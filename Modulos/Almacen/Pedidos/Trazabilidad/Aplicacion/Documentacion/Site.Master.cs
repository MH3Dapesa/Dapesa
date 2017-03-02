using Dapesa.Seguridad.Entidades;
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Dapesa.Almacen.Pedidos.Trazabilidad.IU.Documentacion
{
	public partial class Site : MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetNoStore();
			Request.Browser.Adapters.Clear();

			if (!IsPostBack)
			{
				Sesion loSesion = (Sesion)Session["Sesion"];

				if (!Request.IsAuthenticated || loSesion == null)
					Response.Redirect(FormsAuthentication.LoginUrl, true);

				lblCredenciales.Text = loSesion.Usuario.Nombre + ", " + loSesion.Usuario.Sucursal[0].Descripcion + ".";
				#region Mostrar/ocultar guías

				foreach(Control liItem in luMenu.Controls)
				{

					if (!(liItem is HtmlGenericControl))
						continue;

					((HtmlGenericControl)liItem).Visible = ((HtmlGenericControl)liItem).Attributes["accesskey"].Contains("@" + loSesion.Usuario.Sucursal[0].Clave + "@");
				}

				#endregion
			}
		}

		#region Eventos

		protected void btnSalir_Click(object sender, EventArgs e)
		{

			try
			{
				FormsAuthentication.SignOut();
				FormsAuthentication.RedirectToLoginPage();
			}
			catch
			{
				throw;
			}
		}

		#endregion

		#region Propiedades

		public string Titulo
		{
			set { Page.Title = value; }
		}

		#endregion Properties
	}
}
