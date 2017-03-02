using Dapesa.AccesoDatos.Comun;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;

namespace Dapesa.AccesoDatos.Entidades
{
	[DataContract]
	[KnownType(typeof(Parametro))]
	public class Sentencia
	{
		#region Propiedades

		[DataMember]public List<Parametro> Parametros { get; set; }
		[DataMember]public string TextoComando { get; set; }
		[DataMember]public Definiciones.TipoSentencia Tipo { get; set; }
		[DataMember]public CommandType TipoComando { get; set; }
		[DataMember]public Definiciones.TipoResultado TipoResultado { get; set; }
		[DataMember]public Definiciones.TipoManejadorTransaccion TipoManejadorTransaccion { get; set; }

		#endregion
	}
}
