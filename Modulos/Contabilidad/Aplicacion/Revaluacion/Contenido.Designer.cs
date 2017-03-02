namespace Contabilidad.IU.Revaluacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gvContenido = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbProgreso = new System.Windows.Forms.ProgressBar();
            this.pbRevaluacion = new System.Windows.Forms.ProgressBar();
            this.lblContadorRevaluacionArticulo = new System.Windows.Forms.Label();
            this.lblContadorArticulo = new System.Windows.Forms.Label();
            this.btnCargarArticulos = new System.Windows.Forms.Button();
            this.btnInicarRevaluacion = new System.Windows.Forms.Button();
            this.btnEjecutarTxt = new System.Windows.Forms.Button();
            this.lblContadorActualizacion = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvContenido)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.74627F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.25373F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 197F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Controls.Add(this.gvContenido, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.pbProgreso, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.pbRevaluacion, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblContadorRevaluacionArticulo, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblContadorArticulo, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCargarArticulos, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnInicarRevaluacion, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnEjecutarTxt, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblContadorActualizacion, 4, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(631, 257);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gvContenido
            // 
            this.gvContenido.AllowUserToAddRows = false;
            this.gvContenido.AllowUserToDeleteRows = false;
            this.gvContenido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.gvContenido, 2);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvContenido.DefaultCellStyle = dataGridViewCellStyle1;
            this.gvContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvContenido.Location = new System.Drawing.Point(23, 71);
            this.gvContenido.Name = "gvContenido";
            this.gvContenido.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.gvContenido, 2);
            this.gvContenido.Size = new System.Drawing.Size(176, 163);
            this.gvContenido.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Prog. Articulo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Revaluacion Art.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbProgreso
            // 
            this.pbProgreso.Location = new System.Drawing.Point(304, 71);
            this.pbProgreso.Name = "pbProgreso";
            this.pbProgreso.Size = new System.Drawing.Size(190, 14);
            this.pbProgreso.TabIndex = 0;
            // 
            // pbRevaluacion
            // 
            this.pbRevaluacion.Location = new System.Drawing.Point(304, 157);
            this.pbRevaluacion.Name = "pbRevaluacion";
            this.pbRevaluacion.Size = new System.Drawing.Size(190, 14);
            this.pbRevaluacion.TabIndex = 5;
            // 
            // lblContadorRevaluacionArticulo
            // 
            this.lblContadorRevaluacionArticulo.AutoSize = true;
            this.lblContadorRevaluacionArticulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContadorRevaluacionArticulo.Location = new System.Drawing.Point(501, 154);
            this.lblContadorRevaluacionArticulo.Name = "lblContadorRevaluacionArticulo";
            this.lblContadorRevaluacionArticulo.Size = new System.Drawing.Size(114, 83);
            this.lblContadorRevaluacionArticulo.TabIndex = 7;
            this.lblContadorRevaluacionArticulo.Text = "0 / 0";
            // 
            // lblContadorArticulo
            // 
            this.lblContadorArticulo.AutoSize = true;
            this.lblContadorArticulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContadorArticulo.Location = new System.Drawing.Point(501, 68);
            this.lblContadorArticulo.Name = "lblContadorArticulo";
            this.lblContadorArticulo.Size = new System.Drawing.Size(114, 86);
            this.lblContadorArticulo.TabIndex = 8;
            this.lblContadorArticulo.Text = "0 / 0";
            // 
            // btnCargarArticulos
            // 
            this.btnCargarArticulos.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCargarArticulos.Location = new System.Drawing.Point(23, 23);
            this.btnCargarArticulos.Name = "btnCargarArticulos";
            this.btnCargarArticulos.Size = new System.Drawing.Size(73, 42);
            this.btnCargarArticulos.TabIndex = 1;
            this.btnCargarArticulos.Text = "Cargar Articulos";
            this.btnCargarArticulos.UseVisualStyleBackColor = true;
            this.btnCargarArticulos.Click += new System.EventHandler(this.btnCargarArticulos_Click);
            // 
            // btnInicarRevaluacion
            // 
            this.btnInicarRevaluacion.Location = new System.Drawing.Point(102, 23);
            this.btnInicarRevaluacion.Name = "btnInicarRevaluacion";
            this.btnInicarRevaluacion.Size = new System.Drawing.Size(86, 42);
            this.btnInicarRevaluacion.TabIndex = 9;
            this.btnInicarRevaluacion.Text = "Iniciar Revaluacion";
            this.btnInicarRevaluacion.UseVisualStyleBackColor = true;
            this.btnInicarRevaluacion.Click += new System.EventHandler(this.btnInicarRevaluacion_Click);
            // 
            // btnEjecutarTxt
            // 
            this.btnEjecutarTxt.Location = new System.Drawing.Point(205, 23);
            this.btnEjecutarTxt.Name = "btnEjecutarTxt";
            this.btnEjecutarTxt.Size = new System.Drawing.Size(86, 42);
            this.btnEjecutarTxt.TabIndex = 10;
            this.btnEjecutarTxt.Text = "Ejecutar TXT";
            this.btnEjecutarTxt.UseVisualStyleBackColor = true;
            this.btnEjecutarTxt.Click += new System.EventHandler(this.btnEjecutarTxt_Click);
            // 
            // lblContadorActualizacion
            // 
            this.lblContadorActualizacion.AutoSize = true;
            this.lblContadorActualizacion.BackColor = System.Drawing.Color.DarkBlue;
            this.lblContadorActualizacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContadorActualizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContadorActualizacion.ForeColor = System.Drawing.Color.White;
            this.lblContadorActualizacion.Location = new System.Drawing.Point(304, 237);
            this.lblContadorActualizacion.Name = "lblContadorActualizacion";
            this.lblContadorActualizacion.Size = new System.Drawing.Size(191, 20);
            this.lblContadorActualizacion.TabIndex = 11;
            this.lblContadorActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Contenido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 257);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(683, 295);
            this.Name = "Contenido";
            this.Text = "Contenido";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvContenido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ProgressBar pbProgreso;
        private System.Windows.Forms.Button btnCargarArticulos;
        private System.Windows.Forms.DataGridView gvContenido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pbRevaluacion;
        private System.Windows.Forms.Label lblContadorRevaluacionArticulo;
        private System.Windows.Forms.Label lblContadorArticulo;
        private System.Windows.Forms.Button btnInicarRevaluacion;
        private System.Windows.Forms.Button btnEjecutarTxt;
        private System.Windows.Forms.Label lblContadorActualizacion;

    }
}