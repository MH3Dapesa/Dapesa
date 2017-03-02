using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Dapesa.Seguridad.Entidades;



namespace Dapesa.Seguridad.Ajustes.SeguridadGrupos
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Sesion loSesion = (Sesion)Session["Sesion"];
                string lsIdAplicacion = ConfigurationManager.AppSettings["ID"];

                if (!Request.IsAuthenticated || loSesion == null)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                if (lsIdAplicacion == loSesion.Conexion.IdAplicacion)//
                {
                    lblCredenciales.Text = loSesion.Usuario.Nombre + ", " + loSesion.Usuario.Sucursal[0].Descripcion + ".";
                    //Genra Menu Princiapal de acuerdo a los permisos del usuario
                    //Detecta los permisos tipo Agrupadador, _
                    //Agrega primero los permisos Agrupadores y despues agrega cada permiso a los menus
                    //principales como un submenu

                    int Clave = 0;

                    for (int i = 0; i < loSesion.Usuario.Permiso.Count; i++)
                    {
                        if (loSesion.Usuario.Permiso[i].Agrupador == null)
                        {
                            Clave = (int)loSesion.Usuario.Permiso[i].Clave;
                            //Agrega Menu
                            MenuItem MenuPrincipal = new MenuItem();
                            MenuPrincipal.Text = loSesion.Usuario.Permiso[i].Descripcion;
                            MenuPrincipal.ImageUrl = "~/Img/ventas.png";
                            MenUsuario.Items.Add(MenuPrincipal);

                            //Vuelve a Recorrer todos los permisos 
                            for (int j = 0; j < loSesion.Usuario.Permiso.Count; j++)
                            {
                                if (loSesion.Usuario.Permiso[j].Agrupador != null)
                                {
                                    int agrupadorhijo = (int)loSesion.Usuario.Permiso[j].Agrupador;
                                    if (agrupadorhijo == Clave)
                                    {
                                        //Agrega submenu
                                        //MenuItem MenuPrincipal = MenUsuario.Items[1]; //Home=0,Ventas=1
                                        MenuItem newSubMenuItem = new MenuItem();
                                        newSubMenuItem.Text = loSesion.Usuario.Permiso[j].Descripcion;
                                        newSubMenuItem.NavigateUrl = loSesion.Usuario.Permiso[j].Url;
                                        MenuPrincipal.ChildItems.Add(newSubMenuItem);
                                    }
                                }
                            }
                        }
                    }
                }
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