using Dapesa.Seguridad.Entidades;
using Dapesa.Sistemas.Seguridad.Reglas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dapesa.Criptografia.Reglas;

namespace Dapesa.Sistemas.Seguridad.UI.Permiso
{
    public partial class BuscarGrupo : Form
    {
        public BuscarGrupo()
        {
            InitializeComponent();
        }


        private void BuscarGrupo_show(object sender, EventArgs e)
        {
            txtDescripcion.Text = string.Empty;
            ttDescripcion.SetToolTip(txtDescripcion, "Realizar Busqueda (F8)");
            ttDescripcion.SetToolTip(btnBuscar, "Realizar Busqueda (F8)");
            ObtenerGrupo(((InicioSesion)((Grupo)this.Owner).MdiParent.Owner).Sesion, this.txtDescripcion.Text);
            gvBusquedaGrupo.ReadOnly = false;
            
            
        }
        #region Evento Teclas de Función.
        public bool PreFilterMessage(ref Message poMensajeWindows)
        {
            Keys loCodigo = (Keys)(int)poMensajeWindows.WParam & Keys.KeyCode;

            if (loCodigo == Keys.Snapshot)
            {
                Clipboard.Clear();
                return true;
            }

            return false;
        }

        protected override bool ProcessCmdKey(ref Message poMensajeWindows, Keys poOpcion)
        {
            switch (poOpcion)
            {
                case Keys.F7:
                    txtDescripcion.Text = string.Empty;
                    return true;

                case Keys.F8:

                    IEnlace ResultadosBusquedaGrupo = this.Owner as Grupo;
                    if (ResultadosBusquedaGrupo != null)
                    {
                        ObtenerGrupo(((InicioSesion)((Grupo)this.Owner).MdiParent.Owner).Sesion, this.txtDescripcion.Text);
                    }
                    return true;

                default:
                    return base.ProcessCmdKey(ref poMensajeWindows, poOpcion);
            }
        }

        #endregion

        private void ObtenerGrupo(Sesion poSesion, string psDescripcion)
        {
            Reglas.Permiso ObtenerGrupo = new Reglas.Permiso();
            DataTable loResultado = ObtenerGrupo.BuscarGrupo(poSesion, psDescripcion);
            gvBusquedaGrupo.DataSource = loResultado;

        }

        private void gvBusquedaGrupo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow loFila = this.gvBusquedaGrupo.Rows[e.RowIndex];
                IEnlace DatosGrupo = this.Owner as Grupo;
                if (DatosGrupo != null)
                {
                    DatosGrupo.DatosBuscarGrupo(loFila.Cells["CLAVE"].Value.ToString(), loFila.Cells["DESCRIPCION"].Value.ToString(), loFila.Cells["STATUS"].Value.ToString());
                    this.Dispose();
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ObtenerGrupo(((InicioSesion)((Grupo)this.Owner).MdiParent.Owner).Sesion, this.txtDescripcion.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



    }
}
