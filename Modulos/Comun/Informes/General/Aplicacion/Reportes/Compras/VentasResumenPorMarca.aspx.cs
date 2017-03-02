using Dapesa.Comun.Informes.General.IU.Reportes.Clientes;
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
using DevExpress.XtraReports.UI;
using System.Diagnostics;
using DevExpress.Web;
using Dapesa.Comun.Informes.General.IU.Reportes.Informes.Compras;

namespace Dapesa.Comun.Informes.General.IU.Reportes.Compras
{
    public partial class VentasResumenPorMarca : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                Master.Titulo = "Home::.Dapesa.Comun.Informes.General.Reportes.Compras.VentasResumenPorMarca";
                Sesion loSesion = (Sesion)Session["Sesion"];
                Boolean loPermiso = false;
                foreach (Permiso llpemiso in loSesion.Usuario.Permiso)
                {
                    if (llpemiso.Clave == 42)
                    {
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
                Reglas.Compras loCompras = new Reglas.Compras();

                #region Reporte a Mostrar
                InformeVentasResumenPorMarca loInformeVentasResumenPorMarca = new InformeVentasResumenPorMarca();
                loInformeVentasResumenPorMarca.DataSource = loCompras.obtenerVentasResumenPorMarca(
                                (Sesion)Session["Sesion"],                                
                                Convert.ToDateTime(txtFechaInicio.Text),
                                Convert.ToDateTime(txtFechaFin.Text),
                                ddlSucursales.SelectedValue.ToString()
                                ); 
                loInformeVentasResumenPorMarca.DataMember = "DataSourceVentasResumenXMarca";
                loInformeVentasResumenPorMarca.Parameters["Fecha"].Value = txtFechaInicio.Text + " - " + txtFechaFin.Text;
                loInformeVentasResumenPorMarca.Parameters["Sucursal"].Value = ddlSucursales.SelectedItem.Text;
                loInformeVentasResumenPorMarca.Parameters["Usuario"].Value = loSesion.Usuario.Nombre.ToString();
                this.xrInforme.Report = loInformeVentasResumenPorMarca;
                loInformeVentasResumenPorMarca.CreateDocument();
                Page.Session["loInformeVentasResumenPorMarca"] = loInformeVentasResumenPorMarca;
                
                #endregion

                #region Asignar permiso de imprimir y guardar
                if (Session["Permiso"] == null)
                {
                    foreach (Permiso loPermiso in loSesion.Usuario.Permiso)
                    {
                        if (loPermiso.Clave == 42)
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
                        if (loPermiso.Clave == 42)
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
            e.Key = "loInformeVentasResumenPorMarca";
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