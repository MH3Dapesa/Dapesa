using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapesa.Ventas.Pedidos.Comun
{
    public class Definiciones
    {
        #region Enumeraciones

        public enum FiltroMonitoreoPedidos
        {
            Ninguno = 0, SoloCliente, SoloLinea, LineaCliente,  LineaArticulo, Ambos
        }

        public enum FiltroMonitoreoPedidoCoincidir
        {
            Ninguno = 0, SoloCliente, SoloEstado, Ambos
        }

        #endregion
    }
}
