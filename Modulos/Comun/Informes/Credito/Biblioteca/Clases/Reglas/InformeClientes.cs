using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dapesa.Comun.Informes.Credito.Reglas
{
    public class InformeClientes
    {
        #region Metodos
        public DataTable ObtenerClientes(Sesion poSesion, int psClaveSucursal, string psClaveVendedor, string psCliente)
        {
            HelperInformeClientes loHelper = new HelperInformeClientes();
            DataTable loResultado = loHelper.ObtenerClientes(poSesion, psClaveSucursal, psClaveVendedor, psCliente);
            return loResultado;
        }

        public DataTable CobrosDiarios(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, int psClaveSucursal, string psClaveVendedor, string psCliente)
        {
            HelperInformeClientes loHelper = new HelperInformeClientes();
            DataTable loResultado = loHelper.CobrosDiarios(poSesion, poFechaInicio, poFechaFin, psClaveSucursal, psClaveVendedor, psCliente);
            return loResultado;
        }

        public DataTable ObtenerAntiguedadSaldos(Sesion poSesion, int psClaveSucursal, DateTime poFecha, int pnDiasPeriodo, int pnTipoFecha, int pnDiasAdicionales, string psClaveGestor, string psCliente)
        {
            HelperInformeClientes loHelper = new HelperInformeClientes();
            DataTable loResultado = loHelper.ObtenerAntiguedadSaldos(poSesion, psClaveSucursal, poFecha, pnDiasPeriodo, pnTipoFecha, pnDiasAdicionales, psClaveGestor, psCliente);
            return loResultado;
        }

        public DataTable ObtenerAntiguedadSaldosGeneral(Sesion poSesion, int psClaveSucursal, DateTime poFecha, int pnDiasPeriodo, int pnTipoFecha, int pnDiasAdicionales, string psClaveGestor, string psCliente, int pnIndicadorUsuario)
        {
            HelperInformeClientes loHelper = new HelperInformeClientes();
            DataTable loResultado = loHelper.ObtenerAntiguedadSaldosGeneral(poSesion, psClaveSucursal, poFecha, pnDiasPeriodo, pnTipoFecha, pnDiasAdicionales, psClaveGestor, psCliente, pnIndicadorUsuario);
            return loResultado;
        }

        public DataTable ObtenerAntiguedadSaldosAuxiliar(Sesion poSesion, int psClaveSucursal, DateTime poFecha, int pnDiasPeriodo, int pnTipoFecha, int pnDiasAdicionales, string psClaveGestor, string psCliente, int pnIndicadorUsuario)
        {
            HelperInformeClientes loHelper = new HelperInformeClientes();
            DataTable loResultado = loHelper.ObtenerAntiguedadSaldosAuxiliar(poSesion, psClaveSucursal, poFecha, pnDiasPeriodo, pnTipoFecha, pnDiasAdicionales, psClaveGestor, psCliente, pnIndicadorUsuario);
            return loResultado;
        }

        public int ObtenerClienteSinAsignar(Sesion poSesion, int psClaveSucursal)
        {
            HelperInformeClientes loHelper = new HelperInformeClientes();
            int loResultado = loHelper.ObtenerClienteSinAsignar(poSesion, psClaveSucursal);
            return loResultado;
        }

        public DataTable ObtenerEmailPersonal(Sesion poSesion, int pnClaveSucursal)
        {
            HelperInformeClientes loHelper = new HelperInformeClientes();
            DataTable loResultado = loHelper.ObtenerEmailPersonal(poSesion, pnClaveSucursal);
            return loResultado;
        }
        #endregion
    }
}
