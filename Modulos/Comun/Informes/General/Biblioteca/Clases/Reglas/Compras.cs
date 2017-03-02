using Dapesa.Seguridad.Entidades;
using System;
using System.Data;

namespace Dapesa.Comun.Informes.General.Reglas
{
    public class Compras
    {
        public DataTable obtenerVentasResumenPorMarca(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal)
        {
            HelperCompras loHelperCompras = new HelperCompras();
            return loHelperCompras.obtenerVentasResumenPorMarca(poSesion, poFechaInicio, poFechaFin, psSucursal);
        }
    }
}
