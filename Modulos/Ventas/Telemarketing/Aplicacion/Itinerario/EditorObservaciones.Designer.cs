namespace Dapesa.Ventas.Telemarketing.IU.Itinerario
{
	partial class EditorObservaciones
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
			this.txtTexto = new System.Windows.Forms.TextBox();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.tlpContenedor.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpContenedor
			// 
			this.tlpContenedor.BackColor = System.Drawing.SystemColors.Control;
			this.tlpContenedor.ColumnCount = 5;
			this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tlpContenedor.Controls.Add(this.txtTexto, 1, 1);
			this.tlpContenedor.Controls.Add(this.btnAceptar, 2, 3);
			this.tlpContenedor.Controls.Add(this.btnCancelar, 3, 3);
			this.tlpContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpContenedor.Location = new System.Drawing.Point(0, 0);
			this.tlpContenedor.Name = "tlpContenedor";
			this.tlpContenedor.RowCount = 5;
			this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tlpContenedor.Size = new System.Drawing.Size(564, 214);
			this.tlpContenedor.TabIndex = 0;
			// 
			// txtTexto
			// 
			this.txtTexto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tlpContenedor.SetColumnSpan(this.txtTexto, 3);
			this.txtTexto.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtTexto.ForeColor = System.Drawing.Color.Navy;
			this.txtTexto.Location = new System.Drawing.Point(6, 6);
			this.txtTexto.Margin = new System.Windows.Forms.Padding(1);
			this.txtTexto.MaxLength = 512;
			this.txtTexto.Multiline = true;
			this.txtTexto.Name = "txtTexto";
			this.txtTexto.Size = new System.Drawing.Size(552, 161);
			this.txtTexto.TabIndex = 1;
			// 
			// btnAceptar
			// 
			this.btnAceptar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAceptar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnAceptar.Location = new System.Drawing.Point(400, 181);
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
			this.btnCancelar.Location = new System.Drawing.Point(481, 181);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 3;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = false;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// EditorObservaciones
			// 
			this.AcceptButton = this.btnAceptar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.btnCancelar;
			this.ClientSize = new System.Drawing.Size(564, 214);
			this.Controls.Add(this.tlpContenedor);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = global::Dapesa.Ventas.Telemarketing.IU.Itinerario.Properties.Resources.observaciones;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(580, 250);
			this.Name = "EditorObservaciones";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Editar observaciones";
			this.Shown += new System.EventHandler(this.EditorObservaciones_Shown);
			this.tlpContenedor.ResumeLayout(false);
			this.tlpContenedor.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpContenedor;
		private System.Windows.Forms.TextBox txtTexto;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
	}
}