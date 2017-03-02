using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;


namespace Credito.Clientes.Cartera.Reglas
{
    public class AnalisisCliente
    {
        #region Metodos

        public DataTable ObtenerVentaCliente(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psClaveCliente)
        {
            HelperAnalisisCliente loHelper = new HelperAnalisisCliente();

            return loHelper.ObtenerVentaCliente(poSesion, poFechaInicio, poFechaFin, psClaveCliente);
        }

        public DataTable ObtenerClienteEncabezado(Sesion poSesion,string psClaveCliente)
        {
            HelperAnalisisCliente loHelper = new HelperAnalisisCliente();

            return loHelper.ObtenerClienteEncabezado(poSesion, psClaveCliente);
        }

        #endregion
    }
}
