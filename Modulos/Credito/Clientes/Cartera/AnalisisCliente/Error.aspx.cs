using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Credito.Clientes.Cartera.UI.AnalisisCliente
{
    public partial class Error : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                if (Session["Excepcion"] != null)
                    lblMensaje.Text = "Ocurri&oacute; un error al procesar su solicitud. P&oacute;ngase en contacto con el administrador de la aplicaci&oacute;n.<BR><BR>INFORMACI&Oacute;N DEL ERROR:<BR>" +
                                      "- Fuente. " + ((Exception)Session["Excepcion"]).Source + "<BR>- Mensaje. " + ((Exception)Session["Excepcion"]).Message;

                Master.Titulo = "Error::.Dapesa.Credito.Clientes.Cartera.AnalisisCliente";
            }
        }
    }
}
