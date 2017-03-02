using Dapesa.Comun.Informes.General.IU.Reportes.Clientes;
using Dapesa.Almacen.Pedidos.IU.Mensajero.Rdl;
using Dapesa.Comun.Informes.General.Reglas;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dapesa.Seguridad.Entidades;
using System.Web.Security;
using System.IO;
using DevExpress.XtraReports.Web;
using DevExpress.XtraPrinting.InternalAccess;
using Dapesa.Comun.Informes.General.IU.Reportes.Informes.Clientes;
using DevExpress.XtraReports.UI;
using System.Diagnostics;
using DevExpress.Web;

namespace Dapesa.Comun.Informes.General.IU.Reportes.Clientes
{
    public partial class AnalisisVentasVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblError.Visible = false;
            if (!IsPostBack)
            {
                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                Master.Titulo = "Home::.Dapesa.Comun.Informes.General.Reportes.AnalisisVentasVendedor";
                Sesion loSesion = (Sesion)Session["Sesion"];
                Boolean loPermiso = false;
                foreach (Permiso llpemiso in loSesion.Usuario.Permiso)
                {
                    if (llpemiso.Clave == 33)
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

                #region Reporte a Mostrar
                InformeAnalisisVentaVendedor loInformeVendedor = new InformeAnalisisVentaVendedor();
                if (ddlVendedores.SelectedValue == string.Empty && txtClaveCliente.Text == string.Empty)
                {
                    loInformeVendedor.DataSource = loAnalisisVentas.AnalisisVentaVendedor2(
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
                }
                else
                {
                    loInformeVendedor.DataSource = loAnalisisVentas.AnalisisVentaVendedor(
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
                    loInformeVendedor.DataMember = "DataSourceAnalisisVentaVendedor";
                }
                if (Session["Permiso"] == null)
                {
                    foreach (Permiso loPermiso in loSesion.Usuario.Permiso)
                    {
                        if (loPermiso.Clave == 33)
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
                        if (loPermiso.Clave == 33)
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

                loInformeVendedor.Parameters["FiltrosReporte"].Value = ddlSucursales.SelectedItem.Text;
                loInformeVendedor.Parameters["Periodo"].Value = txtFechaInicio.Text + " - " + txtFechaFin.Text;
                loInformeVendedor.Parameters["Usuario"].Value = loSesion.Usuario.Nombre.ToString();
                loInformeVendedor.Parameters["Art_Clave"].Value = (txtArticulo.Text == string.Empty ? "%" : txtArticulo.Text);
                loInformeVendedor.Parameters["FechaInicio"].Value = txtFechaInicio.Text;
                loInformeVendedor.Parameters["FechaFin"].Value = txtFechaFin.Text;
                loInformeVendedor.Parameters["Linea"].Value = ((string.IsNullOrEmpty(ddlLineas.SelectedValue)) ? "%" : ddlLineas.SelectedItem.ToString());
                loInformeVendedor.Parameters["Marca"].Value = ((string.IsNullOrEmpty(ddlMarcas.SelectedValue)) ? "%" : ddlMarcas.SelectedItem.ToString());
                loInformeVendedor.Parameters["Monto"].Value = (ddlMonto.SelectedValue == string.Empty ? "%" : (txtMonto.Text == string.Empty ? "%" : ddlMonto.SelectedItem.Text + " " + txtMonto.Text));
                loInformeVendedor.Parameters["Piezas"].Value = (ddlPiezas.SelectedValue == string.Empty ? "%" : (txtPiezas.Text == string.Empty ? "%" : ddlPiezas.SelectedItem.Text + " " + txtPiezas.Text));
                loInformeVendedor.Parameters["Cliente"].Value = (txtClaveCliente.Text == string.Empty ? "%" : txtClaveCliente.Text);
                this.xrInforme.Report = loInformeVendedor;
                loInformeVendedor.CreateDocument();
                Page.Session["loInformeVendedor"] = loInformeVendedor;
                #endregion

            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void validaFecha()
        {
            int loTotalFecha = 1 + (Math.Abs((Convert.ToDateTime(txtFechaInicio.Text).Month - Convert.ToDateTime(txtFechaFin.Text).Month) + 12 * (Convert.ToDateTime(txtFechaInicio.Text).Year - Convert.ToDateTime(txtFechaFin.Text).Year)));
            if (loTotalFecha > 12)
            {
                lblError.Visible = true;
                lblError.Text = "**SOLO SE PERMITE CONSULTAR 12 MESES";
                Session["loInformeVendedor"] = string.Empty;
                return;
            }
            EnlazarDatos();
        }
        #endregion

        #region Eventos
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            validaFecha();
        }
        protected void xrInforme_CacheReportDocument(object sender, DevExpress.XtraReports.Web.CacheReportDocumentEventArgs e)
        {
            e.Key = "loInformeVendedor";
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