using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Dapesa.Sistemas.Seguridad.Reglas;


namespace Dapesa.Sistemas.Seguridad.UI.Permiso
{
    public partial class Grupo : Form, IEnlace
    {
        public Grupo()
        {
            InitializeComponent();

        }

        #region Load Ventana Grupo
        private void Grupo_Shown(object sender, EventArgs e)
        {
            txtDescripcion.SelectAll();
            txtDescripcion.Focus();
            cbEstado.SelectedIndex = 0;
        }

        private void Grupo_Load(object sender, EventArgs e)
        {
            //this.ObtenerPersonal(cbPersonal);
        }

        #endregion

        #region Evento Teclas de Función.
        public bool PreFilterMessage(ref Message poMensajeWindows)
        {
            Keys loCodigo = (Keys)(int)poMensajeWindows.WParam & Keys.KeyCode;

            if (loCodigo == Keys.Snapshot)
            {
                Clipboard.Clear();
                return true;
            }

            return false;
        }

        protected override bool ProcessCmdKey(ref Message poMensajeWindows, Keys poOpcion)
        {
            switch (poOpcion)
            {
                case Keys.F7:
                    LimpiarComponentes();
                    return true;
                case Keys.F8:
                    txtClave.Enabled = false;
                    //this.GenerarInforme(txtCliente.Text, dtpAnio.Value.Year);
                    return true;
                default:
                    return base.ProcessCmdKey(ref poMensajeWindows, poOpcion);
            }
        }

        #endregion

        #region Eventos

        private void btnBuscarGrupo_Click(object sender, EventArgs e)
        {
            BuscarGrupo loMdi = new BuscarGrupo();
            loMdi.Owner = this;
            loMdi.ShowDialog();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if (txtDescripcion.TextLength > 0)
            {
                btnGuardar.Enabled = true;
                cbEstado.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
                cbEstado.Enabled = false;
                LimpiarComponentes();
            }
        }

        //private void cbPersonal_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string lsClavePersonal = ((ComboBox)sender).SelectedValue.ToString();

        //    this.ObtenerGrupo(cbGrupo);
        //    this.HabilitarControles(
        //        !string.IsNullOrEmpty(lsClavePersonal),
        //         cbGrupo
        //    );
        //    cbGrupo.Focus();
        //}

        private void cbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ObtenerAplicacion(cbAplicacion);
            string lsClaveGrupo = ((ComboBox)sender).SelectedValue.ToString();
            this.HabilitarControles(
                !string.IsNullOrEmpty(lsClaveGrupo),
                 cbAplicacion, gvPermisos
            );
            cbAplicacion.Focus();
        }

        #endregion

        #region Metodos

        //Metodo Obtiener Grupo y llenar componentes, desde formulario BuscarGrupo
        public void DatosBuscarGrupo(string liClave, string lsDescripcion, string lsEstado)
        {
            this.txtClave.Text = liClave;
            this.txtDescripcion.Text = lsDescripcion;
            this.cbEstado.SelectedItem = lsEstado;
        }

        private void HabilitarControles(bool pbIndicador, params Control[] poControles)
        {

            foreach (Control poControl in poControles)
                poControl.Enabled = pbIndicador;
        }

        //private void ObtenerPersonal(ComboBox poCombo)
        //{

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;
        //        Reglas.Permiso loPersonal = new Reglas.Permiso();

        //        poCombo.DataSource = loPersonal.BuscarPersonal(
        //            ((InicioSesion)this.MdiParent.Owner).Sesion
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        Cursor.Current = Cursors.Default;
        //    }
        //}

        private void ObtenerGrupo(ComboBox poCombo)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Reglas.Permiso loGrupo = new Reglas.Permiso();

                poCombo.DataSource = loGrupo.ObtenerGrupo(
                    ((InicioSesion)this.MdiParent.Owner).Sesion
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

        private void ObtenerAplicacion(ComboBox poCombo)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Reglas.Permiso loAplicacion = new Reglas.Permiso();

                poCombo.DataSource = loAplicacion.ObtenerAplicacion(
                    ((InicioSesion)this.MdiParent.Owner).Sesion
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

        private void LimpiarComponentes()
        {
            txtClave.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            cbEstado.SelectedIndex = 0;
            cbEstado.Enabled = false;
        }

        #endregion

        
    }
}
