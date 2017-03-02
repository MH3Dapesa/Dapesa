using System.ComponentModel;
using System.Runtime.Serialization;

namespace Dapesa.Criptografia.Comun
{
	[DataContract]
	public class Definiciones
	{
		#region Enumeraciones

		[DataContract]
		public enum TipoCifrado { 
			[EnumMember]AES,
			[EnumMember]MD5,
			[EnumMember]SHA1
		};

		[DataContract]
		public enum TipoFuente {
			[EnumMember][DescriptionAttribute("Barcode39")]BARCODE39,
			[EnumMember][DescriptionAttribute("FreeCode39")]CODE39,
			[EnumMember][DescriptionAttribute("FreeCode39X")]CODE39X,
			[EnumMember][DescriptionAttribute("EAN_13")]EAN13
		};

		#endregion
	}
}
