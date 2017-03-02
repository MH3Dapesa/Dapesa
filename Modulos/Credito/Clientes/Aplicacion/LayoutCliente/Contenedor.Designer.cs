namespace Credito.Clientes.IU.LayoutCliente
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
            this.msMenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.tsmiArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTemporal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPermanente = new System.Windows.Forms.ToolStripMenuItem();
            this.tssSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.ssBarraEstado = new System.Windows.Forms.StatusStrip();
            this.tsslCredenciales = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSucursal = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslEstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.msMenuPrincipal.SuspendLayout();
            this.ssBarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenuPrincipal
            // 
            this.msMenuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiArchivo});
            this.msMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msMenuPrincipal.Name = "msMenuPrincipal";
            this.msMenuPrincipal.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.msMenuPrincipal.Size = new System.Drawing.Size(909, 28);
            this.msMenuPrincipal.TabIndex = 4;
            // 
            // tsmiArchivo
            // 
            this.tsmiArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTemporal,
            this.tsmiPermanente,
            this.tssSeparador,
            this.tsmiSalir});
            this.tsmiArchivo.Name = "tsmiArchivo";
            this.tsmiArchivo.Size = new System.Drawing.Size(71, 24);
            this.tsmiArchivo.Text = "&Archivo";
            // 
            // tsmiTemporal
            // 
            this.tsmiTemporal.Image = ((System.Drawing.Image)(resources.GetObject("tsmiTemporal.Image")));
            this.tsmiTemporal.Name = "tsmiTemporal";
            this.tsmiTemporal.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsmiTemporal.Size = new System.Drawing.Size(291, 26);
            this.tsmiTemporal.Text = "Asignación &Temporal";
            this.tsmiTemporal.Click += new System.EventHandler(this.tsmiTemporal_Click);
            // 
            // tsmiPermanente
            // 
            this.tsmiPermanente.Image = ((System.Drawing.Image)(resources.GetObject("tsmiPermanente.Image")));
            this.tsmiPermanente.Name = "tsmiPermanente";
            this.tsmiPermanente.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.tsmiPermanente.Size = new System.Drawing.Size(291, 26);
            this.tsmiPermanente.Text = "&Asignación Permanente";
            this.tsmiPermanente.Click += new System.EventHandler(this.tsmiPermanente_Click);
            // 
            // tssSeparador
            // 
            this.tssSeparador.Name = "tssSeparador";
            this.tssSeparador.Size = new System.Drawing.Size(288, 6);
            // 
            // tsmiSalir
            // 
            this.tsmiSalir.Name = "tsmiSalir";
            this.tsmiSalir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmiSalir.Size = new System.Drawing.Size(291, 26);
            this.tsmiSalir.Text = "&Salir";
            this.tsmiSalir.Click += new System.EventHandler(this.tsmiSalir_Click);
            // 
            // ssBarraEstado
            // 
            this.ssBarraEstado.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ssBarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCredenciales,
            this.tsslSucursal,
            this.tsslEstatus});
            this.ssBarraEstado.Location = new System.Drawing.Point(0, 531);
            this.ssBarraEstado.Name = "ssBarraEstado";
            this.ssBarraEstado.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.ssBarraEstado.Size = new System.Drawing.Size(909, 29);
            this.ssBarraEstado.TabIndex = 6;
            this.ssBarraEstado.Text = "ssBarraEstado";
            // 
            // tsslCredenciales
            // 
            this.tsslCredenciales.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsslCredenciales.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsslCredenciales.Name = "tsslCredenciales";
            this.tsslCredenciales.Size = new System.Drawing.Size(82, 24);
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
            this.tsslSucursal.Size = new System.Drawing.Size(91, 24);
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
            this.tsslEstatus.Size = new System.Drawing.Size(677, 24);
            this.tsslEstatus.Spring = true;
            this.tsslEstatus.Text = "ESTADO: CONECTADO";
            this.tsslEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslEstatus.Click += new System.EventHandler(this.tsslEstatus_Click);
            // 
            // Contenedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 560);
            this.Controls.Add(this.ssBarraEstado);
            this.Controls.Add(this.msMenuPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMenuPrincipal;
            this.MinimumSize = new System.Drawing.Size(927, 605);
            this.Name = "Contenedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dapesa::.Credito.Clientes.LayoutCliente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Contenedor_FormClosed);
            this.Load += new System.EventHandler(this.Contenedor_Load);
            this.msMenuPrincipal.ResumeLayout(false);
            this.msMenuPrincipal.PerformLayout();
            this.ssBarraEstado.ResumeLayout(false);
            this.ssBarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem tsmiArchivo;
        private System.Windows.Forms.ToolStripMenuItem tsmiTemporal;
        private System.Windows.Forms.ToolStripMenuItem tsmiPermanente;
        private System.Windows.Forms.ToolStripSeparator tssSeparador;
        private System.Windows.Forms.ToolStripMenuItem tsmiSalir;
        private System.Windows.Forms.StatusStrip ssBarraEstado;
        private System.Windows.Forms.ToolStripStatusLabel tsslCredenciales;
        private System.Windows.Forms.ToolStripStatusLabel tsslSucursal;
        private System.Windows.Forms.ToolStripStatusLabel tsslEstatus;
    }
}