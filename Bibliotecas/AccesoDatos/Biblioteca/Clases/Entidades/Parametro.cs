using System.Data;
using System.Runtime.Serialization;

namespace Dapesa.AccesoDatos.Entidades
{
	[DataContract]
	public class Parametro
	{
		#region Propiedades

		[DataMember]public ParameterDirection Direccion { get; set; }
		[DataMember]public string Nombre { get; set; }
		[DataMember]public DbType Tipo { get; set; }
		[DataMember]public object Valor { get; set; }

		#endregion
	}
}
