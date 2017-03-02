using Dapesa.Comun.Informes.General.IU.Reportes.Clientes;
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


namespace Dapesa.Comun.Informes.General.IU.Reportes.Clientes
{
    public partial class VentasMarcaLinea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                Master.Titulo = "Home::.Dapesa.Comun.Informes.General.Reportes.VentasPorPoblación";
                Sesion loSesion = (Sesion)Session["Sesion"];
                Boolean loPermiso = false;
                foreach (Permiso llpemiso in loSesion.Usuario.Permiso)
                {
                    if (llpemiso.Clave == 24)
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
                Ventas loVentas = new Ventas();
                string loFiltrosAdicionales = "Sucursal:   " + ((string.IsNullOrEmpty(ddlSucursales.SelectedItem.ToString())) ? "GRUPO DAPESA" : ddlSucursales.SelectedItem.ToString()) + ".\r"
                                           + ((txtArticulo.Text == string.Empty) ? string.Empty : ("Articulo: " + txtArticulo.Text + ".\r"))
                                           + ((ddlLineas.SelectedItem.ToString() == string.Empty) ? string.Empty : ("Línea: " + ddlLineas.SelectedItem.ToString() + ".\r"))
                                           + ((ddlMarcas.SelectedItem.ToString() == string.Empty) ? string.Empty : ("Marca: " + ddlMarcas.SelectedItem.ToString() + ".\r"));
                Sesion loSesion = (Sesion)Session["Sesion"];
                InformeVentaMarcaLinea loTrajesMedidda = new InformeVentaMarcaLinea();
                loTrajesMedidda.Parameters["FiltrosReporte"].Value = loFiltrosAdicionales;
                loTrajesMedidda.Parameters["Usuario"].Value = loSesion.Usuario.Nombre.ToString();
                loTrajesMedidda.Parameters["FiltrosReporte"].Visible = false;
                loTrajesMedidda.Parameters["Usuario"].Visible = false;
                loTrajesMedidda.DataSource = loVentas.VentasMarcaLinea(
                                    (Sesion)Session["Sesion"],
                                    ddlSucursales.SelectedValue.ToString(),
                                    DateTime.Parse(txtFechaInicio.Text),
                                    DateTime.Parse(txtFechaFin.Text),
                                    ddlMarcas.SelectedValue.ToString(),
                                    ddlLineas.SelectedValue.ToString(),
                                    txtArticulo.Text,
                                    cbMostrarVenta.Checked
                                    );
                loTrajesMedidda.DataMember = "VentasMarcaLineaDataSource";
                #region Asignar permiso de imprimir y guardar
                if (Session["Permiso"] == null)
                {
                    foreach (Permiso loPermiso in loSesion.Usuario.Permiso)
                    {
                        if (loPermiso.Clave == 24)
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
                        if (loPermiso.Clave == 24)
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
                this.xrInforme.Report = loTrajesMedidda;
                loTrajesMedidda.CreateDocument();
                Page.Session["loInformeVentaMarcaLinea"] = loTrajesMedidda;
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
            e.Key = "loInformeVentaMarcaLinea";
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