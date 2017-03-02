namespace Dapesa.Tesoreria.Bancos.IU.Cobros
{
    partial class Contenedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contenedor));
            this.ssBarraEstado = new System.Windows.Forms.StatusStrip();
            this.tsslCredenciales = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSucursal = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslEstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.msMenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.tsmiArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBanamex = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBancomer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHSBC = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSantander = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBanorte = new System.Windows.Forms.ToolStripMenuItem();
            this.tssSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.ssBarraEstado.SuspendLayout();
            this.msMenuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssBarraEstado
            // 
            this.ssBarraEstado.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ssBarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCredenciales,
            this.tsslSucursal,
            this.tsslEstatus});
            this.ssBarraEstado.Location = new System.Drawing.Point(0, 438);
            this.ssBarraEstado.Name = "ssBarraEstado";
            this.ssBarraEstado.Size = new System.Drawing.Size(684, 24);
            this.ssBarraEstado.TabIndex = 4;
            this.ssBarraEstado.Text = "ssBarraEstado";
            // 
            // tsslCredenciales
            // 
            this.tsslCredenciales.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslCredenciales.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsslCredenciales.Name = "tsslCredenciales";
            this.tsslCredenciales.Size = new System.Drawing.Size(66, 19);
            this.tsslCredenciales.Text = "USUARIO: ";
            this.tsslCredenciales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsslSucursal
            // 
            this.tsslSucursal.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslSucursal.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsslSucursal.Name = "tsslSucursal";
            this.tsslSucursal.Size = new System.Drawing.Size(74, 19);
            this.tsslSucursal.Text = "SUCURSAL: ";
            this.tsslSucursal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsslEstatus
            // 
            this.tsslEstatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslEstatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsslEstatus.Name = "tsslEstatus";
            this.tsslEstatus.Size = new System.Drawing.Size(529, 19);
            this.tsslEstatus.Spring = true;
            this.tsslEstatus.Text = "ESTADO: CONECTADO";
            this.tsslEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // msMenuPrincipal
            // 
            this.msMenuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiArchivo});
            this.msMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msMenuPrincipal.Name = "msMenuPrincipal";
            this.msMenuPrincipal.Size = new System.Drawing.Size(684, 24);
            this.msMenuPrincipal.TabIndex = 6;
            // 
            // tsmiArchivo
            // 
            this.tsmiArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBanamex,
            this.tsmiBancomer,
            this.tsmiHSBC,
            this.tsmiSantander,
            this.tsmiBanorte,
            this.tssSeparador,
            this.tsmiSalir});
            this.tsmiArchivo.Name = "tsmiArchivo";
            this.tsmiArchivo.Size = new System.Drawing.Size(60, 20);
            this.tsmiArchivo.Text = "&Archivo";
            // 
            // tsmiBanamex
            // 
            this.tsmiBanamex.Image = ((System.Drawing.Image)(resources.GetObject("tsmiBanamex.Image")));
            this.tsmiBanamex.Name = "tsmiBanamex";
            this.tsmiBanamex.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiBanamex.Size = new System.Drawing.Size(173, 26);
            this.tsmiBanamex.Text = "&Banamex";
            this.tsmiBanamex.Click += new System.EventHandler(this.tsmiBanamex_Click);
            // 
            // tsmiBancomer
            // 
            this.tsmiBancomer.Image = ((System.Drawing.Image)(resources.GetObject("tsmiBancomer.Image")));
            this.tsmiBancomer.Name = "tsmiBancomer";
            this.tsmiBancomer.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.tsmiBancomer.Size = new System.Drawing.Size(173, 26);
            this.tsmiBancomer.Text = "&Bancomer";
            this.tsmiBancomer.Click += new System.EventHandler(this.tsmiBancomer_Click);
            // 
            // tsmiHSBC
            // 
            this.tsmiHSBC.Image = ((System.Drawing.Image)(resources.GetObject("tsmiHSBC.Image")));
            this.tsmiHSBC.Name = "tsmiHSBC";
            this.tsmiHSBC.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.tsmiHSBC.Size = new System.Drawing.Size(173, 26);
            this.tsmiHSBC.Text = "&HSBC";
            this.tsmiHSBC.Click += new System.EventHandler(this.tsmiHSBC_Click);
            // 
            // tsmiSantander
            // 
            this.tsmiSantander.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSantander.Image")));
            this.tsmiSantander.Name = "tsmiSantander";
            this.tsmiSantander.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSantander.Size = new System.Drawing.Size(173, 26);
            this.tsmiSantander.Text = "&Santander";
            this.tsmiSantander.Click += new System.EventHandler(this.tsmiSantander_Click);
            // 
            // tsmiBanorte
            // 
            this.tsmiBanorte.Image = ((System.Drawing.Image)(resources.GetObject("tsmiBanorte.Image")));
            this.tsmiBanorte.Name = "tsmiBanorte";
            this.tsmiBanorte.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.tsmiBanorte.Size = new System.Drawing.Size(173, 26);
            this.tsmiBanorte.Text = "&Banorte";
            this.tsmiBanorte.Click += new System.EventHandler(this.tsmiBanorte_Click);
            // 
            // tssSeparador
            // 
            this.tssSeparador.Name = "tssSeparador";
            this.tssSeparador.Size = new System.Drawing.Size(170, 6);
            // 
            // tsmiSalir
            // 
            this.tsmiSalir.Name = "tsmiSalir";
            this.tsmiSalir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmiSalir.Size = new System.Drawing.Size(173, 26);
            this.tsmiSalir.Text = "&Salir";
            this.tsmiSalir.Click += new System.EventHandler(this.tsmiSalir_Click);
            // 
            // Contenedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.msMenuPrincipal);
            this.Controls.Add(this.ssBarraEstado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(699, 499);
            this.Name = "Contenedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dapesa::.Tesoreria.Bancos.Cobros";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Contenedor_FormClosed);
            this.Load += new System.EventHandler(this.Contenedor_Load);
            this.ssBarraEstado.ResumeLayout(false);
            this.ssBarraEstado.PerformLayout();
            this.msMenuPrincipal.ResumeLayout(false);
            this.msMenuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssBarraEstado;
        private System.Windows.Forms.ToolStripStatusLabel tsslCredenciales;
        private System.Windows.Forms.ToolStripStatusLabel tsslSucursal;
        private System.Windows.Forms.ToolStripStatusLabel tsslEstatus;
        private System.Windows.Forms.MenuStrip msMenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem tsmiArchivo;
        private System.Windows.Forms.ToolStripMenuItem tsmiBanamex;
        private System.Windows.Forms.ToolStripMenuItem tsmiBancomer;
        private System.Windows.Forms.ToolStripSeparator tssSeparador;
        private System.Windows.Forms.ToolStripMenuItem tsmiSalir;
        private System.Windows.Forms.ToolStripMenuItem tsmiHSBC;
        private System.Windows.Forms.ToolStripMenuItem tsmiBanorte;
        private System.Windows.Forms.ToolStripMenuItem tsmiSantander;
    }
}