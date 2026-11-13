using System.Globalization;
using MiniProyecto02.Modelos;

namespace MiniProyecto02.Servicios.Logica
{
    // Reto 1: sanitiza y valida el lote línea por línea sin detenerse por una línea mala.
    public class ParserLotes
    {
        private const int CapacidadInicial = 5;

        public Paquete[] Parsear(string texto, out LineaError[] errores)
        {
            Paquete[] validos = new Paquete[CapacidadInicial];
            LineaError[] descartadas = new LineaError[CapacidadInicial];
            int cantidadValidos = 0;
            int cantidadErrores = 0;

            string[] lineas = texto.Trim().Replace("\r\n", "\n").Split('\n');

            for (int i = 0; i < lineas.Length; i++)
            {
                string linea = lineas[i].Trim();
                string motivo;
                Paquete paquete = ValidarLinea(linea, out motivo);

                if (paquete != null)
                {
                    ServicioArreglos.Agregar(ref validos, ref cantidadValidos, paquete);
                }
                else
                {
                    ServicioArreglos.Agregar(ref descartadas, ref cantidadErrores,
                        new LineaError(i + 1, linea, motivo));
                }
            }

            errores = ServicioArreglos.Recortar(descartadas, cantidadErrores);
            return ServicioArreglos.Recortar(validos, cantidadValidos);
        }

        private Paquete ValidarLinea(string linea, out string motivo)
        {
            motivo = null;

            if (linea.Length == 0)
            {
                motivo = "err_vacia";
                return null;
            }

            string[] campos = linea.Split(';');
            if (campos.Length != 5)
            {
                motivo = "err_campos";
                return null;
            }

            for (int i = 0; i < campos.Length; i++)
            {
                campos[i] = campos[i].Trim();
            }

            string codigo = campos[0];
            string cliente = campos[1];
            string zona = string.Join(" ", campos[2].Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToUpper();

            if (codigo.Length == 0)
            {
                motivo = "err_codigo";
                return null;
            }
            if (cliente.Length == 0)
            {
                motivo = "err_cliente";
                return null;
            }
            if (zona != "ZONA A" && zona != "ZONA B" && zona != "ZONA C")
            {
                motivo = "err_zona";
                return null;
            }

            decimal peso;
            decimal valor;
            if (!decimal.TryParse(campos[3], NumberStyles.Number, CultureInfo.InvariantCulture, out peso) ||
                !decimal.TryParse(campos[4], NumberStyles.Number, CultureInfo.InvariantCulture, out valor))
            {
                motivo = "err_numerico";
                return null;
            }

            if (peso <= 0)
            {
                motivo = "err_peso";
                return null;
            }
            if (valor < 0)
            {
                motivo = "err_valor";
                return null;
            }

            try
            {
                return new Paquete(codigo, cliente, zona, peso, valor);
            }
            catch (ArgumentException)
            {
                motivo = "err_dato";
                return null;
            }
        }
    }
}
