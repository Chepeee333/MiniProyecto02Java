namespace MiniProyecto02.Modelos
{
    // Clases que reflejan la estructura de appsettings.json.
    public class ConfiguracionApp
    {
        private TarifasConfig _tarifas = new TarifasConfig();
        private BaseDatosConfig _baseDatos = new BaseDatosConfig();

        public TarifasConfig Tarifas
        {
            get => _tarifas;
            set => _tarifas = value;
        }

        public BaseDatosConfig BaseDatos
        {
            get => _baseDatos;
            set => _baseDatos = value;
        }
    }

    public class TarifasConfig
    {
        private decimal _precioBaseKg;
        private decimal _tasaIva;
        private decimal _costoFijoEnvio;

        public decimal PrecioBaseKg
        {
            get => _precioBaseKg;
            set => _precioBaseKg = value;
        }

        public decimal TasaIva
        {
            get => _tasaIva;
            set => _tasaIva = value;
        }

        public decimal CostoFijoEnvio
        {
            get => _costoFijoEnvio;
            set => _costoFijoEnvio = value;
        }
    }

    public class BaseDatosConfig
    {
        private string _archivo = "logistica.db";

        public string Archivo
        {
            get => _archivo;
            set => _archivo = value;
        }
    }
}
