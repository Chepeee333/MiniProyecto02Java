namespace MiniProyecto02.Modelos
{
    public class ResultadoLote
    {
        private readonly Paquete[] _paquetes;
        private readonly LineaError[] _errores;
        private readonly decimal _subtotalLote;
        private readonly decimal _impuestoLote;
        private readonly decimal _totalLote;

        public ResultadoLote(Paquete[] paquetes, LineaError[] errores,
                             decimal subtotalLote, decimal impuestoLote, decimal totalLote)
        {
            _paquetes = paquetes;
            _errores = errores;
            _subtotalLote = subtotalLote;
            _impuestoLote = impuestoLote;
            _totalLote = totalLote;
        }

        public Paquete[] Paquetes => _paquetes;
        public LineaError[] Errores => _errores;
        public decimal SubtotalLote => _subtotalLote;
        public decimal ImpuestoLote => _impuestoLote;
        public decimal TotalLote => _totalLote;
    }
}
