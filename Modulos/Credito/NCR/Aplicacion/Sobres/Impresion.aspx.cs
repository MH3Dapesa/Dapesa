using Dapesa.Credito.NCR.Sobres;
using Dapesa.Seguridad.Entidades;
using Microsoft.Reporting.WebForms;
using System;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;

namespace Dapesa.Credito.NCR.IU.Sobres
{
	public partial class Impresion : Page, IImpresion
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{

				if (!Request.IsAuthenticated)
					Response.Redirect(FormsAuthentication.LoginUrl, true);

				ceFecha.SelectedDate = DateTime.Now;
				txtFecha.Text = ceFecha.SelectedDate.ToString();
				btnFecha.Attributes.Add("onMouseOver", "this.src='Img/calendario_rollover.png'");
				btnFecha.Attributes.Add("onMouseOut", "this.src='Img/calendario.png'");
				Master.Titulo = "Impresión::.Dapesa.Credito.NCR.Sobres";
			}

			txtClienteID.Focus();
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
			Reglas.Impresion loImpresion = new Reglas.Impresion();

			try
			{
				rvSobre.Reset();
				rvSobre.LocalReport.ReportPath = "Rdl/Sobre.rdl";
				rvSobre.LocalReport.ReportEmbeddedResource = "Rdl/Sobre.rdl";
				rvSobre.LocalReport.DataSources.Add(new ReportDataSource("dsConsignatario", loImpresion.ObtenerConsignatario((Sesion)Session["Sesion"], txtClienteID.Text, DateTime.Parse(txtFecha.Text))));
				rvSobre.LocalReport.DataSources.Add(new ReportDataSource("dsRemitente", loImpresion.ObtenerRemitente((Sesion)Session["Sesion"], ConfigurationManager.AppSettings["RazonSocial"])));
				rvSobre.LocalReport.Refresh();
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