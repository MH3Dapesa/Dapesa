using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Credito.Clientes.IU.LayoutCliente
{
    public partial class Temporal : Form
    {
        public Temporal()
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
            bool loEnabled = false;
            if (!string.IsNullOrEmpty(cbDestino.SelectedValue.ToString()))
            {
                if (int.Parse(cbDestino.SelectedValue.ToString()) > 0)
                {
                    loEnabled = ((cbGestorAsignar.Items.Count > 0) ? true : false);
                }
            }
            btnRelacionar.Enabled = loEnabled;
        }

        private void cbOrigen_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string lsClaveAuxiliar = ((ComboBox)sender).SelectedValue.ToString();

            this.ObtenerGestores(cbGestorAsignar, lsClaveAuxiliar);
            this.ObtenerAuxiliarCXC(cbDestino, lsClaveAuxiliar,int.Parse(cbSucursal.SelectedValue.ToString()));
            this.HabilitarControles(
                ((cbOrigen.Items.Count > 0 && cbGestorAsignar.Items.Count > 0) ? ((int.Parse(cbOrigen.SelectedValue.ToString()) > 0) ? true : false) : false),
                 cbDestino, cbClientesAsignar, cbGestorAsignar, clbClientesAsignar
            );
        }

        private void cbGestorAsignar_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string lsClaveGestor = ((ComboBox)sender).SelectedValue.ToString();

            this.ObtenerClientes(clbClientesAsignar, int.Parse(cbOrigen.SelectedValue.ToString()), int.Parse(lsClaveGestor));
            this.SeleccionarClientes(clbClientesAsignar, true);
            cbClientesAsignar.Checked = true;
            this.HabilitarControles(
                ((clbClientesAsignar.Items.Count > 0) ? true : false),
                cbClientesAsignar, cbGestorAsignar, clbClientesAsignar
            );
        }

        private void cbAuxiliar_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string lsClaveAuxiliar = ((ComboBox)sender).SelectedValue.ToString();

            this.ObtenerGestoresTemporal(cbGestorSuprimir, lsClaveAuxiliar);
            this.HabilitarControles(
                ((cbAuxiliar.Items.Count > 0 && cbGestorSuprimir.Items.Count > 0) ? true : false),
                btnSuprimir, cbClientesSuprimir, cbGestorSuprimir, clbClientesSuprimir
            );
        }

        private void cbGestorSuprimir_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lsClaveGestor = ((ComboBox)sender).SelectedValue.ToString();

            this.ObtenerClientesTemporal(clbClientesSuprimir, int.Parse(cbAuxiliar.SelectedValue.ToString()), int.Parse(lsClaveGestor));
            this.SeleccionarClientes(clbClientesSuprimir, true);
            cbClientesSuprimir.Checked = true;
            this.HabilitarControles(
                ((clbClientesSuprimir.Items.Count > 0) ? true : false),
                btnSuprimir, cbClientesSuprimir, cbGestorSuprimir, clbClientesSuprimir
            );
        }

        private void cbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarControles();
            cbOrigen.Focus();
        }

        private void Temporal_Load(object sender, System.EventArgs e)
        {
            ObtenenerSucursales();
        }

        #endregion

        #region Metodos

        private void ActualizarControles()
        {
            this.ObtenerAuxiliarCXC(cbOrigen, string.Empty, int.Parse(cbSucursal.SelectedValue.ToString()));
            this.ObtenerAuxiliarCXCTemporal(cbAuxiliar, int.Parse(cbSucursal.SelectedValue.ToString()));
        }

        private void ObtenenerSucursales()
        {
            Dapesa.Credito.Clientes.Reglas.LayoutCliente loObtenerSucursales = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();
            cbSucursal.DataSource = loObtenerSucursales.ObtenerSucursal(((InicioSesion)this.MdiParent.Owner).Sesion);
        }

        private void HabilitarControles(bool pbIndicador, params Control[] poControles)
        {

            foreach (Control poControl in poControles)
                poControl.Enabled = pbIndicador;
        }

        private void ProcesarAsignaciones()
        {
            if (clbClientesAsignar.CheckedItems.Count > 0)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                    if (loLayout.Asignar(
                        ((InicioSesion)this.MdiParent.Owner).Sesion, cbDestino.SelectedValue.ToString(), clbClientesAsignar.CheckedItems.OfType<DataRowView>().ToList(), true
                    ))
                    {
                        MessageBox.Show("Información procesada satisfactoriamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarControles();
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
            else
            {
                MessageBox.Show("Debe seleccionar por lo menos un cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ProcesarSupresiones()
        {
            if (clbClientesSuprimir.CheckedItems.Count > 0)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                    if (loLayout.Suprimir(
                        ((InicioSesion)this.MdiParent.Owner).Sesion, cbAuxiliar.SelectedValue.ToString(), clbClientesSuprimir.CheckedItems.OfType<DataRowView>().ToList(), true
                    ))
                    {
                        MessageBox.Show("Información procesada satisfactoriamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarControles();
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
            else
            {
                MessageBox.Show("Debe seleccionar por lo menos un cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ObtenerClientes(CheckedListBox poCombo, int psClaveAuxiliar, int psClaveGestor)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                poCombo.DataSource = loLayout.ObtenerClientesSuprimir(
                    ((InicioSesion)this.MdiParent.Owner).Sesion, psClaveAuxiliar, psClaveGestor
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

        private void ObtenerAuxiliarCXC(ComboBox poCombo, string psClaveAuxiliarExcluir, int pnClaveSucursal)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                poCombo.DataSource = loLayout.ObtenerAuxiliarCXC(
                    ((InicioSesion)this.MdiParent.Owner).Sesion, psClaveAuxiliarExcluir, pnClaveSucursal
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

        private void ObtenerAuxiliarCXCTemporal(ComboBox poCombo, int pnClaveSucursal)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                poCombo.DataSource = loLayout.ObtenerAuxiliarCXCTemporal(
                    ((InicioSesion)this.MdiParent.Owner).Sesion, pnClaveSucursal
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

        private void ObtenerGestores(ComboBox poCombo, string psClaveAuxiliar)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                poCombo.DataSource = loLayout.ObtenerGestoresSuprimir(
                    ((InicioSesion)this.MdiParent.Owner).Sesion, int.Parse(psClaveAuxiliar)
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

        private void ObtenerGestoresTemporal(ComboBox poCombo, string psClaveAuxiliar)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                poCombo.DataSource = loLayout.ObtenerGestoresTemporal(
                    ((InicioSesion)this.MdiParent.Owner).Sesion, int.Parse(psClaveAuxiliar)
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

        private void ObtenerClientesTemporal(CheckedListBox poCombo, int psClaveAuxiliar, int psClaveGestor)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                poCombo.DataSource = loLayout.ObtenerClientesTemporal(
                    ((InicioSesion)this.MdiParent.Owner).Sesion, psClaveAuxiliar, psClaveGestor
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

        #endregion
    }
}
