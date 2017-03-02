using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dapesa.Comun.Informes.General.Reglas
{
    public class DatosClientes
    {
        #region Metodos
            public DataTable ObtenerClientes (Sesion poSesion, int psClaveSucursal, string psClaveVendedor, string psCliente)
            {
                HelperDatosClientes loHelper = new HelperDatosClientes();
                DataTable loResultado = loHelper.ObtenerClientes(poSesion, psClaveSucursal, psClaveVendedor, psCliente);
                return loResultado;
            }
        #endregion
    }
}
