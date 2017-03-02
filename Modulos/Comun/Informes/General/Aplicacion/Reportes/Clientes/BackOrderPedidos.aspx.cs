using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.UI;
using Dapesa.Comun.Informes.General.IU.Reportes.Informes.BackOrder;
using Dapesa.Comun.Informes.General.Reglas;
using System.Diagnostics;
using System.IO;
using DevExpress.XtraReports.Web;

namespace Dapesa.Comun.Informes.General.IU.Reportes.Clientes
{
    public partial class BackOrderPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                Master.Titulo = "Home::.Dapesa.Comun.Informes.General.IU.Reportes";
                Sesion loSesion = (Sesion)Session["Sesion"];
                Boolean loPermiso = false;
                foreach (Permiso llpemiso in loSesion.Usuario.Permiso)
                {
                    if (llpemiso.Clave == 35)
                    {
                        foreach (Dapesa.Seguridad.Comun.Definiciones.TipoPermiso loTipoEmelento in llpemiso.TipoPermiso)
                        {
                            if (loTipoEmelento.ToString() == "Guardar")
                            {
                                btnExportarExcel.Visible = true;
                            }
                        }
                        loPermiso = true;
                    }
                }
                if (!loPermiso)
                {
                    Response.Redirect(FormsAuthentication.LoginUrl, true);
                }
                txtFechaInicio.Text = ((DateTime.Today).AddMonths(-1)).ToString("dd/MM/yyyy");
                txtFechaFin.Text = DateTime.Today.ToString("dd/MM/yyyy");
            }
            txtFolioPedido.Attributes.Add("PlaceHolder", "Folio");
            txtNumeroPedido.Attributes.Add("PlaceHolder", "Numero");
            txtArticulo.Attributes.Add("PlaceHolder", "Articulo");
            txtClaveCliente.Attributes.Add("onkeypress", "javascript: return ValidarEspacio(event,this)");
            txtNumeroPedido.Attributes.Add("onkeypress", "javascript: return ValidarEspacio(event,this)");
            txtFolioPedido.Attributes.Add("onkeypress", "javascript: return ValidarEspacio(event,this)");
        }

        #region Eventos
        protected void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            CrearReporte();
        }

        protected void btnExportarExcel_Click(object sender, ImageClickEventArgs e)
        {
            ExportarExcel();
        }

        protected void xrInforme_CacheReportDocument(object sender, DevExpress.XtraReports.Web.CacheReportDocumentEventArgs e)
        {
            e.Key = "loInformeBackOrderPedidos";
            Page.Session[e.Key] = e.SaveDocumentToMemoryStream();
        }

        protected void xrInforme_RestoreReportDocumentFromCache(object sender, DevExpress.XtraReports.Web.RestoreReportDocumentFromCacheEventArgs e)
        {

            Stream stream = Page.Session[e.Key] as Stream;
            if (stream != null)
                e.RestoreDocumentFromStream(stream);

        }
        #endregion

        #region Metodos
        protected void EnlazarDatos()
        {
            try
            {
                int? lnPedidoNumero = null;
                int? lnClaveVendedor = null;
                int? lnLineaClave = null;
                int? lnMarcaClave = null;
                int MostrarArticulos = 0;
                #region Obtener filtros utilizados.
                if (!string.IsNullOrEmpty(txtNumeroPedido.Text))
                {
                    lnPedidoNumero = Int32.Parse(txtNumeroPedido.Text);
                }
                if (!string.IsNullOrEmpty(ddlVendedores.SelectedValue))
                {
                    lnClaveVendedor = Int32.Parse(ddlVendedores.SelectedValue);
                }
                if (!string.IsNullOrEmpty(ddlMarcas.SelectedValue.ToString()))
                {
                    lnMarcaClave = Int32.Parse(ddlMarcas.SelectedValue.ToString());
                }
                if (!string.IsNullOrEmpty(ddlLineas.SelectedValue.ToString()))
                {
                    lnLineaClave = Int32.Parse(ddlLineas.SelectedValue.ToString());
                }
                #endregion
                if (rbaArticulosConExistencia.Checked)
                    MostrarArticulos = 1;
                if (rbSinArticulosSinExistencia.Checked)
                    MostrarArticulos = 2;

                DateTime loFechaFin = DateTime.Parse(txtFechaFin.Text);
                DateTime loFechaInicio = DateTime.Parse(txtFechaInicio.Text);
                Reglas.Ventas loBackOrderPedidos = new Reglas.Ventas();
                ViewState["loResultado"] = loBackOrderPedidos.ObtenerBackOrderPedidos((Sesion)Session["Sesion"], loFechaInicio, loFechaFin, Int32.Parse(ddlSucursales.SelectedValue), lnClaveVendedor, txtClaveCliente.Text.ToUpper(), lnPedidoNumero, txtFolioPedido.Text.ToUpper(), txtArticulo.Text.ToUpper(), lnLineaClave, lnMarcaClave, MostrarArticulos);
            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void CrearReporte()
        {
            try
            {
                EnlazarDatos();
                #region EncabezadoReporte
                string loFiltrosAdicionales = "Sucursal:   " + ddlSucursales.SelectedItem.ToString() + ".\r"
                                       + ((ddlVendedores.SelectedValue.ToString() == string.Empty) ? string.Empty : ("Vendedor: " + ddlVendedores.SelectedItem.ToString() + ".\r"))
                                       + ((ddlMarcas.SelectedValue.ToString() == string.Empty) ? string.Empty : "Marca:   " + ddlMarcas.SelectedItem.ToString() + ".   ")
                                       + ((ddlLineas.SelectedValue.ToString() == string.Empty) ? string.Empty : "Linea:   " + ((ddlLineas.SelectedItem.ToString().Length <= 37) ? ddlLineas.SelectedItem.ToString() : ddlLineas.SelectedItem.ToString().Substring(0, 37).ToString()) + ".   ")
                                       + ((txtArticulo.Text == string.Empty) ? string.Empty : "Articulo:   " + txtArticulo.Text + ".");
                #endregion
                Sesion loSesion = (Sesion)Session["Sesion"];
                InformeVistaEstandar objReport = new InformeVistaEstandar();
                objReport.Parameters["Sucursal"].Value = loFiltrosAdicionales;
                objReport.Parameters["Vendedor"].Value = (ddlVendedores.SelectedValue.ToString() == string.Empty) ? string.Empty : "Vendedor:   " + ddlVendedores.SelectedItem.ToString() + ".\r";
                objReport.Parameters["FiltrosAdicionales"].Value = loFiltrosAdicionales;
                objReport.Parameters["PeriodoReporte"].Value = txtFechaInicio.Text + " - " + txtFechaFin.Text;
                objReport.Parameters["Usuario"].Value = loSesion.Usuario.Nombre.ToString();
                objReport.Parameters["Sucursal"].Visible = false;
                objReport.Parameters["Vendedor"].Visible = false;
                objReport.Parameters["FiltrosAdicionales"].Visible = false;
                objReport.Parameters["PeriodoReporte"].Visible = false;
                objReport.Parameters["Usuario"].Visible = false;
                objReport.DataSource = (DataTable)ViewState["loResultado"];
                objReport.DataMember = "DataSourceBackOrderPedido";
                #region Asignar permiso de imprimir y guardar
                if (Session["Permiso"] == null)
                {
                    foreach (Permiso loPermiso in loSesion.Usuario.Permiso)
                    {
                        if (loPermiso.Clave == 35)
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
                        if (loPermiso.Clave == 35)
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
                #endregion
                this.xrInforme.Report = objReport;
                objReport.CreateDocument();
                Page.Session["loInformeBackOrderPedidos"] = objReport;
                btnExportarExcel.Visible = true;
            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void ExportarExcel()
        {
            try
            {
                EnlazarDatos();
                Sesion loSesion = (Sesion)Session["Sesion"];
                InformeVistaNormal objReport = new InformeVistaNormal();
                objReport.DataSource = (DataTable)ViewState["loResultado"];
                objReport.DataMember = "sqlDataSource1";
                #region Asignar permiso de imprimir y guardar
                if (Session["Permiso"] == null)
                {
                    foreach (Permiso loPermiso in loSesion.Usuario.Permiso)
                    {
                        if (loPermiso.Clave == 35)
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
                        if (loPermiso.Clave == 35)
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
                #endregion
                objReport.CreateDocument();
                this.xrInforme.Report = objReport;
                Page.Session["loInformeBackOrderPedidos"] = objReport;
            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
        }
        #endregion
    }
}