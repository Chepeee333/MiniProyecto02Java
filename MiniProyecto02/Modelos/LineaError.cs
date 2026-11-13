namespace MiniProyecto02.Modelos
{
    // Línea descartada del lote; Motivo es una clave de idioma (ej. "err_zona").
    public class LineaError
    {
        private readonly int _numeroLinea;
        private readonly string _texto;
        private readonly string _motivo;

        public LineaError(int numeroLinea, string texto, string motivo)
        {
            _numeroLinea = numeroLinea;
            _texto = texto;
            _motivo = motivo;
        }

        public int NumeroLinea => _numeroLinea;
        public string Texto => _texto;
        public string Motivo => _motivo;
    }
}
