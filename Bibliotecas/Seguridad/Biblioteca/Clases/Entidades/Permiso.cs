using Dapesa.Seguridad.Comun;
using System.Collections.Generic;

namespace Dapesa.Seguridad.Entidades
{
	public class Permiso
	{
		#region Propiedades

		public long? Agrupador { get; set; }
		public Aplicacion Aplicacion { get; set; }
		public long Clave { get; set; }
		public string Descripcion { get; set; }
		public int Orden { get; set; }
		public Definiciones.TipoElemento TipoElemento { get; set; }
		public List<Definiciones.TipoPermiso> TipoPermiso { get; set; }
		public string Url { get; set; }

		#endregion
	}
}
