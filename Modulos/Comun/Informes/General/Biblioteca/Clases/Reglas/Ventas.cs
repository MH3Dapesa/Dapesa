using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dapesa.Comun.Informes.General.Reglas
{
    public class Ventas
    {
        #region Metodos
        public DataTable AnalisisVendedores(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal, string psCveVendedor, string psCveCliente, string psCveMarca, string psCveLinea, string psCveArticulo, string pnCveFiltroMonto, int pnFiltroMonto)
        {
            HelperVentas loHelper = new HelperVentas();
            DataTable loResultado = loHelper.AnalisisVendedores(poSesion, poFechaInicio, poFechaFin, psSucursal, psCveVendedor, psCveCliente, psCveMarca, psCveLinea, psCveArticulo, pnCveFiltroMonto, pnFiltroMonto);
            return loResultado;
        }

        public DataTable AnalisisGestor(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal, string psCveVendedor, string psCveCliente, string psCveMarca, string psCveLinea, string psCveArticulo, string pnCveFiltroMonto, int pnFiltroMonto)
        {
            HelperVentas loHelper = new HelperVentas();
            DataTable loResultado = loHelper.AnalisisGestor(poSesion, poFechaInicio, poFechaFin, psSucursal, psCveVendedor, psCveCliente, psCveMarca, psCveLinea, psCveArticulo, pnCveFiltroMonto, pnFiltroMonto);
            return loResultado;
        }

        public DataTable AnalisisCliente(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal, string psCveVendedor, string psCveCliente, string psCveMarca, string psCveLinea, string psCveArticulo, string pnCveFiltroMonto, int pnFiltroMonto)
        {
            HelperVentas loHelper = new HelperVentas();
            DataTable loResultado = loHelper.AnalisisCliente(poSesion, poFechaInicio, poFechaFin, psSucursal, psCveVendedor, psCveCliente, psCveMarca, psCveLinea, psCveArticulo, pnCveFiltroMonto, pnFiltroMonto);
            return loResultado;
        }

        public DataTable VentasMarcaLinea(Sesion poSesion, string psSucursal, DateTime poFechaInicio, DateTime poFechaFin, string psCveMarca, string psCveLinea, string psCveArticulos, bool poMostrarLineasSinVenta)
        {
            HelperVentas loHelper = new HelperVentas();
            DataTable loResultado = loHelper.VentasMarcaLinea(poSesion, psSucursal, poFechaInicio, poFechaFin, psCveMarca, psCveLinea, psCveArticulos, poMostrarLineasSinVenta);
            return loResultado;
        }

        public DataTable AnalisisVentasPorPoblacion(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal, string psCveVendedor, string psCveCliente, string psCveMarca, string psCveLinea, string psCveArticulo)
        {
            HelperVentas loHelper = new HelperVentas();
            DataTable loResultado = loHelper.AnalisisVentasPorPoblacion(poSesion, poFechaInicio, poFechaFin, psSucursal, psCveVendedor, psCveCliente, psCveMarca, psCveLinea, psCveArticulo);
            return loResultado;
        }

        public DataTable AnalisisVendedorIdeal(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal, string psCveVendedor)
        {
            HelperVentas loHelper = new HelperVentas();
            DataTable loResultado = loHelper.AnalisisVendedorIdeal(poSesion, poFechaInicio, poFechaFin, psSucursal, psCveVendedor);
            return loResultado;
        }

        public DataTable ObtenerItineario(Sesion poSesion, int pnClaveTLMK, int pnSucursal, int pnAnio, int pnSemana)
        {
            HelperVentas loResultado = new HelperVentas();
            return loResultado.ObtenerItineario(poSesion, pnClaveTLMK, pnSucursal, pnAnio, pnSemana);
        }

        public DataTable ObtenerTotalSemanal(Sesion poSesion, int pnClaveTLMK, DateTime poFechaSemanaActual, DateTime poFechaSemanaAnterior)
        {
            HelperVentas loHelper = new HelperVentas();

            return loHelper.ObtenerTotalSemanal(poSesion, pnClaveTLMK, poFechaSemanaActual, poFechaSemanaAnterior);
        }

        public DataTable ObtenerVtaMarcaGeo(Sesion poSesion, int pnSucursal, DateTime poFechaInicial, DateTime poFechaFinal)
        {
            HelperVentas loHelper = new HelperVentas();

            return loHelper.ObtenerVtaMarcaGeo(poSesion, pnSucursal, poFechaInicial, poFechaFinal); 
        }

        public DataTable ObtenerListaPrecios(Sesion poSesion, int pnCveListaPrecios, int pnAlmacen, string psCveMarca, string psCveLineas)
        {
            HelperVentas loHelper = new HelperVentas();

            return loHelper.ObtenerListaPrecios(poSesion, pnCveListaPrecios, pnAlmacen, psCveMarca, psCveLineas);
        }

        public DataTable AnalisisVentaVendedor(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal, string psCveVendedor, string psCveCliente, string psCveMarca, string psCveLinea, string psCveArticulo, string pnCveFiltroMonto, int pnFiltroMonto, string pnCveFiltroPiezas, int pnFiltroPiezas)
        {
            HelperVentas loHelper = new HelperVentas();
            DataTable loResultado = loHelper.AnalisisVentaVendedor(poSesion, poFechaInicio, poFechaFin, psSucursal, psCveVendedor, psCveCliente, psCveMarca, psCveLinea, psCveArticulo, pnCveFiltroMonto, pnFiltroMonto,  pnCveFiltroPiezas, pnFiltroPiezas);
            return loResultado;
        }

        public DataTable AnalisisVentaCliente(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal, string psCveVendedor, string psCveCliente, string psCveMarca, string psCveLinea, string psCveArticulo, string pnCveFiltroMonto, int pnFiltroMonto, string pnCveFiltroPiezas, int pnFiltroPiezas)
        {
            HelperVentas loHelper = new HelperVentas();
            DataTable loResultado = loHelper.AnalisisVentaCliente(poSesion, poFechaInicio, poFechaFin, psSucursal, psCveVendedor, psCveCliente, psCveMarca, psCveLinea, psCveArticulo, pnCveFiltroMonto, pnFiltroMonto, pnCveFiltroPiezas,  pnFiltroPiezas);
            return loResultado;
        }

        public DataTable ObtenerBackOrderPedidos(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, int pnSucursal, int? pnClaveVendedor, string psClaveCliente, int? pnPedidoNumero, string psPedidoFolio, string psArticuloClave, int? pnLineaClave, int? pnMarcaClave, int MostrarArticulos)
        {
            HelperVentas loHelper = new HelperVentas();

            return loHelper.ObtenerBackOrderPedidos(poSesion, poFechaInicio, poFechaFin, pnSucursal, pnClaveVendedor, psClaveCliente, pnPedidoNumero, psPedidoFolio, psArticuloClave, pnLineaClave, pnMarcaClave, MostrarArticulos);
        }

        public DataTable AnalisisVentaVendedor2(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal, string psCveVendedor, string psCveCliente, string psCveMarca, string psCveLinea, string psCveArticulo, string pnCveFiltroMonto, int pnFiltroMonto, string pnCveFiltroPiezas, int pnFiltroPiezas)
        {
            HelperVentas loHelper = new HelperVentas();
            DataTable loResultado = loHelper.AnalisisVentaVendedor2(poSesion, poFechaInicio, poFechaFin, psSucursal, psCveVendedor, psCveCliente, psCveMarca, psCveLinea, psCveArticulo, pnCveFiltroMonto, pnFiltroMonto, pnCveFiltroPiezas, pnFiltroPiezas);
            return loResultado;
        }

        #endregion
    }
}
