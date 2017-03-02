namespace Dapesa.Facturacion.Documentos.IU.EmisionFacturas
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
            this.tlpContenido = new System.Windows.Forms.TableLayoutPanel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblFechaInicial = new System.Windows.Forms.Label();
            this.lblFactura = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.clbFacturas = new System.Windows.Forms.CheckedListBox();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.cbImpresora = new System.Windows.Forms.ComboBox();
            this.cbFacturas = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tlpContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpContenido
            // 
            this.tlpContenido.ColumnCount = 5;
            this.tlpContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContenido.Controls.Add(this.pbLogo, 2, 0);
            this.tlpContenido.Controls.Add(this.lblFechaInicial, 1, 2);
            this.tlpContenido.Controls.Add(this.lblFactura, 1, 4);
            this.tlpContenido.Controls.Add(this.btnGenerar, 3, 7);
            this.tlpContenido.Controls.Add(this.btnImprimir, 3, 8);
            this.tlpContenido.Controls.Add(this.clbFacturas, 2, 7);
            this.tlpContenido.Controls.Add(this.txtFactura, 2, 4);
            this.tlpContenido.Controls.Add(this.txtFecha, 2, 2);
            this.tlpContenido.Controls.Add(this.cbImpresora, 3, 6);
            this.tlpContenido.Controls.Add(this.cbFacturas, 2, 6);
            this.tlpContenido.Controls.Add(this.label1, 3, 5);
            this.tlpContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContenido.Location = new System.Drawing.Point(0, 0);
            this.tlpContenido.Name = "tlpContenido";
            this.tlpContenido.RowCount = 12;
            this.tlpContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpContenido.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlpContenido.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContenido.Size = new System.Drawing.Size(650, 386);
            this.tlpContenido.TabIndex = 0;
            this.tlpContenido.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpContenido_Paint);
            // 
            // pbLogo
            // 
            this.tlpContenido.SetColumnSpan(this.pbLogo, 2);
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbLogo.Image = global::Dapesa.Facturacion.Documentos.IU.EmisionFacturas.Properties.Resources.dapesa;
            this.pbLogo.Location = new System.Drawing.Point(477, 3);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(150, 44);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // lblFechaInicial
            // 
            this.lblFechaInicial.AutoSize = true;
            this.lblFechaInicial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaInicial.Location = new System.Drawing.Point(23, 60);
            this.lblFechaInicial.Name = "lblFechaInicial";
            this.lblFechaInicial.Size = new System.Drawing.Size(116, 26);
            this.lblFechaInicial.TabIndex = 1;
            this.lblFechaInicial.Text = "Minutos:";
            this.lblFechaInicial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFechaInicial.Click += new System.EventHandler(this.lblFechaInicial_Click);
            // 
            // lblFactura
            // 
            this.lblFactura.AutoSize = true;
            this.lblFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFactura.Location = new System.Drawing.Point(23, 94);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(116, 26);
            this.lblFactura.TabIndex = 2;
            this.lblFactura.Text = "No. Factura:";
            this.lblFactura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerar.Location = new System.Drawing.Point(450, 174);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(177, 40);
            this.btnGenerar.TabIndex = 4;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(450, 220);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(177, 40);
            this.btnImprimir.TabIndex = 6;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // clbFacturas
            // 
            this.clbFacturas.CheckOnClick = true;
            this.clbFacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbFacturas.FormattingEnabled = true;
            this.clbFacturas.Location = new System.Drawing.Point(145, 174);
            this.clbFacturas.Name = "clbFacturas";
            this.tlpContenido.SetRowSpan(this.clbFacturas, 3);
            this.clbFacturas.Size = new System.Drawing.Size(299, 178);
            this.clbFacturas.TabIndex = 8;
            this.clbFacturas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbFacturas_ItemCheck);
            // 
            // txtFactura
            // 
            this.txtFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFactura.Location = new System.Drawing.Point(145, 97);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(299, 20);
            this.txtFactura.TabIndex = 11;
            this.txtFactura.TextChanged += new System.EventHandler(this.txtFactura_TextChanged);
            this.txtFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFactura_KeyPress);
            // 
            // txtFecha
            // 
            this.txtFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFecha.Location = new System.Drawing.Point(145, 63);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(299, 20);
            this.txtFecha.TabIndex = 12;
            this.txtFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFecha_KeyPress);
            // 
            // cbImpresora
            // 
            this.cbImpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImpresora.FormattingEnabled = true;
            this.cbImpresora.Location = new System.Drawing.Point(450, 145);
            this.cbImpresora.Name = "cbImpresora";
            this.cbImpresora.Size = new System.Drawing.Size(177, 21);
            this.cbImpresora.TabIndex = 13;
            // 
            // cbFacturas
            // 
            this.cbFacturas.AutoSize = true;
            this.cbFacturas.Enabled = false;
            this.cbFacturas.Location = new System.Drawing.Point(145, 145);
            this.cbFacturas.Name = "cbFacturas";
            this.cbFacturas.Size = new System.Drawing.Size(56, 17);
            this.cbFacturas.TabIndex = 9;
            this.cbFacturas.Text = "Todas";
            this.cbFacturas.UseVisualStyleBackColor = true;
            this.cbFacturas.CheckedChanged += new System.EventHandler(this.cbFacturas_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(450, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Elegir impresora";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Contenido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 386);
            this.Controls.Add(this.tlpContenido);
            this.Name = "Contenido";
            this.Text = "Contenido";
            this.Load += new System.EventHandler(this.Contenido_Load);
            this.tlpContenido.ResumeLayout(false);
            this.tlpContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpContenido;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblFechaInicial;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.CheckedListBox clbFacturas;
        private System.Windows.Forms.CheckBox cbFacturas;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.ComboBox cbImpresora;
        private System.Windows.Forms.Label label1;
    }
}