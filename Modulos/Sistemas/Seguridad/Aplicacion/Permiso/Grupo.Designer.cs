namespace Dapesa.Sistemas.Seguridad.UI.Permiso
{
    partial class Grupo
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
            this.tcGrupo = new System.Windows.Forms.TabControl();
            this.tpGrupo = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbLogoGrupo = new System.Windows.Forms.PictureBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.Label();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblRequeridoClave = new System.Windows.Forms.Label();
            this.lblRequeridoDescripcion = new System.Windows.Forms.Label();
            this.lblRequeridoEstado = new System.Windows.Forms.Label();
            this.btnBuscarGrupo = new System.Windows.Forms.Button();
            this.tpRelacionGrupo = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPersonal = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.lblAplicacion = new System.Windows.Forms.Label();
            this.cbPersonal = new System.Windows.Forms.ComboBox();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.cbAplicacion = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPermisos = new System.Windows.Forms.Label();
            this.gvPermisos = new System.Windows.Forms.DataGridView();
            this.tcGrupo.SuspendLayout();
            this.tpGrupo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoGrupo)).BeginInit();
            this.tpRelacionGrupo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPermisos)).BeginInit();
            this.SuspendLayout();
            // 
            // tcGrupo
            // 
            this.tcGrupo.Controls.Add(this.tpGrupo);
            this.tcGrupo.Controls.Add(this.tpRelacionGrupo);
            this.tcGrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcGrupo.Location = new System.Drawing.Point(0, 0);
            this.tcGrupo.Name = "tcGrupo";
            this.tcGrupo.SelectedIndex = 0;
            this.tcGrupo.Size = new System.Drawing.Size(848, 381);
            this.tcGrupo.TabIndex = 0;
            // 
            // tpGrupo
            // 
            this.tpGrupo.Controls.Add(this.tableLayoutPanel1);
            this.tpGrupo.Location = new System.Drawing.Point(4, 22);
            this.tpGrupo.Name = "tpGrupo";
            this.tpGrupo.Padding = new System.Windows.Forms.Padding(3);
            this.tpGrupo.Size = new System.Drawing.Size(840, 355);
            this.tpGrupo.TabIndex = 0;
            this.tpGrupo.Text = "Crear Grupo";
            this.tpGrupo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Controls.Add(this.pbLogoGrupo, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtClave, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcion, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblClave, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDescripcion, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtEstado, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbEstado, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnGuardar, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblRequeridoClave, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblRequeridoDescripcion, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblRequeridoEstado, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnBuscarGrupo, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 349);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pbLogoGrupo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pbLogoGrupo, 3);
            this.pbLogoGrupo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbLogoGrupo.Image = global::Dapesa.Sistemas.Seguridad.UI.Permiso.Properties.Resources.dapesa500;
            this.pbLogoGrupo.Location = new System.Drawing.Point(681, 3);
            this.pbLogoGrupo.Name = "pbLogoGrupo";
            this.pbLogoGrupo.Size = new System.Drawing.Size(150, 50);
            this.pbLogoGrupo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogoGrupo.TabIndex = 0;
            this.pbLogoGrupo.TabStop = false;
            // 
            // txtClave
            // 
            this.txtClave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtClave.Enabled = false;
            this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(225, 89);
            this.txtClave.MaxLength = 10;
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(416, 20);
            this.txtClave.TabIndex = 10;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(225, 115);
            this.txtDescripcion.MaxLength = 60;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(416, 20);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(153, 86);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(37, 13);
            this.lblClave.TabIndex = 3;
            this.lblClave.Text = "Clave:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(153, 112);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 4;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtEstado
            // 
            this.txtEstado.AutoSize = true;
            this.txtEstado.Location = new System.Drawing.Point(153, 141);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(43, 13);
            this.txtEstado.TabIndex = 5;
            this.txtEstado.Text = "Estado:";
            // 
            // cbEstado
            // 
            this.cbEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.Enabled = false;
            this.cbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.cbEstado.Location = new System.Drawing.Point(225, 144);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(416, 21);
            this.cbEstado.TabIndex = 2;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Image = global::Dapesa.Sistemas.Seguridad.UI.Permiso.Properties.Resources.guardar;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(550, 201);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(91, 37);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Registrar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // lblRequeridoClave
            // 
            this.lblRequeridoClave.AutoSize = true;
            this.lblRequeridoClave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRequeridoClave.Image = global::Dapesa.Sistemas.Seguridad.UI.Permiso.Properties.Resources.requerido;
            this.lblRequeridoClave.Location = new System.Drawing.Point(677, 86);
            this.lblRequeridoClave.Name = "lblRequeridoClave";
            this.lblRequeridoClave.Size = new System.Drawing.Size(14, 26);
            this.lblRequeridoClave.TabIndex = 9;
            this.lblRequeridoClave.Visible = false;
            // 
            // lblRequeridoDescripcion
            // 
            this.lblRequeridoDescripcion.AutoSize = true;
            this.lblRequeridoDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRequeridoDescripcion.Image = global::Dapesa.Sistemas.Seguridad.UI.Permiso.Properties.Resources.requerido;
            this.lblRequeridoDescripcion.Location = new System.Drawing.Point(677, 112);
            this.lblRequeridoDescripcion.Name = "lblRequeridoDescripcion";
            this.lblRequeridoDescripcion.Size = new System.Drawing.Size(14, 29);
            this.lblRequeridoDescripcion.TabIndex = 10;
            this.lblRequeridoDescripcion.Visible = false;
            // 
            // lblRequeridoEstado
            // 
            this.lblRequeridoEstado.AutoSize = true;
            this.lblRequeridoEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRequeridoEstado.Image = global::Dapesa.Sistemas.Seguridad.UI.Permiso.Properties.Resources.requerido;
            this.lblRequeridoEstado.Location = new System.Drawing.Point(677, 141);
            this.lblRequeridoEstado.Name = "lblRequeridoEstado";
            this.lblRequeridoEstado.Size = new System.Drawing.Size(14, 27);
            this.lblRequeridoEstado.TabIndex = 11;
            this.lblRequeridoEstado.Visible = false;
            // 
            // btnBuscarGrupo
            // 
            this.btnBuscarGrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuscarGrupo.Image = global::Dapesa.Sistemas.Seguridad.UI.Permiso.Properties.Resources.buscar;
            this.btnBuscarGrupo.Location = new System.Drawing.Point(647, 115);
            this.btnBuscarGrupo.Name = "btnBuscarGrupo";
            this.btnBuscarGrupo.Size = new System.Drawing.Size(24, 23);
            this.btnBuscarGrupo.TabIndex = 12;
            this.btnBuscarGrupo.UseVisualStyleBackColor = true;
            this.btnBuscarGrupo.Click += new System.EventHandler(this.btnBuscarGrupo_Click);
            // 
            // tpRelacionGrupo
            // 
            this.tpRelacionGrupo.Controls.Add(this.tableLayoutPanel2);
            this.tpRelacionGrupo.Location = new System.Drawing.Point(4, 22);
            this.tpRelacionGrupo.Name = "tpRelacionGrupo";
            this.tpRelacionGrupo.Padding = new System.Windows.Forms.Padding(3);
            this.tpRelacionGrupo.Size = new System.Drawing.Size(840, 355);
            this.tpRelacionGrupo.TabIndex = 1;
            this.tpRelacionGrupo.Text = "Añadir Relación";
            this.tpRelacionGrupo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 10;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Controls.Add(this.lblPersonal, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblGrupo, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblAplicacion, 7, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbPersonal, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbGrupo, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbAplicacion, 8, 2);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPermisos, 7, 4);
            this.tableLayoutPanel2.Controls.Add(this.gvPermisos, 7, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(834, 349);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblPersonal
            // 
            this.lblPersonal.AutoSize = true;
            this.lblPersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPersonal.Location = new System.Drawing.Point(69, 66);
            this.lblPersonal.Name = "lblPersonal";
            this.lblPersonal.Size = new System.Drawing.Size(51, 27);
            this.lblPersonal.TabIndex = 0;
            this.lblPersonal.Text = "Personal:";
            this.lblPersonal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGrupo.Location = new System.Drawing.Point(319, 66);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 27);
            this.lblGrupo.TabIndex = 1;
            this.lblGrupo.Text = "Grupo:";
            this.lblGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAplicacion
            // 
            this.lblAplicacion.AutoSize = true;
            this.lblAplicacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAplicacion.Location = new System.Drawing.Point(550, 66);
            this.lblAplicacion.Name = "lblAplicacion";
            this.lblAplicacion.Size = new System.Drawing.Size(59, 27);
            this.lblAplicacion.TabIndex = 2;
            this.lblAplicacion.Text = "Aplicación:";
            this.lblAplicacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbPersonal
            // 
            this.cbPersonal.DisplayMember = "NOMBRE";
            this.cbPersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbPersonal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPersonal.FormattingEnabled = true;
            this.cbPersonal.Location = new System.Drawing.Point(126, 69);
            this.cbPersonal.MinimumSize = new System.Drawing.Size(175, 0);
            this.cbPersonal.Name = "cbPersonal";
            this.cbPersonal.Size = new System.Drawing.Size(175, 21);
            this.cbPersonal.TabIndex = 3;
            this.cbPersonal.ValueMember = "CLAVE";
            // 
            // cbGrupo
            // 
            this.cbGrupo.DisplayMember = "DESCRIPCION";
            this.cbGrupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Location = new System.Drawing.Point(364, 69);
            this.cbGrupo.MinimumSize = new System.Drawing.Size(175, 0);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(175, 21);
            this.cbGrupo.TabIndex = 4;
            this.cbGrupo.ValueMember = "CLAVE";
            this.cbGrupo.SelectedIndexChanged += new System.EventHandler(this.cbGrupo_SelectedIndexChanged);
            // 
            // cbAplicacion
            // 
            this.cbAplicacion.DisplayMember = "DESCRIPCION";
            this.cbAplicacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbAplicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAplicacion.Enabled = false;
            this.cbAplicacion.FormattingEnabled = true;
            this.cbAplicacion.Location = new System.Drawing.Point(615, 69);
            this.cbAplicacion.MinimumSize = new System.Drawing.Size(175, 0);
            this.cbAplicacion.Name = "cbAplicacion";
            this.cbAplicacion.Size = new System.Drawing.Size(175, 21);
            this.cbAplicacion.TabIndex = 5;
            this.cbAplicacion.ValueMember = "CLAVE";
            // 
            // pictureBox1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.pictureBox1, 4);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::Dapesa.Sistemas.Seguridad.UI.Permiso.Properties.Resources.dapesa500;
            this.pictureBox1.Location = new System.Drawing.Point(681, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // lblPermisos
            // 
            this.lblPermisos.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblPermisos, 2);
            this.lblPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPermisos.Location = new System.Drawing.Point(550, 103);
            this.lblPermisos.Name = "lblPermisos";
            this.lblPermisos.Size = new System.Drawing.Size(212, 20);
            this.lblPermisos.TabIndex = 7;
            this.lblPermisos.Text = "Permisos:";
            this.lblPermisos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gvPermisos
            // 
            this.gvPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel2.SetColumnSpan(this.gvPermisos, 2);
            this.gvPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvPermisos.Enabled = false;
            this.gvPermisos.Location = new System.Drawing.Point(550, 126);
            this.gvPermisos.MinimumSize = new System.Drawing.Size(240, 210);
            this.gvPermisos.Name = "gvPermisos";
            this.gvPermisos.Size = new System.Drawing.Size(240, 210);
            this.gvPermisos.TabIndex = 8;
            // 
            // Grupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 381);
            this.Controls.Add(this.tcGrupo);
            this.Name = "Grupo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Grupo";
            this.Load += new System.EventHandler(this.Grupo_Load);
            this.Shown += new System.EventHandler(this.Grupo_Shown);
            this.tcGrupo.ResumeLayout(false);
            this.tpGrupo.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoGrupo)).EndInit();
            this.tpRelacionGrupo.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPermisos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcGrupo;
        private System.Windows.Forms.TabPage tpRelacionGrupo;
        private System.Windows.Forms.TabPage tpGrupo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbLogoGrupo;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label txtEstado;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblRequeridoClave;
        private System.Windows.Forms.Label lblRequeridoDescripcion;
        private System.Windows.Forms.Label lblRequeridoEstado;
        private System.Windows.Forms.Button btnBuscarGrupo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblPersonal;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Label lblAplicacion;
        private System.Windows.Forms.ComboBox cbPersonal;
        private System.Windows.Forms.ComboBox cbGrupo;
        private System.Windows.Forms.ComboBox cbAplicacion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPermisos;
        private System.Windows.Forms.DataGridView gvPermisos;


    }
}