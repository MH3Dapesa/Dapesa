using Dapesa.Comunicaciones.Mensajeria.Comun;
using System;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace Dapesa.Comunicaciones.Mensajeria.Reglas
{
	public class CorreoElectronico : Correo, IMensaje
	{
		#region Constructor

		public CorreoElectronico(Entidades.Correo poMensaje)
			: base(poMensaje)
		{
			
		}

		#endregion

		#region Metodos

		public bool Enviar()
		{

			try
			{
				base._oCliente.Send(base._oMensaje);
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}

			return true;
		}

		public override void EstablecerAdjuntos(string[] poAdjuntos)
		{
			base._oMensaje.Attachments.Clear();

			if (poAdjuntos != null)

				foreach (string lsAdjunto in poAdjuntos)
					base._oMensaje.Attachments.Add(
						new Attachment(lsAdjunto, MediaTypeNames.Application.Octet)
					);
		}

		public void EstablecerContenido(string psContenido)
		{
			StringBuilder loContenido = new StringBuilder();

			loContenido.Append("<table align=\"center\" width=\"100%\" boder=\"0\">");
			loContenido.Append("   <tr>");
			loContenido.Append("      <td><font face=\"calibri,arial,verdana,helvetica,sans-serif\" size=\"2\">");
			loContenido.Append("         " + psContenido);
			loContenido.Append("      </td>");
			loContenido.Append("   </tr>");
			loContenido.Append("</table>");

			base._oMensaje.AlternateViews.Clear();
			base._oMensaje.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(loContenido.ToString(), null, MediaTypeNames.Text.Html));
			base._oMensaje.Body = loContenido.ToString();
		}

		#endregion
	}
}
