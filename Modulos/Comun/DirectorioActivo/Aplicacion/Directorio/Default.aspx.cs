using System;
using System.Web.Security;
using System.Web.UI;

namespace Dapesa.Comun.DirectorioActivo.IU.Directorio
{
	public partial class Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{

				if (!Request.IsAuthenticated)
					Response.Redirect(FormsAuthentication.LoginUrl, true);

				Master.Titulo = "Home::.Dapesa.Comun.DirectorioActivo.Directorio";
			}
		}
	}
}