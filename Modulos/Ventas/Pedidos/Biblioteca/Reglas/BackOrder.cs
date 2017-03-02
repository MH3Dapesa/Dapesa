using Dapesa.Seguridad.Entidades;
using System;
using System.Data;
using System.Text;

namespace Ventas.Pedidos.BackOrder.Reglas
{
    public class BackOrder
    {
        #region Metodos

        public DataTable ObtenerBackOrderPedidos(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, int pnSucursal, int? pnClaveVendedor, string psClaveCliente, int? pnPedidoNumero, string psPedidoFolio, string psArticuloClave, int? pnLineaClave, int? pnMarcaClave, int MostrarArticulos)
        {
            HelperBackOrder loHelper = new HelperBackOrder();

            return loHelper.ObtenerBackOrderPedidos(poSesion, poFechaInicio, poFechaFin, pnSucursal, pnClaveVendedor, psClaveCliente, pnPedidoNumero, psPedidoFolio, psArticuloClave, pnLineaClave, pnMarcaClave, MostrarArticulos);
        }
        #endregion
    }
}
