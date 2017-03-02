using Dapesa.Comun.Informes.Reglas;
using Dapesa.Seguridad.Entidades;
using Microsoft.Reporting.WebForms;
using System;
using System.Web.Security;
using System.Web.UI;

namespace Dapesa.Comun.Informes.IU.Reporteador
{
	public partial class Asignaciones : Page, IReporteador
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
                    Master.Titulo = "Asignaciones::.Dapesa.Comun.Informes.Reporteador.Ventas";
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
			Reglas.Comun loComun = new Reglas.Comun();
			Ventas loVentas = new Ventas();

			try
			{
				rvItinerario.Reset();
				rvItinerario.LocalReport.ReportPath = "Informes/Ventas/Asignaciones.rdl";
				rvItinerario.LocalReport.ReportEmbeddedResource = "Informes/Ventas/Asignaciones.rdl";
				rvItinerario.LocalReport.DisplayName = "Asignaciones" + 
					((string.IsNullOrEmpty(ddlTelemarketings.SelectedValue)) ? string.Empty : "_" + ddlTelemarketings.SelectedItem.Text.Split(' ')[0]) + "_" +
					((string.IsNullOrEmpty(ddlSucursales.SelectedValue)) ? ((((Sesion)Session["Sesion"]).Usuario.Sucursal.Count == 1) ? ((Sesion)Session["Sesion"]).Usuario.Sucursal[0].DescripcionCorta : "GLOBAL") : ddlSucursales.SelectedItem.Text.Split('(')[1].Split(')')[0]);
				rvItinerario.LocalReport.DataSources.Add(new ReportDataSource("dsAsignaciones", loVentas.ObtenerAsignaciones((Sesion)Session["Sesion"], ddlSucursales.SelectedValue, ddlTelemarketings.SelectedValue, ddlEstatus.SelectedValue, ddlSemaforo.SelectedValue)));
				rvItinerario.LocalReport.DataSources.Add(new ReportDataSource("dsEncabezado", loComun.ObtenerEncabezado(
					((string.IsNullOrEmpty(ddlSucursales.SelectedValue)) ? ((((Sesion)Session["Sesion"]).Usuario.Sucursal.Count == 1) ? "Sucursal: " + ((Sesion)Session["Sesion"]).Usuario.Sucursal[0].Descripcion + " (" + ((Sesion)Session["Sesion"]).Usuario.Sucursal[0].DescripcionCorta + ")" : "REPORTE GLOBAL") : "Sucursal: " + ddlSucursales.SelectedItem.Text) +
					((string.IsNullOrEmpty(ddlTelemarketings.SelectedValue)) ? string.Empty : ", Telemarketing: " + ddlTelemarketings.SelectedItem.Text), null)));
				rvItinerario.LocalReport.Refresh();
			}
			catch (Exception ex)
			{
				Session["Excepcion"] = ex;
				Response.Redirect("~/Error.aspx", false);
			}
		}

		#endregion
	}
}