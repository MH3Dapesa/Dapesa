using Dapesa.Comun.Entidades;
using Dapesa.Criptografia.Comun;
using Dapesa.Criptografia.Reglas;
using Dapesa.Seguridad.Entidades;
using Dapesa.Seguridad.Reglas;
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dapesa.Credito.NCR.IU.Sobres
{
	public partial class InicioSesion : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			lgnLogin.Focus();
		}

		#region Eventos

		protected void lgnLogin_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
		{

			try
			{
				Login loLogin = (Login)sender;
				TextBox txtBaseDatos = (TextBox)loLogin.FindControl("DataBase");

				Administrador loAdministrador = new Administrador();
				Cifrado loCifrado = new Cifrado(Definiciones.TipoCifrado.AES);
				Conexion loConexion = new Conexion() {
					BaseDatos = txtBaseDatos.Text,
					Credenciales = new Credenciales() {
						Cifrado = loCifrado,
						Contrasenia = loCifrado.Cifrar(loLogin.Password),
						Usuario = loLogin.UserName
					},
					Tipo = Comun.Definiciones.TipoConexion.CredencialesExplicitas,
					TipoCliente = Comun.Definiciones.TipoCliente.Oracle
				};
				Sesion loSesion = loAdministrador.ObtenerSesion(loConexion);

				e.Authenticated = loSesion.Estatus == Seguridad.Comun.Definiciones.EstatusSesion.Iniciada;
				Session["Sesion"] = loSesion;
			}
			catch (Exception)
			{
				e.Authenticated = false;
			}
		}

		protected void lgnLogin_LoggedIn(object sender, EventArgs e)
		{

			try
			{
				Login loLogin = (Login)sender;
				Response.Cookies.Add(new HttpCookie(
					FormsAuthentication.FormsCookieName,
					FormsAuthentication.Encrypt(new FormsAuthenticationTicket(1,
						HttpContext.Current.Session.SessionID,
						DateTime.Now,
						DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
						false, loLogin.UserName,
						FormsAuthentication.FormsCookiePath
					)))	{
						Secure = true
					});
				FormsAuthentication.RedirectFromLoginPage(loLogin.UserName, false);
			}
			catch (Exception ex)
			{
				Session["Excepcion"] = ex;
				Response.Redirect("~/Error.aspx", false);
			}
		}

		protected void lgnLogin_LoginError(object sender, EventArgs e)
		{
			((Login)sender).FailureText = "Credenciales no v&aacute;lidas. Intenta nuevamente por favor";
		}

		#endregion
	}
}