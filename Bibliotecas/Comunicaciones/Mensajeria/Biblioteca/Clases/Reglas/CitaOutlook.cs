using Dapesa.Comunicaciones.Mensajeria.Comun;
using Microsoft.Office.Interop.Outlook;

namespace Dapesa.Comunicaciones.Mensajeria.Reglas
{
	public class CitaOutlook : Cita, IMensaje
	{
		#region Constructor

		public CitaOutlook(Entidades.Cita poMensaje)
			: base(poMensaje)
		{
			
		}

		#endregion

		#region Metodos

		public bool Enviar()
		{

			try
			{
				this._oCita.Save();

				if (this._bMostrar)
					this._oCita.Display(true);

				if (this._oMensaje != null)
					((_MailItem)this._oMensaje).Send();
			}
			catch (System.Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
			finally
			{
				base.Dispose();
			}

			return true;
		}

		public void EstablecerContenido(string psContenido)
		{
			this._oCita.Body = psContenido;
		}

		#endregion
	}
}
