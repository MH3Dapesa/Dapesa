using Dapesa.Comun.Entidades;
using System;

namespace Dapesa.Comunicaciones.Mensajeria.Entidades
{
	public class Correo
	{
		#region Propiedades

		public string[] Adjuntos { get; set; }
		public string Asunto { get; set; }
		public string CC { get; set; }
		public string Contenido { get; set; }
		public Credenciales Credenciales { get; set; }
		public string Destinatario { get; set; }
		public DateTime Fecha { get; set; }
		public int Puerto { get; set; }
		public string Remitente { get; set; }
		public string Servidor { get; set; }
				
		#endregion
	}
}
