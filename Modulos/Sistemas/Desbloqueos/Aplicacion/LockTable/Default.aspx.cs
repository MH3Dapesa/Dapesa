using Dapesa.Seguridad.Entidades;
using System;
using System.Web.Security;
using System.Web.UI;

namespace Dapesa.Sistemas.Desbloqueos.IU.LockTable
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                Sesion loSesion = (Sesion)Session["Sesion"];
                bool lbPermirtir = false;
                foreach (Permiso llPermiso in loSesion.Usuario.Permiso)
                {
                    if (llPermiso.Clave == 38)
                    {
                        lbPermirtir = true;
                    }
                }

                if (lbPermirtir)
                {
                    Master.Titulo = "Sistema::.Dapesa.Sistemas.Desbloqueos.IU.LockTable.Killer";
                }
                else
                {
                    Response.Redirect(FormsAuthentication.LoginUrl, true);
                }

                Master.Titulo = "Home::.Dapesa.Comun.Informes.Reporteador";
            }
        }
    }
}