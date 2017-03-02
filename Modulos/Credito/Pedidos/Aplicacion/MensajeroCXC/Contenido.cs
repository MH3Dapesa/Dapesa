using Dapesa.Credito.Pedidos.Reglas;
using Dapesa.Seguridad.Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dapesa.Credito.Pedidos.IU.MensajeroCXC
{
    public partial class Contenido : Form
    {
        public DataTable loPedidosTemporal;
        public Contenido()
        {
            InitializeComponent();
            toolTip.SetToolTip(chbMisPedidos, "Si esta habilitado esta opción, solo mostrara las notificaciones de tu cartera.");
        }

        #region Eventos

        private void Contenido_Shown(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Now.AddDays(-1);
            ObtenerSucursales();
            ValidarFechas();
            this.WindowState = FormWindowState.Maximized;
            foreach (Permiso lopemiso in ((InicioSesion)this.MdiParent.Owner).Sesion.Usuario.Permiso)
            {
                if (lopemiso.Clave == 34)
                {
                    cbNotificar.Visible = true;
                }
            }

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            ValidarFechas();
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            Mensajero loMdiMensajero = new Mensajero(((InicioSesion)this.MdiParent.Owner).Sesion, DateTime.Parse(dtpFechaInicio.Text), DateTime.Parse(dtpFechaFinal.Text), int.Parse(cbSucursal.SelectedValue.ToString()));
            loMdiMensajero.Owner = this.MdiParent;
            loMdiMensajero.Show();
            this.MdiParent.Hide();
        }

        private void timerActualizar_Tick(object sender, EventArgs e)
        {
            ValidarFechas();
        }

        private void timerReloj_Tick(object sender, EventArgs e)
        {

            txtHora.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("HH:mm:ss");

        }

        private void alertControl_FormLoad(object sender, DevExpress.XtraBars.Alerter.AlertFormLoadEventArgs e)
        {
            if (e.AlertForm.AlertInfo.Caption.ToString().Contains("*"))
                e.Buttons.PinButton.SetDown(true);
        }
        #endregion

        #region Metodos

        public void ValidarFechas()
        {
            if (dtpFechaInicio.Value > dtpFechaFinal.Value)
            {
                MessageBox.Show("Error. La fecha inicial no puede ser mayor que la fecha final.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                EnlazarDatos();
            }
        }

        public void EnlazarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;

            try
            {

                Dapesa.Credito.Pedidos.Reglas.MensajeroCXC loMensajero = new Dapesa.Credito.Pedidos.Reglas.MensajeroCXC();
                DataTable loPedidos = loMensajero.ObtenerPedidos(((InicioSesion)this.MdiParent.Owner).Sesion, DateTime.Parse(dtpFechaInicio.Text), DateTime.Parse(dtpFechaFinal.Text), int.Parse(cbSucursal.SelectedValue.ToString()));
                rvPedidos.Reset();

                rvPedidos.LocalReport.ReportPath = "Rdl/Pedidos.rdl";
                rvPedidos.LocalReport.ReportEmbeddedResource = "Rdl/Pedidos.rdl";
                rvPedidos.LocalReport.DisplayName = "MENSAJERO PEDIDOS";
                rvPedidos.LocalReport.DataSources.Add(
                    new ReportDataSource("dsPedidos", loPedidos));
                rvPedidos.ShowToolBar = false;
                rvPedidos.RefreshReport();

                if (!cbNotificar.Checked)
                    Alertar(loPedidos);

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

        public void ObtenerSucursales()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;

            try
            {
                Dapesa.Credito.Pedidos.Reglas.MensajeroCXC loMensajero = new Dapesa.Credito.Pedidos.Reglas.MensajeroCXC();
                DataTable loSucursales = loMensajero.ObtenerSucursales(((InicioSesion)this.MdiParent.Owner).Sesion, ((InicioSesion)this.MdiParent.Owner).Sesion.Usuario.Id);
                cbSucursal.DataSource = loSucursales;

                if (loSucursales.Rows[0]["SUC_PREDEFINIDA"].ToString() != string.Empty)
                {
                    cbSucursal.SelectedValue = int.Parse(loSucursales.Rows[0]["SUC_PREDEFINIDA"].ToString());
                }


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

        private void Alertar(DataTable loPedidosActual)
        {
            if (loPedidosTemporal != null)
            {
                #region Nuevo pedido por autorizar
                for (int i = 0; i < loPedidosActual.Rows.Count; i++)
                {
                    Boolean loAuxiliarCliente = true;
                    Boolean loCompararFilas = false;
                    string loFilaActual = string.Empty;
                    string loFilaAnterior = string.Empty;


                    loFilaActual = loFilaActual
                                + loPedidosActual.Rows[i]["FOLIO"].ToString()
                                + loPedidosActual.Rows[i]["NUMERO"].ToString()
                                + loPedidosActual.Rows[i]["AUTORIZACION"].ToString()
                                + loPedidosActual.Rows[i]["ORDEN"].ToString();

                    for (int r = 0; r < loPedidosTemporal.Rows.Count; r++)
                    {
                        loFilaAnterior = loFilaAnterior
                                        + loPedidosTemporal.Rows[r]["FOLIO"].ToString()
                                        + loPedidosTemporal.Rows[r]["NUMERO"].ToString()
                                        + loPedidosTemporal.Rows[r]["AUTORIZACION"].ToString()
                                        + loPedidosTemporal.Rows[r]["ORDEN"].ToString();

                        if (loFilaActual == loFilaAnterior)
                        {
                            loCompararFilas = true;
                        }
                        loFilaAnterior = string.Empty;
                    }
                    if (!loCompararFilas)
                    {
                        if (loPedidosActual.Rows[i]["PERSONAL"].ToString() != string.Empty)
                        {
                            if (int.Parse(loPedidosActual.Rows[i]["PERSONAL"].ToString()) != ((InicioSesion)this.MdiParent.Owner).Sesion.Usuario.Id)
                            {
                                loAuxiliarCliente = false;
                            }
                        }
                        if (loPedidosActual.Rows[i]["PERSONAL_TMP"].ToString() != string.Empty)
                        {
                            if (int.Parse(loPedidosActual.Rows[i]["PERSONAL_TMP"].ToString()) == ((InicioSesion)this.MdiParent.Owner).Sesion.Usuario.Id)
                            {
                                loAuxiliarCliente = true;
                            }
                        }
                        string loContenido = loPedidosActual.Rows[i]["FOLIO"].ToString()
                                            + "-"
                                            + loPedidosActual.Rows[i]["NUMERO"].ToString()
                                            + ",   VEND. "
                                            + loPedidosActual.Rows[i]["VENDEDOR"].ToString()
                                            + ". \r\n"
                                            + loPedidosActual.Rows[i]["CLAVE"].ToString()
                                            + " "
                                            + loPedidosActual.Rows[i]["CLIENTE"].ToString();

                        alertControl.LookAndFeel.UseDefaultLookAndFeel = false;
                        alertControl.LookAndFeel.SkinMaskColor = Color.LightBlue;
                        if (chbMisPedidos.Checked)
                        {
                            if (loAuxiliarCliente)
                            {
                                alertControl.Show(this, "PEDIDO POR AUTORIZAR *", loContenido, imageCollection.Images[0]);
                                
                            }
                        }
                        else
                        {
                            if (loAuxiliarCliente)
                            {
                                alertControl.Show(this, "PEDIDO POR AUTORIZAR *", loContenido, imageCollection.Images[0]);
                            }
                            else
                            {
                                alertControl.Show(this, "PEDIDO POR AUTORIZAR", loContenido, imageCollection.Images[1]);
                            }
                        }
                    }
                }
                #endregion
            }
            loPedidosTemporal = loPedidosActual;
        }

        #endregion

        private void alertControl_AlertClick(object sender, DevExpress.XtraBars.Alerter.AlertClickEventArgs e)
        {
            if (((Contenedor)this.MdiParent).WindowState == FormWindowState.Minimized)
            {
                ((Contenedor)this.MdiParent).WindowState = FormWindowState.Maximized;
                return;
            }
            ((Contenedor)this.MdiParent).Focus();
            ((Contenedor)this.MdiParent).Hide();
            ((Contenedor)this.MdiParent).Show();
        }

        private void alertControl_ButtonClick(object sender, DevExpress.XtraBars.Alerter.AlertButtonClickEventArgs e)
        {
            if (e.ButtonName == "abtnCerrar")
            {
                e.AlertForm.Close();
            }
        }
    }

}





