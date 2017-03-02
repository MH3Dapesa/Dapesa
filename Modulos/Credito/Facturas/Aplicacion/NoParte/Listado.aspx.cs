using Dapesa.Comun.Utilerias;
using Dapesa.Credito.Facturas.Reglas;
using Dapesa.Seguridad.Entidades;
using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dapesa.Credito.Facturas.IU.NoParte
{
	public partial class Listado : Page, INoParte
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{

				if (!Request.IsAuthenticated)
					Response.Redirect(FormsAuthentication.LoginUrl, true);

				lbExportar.Visible = false;
				ceFechaInicio.SelectedDate = DateTime.Now;
				ceFechaFin.SelectedDate = DateTime.Now;
				txtFechaInicio.Text = ceFechaInicio.SelectedDate.ToString();
				txtFechaFin.Text = ceFechaFin.SelectedDate.ToString();
				btnFechaInicio.Attributes.Add("onMouseOver", "this.src='Img/calendario_rollover.png'");
				btnFechaInicio.Attributes.Add("onMouseOut", "this.src='Img/calendario.png'");
				btnFechaFin.Attributes.Add("onMouseOver", "this.src='Img/calendario_rollover.png'");
				btnFechaFin.Attributes.Add("onMouseOut", "this.src='Img/calendario.png'");
				Master.Titulo = "Listado::.Dapesa.Credito.Facturas.NoParte";
			}

			txtClienteID.Focus();
		}

		#region Eventos

		protected void btnGenerar_Click(object sender, EventArgs e)
		{
			this.EnlazarDatos(true);
		}

		protected void gvNoParte_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gvNoParte.EditIndex = -1;
			gvNoParte.PageIndex = e.NewPageIndex;
			this.EnlazarDatos(false);
		}

		protected void lbExportar_Click(object sender, EventArgs e)
		{
			Texto loTexto = new Texto();

			Response.Buffer = false;
			Response.ContentType = "text/xml";
			Response.AddHeader("Content-Disposition", "attachment;filename=" + txtClienteID.Text.ToUpper() + "_" + txtFechaInicio.Text.Replace("/", "") + "-" + txtFechaFin.Text.Replace("/", "") + ".txt");
			Response.Write(loTexto.Unir((DataTable)ViewState["NoParte"], 1, true));
			Response.Close();
		}

		#endregion

		#region Metodos

		public void EnlazarDatos(bool pbEnlazarDesdeBD)
		{
			Reglas.NoParte loNoParte = new Reglas.NoParte();

			try
			{

				if (pbEnlazarDesdeBD)
					ViewState["NoParte"] = loNoParte.Obtener((Sesion)Session["Sesion"], txtClienteID.Text, DateTime.Parse(txtFechaInicio.Text), DateTime.Parse(txtFechaFin.Text));

				lbExportar.Visible = false;
				gvNoParte.DataSource = ViewState["NoParte"];
				gvNoParte.DataBind();

				if (((DataTable)ViewState["NoParte"]).Rows.Count == 0)
					return;

				lbExportar.Visible = true;
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