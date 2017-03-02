namespace Dapesa.Almacen.Pedidos.Trazabilidad.IU.Empaque
{
	partial class frmLectorBascula
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
			this.tlpPanelPrincipal = new System.Windows.Forms.TableLayoutPanel();
			this.tlpPanelSuperior = new System.Windows.Forms.TableLayoutPanel();
			this.txtPedido = new System.Windows.Forms.TextBox();
			this.txtPeso = new System.Windows.Forms.TextBox();
			this.lblPedido = new System.Windows.Forms.Label();
			this.lblPeso = new System.Windows.Forms.Label();
			this.tlpPanelInferior = new System.Windows.Forms.TableLayoutPanel();
			this.btnB9 = new System.Windows.Forms.Button();
			this.btnB8 = new System.Windows.Forms.Button();
			this.btnB7 = new System.Windows.Forms.Button();
			this.btnB4 = new System.Windows.Forms.Button();
			this.btnB5 = new System.Windows.Forms.Button();
			this.btnB6 = new System.Windows.Forms.Button();
			this.btnB1 = new System.Windows.Forms.Button();
			this.btnB2 = new System.Windows.Forms.Button();
			this.btnB3 = new System.Windows.Forms.Button();
			this.btnB0 = new System.Windows.Forms.Button();
			this.btnGrabar = new System.Windows.Forms.Button();
			this.btnBorrar = new System.Windows.Forms.Button();
			this.tlpPanelPrincipal.SuspendLayout();
			this.tlpPanelSuperior.SuspendLayout();
			this.tlpPanelInferior.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlpPanelPrincipal
			// 
			this.tlpPanelPrincipal.ColumnCount = 1;
			this.tlpPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpPanelPrincipal.Controls.Add(this.tlpPanelSuperior, 0, 0);
			this.tlpPanelPrincipal.Controls.Add(this.tlpPanelInferior, 0, 1);
			this.tlpPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpPanelPrincipal.Location = new System.Drawing.Point(0, 0);
			this.tlpPanelPrincipal.Name = "tlpPanelPrincipal";
			this.tlpPanelPrincipal.RowCount = 2;
			this.tlpPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
			this.tlpPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
			this.tlpPanelPrincipal.Size = new System.Drawing.Size(284, 264);
			this.tlpPanelPrincipal.TabIndex = 0;
			// 
			// tlpPanelSuperior
			// 
			this.tlpPanelSuperior.BackColor = System.Drawing.Color.Gainsboro;
			this.tlpPanelSuperior.ColumnCount = 2;
			this.tlpPanelSuperior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpPanelSuperior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tlpPanelSuperior.Controls.Add(this.txtPedido, 1, 0);
			this.tlpPanelSuperior.Controls.Add(this.txtPeso, 1, 1);
			this.tlpPanelSuperior.Controls.Add(this.lblPedido, 0, 0);
			this.tlpPanelSuperior.Controls.Add(this.lblPeso, 0, 1);
			this.tlpPanelSuperior.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpPanelSuperior.Location = new System.Drawing.Point(3, 3);
			this.tlpPanelSuperior.Name = "tlpPanelSuperior";
			this.tlpPanelSuperior.RowCount = 2;
			this.tlpPanelSuperior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpPanelSuperior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpPanelSuperior.Size = new System.Drawing.Size(278, 86);
			this.tlpPanelSuperior.TabIndex = 0;
			// 
			// txtPedido
			// 
			this.txtPedido.BackColor = System.Drawing.Color.White;
			this.txtPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPedido.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPedido.Location = new System.Drawing.Point(58, 3);
			this.txtPedido.MaxLength = 6;
			this.txtPedido.Multiline = true;
			this.txtPedido.Name = "txtPedido";
			this.txtPedido.ReadOnly = true;
			this.txtPedido.Size = new System.Drawing.Size(217, 37);
			this.txtPedido.TabIndex = 0;
			this.txtPedido.TextChanged += new System.EventHandler(this.txtPedido_TextChanged);
			// 
			// txtPeso
			// 
			this.txtPeso.BackColor = System.Drawing.Color.White;
			this.txtPeso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPeso.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPeso.Location = new System.Drawing.Point(58, 46);
			this.txtPeso.MaxLength = 6;
			this.txtPeso.Multiline = true;
			this.txtPeso.Name = "txtPeso";
			this.txtPeso.ReadOnly = true;
			this.txtPeso.Size = new System.Drawing.Size(217, 37);
			this.txtPeso.TabIndex = 1;
			// 
			// lblPedido
			// 
			this.lblPedido.AutoSize = true;
			this.lblPedido.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPedido.Location = new System.Drawing.Point(3, 0);
			this.lblPedido.Name = "lblPedido";
			this.lblPedido.Size = new System.Drawing.Size(49, 43);
			this.lblPedido.TabIndex = 2;
			this.lblPedido.Text = "Pedido:";
			this.lblPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPeso
			// 
			this.lblPeso.AutoSize = true;
			this.lblPeso.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPeso.Location = new System.Drawing.Point(3, 43);
			this.lblPeso.Name = "lblPeso";
			this.lblPeso.Size = new System.Drawing.Size(49, 43);
			this.lblPeso.TabIndex = 3;
			this.lblPeso.Text = "Peso:";
			this.lblPeso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tlpPanelInferior
			// 
			this.tlpPanelInferior.ColumnCount = 4;
			this.tlpPanelInferior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpPanelInferior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpPanelInferior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpPanelInferior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpPanelInferior.Controls.Add(this.btnB9, 2, 0);
			this.tlpPanelInferior.Controls.Add(this.btnB8, 1, 0);
			this.tlpPanelInferior.Controls.Add(this.btnB7, 0, 0);
			this.tlpPanelInferior.Controls.Add(this.btnB4, 0, 1);
			this.tlpPanelInferior.Controls.Add(this.btnB5, 1, 1);
			this.tlpPanelInferior.Controls.Add(this.btnB6, 2, 1);
			this.tlpPanelInferior.Controls.Add(this.btnB1, 0, 2);
			this.tlpPanelInferior.Controls.Add(this.btnB2, 1, 2);
			this.tlpPanelInferior.Controls.Add(this.btnB3, 2, 2);
			this.tlpPanelInferior.Controls.Add(this.btnB0, 0, 3);
			this.tlpPanelInferior.Controls.Add(this.btnGrabar, 3, 1);
			this.tlpPanelInferior.Controls.Add(this.btnBorrar, 3, 0);
			this.tlpPanelInferior.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpPanelInferior.Location = new System.Drawing.Point(3, 95);
			this.tlpPanelInferior.Name = "tlpPanelInferior";
			this.tlpPanelInferior.RowCount = 4;
			this.tlpPanelInferior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpPanelInferior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpPanelInferior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpPanelInferior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpPanelInferior.Size = new System.Drawing.Size(278, 166);
			this.tlpPanelInferior.TabIndex = 1;
			// 
			// btnB9
			// 
			this.btnB9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnB9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnB9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnB9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnB9.Location = new System.Drawing.Point(141, 3);
			this.btnB9.Name = "btnB9";
			this.btnB9.Size = new System.Drawing.Size(63, 35);
			this.btnB9.TabIndex = 9;
			this.btnB9.Text = "9";
			this.btnB9.UseVisualStyleBackColor = true;
			this.btnB9.Click += new System.EventHandler(this.btnB9_Click);
			// 
			// btnB8
			// 
			this.btnB8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnB8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnB8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnB8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnB8.Location = new System.Drawing.Point(72, 3);
			this.btnB8.Name = "btnB8";
			this.btnB8.Size = new System.Drawing.Size(63, 35);
			this.btnB8.TabIndex = 8;
			this.btnB8.Text = "8";
			this.btnB8.UseVisualStyleBackColor = true;
			this.btnB8.Click += new System.EventHandler(this.btnB8_Click);
			// 
			// btnB7
			// 
			this.btnB7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnB7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnB7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnB7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnB7.Location = new System.Drawing.Point(3, 3);
			this.btnB7.Name = "btnB7";
			this.btnB7.Size = new System.Drawing.Size(63, 35);
			this.btnB7.TabIndex = 7;
			this.btnB7.Text = "7";
			this.btnB7.UseVisualStyleBackColor = true;
			this.btnB7.Click += new System.EventHandler(this.btnB7_Click);
			// 
			// btnB4
			// 
			this.btnB4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnB4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnB4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnB4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnB4.Location = new System.Drawing.Point(3, 44);
			this.btnB4.Name = "btnB4";
			this.btnB4.Size = new System.Drawing.Size(63, 35);
			this.btnB4.TabIndex = 4;
			this.btnB4.Text = "4";
			this.btnB4.UseVisualStyleBackColor = true;
			this.btnB4.Click += new System.EventHandler(this.btnB4_Click);
			// 
			// btnB5
			// 
			this.btnB5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnB5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnB5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnB5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnB5.Location = new System.Drawing.Point(72, 44);
			this.btnB5.Name = "btnB5";
			this.btnB5.Size = new System.Drawing.Size(63, 35);
			this.btnB5.TabIndex = 5;
			this.btnB5.Text = "5";
			this.btnB5.UseVisualStyleBackColor = true;
			this.btnB5.Click += new System.EventHandler(this.btnB5_Click);
			// 
			// btnB6
			// 
			this.btnB6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnB6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnB6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnB6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnB6.Location = new System.Drawing.Point(141, 44);
			this.btnB6.Name = "btnB6";
			this.btnB6.Size = new System.Drawing.Size(63, 35);
			this.btnB6.TabIndex = 6;
			this.btnB6.Text = "6";
			this.btnB6.UseVisualStyleBackColor = true;
			this.btnB6.Click += new System.EventHandler(this.btnB6_Click);
			// 
			// btnB1
			// 
			this.btnB1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnB1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnB1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnB1.Location = new System.Drawing.Point(3, 85);
			this.btnB1.Name = "btnB1";
			this.btnB1.Size = new System.Drawing.Size(63, 35);
			this.btnB1.TabIndex = 1;
			this.btnB1.Text = "1";
			this.btnB1.UseVisualStyleBackColor = true;
			this.btnB1.Click += new System.EventHandler(this.btnB1_Click);
			// 
			// btnB2
			// 
			this.btnB2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnB2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnB2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnB2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnB2.Location = new System.Drawing.Point(72, 85);
			this.btnB2.Name = "btnB2";
			this.btnB2.Size = new System.Drawing.Size(63, 35);
			this.btnB2.TabIndex = 2;
			this.btnB2.Text = "2";
			this.btnB2.UseVisualStyleBackColor = true;
			this.btnB2.Click += new System.EventHandler(this.btnB2_Click);
			// 
			// btnB3
			// 
			this.btnB3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnB3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnB3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnB3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnB3.Location = new System.Drawing.Point(141, 85);
			this.btnB3.Name = "btnB3";
			this.btnB3.Size = new System.Drawing.Size(63, 35);
			this.btnB3.TabIndex = 3;
			this.btnB3.Text = "3";
			this.btnB3.UseVisualStyleBackColor = true;
			this.btnB3.Click += new System.EventHandler(this.btnB3_Click);
			// 
			// btnB0
			// 
			this.btnB0.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.tlpPanelInferior.SetColumnSpan(this.btnB0, 3);
			this.btnB0.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnB0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnB0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnB0.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnB0.Location = new System.Drawing.Point(3, 126);
			this.btnB0.Name = "btnB0";
			this.btnB0.Size = new System.Drawing.Size(201, 37);
			this.btnB0.TabIndex = 0;
			this.btnB0.Text = "0";
			this.btnB0.UseVisualStyleBackColor = false;
			this.btnB0.Click += new System.EventHandler(this.btnB0_Click);
			// 
			// btnGrabar
			// 
			this.btnGrabar.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.btnGrabar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnGrabar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGrabar.Location = new System.Drawing.Point(210, 44);
			this.btnGrabar.Name = "btnGrabar";
			this.tlpPanelInferior.SetRowSpan(this.btnGrabar, 3);
			this.btnGrabar.Size = new System.Drawing.Size(65, 119);
			this.btnGrabar.TabIndex = 11;
			this.btnGrabar.Text = "Grabar";
			this.btnGrabar.UseVisualStyleBackColor = false;
			this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
			// 
			// btnBorrar
			// 
			this.btnBorrar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.btnBorrar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnBorrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBorrar.Location = new System.Drawing.Point(210, 3);
			this.btnBorrar.Name = "btnBorrar";
			this.btnBorrar.Size = new System.Drawing.Size(65, 35);
			this.btnBorrar.TabIndex = 10;
			this.btnBorrar.Text = "Borrar";
			this.btnBorrar.UseVisualStyleBackColor = false;
			this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
			// 
			// frmLectorBascula
			// 
			this.AcceptButton = this.btnGrabar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 264);
			this.Controls.Add(this.tlpPanelPrincipal);
			this.Icon = global::Dapesa.Almacen.Pedidos.Trazabilidad.IU.Empaque.Properties.Resources.port;
			this.MinimumSize = new System.Drawing.Size(300, 300);
			this.Name = "frmLectorBascula";
			this.Text = "Pedido";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLectorBascula_FormClosed);
			this.Load += new System.EventHandler(this.frmLectorBascula_Load);
			this.ResizeEnd += new System.EventHandler(this.frmLectorBascula_ResizeEnd);
			this.Resize += new System.EventHandler(this.frmLectorBascula_Resize);
			this.tlpPanelPrincipal.ResumeLayout(false);
			this.tlpPanelSuperior.ResumeLayout(false);
			this.tlpPanelSuperior.PerformLayout();
			this.tlpPanelInferior.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tlpPanelPrincipal;
		private System.Windows.Forms.TableLayoutPanel tlpPanelSuperior;
		private System.Windows.Forms.TableLayoutPanel tlpPanelInferior;
		private System.Windows.Forms.Label lblPedido;
		private System.Windows.Forms.Label lblPeso;
		private System.Windows.Forms.TextBox txtPedido;
		private System.Windows.Forms.TextBox txtPeso;
		private System.Windows.Forms.Button btnB9;
		private System.Windows.Forms.Button btnB8;
		private System.Windows.Forms.Button btnB7;
		private System.Windows.Forms.Button btnB4;
		private System.Windows.Forms.Button btnB5;
		private System.Windows.Forms.Button btnB6;
		private System.Windows.Forms.Button btnB1;
		private System.Windows.Forms.Button btnB2;
		private System.Windows.Forms.Button btnB3;
		private System.Windows.Forms.Button btnB0;
		private System.Windows.Forms.Button btnGrabar;
		private System.Windows.Forms.Button btnBorrar;
	}
}

