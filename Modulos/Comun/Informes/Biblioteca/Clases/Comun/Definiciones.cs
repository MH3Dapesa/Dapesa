using System.ComponentModel;

namespace Dapesa.Comun.Informes.Comun
{
	public class Definiciones
	{
		#region Enumeraciones

		public enum TipoSubreporte
		{
			[DescriptionAttribute("AnalisisDetalle")]Detalle,
			[DescriptionAttribute("MotivosInactivacion")]MInac,
			[DescriptionAttribute("AnalisisMarca")]DetalleMarca,
			[DescriptionAttribute("AnalisisLinea")]DetalleLinea,
            [DescriptionAttribute("DiasConPedidosDetalle")]DiasConPedidosDetalle,
            [DescriptionAttribute("FolioPedidosDias")]FolioPedidosDias,
            [DescriptionAttribute("ArticulosPedidosDias")]ArticulosPedidosDias
		}
		public enum TipoEstatusCliente
		{
			[DescriptionAttribute("A")]Activo,
			[DescriptionAttribute("I")]Inactivo
		}
		public enum TipoFiltrosReporteClientesConDecremento
		{
			Ninguno = 0, SoloVendedor, SoloMarca, Ambos
		}
		public enum TipoSemaforoVenta
		{
			[DescriptionAttribute("Nulo")]SinVenta,
			[DescriptionAttribute("Azul")]MesActual,
			[DescriptionAttribute("Blanco")]MenorIgual90Dias,
			[DescriptionAttribute("Rojo")]Mayor90Dias
		}
        public enum TipoFiltrosReporteVentasPorDias
        {
            Ninguno = 0, Ambos
        }
       
		#endregion
	}
}
