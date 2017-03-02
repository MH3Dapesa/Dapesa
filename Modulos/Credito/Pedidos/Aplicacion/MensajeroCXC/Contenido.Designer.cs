namespace Dapesa.Credito.Pedidos.IU.MensajeroCXC
{
    partial class Contenido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contenido));
            DevExpress.XtraBars.Alerter.AlertButton alertButton1 = new DevExpress.XtraBars.Alerter.AlertButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.txtHora = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.cbSucursal = new System.Windows.Forms.ComboBox();
            this.rvPedidos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnResumen = new System.Windows.Forms.Button();
            this.chbMisPedidos = new System.Windows.Forms.CheckBox();
            this.cbNotificar = new System.Windows.Forms.CheckBox();
            this.timerReloj = new System.Windows.Forms.Timer();
            this.timerActualizar = new System.Windows.Forms.Timer();
            this.toolTip = new System.Windows.Forms.ToolTip();
            this.alertControl = new DevExpress.XtraBars.Alerter.AlertControl();
            this.imageCollection = new DevExpress.Utils.ImageCollection();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel1.Controls.Add(this.lblFechaInicio, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtpFechaInicio, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtHora, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaFin, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtpFechaFinal, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.pbLogo, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGenerar, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblSucursal, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbSucursal, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.rvPedidos, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnResumen, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.chbMisPedidos, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbNotificar, 5, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 98F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1179, 405);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaInicio.Location = new System.Drawing.Point(20, 94);
            this.lblFechaInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(87, 36);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "Fecha inicio:";
            this.lblFechaInicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaInicio.Location = new System.Drawing.Point(142, 98);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(324, 22);
            this.dtpFechaInicio.TabIndex = 1;
            this.dtpFechaInicio.Value = new System.DateTime(2016, 11, 24, 0, 0, 0, 0);
            // 
            // txtHora
            // 
            this.txtHora.AutoSize = true;
            this.txtHora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.Location = new System.Drawing.Point(701, 94);
            this.txtHora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtHora.Name = "txtHora";
            this.tableLayoutPanel1.SetRowSpan(this.txtHora, 2);
            this.txtHora.Size = new System.Drawing.Size(456, 72);
            this.txtHora.TabIndex = 2;
            this.txtHora.Text = "Fecha";
            this.txtHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaFin.Location = new System.Drawing.Point(20, 130);
            this.lblFechaFin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(87, 36);
            this.lblFechaFin.TabIndex = 3;
            this.lblFechaFin.Text = "Fecha final:";
            this.lblFechaFin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaFinal.Location = new System.Drawing.Point(142, 134);
            this.dtpFechaFinal.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(324, 22);
            this.dtpFechaFinal.TabIndex = 4;
            // 
            // pbLogo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pbLogo, 2);
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbLogo.Image = global::Dapesa.Credito.Pedidos.IU.MensajeroCXC.Properties.Resources.dapesa500;
            this.pbLogo.Location = new System.Drawing.Point(975, 4);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pbLogo.MinimumSize = new System.Drawing.Size(200, 62);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(200, 62);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 6;
            this.pbLogo.TabStop = false;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerar.Location = new System.Drawing.Point(474, 134);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(100, 28);
            this.btnGenerar.TabIndex = 7;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSucursal.Location = new System.Drawing.Point(20, 62);
            this.lblSucursal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(87, 32);
            this.lblSucursal.TabIndex = 9;
            this.lblSucursal.Text = "Sucursal:";
            this.lblSucursal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbSucursal
            // 
            this.cbSucursal.DisplayMember = "Descripcion";
            this.cbSucursal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSucursal.FormattingEnabled = true;
            this.cbSucursal.Location = new System.Drawing.Point(142, 66);
            this.cbSucursal.Margin = new System.Windows.Forms.Padding(4);
            this.cbSucursal.Name = "cbSucursal";
            this.cbSucursal.Size = new System.Drawing.Size(324, 24);
            this.cbSucursal.TabIndex = 10;
            this.cbSucursal.ValueMember = "Clave";
            // 
            // rvPedidos
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.rvPedidos, 6);
            this.rvPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvPedidos.DocumentMapWidth = 3;
            this.rvPedidos.Location = new System.Drawing.Point(20, 182);
            this.rvPedidos.Margin = new System.Windows.Forms.Padding(4);
            this.rvPedidos.Name = "rvPedidos";
            this.rvPedidos.Size = new System.Drawing.Size(1137, 214);
            this.rvPedidos.TabIndex = 11;
            // 
            // btnResumen
            // 
            this.btnResumen.Location = new System.Drawing.Point(474, 98);
            this.btnResumen.Margin = new System.Windows.Forms.Padding(4);
            this.btnResumen.Name = "btnResumen";
            this.btnResumen.Size = new System.Drawing.Size(100, 28);
            this.btnResumen.TabIndex = 12;
            this.btnResumen.Text = "Resumen";
            this.btnResumen.UseVisualStyleBackColor = true;
            this.btnResumen.Click += new System.EventHandler(this.btnResumen_Click);
            // 
            // chbMisPedidos
            // 
            this.chbMisPedidos.AutoSize = true;
            this.chbMisPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbMisPedidos.Location = new System.Drawing.Point(582, 134);
            this.chbMisPedidos.Margin = new System.Windows.Forms.Padding(4);
            this.chbMisPedidos.Name = "chbMisPedidos";
            this.chbMisPedidos.Size = new System.Drawing.Size(111, 28);
            this.chbMisPedidos.TabIndex = 13;
            this.chbMisPedidos.Text = "Mis pedidos";
            this.chbMisPedidos.UseVisualStyleBackColor = true;
            // 
            // cbNotificar
            // 
            this.cbNotificar.AutoSize = true;
            this.cbNotificar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbNotificar.Location = new System.Drawing.Point(581, 97);
            this.cbNotificar.Name = "cbNotificar";
            this.cbNotificar.Size = new System.Drawing.Size(113, 30);
            this.cbNotificar.TabIndex = 14;
            this.cbNotificar.Text = "No molestar";
            this.cbNotificar.UseVisualStyleBackColor = true;
            this.cbNotificar.Visible = false;
            // 
            // timerReloj
            // 
            this.timerReloj.Enabled = true;
            this.timerReloj.Tick += new System.EventHandler(this.timerReloj_Tick);
            // 
            // timerActualizar
            // 
            this.timerActualizar.Enabled = true;
            this.timerActualizar.Interval = 30000;
            this.timerActualizar.Tick += new System.EventHandler(this.timerActualizar_Tick);
            // 
            // alertControl
            // 
            this.alertControl.AllowHtmlText = true;
            this.alertControl.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.alertControl.AppearanceCaption.Options.UseFont = true;
            this.alertControl.AppearanceText.Font = new System.Drawing.Font("Tahoma", 9F);
            this.alertControl.AppearanceText.Image = ((System.Drawing.Image)(resources.GetObject("alertControl.AppearanceText.Image")));
            this.alertControl.AppearanceText.Options.UseFont = true;
            this.alertControl.AppearanceText.Options.UseImage = true;
            this.alertControl.AutoFormDelay = 300000;
            alertButton1.Name = "abtnCerrar";
            this.alertControl.Buttons.Add(alertButton1);
            this.alertControl.FormShowingEffect = DevExpress.XtraBars.Alerter.AlertFormShowingEffect.SlideHorizontal;
            this.alertControl.AlertClick += new DevExpress.XtraBars.Alerter.AlertClickEventHandler(this.alertControl_AlertClick);
            this.alertControl.ButtonClick += new DevExpress.XtraBars.Alerter.AlertButtonClickEventHandler(this.alertControl_ButtonClick);
            this.alertControl.FormLoad += new DevExpress.XtraBars.Alerter.AlertFormLoadEventHandler(this.alertControl_FormLoad);
            // 
            // imageCollection
            // 
            this.imageCollection.ImageSize = new System.Drawing.Size(48, 48);
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.Images.SetKeyName(0, "asignado.png");
            this.imageCollection.Images.SetKeyName(1, "sin_asignar.png");
            // 
            // Contenido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 405);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1194, 441);
            this.Name = "Contenido";
            this.Text = "Contenido";
            this.Shown += new System.EventHandler(this.Contenido_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label txtHora;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.ComboBox cbSucursal;
        private System.Windows.Forms.Timer timerReloj;
        private System.Windows.Forms.Timer timerActualizar;
        private Microsoft.Reporting.WinForms.ReportViewer rvPedidos;
        private System.Windows.Forms.Button btnResumen;
        private System.Windows.Forms.CheckBox chbMisPedidos;
        private System.Windows.Forms.ToolTip toolTip;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl;
        private System.Windows.Forms.CheckBox cbNotificar;
        private DevExpress.Utils.ImageCollection imageCollection;
    }
}