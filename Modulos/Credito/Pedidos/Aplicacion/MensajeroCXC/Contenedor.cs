using System;
using System.Windows.Forms;

namespace Dapesa.Credito.Pedidos.IU.MensajeroCXC
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
            
            Contenido loMensajero = new Contenido()
            {
                ControlBox = true,
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable,
                MdiParent = this,
                MinimizeBox = true,
                ShowIcon = true,
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal
            };

            //notifyIcon.BalloonTipTitle = "MENSAJERO CXC";
            //notifyIcon.BalloonTipText = "Aplicacion oculta";
            //notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            //notifyIcon.Visible = true;
            //notifyIcon.ShowBalloonTip(3000);

            loMensajero.Show();
        }

        #endregion
    }
}

