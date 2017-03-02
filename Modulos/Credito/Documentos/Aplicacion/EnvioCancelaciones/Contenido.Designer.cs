namespace Dapesa.Credito.Documentos.IU.EnvioCancela
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contenido));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbTipoDocumento = new System.Windows.Forms.GroupBox();
            this.flpTipoDocumento = new System.Windows.Forms.FlowLayoutPanel();
            this.rbFactura = new System.Windows.Forms.RadioButton();
            this.rbNotaCredito = new System.Windows.Forms.RadioButton();
            this.rbNotaCargo = new System.Windows.Forms.RadioButton();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblFolio = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.btnEnviarEmail = new System.Windows.Forms.Button();
            this.pbRequeridoFolio = new System.Windows.Forms.PictureBox();
            this.pbRequeridoNumero = new System.Windows.Forms.PictureBox();
            this.ttInformacion = new System.Windows.Forms.ToolTip(this.components);
            this.ttRequerido = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.gbTipoDocumento.SuspendLayout();
            this.flpTipoDocumento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRequeridoFolio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRequeridoNumero)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.Controls.Add(this.gbTipoDocumento, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblNumero, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFolio, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pbLogo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFolio, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNumero, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnEnviarEmail, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.pbRequeridoFolio, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.pbRequeridoNumero, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(752, 446);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gbTipoDocumento
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gbTipoDocumento, 2);
            this.gbTipoDocumento.Controls.Add(this.flpTipoDocumento);
            this.gbTipoDocumento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTipoDocumento.Location = new System.Drawing.Point(71, 186);
            this.gbTipoDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.gbTipoDocumento.Name = "gbTipoDocumento";
            this.gbTipoDocumento.Padding = new System.Windows.Forms.Padding(4);
            this.gbTipoDocumento.Size = new System.Drawing.Size(583, 114);
            this.gbTipoDocumento.TabIndex = 6;
            this.gbTipoDocumento.TabStop = false;
            this.gbTipoDocumento.Text = "Tipo documento";
            // 
            // flpTipoDocumento
            // 
            this.flpTipoDocumento.Controls.Add(this.rbFactura);
            this.flpTipoDocumento.Controls.Add(this.rbNotaCredito);
            this.flpTipoDocumento.Controls.Add(this.rbNotaCargo);
            this.flpTipoDocumento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTipoDocumento.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTipoDocumento.Location = new System.Drawing.Point(4, 19);
            this.flpTipoDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.flpTipoDocumento.Name = "flpTipoDocumento";
            this.flpTipoDocumento.Size = new System.Drawing.Size(575, 91);
            this.flpTipoDocumento.TabIndex = 0;
            // 
            // rbFactura
            // 
            this.rbFactura.AutoSize = true;
            this.rbFactura.Checked = true;
            this.rbFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbFactura.Location = new System.Drawing.Point(4, 4);
            this.rbFactura.Margin = new System.Windows.Forms.Padding(4);
            this.rbFactura.Name = "rbFactura";
            this.rbFactura.Size = new System.Drawing.Size(126, 21);
            this.rbFactura.TabIndex = 6;
            this.rbFactura.TabStop = true;
            this.rbFactura.Text = "Factura";
            this.rbFactura.UseVisualStyleBackColor = true;
            // 
            // rbNotaCredito
            // 
            this.rbNotaCredito.AutoSize = true;
            this.rbNotaCredito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbNotaCredito.Location = new System.Drawing.Point(4, 33);
            this.rbNotaCredito.Margin = new System.Windows.Forms.Padding(4);
            this.rbNotaCredito.Name = "rbNotaCredito";
            this.rbNotaCredito.Size = new System.Drawing.Size(126, 21);
            this.rbNotaCredito.TabIndex = 7;
            this.rbNotaCredito.Text = "Nota de crédito";
            this.rbNotaCredito.UseVisualStyleBackColor = true;
            // 
            // rbNotaCargo
            // 
            this.rbNotaCargo.AutoSize = true;
            this.rbNotaCargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbNotaCargo.Location = new System.Drawing.Point(4, 62);
            this.rbNotaCargo.Margin = new System.Windows.Forms.Padding(4);
            this.rbNotaCargo.Name = "rbNotaCargo";
            this.rbNotaCargo.Size = new System.Drawing.Size(126, 21);
            this.rbNotaCargo.TabIndex = 8;
            this.rbNotaCargo.Text = "Nota de cargo";
            this.rbNotaCargo.UseVisualStyleBackColor = true;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumero.Location = new System.Drawing.Point(71, 122);
            this.lblNumero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(62, 35);
            this.lblNumero.TabIndex = 1;
            this.lblNumero.Text = "Numero:";
            this.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFolio.Location = new System.Drawing.Point(71, 87);
            this.lblFolio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(62, 35);
            this.lblFolio.TabIndex = 1;
            this.lblFolio.Text = "Folio:";
            this.lblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbLogo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pbLogo, 4);
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbLogo.Image = global::Dapesa.Credito.Documentos.IU.EnvioCancela.Properties.Resources.dapesa500;
            this.pbLogo.Location = new System.Drawing.Point(548, 4);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(200, 54);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;
            // 
            // txtFolio
            // 
            this.txtFolio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFolio.Location = new System.Drawing.Point(141, 91);
            this.txtFolio.Margin = new System.Windows.Forms.Padding(4);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(513, 22);
            this.txtFolio.TabIndex = 1;
            // 
            // txtNumero
            // 
            this.txtNumero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNumero.Location = new System.Drawing.Point(141, 126);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(513, 22);
            this.txtNumero.TabIndex = 2;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // btnEnviarEmail
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnEnviarEmail, 2);
            this.btnEnviarEmail.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEnviarEmail.Image = global::Dapesa.Credito.Documentos.IU.EnvioCancela.Properties.Resources.enviar;
            this.btnEnviarEmail.Location = new System.Drawing.Point(554, 308);
            this.btnEnviarEmail.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnviarEmail.Name = "btnEnviarEmail";
            this.btnEnviarEmail.Size = new System.Drawing.Size(100, 89);
            this.btnEnviarEmail.TabIndex = 7;
            this.btnEnviarEmail.UseVisualStyleBackColor = true;
            this.btnEnviarEmail.Click += new System.EventHandler(this.btnEnviarEmail_Click);
            // 
            // pbRequeridoFolio
            // 
            this.pbRequeridoFolio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbRequeridoFolio.Image = global::Dapesa.Credito.Documentos.IU.EnvioCancela.Properties.Resources.requerido;
            this.pbRequeridoFolio.Location = new System.Drawing.Point(662, 91);
            this.pbRequeridoFolio.Margin = new System.Windows.Forms.Padding(4);
            this.pbRequeridoFolio.Name = "pbRequeridoFolio";
            this.pbRequeridoFolio.Size = new System.Drawing.Size(19, 27);
            this.pbRequeridoFolio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbRequeridoFolio.TabIndex = 8;
            this.pbRequeridoFolio.TabStop = false;
            this.pbRequeridoFolio.Visible = false;
            // 
            // pbRequeridoNumero
            // 
            this.pbRequeridoNumero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbRequeridoNumero.Image = global::Dapesa.Credito.Documentos.IU.EnvioCancela.Properties.Resources.requerido;
            this.pbRequeridoNumero.Location = new System.Drawing.Point(662, 126);
            this.pbRequeridoNumero.Margin = new System.Windows.Forms.Padding(4);
            this.pbRequeridoNumero.Name = "pbRequeridoNumero";
            this.pbRequeridoNumero.Size = new System.Drawing.Size(19, 27);
            this.pbRequeridoNumero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbRequeridoNumero.TabIndex = 9;
            this.pbRequeridoNumero.TabStop = false;
            this.pbRequeridoNumero.Visible = false;
            // 
            // Contenido
            // 
            this.AcceptButton = this.btnEnviarEmail;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 446);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Contenido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envio de Cancelaciones por E-mail.";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbTipoDocumento.ResumeLayout(false);
            this.flpTipoDocumento.ResumeLayout(false);
            this.flpTipoDocumento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRequeridoFolio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRequeridoNumero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.GroupBox gbTipoDocumento;
        private System.Windows.Forms.FlowLayoutPanel flpTipoDocumento;
        private System.Windows.Forms.RadioButton rbFactura;
        private System.Windows.Forms.RadioButton rbNotaCredito;
        private System.Windows.Forms.RadioButton rbNotaCargo;
        private System.Windows.Forms.Button btnEnviarEmail;
        private System.Windows.Forms.ToolTip ttInformacion;
        private System.Windows.Forms.PictureBox pbRequeridoFolio;
        private System.Windows.Forms.PictureBox pbRequeridoNumero;
        private System.Windows.Forms.ToolTip ttRequerido;

    }
}