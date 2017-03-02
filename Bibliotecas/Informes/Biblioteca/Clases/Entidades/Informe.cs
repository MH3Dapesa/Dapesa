using Dapesa.Informes.Comun;
using Microsoft.Reporting.WebForms;

namespace Dapesa.Informes.Entidades
{
	public class Informe
	{
		#region Propiedades

		public double Alto { get; set; }
		public double Ancho { get; set; }
		public int Copias { get; set; }
		public string Extension { get; set; }
		public Definiciones.TipoFormato Formato { get; set; }
		public string Impresora { get; set; }
		public double MargenDerecho { get; set; }
		public double MargenInferior { get; set; }
		public double MargenIzquierdo { get; set; }
		public double MargenSuperior { get; set; }
		public string Nombre { get; set; }
		public Definiciones.TipoSalida Salida { get; set; }
		public Definiciones.TipoInforme Tipo { get; set; }
		public string Ubicacion { get; set; }
		public Definiciones.TipoUnidaMedida UnidadMedida { get; set; }
        //Adicionado el 27/08/2015
        //public object[] Parametros { get; set; }
        public ReportParameter[] Parametros { get; set; }

		#endregion
	}
}
