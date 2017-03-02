using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


namespace Dapesa.Seguridad.Ajustes.SeguridadGrupos
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Request.IsAuthenticated)
                {
                    Response.Redirect(FormsAuthentication.LoginUrl, true);
                }
                if (Session["Exception"] != null)
                {
                    lblMensaje.Text = "Ocurri&oacute; un error al procesar su solicitud. P&oacute;ngase en contacto con el administrador de la aplicaci&oacute;n.<BR><BR>INFORMACI&Oacute;N DEL ERROR:<BR>" +
                                      "- Fuente. " + ((Exception)Session["Excepcion"]).Source + "<BR>- Mensaje. " + ((Exception)Session["Excepcion"]).Message; ;

                    Master.Titulo = "Error::.Dapesa.Seguridad.Ajustes.SeguridadGrupos";
                }

            }
        }
    }
}