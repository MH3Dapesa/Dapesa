using Dapesa.Comun.Entidades;
using Dapesa.Criptografia.Comun;
using Dapesa.Criptografia.Reglas;
using Dapesa.Seguridad.Entidades;
using Dapesa.Seguridad.Reglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comun.Clientes.ConsultaClientes
{
    public partial class ConsultaClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);
            }
            txtCliente.Focus();
        }

        protected void EnlazarDatos()
        {
            try
            {
                Sesion loSesion = (Sesion)Session["SesionDB"];
                Reglas.Clientes ObtenerCliente = new Reglas.Clientes();
                gvContenido.DataSource = ObtenerCliente.ObtenerCliente(loSesion, txtCliente.Text.ToUpper());
                gvContenido.DataBind();
                txtCliente.Focus();
            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
        }
    

        #region Eventos
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            EnlazarDatos();
        }
        #endregion
    }

}