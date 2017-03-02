using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Dapesa.Ventas.Telemarketing.IU.Itinerario
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

		private void Contenedor_FormClosing(object sender, FormClosingEventArgs e)
		{

			if ((DataTable)((Contenido)this.ActiveMdiChild).CambiosPorAplicar != null &&
				 DialogResult.Cancel == MessageBox.Show("Existen cambios en el itinerario sin guardar.\n\rSi continúa con el cierre de la ventana principal, perderá los cambios realizados.",
					"Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
				) e.Cancel = true;
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
			tsslUltimaActualizacion.Text += DateTime.Now.ToString("dddd, dd/MM/yyyy HH:mm:ss").ToUpper();
			loContenido.Show();
		}

		private void tsslCatalogos_Click(object sender, EventArgs e)
		{
			string lsUbicacion = ConfigurationManager.AppSettings["CAT" + ((InicioSesion)this.Owner).Sesion.Usuario.Sucursal[0].Clave];
			
			this.AbrirUbicacionCatalogos(lsUbicacion);
		}

		#endregion

		#region Metodos

		private void AbrirUbicacionCatalogos(string psUbicacion)
		{

			try
			{
				Process.Start("explorer.exe", psUbicacion);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region Propiedades

		internal string Semana
		{
			set
			{
				tsslSemana.Text = value;
			}
		}

		internal string UltimaActualizacion
		{
			set
			{
				tsslUltimaActualizacion.Text = value;
			}
		}

		#endregion
	}
}
