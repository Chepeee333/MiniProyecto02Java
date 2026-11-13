using MiniProyecto02.Modelos;

namespace MiniProyecto02.Servicios.Logica
{
    // Reto 3: tarifa escalonada. Aquí vive toda la lógica financiera.
    public class CalculadoraFletes
    {
        private const decimal LimitePesoKg = 20m;
        private const decimal PenalizacionPorKgExtra = 0.25m;
        private const decimal LimiteSeguro = 1000m;
        private const decimal TasaSeguro = 0.02m;

        private readonly TarifasConfig _tarifas;

        public CalculadoraFletes(TarifasConfig tarifas)
        {
            _tarifas = tarifas;
        }

        public void Calcular(Paquete paquete)
        {
            decimal subtotalPeso = paquete.PesoKg * _tarifas.PrecioBaseKg;

            decimal tasaZona;
            switch (paquete.Zona)
            {
                case "ZONA A":
                    tasaZona = 0.05m;
                    break;
                case "ZONA B":
                    tasaZona = 0.10m;
                    break;
                case "ZONA C":
                    tasaZona = 0.18m;
                    break;
                default:
                    throw new ArgumentException("Zona no reconocida: " + paquete.Zona);
            }
            decimal recargoZona = subtotalPeso * tasaZona;

            decimal penalizacion = 0m;
            if (paquete.PesoKg > LimitePesoKg)
            {
                penalizacion = (paquete.PesoKg - LimitePesoKg) * _tarifas.PrecioBaseKg * PenalizacionPorKgExtra;
            }

            decimal seguro = 0m;
            if (paquete.ValorDeclarado > LimiteSeguro)
            {
                seguro = paquete.ValorDeclarado * TasaSeguro;
            }

            // El IVA se aplica sobre el flete (peso + recargo + penalización + envío); el seguro se suma aparte.
            decimal baseImponible = subtotalPeso + recargoZona + penalizacion + _tarifas.CostoFijoEnvio;
            decimal impuesto = baseImponible * _tarifas.TasaIva;

            paquete.AsignarDesglose(
                Redondear(subtotalPeso),
                Redondear(recargoZona),
                Redondear(penalizacion),
                Redondear(seguro),
                Redondear(_tarifas.CostoFijoEnvio),
                Redondear(impuesto));
        }

        private static decimal Redondear(decimal valor)
        {
            return Math.Round(valor, 2, MidpointRounding.AwayFromZero);
        }
    }
}
