using Dapesa.Seguridad.Entidades;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;


namespace Dapesa.Ventas.Pedidos.Reglas
{
    public class DiagnosticoPedidos
    {
        public DataTable BuscarPedidos(Sesion _oSesion, int pnRangoDias, int pnSucursal, string psMarcas, string psLineas, string psArticulos, String pbEstados, String psClientes, bool poCoincidirEstados, bool poCoincidirClientes)
        {
            //string lsUbicacionOrigen = ConfigurationManager.AppSettings["UbicacionOrigen"];  //ruta origen


            HelperDiagnosticoPedidos loHelper = new HelperDiagnosticoPedidos();

            return loHelper.BuscarPedidos(_oSesion, pnRangoDias, pnSucursal, psMarcas, psLineas, psArticulos, pbEstados, psClientes, poCoincidirEstados, poCoincidirClientes);

        }

        public DataTable BuscarFacturas(Sesion _oSesion, int pnRangoDias, int pnSucursal, string psMarcas, string psLineas, string psArticulos, String pbEstados, String psClientes, bool poCoincidirEstados, bool poCoincidirClientes)
        {
            //string lsUbicacionOrigen = ConfigurationManager.AppSettings["UbicacionOrigen"];  //ruta origen


            HelperDiagnosticoPedidos loHelper = new HelperDiagnosticoPedidos();

            return loHelper.BuscarFacturas(_oSesion, pnRangoDias, pnSucursal, psMarcas, psLineas, psArticulos, pbEstados, psClientes, poCoincidirEstados, poCoincidirClientes);

        }

    }
}
