using System;

namespace Dapesa.Comun.Informes.Entidades
{
	public class Cliente
	{
		#region Propiedades

		public string Clave { get; set; }
		public string Estatus { get; set; }
		public DateTime FechaInac { get; set; }
		public string MotivosInac { get; set; }
		public string Nombre { get; set; }
		
		#endregion
	}
}
