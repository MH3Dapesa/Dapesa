using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dapesa.Comun.Informes.Credito.Reglas
{
    public class Catalogos
    {
        #region Metodos

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

        public DataTable ObtenerGestores(Sesion poSesion, string psClaveSucursal, int pnIndicadorFila)
        {
            HelperCatalogos loHelper = new HelperCatalogos();

            return loHelper.ObtenerGestores(poSesion, psClaveSucursal, pnIndicadorFila);
        }

        public DataTable ObtenerAuxiliares(Sesion poSesion, string psClaveSucursal, int pnClaveAuxiliar)
        {
            HelperCatalogos loHelper = new HelperCatalogos();

            return loHelper.ObtenerAuxiliares(poSesion, psClaveSucursal, pnClaveAuxiliar);
        }

        #endregion
    }
}
