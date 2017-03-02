using Dapesa.Seguridad.Entidades;
using System;
using System.Data;

namespace Comun.Clientes.Reglas
{
    public class Clientes
    {
        #region Metodos

        public DataTable ObtenerCliente(Sesion poSesion, string psCliente)
        {
            HelperClientes loHelper = new HelperClientes();

            return loHelper.ObtenerCliente(poSesion, psCliente);
        }

        #endregion
    }
}
