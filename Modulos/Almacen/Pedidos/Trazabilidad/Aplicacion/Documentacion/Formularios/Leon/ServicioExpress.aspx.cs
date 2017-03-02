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
	public partial class ServicioExpress : Page, IDocumentacion
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{

				if (!Request.IsAuthenticated)
					Response.Redirect(FormsAuthentication.LoginUrl, true);

				ViewState["Consignatario"] = new DataTable();
				ViewState["Remitente"] = new DataTable();
				ViewState["ClienteID"] = -1;
				Master.Titulo = "Servicio Express::.Dapesa.Almacén.Pedidos.Trazabilidad.Documentación";
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
						ViewState["Consignatario"] = loDocumentacion.ObtenerConsignatario((Sesion)Session["Sesion"], txtClienteID.Text, ConfigurationManager.AppSettings["PolizaSeguro"]);

						if (((DataTable)ViewState["Consignatario"]).Rows.Count == 0)
						{
							txtDomicilio.ToolTip = string.Empty;
							txtColonia.ToolTip = string.Empty;
							this.LimpiarConsignatario();
						}
						else
							this.EstablecerConsignatario();

						if (((DataTable)ViewState["Remitente"]).Rows.Count == 0)
							ViewState["Remitente"] = loDocumentacion.ObtenerRemitente((Sesion)Session["Sesion"], ConfigurationManager.AppSettings["RazonSocialAbreviada"]);
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
				Informe loInforme = new Informe() {
					Ancho = 21.3,
					Alto = 14.1,
					Copias = int.Parse(txtCopias.Text),
					Extension = "rdl",
					Formato = Informes.Comun.Definiciones.TipoFormato.EMF,
					Nombre = "ServicioExpress",
					Salida = Informes.Comun.Definiciones.TipoSalida.Impresion,
					Tipo = Informes.Comun.Definiciones.TipoInforme.Web,
					Ubicacion = Server.MapPath("~/Guias/"),
					UnidadMedida = Informes.Comun.Definiciones.TipoUnidaMedida.Centimetros
				};
				DataSet loFuenteDatos = new DataSet();

				loFuenteDatos.Tables.Add((DataTable)ViewState["Consignatario"]);
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

		#endregion

		#region Metodos

		public void ActualizarConsignatario()
		{
			((DataTable)ViewState["Consignatario"]).Rows[0]["CLAVE"] = txtClienteID.Text.ToUpper();
			((DataTable)ViewState["Consignatario"]).Rows[0]["NOMBRE"] = txtNombre.Text.ToUpper();
			((DataTable)ViewState["Consignatario"]).Rows[0]["RAZON_SOCIAL"] = txtRazonSocial.Text.ToUpper();
			((DataTable)ViewState["Consignatario"]).Rows[0]["RFC"] = txtRFC.Text.ToUpper();
			((DataTable)ViewState["Consignatario"]).Rows[0]["DIRECCION"] = txtDomicilio.Text.ToUpper();
			((DataTable)ViewState["Consignatario"]).Rows[0]["COLONIA"] = txtColonia.Text.ToUpper();
			((DataTable)ViewState["Consignatario"]).Rows[0]["POBLACION"] = txtPoblacion.Text.ToUpper();
			((DataTable)ViewState["Consignatario"]).Rows[0]["CP"] = txtCodigoPostal.Text.ToUpper();
			((DataTable)ViewState["Consignatario"]).Rows[0]["TELEFONO"] = txtTelefono.Text.ToUpper();
		}

		public void EstablecerConsignatario()
		{
			txtNombre.Text = ((DataTable)ViewState["Consignatario"]).Rows[0]["NOMBRE"].ToString();
			txtRazonSocial.Text = ((DataTable)ViewState["Consignatario"]).Rows[0]["RAZON_SOCIAL"].ToString();
			txtRFC.Text = ((DataTable)ViewState["Consignatario"]).Rows[0]["RFC"].ToString();
			txtDomicilio.Text = txtDomicilio.ToolTip = ((DataTable)ViewState["Consignatario"]).Rows[0]["DIRECCION"].ToString();
			txtColonia.Text = txtColonia.ToolTip = ((DataTable)ViewState["Consignatario"]).Rows[0]["COLONIA"].ToString();
			txtPoblacion.Text = ((DataTable)ViewState["Consignatario"]).Rows[0]["POBLACION"].ToString();
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
			txtRFC.Text = string.Empty;
			txtDomicilio.Text = string.Empty;
			txtColonia.Text = string.Empty;
			txtPoblacion.Text = string.Empty;
			txtCodigoPostal.Text = string.Empty;
			txtTelefono.Text = string.Empty;
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
