using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Seguridad.Ajustes.SeguridadGrupos
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

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