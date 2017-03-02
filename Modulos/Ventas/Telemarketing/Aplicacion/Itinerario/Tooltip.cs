using Dapesa.Ventas.Telemarketing.Comun;
using System;
using System.Windows.Forms;

namespace Dapesa.Ventas.Telemarketing.IU.Itinerario
{
	public partial class Tooltip : Form
	{
		#region Constructor

		public Tooltip()
		{
			InitializeComponent();
		}

		#endregion

		#region Eventos

		private void btnAceptar_Click(object sender, EventArgs e)
		{
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

		internal string TextoInformativo
		{
			set
			{
				lblTooltip.Text = value;
			}
		}

		#endregion
	}
}
