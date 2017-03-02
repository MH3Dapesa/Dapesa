using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Contabilidad.IU.Revaluacion
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


            Contenido loContenido = new Contenido()
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
    }
}

