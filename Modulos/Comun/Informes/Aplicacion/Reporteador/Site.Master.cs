using Dapesa.Seguridad.Entidades;
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Dapesa.Comun.Informes.IU.Reporteador
{
    public partial class Site : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Request.Browser.Adapters.Clear();

            if (!IsPostBack)
            {
                Sesion loSesion = (Sesion)Session["Sesion"];//

                string lsIdAplicacion = ConfigurationManager.AppSettings["ID"];//


                if (!Request.IsAuthenticated || loSesion == null)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                //Generar Menu
                //loSesion.Usuario.Permiso[0].TipoPermiso
                //coloca Accesos principales con agrupador de Permiso =null
                //      coloca permisos con agrupador de permiso

                if (lsIdAplicacion == loSesion.Conexion.IdAplicacion)//
                {//

                    lblCredenciales.Text = loSesion.Usuario.Nombre + ", " + loSesion.Usuario.Sucursal[0].Descripcion + ".";

                    //Para cada permiso principal
                    //Recorrer el listado de permisos
                    //donde Clave_permiso = agrupdor de item recorrrido
                    //gregar al Menu del permiso principal

                    int Clave = 0;
                    int Tipoelemento = 1;

                    for (int i = 0; i < loSesion.Usuario.Permiso.Count; i++)
                    {
                        Tipoelemento = (int)loSesion.Usuario.Permiso[i].TipoElemento;
                        if (loSesion.Usuario.Permiso[i].Agrupador == null && Tipoelemento != 1)
                        {
                            Clave = (int)loSesion.Usuario.Permiso[i].Clave;
                            //Agrega Menu
                            MenuItem MenuPrincipal = new MenuItem();
                            MenuPrincipal.Text = loSesion.Usuario.Permiso[i].Descripcion;
                            if (Clave == 3 )
                            {
                                MenuPrincipal.ImageUrl = "~/Img/ventas.png";
                            }
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
