using Dapesa.Ventas.Telemarketing.Comun;
using System;
using System.Windows.Forms;

namespace Dapesa.Ventas.Telemarketing.IU.Itinerario
{
	public partial class Buscador : Form
	{
		#region Atributos

		private event Comun.Definiciones.TextoModificadoManejadorEvento _oTextoModificadoEvento;

		#endregion

		#region Constructor

		public Buscador()
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
				this._oTextoModificadoEvento(this, new ArgumentosEvento(txtCliente.Text));
				
			this.Close();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
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

		#endregion
	}
}
