using System.Runtime.Serialization;

namespace Dapesa.Comun.Entidades
{
	[DataContract]
	public class Conexion
	{
		#region Propiedades

		[DataMember]public string BaseDatos { get; set; }
		[DataMember]public Credenciales Credenciales { get; set; }
		[DataMember]public string IdAplicacion { get; set; }
		[DataMember]public string IdServicio { get; set; }
		[DataMember]public string Nombre { get; set; }
		[DataMember]public string Puerto { get; set; }
		[DataMember]public string Servidor { get; set; }
		[DataMember]public Definiciones.TipoConexion Tipo { get; set; }
		[DataMember]public Definiciones.TipoCliente TipoCliente { get; set; }

		#endregion
	}
}
