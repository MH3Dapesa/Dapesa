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

namespace Dapesa.Sistemas.Desbloqueos.IU.LockTable
{
    public partial class Killer : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pNotificacion.Visible = false;
                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                Sesion loSesion = (Sesion)Session["Sesion"];
                bool lbPermirtir = false;
                foreach (Permiso llPermiso in loSesion.Usuario.Permiso)
                {
                    if (llPermiso.Clave == 37)
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

                chkRefresh.Checked = true;
                TablasBloqueadas();

                if (chkRefresh.Checked == true)
                {
                    Response.AppendHeader("Refresh", "5; URL=Killer.aspx");
                }
            }
        }

        #region Metodos

        public void TablasBloqueadas()
        {
            gvBloqueadas.DataSource = llenarTablasBloqueadas();
            gvBloqueadas.DataBind();            
        }

        public DataTable llenarTablasBloqueadas()
        {
            Consultas loConsulta = new Consultas();
            return loConsulta.llenarBloqueados();
        }

        public object DesconectaSesion(string sParametros, string sRAC, DataTable loTabla)
        {
            Consultas loConsulta = new Consultas();
            loConsulta.Desconectar(sParametros, sRAC, loConsulta.llenarBloqueados());
            return true;
        }

        public object MataSesion(string sParametros, string sRAC, DataTable loTabla)
        {
            Consultas loConsulta = new Consultas();
            loConsulta.Matar(sParametros, sRAC, loConsulta.llenarBloqueados());
            return true;
        }
        #endregion 

        #region Eventos 

        protected void gvBloqueadas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.backgroundColor='#FFE5CC';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='#fff';";
                e.Row.HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].Font.Bold = true;
                e.Row.VerticalAlign = VerticalAlign.Middle;
                e.Row.Cells[7].Font.Bold = true;
                e.Row.Cells[7].CssClass = "text-danger";
                e.Row.Cells[8].Font.Bold = true;
                e.Row.Cells[8].CssClass = "text-danger";

                if (e.Row.Cells[5].Text == "enq: TX - row lock contention")
                {
                    e.Row.BackColor = System.Drawing.Color.FromArgb(255, 102, 102);
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.backgroundColor='#990000';";
                    e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='#FF6666';";
                    e.Row.ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.White;
                }

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
                }

                string sUsuario = e.Row.Cells[1].Text;
                string sLocktable = e.Row.Cells[2].Text;
                string sParametros = e.Row.Cells[7].Text;
                string sRAC = e.Row.Cells[8].Text;

                foreach (LinkButton button in e.Row.Cells[0].Controls.OfType<LinkButton>())
                {
                    if (button.CommandName == "Desconectar")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Desconectar Sesion: Usuario " + sUsuario + " Objeto bloqueado: " + sLocktable + " SID-Serial#-RAC: " + sParametros + "," + sRAC + "')){ return false; };";
                    }
                    if (button.CommandName == "Matar")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Matar Sesion: Usuario " + sUsuario + " Objeto bloqueado: " + sLocktable + " SID-Serial#-RAC: " + sParametros + "," + sRAC + "')){ return false; };";
                    }
                }
            }
        }

        protected void lnkActualizar_Click(object sender, EventArgs e)
        {
            this.TablasBloqueadas();
        }

        protected void gvBloqueadas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Desconectar":
                    foreach (GridViewRow loFila in gvBloqueadas.Rows)
                    {
                        Session["dbUser"] = loFila.Cells[1].Text;
                        Session["Usuer"] = loFila.Cells[2].Text;
                        Session["Parametros"] = loFila.Cells[7].Text;
                        Session["RAC"] = loFila.Cells[8].Text;
                        pNotificacion.Visible = true;
                        pNotificacion.CssClass = "alert alert-success";
                        lblUsuario.Text = "Sesión desconectada de la BD: " + Session["dbUser"]
                            + " - " + Session["Usuer"] + " - " + Session["Parametros"] + "," + Session["RAC"] + "";
                        DesconectaSesion(Session["Parametros"].ToString(), Session["RAC"].ToString(), llenarTablasBloqueadas());
                    }
                    break;
                case "Matar":
                    foreach (GridViewRow loFila in gvBloqueadas.Rows)
                    {
                        Session["dbUser"] = loFila.Cells[1].Text;
                        Session["Usuer"] = loFila.Cells[2].Text;
                        Session["Parametros"] = loFila.Cells[7].Text;
                        Session["RAC"] = loFila.Cells[8].Text;
                        pNotificacion.Visible = true;
                        pNotificacion.CssClass = "alert alert-success";
                        lblUsuario.Text = "Sesión Eliminada de la BD: " + Session["dbUser"]
                            + " - " + Session["Usuer"] + " - " + Session["Parametros"] + "," + Session["RAC"] + "";
                        MataSesion(Session["Parametros"].ToString(), Session["RAC"].ToString(), llenarTablasBloqueadas());
                    }
                    break;
            }
        }

        protected void chkRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRefresh.Checked == true)
            {
                Response.AppendHeader("Refresh", "5; URL=Killer.aspx");
            }
            if (chkRefresh.Checked == false)
            {
                Response.AppendHeader("Refresh", "300; URL=Killer.aspx");
            }
        }        
        #endregion
    }
}