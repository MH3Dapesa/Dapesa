using Dapesa.Comun.Informes.Entidades;
using Dapesa.Comun.Informes.Reglas;
using Dapesa.Informes.Reglas;
using Dapesa.Informes.Entidades;
using Dapesa.Comun.Utilerias;
using Dapesa.Seguridad.Entidades;
using Microsoft.Reporting.WebForms;
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;

using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Management;
using System.Web.UI.WebControls;


namespace Dapesa.Comun.Informes.IU.Reporteador
{
    public partial class Analisis : Page, IReporteador
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                //Validar su el usuario tiene permiso para esta pagina
                //Permiso: CLAVE=4
                Sesion loSesion = (Sesion)Session["Sesion"];
                bool lbPermirtir = false;
                foreach (Permiso llpemiso in loSesion.Usuario.Permiso)
                {
                    if (llpemiso.Clave == 4)
                    {
                        lbPermirtir = true;
                    }
                    if(llpemiso.Clave == 7)
                    {
                        btnImprimir.Visible = true;
                    }
                }

                if (lbPermirtir)
                {
                    Catalogos loCatalogos = new Catalogos();
                    ddlMarcas.DataSource = loCatalogos.ObtenerMarcas((Sesion)Session["Sesion"], 1);
                    ddlMarcas.DataBind();
                    Master.Titulo = "Análisis::.Dapesa.Comun.Informes.Reporteador.Ventas";

                    ViewState["dtCuerpo"] = new DataTable();
                    ViewState["dtEncabezado"] = new DataTable();
                     ViewState["parametros"] = new ReportParameter();
                    ViewState["NivelReporte"] = 0;
                    ViewState["Contenido"] = 0;
                }
                else
                {
                    Response.Redirect(FormsAuthentication.LoginUrl, true);
                }
            }

            lblMsg.Text = "";
            lblMsg.Visible = false;
            UpMensajes.Update();
            ddlSucursales.Focus();
        }

        #region Eventos

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            this.EnlazarDatos();
        }

        protected void rvVenta_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            Ventas loVentas = new Ventas();

            try
            {
                #region Mostrar detalles

                string lsClaveCliente = ((LocalReport)e.Report).OriginalParametersToDrillthrough[0].Values[0];
                bool lbDecremento = ckDecremento.Checked;
                ReportParameter[] parametros = new ReportParameter[3];
                parametros[0] = new ReportParameter("pDecremento", "true");

                if (lbDecremento)
                { parametros[0].Values[0] = "true"; }
                else
                {
                    parametros[0].Values[0] = "false";
                }

                if (e.ReportPath == Comun.Definiciones.TipoSubreporte.Detalle.Descripcion())
                {
                    ((LocalReport)e.Report).ReportPath = "Informes/Ventas/" + e.ReportPath + ".rdl";
                    ((LocalReport)e.Report).ReportEmbeddedResource = "Informes/Ventas/" + e.ReportPath + ".rdl";
                    ((LocalReport)e.Report).DisplayName = "MarcasConDecremento_Cte-" + lsClaveCliente + "_" + ddlSucursales.SelectedItem.Text.Split('(')[1].Split(')')[0];
                    ViewState["dtCuerpo"] = loVentas.ObtenerAnalisisAnualMarcas((Sesion)Session["Sesion"], lsClaveCliente, ddlMarcas.SelectedValue);
                    ((LocalReport)e.Report).DataSources.Add(new ReportDataSource("dsVentaDetalle", (DataTable)ViewState["dtCuerpo"]));
                    ViewState["NivelReporte"] = 1;
                    ((LocalReport)e.Report).SetParameters((ReportParameter[])ViewState["parametros"]);
                    //Despues de llenar el Reporte recolectar parametros para pasarlos al de impresion
                    parametros[1] = new ReportParameter("pClaveCliente", lsClaveCliente);
                    parametros[2] = new ReportParameter("pCliente", ((LocalReport)e.Report).OriginalParametersToDrillthrough[1].Values[0]);
                    ViewState["parametros"] = parametros; 
                    ((LocalReport)e.Report).Refresh();
                    ViewState["Contenido"] = 1;
                }
                else if (e.ReportPath == Comun.Definiciones.TipoSubreporte.DetalleMarca.Descripcion())
                {
                    string lsClaveMarca = ((LocalReport)e.Report).OriginalParametersToDrillthrough[1].Values[0];
                    ((LocalReport)e.Report).ReportPath = "Informes/Ventas/" + e.ReportPath + ".rdl";
                    ((LocalReport)e.Report).ReportEmbeddedResource = "Informes/Ventas/" + e.ReportPath + ".rdl";
                    ((LocalReport)e.Report).DisplayName = "LineasConDecremento_Cte-" + lsClaveCliente + "_" + ddlSucursales.SelectedItem.Text.Split('(')[1].Split(')')[0];
                    ViewState["dtCuerpo"] = loVentas.ObtenerAnalisisAnualLineas((Sesion)Session["Sesion"], lsClaveCliente, lsClaveMarca);
                    ((LocalReport)e.Report).DataSources.Add(new ReportDataSource("dsVentaDetalle", (DataTable)ViewState["dtCuerpo"]));
                    ViewState["NivelReporte"] = 2;
                    ((LocalReport)e.Report).SetParameters((ReportParameter[])ViewState["parametros"]);
                    parametros[1] = new ReportParameter("pCliente", ((LocalReport)e.Report).OriginalParametersToDrillthrough[2].Values[0]);
                    parametros[2] = new ReportParameter("pMarca", ((LocalReport)e.Report).OriginalParametersToDrillthrough[3].Values[0]);
                    ViewState["parametros"] = parametros;
                    ((LocalReport)e.Report).Refresh();
                    ViewState["Contenido"] = 1;
                }
                else if (e.ReportPath == Comun.Definiciones.TipoSubreporte.DetalleLinea.Descripcion())
                {
                    string lsClaveLinea = ((LocalReport)e.Report).OriginalParametersToDrillthrough[1].Values[0];
                    ((LocalReport)e.Report).ReportPath = "Informes/Ventas/" + e.ReportPath + ".rdl";
                    ((LocalReport)e.Report).ReportEmbeddedResource = "Informes/Ventas/" + e.ReportPath + ".rdl";
                    ((LocalReport)e.Report).DisplayName = "ArticulosConDecremento_Cte-" + lsClaveLinea + "_" + ddlSucursales.SelectedItem.Text.Split('(')[1].Split(')')[0];
                    ViewState["dtCuerpo"] =loVentas.ObtenerAnalisisAnualArticulos((Sesion)Session["Sesion"], lsClaveCliente, lsClaveLinea);
                    ((LocalReport)e.Report).DataSources.Add(new ReportDataSource("dsVentaDetalle", (DataTable)ViewState["dtCuerpo"]));
                    ViewState["NivelReporte"] = 3;
                    parametros[1] = new ReportParameter("pCliente", ((LocalReport)e.Report).OriginalParametersToDrillthrough[2].Values[0]);
                    parametros[2] = new ReportParameter("pLinea", ((LocalReport)e.Report).OriginalParametersToDrillthrough[3].Values[0]);
                    ViewState["parametros"] = parametros;
                    ((LocalReport)e.Report).SetParameters((ReportParameter[])ViewState["parametros"]);
                    ((LocalReport)e.Report).Refresh();
                    ViewState["Contenido"] = 1;
                }
                else if (e.ReportPath == Comun.Definiciones.TipoSubreporte.MInac.Descripcion())
                {
                    string lsEstatus = ((LocalReport)e.Report).OriginalParametersToDrillthrough[1].Values[0];

                    if (lsEstatus == Comun.Definiciones.TipoEstatusCliente.Inactivo.Descripcion())
                    {
                        Cliente loCliente = loVentas.ObtenerAnalisisAnualMotivosInac((Sesion)Session["Sesion"], lsClaveCliente);

                        lblCliente.Text = lsClaveCliente + "-" + loCliente.Nombre;
                        lblMotivosInac.Text = loCliente.MotivosInac;
                        lblFechaInac.Text = (loCliente.FechaInac == DateTime.MinValue) ? string.Empty : loCliente.FechaInac.ToString("dd/MM/yyyy");
                        mpeMotivosInac.Show();
                        upPanelVenta.Update();
                    }

                    e.Cancel = true;
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

        #region Metodos

        public void EnlazarDatos()
        {

            if (string.IsNullOrEmpty(ddlSucursales.SelectedValue))
                return;

            bool lbMostrarClientesEliminados = ckClientesEliminados.Checked;
            Reglas.Comun loComun = new Reglas.Comun();
            Ventas loVentas = new Ventas();

            try
            {
                rvVenta.Reset();
                rvVenta.LocalReport.ReportPath = "Informes/Ventas/Analisis.rdl";
                rvVenta.LocalReport.ReportEmbeddedResource = "Informes/Ventas/Analisis.rdl";
                rvVenta.LocalReport.DisplayName = "AnalisisClientesConDecremento_" +
                    DateTime.Now.Year + "-" + (DateTime.Now.Year - 3) + "_" + ddlSucursales.SelectedItem.Text.Split('(')[1].Split(')')[0] +
                    ((string.IsNullOrEmpty(ddlVendedores.SelectedValue)) ? string.Empty : "_V-" + ddlVendedores.SelectedValue) +
                    ((string.IsNullOrEmpty(ddlMarcas.SelectedValue)) ? string.Empty : "_M-" + ddlMarcas.SelectedValue);

                ViewState["dtCuerpo"] = loVentas.ObtenerAnalisisAnual((Sesion)Session["Sesion"], ddlSucursales.SelectedValue, ddlVendedores.SelectedValue, ddlMarcas.SelectedValue, lbMostrarClientesEliminados);
                rvVenta.LocalReport.DataSources.Add(new ReportDataSource("dsVenta", (DataTable)ViewState["dtCuerpo"]));

                ViewState["dtEncabezado"] = loComun.ObtenerEncabezado(
                        "Sucursal: " + ddlSucursales.SelectedItem.Text +
                        ((string.IsNullOrEmpty(ddlVendedores.SelectedValue)) ? string.Empty : ", Vendedor: " + ddlVendedores.SelectedItem.Text) +
                        ((string.IsNullOrEmpty(ddlMarcas.SelectedValue)) ? string.Empty : ", Marca: " + ddlMarcas.SelectedItem.Text),
                        (DateTime.Now.Year - 3) + "-" + DateTime.Now.Year);
                rvVenta.LocalReport.DataSources.Add(new ReportDataSource("dsEncabezado", (DataTable)ViewState["dtEncabezado"]));

                bool lbDecremento = ckDecremento.Checked;
                ReportParameter[] parametros = new ReportParameter[1];
                parametros[0] = new ReportParameter("pDecremento", "true");

                if (lbDecremento)
                { parametros[0].Values[0] = "true"; }
                else
                {
                    parametros[0].Values[0] = "false";
                }

                ViewState["parametros"] = parametros;
                ViewState["NivelReporte"] = 0;
                rvVenta.LocalReport.SetParameters((ReportParameter[])ViewState["parametros"]);
                rvVenta.LocalReport.Refresh();
                ViewState["Contenido"] = 1;
            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
        }

        #endregion

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
          
            if (int.Parse(ddlSucursales.SelectedValue) > 0)
            {
                lblMsg.Text = "";
                Imprimir();
            }
        }

        public void Imprimir()
        {
            try
            {
                if ((int)ViewState["Contenido"] == 1)
                {
                    Rendizador loRendizador = new Rendizador();
                    int lnNivelReporte = (int)ViewState["NivelReporte"];
                    //object[] laparametros =  (object[])ViewState["parametros"];
                    ReportParameter[] laparametros = (ReportParameter[])ViewState["parametros"];
                    DataSet loFuenteDatos = new DataSet();
                    //string lsimpresora = GetImpresoraDefecto();
                    string lsimpresora = "";
                    lsimpresora = ConfigurationManager.AppSettings[((Sesion)HttpContext.Current.Session["Sesion"]).Usuario.Clave];
                    //Label1.Text = lsimpresora;
                    //UpdatePanel1.Update();

                    if (lnNivelReporte == 0)
                    {
                        Informe loInforme = new Informe()
                        {
                            //Ancho = 21.6,
                            //Alto = 27.9,
                            //Ancho = 37,
                            //Alto = 21.59,
                            Ancho = 42,
                            Alto = 28.59,
                            MargenIzquierdo = 1,
                            MargenDerecho = 1,
                            MargenSuperior = 1,
                            MargenInferior = 1,
                            Impresora = lsimpresora,
                            //Copias = 1,
                            Extension = "rdl",
                            Formato = Dapesa.Informes.Comun.Definiciones.TipoFormato.EMF,
                            Nombre = "Analisis",
                            Salida = Dapesa.Informes.Comun.Definiciones.TipoSalida.Impresion,
                            Tipo = Dapesa.Informes.Comun.Definiciones.TipoInforme.Web,
                            Ubicacion = Server.MapPath("~/Informes/Ventas/"),
                            Parametros = laparametros
                            //UnidadMedida = Dapesa.Informes.Comun.Definiciones.TipoUnidaMedida.Centimetros
                        };

                        loFuenteDatos.Tables.Add((DataTable)ViewState["dtCuerpo"]);
                        loFuenteDatos.Tables[0].TableName = "dsVenta";
                        loFuenteDatos.Tables.Add((DataTable)ViewState["dtEncabezado"]);
                        loFuenteDatos.Tables[1].TableName = "dsEncabezado";
                        loRendizador.Presentar(loInforme, loFuenteDatos);
                    }
                    else if (lnNivelReporte == 1)
                    {
                        Informe loInforme = new Informe()
                        {
                            Ancho = 33.96,
                            Alto = 21.59,
                            MargenIzquierdo = 1,
                            MargenDerecho = 1,
                            MargenSuperior = 1,
                            MargenInferior = 1,
                            Impresora = lsimpresora,
                            Extension = "rdl",
                            Formato = Dapesa.Informes.Comun.Definiciones.TipoFormato.EMF,
                            Nombre = "AnalisisDetalle",
                            Salida = Dapesa.Informes.Comun.Definiciones.TipoSalida.Impresion,
                            Tipo = Dapesa.Informes.Comun.Definiciones.TipoInforme.Web,
                            Ubicacion = Server.MapPath("~/Informes/Ventas/"),
                            Parametros = laparametros
                        };

                        loFuenteDatos.Tables.Add((DataTable)ViewState["dtCuerpo"]);
                        loFuenteDatos.Tables[0].TableName = "dsVentaDetalle";
                        //loFuenteDatos.Tables.Add((DataTable)ViewState["dtEncabezado"]);
                        //loFuenteDatos.Tables[1].TableName = "dsEncabezado";
                        loRendizador.Presentar(loInforme, loFuenteDatos);
                    }
                    else if (lnNivelReporte == 2)
                    {
                        Informe loInforme = new Informe()
                        {
                            Ancho = 33.96,
                            Alto = 21.59,
                            MargenIzquierdo = 1,
                            MargenDerecho = 1,
                            MargenSuperior = 1,
                            MargenInferior = 1,
                            Impresora = lsimpresora,
                            Extension = "rdl",
                            Formato = Dapesa.Informes.Comun.Definiciones.TipoFormato.EMF,
                            Nombre = "AnalisisMarca",
                            Salida = Dapesa.Informes.Comun.Definiciones.TipoSalida.Impresion,
                            Tipo = Dapesa.Informes.Comun.Definiciones.TipoInforme.Web,
                            Ubicacion = Server.MapPath("~/Informes/Ventas/"),
                            Parametros = laparametros
                        };

                        loFuenteDatos.Tables.Add((DataTable)ViewState["dtCuerpo"]);
                        loFuenteDatos.Tables[0].TableName = "dsVentaDetalle";
                        loRendizador.Presentar(loInforme, loFuenteDatos);
                    }

                    else if (lnNivelReporte == 3)
                    {
                        Informe loInforme = new Informe()
                        {
                            Ancho = 37,
                            Alto = 21.59,
                            MargenIzquierdo = 1,
                            MargenDerecho = 1,
                            MargenSuperior = 1,
                            MargenInferior = 1,
                            Impresora = lsimpresora,
                            Extension = "rdl",
                            Formato = Dapesa.Informes.Comun.Definiciones.TipoFormato.EMF,
                            Nombre = "AnalisisLinea",
                            Salida = Dapesa.Informes.Comun.Definiciones.TipoSalida.Impresion,
                            Tipo = Dapesa.Informes.Comun.Definiciones.TipoInforme.Web,
                            Ubicacion = Server.MapPath("~/Informes/Ventas/"),
                            Parametros = laparametros
                        };

                        loFuenteDatos.Tables.Add((DataTable)ViewState["dtCuerpo"]);
                        loFuenteDatos.Tables[0].TableName = "dsVentaDetalle";
                        loRendizador.Presentar(loInforme, loFuenteDatos);
                    }

                    //#region add rows, if necessary
                    //((DataTable)ViewState["Consignatario"]).Rows[0]["NUMERO_CAJA"] = loNumCaja;
                    //((DataTable)ViewState["Consignatario"]).Rows[0]["TOTAL_CAJAS"] = loTotalCajas;

                    //DataTable loTablaAuxiliar = ((DataTable)ViewState["Consignatario"]).Copy();

                    //for (int i = 1; i < int.Parse(txtCopias.Text); i++)
                    //{
                    //    DataRow loRegistro = loTablaAuxiliar.Rows[0];

                    //    loTablaAuxiliar.ImportRow(loRegistro);
                    //    loTablaAuxiliar.Rows[loTablaAuxiliar.Rows.Count - 1]["NUMERO_CAJA"] = loNumCaja + i;
                    //}

                    //#endregion
                }
                else
                {
                    //Mostrar mensaje de no hay datos filtrados en el reporte
                    lblMsg.Visible = true;
                    lblMsg.Text = "No hay datos Filtrados para Imprimir";
                    UpMensajes.Update();
                }
            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
            finally
            {
               
            }
        }
      
        public static string  GetImpresoraDefecto()
        {
         for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                PrinterSettings a = new PrinterSettings();
                a.PrinterName = PrinterSettings.InstalledPrinters[i].ToString();
                if (a.IsDefaultPrinter)
                {
                   return   PrinterSettings.InstalledPrinters[i].ToString();

                }
            }
            return "";
        }

        //public void meto()
        //{
        //    PrintDocument pd = new PrintDocument();
        //    string s_DefaultPrinter = pd.PrinterSettings.PrinterName;

        //}      

    }
}