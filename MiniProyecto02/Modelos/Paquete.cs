namespace MiniProyecto02.Modelos
{
    // Entidad de dominio: un paquete/factura con su desglose financiero.
    public class Paquete
    {
        private string _codigo;
        private string _cliente;
        private string _zona;
        private decimal _pesoKg;
        private decimal _valorDeclarado;
        private decimal _subtotalPeso;
        private decimal _recargoZona;
        private decimal _penalizacionPeso;
        private decimal _seguro;
        private decimal _costoEnvio;
        private decimal _impuesto;
        private decimal _total;

        public Paquete(string codigo, string cliente, string zona, decimal pesoKg, decimal valorDeclarado)
        {
            Codigo = codigo;
            Cliente = cliente;
            Zona = zona;
            PesoKg = pesoKg;
            ValorDeclarado = valorDeclarado;
        }

        public string Codigo
        {
            get => _codigo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Código vacío.");
                _codigo = value.Trim().ToUpper();
            }
        }

        public string Cliente
        {
            get => _cliente;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Cliente vacío.");
                _cliente = value.Trim();
            }
        }

        public string Zona
        {
            get => _zona;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Zona vacía.");
                _zona = value.Trim().ToUpper();
            }
        }

        public decimal PesoKg
        {
            get => _pesoKg;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El peso debe ser mayor que cero.");
                _pesoKg = value;
            }
        }

        public decimal ValorDeclarado
        {
            get => _valorDeclarado;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El valor declarado no puede ser negativo.");
                _valorDeclarado = value;
            }
        }

        public decimal SubtotalPeso => _subtotalPeso;
        public decimal RecargoZona => _recargoZona;
        public decimal PenalizacionPeso => _penalizacionPeso;
        public decimal Seguro => _seguro;
        public decimal CostoEnvio => _costoEnvio;
        public decimal Impuesto => _impuesto;
        public decimal Total => _total;

        public void AsignarDesglose(decimal subtotalPeso, decimal recargoZona, decimal penalizacionPeso,
                                    decimal seguro, decimal costoEnvio, decimal impuesto)
        {
            _subtotalPeso = subtotalPeso;
            _recargoZona = recargoZona;
            _penalizacionPeso = penalizacionPeso;
            _seguro = seguro;
            _costoEnvio = costoEnvio;
            _impuesto = impuesto;
            _total = subtotalPeso + recargoZona + penalizacionPeso + seguro + costoEnvio + impuesto;
        }
    }
}
