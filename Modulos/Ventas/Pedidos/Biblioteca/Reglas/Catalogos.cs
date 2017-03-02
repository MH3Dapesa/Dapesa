using Dapesa.Seguridad.Entidades;
using System;
using System.Data;

namespace Ventas.Pedidos.BackOrder.Reglas
{
   public class Catalogos
    {
       public DataTable ObtenerMarcas(Sesion poSesion, int pnIndicadorFila)
       {
           HelperCatalogos loHelper = new HelperCatalogos();

           return loHelper.ObtenerMarcas(poSesion, pnIndicadorFila);
       }
       public DataTable ObtenerLineasArticulos(Sesion poSesion,int pnCveMarca, int pnIndicadorFila)
       {
           HelperCatalogos loHelper = new HelperCatalogos();

           return loHelper.ObtenerLineasArticulos(poSesion, pnCveMarca, pnIndicadorFila);
       }
        public DataTable ObtenerSucursales(Sesion poSesion, int pnIndicadorFila)
        {
            HelperCatalogos loHelper = new HelperCatalogos();

            return loHelper.ObtenerSucursales(poSesion, pnIndicadorFila);
        }
        public DataTable ObtenerVendedores(Sesion poSesion, string psClaveSucursal, int pnIndicadorFila, int pnIndicadorCve)
        {
            HelperCatalogos loHelper = new HelperCatalogos();

            return loHelper.ObtenerVendedores(poSesion, psClaveSucursal, pnIndicadorFila, pnIndicadorCve);
        }
    }
}
