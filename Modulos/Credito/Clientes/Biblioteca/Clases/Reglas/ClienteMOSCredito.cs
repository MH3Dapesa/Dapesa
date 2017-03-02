using Dapesa.Seguridad.Entidades;
using System.Data;

namespace Dapesa.Credito.Clientes.Reglas
{
	public class ClienteMOSCredito
	{
		#region Metodos

		public DataTable Obtener(Sesion poSesion, string psClaveCliente, int pnAnio)
		{
			HelperClienteMOSCredito loHelper = new HelperClienteMOSCredito();

			return loHelper.Obtener(poSesion, psClaveCliente, pnAnio);
		}

		public DataTable ObtenerEncabezado(Sesion poSesion, string psClaveCliente, int pnAnio)
		{
			HelperClienteMOSCredito loHelper = new HelperClienteMOSCredito();

			return loHelper.ObtenerEncabezado(poSesion, psClaveCliente, pnAnio);
		}

		public DataTable ObtenerSaldos(Sesion poSesion, string psClaveCliente)
		{
			HelperClienteMOSCredito loHelper = new HelperClienteMOSCredito();

			return loHelper.ObtenerSaldos(poSesion, psClaveCliente);
		}

		#endregion
	}
}
