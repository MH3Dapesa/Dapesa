using Dapesa.Comun.Entidades;

namespace Dapesa.Seguridad.Reglas
{
	public class Administrador
	{
		#region Metodos

		public Entidades.Sesion ObtenerSesion(Conexion poConexion)
		{
			Sesion loSesion = new Sesion();
				
			return loSesion.Obtener(poConexion);
		}

		#endregion
	}
}
