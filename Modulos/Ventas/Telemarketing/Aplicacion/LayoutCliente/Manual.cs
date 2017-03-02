using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Dapesa.Ventas.Telemarketing.IU.LayoutCliente
{
	public partial class Manual : Form
	{
		public Manual()
		{
			InitializeComponent();
			#region Inicializar componentes

			ttInformacion.SetToolTip(btnRelacionar, "Relacionar");
			ttInformacion.SetToolTip(btnSuprimir, "Suprimir relación");

			#endregion
		}

		#region Eventos

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnRelacionar_Click(object sender, System.EventArgs e)
		{
			this.ProcesarAsignaciones();
		}

		private void btnSuprimir_Click(object sender, EventArgs e)
		{
			this.ProcesarSupresiones();
		}

		private void cbClientesAsignar_CheckedChanged(object sender, EventArgs e)
		{
			this.SeleccionarClientes(clbClientesAsignar, ((CheckBox)sender).Checked);
		}

		private void cbClientesSuprimir_CheckedChanged(object sender, EventArgs e)
		{
			this.SeleccionarClientes(clbClientesSuprimir, ((CheckBox)sender).Checked);
		}

		private void cbDestino_SelectedIndexChanged(object sender, EventArgs e)
		{
			string lsClaveTelemarketing = ((ComboBox)sender).SelectedValue.ToString();

			btnRelacionar.Enabled = !string.IsNullOrEmpty(lsClaveTelemarketing);
		}

		private void cbOrigen_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string lsClaveTelemarketing = ((ComboBox)sender).SelectedValue.ToString();

			this.ObtenerVendedores(cbVendedorAsignar, lsClaveTelemarketing, false);
			this.ObtenerTelemarketing(cbDestino, lsClaveTelemarketing);
			this.HabilitarControles(
				!string.IsNullOrEmpty(lsClaveTelemarketing),
				cbDestino, cbClientesAsignar, cbVendedorAsignar, clbClientesAsignar
			);
		}

		private void cbTelemarketing_SelectedIndexChanged(object sender, EventArgs e)
		{
			string lsClaveTelemarketing = ((ComboBox)sender).SelectedValue.ToString();

			this.ObtenerVendedores(cbVendedorSuprimir, lsClaveTelemarketing, true);
			this.HabilitarControles(
				!string.IsNullOrEmpty(lsClaveTelemarketing),
				btnSuprimir, cbClientesSuprimir, cbVendedorSuprimir, clbClientesSuprimir
			);
		}

		private void cbVendedorAsignar_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string lsClaveVendedor = ((ComboBox)sender).SelectedValue.ToString();

			this.ObtenerClientes(clbClientesAsignar, cbOrigen.SelectedValue.ToString(), lsClaveVendedor, false);
			this.SeleccionarClientes(clbClientesAsignar, true);
			cbClientesAsignar.Checked = true;
		}

		private void cbVendedorSuprimir_SelectedIndexChanged(object sender, EventArgs e)
		{
			string lsClaveVendedor = ((ComboBox)sender).SelectedValue.ToString();

			this.ObtenerClientes(clbClientesSuprimir, cbTelemarketing.SelectedValue.ToString(), lsClaveVendedor, true);
			this.SeleccionarClientes(clbClientesSuprimir, true);
			cbClientesSuprimir.Checked = true;
		}

		private void Manual_Load(object sender, System.EventArgs e)
		{
			this.ObtenerTelemarketing(cbOrigen, string.Empty);
			this.ObtenerTelemarketing(cbTelemarketing, string.Empty);
			cbOrigen.Focus();
		}

		#endregion

		#region Metodos

		private void HabilitarControles(bool pbIndicador, params Control[] poControles)
		{
			
			foreach(Control poControl in poControles)
				poControl.Enabled = pbIndicador;
		}

		private void ProcesarAsignaciones()
		{
		
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				Reglas.LayoutCliente loLayout = new Reglas.LayoutCliente();

				if (loLayout.Asignar(
					((InicioSesion)this.MdiParent.Owner).Sesion, cbDestino.SelectedValue.ToString(), clbClientesAsignar.CheckedItems.OfType<DataRowView>().ToList()
				))
					MessageBox.Show("Información procesada satisfactoriamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

		private void ProcesarSupresiones()
		{
			
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				Reglas.LayoutCliente loLayout = new Reglas.LayoutCliente();

				if (loLayout.Suprimir(
					((InicioSesion)this.MdiParent.Owner).Sesion, cbTelemarketing.SelectedValue.ToString(), clbClientesSuprimir.CheckedItems.OfType<DataRowView>().ToList()
				))
					MessageBox.Show("Información procesada satisfactoriamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

		private void ObtenerClientes(CheckedListBox poCombo, string psClaveTelemarketing, string psClaveVendedor, bool pbAsignacionTemporal)
		{

			try
			{
				Cursor.Current = Cursors.WaitCursor;
				Reglas.LayoutCliente loLayout = new Reglas.LayoutCliente();

				poCombo.DataSource = loLayout.ObtenerClientes(
					((InicioSesion)this.MdiParent.Owner).Sesion, psClaveTelemarketing, psClaveVendedor, pbAsignacionTemporal
				);
				poCombo.DisplayMember = "DESCRIPCION";
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

		private void ObtenerTelemarketing(ComboBox poCombo, string psClaveTelemarketingExcluir)
		{

			try
			{
				Cursor.Current = Cursors.WaitCursor;
				Reglas.LayoutCliente loLayout = new Reglas.LayoutCliente();

				poCombo.DataSource = loLayout.ObtenerTelemarketing(
					((InicioSesion)this.MdiParent.Owner).Sesion, psClaveTelemarketingExcluir
				);
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

		private void ObtenerVendedores(ComboBox poCombo, string psClaveTelemarketing, bool pbAsignacionTemporal)
		{

			try
			{
				Cursor.Current = Cursors.WaitCursor;
				Reglas.LayoutCliente loLayout = new Reglas.LayoutCliente();

				poCombo.DataSource = loLayout.ObtenerVendedores(
					((InicioSesion)this.MdiParent.Owner).Sesion, psClaveTelemarketing, pbAsignacionTemporal
				);
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

		private void SeleccionarClientes(CheckedListBox poCheckedList, bool pbIndicador)
		{

			for (int lnIndice = 0; lnIndice < poCheckedList.Items.Count; lnIndice++)
				poCheckedList.SetItemChecked(lnIndice, pbIndicador);
		}

		#endregion
	}
}
