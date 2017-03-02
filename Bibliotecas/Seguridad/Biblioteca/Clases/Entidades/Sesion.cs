using Dapesa.Comun.Entidades;
using Dapesa.Seguridad.Comun;

namespace Dapesa.Seguridad.Entidades
{
	public class Sesion
	{
		#region Propiedades

		public Conexion Conexion { get; set; }
		public Definiciones.EstatusSesion Estatus { get; set; }
		public Usuario Usuario { get; set; }

		#endregion
	}
}
