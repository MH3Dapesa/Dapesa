using Dapesa.Seguridad.Entidades;
using System;
using System.Data;

namespace Dapesa.Credito.Facturas.Reglas
{
	public class NoParte
	{
		#region Metodos

		public DataTable Obtener(Sesion poSesion, string psClienteID, DateTime poFechaInicio, DateTime poFechaFin)
		{
			HelperNoParte loHelper = new HelperNoParte();

			return loHelper.Obtener(poSesion, psClienteID, poFechaInicio, poFechaFin);
		}

		#endregion
	}
}
