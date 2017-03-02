using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dapesa.Tesoreria.Bancos.IU.Cobros
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
            
        }

        private void tsmiBanamex_Click(object sender, EventArgs e)
        {
            if (!Dapesa.Comun.Utilerias.IU.ExisteFormulario(typeof(Contenido), this.MdiChildren))
            {
                Contenido loBanamex = new Contenido()
                {
                    ControlBox = true,
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable,
                    MdiParent = this,
                    MinimizeBox = true,
                    ShowIcon = true,
                    StartPosition = FormStartPosition.CenterScreen,
                    WindowState = FormWindowState.Maximized
                };
                loBanamex.Show();
            }
        }

        private void tsmiBancomer_Click(object sender, EventArgs e)
        {
            if (!Dapesa.Comun.Utilerias.IU.ExisteFormulario(typeof(Bancomer), this.MdiChildren))
            {
                Bancomer loBancomer = new Bancomer()
                {
                    ControlBox = true,
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable,
                    MdiParent = this,
                    MinimizeBox = true,
                    ShowIcon = true,
                    StartPosition = FormStartPosition.CenterScreen,
                    WindowState = FormWindowState.Maximized
                };
                loBancomer.Show();
            }
        }

        private void tsmiHSBC_Click(object sender, EventArgs e)
        {
            if (!Dapesa.Comun.Utilerias.IU.ExisteFormulario(typeof(HSBC), this.MdiChildren))
            {
                HSBC loHSBC = new HSBC()
                {
                    ControlBox = true,
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable,
                    MdiParent = this,
                    MinimizeBox = true,
                    ShowIcon = true,
                    StartPosition = FormStartPosition.CenterScreen,
                    WindowState = FormWindowState.Maximized
                };
                loHSBC.Show();
            }
        }

        private void tsmiSantander_Click(object sender, EventArgs e)
        {
            if (!Dapesa.Comun.Utilerias.IU.ExisteFormulario(typeof(Santander), this.MdiChildren))
            {
                Santander loSantander = new Santander()
                {
                    ControlBox = true,
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable,
                    MdiParent = this,
                    MinimizeBox = true,
                    ShowIcon = true,
                    StartPosition = FormStartPosition.CenterScreen,
                    WindowState = FormWindowState.Maximized
                };
                loSantander.Show();
            }
        }

        private void tsmiBanorte_Click(object sender, EventArgs e)
        {
            if (!Dapesa.Comun.Utilerias.IU.ExisteFormulario(typeof(Banorte), this.MdiChildren))
            {
                Banorte loBanorte = new Banorte()
                {
                    ControlBox = true,
                    FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable,
                    MdiParent = this,
                    MinimizeBox = true,
                    ShowIcon = true,
                    StartPosition = FormStartPosition.CenterScreen,
                    WindowState = FormWindowState.Maximized
                };
                loBanorte.Show();
            }
        }

        private void tsmiSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
