using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dapesa.Compras.OrdenCompra.Reglas
{
    public class CompraOrden
    {
        public DataTable Obtener(Sesion poSesion, string psFolioOrdenCompra, int pnSucursal)
        {
            HelperCompraOrden loHelper = new HelperCompraOrden();

            return loHelper.Obtener(poSesion, psFolioOrdenCompra, pnSucursal);
        }

        public DataTable ObtenerDatosOrdenCompra(Sesion poSesion, string psFolioOrdenCompra, int pnNumeroOrdenCompra, int pnSucursal)
        {
            HelperCompraOrden loHelper = new HelperCompraOrden();

            return loHelper.ObtenerDatosOrdenCompra(poSesion, psFolioOrdenCompra, pnNumeroOrdenCompra, pnSucursal);
        }

        public DataTable ObtenerSucursal(Sesion poSesion, string psClavePersonal)
        {
            HelperCompraOrden loHelper = new HelperCompraOrden();

            return loHelper.ObtenerSucursal(poSesion, psClavePersonal);
        }

        public DataTable ObtenerProveedores(Sesion poSesion)
        {
            HelperCompraOrden loHelper = new HelperCompraOrden();
   
           
            return loHelper.ObtenerProveedores(poSesion);
        }
    }
}
