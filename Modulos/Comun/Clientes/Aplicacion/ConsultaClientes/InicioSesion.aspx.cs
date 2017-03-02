using Dapesa.Comun.Entidades;
using Dapesa.Criptografia.Comun;
using Dapesa.Criptografia.Reglas;
using Dapesa.Seguridad.Entidades;
using Dapesa.Seguridad.Reglas;
using System.DirectoryServices.AccountManagement;
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections.Generic;

namespace Comun.Clientes.ConsultaClientes
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
            #region IniciarSesion con directorio activo
            try
            {
                Login loLogin = (Login)sender;
                TextBox txtDominio = (TextBox)loLogin.FindControl("Domain");

                PrincipalContext loLDAP = new PrincipalContext(ContextType.Domain, txtDominio.Text, loLogin.UserName, loLogin.Password);
                Dapesa.Comun.DirectorioActivo.Reglas.Usuario loUsuario = new Dapesa.Comun.DirectorioActivo.Reglas.Usuario();
                Cifrado loCifrado = new Cifrado(Dapesa.Criptografia.Comun.Definiciones.TipoCifrado.AES);

                Sesion loSesion = new Sesion()
                {
                    Conexion = new Conexion()
                    {
                        Nombre = loLDAP.Name,
                        Servidor = loLDAP.ConnectedServer,
                        Credenciales = new Credenciales()
                        {
                            Cifrado = loCifrado,
                            Contrasenia = loCifrado.Cifrar(loLogin.Password),
                            Usuario = loLogin.UserName
                        },
                    },
                    Estatus = (loLDAP.ValidateCredentials(loLogin.UserName, loLogin.Password)) ? Dapesa.Seguridad.Comun.Definiciones.EstatusSesion.Iniciada : Dapesa.Seguridad.Comun.Definiciones.EstatusSesion.NoIniciada,
                    Usuario = new Usuario()
                    {
                        Estatus = Dapesa.Seguridad.Comun.Definiciones.EstatusUsuario.Valido,
                        Sucursal = new List<Sucursal>() { new Sucursal() }
                    },
                };

                e.Authenticated = loSesion.Estatus == Dapesa.Seguridad.Comun.Definiciones.EstatusSesion.Iniciada && loUsuario.PerteneceA(loSesion, ConfigurationManager.AppSettings["GrupoValidez"]);

                if (e.Authenticated)
                {
                    loSesion.Usuario.Nombre = loUsuario.ObtenerPropiedad(loSesion, "name");
                    loSesion.Usuario.Sucursal[0].Descripcion = loUsuario.ObtenerPropiedad(loSesion, "l");
                    SesionDB();
                }

                Session["Sesion"] = loSesion;
            }
            catch (Exception)
            {
                e.Authenticated = false;
            }
            #endregion

           
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
                    )))
                    {
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
        internal void SesionDB()
        {
            #region Sesion usuario base de datos
            try
            {
                Administrador loAdministrador = new Administrador();
                Cifrado loCifrado = new Cifrado(Definiciones.TipoCifrado.AES);
                Conexion loConexion = new Conexion()
                {
                    BaseDatos = "siil",
                    Credenciales = new Credenciales()
                    {
                        Cifrado = loCifrado,
                        Contrasenia = loCifrado.Cifrar(ConfigurationManager.AppSettings["Clave"]),
                        Usuario = ConfigurationManager.AppSettings["Usuario"]
                    },
                    Tipo = Dapesa.Comun.Definiciones.TipoConexion.CredencialesExplicitas,
                    TipoCliente = Dapesa.Comun.Definiciones.TipoCliente.Oracle
                };
                Sesion loSesion = loAdministrador.ObtenerSesion(loConexion);

                Session["SesionDB"] = loSesion;
            }
            catch (Exception)
            {

            }
            #endregion
        }
    }
}