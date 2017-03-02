using System;
using System.Windows.Forms;

namespace Dapesa.Credito.Documentos.IU.Gestor
{
	public partial class Agrupador : Form
	{
		#region Constructor

		public Agrupador()
		{
			InitializeComponent();
			ttInformacion.SetToolTip(btnSeleccionarCarpeta, "Examinar...");
			ttInformacion.SetToolTip(btnAgrupar, "Agrupar documentos");
		}

		#endregion

		#region Eventos

		private void btnSeleccionarCarpeta_Click(object sender, EventArgs e)
		{
			DialogResult result = fbdSeleccionarCarpeta.ShowDialog();

			if (result == DialogResult.OK)
			{
				txtCarpeta.Text = fbdSeleccionarCarpeta.SelectedPath;
			}
		}

		private void btnAgrupar_Click(object sender, EventArgs e)
		{
			this.AgruparDocumentos();
		}

		#endregion

		#region Metodos

		private void AgruparDocumentos()
		{

			if (string.IsNullOrEmpty(txtCarpeta.Text))
			{
				MessageBox.Show("Debe seleccionar una carpeta origen", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			Cursor.Current = Cursors.WaitCursor;
			this.Enabled = false;

			try
			{
				Reglas.Documentos loDocumento = new Reglas.Documentos();
				bool lbAgrupamiento = false;

				loDocumento.DocumentosRecuperados += this.documentosRecuperados_Evento;
				loDocumento.DocumentoProcesado += this.documentoProcesado_Evento;

				if (rbFactura.Checked)
					lbAgrupamiento = loDocumento.AgruparDocumentos(((InicioSesion)this.MdiParent.Owner).Sesion, Comun.Definiciones.TipoDocumento.Factura, txtCliente.Text, txtCarpeta.Text, dtpFechaInicio.Value, dtpFechaFin.Value);
				else if (rbNotaCargo.Checked)
					lbAgrupamiento = loDocumento.AgruparDocumentos(((InicioSesion)this.MdiParent.Owner).Sesion, Comun.Definiciones.TipoDocumento.NotaCargo, txtCliente.Text, txtCarpeta.Text, dtpFechaInicio.Value, dtpFechaFin.Value);
				else if (rbNotaCredito.Checked)
					lbAgrupamiento = loDocumento.AgruparDocumentos(((InicioSesion)this.MdiParent.Owner).Sesion, Comun.Definiciones.TipoDocumento.NotaCredito, txtCliente.Text, txtCarpeta.Text, dtpFechaInicio.Value, dtpFechaFin.Value);

				if (lbAgrupamiento)
					MessageBox.Show("Agrupamiento terminado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
				this.Enabled = true;
			}
		}

		private void documentoProcesado_Evento(object sender, EventArgs e)
		{
			pbBarraProgreso.PerformStep();
		}

		private void documentosRecuperados_Evento(object sender, EventArgs e)
		{
			pbBarraProgreso.Minimum = 1;
			pbBarraProgreso.Maximum = ((Reglas.Documentos)sender).TotalDocumentosRecuperados;
			pbBarraProgreso.Value = 1;
			pbBarraProgreso.Step = 1;
		}
	
		#endregion
	}
}
