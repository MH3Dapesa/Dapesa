using Dapesa.Almacen.Pedidos.Reglas;
using Dapesa.Seguridad.Entidades;
using System;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;


namespace Dapesa.Almacen.Pedidos.IU.Mensajero
{
    public partial class Listado : Page, IMensajero
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                tmrInfo.Interval = int.Parse(ConfigurationManager.AppSettings["TiempoRefrescado"]);
                tmrInfo.Enabled = true;
                ceFechaInicio.SelectedDate = DateTime.Now;
                ceFechaFin.SelectedDate = DateTime.Now;
                txtFechaInicio.Text = ceFechaInicio.SelectedDate.ToString();
                txtFechaFin.Text = ceFechaFin.SelectedDate.ToString();
                lblHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                btnFechaInicio.Attributes.Add("onMouseOver", "this.src='Img/calendario_rollover.png'");
                btnFechaInicio.Attributes.Add("onMouseOut", "this.src='Img/calendario.png'");
                btnFechaFin.Attributes.Add("onMouseOver", "this.src='Img/calendario_rollover.png'");
                btnFechaFin.Attributes.Add("onMouseOut", "this.src='Img/calendario.png'");
                Master.Titulo = "Listado::.Dapesa.Almacén.Pedidos.Mensajero";
            }
        }

        #region Eventos

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            this.EnlazarDatos();
        }

        protected void tmrInfo_Tick(object sender, EventArgs e)
        {

            if (cvFechas.IsValid)
                this.EnlazarDatos();
        }

        #endregion

        #region Metodos

        public void EnlazarDatos()
        {
            Reglas.Mensajero loMensajero = new Reglas.Mensajero();

            try
            {
                DataTable loPedidos = loMensajero.ObtenerPedidos((Sesion)Session["Sesion"], DateTime.Parse(txtFechaInicio.Text), DateTime.Parse(txtFechaFin.Text));


                for (int i = 0; i < loPedidos.Rows.Count; i++)
                {
                    if (loPedidos.Rows[i]["EXISTENCIA"].ToString() != "0")
                    {
                        loPedidos.Rows[i]["EXISTENCIA"] = "1";
                    }
                }
                loPedidos.DefaultView.Sort = "EXISTENCIA DESC, ORDEN ASC, GESTOR ASC, NUMERO ASC";


                loPedidos.Columns["VENDEDOR"].SetOrdinal(0);
                loPedidos.Columns["CLAVE"].SetOrdinal(1);
                loPedidos.Columns["CLIENTE"].SetOrdinal(2);
                loPedidos.Columns["FOLIO"].SetOrdinal(3);
                loPedidos.Columns["TRANSPORTISTA"].SetOrdinal(4);
                loPedidos.Columns["CONDICION"].SetOrdinal(5);
                loPedidos.Columns["ORDEN"].SetOrdinal(6);
                loPedidos.Columns["FECHA"].SetOrdinal(7);
                loPedidos.Columns["RENGLONES"].SetOrdinal(8);
                loPedidos.Columns["OBSERVACIONES"].SetOrdinal(9);


                loPedidos.Columns.Add("#", typeof(int)).SetOrdinal(0);
                DataRow loAgregarFila;
                loAgregarFila = loPedidos.NewRow();
                int loNumeroDeFilas = loPedidos.Rows.Count;
                for (int i = 0; i < loNumeroDeFilas; i++)
                {

                    loPedidos.Rows[i]["#"] = i + 1;
                }


                //rvPedidos.Reset();
                //rvPedidos.LocalReport.ReportPath = "Rdl/Pedidos.rdl";
                //rvPedidos.LocalReport.ReportEmbeddedResource = "Rdl/Pedidos.rdl";
                //rvPedidos.LocalReport.DataSources.Add(new ReportDataSource("dsPedidos", loPedidos));
                //rvPedidos.LocalReport.Refresh();


                gvPedidos.Visible = true;
                gvPedidos.DataSource = loPedidos;
                gvPedidos.DataBind();

                upPanelPedidos.Update();
            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
        }

        #endregion

        #region Eventos

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            e.Row.Cells[0].Width = 35;
            e.Row.Cells[1].Width = 48;
            e.Row.Cells[3].Width = 215;
            e.Row.Cells[4].Width = 60;
            e.Row.Cells[5].Width = 150;
            e.Row.Cells[6].Width = 63;
            e.Row.Cells[7].Width = 120;
            e.Row.Cells[8].Width = 100;
            e.Row.Cells[9].Width = 36;
            e.Row.Cells[10].Width = 1300;
            

            //e.Row.Cells[0].Attributes.Add("id", "col0");
            //e.Row.Cells[1].Attributes.Add("id", "col1");

            e.Row.Cells[2].Visible = false;
            for (int i = 11; i <= e.Row.Cells.Count - 1; i++)
            {
                e.Row.Cells[i].Width = 0;
                e.Row.Cells[i].Visible = false;
            }


            //Cambiar Texto solo a encabezados de Columnas del GridView
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "VEND";
                e.Row.Cells[4].Text = "PEDIDO";
                e.Row.Cells[6].Text = "CONDICIÓN";
                e.Row.Cells[7].Text = "AUTORIZACIÓN";
                e.Row.Cells[9].Text = "RENG";
                e.Row.Cells[10].CssClass="td-Descripcion";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //CREAR EL FOLIO-NUMERO DEL PEDIDO
                e.Row.Cells[3].Text = e.Row.Cells[2].Text + " " + e.Row.Cells[3].Text;
                e.Row.Cells[4].Text = e.Row.Cells[4].Text + " - " + e.Row.Cells[12].Text;
                e.Row.Cells[10].ToolTip = e.Row.Cells[10].Text;
                e.Row.Cells[8].Text = Convert.ToDateTime(e.Row.Cells[8].Text).ToString("dd/MM/yyyy hh:mm:ss");


                string _estado = DataBinder.Eval(e.Row.DataItem, "#").ToString();


                e.Row.Cells[0].Text = (e.Row.RowIndex + 1).ToString();





                //Cambiar texto en la columna CONDICIÓN
                if (e.Row.Cells[6].Text == "1")
                {
                    e.Row.Cells[6].Text = "CONTADO";
                }
                else
                {
                    e.Row.Cells[6].Text = "CRÉDITO";
                }

                //pintar fondo de fila.
                if (e.Row.Cells[16].Text == "0")
                {
                    e.Row.BackColor = System.Drawing.Color.LightBlue;
                }
                else
                {
                    if (e.Row.Cells[5].Text.Contains("BACK") || e.Row.Cells[7].Text == "3") //revisar
                    {
                        e.Row.BackColor = System.Drawing.Color.FromName("#d33739");
                        e.Row.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        if (e.Row.Cells[7].Text == "2")
                        {
                            e.Row.BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            if (e.Row.Cells[11].Text == "3" && (e.Row.Cells[3].Text.Contains("MOSTR") || e.Row.Cells[5].Text.Contains("MOSTR")))
                            {
                                e.Row.BackColor = System.Drawing.Color.Orange;
                            }
                            else
                            {
                                if (e.Row.Cells[11].Text == "3" && e.Row.Cells[5].Text.Contains("MOTO"))
                                {
                                    e.Row.BackColor = System.Drawing.Color.LightGreen;
                                }
                                else
                                {
                                    if (e.Row.Cells[5].Text.Contains("NUESTR") || e.Row.Cells[5].Text.Contains("CAMIONETA") || e.Row.Cells[5].Text.Contains("CONTAD") || e.Row.Cells[5].Text.Contains("COTIZ"))
                                    {
                                        e.Row.BackColor = System.Drawing.Color.White;
                                    }
                                    else
                                    {
                                        e.Row.BackColor = System.Drawing.Color.LightGreen;
                                    }
                                }
                            }
                        }
                    }
                }


                //cambiar texto en la columna AUTORIZACIÓN
                switch (e.Row.Cells[7].Text)
                {
                    case "0":
                        e.Row.Cells[7].Text = "N/A";
                        break;
                    case "1":
                        e.Row.Cells[7].Text = "POR FACTURAR";
                        break;
                    case "2":
                        e.Row.Cells[7].Text = "POR AUTORIZAR VENTAS";
                        break;
                    case "3":
                        e.Row.Cells[7].Text = "POR AUTORIZAR CxC";
                        break;
                }



                //e.Row.BackColor = System.Drawing.Color.DarkSlateBlue;           
                //    //e.Row.Cells[0].BackColor = System.Drawing.Color.Blue; pinta columna completa
                //string _estado = DataBinder.Eval(e.Row.DataItem, "FOLIO").ToString();
                //if (_estado == "30")
                //    e.Row.BackColor = System.Drawing.Color.Red;

            }
        }


        #endregion
    }
}
