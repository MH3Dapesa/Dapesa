using Dapesa.Almacen.Pedidos.IU.Mensajero.Rdl;
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
using Ventas.Pedidos.BackOrder.Reglas;
using Ventas.Pedidos.BackOrder.UI.Pedidos.Reportes;
using System.Diagnostics;
using System.IO;
using DevExpress.XtraReports.Web;

namespace Ventas.Pedidos.BackOrder.UI.Pedidos
{
    public partial class Exportar : System.Web.UI.Page
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
                    if (llpemiso.Clave == 14)
                    {
                        loPermiso = true;
                        CrearReporte();
                    }
                }
                if (!loPermiso)
                {
                    Response.Redirect(FormsAuthentication.LoginUrl, true);
                }
            }
        }

        protected void CrearReporte()
        {
            try
            {
                Sesion loSesion = (Sesion)Session["Sesion"];
                #region Asignar permiso de imprimir y guardar
                if (Session["Permiso"] == null)
                {
                    foreach (Permiso loPermiso in loSesion.Usuario.Permiso)
                    {
                        if (loPermiso.Clave == 14)
                        {
                            foreach (Dapesa.Seguridad.Comun.Definiciones.TipoPermiso loTipoEmelento in loPermiso.TipoPermiso)
                            {
                                if (loTipoEmelento.ToString() == "Guardar")
                                {
                                    InformeVistaEstandar objReport = new InformeVistaEstandar();
                                    objReport.DataSource = (DataTable)ViewState["loResultado"];
                                    objReport.DataMember = "DataSourceBackOrderPedido";
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
                                    objReport.CreateDocument();
                                    this.xrInforme.Report = objReport;
                                    break;
                                }
                            }
                            break;
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
    }

}