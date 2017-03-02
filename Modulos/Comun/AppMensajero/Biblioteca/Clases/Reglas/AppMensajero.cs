using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dapesa.Comun.Pedidos.Reglas
{
    public class AppMensajero
    {
        #region Metodos

        public DataTable ObtenerSucursales(Sesion poSesion, int psCveUsuario)
        {
            HelperAppMensajero loHelper = new HelperAppMensajero();

            return loHelper.ObtenerSucursales(poSesion, psCveUsuario);
        }

        public DataTable ObtenerPedidos(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, int pnSucursal)
        {
            HelperAppMensajero loHelper = new HelperAppMensajero();

            return loHelper.ObtenerPedidos(poSesion, poFechaInicio, poFechaFin, pnSucursal);
        }


        #endregion
    }
}
