using System;
using System.Windows.Forms;

namespace Dapesa.Ventas.Telemarketing.IU.LayoutContacto
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

		private void tsmiBatch_Click(object sender, EventArgs e)
		{

			if (!Dapesa.Comun.Utilerias.IU.ExisteFormulario(typeof(Batch), this.MdiChildren))
			{
				Batch loGestor = new Batch()
				{
					ControlBox = true,
					FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable,
					MdiParent = this,
					MinimizeBox = true,
					ShowIcon = true,
					StartPosition = FormStartPosition.CenterScreen,
					WindowState = FormWindowState.Normal
				};

				loGestor.Show();
			}
		}

		private void tsmiManual_Click(object sender, EventArgs e)
		{

			if (!Dapesa.Comun.Utilerias.IU.ExisteFormulario(typeof(Manual), this.MdiChildren))
			{
				Manual loManual = new Manual()
				{
					ControlBox = true,
					FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable,
					MdiParent = this,
					MinimizeBox = true,
					ShowIcon = true,
					StartPosition = FormStartPosition.CenterScreen,
					WindowState = FormWindowState.Normal
				};

				loManual.Show();
			}
		}

		private void tsmiSalir_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#endregion
	}
}
