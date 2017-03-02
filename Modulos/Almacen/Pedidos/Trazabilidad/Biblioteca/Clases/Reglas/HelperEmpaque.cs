using Dapesa.Almacen.Pedidos.Trazabilidad.Comun;
using Dapesa.Almacen.Pedidos.Trazabilidad.Entidades.Empaque;
using System;

namespace Dapesa.Almacen.Pedidos.Trazabilidad.Reglas
{
	internal class HelperEmpaque
	{
		#region Metodos

		internal int GuardarPaquete(Paquete poPaquete)
		{

			try
			{
				Caja loCaja = new Caja();
				PedidoCaja loPedidoCaja = new PedidoCaja();
				Traza loTraza = new Traza();

				loCaja.Peso = poPaquete.Peso;
				loPedidoCaja.FolioPedido = poPaquete.FolioPedido;
				loPedidoCaja.NumeroPedido = poPaquete.NumeroPedido;
				loTraza.Activo = 1;
				loTraza.ClavePersonal = poPaquete.ClavePersonal;
				loTraza.Estatus = (int)Comun.Definiciones.EstatusPedido.Empacado;
				loTraza.Fecha = DateTime.Now;
				loTraza.FolioPedido = poPaquete.FolioPedido;
				loTraza.NumeroPedido = poPaquete.NumeroPedido;

				//todo: guardar paquete

				return 0;
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		#endregion
	}
}
