using System;
using System.Web.Security;
using System.Web.UI;

namespace Dapesa.Almacen.Pedidos.IU.Mensajero
{
	public partial class Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{

				if (!Request.IsAuthenticated)
					Response.Redirect(FormsAuthentication.LoginUrl, true);

				Master.Titulo = "Home::.Dapesa.Almacén.Pedidos.Mensajero";
			}
		}
	}
}