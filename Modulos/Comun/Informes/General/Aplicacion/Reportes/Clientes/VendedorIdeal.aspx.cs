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
    public partial class VendedorIdeal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                Sesion loSesion = (Sesion)Session["Sesion"];
                Boolean loPermiso = false;
                foreach (Permiso llpemiso in loSesion.Usuario.Permiso)
                {
                    if (llpemiso.Clave == 22)
                    {
                        Master.Titulo = "Home::.Dapesa.Comun.Informes.General.Reportes.VendedorIdeal";
                        loPermiso = true;
                    }
                }
                if (!loPermiso)
                {
                    Response.Redirect(FormsAuthentication.LoginUrl, true);
                }
            }
        }

        #region Metodos
        protected void EnlazarDatos()
        {
            try
            {
                Sesion loSesion = (Sesion)Session["Sesion"];
                Ventas loAnalisisVentas = new Ventas();
                #region Reporte a Mostrar
                InformeVendedorIdealMarca loInformeVendedor = new InformeVendedorIdealMarca();
                loInformeVendedor.DataSource = loAnalisisVentas.AnalisisVendedorIdeal(
                                (Sesion)Session["Sesion"],
                                Convert.ToDateTime(txtFechaInicio.Text),
                                Convert.ToDateTime(txtFechaFin.Text),
                                ddlSucursales.SelectedValue.ToString(),
                                ddlVendedores.SelectedValue.ToString()
                                ); ;
                loInformeVendedor.DataMember = "VentaDataSource";
                loInformeVendedor.Parameters["FiltrosReporte"].Value = "Sucursal: " + ddlSucursales.SelectedItem.Text + ". "
                                        + "Vendedor: " + ddlVendedores.SelectedItem.Text + ".";
                loInformeVendedor.Parameters["Usuario"].Value = loSesion.Usuario.Nombre.ToString();
                loInformeVendedor.Parameters["PorcentajeIdealVenta"].Value = ((txtPorcentajeMontoIdeal.Text == string.Empty) ? 0 : (decimal.Parse(txtPorcentajeMontoIdeal.Text) / 100));
                loInformeVendedor.Parameters["MostrarEncabezado"].Value = cbMostrarEncabezado.Checked;
                loInformeVendedor.Parameters["FiltrosReporte"].Visible = false;
                loInformeVendedor.Parameters["Usuario"].Visible = false;
                loInformeVendedor.Parameters["PorcentajeIdealVenta"].Visible = false;
                loInformeVendedor.Parameters["MostrarEncabezado"].Visible = false;
                #region Asignar permiso de imprimir y guardar
                foreach (Permiso loPermiso in loSesion.Usuario.Permiso)
                {
                    if (loPermiso.Clave == 22)
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
                    if (loPermiso.Clave == 22)
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
                #endregion
                this.xrInforme.Report = loInformeVendedor;
                loInformeVendedor.CreateDocument();
                Page.Session["loInformeVendedorIdeal"] = loInformeVendedor;
                #endregion
            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
        }
        #endregion

        #region Eventos
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            EnlazarDatos();
        }
        protected void xrInforme_CacheReportDocument(object sender, DevExpress.XtraReports.Web.CacheReportDocumentEventArgs e)
        {
            e.Key = "loInformeVendedorIdeal";
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