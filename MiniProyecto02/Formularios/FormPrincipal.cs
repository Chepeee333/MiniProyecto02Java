using System.Text.Json;
using System.Text;
using MiniProyecto02.Modelos;
using MiniProyecto02.Servicios.Idioma;
using MiniProyecto02.Servicios.Logica;
using MiniProyecto02.Servicios.Persistencia;
using Microsoft.Data.Sqlite;

namespace MiniProyecto02.Formularios
{
    // Capa de presentación: solo captura eventos y muestra resultados; la lógica está en Services.
    public partial class FormPrincipal : Form
    {
        private readonly ServicioIdioma _idioma = new ServicioIdioma();
        private readonly ServicioConfiguracion _servicioConfig = new ServicioConfiguracion();
        private readonly ServicioCsv _servicioCsv = new ServicioCsv();

        private ProcesadorLotes _procesador;
        private RepositorioEnvios _repositorio;
        private ResultadoLote _resultado;
        private Paquete[] _paquetesActuales;
        private Paquete _seleccionado;

        public FormPrincipal()
        {
            InitializeComponent();
            _cmbIdioma.SelectedIndex = 0;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            AplicarIdioma();
            CargarConfiguracion();
        }

        // RF1: lectura obligatoria del JSON al iniciar.
        private void CargarConfiguracion()
        {
            string ruta = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            try
            {
                ConfiguracionApp config = _servicioConfig.Cargar(ruta);
                _procesador = new ProcesadorLotes(config.Tarifas);
                _repositorio = new RepositorioEnvios(config.BaseDatos.Archivo);
            }
            catch (FileNotFoundException)
            {
                Mostrar(string.Format(_idioma.T("errConfig"), ruta), "tituloError", MessageBoxIcon.Error);
            }
            catch (Exception ex) when (ex is JsonException || ex is InvalidDataException)
            {
                Mostrar(string.Format(_idioma.T("errConfigFormato"), ex.Message), "tituloError", MessageBoxIcon.Error);
            }
            catch (SqliteException ex)
            {
                Mostrar(string.Format(_idioma.T("errBd"), ex.Message), "tituloError", MessageBoxIcon.Error);
            }

            _btnProcesar.Enabled = _procesador != null;
            _btnGuardar.Enabled = _repositorio != null;
            _btnHistorial.Enabled = _repositorio != null;
        }

        private void CmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            _idioma.Codigo = _cmbIdioma.SelectedIndex == 1 ? "en" : "es";
            AplicarIdioma();
        }

        // RF2: refresca todos los textos de inmediato.
        private void AplicarIdioma()
        {
            Text = _idioma.T("titulo");
            _lblIdioma.Text = _idioma.T("idioma");
            _gbLote.Text = _idioma.T("gbLote");
            _gbDetalle.Text = _idioma.T("gbDetalle");
            _gbErrores.Text = _idioma.T("gbErrores");
            _btnProcesar.Text = _idioma.T("procesar");
            _btnGuardar.Text = _idioma.T("guardar");
            _btnHistorial.Text = _idioma.T("historial");
            _btnExportar.Text = _idioma.T("exportar");
            _btnLimpiar.Text = _idioma.T("limpiar");

            foreach (DataGridViewColumn columna in _dgv.Columns)
            {
                columna.HeaderText = _idioma.T(columna.Name);
            }

            MostrarErrores();
            MostrarResumen();
            if (_seleccionado != null)
                MostrarDetalle(_seleccionado);
            else
                _txtDetalle.Text = _idioma.T("detalleVacio");
        }

