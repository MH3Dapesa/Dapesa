using Dapesa.Comun.Utilerias;
using Dapesa.Seguridad.Entidades;
using Dapesa.Credito.Clientes.Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Credito.Clientes.Entidades;

namespace Dapesa.Credito.Clientes.Reglas
{
    public class LayoutCliente
    {
        #region Metodos

        public DataTable ObtenerSucursal(Sesion poSesion)
        {
            HelperLayoutCliente loHelper = new HelperLayoutCliente();
            return loHelper.ObtenerSucursal(poSesion);
        }

        public bool Asignar(Sesion poSesion, string psClaveGestores, List<DataRowView> poClientes, bool poIdenticador)
        {
            List<Asignacion> loAsignaciones = new List<Asignacion>();
            HelperLayoutCliente loHelper = new HelperLayoutCliente();

            #region Procesar asignaciones...

            foreach (DataRowView poCliente in poClientes)
                loAsignaciones.Add(new Asignacion()
                {
                    #region Inicializar propiedades

                    ClaveCliente = poCliente["DESCRIPCION"].ToString(),
                    ClaveUsuario = psClaveGestores,
                    Estatus = Clientes.Comun.Definiciones.TipoEstatusRegistro.Activo.Descripcion()

                    #endregion initialize
                });

            #endregion 

            return loHelper.Guardar(poSesion, loAsignaciones, poIdenticador);
        }

        public bool Suprimir(Sesion poSesion, string psClaveAuxiliar, List<DataRowView> poClientes, bool poIdentificador)
        {
            List<Asignacion> loAsignaciones = new List<Asignacion>();
            HelperLayoutCliente loHelper = new HelperLayoutCliente();

            #region Suprimir asignaciones...

            foreach (DataRowView poCliente in poClientes)
                loAsignaciones.Add(new Asignacion()
                {
                    #region Inicializar propiedades

                    ClaveCliente = poCliente["DESCRIPCION"].ToString(),
                    ClaveUsuario = psClaveAuxiliar,

                    #endregion initialize
                });

            #endregion processing file

            return loHelper.Eliminar(poSesion, loAsignaciones, poIdentificador);
        }

        public DataTable ObtenerClientesNoAsignados(Sesion poSesion, int pnCveGestor, int pnClaveSucursal)
        {
            HelperLayoutCliente loHelper = new HelperLayoutCliente();

            return loHelper.ObtenerClientesNoAsignados(poSesion, pnCveGestor, pnClaveSucursal);
        }

        public DataTable ObtenerGestoresNoAsignados(Sesion poSesion, int pnClaveSucursal)
        {
            HelperLayoutCliente loHelper = new HelperLayoutCliente();

            return loHelper.ObtenerGestoresNoAsignados(poSesion,pnClaveSucursal);
        }

        public DataTable ObtenerAuxiliarCXC(Sesion poSesion, string psClaveAuxiliarExcluir, int pnClaveSucursal)
        {
            HelperLayoutCliente loHelper = new HelperLayoutCliente();

            return loHelper.ObtenerAuxiliarCXC(poSesion, psClaveAuxiliarExcluir,pnClaveSucursal);
        }

        public DataTable ObtenerGestores(Sesion poSesion, int pnClaveSucursal)
        {
            HelperLayoutCliente loHelper = new HelperLayoutCliente();

            return loHelper.ObtenerGestores(poSesion,pnClaveSucursal);
        }

        public DataTable ObtenerClientes(Sesion poSesion, int pnCveGestor, int pnClaveSucursal)
        {
            HelperLayoutCliente loHelper = new HelperLayoutCliente();

            return loHelper.ObtenerClientes(poSesion, pnCveGestor, pnClaveSucursal);
        }

        public DataTable ObtenerAuxiliarCXCSuprimir(Sesion poSesion, int pnClaveSucursal)
        {
            HelperLayoutCliente loHelper = new HelperLayoutCliente();

            return loHelper.ObtenerAuxiliarCXCSuprimir(poSesion, pnClaveSucursal);
        }

        public DataTable ObtenerGestoresSuprimir(Sesion poSesion, int pnAuxiliar)
        {
            HelperLayoutCliente loHelper = new HelperLayoutCliente();

            return loHelper.ObtenerGestoresSuprimir(poSesion, pnAuxiliar);
        }

        public DataTable ObtenerClientesSuprimir(Sesion poSesion, int pnAuxiliar, int pnCveGestor)
        {
            HelperLayoutCliente loHelper = new HelperLayoutCliente();

            return loHelper.ObtenerClientesSuprimir(poSesion, pnAuxiliar, pnCveGestor);
        }

        public DataTable ObtenerAuxiliarCXCTemporal(Sesion poSesion, int pnClaveSucursal)
        {
            HelperLayoutCliente loHelper = new HelperLayoutCliente();

            return loHelper.ObtenerAuxiliarCXCTemporal(poSesion, pnClaveSucursal);
        }

        public DataTable ObtenerGestoresTemporal(Sesion poSesion, int pnAuxiliar)
        {
            HelperLayoutCliente loHelper = new HelperLayoutCliente();

            return loHelper.ObtenerGestoresTemporal(poSesion, pnAuxiliar);
        }

        public DataTable ObtenerClientesTemporal(Sesion poSesion, int pnAuxiliar, int pnCveGestor)
        {
            HelperLayoutCliente loHelper = new HelperLayoutCliente();

            return loHelper.ObtenerClientesTemporal(poSesion, pnAuxiliar, pnCveGestor);
        }

        #endregion
    }
}
