using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Credito.Clientes.IU.LayoutCliente
{
    public partial class Permanente : Form
    {
        public Permanente()
        {
            InitializeComponent();
            #region Inicializar componentes

            ttInformacion.SetToolTip(btnRelacionarPendiente, "Relacionar");
            ttInformacion.SetToolTip(btnRelacionar, "Relacionar");
            ttInformacion.SetToolTip(btnRelacionSuprimir, "Suprimir relación");

            #endregion
        }

        #region Eventos

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnRelacionarPendiente_Click(object sender, EventArgs e)
        {
            this.ProcesarAsignacionesPendientes();
        }

        private void cbAuxiliar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lnClaveAuxiliar = cbAuxiliar.Items.Count;
            if (lnClaveAuxiliar > 0 && !string.IsNullOrEmpty(cbAuxiliar.SelectedValue.ToString()))
                this.HabilitarControles(
                    ((int.Parse(cbAuxiliar.SelectedValue.ToString())) < 0) ? false : true,
                   btnRelacionarPendiente, cbClientesSinAsignar, cbGestoresSinAsignar, clbClientesSinAsignar
                );
        }

        private void cbGestoresSinAsignar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string psClaveGestor = cbGestoresSinAsignar.SelectedValue.ToString();

            this.ObtenerClientesSinAsignar(clbClientesSinAsignar, int.Parse(psClaveGestor), int.Parse(cbSucursal.SelectedValue.ToString()));
            this.SeleccionarClientes(clbClientesSinAsignar, true);
            cbClientesSinAsignar.Checked = true;

            if (cbGestoresSinAsignar.Items.Count > 0 && clbClientesSinAsignar.Items.Count > 0 && (int.Parse(cbAuxiliar.SelectedValue.ToString())) > 0)
            {
                this.HabilitarControles(
                   !string.IsNullOrEmpty(psClaveGestor),
                   btnRelacionarPendiente, cbClientesSinAsignar, cbGestoresSinAsignar, clbClientesSinAsignar
                );
            }
        }

        private void cbClientesSinAsignar_CheckedChanged(object sender, EventArgs e)
        {
            this.SeleccionarClientes(clbClientesSinAsignar, ((CheckBox)sender).Checked);
        }

        private void cbOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lnClaveAuxiliar = cbOrigen.Items.Count;
            if (lnClaveAuxiliar > 0 && !string.IsNullOrEmpty(cbOrigen.SelectedValue.ToString()))
                this.HabilitarControles(
                    ((int.Parse(cbOrigen.SelectedValue.ToString())) < 0) ? false : true,
                   btnRelacionar, cbClientesAsignar, cbGestoresAsignar, clbClientesAsignar
                );
        }

        private void cbGestoresAsignar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string psClaveGestor = cbGestoresAsignar.SelectedValue.ToString();

            this.ObtenerClientes(clbClientesAsignar, int.Parse(psClaveGestor), int.Parse(cbSucursal.SelectedValue.ToString()));
            this.SeleccionarClientes(clbClientesAsignar, true);
            cbClientesAsignar.Checked = true;

            if (cbGestoresAsignar.Items.Count > 0 && clbClientesAsignar.Items.Count > 0 && (int.Parse(cbOrigen.SelectedValue.ToString())) > 0)
            {
                this.HabilitarControles(
                   !string.IsNullOrEmpty(psClaveGestor),
                   btnRelacionar, cbClientesAsignar, cbGestoresAsignar, clbClientesAsignar
                );
            }
        }

        private void btnRelacionar_Click(object sender, EventArgs e)
        {
            this.ProcesarAsignaciones();
        }

        private void cbClientesAsignar_CheckedChanged(object sender, EventArgs e)
        {
            this.SeleccionarClientes(clbClientesAsignar, ((CheckBox)sender).Checked);
        }

        private void cbAuxiliarSuprimir_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ObtenerGestoresSuprimir(cbGestorSuprimir);
            this.SeleccionarClientes(clbClientesSuprimir, true);
            cbClienteSuprimir.Checked = true;
            this.HabilitarControles(
                (cbGestorSuprimir.Items.Count > 0) ? true : false,
               btnRelacionSuprimir, cbClienteSuprimir, cbGestorSuprimir, clbClientesSuprimir
            );
        }

        private void cbGestorSuprimir_SelectedIndexChanged(object sender, EventArgs e)
        {
            string psClaveGestor = cbGestorSuprimir.SelectedValue.ToString();

            this.ObtenerClientesSuprimir(clbClientesSuprimir, int.Parse(psClaveGestor));
            this.SeleccionarClientes(clbClientesSuprimir, true);
            cbClientesAsignar.Checked = true;

            this.HabilitarControles(
               (clbClientesSuprimir.Items.Count > 0) ? true : false,
               btnRelacionSuprimir, cbClienteSuprimir, cbGestorSuprimir, clbClientesSuprimir
            );
        }

        private void cbClienteSuprimir_CheckedChanged(object sender, EventArgs e)
        {
            this.SeleccionarClientes(clbClientesSuprimir, ((CheckBox)sender).Checked);
        }

        private void btnRelacionSuprimir_Click(object sender, EventArgs e)
        {
            SuprimirAsignaciones();
        }

        private void cbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarControles();
            cbAuxiliar.Focus();
        }

        private void Permanente_Load(object sender, System.EventArgs e)
        {
            ObtenerSucursal();
        }

        #endregion

        #region Metodos
        private void ActualizarControles()
        {
            this.ObtenerAuxiliarCXC(cbAuxiliar, int.Parse(cbSucursal.SelectedValue.ToString()));
            this.ObtenerAuxiliarCXC(cbOrigen, int.Parse(cbSucursal.SelectedValue.ToString()));
            this.ObtenerAuxiliarCXCSuprimir(cbAuxiliarSuprimir, int.Parse(cbSucursal.SelectedValue.ToString()));
            this.ObtenerGestoresSinAsignar(cbGestoresSinAsignar, int.Parse(cbSucursal.SelectedValue.ToString()));
            this.ObtenerGestores(cbGestoresAsignar, int.Parse(cbSucursal.SelectedValue.ToString()));
            //this.ObtenerClientes(clbClientesAsignar, (int)cbGestoresAsignar.SelectedValue);
            string lnGestorSinAsignar = (cbGestoresSinAsignar.Items.Count == 0) ? "-1" : cbGestoresSinAsignar.SelectedValue.ToString();
            this.ObtenerClientesSinAsignar(clbClientesSinAsignar, int.Parse(lnGestorSinAsignar), int.Parse(cbSucursal.SelectedValue.ToString()));
        }

        private void ObtenerSucursal()
        {
            Dapesa.Credito.Clientes.Reglas.LayoutCliente loObtenerSucursal = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();
            cbSucursal.DataSource = loObtenerSucursal.ObtenerSucursal(((InicioSesion)this.MdiParent.Owner).Sesion);
        }

        private void HabilitarControles(bool pbIndicador, params Control[] poControles)
        {
            foreach (Control poControl in poControles)
                poControl.Enabled = pbIndicador;
        }

        private void ProcesarAsignacionesPendientes()
        {
            try
            {
                if (clbClientesSinAsignar.CheckedItems.Count > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                    if (loLayout.Asignar(
                        ((InicioSesion)this.MdiParent.Owner).Sesion, cbAuxiliar.SelectedValue.ToString(), clbClientesSinAsignar.CheckedItems.OfType<DataRowView>().ToList(), false
                    ))
                    {
                        MessageBox.Show("Información procesada satisfactoriamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarControles();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar por lo menos un cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ProcesarAsignaciones()
        {
            try
            {
                if (clbClientesAsignar.CheckedItems.Count > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                    if (loLayout.Asignar(
                        ((InicioSesion)this.MdiParent.Owner).Sesion, cbOrigen.SelectedValue.ToString(), clbClientesAsignar.CheckedItems.OfType<DataRowView>().ToList(), false
                    ))
                    {
                        MessageBox.Show("Información procesada satisfactoriamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarControles();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar por lo menos un cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void SuprimirAsignaciones()
        {
            try
            {
                if (clbClientesSuprimir.CheckedItems.Count > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                    if (loLayout.Suprimir(
                        ((InicioSesion)this.MdiParent.Owner).Sesion, cbAuxiliarSuprimir.SelectedValue.ToString(), clbClientesSuprimir.CheckedItems.OfType<DataRowView>().ToList(), false
                    ))
                    {
                        MessageBox.Show("Información procesada satisfactoriamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarControles();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar por lo menos un cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ObtenerClientesSinAsignar(CheckedListBox poCombo, int pnCveGestor, int pnClaveSucursal)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                poCombo.DataSource = loLayout.ObtenerClientesNoAsignados(
                    ((InicioSesion)this.MdiParent.Owner).Sesion, pnCveGestor, pnClaveSucursal
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

        private void ObtenerAuxiliarCXC(ComboBox poCombo, int pnClaveSucursal)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                poCombo.DataSource = loLayout.ObtenerAuxiliarCXC(
                    ((InicioSesion)this.MdiParent.Owner).Sesion, string.Empty, pnClaveSucursal
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

        private void ObtenerGestoresSinAsignar(ComboBox poCombo, int pnClaveSucursal)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                poCombo.DataSource = loLayout.ObtenerGestoresNoAsignados(
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

        private void ObtenerGestores(ComboBox poCombo, int pnClaveSucursal)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                poCombo.DataSource = loLayout.ObtenerGestores(
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

        private void ObtenerClientes(CheckedListBox poCombo, int pnCveGestor, int pnClaveSucursal)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                poCombo.DataSource = loLayout.ObtenerClientes(
                    ((InicioSesion)this.MdiParent.Owner).Sesion, pnCveGestor, pnClaveSucursal
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

        private void ObtenerAuxiliarCXCSuprimir(ComboBox poCombo, int pnClaveSucursal)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                poCombo.DataSource = loLayout.ObtenerAuxiliarCXCSuprimir(
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

        private void ObtenerGestoresSuprimir(ComboBox poCombo)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                poCombo.DataSource = loLayout.ObtenerGestoresSuprimir(
                    ((InicioSesion)this.MdiParent.Owner).Sesion, int.Parse(cbAuxiliarSuprimir.SelectedValue.ToString())
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

        private void ObtenerClientesSuprimir(CheckedListBox poCombo, int pnCveGestor)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Dapesa.Credito.Clientes.Reglas.LayoutCliente loLayout = new Dapesa.Credito.Clientes.Reglas.LayoutCliente();

                poCombo.DataSource = loLayout.ObtenerClientesSuprimir(
                    ((InicioSesion)this.MdiParent.Owner).Sesion, int.Parse(cbAuxiliarSuprimir.SelectedValue.ToString()), pnCveGestor
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

        private void SeleccionarClientes(CheckedListBox poCheckedList, bool pbIndicador)
        {

            for (int lnIndice = 0; lnIndice < poCheckedList.Items.Count; lnIndice++)
                poCheckedList.SetItemChecked(lnIndice, pbIndicador);
        }

        #endregion

    }
}
