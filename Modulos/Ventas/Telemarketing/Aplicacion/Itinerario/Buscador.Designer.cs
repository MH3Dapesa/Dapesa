namespace Dapesa.Ventas.Telemarketing.IU.Itinerario
{
	partial class Buscador
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
			this.lblCliente = new System.Windows.Forms.Label();
			this.txtCliente = new System.Windows.Forms.TextBox();
			this.tlpContenedor.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpContenedor
			// 
			this.tlpContenedor.BackColor = System.Drawing.SystemColors.Control;
			this.tlpContenedor.ColumnCount = 6;
			this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
			this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tlpContenedor.Controls.Add(this.btnAceptar, 1, 4);
			this.tlpContenedor.Controls.Add(this.btnCancelar, 4, 4);
			this.tlpContenedor.Controls.Add(this.lblCliente, 1, 2);
			this.tlpContenedor.Controls.Add(this.txtCliente, 3, 2);
			this.tlpContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpContenedor.Location = new System.Drawing.Point(0, 0);
			this.tlpContenedor.Name = "tlpContenedor";
			this.tlpContenedor.RowCount = 6;
			this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
			this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpContenedor.Size = new System.Drawing.Size(234, 99);
			this.tlpContenedor.TabIndex = 0;
			// 
			// btnAceptar
			// 
			this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAceptar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.tlpContenedor.SetColumnSpan(this.btnAceptar, 3);
			this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAceptar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnAceptar.Location = new System.Drawing.Point(69, 59);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(75, 23);
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
			this.btnCancelar.Location = new System.Drawing.Point(150, 59);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 3;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = false;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// lblCliente
			// 
			this.lblCliente.AutoSize = true;
			this.tlpContenedor.SetColumnSpan(this.lblCliente, 2);
			this.lblCliente.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblCliente.Location = new System.Drawing.Point(8, 20);
			this.lblCliente.Name = "lblCliente";
			this.lblCliente.Size = new System.Drawing.Size(61, 26);
			this.lblCliente.TabIndex = 0;
			this.lblCliente.Text = "No. cliente:";
			this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCliente
			// 
			this.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tlpContenedor.SetColumnSpan(this.txtCliente, 2);
			this.txtCliente.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtCliente.Location = new System.Drawing.Point(75, 23);
			this.txtCliente.Margin = new System.Windows.Forms.Padding(3, 3, 13, 3);
			this.txtCliente.MaxLength = 20;
			this.txtCliente.Name = "txtCliente";
			this.txtCliente.Size = new System.Drawing.Size(141, 20);
			this.txtCliente.TabIndex = 1;
			// 
			// Buscador
			// 
			this.AcceptButton = this.btnAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.btnCancelar;
			this.ClientSize = new System.Drawing.Size(234, 99);
			this.Controls.Add(this.tlpContenedor);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = global::Dapesa.Ventas.Telemarketing.IU.Itinerario.Properties.Resources.buscar;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(250, 135);
			this.Name = "Buscador";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Buscar cliente";
			this.tlpContenedor.ResumeLayout(false);
			this.tlpContenedor.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpContenedor;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Label lblCliente;
		private System.Windows.Forms.TextBox txtCliente;
	}
}