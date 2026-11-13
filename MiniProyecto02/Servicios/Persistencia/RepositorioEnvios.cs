using MiniProyecto02.Modelos;
using MiniProyecto02.Servicios.Logica;
using Microsoft.Data.Sqlite;

namespace MiniProyecto02.Servicios.Persistencia
{
    // Persistencia en SQLite: tabla Lotes (cabecera) y Envios (detalle).
    public class RepositorioEnvios
    {
        private readonly string _cadenaConexion;

        public RepositorioEnvios(string archivoDb)
        {
            string ruta = Path.Combine(AppContext.BaseDirectory, archivoDb);
            _cadenaConexion = "Data Source=" + ruta;
            CrearTablas();
        }

        private void CrearTablas()
        {
            using (var conexion = new SqliteConnection(_cadenaConexion))
            {
                conexion.Open();
                using (var comando = conexion.CreateCommand())
                {
                    comando.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Lotes (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Fecha TEXT NOT NULL,
                            TotalPaquetes INTEGER NOT NULL,
                            TotalLote REAL NOT NULL
                        );
                        CREATE TABLE IF NOT EXISTS Envios (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            LoteId INTEGER NOT NULL,
                            Codigo TEXT NOT NULL,
                            Cliente TEXT NOT NULL,
                            Zona TEXT NOT NULL,
                            PesoKg REAL NOT NULL,
                            ValorDeclarado REAL NOT NULL,
                            SubtotalPeso REAL NOT NULL,
                            RecargoZona REAL NOT NULL,
                            Penalizacion REAL NOT NULL,
                            Seguro REAL NOT NULL,
                            CostoEnvio REAL NOT NULL,
                            Impuesto REAL NOT NULL,
                            Total REAL NOT NULL,
                            FOREIGN KEY (LoteId) REFERENCES Lotes(Id)
                        );";
                    comando.ExecuteNonQuery();
                }
            }
        }

        // Guarda el lote completo en una sola transacción.
        public long GuardarLote(Paquete[] paquetes, decimal totalLote)
        {
            using (var conexion = new SqliteConnection(_cadenaConexion))
            {
                conexion.Open();
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        long loteId;
                        using (var cmdLote = conexion.CreateCommand())
                        {
                            cmdLote.Transaction = transaccion;
                            cmdLote.CommandText = @"
                                INSERT INTO Lotes (Fecha, TotalPaquetes, TotalLote)
                                VALUES ($fecha, $cantidad, $total);
                                SELECT last_insert_rowid();";
                            cmdLote.Parameters.AddWithValue("$fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmdLote.Parameters.AddWithValue("$cantidad", paquetes.Length);
                            cmdLote.Parameters.AddWithValue("$total", (double)totalLote);
                            loteId = (long)cmdLote.ExecuteScalar();
                        }

                        for (int i = 0; i < paquetes.Length; i++)
                        {
                            Paquete p = paquetes[i];
                            using (var cmd = conexion.CreateCommand())
                            {
                                cmd.Transaction = transaccion;
                                cmd.CommandText = @"
                                    INSERT INTO Envios (LoteId, Codigo, Cliente, Zona, PesoKg, ValorDeclarado,
                                        SubtotalPeso, RecargoZona, Penalizacion, Seguro, CostoEnvio, Impuesto, Total)
                                    VALUES ($lote, $codigo, $cliente, $zona, $peso, $valor,
                                        $subtotal, $recargo, $penal, $seguro, $envio, $impuesto, $total);";
                                cmd.Parameters.AddWithValue("$lote", loteId);
                                cmd.Parameters.AddWithValue("$codigo", p.Codigo);
                                cmd.Parameters.AddWithValue("$cliente", p.Cliente);
                                cmd.Parameters.AddWithValue("$zona", p.Zona);
                                cmd.Parameters.AddWithValue("$peso", (double)p.PesoKg);
                                cmd.Parameters.AddWithValue("$valor", (double)p.ValorDeclarado);
                                cmd.Parameters.AddWithValue("$subtotal", (double)p.SubtotalPeso);
                                cmd.Parameters.AddWithValue("$recargo", (double)p.RecargoZona);
                                cmd.Parameters.AddWithValue("$penal", (double)p.PenalizacionPeso);
                                cmd.Parameters.AddWithValue("$seguro", (double)p.Seguro);
                                cmd.Parameters.AddWithValue("$envio", (double)p.CostoEnvio);
                                cmd.Parameters.AddWithValue("$impuesto", (double)p.Impuesto);
                                cmd.Parameters.AddWithValue("$total", (double)p.Total);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaccion.Commit();
                        return loteId;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        public Paquete[] CargarHistorial()
        {
            Paquete[] resultado = new Paquete[10];
            int cantidad = 0;

            using (var conexion = new SqliteConnection(_cadenaConexion))
            {
                conexion.Open();
                using (var comando = conexion.CreateCommand())
                {
                    comando.CommandText = @"
                        SELECT Codigo, Cliente, Zona, PesoKg, ValorDeclarado,
                               SubtotalPeso, RecargoZona, Penalizacion, Seguro, CostoEnvio, Impuesto
                        FROM Envios ORDER BY Id DESC;";
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Paquete p = new Paquete(
                                lector.GetString(0),
                                lector.GetString(1),
                                lector.GetString(2),
                                (decimal)lector.GetDouble(3),
                                (decimal)lector.GetDouble(4));
                            p.AsignarDesglose(
                                (decimal)lector.GetDouble(5),
                                (decimal)lector.GetDouble(6),
                                (decimal)lector.GetDouble(7),
                                (decimal)lector.GetDouble(8),
                                (decimal)lector.GetDouble(9),
                                (decimal)lector.GetDouble(10));
                            ServicioArreglos.Agregar(ref resultado, ref cantidad, p);
                        }
                    }
                }
            }

            return ServicioArreglos.Recortar(resultado, cantidad);
        }
    }
}
