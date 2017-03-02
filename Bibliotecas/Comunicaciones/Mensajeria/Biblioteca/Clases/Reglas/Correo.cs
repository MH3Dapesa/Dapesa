using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace Dapesa.Comunicaciones.Mensajeria.Reglas
{
	public abstract class Correo : IDisposable
	{
		#region Atributos

		protected readonly SmtpClient _oCliente;
		protected readonly DateTime _oFecha;
		protected MailMessage _oMensaje;

		#endregion

		#region Constructor/Destructor

		protected Correo(Entidades.Correo poCorreo) 
		{
			StringBuilder loContenido = new StringBuilder();

			loContenido.Append("<table align=\"center\" width=\"100%\" boder=\"0\">");
			loContenido.Append("   <tr>");
			loContenido.Append("      <td><font face=\"calibri,arial,verdana,helvetica,sans-serif\" size=\"2\">");
			loContenido.Append("         " + poCorreo.Contenido);
			loContenido.Append("      </td>");
			loContenido.Append("   </tr>");
			loContenido.Append("</table>");

			this._oFecha = poCorreo.Fecha;
			this._oCliente = new SmtpClient(poCorreo.Servidor, poCorreo.Puerto) {
				EnableSsl = false,
				UseDefaultCredentials = true
			};
			this._oCliente.Credentials = new NetworkCredential(poCorreo.Credenciales.Usuario, poCorreo.Credenciales.Cifrado.Descifrar(poCorreo.Credenciales.Contrasenia));
			this._oMensaje = new MailMessage(poCorreo.Remitente, poCorreo.Destinatario) {
				AlternateViews = { AlternateView.CreateAlternateViewFromString(loContenido.ToString(), null, MediaTypeNames.Text.Html) },
				Body = loContenido.ToString(),
				BodyEncoding = Encoding.Default,
				IsBodyHtml = true,
				Subject = poCorreo.Asunto
			};

			if (!string.IsNullOrEmpty(poCorreo.CC))
				this._oMensaje.CC.Add(poCorreo.CC);

			if (poCorreo.Adjuntos != null)
			
				foreach (string lsAdjunto in poCorreo.Adjuntos) 
					this._oMensaje.Attachments.Add(
						new Attachment(lsAdjunto, MediaTypeNames.Application.Octet)
					);
		}

		~Correo()
		{
			this.Dispose();
		}
		
		#endregion

		#region Metodos

		public abstract void EstablecerAdjuntos(string[] poAdjuntos);

		public void Dispose()
		{
			this._oMensaje.Dispose();
		}

		#endregion 
	}
}
