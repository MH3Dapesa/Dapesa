namespace Dapesa.Seguridad.Comun
{
	public class Definiciones
	{
		#region Enumeraciones

		public enum EstatusSesion { NoIniciada = 0, Iniciada, Expirada };
		public enum EstatusUsuario { NoValido = 0, Valido };
		public enum TipoElemento { NoVisual = 1, Menu, SubMenu };
		public enum TipoPermiso { Lectura = 1, Escritura, Guardar, Imprimir };

		#endregion
	}
}
