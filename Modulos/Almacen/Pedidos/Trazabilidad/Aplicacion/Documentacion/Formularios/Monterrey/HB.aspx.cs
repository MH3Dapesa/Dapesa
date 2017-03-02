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

namespace Dapesa.Almacen.Pedidos.Trazabilidad.IU.Documentacion.Formularios.Monterrey
{
    public partial class HB : System.Web.UI.Page
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
                Master.Titulo = "HB::.Dapesa.Almacén.Pedidos.Trazabilidad.Documentación";
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
                        ViewState["Consignatario"] = MergeConsignatario(loDocumentacion.ObtenerConsignatario((Sesion)Session["Sesion"], txtClienteID.Text, ConfigurationManager.AppSettings["PolizaSeguro"]));

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
                    Ancho = 21.4,
                    Alto = 14,
                    Copias = 1,
                    Extension = "rdl",
                    Formato = Informes.Comun.Definiciones.TipoFormato.EMF,
                    Nombre = "HB",
                    Salida = Informes.Comun.Definiciones.TipoSalida.Impresion,
                    Tipo = Informes.Comun.Definiciones.TipoInforme.Web,
                    Ubicacion = Server.MapPath("~/Guias/"),
                    UnidadMedida = Informes.Comun.Definiciones.TipoUnidaMedida.Centimetros
                };

                #region add rows, if necessary

                int loCantidad = int.Parse(txtCantidad1.Text);
                //Concatenar las diferentes columnas de los valores declarados a enviar.
                //Por ejemplo: Cant. = Cantidad1+Cantidad2+Cantidad3;
                ((DataTable)ViewState["Consignatario"]).Rows[0]["NUMERO_CAJA"] = txtCantidad1.Text + "\n\r" + txtCantidad2.Text + "\n\r" + txtCantidad3.Text;
                ((DataTable)ViewState["Consignatario"]).Rows[0]["TOTAL_CAJAS"] = txtPeso1.Text + "\n\r" + txtPeso2.Text + "\n\r" + txtPeso3.Text;
                ((DataTable)ViewState["Consignatario"]).Rows[0]["NOTAS"] = txtArticulo1.Text + "\n\r" + txtArticulo2.Text + "\n\r" + txtArticulo3.Text;
                ((DataTable)ViewState["Consignatario"]).Rows[0]["VIA_EMBARQUE"] = txtContenido1.Text + "\n\r" + txtContenido2.Text + "\n\r" + txtContenido3.Text;

                DataTable loTablaAuxiliar = ((DataTable)ViewState["Consignatario"]).Copy();

                for (int i = 1; i < int.Parse(txtCopias.Text); i++)
                {
                    DataRow loRegistro = loTablaAuxiliar.Rows[0];

                    loTablaAuxiliar.ImportRow(loRegistro);
                    loTablaAuxiliar.Rows[loTablaAuxiliar.Rows.Count - 1]["NUMERO_CAJA"] = loCantidad + i;

                }
                #endregion
                DataSet loFuenteDatos = new DataSet();
                loFuenteDatos.Tables.Add(loTablaAuxiliar);
                loFuenteDatos.Tables[0].TableName = "dsConsignatario";
                loFuenteDatos.Tables.Add((DataTable)ViewState["Remitente"]);
                loFuenteDatos.Tables[1].TableName = "dsRemitente";
                loRendizador.Presentar(loInforme, loFuenteDatos);
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

        protected void cbRemitente_CheckedChanged(object sender, EventArgs e)
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
            ((DataTable)ViewState["Consignatario"]).Rows[0]["NUMERO_CAJA"] = txtCantidad1.Text + "\n\r" + txtCantidad2.Text + "\n\r" + txtCantidad3.Text;
            ((DataTable)ViewState["Consignatario"]).Rows[0]["TOTAL_CAJAS"] = txtPeso1.Text + "\n\r" + txtPeso2.Text + "\n\r" + txtPeso3.Text;
            ((DataTable)ViewState["Consignatario"]).Rows[0]["NOTAS"] = txtArticulo1.Text + "\n\r" + txtArticulo2.Text + "\n\r" + txtArticulo3.Text;
            ((DataTable)ViewState["Consignatario"]).Rows[0]["VIA_EMBARQUE"] = txtContenido1.Text + "\n\r" + txtContenido2.Text + "\n\r" + txtContenido3.Text;
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

        public DataTable MergeConsignatario(DataTable loConsignatario)
        {
            //Se creó una nueva tabla para cambiar el tipo de columna de NUMERO_CAJA y TOTAL_CAJAS a string.
            DataTable loMergeConsignatario = new DataTable("Consignatario");
            loMergeConsignatario.Columns.Add("FECHA", typeof(DateTime));
            loMergeConsignatario.Columns.Add("CLAVE", typeof(int));
            loMergeConsignatario.Columns.Add("NOMBRE", typeof(string));
            loMergeConsignatario.Columns.Add("DIRECCION", typeof(string));
            loMergeConsignatario.Columns.Add("COLONIA", typeof(string));
            loMergeConsignatario.Columns.Add("POBLACION", typeof(string));
            loMergeConsignatario.Columns.Add("CIUDAD", typeof(string));
            loMergeConsignatario.Columns.Add("ESTADO", typeof(string));
            loMergeConsignatario.Columns.Add("PAIS", typeof(string));
            loMergeConsignatario.Columns.Add("TELEFONO", typeof(string));
            loMergeConsignatario.Columns.Add("CP", typeof(string));
            loMergeConsignatario.Columns.Add("RAZON_SOCIAL", typeof(string));
            loMergeConsignatario.Columns.Add("RFC", typeof(string));
            loMergeConsignatario.Columns.Add("NUMERO_CAJA", typeof(string));
            loMergeConsignatario.Columns.Add("TOTAL_CAJAS", typeof(string));
            loMergeConsignatario.Columns.Add("NOTAS", typeof(string));
            loMergeConsignatario.Columns.Add("VIA_EMBARQUE", typeof(string));

            DataRow loFilaConsignatario = loMergeConsignatario.NewRow();
            loFilaConsignatario["FECHA"] = loConsignatario.Rows[0]["FECHA"];
            loFilaConsignatario["CLAVE"] = loConsignatario.Rows[0]["CLAVE"];
            loFilaConsignatario["NOMBRE"] = loConsignatario.Rows[0]["NOMBRE"];
            loFilaConsignatario["DIRECCION"] = loConsignatario.Rows[0]["DIRECCION"];
            loFilaConsignatario["COLONIA"] = loConsignatario.Rows[0]["COLONIA"];
            loFilaConsignatario["POBLACION"] = loConsignatario.Rows[0]["POBLACION"];
            loFilaConsignatario["CIUDAD"] = loConsignatario.Rows[0]["CIUDAD"];
            loFilaConsignatario["ESTADO"] = loConsignatario.Rows[0]["ESTADO"];
            loFilaConsignatario["PAIS"] = loConsignatario.Rows[0]["PAIS"];
            loFilaConsignatario["TELEFONO"] = loConsignatario.Rows[0]["TELEFONO"];
            loFilaConsignatario["CP"] = loConsignatario.Rows[0]["CP"];
            loFilaConsignatario["RAZON_SOCIAL"] = loConsignatario.Rows[0]["RAZON_SOCIAL"];
            loFilaConsignatario["RFC"] = loConsignatario.Rows[0]["RFC"];
            loFilaConsignatario["NUMERO_CAJA"] = loConsignatario.Rows[0]["NUMERO_CAJA"].ToString();
            loFilaConsignatario["TOTAL_CAJAS"] = loConsignatario.Rows[0]["TOTAL_CAJAS"].ToString();
            loFilaConsignatario["NOTAS"] = loConsignatario.Rows[0]["NOTAS"];
            loFilaConsignatario["VIA_EMBARQUE"] = loConsignatario.Rows[0]["VIA_EMBARQUE"];
            loMergeConsignatario.Rows.Add(loFilaConsignatario);
            return loMergeConsignatario;
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
            txtCantidad1.Text = "1";
            txtPeso1.Text = "1";
            txtCantidad2.Text = "";
            txtPeso2.Text = "";
            txtCantidad3.Text = "";
            txtPeso3.Text = "";
            txtArticulo1.Text = "CAJA";
            txtContenido1.Text = "AUTOPARTES";
            txtArticulo2.Text = "";
            txtContenido2.Text = "";
            txtArticulo3.Text = "";
            txtContenido3.Text = "";
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