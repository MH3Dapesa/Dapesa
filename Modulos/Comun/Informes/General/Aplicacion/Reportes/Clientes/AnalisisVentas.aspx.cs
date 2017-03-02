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
    public partial class AnalisisVentas : System.Web.UI.Page
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
            ddlMonto.Attributes.Add("onchange", "limpiarMonto()");
        }

        #region Metodos
        protected void EnlazarDatos()
        {
            try
            {
                Sesion loSesion = (Sesion)Session["Sesion"];
                Ventas loAnalisisVentas = new Ventas();
                #region Reporte a Mostrar
                if (rbAgruparVendedor.Checked)
                {
                    InformeVenta loInformeVendedor = new InformeVenta();
                    loInformeVendedor.DataSource = loAnalisisVentas.AnalisisVendedores(
                                    (Sesion)Session["Sesion"],
                                    Convert.ToDateTime(txtFechaInicio.Text),
                                    Convert.ToDateTime(txtFechaFin.Text),
                                    ddlSucursales.SelectedValue.ToString(),
                                    ddlVendedores.SelectedValue.ToString(),
                                    txtClaveCliente.Text,
                                    ddlMarcas.SelectedValue.ToString(),
                                    ddlLineas.SelectedValue.ToString(),
                                    txtArticulo.Text,
                                    ddlMonto.SelectedValue.ToString(),
                                    ((txtMonto.Text.Length > 0) ? int.Parse(txtMonto.Text) : 0)
                                    ); ;
                    loInformeVendedor.DataMember = "VentaDataSource";
                    loInformeVendedor.Parameters["FiltrosReporte"].Value = "Sucursal: " + ddlSucursales.SelectedItem.Text;
                    loInformeVendedor.Parameters["Usuario"].Value = loSesion.Usuario.Nombre.ToString();
                    loInformeVendedor.Parameters["FiltrosReporte"].Visible = false;
                    loInformeVendedor.Parameters["Usuario"].Visible = false;
                    this.xrInforme.Report = loInformeVendedor;
                    loInformeVendedor.CreateDocument();
                    Page.Session["loInformeVentas"] = loInformeVendedor;
                }
                else if (rbAgruparGestor.Checked)
                {
                    InformeVentaGestor loInformeGestor = new InformeVentaGestor();
                    loInformeGestor.DataSource = loAnalisisVentas.AnalisisGestor(
                                    (Sesion)Session["Sesion"],
                                    Convert.ToDateTime(txtFechaInicio.Text),
                                    Convert.ToDateTime(txtFechaFin.Text),
                                    ddlSucursales.SelectedValue.ToString(),
                                    ddlVendedores.SelectedValue.ToString(),
                                    txtClaveCliente.Text,
                                    ddlMarcas.SelectedValue.ToString(),
                                    ddlLineas.SelectedValue.ToString(),
                                    txtArticulo.Text,
                                    ddlMonto.SelectedValue.ToString(),
                                    ((txtMonto.Text.Length > 0) ? int.Parse(txtMonto.Text) : 0)
                                    );
                    loInformeGestor.DataMember = "VentaDataSource";
                    loInformeGestor.Parameters["FiltrosReporte"].Value = "Sucursal: " + ddlSucursales.SelectedItem.Text;
                    loInformeGestor.Parameters["Usuario"].Value = loSesion.Usuario.Nombre.ToString();
                    loInformeGestor.Parameters["FiltrosReporte"].Visible = false;
                    loInformeGestor.Parameters["Usuario"].Visible = false;
                    this.xrInforme.Report = loInformeGestor;
                    loInformeGestor.CreateDocument();
                    Page.Session["loInformeVentas"] = loInformeGestor;
                }
                else if (rbAgruparCliente.Checked)
                {
                    InformeVentaCliente loInformeGestor = new InformeVentaCliente();
                    loInformeGestor.DataSource = loAnalisisVentas.AnalisisCliente(
                                    (Sesion)Session["Sesion"],
                                    Convert.ToDateTime(txtFechaInicio.Text),
                                    Convert.ToDateTime(txtFechaFin.Text),
                                    ddlSucursales.SelectedValue.ToString(),
                                    ddlVendedores.SelectedValue.ToString(),
                                    txtClaveCliente.Text,
                                    ddlMarcas.SelectedValue.ToString(),
                                    ddlLineas.SelectedValue.ToString(),
                                    txtArticulo.Text,
                                    ddlMonto.SelectedValue.ToString(),
                                    ((txtMonto.Text.Length > 0) ? int.Parse(txtMonto.Text) : 0)
                                    ); ;
                    loInformeGestor.DataMember = "VentaDataSource";
                    loInformeGestor.Parameters["FiltrosReporte"].Value = "Sucursal: " + ddlSucursales.SelectedItem.Text;
                    loInformeGestor.Parameters["Usuario"].Value = loSesion.Usuario.Nombre.ToString();
                    loInformeGestor.Parameters["FiltrosReporte"].Visible = false;
                    loInformeGestor.Parameters["Usuario"].Visible = false;
                    this.xrInforme.Report = loInformeGestor;
                    loInformeGestor.CreateDocument();
                    Page.Session["loInformeVentas"] = loInformeGestor;
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