namespace Comun.Pedidos.IU.AppMensajero
{
    partial class Mensajero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mensajero));
            this.timerReloj = new System.Windows.Forms.Timer();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rvPedidos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.cbSucursal = new System.Windows.Forms.ComboBox();
            this.timerActualizar = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerReloj
            // 
            this.timerReloj.Enabled = true;
            this.timerReloj.Tick += new System.EventHandler(this.timerReloj_Tick);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerar.Location = new System.Drawing.Point(351, 106);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 7;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // pbLogo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pbLogo, 2);
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbLogo.Image = global::Comun.Pedidos.IU.AppMensajero.Properties.Resources.dapesa500;
            this.pbLogo.Location = new System.Drawing.Point(650, 3);
            this.pbLogo.MinimumSize = new System.Drawing.Size(150, 50);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(150, 50);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 6;
            this.pbLogo.TabStop = false;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaFinal.Location = new System.Drawing.Point(108, 106);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(237, 20);
            this.dtpFechaFinal.TabIndex = 4;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaFin.Location = new System.Drawing.Point(15, 103);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(67, 29);
            this.lblFechaFin.TabIndex = 3;
            this.lblFechaFin.Text = "Fecha final:";
            this.lblFechaFin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHora
            // 
            this.txtHora.AutoSize = true;
            this.txtHora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.Location = new System.Drawing.Point(452, 77);
            this.txtHora.Name = "txtHora";
            this.tableLayoutPanel1.SetRowSpan(this.txtHora, 2);
            this.txtHora.Size = new System.Drawing.Size(335, 55);
            this.txtHora.TabIndex = 2;
            this.txtHora.Text = "Fecha";
            this.txtHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaInicio.Location = new System.Drawing.Point(108, 80);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(237, 20);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaInicio.Location = new System.Drawing.Point(15, 77);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(67, 26);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "Fecha inicio:";
            this.lblFechaInicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel1.Controls.Add(this.lblFechaInicio, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtpFechaInicio, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtHora, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaFin, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtpFechaFinal, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.pbLogo, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGenerar, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.rvPedidos, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblSucursal, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbSucursal, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 98F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(803, 367);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rvPedidos
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.rvPedidos, 6);
            this.rvPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvPedidos.DocumentMapWidth = 4;
            this.rvPedidos.Location = new System.Drawing.Point(15, 145);
            this.rvPedidos.Name = "rvPedidos";
            this.rvPedidos.Size = new System.Drawing.Size(772, 214);
            this.rvPedidos.TabIndex = 8;
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSucursal.Location = new System.Drawing.Point(15, 50);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(67, 27);
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
            this.cbSucursal.Location = new System.Drawing.Point(108, 53);
            this.cbSucursal.Name = "cbSucursal";
            this.cbSucursal.Size = new System.Drawing.Size(237, 21);
            this.cbSucursal.TabIndex = 10;
            this.cbSucursal.ValueMember = "Clave";
            // 
            // timerActualizar
            // 
            this.timerActualizar.Enabled = true;
            this.timerActualizar.Interval = 30000;
            this.timerActualizar.Tick += new System.EventHandler(this.timerActualizar_Tick);
            // 
            // Mensajero
            // 
            this.AcceptButton = this.btnGenerar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 367);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(819, 405);
            this.Name = "Mensajero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mensajero";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Mensajero_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerReloj;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label txtHora;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private Microsoft.Reporting.WinForms.ReportViewer rvPedidos;
        private System.Windows.Forms.Timer timerActualizar;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.ComboBox cbSucursal;

    }
}