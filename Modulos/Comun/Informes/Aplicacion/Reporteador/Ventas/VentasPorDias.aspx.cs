using Dapesa.Comun.Informes.Entidades;
using Dapesa.Comun.Informes.Reglas;
using Dapesa.Comun.Utilerias;
using Dapesa.Seguridad.Entidades;
using Microsoft.Reporting.WebForms;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace Dapesa.Comun.Informes.IU.Reporteador
{
    public partial class VentasPorDias : Page, IReporteador
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                Sesion loSesion = (Sesion)Session["Sesion"];
                bool lbPermirtir = false;
                foreach (Permiso llpemiso in loSesion.Usuario.Permiso)
                {
                    if (llpemiso.Clave == 5)
                    {
                        lbPermirtir = true;
                    }
                }

                if (lbPermirtir)
                {

                    Catalogos loCatalogos = new Catalogos();
                    ceFechaInicio.SelectedDate = DateTime.Now;
                    ceFechaFin.SelectedDate = DateTime.Now;
                    txtFechaInicio.Text = ceFechaInicio.SelectedDate.ToString();
                    txtFechaFin.Text = ceFechaFin.SelectedDate.ToString();
                    Master.Titulo = "Análisis::.Dapesa.Comun.Informes.Reporteador.VentasPorDia";
                    //this.ddlSucursales.Attributes.Add("onchange", "limpiar_upComodines()");
                }
                else
                {
                    Response.Redirect(FormsAuthentication.LoginUrl, true);
                }
            }
            ddlSucursales.Focus();
        }


        #region Eventos

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            this.EnlazarDatos();
        }

        #endregion

        #region Metodos


        public void EnlazarDatos()
        {
            lblInformacion.Text = "";
            upCantidadDias.Update();

            
                if (string.IsNullOrEmpty(ddlSucursales.SelectedValue))

                    return;

                int liComodinesSeleccionados = RetornaComodinesSeleccionados();
                if (int.Parse(ddlVendedores.SelectedValue) > 0)
                {
                    if (liComodinesSeleccionados == 0)
                    {
                        lblInformacion.Text = "Seleccione al menos un Vendedor del Grupo de Checks Vendedores";
                        upCantidadDias.Update();
                        rvVenta.Reset();
                        rvVenta.LocalReport.Refresh();
                        upPanelVenta.Update();
                        return;
                    }
                }


                string lsClavesComodines = RetornaCadComodines();


                bool lbMostrarClientesEliminados = ckClientesEliminados.Checked;
                bool lbMostrarClienteCeroPedidos = ckClienteceroPedidos.Checked;
                TimeSpan lnRangoDeDias = DateTime.Parse(txtFechaFin.Text)- DateTime.Parse(txtFechaInicio.Text);
                Reglas.Comun loComun = new Reglas.Comun();
                Ventas loDiasConPedidos = new Ventas();               
                try
                {
                    rvVenta.Reset();
                    rvVenta.LocalReport.ReportPath = "Informes/Ventas/AnalisisDiasConPedidos.rdl";
                    rvVenta.LocalReport.ReportEmbeddedResource = "Informes/Ventas/AnalisisDiasConPedidos.rdl";
                    rvVenta.LocalReport.DisplayName = "VentasPorDias_" +
                        DateTime.Parse(txtFechaInicio.Text) + "-" + DateTime.Parse(txtFechaInicio.Text) + "_" + ddlSucursales.SelectedItem.Text.Split('(')[1].Split(')')[0] +
                        ((int.Parse(ddlVendedores.SelectedValue) == 0) ? string.Empty : "_V-" + ddlVendedores.SelectedValue);
                    rvVenta.LocalReport.DataSources.Add(new ReportDataSource("dsDiasConPedidos", loDiasConPedidos.ObtenerVentasPorDias((Sesion)Session["Sesion"], DateTime.Parse(txtFechaInicio.Text), DateTime.Parse(txtFechaFin.Text), lnRangoDeDias.Days + 1, ddlSucursales.SelectedValue, ddlVendedores.SelectedValue, lsClavesComodines, lbMostrarClientesEliminados, lbMostrarClienteCeroPedidos)));
                    rvVenta.LocalReport.DataSources.Add(new ReportDataSource("dsEncabezado", loComun.ObtenerEncabezado(
                            "Sucursal: " + ddlSucursales.SelectedItem.Text +
                            ((int.Parse(ddlVendedores.SelectedValue) == 0) ? string.Empty : ", Vendedor: " + ddlVendedores.SelectedItem.Text), txtFechaInicio.Text + " - " + txtFechaFin.Text)
                        ));

                    upCantidadDias.Update();
                    rvVenta.LocalReport.Refresh();
                }
                catch (Exception ex)
                {
                    Session["Excepcion"] = ex;
                    Response.Redirect("~/Error.aspx", false);
                }

            
        }


        public string RetornaCadComodines()
        {
            string resultado = "";
            foreach (ListItem item in cklVendedores.Items)
            {
                if (item.Selected)
                {
                    resultado += item.Value + ",";

                }
            }
            resultado = resultado.TrimEnd(',');
            return resultado;
        }


        public int RetornaComodinesSeleccionados()
        {
            int resultado = 0;
            foreach (ListItem item in cklVendedores.Items)
            {
                if (item.Selected)
                {
                    resultado += 1;

                }
            }
            return resultado;
        }

        #endregion

        protected void ddlVendedores_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblInformacion.Text = "";



            TimeSpan loDiferenciaFechas = DateTime.Parse(txtFechaFin.Text) - DateTime.Parse(txtFechaInicio.Text);
            int dias = loDiferenciaFechas.Days;

            if (dias < 0)
            {
                lblInformacion.Text = "La fecha final debe ser mayor que la fecha inicial.";
                upCantidadDias.Update();
                return;
            }

            Catalogos loCatalogos = new Catalogos();
            cklVendedores.DataSource = loCatalogos.ObtenerComodines((Sesion)Session["Sesion"], int.Parse(ddlSucursales.SelectedValue), int.Parse(ddlVendedores.SelectedValue), DateTime.Parse(txtFechaInicio.Text), DateTime.Parse(txtFechaFin.Text));
            cklVendedores.DataValueField = "VEND_CLAVE";
            cklVendedores.DataTextField = "VENDEDOR";
            cklVendedores.DataBind();


            if (int.Parse(ddlVendedores.SelectedValue) > 0)
            {
                this.LkbComodines.Visible = true; upComodines0.Update();
            }
            else
            {
                LkbComodines.Visible = false; upComodines0.Update();
            }
            upComodines.Update();
        }

        protected void rvVenta_Drillthrough(object sender, DrillthroughEventArgs e)
        {
            Ventas loVentas = new Ventas();

            try
            {
                #region Mostrar detalles

                string lsClaveCliente = ((LocalReport)e.Report).OriginalParametersToDrillthrough[0].Values[0];
                string lsCliente = ((LocalReport)e.Report).OriginalParametersToDrillthrough[1].Values[0];
                string lsComodines = RetornaCadComodines();
                Reglas.Comun loComun = new Reglas.Comun();

                if (e.ReportPath == Comun.Definiciones.TipoSubreporte.DiasConPedidosDetalle.Descripcion())
                {
                    ((LocalReport)e.Report).ReportPath = "Informes/Ventas/" + e.ReportPath + ".rdl";
                    ((LocalReport)e.Report).ReportEmbeddedResource = "Informes/Ventas/" + e.ReportPath + ".rdl";
                    ((LocalReport)e.Report).DisplayName = "Analisis_dias_con_Pedidos_Cte-" + lsClaveCliente + "_" + ddlSucursales.SelectedItem.Text.Split('(')[1].Split(')')[0];
                    ((LocalReport)e.Report).DataSources.Add(new ReportDataSource("dsImportePedidoDias", loVentas.ObtenerVentasPorDiasDetalle((Sesion)Session["Sesion"], lsClaveCliente, int.Parse(ddlSucursales.SelectedValue), DateTime.Parse(txtFechaInicio.Text), DateTime.Parse(txtFechaFin.Text), int.Parse(ddlVendedores.SelectedValue), lsComodines)));
                    ((LocalReport)e.Report).DataSources.Add(new ReportDataSource("dsEncabezado", loComun.ObtenerEncabezado(
                       "Sucursal: " + ddlSucursales.SelectedItem.Text +
                       ",  Cliente: " + lsCliente +
                       ((int.Parse(ddlVendedores.SelectedValue) == 0) ? string.Empty : ",  Vendedor: " + ddlVendedores.SelectedItem.Text + "  "),
                       (txtFechaInicio.Text) + " - " + txtFechaFin.Text)
                   ));
                    //((LocalReport)e.Report).SetParameters(parametros);
                    ((LocalReport)e.Report).Refresh();
                }
                else if (e.ReportPath == Comun.Definiciones.TipoSubreporte.FolioPedidosDias.Descripcion())
                {
                    string ldFecha = ((LocalReport)e.Report).OriginalParametersToDrillthrough[2].Values[0];
                    ((LocalReport)e.Report).ReportPath = "Informes/Ventas/" + e.ReportPath + ".rdl";
                    ((LocalReport)e.Report).ReportEmbeddedResource = "Informes/Ventas/" + e.ReportPath + ".rdl";
                    ((LocalReport)e.Report).DisplayName = "Analisis_Folio_Pedidos_Cte-" + lsClaveCliente + "_" + ddlSucursales.SelectedItem.Text.Split('(')[1].Split(')')[0];
                    ((LocalReport)e.Report).DataSources.Add(new ReportDataSource("dsImportePedidoDias", loVentas.ObtenerFolioPedidosDias((Sesion)Session["Sesion"], lsClaveCliente, int.Parse(ddlSucursales.SelectedValue), DateTime.Parse(ldFecha), int.Parse(ddlVendedores.SelectedValue), lsComodines)));
                    ((LocalReport)e.Report).DataSources.Add(new ReportDataSource("dsEncabezado", loComun.ObtenerEncabezado(
                       "Sucursal: " + ddlSucursales.SelectedItem.Text +
                       ",   Cliente: " + lsCliente +
                       ((int.Parse(ddlVendedores.SelectedValue) == 0) ? string.Empty : ",   Vendedor: " + ddlVendedores.SelectedItem.Text + "  "),
                       DateTime.Parse(ldFecha).ToString("dd/MM/yyyy"))
                   ));
                    ((LocalReport)e.Report).Refresh();
                }
                else if (e.ReportPath == Comun.Definiciones.TipoSubreporte.ArticulosPedidosDias.Descripcion())
                {
                    string lsFolio = ((LocalReport)e.Report).OriginalParametersToDrillthrough[2].Values[0];
                    int lnNumero = int.Parse(((LocalReport)e.Report).OriginalParametersToDrillthrough[3].Values[0]);
                    string ldFecha = ((LocalReport)e.Report).OriginalParametersToDrillthrough[4].Values[0];

                    ((LocalReport)e.Report).ReportPath = "Informes/Ventas/" + e.ReportPath + ".rdl";
                    ((LocalReport)e.Report).ReportEmbeddedResource = "Informes/Ventas/" + e.ReportPath + ".rdl";
                    ((LocalReport)e.Report).DisplayName = "Analisis_Articulos_Pedidos_Cte-" + lsClaveCliente + "_" + ddlSucursales.SelectedItem.Text.Split('(')[1].Split(')')[0];
                    ((LocalReport)e.Report).DataSources.Add(new ReportDataSource("dsImportePedidoDias", loVentas.ObtenerArticulosPedidosDias((Sesion)Session["Sesion"], lsClaveCliente, int.Parse(ddlSucursales.SelectedValue), DateTime.Parse(ldFecha), lsFolio, lnNumero, int.Parse(ddlVendedores.SelectedValue), lsComodines)));
                    ((LocalReport)e.Report).DataSources.Add(new ReportDataSource("dsEncabezado", loComun.ObtenerEncabezado(
                       "Sucursal: " + ddlSucursales.SelectedItem.Text +
                       ",   Cliente: " + lsCliente +
                       ((int.Parse(ddlVendedores.SelectedValue) == 0) ? string.Empty : ",   Vendedor: " + ddlVendedores.SelectedItem.Text + "  "),
                       DateTime.Parse(ldFecha).ToString("dd/MM/yyyy"))
                   ));
                    ((LocalReport)e.Report).Refresh();
                }

                #endregion
            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void LkbComodines_Click(object sender, EventArgs e)
        {
            int items = cklVendedores.Items.Count;
            int items_seleccionados = 0;

            for (int i = 0; i < items; i++)
            {
                if(cklVendedores.Items[i].Selected)
                {
                    items_seleccionados += 1;
                }
            }

            if (items_seleccionados > 0)
            {
                for (int i = 0; i < items; i++)
                {
                    cklVendedores.Items[i].Selected = false;
                }
            }
            else
            {
                for (int i = 0; i < items; i++)
                {
                    cklVendedores.Items[i].Selected = true;
                }
            }
            LkbComodines.Visible = true;
            items_seleccionados = 0;
            upComodines.Update();
            upComodines0.Update();
        }

        //protected void ddlSucursales_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    cklVendedores.DataSource = "";
        //    cklVendedores.DataBind();
        //    upComodines.Update();
        //}







    }
}