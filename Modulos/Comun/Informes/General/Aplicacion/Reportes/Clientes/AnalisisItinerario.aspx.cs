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
using System.Globalization;

namespace Dapesa.Comun.Informes.General.IU.Reportes.Clientes
{
    public partial class AnalisisItinerario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                Master.Titulo = "Home::.Dapesa.Comun.Informes.General.Reportes.AnalisisItinerario";
                Sesion loSesion = (Sesion)Session["Sesion"];
                Boolean loPermiso = false;
                foreach (Permiso llpemiso in loSesion.Usuario.Permiso)
                {
                    if (llpemiso.Clave == 25)
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
                #region Calcular semana considerando año bisiesto.

                int pnAnioMonstrado = DateTime.Now.Year;
                int pnSemanaMostrada;
                DateTime loFecha = DateTime.Parse(txtFechaInicio.Text);
                DayOfWeek loDia = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(loFecha);
                if (loDia >= DayOfWeek.Monday && loDia <= DayOfWeek.Wednesday)
                {
                    loFecha = loFecha.AddDays(3);
                }
                pnSemanaMostrada = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(loFecha, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

                #endregion

                Ventas loVentas = new Ventas();
                Sesion loSesion = (Sesion)Session["Sesion"];
                InformeItinerario loItinerario = new InformeItinerario();
                DataTable loItinerarioVenta = loVentas.ObtenerItineario(
                                    (Sesion)Session["Sesion"],
                                    int.Parse(ddlTelemarketings.SelectedValue),
                                    int.Parse(ddlSucursales.SelectedValue),
                                    pnAnioMonstrado,
                                    pnSemanaMostrada
                                    );
                DataTable loTotalSemanal = loVentas.ObtenerTotalSemanal(
                                    (Sesion)Session["Sesion"],
                                    int.Parse(ddlTelemarketings.SelectedValue),
                                    loFecha.AddDays(1 - (((int)loFecha.DayOfWeek) == 0 ? 7 : (int)loFecha.DayOfWeek)),
                                    loFecha.AddDays(1 - (((int)loFecha.DayOfWeek) == 0 ? 7 : (int)loFecha.DayOfWeek)).AddDays(-6));
                DataSet loFuenteDatos = new DataSet();
                loFuenteDatos.DataSetName = "DataSourceItinerario";
                loFuenteDatos.Tables.Add(loItinerarioVenta);
                loFuenteDatos.Tables[0].TableName = "ITINERARIO_VENTA";
                loFuenteDatos.Tables.Add(loTotalSemanal);
                loFuenteDatos.Tables[1].TableName = "TOTAL_X_SEMANA";
                loFuenteDatos.AcceptChanges();

                loItinerario.DataMember = "DataSourceItinerario";
                loItinerario.DataSource = loFuenteDatos;
                loItinerario.FillDataSource();

                loItinerario.Parameters["psSucursal"].Value = ddlSucursales.SelectedItem;
                loItinerario.Parameters["psTelemarketing"].Value = ddlTelemarketings.SelectedItem;
                loItinerario.Parameters["psPeriodo"].Value = "SEMANA: " + pnSemanaMostrada.ToString()
                                    + ", FECHA: "
                                    + loFecha.AddDays(1 - (((int)loFecha.DayOfWeek) == 0 ? 7 : (int)loFecha.DayOfWeek)).ToShortDateString()
                                    + " - "
                                    + loFecha.AddDays((1 - (((int)loFecha.DayOfWeek) == 0 ? 7 : (int)loFecha.DayOfWeek)) + 5).ToShortDateString();
                loItinerario.Parameters["psSucursal"].Visible = false;
                loItinerario.Parameters["psTelemarketing"].Visible = false;
                loItinerario.Parameters["psPeriodo"].Visible = false;


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
                this.xrInforme.Report = loItinerario;
                loItinerario.CreateDocument();
                Page.Session["loInformeItinerario"] = loItinerario;
                CargarTotalesVenta(loTotalSemanal);
            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
        }
        protected void CargarTotalesVenta(DataTable loTotalSemanal)
        {
            gvTotalesTLMK.DataSource = loTotalSemanal;
            gvTotalesTLMK.DataBind();
            gvTotalesTLMK.CssClass = "gvTotalesTLMK";
            UpTotalesTLMK.Update();
        }
        #endregion

        #region Eventos
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            EnlazarDatos();
        }

        protected void xrInforme_CacheReportDocument(object sender, DevExpress.XtraReports.Web.CacheReportDocumentEventArgs e)
        {
            e.Key = "loInformeItinerario";
            Page.Session[e.Key] = e.SaveDocumentToMemoryStream();
        }

        protected void xrInforme_RestoreReportDocumentFromCache(object sender, DevExpress.XtraReports.Web.RestoreReportDocumentFromCacheEventArgs e)
        {

            Stream stream = Page.Session[e.Key] as Stream;
            if (stream != null)
                e.RestoreDocumentFromStream(stream);

        }

        protected void gvTotalesTLMK_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Text = decimal.Parse(e.Row.Cells[1].Text).ToString("N2", new System.Globalization.CultureInfo("es-MX"));
                e.Row.Cells[2].Text = decimal.Parse(e.Row.Cells[2].Text).ToString("N2", new System.Globalization.CultureInfo("es-MX"));
                e.Row.Cells[3].Text = decimal.Parse(e.Row.Cells[3].Text).ToString("N2", new System.Globalization.CultureInfo("es-MX"));
                e.Row.Cells[4].Text = decimal.Parse(e.Row.Cells[4].Text).ToString("N2", new System.Globalization.CultureInfo("es-MX"));
                e.Row.Cells[5].Text = decimal.Parse(e.Row.Cells[5].Text).ToString("N2", new System.Globalization.CultureInfo("es-MX"));
                e.Row.Cells[6].Text = decimal.Parse(e.Row.Cells[6].Text).ToString("N2", new System.Globalization.CultureInfo("es-MX"));
                e.Row.Cells[1].CssClass = "gvVentaTLMK";
                e.Row.Cells[2].CssClass = "gvVentaTLMK";
                e.Row.Cells[3].CssClass = "gvVentaTLMK";
                e.Row.Cells[4].CssClass = "gvVentaTLMK";
                e.Row.Cells[5].CssClass = "gvVentaTLMK";
                e.Row.Cells[6].CssClass = "gvVentaTLMK";
                e.Row.Cells[0].Width = 180;
            }
        }
        #endregion
        
    }

}