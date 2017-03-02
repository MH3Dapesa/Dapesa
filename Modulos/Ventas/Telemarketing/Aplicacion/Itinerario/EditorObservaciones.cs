using Dapesa.Ventas.Telemarketing.Comun;
using System;
using System.Windows.Forms;

namespace Dapesa.Ventas.Telemarketing.IU.Itinerario
{
	public partial class EditorObservaciones : Form
	{
		#region Atributos

		private event Comun.Definiciones.TextoModificadoManejadorEvento _oTextoModificadoEvento;

		#endregion

		#region Constructor

		public EditorObservaciones()
		{
			InitializeComponent();
			this._oTextoModificadoEvento = new Comun.Definiciones.TextoModificadoManejadorEvento(
				this.evento_TextoModificado
			);
		}

		#endregion

		#region Eventos

		private void btnAceptar_Click(object sender, EventArgs e)
		{

			if (this._oTextoModificadoEvento != null)
				this._oTextoModificadoEvento(this, new ArgumentosEvento(txtTexto.Text));

			this.Close();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void EditorObservaciones_Shown(object sender, EventArgs e)
		{
			txtTexto.SelectionStart = txtTexto.Text.Length;
		}

		private void evento_TextoModificado(object sender, ArgumentosEvento e)
		{

		}

		#endregion

		#region Propiedades

		internal Comun.Definiciones.TextoModificadoManejadorEvento TextoModificadoEvento
		{
			get
			{
				return this._oTextoModificadoEvento;
			}
			set
			{
				this._oTextoModificadoEvento += value;
			}
		}

		internal string Texto
		{
			set
			{
				txtTexto.Text = value;
			}
		}

		#endregion
	}
}
