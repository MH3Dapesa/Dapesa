using System;

namespace Dapesa.Almacen.Pedidos.Trazabilidad.Entidades.Empaque
{
	public class Traza
	{
		#region Propiedades

		public short Activo { get; set; }
		public long ClavePersonal { get; set; }
		public int Estatus { get; set; }
		public DateTime Fecha { get; set; }
		public string FolioPedido { get; set; }
		public long NumeroPedido { get; set; }

		#endregion
	}
}
