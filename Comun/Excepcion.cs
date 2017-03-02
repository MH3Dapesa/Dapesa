using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contabilidad.Comun
{
    public class Excepcion : ApplicationException
    {
        /// <summary>
        /// Lanza una excepción específica del proceso de pedidos CXC
        /// </summary>
        /// <param name="psMensaje">Mensaje de error</param>
        /// <param name="poExcepcionOriginal">Excepción original</param>
        public Excepcion(string psMensaje, Exception poExcepcionOriginal)
            : base(psMensaje, poExcepcionOriginal)
        {

        }

        /// <summary>
        /// Lanza una excepción específica del proceso de pedidos CXC
        /// </summary>
        /// <param name="psMensaje">Mensaje de error</param>
        public Excepcion(string psMensaje)
            : base(psMensaje)
        {

        }
    }
}
