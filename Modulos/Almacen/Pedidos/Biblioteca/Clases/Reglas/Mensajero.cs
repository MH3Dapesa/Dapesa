using Dapesa.Seguridad.Entidades;
using System;
using System.Data;

namespace Dapesa.Almacen.Pedidos.Reglas
{
	public class Mensajero
	{
		#region Metodos

		public DataTable ObtenerPedidos(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin)
		{
			HelperMensajero loHelper = new HelperMensajero();

			return loHelper.ObtenerPedidos(poSesion, poFechaInicio, poFechaFin);
		}

		#endregion
	}
}
