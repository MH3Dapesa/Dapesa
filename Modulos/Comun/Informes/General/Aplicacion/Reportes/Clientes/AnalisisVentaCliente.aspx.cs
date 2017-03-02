using Dapesa.Comun.Informes.General.Reglas;
using Dapesa.Seguridad.Entidades;
using Dapesa.Comun.Informes.General.IU.Reportes.Informes.Clientes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.Web;

namespace Dapesa.Comun.Informes.General.IU.Reportes.Clientes
{
    public partial class AnalisisVentaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                Master.Titulo = "Home::.Dapesa.Comun.Informes.General.Reportes.AnalisisVentaCliente";
                Sesion loSesion = (Sesion)Session["Sesion"];
                Boolean loPermiso = false;
                foreach (Permiso llpemiso in loSesion.Usuario.Permiso)
                {
                    if (llpemiso.Clave == 32)
                    {
                        loPermiso = true;
                    }
                }
                if (!loPermiso)
                {
                    Response.Redirect(FormsAuthentication.LoginUrl, true);
                }
            }
            ddlMonto.Attributes.Add("onchange", "limpiarMonto()");
            ddlPiezas.Attributes.Add("onchange", "limpiarPiezas()");
            ddlSucursales.Attributes.Add("onchange", "SeleccionarSucursal()");

        }

        #region Metodos
        protected void EnlazarDatos()
        {
            try
            {
                Sesion loSesion = (Sesion)Session["Sesion"];
                Ventas loAnalisisVentas = new Ventas();
                InformeAnalisisVentaCliente loInformeCliente = new InformeAnalisisVentaCliente();
                loInformeCliente.DataSource = loAnalisisVentas.AnalisisVentaCliente(
                                (Sesion)Session["Sesion"],
                                Convert.ToDateTime(txtFechaInicio.Text),
                                Convert.ToDateTime(txtFechaFin.Text),
                                ddlSucursales.SelectedValue.ToString(),
                                ddlVendedores.SelectedValue.ToString(),
                                txtClaveCliente.Text,
                                ddlMarcas.SelectedValue.ToString(),
                                ddlLineas.SelectedValue.ToString(),
                                txtArticulo.Text.ToUpper(),
                                ddlMonto.SelectedValue.ToString(),
                                ((txtMonto.Text.Length > 0) ? int.Parse(txtMonto.Text) : 0),
                                ddlPiezas.SelectedValue.ToString(),
                                ((txtPiezas.Text.Length > 0) ? int.Parse(txtPiezas.Text) : 0)
                                );
                loInformeCliente.DataMember = "DataSourceAnalisisVentaCliente";
                if (Session["Permiso"] == null)
                {
                    foreach (Permiso loPermiso in loSesion.Usuario.Permiso)
                    {
                        if (loPermiso.Clave == 32)
                        {
                            foreach (Dapesa.Seguridad.Comun.Definiciones.TipoPermiso loTipoEmelento in loPermiso.TipoPermiso)
                            {
                                if (loTipoEmelento.ToString() == "Imprimir")
                                {
                                    #region Eliminar Boton Imprimir
                                    ReportToolbarItem saveItem = null;
                                    foreach (ReportToolbarItem item in xrInforme.ToolbarItems)
                                    {
                                        if (item.ItemKind == ReportToolbarItemKind.PrintReport || item.ItemKind == ReportToolbarItemKind.PrintPage)
                                            saveItem = item;
                                    }
                                    xrInforme.ToolbarItems.Remove(saveItem);
                                    saveItem = null;
                                    foreach (ReportToolbarItem item in xrInforme.ToolbarItems)
                                    {
                                        if (item.ItemKind == ReportToolbarItemKind.PrintPage || item.ItemKind == ReportToolbarItemKind.PrintPage)
                                            saveItem = item;
                                    }
                                    xrInforme.ToolbarItems.Remove(saveItem);
                                    #endregion
                                    xrInforme.ToolbarItems.Add(new ReportToolbarButton(ReportToolbarItemKind.PrintPage, true));
                                    xrInforme.ToolbarItems.Add(new ReportToolbarButton(ReportToolbarItemKind.PrintReport, true));
                                }
                            }
                        }
                        if (loPermiso.Clave == 32)
                        {
                            foreach (Dapesa.Seguridad.Comun.Definiciones.TipoPermiso loTipoEmelento in loPermiso.TipoPermiso)
                            {
                                if (loTipoEmelento.ToString() == "Guardar")
                                {
                                    #region Eliminar Boton Guadar
                                    ReportToolbarItem loItem = null;
                                    foreach (ReportToolbarItem item in xrInforme.ToolbarItems)
                                    {
                                        if (item.ItemKind == ReportToolbarItemKind.SaveToDisk || item.ItemKind == ReportToolbarItemKind.SaveToDisk)
                                            loItem = item;
                                    }
                                    xrInforme.ToolbarItems.Remove(loItem);
                                    #endregion
                                    xrInforme.ToolbarItems.Add(new ReportToolbarButton(ReportToolbarItemKind.SaveToDisk, true));
                                }
                            }
                        }
                    }
                }
                loInformeCliente.Parameters["Sucursal"].Value = ddlSucursales.SelectedItem.ToString();
                loInformeCliente.Parameters["Periodo"].Value = txtFechaInicio.Text + " - " + txtFechaFin.Text;
                loInformeCliente.Parameters["Marca"].Value = ((ddlMarcas.SelectedValue.ToString() == string.Empty) ? "%" : ddlMarcas.SelectedItem.ToString());
                loInformeCliente.Parameters["Linea"].Value = ((ddlLineas.SelectedValue.ToString() == string.Empty) ? "%" : ddlLineas.SelectedItem.ToString());
                loInformeCliente.Parameters["Articulo"].Value = ((txtArticulo.Text == string.Empty) ? "%" : txtArticulo.Text.ToUpper());
                loInformeCliente.Parameters["FechaInicial"].Value = txtFechaInicio.Text;
                loInformeCliente.Parameters["FechaFinal"].Value = txtFechaFin.Text;
                loInformeCliente.Parameters["Usuario"].Value = loSesion.Usuario.Nombre.ToString();
                loInformeCliente.Parameters["Monto"].Value = (ddlMonto.SelectedValue == string.Empty ? "%" : (txtMonto.Text == string.Empty ? "%" : ddlMonto.SelectedItem.Text + " " + txtMonto.Text));
                loInformeCliente.Parameters["Piezas"].Value = (ddlPiezas.SelectedValue == string.Empty ? "%" : (txtPiezas.Text == string.Empty ? "%" : ddlPiezas.SelectedItem.Text + " " + txtPiezas.Text));
                this.xrInforme.Report = loInformeCliente;
                loInformeCliente.CreateDocument();
                Page.Session["loInformeVentas"] = loInformeCliente;
            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void ValidarFechas()
        {
            int lnMeses = 1 + ((Math.Abs((Convert.ToDateTime(txtFechaInicio.Text).Month - Convert.ToDateTime(txtFechaFin.Text).Month) + 12 * (Convert.ToDateTime(txtFechaInicio.Text).Year - Convert.ToDateTime(txtFechaFin.Text).Year))));

            if (lnMeses > 12)
            {
                lblResultado.Text = "**SOLO SE PERMITE CONSULTAR 12 MESES";
                Page.Session["loInformeVentas"] = string.Empty;
                return;
            }

            EnlazarDatos();
            lblResultado.Text = string.Empty;
        }
        #endregion

        #region Eventos
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            ValidarFechas();
        }
        protected void xrInforme_CacheReportDocument(object sender, DevExpress.XtraReports.Web.CacheReportDocumentEventArgs e)
        {
            e.Key = "loInformeVentas";
            Page.Session[e.Key] = e.SaveDocumentToMemoryStream();
        }

        protected void xrInforme_RestoreReportDocumentFromCache(object sender, DevExpress.XtraReports.Web.RestoreReportDocumentFromCacheEventArgs e)
        {
            Stream stream = Page.Session[e.Key] as Stream;
            if (stream != null)
                e.RestoreDocumentFromStream(stream);
        }
        #endregion
    }
}