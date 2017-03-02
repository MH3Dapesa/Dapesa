using Dapesa.Ventas.Telemarketing.Entidades;
using System;
using System.Windows.Forms;

namespace Dapesa.Ventas.Telemarketing.IU.LayoutContacto
{
	public partial class Manual : Form
	{
		#region Constructor

		public Manual()
		{
			InitializeComponent();
			#region Inicializar componentes

			ttInformacion.SetToolTip(btnAceptar, "Guardar información");
			ttInformacion.SetToolTip(btnCancelar, "Cancelar edición");

			#endregion
		}

		#endregion

		#region Eventos

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			this.GuardarContacto();
		}

		private void btnBuscar_Click(object sender, EventArgs e)
		{
			this.BuscarContacto();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Manual_Load(object sender, EventArgs e)
		{
			txtClaveCliente.Focus();
		}

		#endregion

		#region Metodos

		private void BuscarContacto()
		{

			try
			{
				Cursor.Current = Cursors.WaitCursor;
				Reglas.LayoutContacto loLayout = new Reglas.LayoutContacto();
				ContactoCliente loContacto = loLayout.ObtenerContacto(
					((InicioSesion)this.MdiParent.Owner).Sesion, txtClaveCliente.Text.Trim()
				);

				#region Asignar propiedades a controles

				txtApodo.Text = loContacto.Apodo;
				txtApPaterno.Text = loContacto.ApellidoPaterno;
				txtCelular.Text = loContacto.Celular;
				txtCorreo.Text = loContacto.Correo;
				txtNombre.Text = loContacto.Nombre;
				txtPuesto.Text = loContacto.Puesto;
				txtRadio.Text = loContacto.Nextel;
				txtTelefono.Text= loContacto.Telefono;

				#endregion
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

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

			try
			{
				Cursor.Current = Cursors.WaitCursor;

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
						((InicioSesion)this.MdiParent.Owner).Sesion, new ContactoCliente() {
							#region Inicializar propiedades

							ApellidoPaterno = txtApPaterno.Text.ToUpper().Trim(),
							Apodo = txtApodo.Text.ToUpper().Trim(),
							Celular = txtCelular.Text.Trim(),
							ClaveCliente = txtClaveCliente.Text.Trim(),
							Correo = txtCorreo.Text.ToLower().Trim(),
							Nextel = txtRadio.Text.Trim(),
							Nombre = txtNombre.Text.ToUpper().Trim(),
							Puesto = txtPuesto.Text.ToUpper().Trim(),
							Telefono = txtTelefono.Text.Trim()

							#endregion
						}))
					MessageBox.Show("Información de contacto procesada satisfactoriamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtNombre.Focus();
			}
			finally
			{
				Cursor.Current = Cursors.Default;
				txtCelular.TextMaskFormat = MaskFormat.IncludeLiterals;
				txtTelefono.TextMaskFormat = MaskFormat.IncludeLiterals;
			}
		}

		#endregion
	}
}
