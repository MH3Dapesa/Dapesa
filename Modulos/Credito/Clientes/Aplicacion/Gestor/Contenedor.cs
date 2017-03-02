using System;
using System.Windows.Forms;

namespace Dapesa.Credito.Clientes.IU.Gestor
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
			Contenido loContenido = new Contenido()	{
				ControlBox = false,
				FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable,
				MdiParent = this,
				MinimizeBox = false,
				ShowIcon = true,
				StartPosition = FormStartPosition.CenterScreen,
				WindowState = FormWindowState.Normal
			};

			tsslCredenciales.Text += ((InicioSesion)this.Owner).Sesion.Usuario.Nombre.ToUpper();
			tsslSucursal.Text += ((InicioSesion)this.Owner).Sesion.Usuario.Sucursal[0].Descripcion.ToUpper();
			loContenido.Show();
		}

		#endregion
	}
}
