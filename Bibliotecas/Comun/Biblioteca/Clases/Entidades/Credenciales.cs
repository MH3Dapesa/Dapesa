using Dapesa.Criptografia.Reglas;
using System.Runtime.Serialization;

namespace Dapesa.Comun.Entidades
{
	[DataContract]
	public class Credenciales
	{
		#region Propiedades

		[DataMember]public Cifrado Cifrado { get; set; }
		[DataMember]public byte[] Contrasenia { get; set; }
		[DataMember]public string Usuario { get; set; }
				
		#endregion
	}
}
