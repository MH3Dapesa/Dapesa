using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Credito.Clientes.Cartera.UI.AnalisisCliente
{
    public partial class AnalisisCliente : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);


                Master.Titulo = "Home::.Dapesa.Credito.Clientes.Cartera.AnalisisCliente";
            }
            //btnImprimir.Attributes.Add("onclick", "Imprimir('divContenido');return false;");
            btnImprimir.Visible = false;
            upPanelMostrar.Visible = false;
            lblResultadoConsulta.Visible = false;
            btnImprimir.Visible = false;
        }

        #region Eventos

        protected void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            VericaCamposVacios();
        }

        protected void gvVenta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 5; i <= e.Row.Cells.Count - 1; i++)
            {
                e.Row.Cells[i].Width = 0;
                e.Row.Cells[i].Visible = false;
            }
            e.Row.Cells[0].CssClass = "tdCssMes";
            e.Row.Cells[2].CssClass = "tdCssPagoPlazo";
            e.Row.Cells[3].CssClass = "tdCssAtrasoDias";
            e.Row.Cells[4].CssClass = "tdCssObservaciones";

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].CssClass = "tdCssMes";
                e.Row.Cells[0].Text = "MES";
                e.Row.Cells[1].Text = "TOTAL COMPRADO";
                e.Row.Cells[3].Text = "ATRASO EN DÍAS";
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = Convert.ToDecimal(e.Row.Cells[1].Text).ToString("N2");
                e.Row.Cells[1].CssClass = "tdCssImporte";
                e.Row.Cells[0].Text = Convert.ToDateTime("1/" + e.Row.Cells[0].Text).ToString("MMMM", CultureInfo.CreateSpecificCulture("es-MX")).ToUpper()
                                      + " - " + Convert.ToDateTime("1/" + e.Row.Cells[0].Text).ToString("yyyy");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnalisisCliente.aspx");
        }
        
        #endregion

        #region Metodos

        public void EnlazarDatos()
        {

            this.ObtenerVentaCliente();
            Sesion loSesion = (Sesion)Session["Sesion"];
            this.lblAuxiliar.Text = loSesion.Usuario.Nombre.ToUpper();
            this.lblElaboro.Text = loSesion.Usuario.Nombre.ToUpper();

            this.lblMovimientoSolicitad.Text = txtMovimientoSolicitado.Text;
            this.lblSetMontoSolicitado.Text = txtMontoSolicitad.Text;
            this.lblSetPlazoRequerido.Text = txtPlazoRequerid.Text.ToUpper();
            this.lblSetClaveCliente.Text = txtClaveCliente.Text;
            this.lblFechaConsulta.Text = DateTime.Now.ToShortDateString().ToString().ToUpper() +" " + DateTime.Now.ToLongTimeString().ToUpper(); ;         
            btnImprimir.Visible = true;
            upPanelMostrar.Visible = true;
            btnImprimir.Visible = true;
            upPanelContenido.Update();

        }

        public void ObtenerVentaCliente()
        {
            try
            {
                Reglas.AnalisisCliente loAnalsisCliente = new Reglas.AnalisisCliente();

                DateTime loFechaFin = DateTime.Today;
                DateTime loFechaInicio = loFechaFin.AddMonths(-11);

                DataTable loResultado = loAnalsisCliente.ObtenerVentaCliente((Sesion)Session["Sesion"], loFechaInicio, loFechaFin, txtClaveCliente.Text);

                loResultado.Columns.Add("PLAZO EN PAGO SI/NO", typeof(string));
                loResultado.Columns.Add("OBSERVACIONES", typeof(string));
                DataRow loAgregarFila;
                loAgregarFila = loResultado.NewRow();
                decimal lnTotalImporte = 0;
                int lnComprasRealizadas = 0;
                for (int i = 0; i < loResultado.Rows.Count; i++)
                {
                    if (Convert.ToInt32(loResultado.Rows[i]["DIAS_ULT_PAGO"].ToString()) > 0)
                    {
                        loResultado.Rows[i]["PLAZO EN PAGO SI/NO"] = "NO";
                        loResultado.Rows[i]["OBSERVACIONES"] = "PAGO A " + (Convert.ToInt32(loResultado.Rows[i]["DIAS_ULT_PAGO"].ToString()) + Convert.ToInt32(lblPlazoProntoPago.Text)).ToString() + " DÍAS";
                    }
                    else
                    {
                        loResultado.Rows[i]["PLAZO EN PAGO SI/NO"] = "SI";
                        loResultado.Rows[i]["OBSERVACIONES"] = "PAGO A " + lblPlazoProntoPago.Text + " DÍAS";
                    }

                    lnTotalImporte = lnTotalImporte + Convert.ToDecimal(loResultado.Rows[i]["IMPORTE"].ToString());
                    if(Convert.ToDecimal(loResultado.Rows[i]["IMPORTE"].ToString())!=0)
                    {
                        lnComprasRealizadas++;
                    }
                }

                lblTotalImporte.Text = lnTotalImporte.ToString("N2");
                lblPromedioImporte.Text = (lnTotalImporte / 12).ToString("N2");
                lblPromedioCompras.Text = (lnTotalImporte / ((lnComprasRealizadas<=0)?1:lnComprasRealizadas)).ToString("N2");
                loResultado.Columns["MESYEAR"].SetOrdinal(0);
                loResultado.Columns["IMPORTE"].SetOrdinal(1);
                loResultado.Columns["PLAZO EN PAGO SI/NO"].SetOrdinal(2);
                loResultado.Columns["DIAS_ULT_PAGO"].SetOrdinal(3);
                loResultado.Columns["OBSERVACIONES"].SetOrdinal(4);
                gvVenta.DataSource = loResultado;
                gvVenta.DataBind();

            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
        }

        public void ObtenerObservacionesCliente()
        {
            try
            {
                Reglas.AnalisisCliente loAnalsisCliente = new Reglas.AnalisisCliente();
                string loFechaInicio = DateTime.Now.Day + "/" + DateTime.Now.Month;
                int loObtenerRestaYear = Convert.ToInt32(DateTime.Now.Year) - 1;
                loFechaInicio = loFechaInicio + "/" + loObtenerRestaYear.ToString();

                DataTable loResultado = loAnalsisCliente.ObtenerClienteEncabezado((Sesion)Session["Sesion"], txtClaveCliente.Text);

                if (loResultado.Rows.Count > 0)
                {
                    for (int i = 0; i < loResultado.Rows.Count; i++)
                    {
                        int lsDescuento_PP1 = Convert.ToInt32(loResultado.Rows[i]["DESCTO_PP1"].ToString());
                        int lsDescuento_PP2 = Convert.ToInt32(loResultado.Rows[i]["DESCTO_PP2"].ToString());
                        this.lblNombreCliente.Text = loResultado.Rows[i]["RAZON_SOCIAL"].ToString().ToUpper();
                        this.lblClienteDesde.Text = Convert.ToDateTime(loResultado.Rows[i]["FECHA_ALTA"].ToString()).ToString("d");
                        this.lblDireccion.Text = loResultado.Rows[i]["CIUDAD"].ToString() + "," + loResultado.Rows[i]["ESTADO"].ToString().ToUpper();
                        this.lblClaveVendedor.Text = loResultado.Rows[i]["VEND_CLAVE"].ToString();
                        this.lblNombreVendedor.Text = loResultado.Rows[i]["NOMBRE"].ToString().ToUpper();
                        this.lblSaldoDeudor.Text= Convert.ToDecimal(loResultado.Rows[i]["SALDO"].ToString()).ToString("N2");
                        this.lblLimiteCredito.Text = Convert.ToDecimal(loResultado.Rows[i]["LIMITE_CREDITO"].ToString()).ToString("N2");
                        this.lblPlazoProntoPago.Text = loResultado.Rows[i]["PLAZO_PP"].ToString();
                        this.lblDescuentoAutorizado.Text = lsDescuento_PP1 + "%   " + lsDescuento_PP2 + "%   " + "GENERAL";
                        this.lblDescripcionCliente.Text = loResultado.Rows[i]["OBSERVACIONES"].ToString().ToUpper();
                    }
                    lblResultadoConsulta.Visible=false;
                    this.EnlazarDatos();
                }
                else
                {
                    lblResultadoConsulta.Text = "NO HAY REGISTROS QUE MOSTRAR.";
                    lblResultadoConsulta.Visible = true;
                }

            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
        }

        public void VericaCamposVacios()
        {
            if (txtClaveCliente.Text != string.Empty)
            {
                if (txtMontoSolicitad.Text != string.Empty)
                {
                    if (txtPlazoRequerid.Text != string.Empty)
                    {
                        if (txtMovimientoSolicitado.Text != string.Empty)
                        {
                            this.ObtenerObservacionesCliente();
                        }
                        else
                        {
                            lblResultadoConsulta.Text = "MOVIMIENTO SOLICITADO REQUERIDO.";
                            lblResultadoConsulta.Visible = true;
                            txtMovimientoSolicitado.Focus();
                        }
                    }
                    else
                    {
                        lblResultadoConsulta.Text = "PLAZO P.P. REQUERIDO.";
                        lblResultadoConsulta.Visible = true;
                        txtPlazoRequerid.Focus();
                    }
                }
                else
                {
                    lblResultadoConsulta.Text = "MONTO SOLICITADO REQUERIDO.";
                    lblResultadoConsulta.Visible = true;
                    txtMontoSolicitad.Focus();
                }
            }
            else
            {
                lblResultadoConsulta.Text = "CLAVE DEL CLIENTE REQUERIO.";
                lblResultadoConsulta.Visible = true;
                txtClaveCliente.Focus();
            }
        }
        #endregion

    }
}
