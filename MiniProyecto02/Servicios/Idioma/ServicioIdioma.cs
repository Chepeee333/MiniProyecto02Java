namespace MiniProyecto02.Servicios.Idioma
{
    // Textos de la interfaz en Español (es) e Inglés (en).
    public class ServicioIdioma
    {
        private string _codigo = "es";

        private readonly Dictionary<string, string> _es = new Dictionary<string, string>
        {
            ["titulo"] = "Auditoría de Facturación - Logística",
            ["idioma"] = "Idioma:",
            ["gbLote"] = "Lote de paquetes (CÓDIGO;Cliente;Zona;Peso;Valor)",
            ["procesar"] = "Procesar lote",
            ["guardar"] = "Guardar en BD",
            ["historial"] = "Ver historial",
            ["exportar"] = "Exportar CSV",
            ["limpiar"] = "Limpiar",
            ["gbDetalle"] = "Inspección del paquete",
            ["gbErrores"] = "Líneas descartadas",
            ["colCodigo"] = "Código",
            ["colCliente"] = "Cliente",
            ["colZona"] = "Zona",
            ["colPeso"] = "Peso (kg)",
            ["colValor"] = "Valor declarado",
            ["colSubtotal"] = "Subtotal peso",
            ["colRecargo"] = "Recargo zona",
            ["colPenal"] = "Penalización",
            ["colSeguro"] = "Seguro",
            ["colEnvio"] = "Envío fijo",
            ["colIva"] = "IVA",
            ["colTotal"] = "Total",
            ["dDesglose"] = "Desglose financiero",
            ["detalleVacio"] = "Seleccione un paquete en la tabla.",
            ["resumen"] = "Válidos: {0} | Descartados: {1} | Subtotal: {2} | IVA: {3} | Total del lote: {4}",
            ["historialCargado"] = "Historial cargado: {0} registros.",
            ["errConfig"] = "No se encontró el archivo de configuración:\n{0}",
            ["errConfigFormato"] = "El archivo de configuración es inválido: {0}",
            ["loteVacio"] = "Ingrese al menos una línea en el lote.",
            ["sinDatos"] = "No hay datos procesados para esta operación.",
            ["guardadoOk"] = "Lote guardado en la base de datos (Id {0}).",
            ["errBd"] = "Error de base de datos: {0}",
            ["historialVacio"] = "No hay envíos guardados todavía.",
            ["csvOk"] = "Archivo exportado correctamente.",
            ["errArchivo"] = "No se pudo escribir el archivo: {0}",
            ["errInesperado"] = "Ocurrió un error inesperado: {0}",
            ["tituloError"] = "Error",
            ["tituloInfo"] = "Información",
            ["tituloAviso"] = "Aviso",
            ["filtroCsv"] = "Archivos CSV (*.csv)|*.csv",
            ["lineaError"] = "Línea {0}: \"{1}\" -> {2}",
            ["err_vacia"] = "línea vacía",
            ["err_campos"] = "número de campos incorrecto (se esperan 5)",
            ["err_codigo"] = "código vacío",
            ["err_cliente"] = "cliente vacío",
            ["err_zona"] = "zona inválida (A, B o C)",
            ["err_numerico"] = "formato numérico inválido",
            ["err_peso"] = "el peso debe ser mayor que cero",
            ["err_valor"] = "valor declarado negativo",
            ["err_dato"] = "datos inválidos"
        };

        private readonly Dictionary<string, string> _en = new Dictionary<string, string>
        {
            ["titulo"] = "Billing Audit - Logistics",
            ["idioma"] = "Language:",
            ["gbLote"] = "Package batch (CODE;Customer;Zone;Weight;Value)",
            ["procesar"] = "Process batch",
            ["guardar"] = "Save to DB",
            ["historial"] = "View history",
            ["exportar"] = "Export CSV",
            ["limpiar"] = "Clear",
            ["gbDetalle"] = "Package inspection",
            ["gbErrores"] = "Discarded lines",
            ["colCodigo"] = "Code",
            ["colCliente"] = "Customer",
            ["colZona"] = "Zone",
            ["colPeso"] = "Weight (kg)",
            ["colValor"] = "Declared value",
            ["colSubtotal"] = "Weight subtotal",
            ["colRecargo"] = "Zone surcharge",
            ["colPenal"] = "Overweight fee",
            ["colSeguro"] = "Insurance",
            ["colEnvio"] = "Flat shipping",
            ["colIva"] = "VAT",
            ["colTotal"] = "Total",
            ["dDesglose"] = "Financial breakdown",
            ["detalleVacio"] = "Select a package in the table.",
            ["resumen"] = "Valid: {0} | Discarded: {1} | Subtotal: {2} | VAT: {3} | Batch total: {4}",
            ["historialCargado"] = "History loaded: {0} records.",
            ["errConfig"] = "Configuration file not found:\n{0}",
            ["errConfigFormato"] = "The configuration file is invalid: {0}",
            ["loteVacio"] = "Enter at least one line in the batch.",
            ["sinDatos"] = "There is no processed data for this operation.",
            ["guardadoOk"] = "Batch saved to the database (Id {0}).",
            ["errBd"] = "Database error: {0}",
            ["historialVacio"] = "There are no saved shipments yet.",
            ["csvOk"] = "File exported successfully.",
            ["errArchivo"] = "The file could not be written: {0}",
            ["errInesperado"] = "An unexpected error occurred: {0}",
            ["tituloError"] = "Error",
            ["tituloInfo"] = "Information",
            ["tituloAviso"] = "Warning",
            ["filtroCsv"] = "CSV files (*.csv)|*.csv",
            ["lineaError"] = "Line {0}: \"{1}\" -> {2}",
            ["err_vacia"] = "empty line",
            ["err_campos"] = "wrong number of fields (5 expected)",
            ["err_codigo"] = "empty code",
            ["err_cliente"] = "empty customer",
            ["err_zona"] = "invalid zone (A, B or C)",
            ["err_numerico"] = "invalid numeric format",
            ["err_peso"] = "weight must be greater than zero",
            ["err_valor"] = "negative declared value",
            ["err_dato"] = "invalid data"
        };

        public string Codigo
        {
            get => _codigo;
            set => _codigo = value == "en" ? "en" : "es";
        }

        public string T(string clave)
        {
            Dictionary<string, string> tabla = _codigo == "en" ? _en : _es;
            return tabla.TryGetValue(clave, out string texto) ? texto : clave;
        }
    }
}
