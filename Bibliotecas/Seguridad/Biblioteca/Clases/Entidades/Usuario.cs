using Dapesa.Seguridad.Comun;
using System.Collections.Generic;

namespace Dapesa.Seguridad.Entidades
{
	public class Usuario
	{
		#region Propiedades

		public int Id { get; set; }
		public string Clave { get; set; }
		public Definiciones.EstatusUsuario Estatus { get; set; }
		public List<Grupo> Grupo { get; set; }
		public string Nombre { get; set; }
		public List<Permiso> Permiso { get; set; }
		public List<Sucursal> Sucursal { get; set; }

		#endregion
	}
}
