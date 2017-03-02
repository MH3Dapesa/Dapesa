using System.ComponentModel;

namespace Dapesa.Comun.DirectorioActivo.Comun
{
	public class Definiciones
	{
		#region Enumeraciones

		public enum TipoComando
		{
			[DescriptionAttribute("Cancelar")]Cancelar,
			[DescriptionAttribute("MostrarDetalles")]MostrarDetalle
		}
		public enum TipoPropiedad
		{
			[DescriptionAttribute("sn")]Apellido,
			[DescriptionAttribute("postOfficeBox")]Colonia,
			[DescriptionAttribute("company")]Compania,
			[DescriptionAttribute("mail")]Correo,
			[DescriptionAttribute("postalCode")]CP,
			[DescriptionAttribute("department")]Departamento,
			[DescriptionAttribute("streetAddress")]Direccion,
			[DescriptionAttribute("userAccountControl")]Estatus,
			[DescriptionAttribute("st")]Estado,
			[DescriptionAttribute("pager")]Extension,
			[DescriptionAttribute("mobile")]Movil,
			[DescriptionAttribute("givenName")]Nombre,
			[DescriptionAttribute("name")]NombreCompleto,
			[DescriptionAttribute("title")]Puesto,
			[DescriptionAttribute("ipPhone")]Radio,
			[DescriptionAttribute("l")]Sucursal,
			[DescriptionAttribute("telephoneNumber")]Telefono,
			[DescriptionAttribute("initials")]Titulo,
			[DescriptionAttribute("samAccountName")]UsuarioDominio,
			[DescriptionAttribute("userPrincipalName")]UsuarioPrincipal
		};

		#endregion
	}
}
