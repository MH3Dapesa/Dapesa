using Dapesa.Almacen.Pedidos.Trazabilidad.Reglas;
using Dapesa.Informes.Entidades;
using Dapesa.Informes.Reglas;
using Dapesa.Seguridad.Entidades;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dapesa.Almacen.Pedidos.Trazabilidad.IU.Documentacion
{
    public partial class IGAPAQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (!Request.IsAuthenticated)
                    Response.Redirect(FormsAuthentication.LoginUrl, true);

                ViewState["ClienteID"] = -1;
                ViewState["Consignatario"] = new DataTable();
                ViewState["Remitente"] = new DataTable();
                Master.Titulo = "IGAPAQ::.Dapesa.Almacén.Pedidos.Trazabilidad.Documentación";
            }

            lblMensaje.Text = "";
            txtClienteID.Focus();
        }

        #region Eventos

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            Reglas.Documentacion loDocumentacion = new Reglas.Documentacion();

            try
            {
                this.cbRemitente_CheckedChanged();

                if (txtClienteID.Text.Trim() == string.Empty)
                {
                    txtDomicilio.ToolTip = string.Empty;
                    txtColonia.ToolTip = string.Empty;
                    this.LimpiarConsignatario();
                }
                else
                {

                    if (txtClienteID.Text.Trim() == ViewState["ClienteID"].ToString())
                    {
                        txtDomicilio.Text = txtDomicilio.ToolTip;
                        txtColonia.Text = txtColonia.ToolTip;
                        this.ActualizarConsignatario();
                    }
                    else
                    {
                        ViewState["Consignatario"] = loDocumentacion.ObtenerConsignatario((Sesion)Session["Sesion"], txtClienteID.Text, ConfigurationManager.AppSettings["PolizaSeguro"]);

                        if (((DataTable)ViewState["Consignatario"]).Rows.Count == 0)
                        {
                            txtDomicilio.ToolTip = string.Empty;
                            txtColonia.ToolTip = string.Empty;
                            this.LimpiarConsignatario();
                        }
                        else
                            this.EstablecerConsignatario();
                    }
                }

                cbOcurre.Checked = false;
            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void btnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            this.ActualizarConsignatario();

            try
            {
                Rendizador loRendizador = new Rendizador();
                Informe loInforme = new Informe()
                {
                    Ancho = 21.6,
                    Alto = 13.9,
                    Copias = 1,
                    Extension = "rdl",
                    Formato = Informes.Comun.Definiciones.TipoFormato.EMF,
                    Nombre = "IGAPAQ",
                    Salida = Informes.Comun.Definiciones.TipoSalida.Impresion,
                    Tipo = Informes.Comun.Definiciones.TipoInforme.Web,
                    Ubicacion = Server.MapPath("~/Guias/"),
                    UnidadMedida = Informes.Comun.Definiciones.TipoUnidaMedida.Centimetros
                };

                #region add rows, if necessary

                //int loNumCaja = int.Parse(txtNumCaja.Text);
                //int loTotalCajas = int.Parse(txtTotalCajas.Text);

                //((DataTable)ViewState["Consignatario"]).Rows[0]["NUMERO_CAJA"] = loNumCaja;
                //((DataTable)ViewState["Consignatario"]).Rows[0]["TOTAL_CAJAS"] = loTotalCajas;

                DataTable loTablaAuxiliar = ((DataTable)ViewState["Consignatario"]).Copy();

                for (int i = 1; i < 1; i++)
                {
                    DataRow loRegistro = loTablaAuxiliar.Rows[0];

                    loTablaAuxiliar.ImportRow(loRegistro);
                    //loTablaAuxiliar.Rows[loTablaAuxiliar.Rows.Count - 1]["NUMERO_CAJA"] = loNumCaja + i;
                }

                #endregion
                DataSet loFuenteDatos = new DataSet();

                loFuenteDatos.Tables.Add(loTablaAuxiliar);
                loFuenteDatos.Tables[0].TableName = "dsConsignatario";
                loFuenteDatos.Tables.Add((DataTable)ViewState["Remitente"]);
                loFuenteDatos.Tables[1].TableName = "dsRemitente";
                for (int i = 1; i <= int.Parse(txtCopias.Text); i++)
                {
                    loRendizador.Presentar(loInforme, loFuenteDatos);
                }
            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
            finally
            {
                txtClienteID.Focus();
            }
        }

        protected void cbOcurre_CheckedChanged(object sender, EventArgs e)
        {
            Reglas.Documentacion loDocumentacion = new Reglas.Documentacion();
            bool lbIndicador = ((CheckBox)sender).Checked;

            try
            {

                if (string.IsNullOrEmpty(txtClienteID.Text))
                {
                    DataTable loOcurre = loDocumentacion.ObtenerConsignatario((Sesion)Session["Sesion"], "-1", ConfigurationManager.AppSettings["PolizaSeguro"]);

                    loOcurre.Rows.Add(loOcurre.NewRow());
                    ViewState["Consignatario"] = loOcurre;
                    btnImprimir.Visible = lbIndicador;
                }
            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
            finally
            {

                if (lbIndicador)
                {
                    txtDomicilio.ToolTip = txtDomicilio.Text;
                    txtDomicilio.Text = "OCURRE";
                    txtColonia.ToolTip = txtColonia.Text;
                    txtColonia.Text = "CENTRO";
                    txtColonia.Focus();
                }
                else
                {
                    txtDomicilio.Text = txtDomicilio.ToolTip;
                    txtColonia.Text = txtColonia.ToolTip;
                    txtClienteID.Focus();
                }
            }
        }

        protected void cbRemitente_CheckedChanged()
        {
            Reglas.Documentacion loDocumentacion = new Reglas.Documentacion();

            try
            {
                if (cbRemitente.Checked)
                    ViewState["Remitente"] = loDocumentacion.ObtenerRemitente((Sesion)Session["Sesion"], ConfigurationManager.AppSettings["RazonSocial"]);
                else
                    ViewState["Remitente"] = new DataTable();
            }
            catch (Exception ex)
            {
                Session["Excepcion"] = ex;
                Response.Redirect("~/Error.aspx", false);
            }
        }

        #endregion

        #region Metodos

        public void ActualizarConsignatario()
        {
            ((DataTable)ViewState["Consignatario"]).Rows[0]["CLAVE"] = txtClienteID.Text.ToUpper();
            ((DataTable)ViewState["Consignatario"]).Rows[0]["NOMBRE"] = txtNombre.Text.ToUpper();
            ((DataTable)ViewState["Consignatario"]).Rows[0]["RAZON_SOCIAL"] = txtRazonSocial.Text.ToUpper();
            ((DataTable)ViewState["Consignatario"]).Rows[0]["DIRECCION"] = txtDomicilio.Text.ToUpper();
            ((DataTable)ViewState["Consignatario"]).Rows[0]["COLONIA"] = txtColonia.Text.ToUpper();
            ((DataTable)ViewState["Consignatario"]).Rows[0]["CIUDAD"] = txtCiudad.Text.ToUpper();
            ((DataTable)ViewState["Consignatario"]).Rows[0]["ESTADO"] = txtEstado.Text.ToUpper();
            ((DataTable)ViewState["Consignatario"]).Rows[0]["CP"] = txtCodigoPostal.Text.ToUpper();
            ((DataTable)ViewState["Consignatario"]).Rows[0]["TELEFONO"] = txtTelefono.Text.ToUpper();
            ((DataTable)ViewState["Consignatario"]).Rows[0]["VIA_EMBARQUE"] = (!cbOcurre.Checked) ? "X": String.Empty;
            ((DataTable)ViewState["Consignatario"]).Rows[0]["NOTAS"] = txtContenido.Text.ToString().ToUpper();
            ((DataTable)ViewState["Consignatario"]).Rows[0]["SEGURO"] = txtTotalPiezas.Text.ToString().ToUpper();
            //((DataTable)ViewState["Consignatario"]).Rows[0]["NUMERO_CAJA"] = txtNumCaja.Text.ToUpper();
            //((DataTable)ViewState["Consignatario"]).Rows[0]["TOTAL_CAJAS"] = txtTotalCajas.Text.ToUpper();
        }

        public void EstablecerConsignatario()
        {
            txtNombre.Text = ((DataTable)ViewState["Consignatario"]).Rows[0]["NOMBRE"].ToString();
            txtRazonSocial.Text = ((DataTable)ViewState["Consignatario"]).Rows[0]["RAZON_SOCIAL"].ToString();
            txtDomicilio.Text = txtDomicilio.ToolTip = ((DataTable)ViewState["Consignatario"]).Rows[0]["DIRECCION"].ToString();
            txtColonia.Text = txtColonia.ToolTip = ((DataTable)ViewState["Consignatario"]).Rows[0]["COLONIA"].ToString();
            txtCiudad.Text = ((DataTable)ViewState["Consignatario"]).Rows[0]["CIUDAD"].ToString();
            txtEstado.Text = ((DataTable)ViewState["Consignatario"]).Rows[0]["ESTADO"].ToString();
            txtCodigoPostal.Text = ((DataTable)ViewState["Consignatario"]).Rows[0]["CP"].ToString();
            txtTelefono.Text = ((DataTable)ViewState["Consignatario"]).Rows[0]["TELEFONO"].ToString();
            ViewState["ClienteID"] = txtClienteID.Text.Trim();
            txtCopias.Text = "1";
            btnImprimir.Visible = true;
        }

        public void LimpiarConsignatario()
        {
            txtNombre.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtDomicilio.Text = string.Empty;
            txtColonia.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtCodigoPostal.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            //txtNumCaja.Text = "1";
            //txtTotalCajas.Text = "1";
            txtCopias.Text = "1";
            ViewState["ClienteID"] = -1;
            btnImprimir.Visible = false;

            if (lblMensaje.ForeColor == Color.Green)
                lblMensaje.ForeColor = Color.Blue;
            else
                lblMensaje.ForeColor = Color.Green;

            lblMensaje.Text = "No hay información con los datos del cliente proporcionado.";
        }

        #endregion
    }
}
