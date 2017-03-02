using System;

namespace Dapesa.Comun.DirectorioActivo.Entidades
{
	[Serializable]
	public class Usuario
	{
		#region Propiedades

		public string Apellido  { get; set; }
		public string Colonia { get; set; }
		public string Compania { get; set; }
		public int Consecutivo { get; set; }
		public string Correo { get; set; }
		public string CP { get; set; }
		public string Departamento { get; set; }
		public string Direccion { get; set; }
		public string Estado { get; set; }
		public bool? Estatus { get; set; }
		public string Extension { get; set; }
		public string Movil { get; set; }
		public string Nombre { get; set; }
		public string NombreCompleto { get; set; }
		public string Puesto { get; set; }
		public string Radio { get; set; }
		public string Sucursal { get; set; }
		public string Telefono { get; set; }
		public string Titulo { get; set; }
		public string UsuarioDominio { get; set; }
		public string UsuarioPrincipal { get; set; }
		
		#endregion
	}
}
