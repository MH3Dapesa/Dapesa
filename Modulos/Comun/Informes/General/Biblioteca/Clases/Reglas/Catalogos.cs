using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dapesa.Comun.Informes.General.Reglas
{
    public class Catalogos
    {
        #region Metodos

        public DataTable ObtenerMarcas(Sesion poSesion, int pnIndicadorFila)
        {
            HelperCatalogos loHelper = new HelperCatalogos();

            return loHelper.ObtenerMarcas(poSesion, pnIndicadorFila);
        }
        public DataTable ObtenerLineasArticulos(Sesion poSesion, int pnCveMarca, int pnIndicadorFila)
        {
            HelperCatalogos loHelper = new HelperCatalogos();

            return loHelper.ObtenerLineasArticulos(poSesion, pnCveMarca, pnIndicadorFila);
        }

        public DataTable ObtenerSucursales(Sesion poSesion, int pnIndicadorFila)
        {
            HelperCatalogos loHelper = new HelperCatalogos();

            return loHelper.ObtenerSucursales(poSesion, pnIndicadorFila);
        }

        public DataTable ObtenerTelemarketings(Sesion poSesion, string psClaveSucursal, int pnIndicadorFila)
        {
            HelperCatalogos loHelper = new HelperCatalogos();

            return loHelper.ObtenerTelemarketings(poSesion, psClaveSucursal, pnIndicadorFila);
        }

        public DataTable ObtenerVendedores(Sesion poSesion, string psClaveSucursal, int pnIndicadorFila, int pnIndicadorCve)
        {
            HelperCatalogos loHelper = new HelperCatalogos();

            return loHelper.ObtenerVendedores(poSesion, psClaveSucursal, pnIndicadorFila, pnIndicadorCve);
        }

        public DataTable ObtenerAlmacenes(Sesion poSesion, int pnIndicadorFila)
        {
            HelperCatalogos loHelper = new HelperCatalogos();

            return loHelper.ObtenerAlmacenes(poSesion, pnIndicadorFila);
        }

        public DataTable ObtenerListasPrecios(Sesion poSesion)
        {
            HelperCatalogos loHelper = new HelperCatalogos();

            return loHelper.ObtenerListasPrecios(poSesion);
        }

        #endregion
    }
}
