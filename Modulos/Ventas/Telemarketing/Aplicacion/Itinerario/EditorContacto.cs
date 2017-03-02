using Dapesa.Ventas.Telemarketing.Entidades;
using System;
using System.Windows.Forms;

namespace Dapesa.Ventas.Telemarketing.IU.Itinerario
{
	public partial class EditorContacto : Form
	{
		#region Atributos

		private event Comun.Definiciones.ContactoAgregadoManejadorEvento _oContactoAgregadoEvento;
		private string _sClaveCliente;
		private string _sCliente;

		#endregion

		#region Constructor

		public EditorContacto()
		{
			InitializeComponent();
			this._oContactoAgregadoEvento = new Comun.Definiciones.ContactoAgregadoManejadorEvento(
				this.evento_ContactoAgregado
			);
		}

		#endregion

		#region Eventos

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			this.GuardarContacto();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void EditorContacto_Shown(object sender, EventArgs e)
		{
			lblNombreCliente.Text = this._sClaveCliente + "-" + this._sCliente;
		}

		private void evento_ContactoAgregado(object sender, EventArgs e)
		{
			
		}

		#endregion

		#region Metodos

		private bool CamposRequeridos()
		{
			bool lbCamposRequeridos = true;

			#region Verificación de campos requeridos

			pbNombreRequerido.Visible = false;
			pbPuestoRequerido.Visible = false;

			if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
			{
				pbNombreRequerido.Visible = true;
				lbCamposRequeridos = false;
			}

			if (string.IsNullOrEmpty(txtPuesto.Text.Trim()))
			{
				pbPuestoRequerido.Visible = true;
				lbCamposRequeridos = false;
			}

			#endregion

			return lbCamposRequeridos;
		}

		private void GuardarContacto()
		{

			if (!this.CamposRequeridos())
			{
				txtNombre.Focus();
				return;
			}

			Cursor.Current = Cursors.WaitCursor;
			this.Enabled = false;

			try
			{
				#region Validar máscaras de telefonos

				txtCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
				txtTelefono.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

				if (txtCelular.Text.Length > 0)
					txtCelular.TextMaskFormat = MaskFormat.IncludeLiterals;

				if (txtTelefono.Text.Length > 0)
					txtTelefono.TextMaskFormat = MaskFormat.IncludeLiterals;

				#endregion

				Reglas.LayoutContacto loLayout = new Reglas.LayoutContacto();

				if (loLayout.GuardarContacto(
						((InicioSesion)((Contenido)this.Owner).MdiParent.Owner).Sesion, new ContactoCliente() {
							#region Inicializar propiedades

							ApellidoPaterno = txtApPaterno.Text.ToUpper().Trim(),
							Apodo = txtApodo.Text.ToUpper().Trim(),
							Celular = txtCelular.Text.Trim(),
							ClaveCliente = this._sClaveCliente,
							Correo = txtCorreo.Text.ToLower().Trim(),
							Nextel = txtRadio.Text.Trim(),
							Nombre = txtNombre.Text.ToUpper().Trim(),
							Puesto = txtPuesto.Text.ToUpper().Trim(),
							Telefono = txtTelefono.Text.Trim()

							#endregion
						}) && this._oContactoAgregadoEvento != null)
					this._oContactoAgregadoEvento(this, new EventArgs());

				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtNombre.Focus();
			}
			finally
			{
				this.Enabled = true;
				Cursor.Current = Cursors.Default;
				txtCelular.TextMaskFormat = MaskFormat.IncludeLiterals;
				txtTelefono.TextMaskFormat = MaskFormat.IncludeLiterals;
			}
		}

		#endregion

		#region Propiedades

		internal string ClaveCliente
		{
			set
			{
				this._sClaveCliente = value;
			}
		}

		internal Comun.Definiciones.ContactoAgregadoManejadorEvento ContactoAgregadoEvento
		{
			get
			{
				return this._oContactoAgregadoEvento;
			}
			set
			{
				this._oContactoAgregadoEvento += value;
			}
		}

		internal string Cliente
		{
			set
			{
				this._sCliente = value;
			}
		}

		#endregion
	}
}
