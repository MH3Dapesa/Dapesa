using System.ComponentModel;

namespace Dapesa.Informes.Comun
{
	public class Definiciones
	{
		#region Enumeraciones

		public enum TipoInforme { WindowsForm, Web };
		public enum TipoFormato
		{
			[DescriptionAttribute("Image")]EMF,
			[DescriptionAttribute("PDF")]PDF,
			[DescriptionAttribute("Word")]DOC,
			[DescriptionAttribute("Excel")]XLS
		};
		public enum TipoSalida { Archivo, Impresion };
		public enum TipoUnidaMedida
		{
			[DescriptionAttribute("cm")]Centimetros,
			[DescriptionAttribute("ft")]Pie,
			[DescriptionAttribute("in")]Pulgadas
		};

		#endregion
	}
}
