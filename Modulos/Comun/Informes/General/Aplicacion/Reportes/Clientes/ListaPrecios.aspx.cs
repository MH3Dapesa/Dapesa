using Dapesa.Comun.Informes.General.IU.Reportes.Informes.Clientes;
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
using System.Globalization;
using System.Configuration;

namespace Dapesa.Comun.Informes.General.IU.Reportes.Clientes
{
    public partial class ListaPrecios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                Master.Titulo = "Home::.Dapesa.Comun.Informes.General.Reportes.ListaPrecios";
                Sesion loSesion = (Sesion)Session["Sesion"];
                Boolean loPermiso = false;
                foreach (Permiso llpemiso in loSesion.Usuario.Permiso)
                {
                    if (llpemiso.Clave == 28)
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
                Ventas loListaPrecios = new Ventas();
                Sesion loSesion = (Sesion)Session["Sesion"];
                InformeListaPrecios loAntiguedadSaldos = new InformeListaPrecios();
                loAntiguedadSaldos.Parameters["Linea"].Value = ((string.IsNullOrEmpty(ddlLineas.SelectedValue)) ? "%" : ddlLineas.SelectedItem.ToString());
                loAntiguedadSaldos.Parameters["Marca"].Value = ((string.IsNullOrEmpty(ddlMarcas.SelectedValue)) ? "%" : ddlMarcas.SelectedItem.ToString());
                loAntiguedadSaldos.Parameters["TipoPrecio"].Value = ((string.IsNullOrEmpty(ddlListaPrecios.SelectedValue)) ? "%" : ddlListaPrecios.SelectedItem.ToString());
                loAntiguedadSaldos.DataSource = loListaPrecios.ObtenerListaPrecios(
                                   (Sesion)Session["Sesion"],
                                   int.Parse(ddlListaPrecios.SelectedValue),
                                   ((string.IsNullOrEmpty(ddlAlmacenes.SelectedValue)) ? -1 : int.Parse(ddlAlmacenes.SelectedValue)),
                                   ddlMarcas.SelectedValue,
                                   ddlLineas.SelectedValue
                                   );
                loAntiguedadSaldos.DataMember = "DataSourceListaPrecios";

                if (Session["Permiso"] == null)
                {
                    foreach (Permiso loPermiso in loSesion.Usuario.Permiso)
                    {
                        if (loPermiso.Clave == 28)
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
                        if (loPermiso.Clave == 28)
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

                this.xrInforme.Report = loAntiguedadSaldos;
                loAntiguedadSaldos.CreateDocument();
                Page.Session["loInformeListaPrecios"] = loAntiguedadSaldos;
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
            e.Key = "loInformeListaPrecios";
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