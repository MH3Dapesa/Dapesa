namespace Dapesa.Ventas.Telemarketing.IU.Itinerario
{
	partial class Tooltip
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
			this.tlpContenedor = new System.Windows.Forms.TableLayoutPanel();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.lblTooltip = new System.Windows.Forms.Label();
			this.tlpContenedor.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpContenedor
			// 
			this.tlpContenedor.BackColor = System.Drawing.SystemColors.Control;
			this.tlpContenedor.ColumnCount = 5;
			this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
			this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
			this.tlpContenedor.Controls.Add(this.btnAceptar, 2, 3);
			this.tlpContenedor.Controls.Add(this.btnCancelar, 3, 3);
			this.tlpContenedor.Controls.Add(this.lblTooltip, 1, 1);
			this.tlpContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpContenedor.Location = new System.Drawing.Point(0, 0);
			this.tlpContenedor.Name = "tlpContenedor";
			this.tlpContenedor.RowCount = 5;
			this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
			this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
			this.tlpContenedor.Size = new System.Drawing.Size(280, 210);
			this.tlpContenedor.TabIndex = 0;
			// 
			// btnAceptar
			// 
			this.btnAceptar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAceptar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnAceptar.Location = new System.Drawing.Point(120, 181);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(75, 25);
			this.btnAceptar.TabIndex = 2;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.UseVisualStyleBackColor = false;
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancelar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.btnCancelar.Location = new System.Drawing.Point(201, 181);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 3;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = false;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// lblTooltip
			// 
			this.lblTooltip.AutoSize = true;
			this.lblTooltip.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tlpContenedor.SetColumnSpan(this.lblTooltip, 3);
			this.lblTooltip.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTooltip.Location = new System.Drawing.Point(4, 1);
			this.lblTooltip.Name = "lblTooltip";
			this.lblTooltip.Size = new System.Drawing.Size(272, 172);
			this.lblTooltip.TabIndex = 4;
			// 
			// Emergente
			// 
			this.AcceptButton = this.btnAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.btnCancelar;
			this.ClientSize = new System.Drawing.Size(280, 210);
			this.ControlBox = false;
			this.Controls.Add(this.tlpContenedor);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Emergente";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.tlpContenedor.ResumeLayout(false);
			this.tlpContenedor.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpContenedor;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Label lblTooltip;
	}
}