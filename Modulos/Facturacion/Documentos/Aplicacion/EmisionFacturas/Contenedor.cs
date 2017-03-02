using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dapesa.Facturacion.Documentos.IU.EmisionFacturas
{
    public partial class Contenedor : Form
    {
        #region Constructor

        public Contenedor()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos

        private void Contenedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Invalidate(true);
            this.Owner.Refresh();
            this.Owner.Update();
            this.Owner.Show();
        }

        private void Contenedor_Load(object sender, EventArgs e)
        {
            tsslCredenciales.Text += ((InicioSesion)this.Owner).Sesion.Usuario.Nombre.ToUpper();
            tsslSucursal.Text += ((InicioSesion)this.Owner).Sesion.Usuario.Sucursal[0].Descripcion.ToUpper();
            Contenido loEnvioCancelaciones = new Contenido()
            {
                ControlBox = true,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable,
                MdiParent = this,
                MinimizeBox = true,
                ShowIcon = true,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            loEnvioCancelaciones.Show();
        }

        #endregion
    }
}
