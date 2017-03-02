using Dapesa.Seguridad.Entidades;
using System.Data;

namespace Dapesa.Almacen.Pedidos.Trazabilidad.Reglas
{
	public class Documentacion
	{
		#region Metodos

		public DataTable ObtenerConsignatario(Sesion poSesion, string psClienteID, string psPolizaSeguro)
		{
			HelperDocumentacion loHelper = new HelperDocumentacion();

			return loHelper.ObtenerConsignatario(poSesion, psClienteID, psPolizaSeguro);
		}

		public DataTable ObtenerRemitente(Sesion poSesion, string psRazonSocial)
		{
			HelperDocumentacion loHelper = new HelperDocumentacion();

			return loHelper.ObtenerRemitente(poSesion, psRazonSocial);
		}

		public DataTable ObtenerTransportistas(Sesion poSesion)
		{
			HelperDocumentacion loHelper = new HelperDocumentacion();

			return loHelper.ObtenerTransportistas(poSesion);
		}

		#endregion
	}
}
