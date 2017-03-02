using Dapesa.Seguridad.Entidades;
using System;
using System.Data;

namespace Dapesa.Credito.NCR.Reglas
{
	public class Impresion
	{
		#region Metodos

		public DataTable ObtenerConsignatario(Sesion poSesion, string psClienteID, DateTime poFecha)
		{
			HelperImpresion loHelper = new HelperImpresion();

			return loHelper.ObtenerConsignatario(poSesion, psClienteID, poFecha);
		}

		public DataTable ObtenerRemitente(Sesion poSesion, string psRazonSocial)
		{
			HelperImpresion loHelper = new HelperImpresion();

			return loHelper.ObtenerRemitente(poSesion, psRazonSocial);
		}

		#endregion
	}
}
