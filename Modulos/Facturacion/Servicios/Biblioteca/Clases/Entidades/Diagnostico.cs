using Dapesa.Comunicaciones.Mensajeria.Entidades;

namespace Dapesa.Facturacion.Servicios.Entidades
{
	public class Diagnostico
	{
		#region Propiedades

		public string DirectorioDiagnostico { get; set; }
		public string DirectorioEntrada { get; set; }
		public string DirectorioProcesados { get; set; }
		public string HoraDetencion { get; set; }
		public string HoraDetencionSabado { get; set; }
		public string HoraReanudacion { get; set; }
		public Correo Mensaje { get; set; }

		#endregion
	}
}
