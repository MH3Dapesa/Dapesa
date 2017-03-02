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
using System.Globalization;
using System.Drawing;
using System.Diagnostics;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.UI;
using System.Net.Mail;
using System.Configuration;

namespace Dapesa.Comun.Informes.Credito.IU.ReportesCredito.Clientes
{
    public partial class AntiguedadSaldosGeneral : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                Master.Titulo = "Home::.Dapesa.Comun.Informes.Credito.ReportesCredito.AntigüedadSaldosGeneral";
                Sesion loSesion = (Sesion)Session["Sesion"];
                Boolean loPermiso = false;
                foreach (Permiso llpemiso in loSesion.Usuario.Permiso)
                {
                    if (llpemiso.Clave == 31)
                    {
                        loPermiso = true;
                    }
                }
                if (!loPermiso)
                {
                    Response.Redirect(FormsAuthentication.LoginUrl, true);
                }
            }
            txtClaveCliente.Attributes.Add("onkeypress", "javascript: return ValidarEspacio(event,this)");
            txtDiasPeriodo.Attributes.Add("onkeypress", "javascript: return ValidarEspacio(event,this)");
            txtDiasPeriodo.Attributes.Add("PlaceHolder", "10");
        }

        #region Metodos
        protected void EnlazarDatos()
        {
            try
            {
                #region Concentrado general
                Sesion loSesion = (Sesion)Session["Sesion"];
                InformeClientes loAntiguedad = new InformeClientes();
                InformeAntiguedadSaldosGeneral loAntiguedadSaldos = new InformeAntiguedadSaldosGeneral();
                CrearInforme(loAntiguedadSaldos, loAntiguedad,
                                    loAntiguedad.ObtenerAntiguedadSaldosGeneral(
                                   (Sesion)Session["Sesion"],
                                   int.Parse(ddlSucursales.SelectedValue),
                                   DateTime.Parse(txtFechaInicio.Text),
                                   ((string.IsNullOrEmpty(txtDiasPeriodo.Text)) ? 10 : int.Parse(txtDiasPeriodo.Text)),
                                   int.Parse(ddlTipoFecha.SelectedValue.ToString()),
                                   Convert.ToInt32(cbDiasAdicionales.Checked),
                                   ((ddlGestores.SelectedValue.ToString() == string.Empty) ? null : ddlGestores.SelectedValue),
                                   ((txtClaveCliente.Text == string.Empty) ? null : txtClaveCliente.Text),
                                   -1
                                   ),
                                   "CONCENTRADO ANTIGÜEDAD DE SALDOS DE CLIENTES",
                                   loSesion);
                #endregion

                #region Concentrado por auxiliar
                InformeClientes loAuxiliarAntiguedad = new InformeClientes();
                DataTable loAuxiliarResultado = loAuxiliarAntiguedad.ObtenerAntiguedadSaldosAuxiliar(
                                   (Sesion)Session["Sesion"],
                                   int.Parse(ddlSucursales.SelectedValue),
                                   DateTime.Parse(txtFechaInicio.Text),
                                   ((string.IsNullOrEmpty(txtDiasPeriodo.Text)) ? 10 : int.Parse(txtDiasPeriodo.Text)),
                                   int.Parse(ddlTipoFecha.SelectedValue.ToString()),
                                   Convert.ToInt32(cbDiasAdicionales.Checked),
                                   ((ddlGestores.SelectedValue.ToString() == string.Empty) ? null : ddlGestores.SelectedValue),
                                   ((txtClaveCliente.Text == string.Empty) ? null : txtClaveCliente.Text),
                                   -1
                                   );
                InformeAntiguedadSaldoAuxiliar loAntiguedadSaldosAuxiliar = new InformeAntiguedadSaldoAuxiliar();
                CrearInforme(loAntiguedadSaldosAuxiliar, loAuxiliarAntiguedad,
                                   loAuxiliarResultado,
                                   "CONCENTRADO ANTIGÜEDAD DE SALDOS DE CLIENTES POR AUXILIAR",
                                   loSesion);
                #endregion

                if (Session["Permiso"] == null)
                {
                    foreach (Permiso loPermiso in loSesion.Usuario.Permiso)
                    {
                        if (loPermiso.Clave == 31)
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
                        if (loPermiso.Clave == 31)
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
                loAntiguedadSaldos.Pages.AddRange(loAntiguedadSaldosAuxiliar.Pages);
                loAntiguedadSaldos.PrintingSystem.ContinuousPageNumbering = true;
                loAntiguedadSaldos.ExportOptions.Xlsx.ExportMode = DevExpress.XtraPrinting.XlsxExportMode.SingleFilePageByPage;
                xrInforme.Report = loAntiguedadSaldos;
                Page.Session["loInformeAntiguedadSaldosGeneral"] = loAntiguedadSaldos;

                if (cbEnviarCorreo.Checked)
                    AgruparPorAuxiliar(loAuxiliarResultado, loSesion);
            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
        }


        private void CrearInforme(XtraReport poInforme, InformeClientes poClientes, DataTable poAntiguedad, string poTituloReporte, Sesion poSesion)
        {
            poInforme.Watermark.Text = (poClientes.ObtenerClienteSinAsignar(poSesion, int.Parse(ddlSucursales.SelectedValue)) > 0 ? "CLIENTES SIN ASIGNAR" : "");
            poInforme.Watermark.Font = new Font(poInforme.Watermark.Font.FontFamily, 50);
            poInforme.Watermark.ForeColor = Color.DodgerBlue;
            poInforme.PrintingSystem.Watermark.ShowBehind = true;
            poInforme.Watermark.TextTransparency = 150;
            poInforme.Parameters["Sucursal"].Value = ddlSucursales.SelectedItem.ToString();
            poInforme.Parameters["FechaCorte"].Value = txtFechaInicio.Text;
            poInforme.Parameters["TipoFecha"].Value = ddlTipoFecha.SelectedItem.ToString();
            poInforme.Parameters["DiasAdicionales"].Value = (bool)cbDiasAdicionales.Checked;
            poInforme.Parameters["DiasVencido"].Value = ((string.IsNullOrEmpty(txtDiasPeriodo.Text)) ? 10 : int.Parse(txtDiasPeriodo.Text));
            poInforme.Parameters["Usuario"].Value = poSesion.Usuario.Nombre;
            poInforme.Parameters["TituloReporte"].Value = poTituloReporte;
            poInforme.DataSource = poAntiguedad;
            poInforme.DataMember = "DataSourceAntiguedadSaldos";
            poInforme.CreateDocument();
        }

        private void EnviarCorreo(MemoryStream poDocumento, string loEmailPersonal)
        {
            if (string.IsNullOrEmpty(loEmailPersonal))
                return;
            Attachment loAgregarPdf = new Attachment(poDocumento, "CONCENTRADO ANTIGUEDAD - " + DateTime.Now.ToString("dd-mm-yyyy") + ".pdf", "application/pdf");
            MailMessage loEmail = new MailMessage();
            loEmail.To.Add(new MailAddress(loEmailPersonal));

            loEmail.Attachments.Add(loAgregarPdf);
            loEmail.From = new MailAddress(ConfigurationManager.AppSettings["CorreoCuenta"]);
            loEmail.Subject = ConfigurationManager.AppSettings["CorreoAsunto"];
            loEmail.Body = "Se anexa el concentrado antigüedad de saldos por auxiliar correspondiente al día " + DateTime.Now.ToShortDateString().ToString();

            SmtpClient cliente = new SmtpClient("smtp.dapesa.com.mx", 25);
            using (cliente)
            {
                cliente.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["CorreoCuenta"], ConfigurationManager.AppSettings["CorreoCP"]);
                cliente.EnableSsl = false;
                cliente.Send(loEmail);
            }
        }

        private bool AgruparPorAuxiliar(DataTable poAuxiliarResultado, Sesion poSesion)
        {
            try
            {
                DataTable loPersonal = new DataTable();
                loPersonal = poAuxiliarResultado.DefaultView.ToTable(true, "CVE_PERSONAL");

                foreach (DataRow poEmailPersonal in loPersonal.Rows)
                {
                    if (poEmailPersonal[0] != DBNull.Value)
                    {
                        DataSet loClientesPersonal = new DataSet();
                        loClientesPersonal.Merge(poAuxiliarResultado.Select("CVE_PERSONAL = " + poEmailPersonal[0]));

                        if (loClientesPersonal.Tables.Count > 0)
                        {
                            InformeClientes poAuxiliarAntiguedad = new InformeClientes();
                            InformeAntiguedadSaldoAuxiliar poAntiguedadAuxiliar = new InformeAntiguedadSaldoAuxiliar();
                            CrearInforme(poAntiguedadAuxiliar, poAuxiliarAntiguedad, loClientesPersonal.Tables[0], "CONCENTRADO ANTIGÜEDAD DE SALDOS DE CLIENTES POR AUXILIAR", poSesion);
                            MemoryStream poDocumento = new MemoryStream();
                            poAntiguedadAuxiliar.ExportToPdf(poDocumento);
                            poDocumento.Seek(0, System.IO.SeekOrigin.Begin);

                            EnviarCorreo(poDocumento,
                                        poAuxiliarAntiguedad.ObtenerEmailPersonal(poSesion, int.Parse(poEmailPersonal[0].ToString())).Rows[0][0].ToString());
                            poDocumento.Close();
                            poDocumento.Flush();
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
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
            e.Key = "loInformeAntiguedadSaldosGeneral";
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