using System;
using System.Configuration;
using System.Windows.Forms;

namespace Dapesa.Ventas.Telemarketing.IU.LayoutContacto
{
	public partial class Batch : Form
	{
		public Batch()
		{
			InitializeComponent();
			#region Inicializar componentes

			ofdArchivo.RestoreDirectory = true;
			ofdArchivo.Filter = "CSV (delimitado por comas) (*.csv)|*.csv";
			ttInformacion.SetToolTip(btnCargar, "Cargar información (F5)");

			#endregion
		}

		#region Eventos

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnCargar_Click(object sender, EventArgs e)
		{
			this.CargarInformacion();
		}

		private void btnExaminar_Click(object sender, EventArgs e)
		{

			if (ofdArchivo.ShowDialog() == DialogResult.OK)
			{
				txtArchivo.Text = ofdArchivo.FileName;
				btnCargar.Enabled = true;
			}
		}

		#endregion

		#region Metodos

		private void CargarInformacion()
		{

			try
			{
				Cursor.Current = Cursors.WaitCursor;
				Reglas.LayoutContacto loLayout = new Reglas.LayoutContacto();

				if (loLayout.Cargar(
					((InicioSesion)this.MdiParent.Owner).Sesion, ofdArchivo.FileName, int.Parse(ConfigurationManager.AppSettings["NumeroLineasIgnorar"])
				)) {
					MessageBox.Show("Información procesada satisfactoriamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtArchivo.Text = string.Empty;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		protected override bool ProcessCmdKey(ref Message psMensaje, Keys poOpcion)
		{

			switch (poOpcion)
			{
				case Keys.F5:
					this.CargarInformacion();
					return true;
				default:
					return base.ProcessCmdKey(ref psMensaje, poOpcion);
			}
		}

		#endregion
	}
}
