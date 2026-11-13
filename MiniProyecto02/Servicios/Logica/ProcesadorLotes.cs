using MiniProyecto02.Modelos;

namespace MiniProyecto02.Servicios.Logica
{
    // Orquesta: parseo, cálculo por paquete, ordenamiento y totales del lote.
    public class ProcesadorLotes
    {
        private readonly ParserLotes _parser = new ParserLotes();
        private readonly CalculadoraFletes _calculadora;

        public ProcesadorLotes(TarifasConfig tarifas)
        {
            _calculadora = new CalculadoraFletes(tarifas);
        }

        public ResultadoLote Procesar(string texto)
        {
            Paquete[] paquetes = _parser.Parsear(texto, out LineaError[] errores);

            decimal subtotalLote = 0m;
            decimal impuestoLote = 0m;
            decimal totalLote = 0m;

            for (int i = 0; i < paquetes.Length; i++)
            {
                _calculadora.Calcular(paquetes[i]);
                subtotalLote += paquetes[i].SubtotalPeso;
                impuestoLote += paquetes[i].Impuesto;
                totalLote += paquetes[i].Total;
            }

            ServicioArreglos.OrdenarPorTotalDescendente(paquetes);

            return new ResultadoLote(paquetes, errores, subtotalLote, impuestoLote, totalLote);
        }
    }
}
