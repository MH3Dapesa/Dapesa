using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dapesa.Sistemas.Seguridad.UI.Permiso
{
    public partial class Contenedor : Form
    {
        #region Constructor

        public Contenedor()
        {
            InitializeComponent();
            Grupo loContenido = new Grupo()
            {
                ControlBox = true,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable,
                MdiParent = this,
                MinimizeBox = true,
                ShowIcon = true,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };
            loContenido.Show();
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
            //AÑADIR ITEMS AL MENU
            int Clave = 0;
            for (int i = 0; i < ((InicioSesion)this.Owner).Sesion.Usuario.Permiso.Count; i++)
            {
                if (((InicioSesion)this.Owner).Sesion.Usuario.Permiso[i].Agrupador == null)
                {
                    Clave = (int)((InicioSesion)this.Owner).Sesion.Usuario.Permiso[i].Clave;
                    ToolStripMenuItem miMenu = new ToolStripMenuItem();
                    miMenu.Name = "mi" + ((InicioSesion)this.Owner).Sesion.Usuario.Permiso[i].Descripcion;
                    miMenu.Text = ((InicioSesion)this.Owner).Sesion.Usuario.Permiso[i].Descripcion;
                    msMenu.Items.Add(miMenu);

                    for (int j = 0; j < ((InicioSesion)this.Owner).Sesion.Usuario.Permiso.Count; j++)
                    {
                        if (((InicioSesion)this.Owner).Sesion.Usuario.Permiso[j].Agrupador != null)
                        {
                            int agrupadorhijo = (int)((InicioSesion)this.Owner).Sesion.Usuario.Permiso[j].Agrupador;
                            if (agrupadorhijo == Clave)
                            {
                                ToolStripMenuItem miMenuItem = new ToolStripMenuItem();
                                miMenuItem.Name = "mi" + ((InicioSesion)this.Owner).Sesion.Usuario.Permiso[j].Descripcion;
                                miMenuItem.Text = ((InicioSesion)this.Owner).Sesion.Usuario.Permiso[j].Descripcion;
                                miMenuItem.Click += new System.EventHandler(toolStripMenuItem_Click);
                                miMenu.DropDownItems.Add(miMenuItem);
                            }
                        }
                    }
                }
            }
            //foreach (Dapesa.Seguridad.Entidades.Permiso llpemiso in ((InicioSesion)this.Owner).Sesion.Usuario.Permiso)
            //{
            //    ToolStripMenuItem miMenu = new ToolStripMenuItem();
            //    miMenu.Name = "mi" + llpemiso.Descripcion;
            //    miMenu.Text = llpemiso.Descripcion;

            //    msMenu.Items.Add(miMenu);

            //    ToolStripMenuItem miMenuItem = new ToolStripMenuItem();
            //    miMenuItem.Name = "mi" + llpemiso.Descripcion;
            //    miMenuItem.Text = llpemiso.Descripcion;
            //    miMenuItem.Click += new System.EventHandler(toolStripMenuItem_Click);
            //    miMenu.DropDownItems.Add(miMenuItem);
            //}

        }

        #endregion

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Dapesa.Seguridad.Entidades.Permiso llpemiso in ((InicioSesion)this.Owner).Sesion.Usuario.Permiso)
            {

                switch (llpemiso.Clave)
                {
                    case 10:
                        if (!Dapesa.Comun.Utilerias.IU.ExisteFormulario(typeof(Grupo), this.MdiChildren))
                        {
                            Grupo loContenido = new Grupo()
                            {
                                ControlBox = true,
                                FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable,
                                MdiParent = this,
                                MinimizeBox = true,
                                ShowIcon = true,
                                StartPosition = FormStartPosition.CenterScreen,
                                WindowState = FormWindowState.Normal
                            };
                            loContenido.Show();
                        }
                        break;
                }
            }
        }
        private void msMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}