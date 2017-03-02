using System;
using System.Web;

namespace Dapesa.Comun.Informes.IU.Reporteador
{
	public class Global : HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{

		}

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
            // Fires at the beginning of each request
            if (!String.IsNullOrEmpty(Request.ServerVariables["HTTP_X_BLUECOAT_VIA"]))
            {
                string original = Request.QueryString.ToString();
                HttpContext.Current.RewritePath(Request.Path + "?" + original.Replace(Server.UrlEncode("amp;"), "&"));
            }
		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{
			HttpException loExcepcion = (HttpException)Server.GetLastError();

			if (HttpContext.Current.Session != null)
			{
				Session["Excepcion"] = new Exception("Error " + loExcepcion.GetHttpCode() + "- " + loExcepcion.Message, loExcepcion);
				Response.Redirect("~/Error.aspx", false);
			}
		}

		protected void Session_End(object sender, EventArgs e)
		{
            
		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}