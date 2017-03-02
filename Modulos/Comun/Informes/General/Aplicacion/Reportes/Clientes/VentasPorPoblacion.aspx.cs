using Dapesa.Comun.Informes.General.IU.Reportes.Informes.Clientes;
using Dapesa.Comun.Informes.General.Reglas;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dapesa.Comun.Informes.General.IU.Reportes.Clientes
{
    public partial class VentasPorPoblacion : System.Web.UI.Page
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
                    if (llpemiso.Clave == 21)
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
                Ventas loAnalisisVentas = new Ventas();
                InformeVentasPorPoblacion loInformeVendedor = new InformeVentasPorPoblacion();
                loInformeVendedor.DataSource = loAnalisisVentas.AnalisisVentasPorPoblacion(
                                (Sesion)Session["Sesion"],
                                Convert.ToDateTime("1/" + txtFechaInicio.Text),
                                Convert.ToDateTime("30/" + txtFechaFin.Text),
                                ddlSucursales.SelectedValue.ToString(),
                                ddlVendedores.SelectedValue.ToString(),
                                txtClaveCliente.Text,
                                ddlMarcas.SelectedValue.ToString(),
                                ddlLineas.SelectedValue.ToString(),
                                txtArticulo.Text
                                );
                loInformeVendedor.DataMember = "VentaPoblacionDataSource";

                loInformeVendedor.Parameters["FiltrosReporte"].Value = "Sucursal: " + ddlSucursales.SelectedItem.Text;
                loInformeVendedor.Parameters["Usuario"].Value = loSesion.Usuario.Nombre.ToString();
                loInformeVendedor.Parameters["FechaInicial"].Value = "01/" + txtFechaInicio.Text;
                loInformeVendedor.Parameters["FechaFinal"].Value = "30/" + txtFechaFin.Text;
                loInformeVendedor.Parameters["FiltrosReporte"].Visible = false;
                loInformeVendedor.Parameters["Usuario"].Visible = false;
                loInformeVendedor.Parameters["FechaInicial"].Visible = false;
                loInformeVendedor.Parameters["FechaFinal"].Visible = false;

                this.xrInforme.Report = loInformeVendedor;
                loInformeVendedor.CreateDocument();
                Page.Session["loInformeVentasPorPoblacion"] = loInformeVendedor;
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
            e.Key = "loInformeVentasPorPoblacion";
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