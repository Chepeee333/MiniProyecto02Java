using System.Globalization;
using System.Text;
using MiniProyecto02.Modelos;
using MiniProyecto02.Servicios.Logica;

namespace MiniProyecto02.Servicios.Persistencia
{
    public class ServicioCsv
    {
        public void Exportar(string ruta, Paquete[] paquetes, string[] encabezados)
        {
            using (StreamWriter escritor = new StreamWriter(ruta, false, new UTF8Encoding(true)))
            {
                string[] cabecera = new string[encabezados.Length];
                for (int i = 0; i < encabezados.Length; i++)
                {
                    cabecera[i] = Escapar(encabezados[i]);
                }
                escritor.WriteLine(string.Join(",", cabecera));

                for (int i = 0; i < paquetes.Length; i++)
                {
                    Paquete p = paquetes[i];
                    string[] fila =
                    {
                        Escapar(p.Codigo),
                        Escapar(p.Cliente),
                        Escapar(p.Zona),
                        Numero(p.PesoKg),
                        Numero(p.ValorDeclarado),
                        Numero(p.SubtotalPeso),
                        Numero(p.RecargoZona),
                        Numero(p.PenalizacionPeso),
                        Numero(p.Seguro),
                        Numero(p.CostoEnvio),
                        Numero(p.Impuesto),
                        Numero(p.Total)
                    };
                    escritor.WriteLine(string.Join(",", fila));
                }
            }
        }

        private static string Numero(decimal valor)
        {
            return valor.ToString("F2", CultureInfo.InvariantCulture);
        }

        private static string Escapar(string valor)
        {
            if (valor.Contains(',') || valor.Contains('"'))
                return "\"" + valor.Replace("\"", "\"\"") + "\"";
            return valor;
        }
    }
}
