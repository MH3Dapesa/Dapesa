namespace Dapesa.Credito.Pedidos.IU.MensajeroCXC
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
            this.components = new System.ComponentModel.Container();
            this.rvPedidos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.timerActualizar = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // rvPedidos
            // 
            this.rvPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvPedidos.Location = new System.Drawing.Point(0, 0);
            this.rvPedidos.Name = "rvPedidos";
            this.rvPedidos.ShowToolBar = false;
            this.rvPedidos.Size = new System.Drawing.Size(384, 116);
            this.rvPedidos.TabIndex = 0;
            // 
            // timerActualizar
            // 
            this.timerActualizar.Enabled = true;
            this.timerActualizar.Interval = 20000;
            this.timerActualizar.Tick += new System.EventHandler(this.timerActualizar_Tick);
            // 
            // Mensajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(384, 116);
            this.Controls.Add(this.rvPedidos);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 150);
            this.Name = "Mensajero";
            this.Text = "Mensajero";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Mensajero_FormClosed);
            this.Load += new System.EventHandler(this.Mensajero_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvPedidos;
        private System.Windows.Forms.Timer timerActualizar;



    }
}