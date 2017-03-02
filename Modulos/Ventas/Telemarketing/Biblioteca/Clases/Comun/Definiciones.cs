using System;
using System.ComponentModel;

namespace Dapesa.Ventas.Telemarketing.Comun
{
	public class Definiciones
	{
		#region Delegados

		public delegate void TextoModificadoManejadorEvento(object sender, ArgumentosEvento e);
		public delegate void ContactoAgregadoManejadorEvento(object sender, EventArgs e);

		#endregion

		#region Enumeraciones

		public enum TipoAsignacion
		{
			[DescriptionAttribute("O")]Original,
			[DescriptionAttribute("T")]Temporal
		}
		public enum TipoContactoCliente
		{
			[DescriptionAttribute("VENTAS")]Ventas = 1,
			[DescriptionAttribute("PAGOS")]Pagos,
			[DescriptionAttribute("PROPIETARIO")]Propietario,
			[DescriptionAttribute("Compras")]Compras,
			
		}
		public enum TipoEstatusCliente
		{
			[DescriptionAttribute("A")]Activo,
			[DescriptionAttribute("I")]Inactivo
		}
		public enum TipoEstatusRegistro
		{
			[DescriptionAttribute("N")]Activo,
			[DescriptionAttribute("S")]Inactivo
		}
		public enum TipoLayoutCliente { ClaveCliente = 0, ClaveUsuario, Estatus, ClaveVendedor };
		public enum TipoLayoutContacto { ClaveCliente = 0, Nombre, ApellidoPaterno, Apodo, Puesto, Telefono, Celular, Nextel, Correo, Observaciones };

		#endregion
	}
}
