using System;

namespace Dapesa.Almacen.Pedidos.Trazabilidad.Entidades.Documentacion
{
	public class Guia
	{
		#region Propiedades

		public DateTime Fecha { get; set; }
		public Consignatario Consignatario { get; set; }
		public Remitente Remitente { get; set; }

		#endregion
	}
}
