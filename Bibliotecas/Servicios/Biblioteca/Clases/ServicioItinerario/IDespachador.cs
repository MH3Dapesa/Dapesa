using Dapesa.AccesoDatos.Entidades;
using Dapesa.Comun.Entidades;
using System.Collections.Generic;
using System.ServiceModel;

namespace Dapesa.Servicios.ServicioItinerario
{
	[ServiceContract]
	public interface IDespachador
	{
		#region Operaciones

		[OperationContract]
		bool Validar(Conexion poConexion);

		[OperationContract]
		object Despachar(Conexion poConexion, List<Sentencia> poSentencia);

		#endregion
	}
}
