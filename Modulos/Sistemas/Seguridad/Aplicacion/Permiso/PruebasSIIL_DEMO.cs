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
    public partial class PruebasSIIL_DEMO : Form
    {
        public PruebasSIIL_DEMO()
        {
            InitializeComponent();
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            Reglas.Permiso ObtenerGrupo = new Reglas.Permiso();
            DataTable loResultado = ObtenerGrupo.ObtenerPrueba(((InicioSesion)this.MdiParent.Owner).Sesion);
            gvPrueba.DataSource = loResultado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reglas.Permiso ObtenerGrupo = new Reglas.Permiso();
            if (ObtenerGrupo.Eliminar(((InicioSesion)this.MdiParent.Owner).Sesion, 1))
            {
                MessageBox.Show("SI", "RESPUESTA", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("NO", "RESPUESTA", MessageBoxButtons.OK);
            };

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reglas.Permiso ObtenerGrupo = new Reglas.Permiso();
            if (ObtenerGrupo.Guardar(((InicioSesion)this.MdiParent.Owner).Sesion))
            {
                MessageBox.Show("SI", "RESPUESTA", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("NO", "RESPUESTA", MessageBoxButtons.OK);
            };
        }
    }
}
