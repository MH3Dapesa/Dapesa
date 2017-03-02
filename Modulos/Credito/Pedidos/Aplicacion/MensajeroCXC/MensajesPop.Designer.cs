namespace Dapesa.Credito.Pedidos.IU.MensajeroCXC
{
    partial class MensajesPop
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
            this.tblContenido = new System.Windows.Forms.TableLayoutPanel();
            this.lblEncabezado = new System.Windows.Forms.Label();
            this.lblContenido = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.timerActualizar = new System.Windows.Forms.Timer(this.components);
            this.timerCerrar = new System.Windows.Forms.Timer(this.components);
            this.tblContenido.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblContenido
            // 
            this.tblContenido.BackColor = System.Drawing.Color.White;
            this.tblContenido.ColumnCount = 3;
            this.tblContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tblContenido.Controls.Add(this.lblEncabezado, 1, 1);
            this.tblContenido.Controls.Add(this.lblContenido, 1, 2);
            this.tblContenido.Controls.Add(this.btnAceptar, 1, 3);
            this.tblContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblContenido.Location = new System.Drawing.Point(0, 0);
            this.tblContenido.Name = "tblContenido";
            this.tblContenido.RowCount = 4;
            this.tblContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tblContenido.Size = new System.Drawing.Size(350, 130);
            this.tblContenido.TabIndex = 0;
            // 
            // lblEncabezado
            // 
            this.lblEncabezado.AutoSize = true;
            this.lblEncabezado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEncabezado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezado.ForeColor = System.Drawing.Color.Black;
            this.lblEncabezado.Location = new System.Drawing.Point(8, 20);
            this.lblEncabezado.Name = "lblEncabezado";
            this.lblEncabezado.Size = new System.Drawing.Size(334, 37);
            this.lblEncabezado.TabIndex = 0;
            this.lblEncabezado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblContenido
            // 
            this.lblContenido.AutoSize = true;
            this.lblContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContenido.ForeColor = System.Drawing.Color.Black;
            this.lblContenido.Location = new System.Drawing.Point(8, 57);
            this.lblContenido.Name = "lblContenido";
            this.lblContenido.Size = new System.Drawing.Size(334, 37);
            this.lblContenido.TabIndex = 1;
            this.lblContenido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAceptar.Image = global::Dapesa.Credito.Pedidos.IU.MensajeroCXC.Properties.Resources.ok;
            this.btnAceptar.Location = new System.Drawing.Point(301, 97);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(41, 30);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // timerActualizar
            // 
            this.timerActualizar.Enabled = true;
            this.timerActualizar.Interval = 800;
            this.timerActualizar.Tick += new System.EventHandler(this.timerActualizar_Tick);
            // 
            // timerCerrar
            // 
            this.timerCerrar.Enabled = true;
            this.timerCerrar.Interval = 30000;
            this.timerCerrar.Tick += new System.EventHandler(this.timerCerrar_Tick);
            // 
            // MensajesPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 130);
            this.Controls.Add(this.tblContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 130);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 130);
            this.Name = "MensajesPop";
            this.ShowInTaskbar = false;
            this.Text = "MensajesPop";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.MensajesPop_Shown);
            this.tblContenido.ResumeLayout(false);
            this.tblContenido.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblContenido;
        private System.Windows.Forms.Label lblEncabezado;
        private System.Windows.Forms.Label lblContenido;
        private System.Windows.Forms.Timer timerActualizar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Timer timerCerrar;
    }
}