using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dapesa.Credito.Documentos.IU.EnvioCancela
{
    public partial class Contenido : Form
    {
        public Contenido()
        {
            InitializeComponent();
            ttInformacion.SetToolTip(btnEnviarEmail, "Enviar notificación.");
            ttRequerido.SetToolTip(pbRequeridoFolio, "*Campo Requerido.");
            ttRequerido.SetToolTip(pbRequeridoNumero, "*Campo requerido.");
        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            if (txtFolio.Text != string.Empty)
            {
                if (txtNumero.Text != string.Empty)
                {
                    pbRequeridoNumero.Visible = false;
                    EnviarAvisoCancelacion();
                }
                else
                {
                    pbRequeridoNumero.Visible = true;    
                }
                pbRequeridoFolio.Visible = false;
            }
            else
            {
                pbRequeridoFolio.Visible = true;
            }            
        }

        private void EnviarAvisoCancelacion()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;

            try
            {
                Reglas.Documentos loDocumento = new Reglas.Documentos();
                string lsMensaje = string.Empty;

                if (rbFactura.Checked)
                    lsMensaje = loDocumento.EnviarAvisoCancelacion(((InicioSesion)this.MdiParent.Owner).Sesion, Comun.Definiciones.TipoDocumento.Factura, txtFolio.Text.ToUpper(), int.Parse(txtNumero.Text));
                else if (rbNotaCargo.Checked)
                    lsMensaje = loDocumento.EnviarAvisoCancelacion(((InicioSesion)this.MdiParent.Owner).Sesion, Comun.Definiciones.TipoDocumento.NotaCargo, txtFolio.Text.ToUpper(), int.Parse(txtNumero.Text));
                else if (rbNotaCredito.Checked)
                    lsMensaje = loDocumento.EnviarAvisoCancelacion(((InicioSesion)this.MdiParent.Owner).Sesion, Comun.Definiciones.TipoDocumento.NotaCredito, txtFolio.Text.ToUpper(), int.Parse(txtNumero.Text));

                MessageBox.Show(lsMensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
