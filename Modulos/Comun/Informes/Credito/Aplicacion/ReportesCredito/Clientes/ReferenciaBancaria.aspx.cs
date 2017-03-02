using Dapesa.Comun.Informes.Credito.IU.ReportesCredito.Informes;
using Dapesa.Comun.Informes.Credito.Reglas;
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

namespace Dapesa.Comun.Informes.Credito.IU.ReportesCredito.Clientes
{
    public partial class ReferenciaBancaria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                    Master.Titulo = "Home::.Dapesa.Comun.Informes.Credito.ReportesCredito.ReferenciaBancaria";
                    Sesion loSesion = (Sesion)Session["Sesion"];
                    Boolean loPermiso = false;
                    foreach (Permiso llpemiso in loSesion.Usuario.Permiso)
                    {
                        if (llpemiso.Clave == 20)
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
                InformeClientes loClientesDescuentos = new InformeClientes();
                string loFiltrosAdicionales = "Sucursal:   " + ddlSucursales.SelectedItem.ToString() + ".\r"
                                           + ((ddlVendedores.SelectedValue.ToString() == string.Empty) ? string.Empty : ("Vendedor: " + ddlVendedores.SelectedItem.ToString() + ".\r"));
                Sesion loSesion = (Sesion)Session["Sesion"];
                ReferenciaBanco loTrajesMedidda = new ReferenciaBanco();
                loTrajesMedidda.Parameters["FiltrosReporte"].Value = loFiltrosAdicionales;
                loTrajesMedidda.Parameters["Usuario"].Value = loSesion.Usuario.Nombre.ToString();
                loTrajesMedidda.Parameters["FiltrosReporte"].Visible = false;
                loTrajesMedidda.Parameters["Usuario"].Visible = false;
                loTrajesMedidda.DataSource = loClientesDescuentos.ObtenerClientes(
                                    (Sesion)Session["Sesion"],
                                   int.Parse(ddlSucursales.SelectedValue),
                                    ((ddlVendedores.SelectedValue.ToString() == string.Empty) ? null : ddlVendedores.SelectedValue),
                                    ((txtClaveCliente.Text == string.Empty) ? null : txtClaveCliente.Text)
                                    );
                loTrajesMedidda.DataMember = "ReferenciaBancoDataSource";

                if (Session["Permiso"] == null)
                {
                    foreach (Permiso loPermiso in loSesion.Usuario.Permiso)
                    {
                        if (loPermiso.Clave == 20)
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
                        if (loPermiso.Clave == 20)
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

                this.xrInforme.Report = loTrajesMedidda;
                loTrajesMedidda.CreateDocument();
                Page.Session["loInformeReferenciaBancaria"] = loTrajesMedidda;
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
            e.Key = "loInformeReferenciaBancaria";
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