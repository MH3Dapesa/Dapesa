using System.ComponentModel;

namespace Dapesa.Almacen.Pedidos.Trazabilidad.Comun
{
	public class Definiciones
	{
		#region Enumeraciones

		public enum TipoServicioEntrega
		{
			[DescriptionAttribute("Domicilio")]Domicilio,
			[DescriptionAttribute("Ocurre")]Ocurre
		}
		public enum EstatusPedido { Surtiendo = 1, Surtido, Empacando, Empacado, Documentacion, Enrutando, EnRuta, Entregado };

		#endregion
	}
}
