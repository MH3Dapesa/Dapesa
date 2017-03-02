using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dapesa.Credito.Pedidos.Reglas
{
    public class MensajeroCXC
    {

        #region Metodos

        public DataTable ObtenerSucursales(Sesion poSesion, int psCveUsuario)
        {
            HelperMensajeroCXC loHelper = new HelperMensajeroCXC();

            return loHelper.ObtenerSucursales(poSesion, psCveUsuario);
        }

        public DataTable ObtenerPedidos(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, int pnSucursal)
        {
            HelperMensajeroCXC loHelper = new HelperMensajeroCXC();

            return loHelper.ObtenerPedidos(poSesion, poFechaInicio, poFechaFin, pnSucursal);
        }
        #endregion

    }
}