        private void BtnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_txtLote.Text))
                {
                    Mostrar(_idioma.T("loteVacio"), "tituloAviso", MessageBoxIcon.Warning);
                    return;
                }

                _resultado = _procesador.Procesar(_txtLote.Text);
                _paquetesActuales = _resultado.Paquetes;
                _seleccionado = null;
                _dgv.DataSource = _paquetesActuales;
                _dgv.ClearSelection();

                MostrarErrores();
                MostrarResumen();
                _txtDetalle.Text = _idioma.T("detalleVacio");
            }
            catch (Exception ex)
            {
                Mostrar(string.Format(_idioma.T("errInesperado"), ex.Message), "tituloError", MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (_resultado == null || _resultado.Paquetes.Length == 0)
            {
                Mostrar(_idioma.T("sinDatos"), "tituloAviso", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                long id = _repositorio.GuardarLote(_resultado.Paquetes, _resultado.TotalLote);
                Mostrar(string.Format(_idioma.T("guardadoOk"), id), "tituloInfo", MessageBoxIcon.Information);
            }
            catch (SqliteException ex)
            {
                Mostrar(string.Format(_idioma.T("errBd"), ex.Message), "tituloError", MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Mostrar(string.Format(_idioma.T("errInesperado"), ex.Message), "tituloError", MessageBoxIcon.Error);
            }
        }

        private void BtnHistorial_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete[] historial = _repositorio.CargarHistorial();
                if (historial.Length == 0)
                {
                    Mostrar(_idioma.T("historialVacio"), "tituloInfo", MessageBoxIcon.Information);
                    return;
                }

                _resultado = null;
                _seleccionado = null;
                _paquetesActuales = historial;
                _dgv.DataSource = _paquetesActuales;
                _dgv.ClearSelection();

                MostrarErrores();
                MostrarResumen();
                _txtDetalle.Text = _idioma.T("detalleVacio");
            }
            catch (SqliteException ex)
            {
                Mostrar(string.Format(_idioma.T("errBd"), ex.Message), "tituloError", MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Mostrar(string.Format(_idioma.T("errInesperado"), ex.Message), "tituloError", MessageBoxIcon.Error);
            }
        }

        // RF6: la ruta se pide con SaveFileDialog y la escritura la hace el servicio.
        private void BtnExportar_Click(object sender, EventArgs e)
        {
            if (_paquetesActuales == null || _paquetesActuales.Length == 0)
            {
                Mostrar(_idioma.T("sinDatos"), "tituloAviso", MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Filter = _idioma.T("filtroCsv");
                dialogo.DefaultExt = "csv";
                dialogo.FileName = "auditoria_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                if (dialogo.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    _servicioCsv.Exportar(dialogo.FileName, _paquetesActuales, ObtenerEncabezados());
                    Mostrar(_idioma.T("csvOk"), "tituloInfo", MessageBoxIcon.Information);
                }
                catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException ||
                                           ex is ArgumentException || ex is NotSupportedException)
                {
                    Mostrar(string.Format(_idioma.T("errArchivo"), ex.Message), "tituloError", MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    Mostrar(string.Format(_idioma.T("errInesperado"), ex.Message), "tituloError", MessageBoxIcon.Error);
                }
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            _txtLote.Clear();
            _resultado = null;
            _paquetesActuales = null;
            _seleccionado = null;
            _dgv.DataSource = null;
            _txtErrores.Clear();
            _lblResumen.Text = string.Empty;
            _txtDetalle.Text = _idioma.T("detalleVacio");
        }

        // RF5: al hacer clic en una fila se muestra el detalle en el panel lateral.
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Paquete paquete = _dgv.Rows[e.RowIndex].DataBoundItem as Paquete;
            if (paquete != null)
            {
                _seleccionado = paquete;
                MostrarDetalle(paquete);
            }
        }

        private void MostrarDetalle(Paquete p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(_idioma.T("colCodigo") + ": " + p.Codigo);
            sb.AppendLine(_idioma.T("colCliente") + ": " + p.Cliente);
            sb.AppendLine(_idioma.T("colZona") + ": " + p.Zona);
            sb.AppendLine(_idioma.T("colPeso") + ": " + p.PesoKg.ToString("N2"));
            sb.AppendLine(_idioma.T("colValor") + ": " + p.ValorDeclarado.ToString("N2"));
            sb.AppendLine();
            sb.AppendLine("--- " + _idioma.T("dDesglose") + " ---");
            sb.AppendLine(_idioma.T("colSubtotal") + ": " + p.SubtotalPeso.ToString("N2"));
            sb.AppendLine(_idioma.T("colRecargo") + ": " + p.RecargoZona.ToString("N2"));
            sb.AppendLine(_idioma.T("colPenal") + ": " + p.PenalizacionPeso.ToString("N2"));
            sb.AppendLine(_idioma.T("colEnvio") + ": " + p.CostoEnvio.ToString("N2"));
            sb.AppendLine(_idioma.T("colIva") + ": " + p.Impuesto.ToString("N2"));
            sb.AppendLine(_idioma.T("colSeguro") + ": " + p.Seguro.ToString("N2"));
            sb.AppendLine(_idioma.T("colTotal") + ": " + p.Total.ToString("N2"));
            _txtDetalle.Text = sb.ToString();
        }

        private void MostrarErrores()
        {
            if (_resultado == null)
            {
                _txtErrores.Clear();
                return;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _resultado.Errores.Length; i++)
            {
                LineaError error = _resultado.Errores[i];
                sb.AppendLine(string.Format(_idioma.T("lineaError"),
                    error.NumeroLinea, error.Texto, _idioma.T(error.Motivo)));
            }
            _txtErrores.Text = sb.ToString();
        }

        private void MostrarResumen()
        {
            if (_resultado != null)
            {
                _lblResumen.Text = string.Format(_idioma.T("resumen"),
                    _resultado.Paquetes.Length,
                    _resultado.Errores.Length,
                    _resultado.SubtotalLote.ToString("N2"),
                    _resultado.ImpuestoLote.ToString("N2"),
                    _resultado.TotalLote.ToString("N2"));
            }
            else if (_paquetesActuales != null)
            {
                _lblResumen.Text = string.Format(_idioma.T("historialCargado"), _paquetesActuales.Length);
            }
            else
            {
                _lblResumen.Text = string.Empty;
            }
        }

        private string[] ObtenerEncabezados()
        {
            string[] encabezados = new string[_dgv.Columns.Count];
            for (int i = 0; i < encabezados.Length; i++)
            {
                encabezados[i] = _dgv.Columns[i].HeaderText;
            }
            return encabezados;
        }

        private void Mostrar(string mensaje, string claveTitulo, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, _idioma.T(claveTitulo), MessageBoxButtons.OK, icono);
        }
    }
}
