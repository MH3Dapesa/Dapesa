namespace Dapesa.Tesoreria.Bancos.IU.Cobros
{
    partial class HSBC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HSBC));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpMovimientosCorrectos = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnImprimirMovimientoC = new System.Windows.Forms.Button();
            this.btnGuardarMovimientoC = new System.Windows.Forms.Button();
            this.gvMovimientosCorrectos = new System.Windows.Forms.DataGridView();
            this.btnExportarXlsxC = new System.Windows.Forms.Button();
            this.tpMovimientosErrores = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnImprimirMovimientoR = new System.Windows.Forms.Button();
            this.btnGuardarMovimientoR = new System.Windows.Forms.Button();
            this.gvMovimientosErrores = new System.Windows.Forms.DataGridView();
            this.btnExportarXlsxR = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.pbMovimientos = new System.Windows.Forms.ProgressBar();
            this.lblImpresora = new System.Windows.Forms.Label();
            this.cbImpresora = new System.Windows.Forms.ComboBox();
            this.lblEstatus = new System.Windows.Forms.Label();
            this.lblBanco = new System.Windows.Forms.Label();
            this.ofdArchivo = new System.Windows.Forms.OpenFileDialog();
            this.sfdGuardar = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpMovimientosCorrectos.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMovimientosCorrectos)).BeginInit();
            this.tpMovimientosErrores.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvMovimientosErrores)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblArchivo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtArchivo, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnProcesar, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblResultado, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.pbMovimientos, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblImpresora, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbImpresora, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblEstatus, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblBanco, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(746, 379);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 2);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Dapesa.Tesoreria.Bancos.IU.Cobros.Properties.Resources.dapesa;
            this.pictureBox1.Location = new System.Drawing.Point(561, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblArchivo.Location = new System.Drawing.Point(39, 49);
            this.lblArchivo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(145, 27);
            this.lblArchivo.TabIndex = 1;
            this.lblArchivo.Text = "Archivo:";
            this.lblArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtArchivo
            // 
            this.txtArchivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtArchivo.Enabled = false;
            this.txtArchivo.Location = new System.Drawing.Point(188, 51);
            this.txtArchivo.Margin = new System.Windows.Forms.Padding(2);
            this.txtArchivo.Multiline = true;
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(369, 23);
            this.txtArchivo.TabIndex = 2;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProcesar.Location = new System.Drawing.Point(561, 51);
            this.btnProcesar.Margin = new System.Windows.Forms.Padding(2);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(145, 23);
            this.btnProcesar.TabIndex = 3;
            this.btnProcesar.Text = "Procesar archivo";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // tabControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tabControl1, 3);
            this.tabControl1.Controls.Add(this.tpMovimientosCorrectos);
            this.tabControl1.Controls.Add(this.tpMovimientosErrores);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(39, 125);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(667, 252);
            this.tabControl1.TabIndex = 4;
            // 
            // tpMovimientosCorrectos
            // 
            this.tpMovimientosCorrectos.BackColor = System.Drawing.Color.Transparent;
            this.tpMovimientosCorrectos.Controls.Add(this.tableLayoutPanel2);
            this.tpMovimientosCorrectos.Location = new System.Drawing.Point(4, 22);
            this.tpMovimientosCorrectos.Margin = new System.Windows.Forms.Padding(2);
            this.tpMovimientosCorrectos.Name = "tpMovimientosCorrectos";
            this.tpMovimientosCorrectos.Padding = new System.Windows.Forms.Padding(2);
            this.tpMovimientosCorrectos.Size = new System.Drawing.Size(659, 226);
            this.tpMovimientosCorrectos.TabIndex = 0;
            this.tpMovimientosCorrectos.Text = "Correcto";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.Controls.Add(this.btnImprimirMovimientoC, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnGuardarMovimientoC, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.gvMovimientosCorrectos, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnExportarXlsxC, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(655, 222);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnImprimirMovimientoC
            // 
            this.btnImprimirMovimientoC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImprimirMovimientoC.Image = global::Dapesa.Tesoreria.Bancos.IU.Cobros.Properties.Resources.impresora;
            this.btnImprimirMovimientoC.Location = new System.Drawing.Point(433, 2);
            this.btnImprimirMovimientoC.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimirMovimientoC.Name = "btnImprimirMovimientoC";
            this.btnImprimirMovimientoC.Size = new System.Drawing.Size(70, 37);
            this.btnImprimirMovimientoC.TabIndex = 0;
            this.btnImprimirMovimientoC.UseVisualStyleBackColor = true;
            this.btnImprimirMovimientoC.Click += new System.EventHandler(this.btnImprimirMovimientoC_Click);
            // 
            // btnGuardarMovimientoC
            // 
            this.btnGuardarMovimientoC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGuardarMovimientoC.Image = global::Dapesa.Tesoreria.Bancos.IU.Cobros.Properties.Resources.pdf;
            this.btnGuardarMovimientoC.Location = new System.Drawing.Point(582, 2);
            this.btnGuardarMovimientoC.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarMovimientoC.Name = "btnGuardarMovimientoC";
            this.btnGuardarMovimientoC.Size = new System.Drawing.Size(71, 37);
            this.btnGuardarMovimientoC.TabIndex = 1;
            this.btnGuardarMovimientoC.UseVisualStyleBackColor = true;
            this.btnGuardarMovimientoC.Click += new System.EventHandler(this.btnGuardarMovimientoC_Click);
            // 
            // gvMovimientosCorrectos
            // 
            this.gvMovimientosCorrectos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvMovimientosCorrectos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel2.SetColumnSpan(this.gvMovimientosCorrectos, 4);
            this.gvMovimientosCorrectos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvMovimientosCorrectos.Location = new System.Drawing.Point(2, 43);
            this.gvMovimientosCorrectos.Margin = new System.Windows.Forms.Padding(2);
            this.gvMovimientosCorrectos.Name = "gvMovimientosCorrectos";
            this.gvMovimientosCorrectos.ReadOnly = true;
            this.gvMovimientosCorrectos.RowTemplate.Height = 24;
            this.gvMovimientosCorrectos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvMovimientosCorrectos.Size = new System.Drawing.Size(651, 177);
            this.gvMovimientosCorrectos.TabIndex = 2;
            // 
            // btnExportarXlsxC
            // 
            this.btnExportarXlsxC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportarXlsxC.Image = global::Dapesa.Tesoreria.Bancos.IU.Cobros.Properties.Resources.xls;
            this.btnExportarXlsxC.Location = new System.Drawing.Point(507, 2);
            this.btnExportarXlsxC.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportarXlsxC.Name = "btnExportarXlsxC";
            this.btnExportarXlsxC.Size = new System.Drawing.Size(71, 37);
            this.btnExportarXlsxC.TabIndex = 3;
            this.btnExportarXlsxC.UseVisualStyleBackColor = true;
            this.btnExportarXlsxC.Click += new System.EventHandler(this.btnExportarXlsxC_Click);
            // 
            // tpMovimientosErrores
            // 
            this.tpMovimientosErrores.BackColor = System.Drawing.Color.Transparent;
            this.tpMovimientosErrores.Controls.Add(this.tableLayoutPanel3);
            this.tpMovimientosErrores.Location = new System.Drawing.Point(4, 22);
            this.tpMovimientosErrores.Margin = new System.Windows.Forms.Padding(2);
            this.tpMovimientosErrores.Name = "tpMovimientosErrores";
            this.tpMovimientosErrores.Padding = new System.Windows.Forms.Padding(2);
            this.tpMovimientosErrores.Size = new System.Drawing.Size(659, 226);
            this.tpMovimientosErrores.TabIndex = 1;
            this.tpMovimientosErrores.Text = "Errores";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.Controls.Add(this.btnImprimirMovimientoR, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnGuardarMovimientoR, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.gvMovimientosErrores, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnExportarXlsxR, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(655, 222);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btnImprimirMovimientoR
            // 
            this.btnImprimirMovimientoR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImprimirMovimientoR.Image = global::Dapesa.Tesoreria.Bancos.IU.Cobros.Properties.Resources.impresora;
            this.btnImprimirMovimientoR.Location = new System.Drawing.Point(433, 2);
            this.btnImprimirMovimientoR.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimirMovimientoR.Name = "btnImprimirMovimientoR";
            this.btnImprimirMovimientoR.Size = new System.Drawing.Size(70, 37);
            this.btnImprimirMovimientoR.TabIndex = 0;
            this.btnImprimirMovimientoR.UseVisualStyleBackColor = true;
            this.btnImprimirMovimientoR.Click += new System.EventHandler(this.btnImprimirMovimientoR_Click);
            // 
            // btnGuardarMovimientoR
            // 
            this.btnGuardarMovimientoR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGuardarMovimientoR.Image = global::Dapesa.Tesoreria.Bancos.IU.Cobros.Properties.Resources.pdf;
            this.btnGuardarMovimientoR.Location = new System.Drawing.Point(582, 2);
            this.btnGuardarMovimientoR.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarMovimientoR.Name = "btnGuardarMovimientoR";
            this.btnGuardarMovimientoR.Size = new System.Drawing.Size(71, 37);
            this.btnGuardarMovimientoR.TabIndex = 1;
            this.btnGuardarMovimientoR.UseVisualStyleBackColor = true;
            this.btnGuardarMovimientoR.Click += new System.EventHandler(this.btnGuardarMovimientoR_Click);
            // 
            // gvMovimientosErrores
            // 
            this.gvMovimientosErrores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvMovimientosErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel3.SetColumnSpan(this.gvMovimientosErrores, 4);
            this.gvMovimientosErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvMovimientosErrores.Location = new System.Drawing.Point(2, 43);
            this.gvMovimientosErrores.Margin = new System.Windows.Forms.Padding(2);
            this.gvMovimientosErrores.Name = "gvMovimientosErrores";
            this.gvMovimientosErrores.ReadOnly = true;
            this.gvMovimientosErrores.RowTemplate.Height = 24;
            this.gvMovimientosErrores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvMovimientosErrores.Size = new System.Drawing.Size(651, 177);
            this.gvMovimientosErrores.TabIndex = 2;
            // 
            // btnExportarXlsxR
            // 
            this.btnExportarXlsxR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportarXlsxR.Image = global::Dapesa.Tesoreria.Bancos.IU.Cobros.Properties.Resources.xls;
            this.btnExportarXlsxR.Location = new System.Drawing.Point(507, 2);
            this.btnExportarXlsxR.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportarXlsxR.Name = "btnExportarXlsxR";
            this.btnExportarXlsxR.Size = new System.Drawing.Size(71, 37);
            this.btnExportarXlsxR.TabIndex = 3;
            this.btnExportarXlsxR.UseVisualStyleBackColor = true;
            this.btnExportarXlsxR.Click += new System.EventHandler(this.btnExportarXlsxR_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResultado.Location = new System.Drawing.Point(39, 101);
            this.lblResultado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(145, 22);
            this.lblResultado.TabIndex = 6;
            this.lblResultado.Text = "Resultado:";
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbMovimientos
            // 
            this.pbMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMovimientos.Location = new System.Drawing.Point(188, 103);
            this.pbMovimientos.Margin = new System.Windows.Forms.Padding(2);
            this.pbMovimientos.Minimum = 1;
            this.pbMovimientos.Name = "pbMovimientos";
            this.pbMovimientos.Size = new System.Drawing.Size(369, 18);
            this.pbMovimientos.Step = 1;
            this.pbMovimientos.TabIndex = 7;
            this.pbMovimientos.Value = 1;
            // 
            // lblImpresora
            // 
            this.lblImpresora.AutoSize = true;
            this.lblImpresora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImpresora.Location = new System.Drawing.Point(39, 76);
            this.lblImpresora.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImpresora.Name = "lblImpresora";
            this.lblImpresora.Size = new System.Drawing.Size(145, 25);
            this.lblImpresora.TabIndex = 8;
            this.lblImpresora.Text = "Impresora:";
            this.lblImpresora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbImpresora
            // 
            this.cbImpresora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbImpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImpresora.FormattingEnabled = true;
            this.cbImpresora.Location = new System.Drawing.Point(188, 78);
            this.cbImpresora.Margin = new System.Windows.Forms.Padding(2);
            this.cbImpresora.Name = "cbImpresora";
            this.cbImpresora.Size = new System.Drawing.Size(369, 21);
            this.cbImpresora.TabIndex = 9;
            // 
            // lblEstatus
            // 
            this.lblEstatus.AutoSize = true;
            this.lblEstatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstatus.Location = new System.Drawing.Point(561, 101);
            this.lblEstatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEstatus.Name = "lblEstatus";
            this.lblEstatus.Size = new System.Drawing.Size(145, 22);
            this.lblEstatus.TabIndex = 10;
            this.lblEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanco.Location = new System.Drawing.Point(188, 0);
            this.lblBanco.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(369, 41);
            this.lblBanco.TabIndex = 11;
            this.lblBanco.Text = "HSBC";
            this.lblBanco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HSBC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 379);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(762, 418);
            this.Name = "HSBC";
            this.Text = "HSBC";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpMovimientosCorrectos.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvMovimientosCorrectos)).EndInit();
            this.tpMovimientosErrores.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvMovimientosErrores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpMovimientosCorrectos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnImprimirMovimientoC;
        private System.Windows.Forms.Button btnGuardarMovimientoC;
        private System.Windows.Forms.DataGridView gvMovimientosCorrectos;
        private System.Windows.Forms.Button btnExportarXlsxC;
        private System.Windows.Forms.TabPage tpMovimientosErrores;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnImprimirMovimientoR;
        private System.Windows.Forms.Button btnGuardarMovimientoR;
        private System.Windows.Forms.DataGridView gvMovimientosErrores;
        private System.Windows.Forms.Button btnExportarXlsxR;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.ProgressBar pbMovimientos;
        private System.Windows.Forms.Label lblImpresora;
        private System.Windows.Forms.ComboBox cbImpresora;
        private System.Windows.Forms.Label lblEstatus;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.OpenFileDialog ofdArchivo;
        private System.Windows.Forms.SaveFileDialog sfdGuardar;
    }
}