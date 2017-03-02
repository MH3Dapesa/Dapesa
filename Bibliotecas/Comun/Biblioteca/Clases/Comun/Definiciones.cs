using System.Runtime.Serialization;

namespace Dapesa.Comun
{
	[DataContract]	
	public class Definiciones
	{
		#region Enumeraciones
		[DataContract]
		public enum TipoCliente { 
			[EnumMember]MySql,
			[EnumMember]Oracle,
			[EnumMember]SqlServer
		};

		[DataContract]
		public enum TipoConexion {
			[EnumMember]CredencialesExplicitas,
			[EnumMember]NombreConexion, 
			[EnumMember]NoTNSNAMES 
		};

		#endregion
	}
}
