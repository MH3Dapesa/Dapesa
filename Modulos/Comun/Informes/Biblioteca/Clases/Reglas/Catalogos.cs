using Dapesa.Seguridad.Entidades;
using System;
using System.Data;

namespace Dapesa.Comun.Informes.Reglas
{
	public class Catalogos
	{
		#region Metodos

		public DataTable ObtenerMarcas(Sesion poSesion, int pnIndicadorFila)
		{
			HelperCatalogos loHelper = new HelperCatalogos();

			return loHelper.ObtenerMarcas(poSesion, pnIndicadorFila);
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

        public DataTable ObtenerVendedoresTlmk(Sesion poSesion, string psClaveSucursal, int pnIndicadorFila, int pnIndicadorCve)
        {
            HelperCatalogos loHelper = new HelperCatalogos();

            return loHelper.ObtenerVendedoresTlmk(poSesion, psClaveSucursal, pnIndicadorFila, pnIndicadorCve);
        }

        public DataTable ObtenerClientes(Sesion poSesion, int pnIndicadorFila, int pnIndicadorCve, int psClaveSucursal, int pnClaveVendedor)
        {
            HelperCatalogos loHelper = new HelperCatalogos();

            return loHelper.ObtenerClientes(poSesion, pnIndicadorFila, pnIndicadorCve, psClaveSucursal, pnClaveVendedor);
        }


        public DataTable ObtenerComodines(Sesion poSesion,int lnClaveSucursal, int lnClaveVendedor,DateTime ldFechaInicial, DateTime ldFechaFinal)
        {
            HelperCatalogos loHelper = new HelperCatalogos();

            return loHelper.ObtenerComodines(poSesion, lnClaveSucursal, lnClaveVendedor, ldFechaInicial, ldFechaFinal);
        }
      

		#endregion
	}
}
