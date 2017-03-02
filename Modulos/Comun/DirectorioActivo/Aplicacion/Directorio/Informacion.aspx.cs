using Dapesa.Comun.DirectorioActivo.Reglas;
using Dapesa.Comun.Utilerias;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dapesa.Comun.DirectorioActivo.IU.Directorio
{
	public partial class Informacion : Page, IDirectorio
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{

				if (!Request.IsAuthenticated)
					Response.Redirect(FormsAuthentication.LoginUrl, true);

				btnCerrar.Attributes.Add("onMouseOver", "this.src='Img/cerrar_rollover.png'");
				btnCerrar.Attributes.Add("onMouseOut", "this.src='Img/cerrar.png'");
				Master.Titulo = "Informaci&oacute;n::.Dapesa.Comun.DirectorioActivo.Directorio";
			}

			txtValor.Focus();
		}

		#region Eventos

		protected void btnBuscar_Click(object sender, EventArgs e)
		{
			this.EnlazarDatos(true);
		}

		protected void gvInformacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gvInformacion.EditIndex = -1;
			gvInformacion.PageIndex = e.NewPageIndex;
			this.EnlazarDatos(false);
		}

		protected void gvInformacion_RowCommand(object sender, GridViewCommandEventArgs e)
		{
   
            if (e.CommandName == DirectorioActivo.Comun.Definiciones.TipoComando.MostrarDetalle.Descripcion())
            {
				#region Establecer valores

				GridViewRowCollection loFilas = (GridViewRowCollection)((GridView)sender).Rows;
				Label loColonia = (Label)(loFilas[int.Parse(e.CommandArgument.ToString())]).FindControl("lblColonia");
				Label loCorreo = (Label)(loFilas[int.Parse(e.CommandArgument.ToString())]).FindControl("lblCorreo");
				Label loCP = (Label)(loFilas[int.Parse(e.CommandArgument.ToString())]).FindControl("lblCP");
				Label loDepartamento = (Label)(loFilas[int.Parse(e.CommandArgument.ToString())]).FindControl("lblDepartamento");
				Label loDireccion = (Label)(loFilas[int.Parse(e.CommandArgument.ToString())]).FindControl("lblDireccion");
				Label loEstado = (Label)(loFilas[int.Parse(e.CommandArgument.ToString())]).FindControl("lblEstado");
				Label loExtension = (Label)(loFilas[int.Parse(e.CommandArgument.ToString())]).FindControl("lblExtension");
				Label loMovil = (Label)(loFilas[int.Parse(e.CommandArgument.ToString())]).FindControl("lblMovil");
                LinkButton loNombre = (LinkButton)(loFilas[int.Parse(e.CommandArgument.ToString())]).FindControl("lblNombre");
				Label loPuesto = (Label)(loFilas[int.Parse(e.CommandArgument.ToString())]).FindControl("lblPuesto");
				Label loRadio = (Label)(loFilas[int.Parse(e.CommandArgument.ToString())]).FindControl("lblRadio");
				Label loSucursal = (Label)(loFilas[int.Parse(e.CommandArgument.ToString())]).FindControl("lblSucursal");
				Label loTelefono = (Label)(loFilas[int.Parse(e.CommandArgument.ToString())]).FindControl("lblTelefono");
			
				lblColonia.Text = loColonia.Text;
				lblCorreo.Text = loCorreo.Text;
				lblCP.Text = loCP.Text;
				lblDepartamento.Text = loDepartamento.Text;
				lblDireccion.Text = loDireccion.Text;
				lblEstado.Text = loEstado.Text;
				lblExtension.Text = loExtension.Text;
				lblMovil.Text = loMovil.Text;
				lblNombre.Text = loNombre.Text;
				lblPuesto.Text = loPuesto.Text;
				lblRadio.Text = loRadio.Text;
				lblSucursal.Text = loSucursal.Text;
				lblTelefono.Text = loTelefono.Text;
				mpeDetalles.Show();

				#endregion
            }
		}

		protected void gvInformacion_RowCreated(object sender, GridViewRowEventArgs e)
		{

			if (e.Row.RowType == DataControlRowType.DataRow)
			{
                LinkButton loDetalles = (LinkButton)e.Row.FindControl("lblNombre");

				loDetalles.CommandArgument = e.Row.RowIndex.ToString();
			}
		}

		#endregion

		#region Metodos

		public void EnlazarDatos(bool pbEnlazarDesdeDA)
		{
			Reglas.Usuario loInformacion = new Reglas.Usuario();

			try
			{

				if (pbEnlazarDesdeDA)
					
                    ViewState["Informacion"] = loInformacion.Obtener((Sesion)Session["Sesion"], ddlFiltro.SelectedValue, txtValor.Text);

				gvInformacion.DataSource = ViewState["Informacion"] as List<Entidades.Usuario>;
				gvInformacion.DataBind();
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