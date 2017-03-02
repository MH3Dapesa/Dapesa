using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using System.Data;
using System.Web.Security;
using Dapesa.Seguridad.Entidades;
using System.Configuration;
using Sistemas.Desbloqueos.Reglas;

namespace Sistemas.Desbloqueos.IU.LockTable
{
    public partial class Loading : Page
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
                    Master.Titulo = "Sistema::.Dapesa.Sistemas.Desbloqueos.IU.LockTable.Loading";
                }
                else
                {
                    Response.Redirect(FormsAuthentication.LoginUrl, true);
                }

                chkRefresh.Checked = true;
                Procesos();
            }
        }

        #region Metodos

        public void Procesos()
        {
            Consultas loProcesos = new Consultas();
            gvProcesos.DataSource = loProcesos.llenarProcesos();
            gvProcesos.DataBind();

            if (chkRefresh.Checked == true)
            {
                Response.AppendHeader("Refresh", "5; URL=Loading.aspx");
            }
        }
        #endregion

        #region Eventos

        protected void gvProcesos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.backgroundColor='#FFE5CC';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='#fff';";
                e.Row.HorizontalAlign = HorizontalAlign.Center;
                e.Row.VerticalAlign = VerticalAlign.Middle;
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[7].CssClass = "text-danger";

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }
            }
        }

        protected void lnkActualizar_Click(object sender, EventArgs e)
        {
            Procesos();
        }

        protected void chkRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRefresh.Checked == true)
            {
                Response.AppendHeader("Refresh", "5; URL=Loading.aspx");
            }
            if (chkRefresh.Checked == false)
            {
                Response.AppendHeader("Refresh", "300; URL=Loading.aspx");
            }
        }

        #endregion
    }
}