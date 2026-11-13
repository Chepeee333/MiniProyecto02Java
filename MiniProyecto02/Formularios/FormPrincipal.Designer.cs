using MiniProyecto02.Modelos;
using MiniProyecto02.Servicios.Idioma;
using MiniProyecto02.Servicios.Logica;
using MiniProyecto02.Servicios.Persistencia;

namespace MiniProyecto02.Formularios
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            DataGridViewCellStyle estilo1 = new DataGridViewCellStyle();
            DataGridViewCellStyle estilo2 = new DataGridViewCellStyle();
            DataGridViewCellStyle estilo3 = new DataGridViewCellStyle();
            DataGridViewCellStyle estilo4 = new DataGridViewCellStyle();
            DataGridViewCellStyle estilo5 = new DataGridViewCellStyle();
            DataGridViewCellStyle estilo6 = new DataGridViewCellStyle();
            DataGridViewCellStyle estilo7 = new DataGridViewCellStyle();
            DataGridViewCellStyle estilo8 = new DataGridViewCellStyle();
            DataGridViewCellStyle estilo9 = new DataGridViewCellStyle();
            _panelIdioma = new Panel();
            _lblIdioma = new Label();
            _cmbIdioma = new ComboBox();
            _gbLote = new GroupBox();
            _txtLote = new TextBox();
            _panelBotones = new FlowLayoutPanel();
            _btnProcesar = new Button();
            _btnGuardar = new Button();
            _btnHistorial = new Button();
            _btnExportar = new Button();
            _btnLimpiar = new Button();
            _lblResumen = new Label();
            _gbErrores = new GroupBox();
            _txtErrores = new TextBox();
            _gbDetalle = new GroupBox();
            _txtDetalle = new TextBox();
            _dgv = new DataGridView();
            _colCodigo = new DataGridViewTextBoxColumn();
            _colCliente = new DataGridViewTextBoxColumn();
            _colZona = new DataGridViewTextBoxColumn();
            _colPeso = new DataGridViewTextBoxColumn();
            _colValor = new DataGridViewTextBoxColumn();
            _colSubtotal = new DataGridViewTextBoxColumn();
            _colRecargo = new DataGridViewTextBoxColumn();
            _colPenal = new DataGridViewTextBoxColumn();
            _colSeguro = new DataGridViewTextBoxColumn();
            _colEnvio = new DataGridViewTextBoxColumn();
            _colIva = new DataGridViewTextBoxColumn();
            _colTotal = new DataGridViewTextBoxColumn();
            _panelIdioma.SuspendLayout();
            _gbLote.SuspendLayout();
            _panelBotones.SuspendLayout();
            _gbErrores.SuspendLayout();
            _gbDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgv).BeginInit();
            SuspendLayout();
            //
            // _panelIdioma
            //
            _panelIdioma.Controls.Add(_lblIdioma);
            _panelIdioma.Controls.Add(_cmbIdioma);
            _panelIdioma.Dock = DockStyle.Top;
            _panelIdioma.Name = "_panelIdioma";
            _panelIdioma.Size = new Size(1184, 42);
            _panelIdioma.TabIndex = 6;
            //
            // _lblIdioma
            //
            _lblIdioma.AutoSize = true;
            _lblIdioma.Location = new Point(12, 15);
            _lblIdioma.Name = "_lblIdioma";
            _lblIdioma.Size = new Size(55, 15);
            _lblIdioma.TabIndex = 0;
            _lblIdioma.Text = "Idioma:";
            //
            // _cmbIdioma
            //
            _cmbIdioma.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbIdioma.FormattingEnabled = true;
            _cmbIdioma.Items.AddRange(new object[] { "Español", "English" });
            _cmbIdioma.Location = new Point(100, 11);
            _cmbIdioma.Name = "_cmbIdioma";
            _cmbIdioma.Size = new Size(140, 23);
            _cmbIdioma.TabIndex = 1;
            _cmbIdioma.SelectedIndexChanged += CmbIdioma_SelectedIndexChanged;
            //
            // _gbLote
            //
            _gbLote.Controls.Add(_txtLote);
            _gbLote.Dock = DockStyle.Top;
            _gbLote.Name = "_gbLote";
            _gbLote.Size = new Size(1184, 140);
            _gbLote.TabIndex = 5;
            _gbLote.TabStop = false;
            _gbLote.Text = "Lote de paquetes";
            //
            // _txtLote
            //
            _txtLote.Dock = DockStyle.Fill;
            _txtLote.Multiline = true;
            _txtLote.Name = "_txtLote";
            _txtLote.ScrollBars = ScrollBars.Both;
            _txtLote.TabIndex = 0;
            _txtLote.WordWrap = false;
            _txtLote.Text = " PACK-001 ; Juan Perez ; Zona A ; 12.5 ; 150.0 \r\nPACK-002; Maria Lopez; Zona C; -5.0; 200.0\r\nPACK-003; Pedro Gomez; Zona B; ABC; 100.0\r\nPACK-004; Ana Ruiz; Zona C; 28.0; 1500.0\r\nPACK-005; Luis Soto; zona   b; 8; 300";
            //
            // _panelBotones
            //
            _panelBotones.Controls.Add(_btnProcesar);
            _panelBotones.Controls.Add(_btnGuardar);
            _panelBotones.Controls.Add(_btnHistorial);
            _panelBotones.Controls.Add(_btnExportar);
            _panelBotones.Controls.Add(_btnLimpiar);
            _panelBotones.Dock = DockStyle.Top;
            _panelBotones.Name = "_panelBotones";
            _panelBotones.Padding = new Padding(6);
            _panelBotones.Size = new Size(1184, 46);
            _panelBotones.TabIndex = 4;
            //
            // _btnProcesar
            //
            _btnProcesar.AutoSize = true;
            _btnProcesar.MinimumSize = new Size(120, 30);
            _btnProcesar.Name = "_btnProcesar";
            _btnProcesar.TabIndex = 0;
            _btnProcesar.Text = "Procesar lote";
            _btnProcesar.UseVisualStyleBackColor = true;
            _btnProcesar.Click += BtnProcesar_Click;
            //
            // _btnGuardar
            //
            _btnGuardar.AutoSize = true;
            _btnGuardar.MinimumSize = new Size(120, 30);
            _btnGuardar.Name = "_btnGuardar";
            _btnGuardar.TabIndex = 1;
            _btnGuardar.Text = "Guardar en BD";
            _btnGuardar.UseVisualStyleBackColor = true;
            _btnGuardar.Click += BtnGuardar_Click;
            //
            // _btnHistorial
            //
            _btnHistorial.AutoSize = true;
            _btnHistorial.MinimumSize = new Size(120, 30);
            _btnHistorial.Name = "_btnHistorial";
            _btnHistorial.TabIndex = 2;
            _btnHistorial.Text = "Ver historial";
            _btnHistorial.UseVisualStyleBackColor = true;
            _btnHistorial.Click += BtnHistorial_Click;
            //
            // _btnExportar
            //
            _btnExportar.AutoSize = true;
            _btnExportar.MinimumSize = new Size(120, 30);
            _btnExportar.Name = "_btnExportar";
            _btnExportar.TabIndex = 3;
            _btnExportar.Text = "Exportar CSV";
            _btnExportar.UseVisualStyleBackColor = true;
            _btnExportar.Click += BtnExportar_Click;
            //
            // _btnLimpiar
            //
            _btnLimpiar.AutoSize = true;
            _btnLimpiar.MinimumSize = new Size(120, 30);
            _btnLimpiar.Name = "_btnLimpiar";
            _btnLimpiar.TabIndex = 4;
            _btnLimpiar.Text = "Limpiar";
            _btnLimpiar.UseVisualStyleBackColor = true;
            _btnLimpiar.Click += BtnLimpiar_Click;
            //
            // _lblResumen
            //
            _lblResumen.Dock = DockStyle.Bottom;
            _lblResumen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            _lblResumen.Name = "_lblResumen";
            _lblResumen.Size = new Size(1184, 28);
            _lblResumen.TabIndex = 3;
            _lblResumen.TextAlign = ContentAlignment.MiddleLeft;
            //
            // _gbErrores
            //
            _gbErrores.Controls.Add(_txtErrores);
            _gbErrores.Dock = DockStyle.Bottom;
            _gbErrores.Name = "_gbErrores";
            _gbErrores.Size = new Size(1184, 120);
            _gbErrores.TabIndex = 2;
            _gbErrores.TabStop = false;
            _gbErrores.Text = "Líneas descartadas";
            //
            // _txtErrores
            //
            _txtErrores.Dock = DockStyle.Fill;
            _txtErrores.Multiline = true;
            _txtErrores.Name = "_txtErrores";
            _txtErrores.ReadOnly = true;
            _txtErrores.ScrollBars = ScrollBars.Vertical;
            _txtErrores.TabIndex = 0;
            //
            // _gbDetalle
            //
            _gbDetalle.Controls.Add(_txtDetalle);
            _gbDetalle.Dock = DockStyle.Right;
            _gbDetalle.Name = "_gbDetalle";
            _gbDetalle.Size = new Size(320, 400);
            _gbDetalle.TabIndex = 1;
            _gbDetalle.TabStop = false;
            _gbDetalle.Text = "Inspección del paquete";
            //
            // _txtDetalle
            //
            _txtDetalle.Dock = DockStyle.Fill;
            _txtDetalle.Font = new Font("Consolas", 10F);
            _txtDetalle.Multiline = true;
            _txtDetalle.Name = "_txtDetalle";
            _txtDetalle.ReadOnly = true;
            _txtDetalle.ScrollBars = ScrollBars.Vertical;
            _txtDetalle.TabIndex = 0;
            //
            // _dgv
            //
            _dgv.AllowUserToAddRows = false;
            _dgv.AllowUserToDeleteRows = false;
            _dgv.AutoGenerateColumns = false;
            _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _dgv.Columns.AddRange(new DataGridViewColumn[] { _colCodigo, _colCliente, _colZona, _colPeso, _colValor, _colSubtotal, _colRecargo, _colPenal, _colSeguro, _colEnvio, _colIva, _colTotal });
            _dgv.Dock = DockStyle.Fill;
            _dgv.MultiSelect = false;
            _dgv.Name = "_dgv";
            _dgv.ReadOnly = true;
            _dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgv.TabIndex = 0;
            _dgv.CellClick += Dgv_CellClick;
            //
            // _colCodigo
            //
            _colCodigo.DataPropertyName = "Codigo";
            _colCodigo.HeaderText = "Código";
            _colCodigo.Name = "colCodigo";
            _colCodigo.ReadOnly = true;
            //
            // _colCliente
            //
            _colCliente.DataPropertyName = "Cliente";
            _colCliente.HeaderText = "Cliente";
            _colCliente.Name = "colCliente";
            _colCliente.ReadOnly = true;
            //
            // _colZona
            //
            _colZona.DataPropertyName = "Zona";
            _colZona.HeaderText = "Zona";
            _colZona.Name = "colZona";
            _colZona.ReadOnly = true;
            //
            // _colPeso
            //
            _colPeso.DataPropertyName = "PesoKg";
            _colPeso.HeaderText = "Peso (kg)";
            _colPeso.Name = "colPeso";
            _colPeso.ReadOnly = true;
            estilo1.Alignment = DataGridViewContentAlignment.MiddleRight;
            estilo1.Format = "N2";
            _colPeso.DefaultCellStyle = estilo1;
            //
            // _colValor
            //
            _colValor.DataPropertyName = "ValorDeclarado";
            _colValor.HeaderText = "Valor declarado";
            _colValor.Name = "colValor";
            _colValor.ReadOnly = true;
            estilo2.Alignment = DataGridViewContentAlignment.MiddleRight;
            estilo2.Format = "N2";
            _colValor.DefaultCellStyle = estilo2;
            //
            // _colSubtotal
            //
            _colSubtotal.DataPropertyName = "SubtotalPeso";
            _colSubtotal.HeaderText = "Subtotal peso";
            _colSubtotal.Name = "colSubtotal";
            _colSubtotal.ReadOnly = true;
            estilo3.Alignment = DataGridViewContentAlignment.MiddleRight;
            estilo3.Format = "N2";
            _colSubtotal.DefaultCellStyle = estilo3;
            //
            // _colRecargo
            //
            _colRecargo.DataPropertyName = "RecargoZona";
            _colRecargo.HeaderText = "Recargo zona";
            _colRecargo.Name = "colRecargo";
            _colRecargo.ReadOnly = true;
            estilo4.Alignment = DataGridViewContentAlignment.MiddleRight;
            estilo4.Format = "N2";
            _colRecargo.DefaultCellStyle = estilo4;
            //
            // _colPenal
            //
            _colPenal.DataPropertyName = "PenalizacionPeso";
            _colPenal.HeaderText = "Penalización";
            _colPenal.Name = "colPenal";
            _colPenal.ReadOnly = true;
            estilo5.Alignment = DataGridViewContentAlignment.MiddleRight;
            estilo5.Format = "N2";
            _colPenal.DefaultCellStyle = estilo5;
            //
            // _colSeguro
            //
            _colSeguro.DataPropertyName = "Seguro";
            _colSeguro.HeaderText = "Seguro";
            _colSeguro.Name = "colSeguro";
            _colSeguro.ReadOnly = true;
            estilo6.Alignment = DataGridViewContentAlignment.MiddleRight;
            estilo6.Format = "N2";
            _colSeguro.DefaultCellStyle = estilo6;
            //
            // _colEnvio
            //
            _colEnvio.DataPropertyName = "CostoEnvio";
            _colEnvio.HeaderText = "Envío fijo";
            _colEnvio.Name = "colEnvio";
            _colEnvio.ReadOnly = true;
            estilo7.Alignment = DataGridViewContentAlignment.MiddleRight;
            estilo7.Format = "N2";
            _colEnvio.DefaultCellStyle = estilo7;
            //
            // _colIva
            //
            _colIva.DataPropertyName = "Impuesto";
            _colIva.HeaderText = "IVA";
            _colIva.Name = "colIva";
            _colIva.ReadOnly = true;
            estilo8.Alignment = DataGridViewContentAlignment.MiddleRight;
            estilo8.Format = "N2";
            _colIva.DefaultCellStyle = estilo8;
            //
            // _colTotal
            //
            _colTotal.DataPropertyName = "Total";
            _colTotal.HeaderText = "Total";
            _colTotal.Name = "colTotal";
            _colTotal.ReadOnly = true;
            estilo9.Alignment = DataGridViewContentAlignment.MiddleRight;
            estilo9.Format = "N2";
            _colTotal.DefaultCellStyle = estilo9;
            //
            // FormPrincipal
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 721);
            Controls.Add(_dgv);
            Controls.Add(_gbDetalle);
            Controls.Add(_gbErrores);
            Controls.Add(_lblResumen);
            Controls.Add(_panelBotones);
            Controls.Add(_gbLote);
            Controls.Add(_panelIdioma);
            MinimumSize = new Size(1000, 640);
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Auditoría de Facturación - Logística";
            Load += FormPrincipal_Load;
            _panelIdioma.ResumeLayout(false);
            _panelIdioma.PerformLayout();
            _gbLote.ResumeLayout(false);
            _gbLote.PerformLayout();
            _panelBotones.ResumeLayout(false);
            _panelBotones.PerformLayout();
            _gbErrores.ResumeLayout(false);
            _gbErrores.PerformLayout();
            _gbDetalle.ResumeLayout(false);
            _gbDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel _panelIdioma;
        private Label _lblIdioma;
        private ComboBox _cmbIdioma;
        private GroupBox _gbLote;
        private TextBox _txtLote;
        private FlowLayoutPanel _panelBotones;
        private Button _btnProcesar;
        private Button _btnGuardar;
        private Button _btnHistorial;
        private Button _btnExportar;
        private Button _btnLimpiar;
        private Label _lblResumen;
        private GroupBox _gbErrores;
        private TextBox _txtErrores;
        private GroupBox _gbDetalle;
        private TextBox _txtDetalle;
        private DataGridView _dgv;
        private DataGridViewTextBoxColumn _colCodigo;
        private DataGridViewTextBoxColumn _colCliente;
        private DataGridViewTextBoxColumn _colZona;
        private DataGridViewTextBoxColumn _colPeso;
        private DataGridViewTextBoxColumn _colValor;
        private DataGridViewTextBoxColumn _colSubtotal;
        private DataGridViewTextBoxColumn _colRecargo;
        private DataGridViewTextBoxColumn _colPenal;
        private DataGridViewTextBoxColumn _colSeguro;
        private DataGridViewTextBoxColumn _colEnvio;
        private DataGridViewTextBoxColumn _colIva;
        private DataGridViewTextBoxColumn _colTotal;
    }
}
