using Dapesa.Almacen.Pedidos.Trazabilidad.Entidades.Empaque;

namespace Dapesa.Almacen.Pedidos.Trazabilidad.Reglas
{
	public class Empaque
	{
		#region Metodos

		public int GuardarPaquete(Paquete poPaquete)
		{
			HelperEmpaque loHelper = new HelperEmpaque();

			return loHelper.GuardarPaquete(poPaquete);
		}

		#endregion
	}
}
