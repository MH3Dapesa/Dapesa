using Dapesa.Comun.Informes.Entidades;
using Dapesa.Seguridad.Entidades;
using System;
using System.Data;

namespace Dapesa.Comun.Informes.Reglas
{
	public class Ventas
	{
		#region Metodos

		public DataTable ObtenerAnalisisAnual(Sesion poSesion, string psClaveSucursal, string psClaveVendedor, string psClaveMarca,bool pbMostrarClienteEliminado)
		{
			HelperVentas loHelper = new HelperVentas();

			return loHelper.ObtenerAnalisisAnual(poSesion, psClaveSucursal, psClaveVendedor, psClaveMarca,pbMostrarClienteEliminado);
		}

		public DataTable ObtenerAnalisisAnualMarcas(Sesion poSesion, string psClaveCliente, string psClaveMarca)
		{
			HelperVentas loHelper = new HelperVentas();

			return loHelper.ObtenerAnalisisAnualMarcas(poSesion, psClaveCliente, psClaveMarca);
		}

        //Revisar
        public DataTable ObtenerAnalisisAnualLineas(Sesion poSesion, string psClaveCliente, string psClaveMarca)
        {
            HelperVentas loHelper = new HelperVentas();

            return loHelper.ObtenerAnalisisAnualLineas(poSesion, psClaveCliente, psClaveMarca);
        }


        public DataTable ObtenerAnalisisAnualArticulos(Sesion poSesion, string psClaveCliente, string psClaveLinea)
        {
            HelperVentas loHelper = new HelperVentas();

            return loHelper.ObtenerAnalisisAnualArticulos(poSesion, psClaveCliente, psClaveLinea);
        }

		public Cliente ObtenerAnalisisAnualMotivosInac(Sesion poSesion, string psClaveCliente)
		{
			HelperVentas loHelper = new HelperVentas();

			return loHelper.ObtenerAnalisisAnualMotivosInac(poSesion, psClaveCliente);
		}

		public DataTable ObtenerAsignaciones(Sesion poSesion, string psClaveSucursal, string psClavePersonal, string psEstatus, string psSemaforo)
		{
			HelperVentas loHelper = new HelperVentas();

			return loHelper.ObtenerAsignaciones(poSesion, psClaveSucursal, psClavePersonal, psEstatus, psSemaforo);
		}

        //agregado 
        public DataTable ObtenerVentasPorDias(Sesion poSesion,DateTime poFechaInicial, DateTime poFechaFinal, int piCantidadDias, string psClaveSucursal, string psClaveVendedor,string psClavesComodines, bool pbMostrarClienteEliminado, bool pbMostrarClienteCeroPedidos)
        {
            HelperVentas loHelper = new HelperVentas();

            return loHelper.ObtenerVentasPorDias(poSesion, poFechaInicial, poFechaFinal, piCantidadDias, psClaveSucursal, psClaveVendedor, psClavesComodines,pbMostrarClienteEliminado, pbMostrarClienteCeroPedidos);                                               
        }


        public DataTable ObtenerVentasPorDiasDetalle(Sesion poSesion, string psClaveCliente, int piClaveSucursal, DateTime poFechaInicial, DateTime poFechaFinal, int piClaveVendedor, string psClavesComodines)
        {
            HelperVentas loHelper = new HelperVentas();

            return loHelper.ObtenerVentasPorDiasDetalle(poSesion, psClaveCliente, piClaveSucursal, poFechaInicial, poFechaFinal, piClaveVendedor, psClavesComodines);
        }


        public DataTable ObtenerFolioPedidosDias(Sesion poSesion, string psClaveCliente, int piClaveSucursal, DateTime poFechaInicial,  int piClaveVendedor, string psClavesComodines)
        {
            HelperVentas loHelper = new HelperVentas();

            return loHelper.ObtenerFolioPedidosDias(poSesion, psClaveCliente, piClaveSucursal, poFechaInicial, piClaveVendedor, psClavesComodines);
        }

        public DataTable ObtenerArticulosPedidosDias(Sesion poSesion, string psClaveCliente, int piClaveSucursal, DateTime poFechaInicial,string psFolio,int piNumero, int piClaveVendedor, string psClavesComodines)
        {
            HelperVentas loHelper = new HelperVentas();

            return loHelper.ObtenerArticulosPedidosDias(poSesion, psClaveCliente, piClaveSucursal, poFechaInicial,psFolio, piNumero,piClaveVendedor, psClavesComodines);
        }


		#endregion
	}
}
