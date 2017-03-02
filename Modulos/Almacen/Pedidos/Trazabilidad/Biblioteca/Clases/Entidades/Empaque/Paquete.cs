namespace Dapesa.Almacen.Pedidos.Trazabilidad.Entidades.Empaque
{
	public class Paquete
	{
		#region Propiedades

		public long ClavePersonal { get; set; }
		public string FolioPedido { get; set; }
		public long NumeroPedido { get; set; }
		public double Peso { get; set; }

		#endregion
	}
}
