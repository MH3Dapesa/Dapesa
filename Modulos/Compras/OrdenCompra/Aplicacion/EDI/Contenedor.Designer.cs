namespace Dapesa.Compras.OrdenCompra.IU.EDI
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
            this.ssBarraEstado = new System.Windows.Forms.StatusStrip();
            this.tsslCredenciales = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSucursal = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslEstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssBarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssBarraEstado
            // 
            this.ssBarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCredenciales,
            this.tsslSucursal,
            this.tsslEstatus});
            this.ssBarraEstado.Location = new System.Drawing.Point(0, 438);
            this.ssBarraEstado.Name = "ssBarraEstado";
            this.ssBarraEstado.Size = new System.Drawing.Size(684, 24);
            this.ssBarraEstado.TabIndex = 2;
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
            // Contenedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.ssBarraEstado);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "Contenedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dapesa::.Compras.OrdenCompras.EDI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Contenedor_FormClosed);
            this.Load += new System.EventHandler(this.Contenedor_Load);
            this.ssBarraEstado.ResumeLayout(false);
            this.ssBarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssBarraEstado;
        private System.Windows.Forms.ToolStripStatusLabel tsslCredenciales;
        private System.Windows.Forms.ToolStripStatusLabel tsslSucursal;
        private System.Windows.Forms.ToolStripStatusLabel tsslEstatus;
    }
}