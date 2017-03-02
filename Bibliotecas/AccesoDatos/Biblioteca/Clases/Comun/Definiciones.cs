using System.Runtime.Serialization;

namespace Dapesa.AccesoDatos.Comun
{
	[DataContract]
	public class Definiciones
	{
		#region Enumeraciones

		[DataContract]
		public enum TipoManejadorTransaccion { 
			[EnumMember]ContinuarTransaccion, 
			[EnumMember]FinalizarTransaccion, 
			[EnumMember]IniciarTransaccion, 
			[EnumMember]NoTransaccion 
		};

		[DataContract]
		public enum TipoResultado { 
			[EnumMember]Cadena, 
			[EnumMember]Conjunto, 
			[EnumMember]Decimal, 
			[EnumMember]Entero, 
			[EnumMember]Vacio = -1
		};

		[DataContract]
		public enum TipoSentencia { 
			[EnumMember]Escalar,
			[EnumMember]NoQuery,
			[EnumMember]Query
		};

		#endregion
	}
}
