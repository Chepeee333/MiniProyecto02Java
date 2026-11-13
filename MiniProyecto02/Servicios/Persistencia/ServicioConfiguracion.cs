using System.Text.Json;
using MiniProyecto02.Modelos;
using MiniProyecto02.Servicios.Logica;

namespace MiniProyecto02.Servicios.Persistencia
{
    public class ServicioConfiguracion
    {
        public ConfiguracionApp Cargar(string ruta)
        {
            if (!File.Exists(ruta))
                throw new FileNotFoundException("No existe el archivo de configuración.", ruta);

            string json = File.ReadAllText(ruta);
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            ConfiguracionApp config = JsonSerializer.Deserialize<ConfiguracionApp>(json, opciones);

            if (config == null || config.Tarifas == null)
                throw new InvalidDataException("Falta la sección Tarifas.");
            if (config.Tarifas.PrecioBaseKg <= 0 || config.Tarifas.TasaIva < 0 || config.Tarifas.CostoFijoEnvio < 0)
                throw new InvalidDataException("Valores de tarifa fuera de rango.");

            return config;
        }
    }
}
