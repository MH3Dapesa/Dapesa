using Dapesa.AccesoDatos.Entidades;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.Seguridad.Entidades;
using Dapesa.Comun.Informes.Comun;
using System;
using System.Collections.Generic;
using System.Data;
using Dapesa.Comun;
using System.Linq;



namespace Dapesa.Ventas.Pedidos.Reglas
{
    internal class HelperDiagnosticoPedidos
    {
        #region Metodos

        internal DataTable BuscarPedidos(Sesion poSesion, int pnRangoDias, int pnSucursal, string psMarcas, string psLineas, string psArticulos, String psEstados, String psClientes, bool poCoincidirEstados, bool poCoincidirClientes)
        {

            try
            {
                Sentencia loSentencia = new Sentencia();
                int lnIndicadorFiltros = (int)Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidos.Ninguno;
                int lnIndicadorCoincidir =(int)Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidoCoincidir.Ninguno;
                loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					}, 
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_RANGO_DIAS",
                        Tipo = DbType.Int32,
                        Valor = pnRangoDias
                    },      
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_CVE_ESTADO",
                        Tipo = DbType.String,
                        Valor = psEstados
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PDI_CVE_MARCA",
                        Tipo = DbType.String,
                        Valor = psMarcas
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_CVE_SUCURSAL",
                        Tipo = DbType.Int32,
                        Valor = pnSucursal
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_CVE_INDICADOR",
                        Tipo = DbType.Int32,
                        Valor = lnIndicadorFiltros
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PSO_CVE1",
                        Tipo = DbType.String,
                        Valor = psClientes
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PSO_CVE2",
                        Tipo = DbType.String,
                        Valor = psLineas
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PSO_CVE3",
                        Tipo = DbType.String,
                        Valor = psArticulos
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_CVE_COINCIDIR",
                        Tipo = DbType.Int32,
                        Valor = lnIndicadorCoincidir
                    }
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_MONITOREO.PROC_MONITOREO_PEDIDOS";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;


                Planificador loPlanificador = new Planificador();

                #region Definir filtros
                if(psClientes.Length > 0)
                {
                    lnIndicadorFiltros = (int)Dapesa.Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidos.SoloCliente;
                }
                if (psLineas.Length > 0)
                {
                    lnIndicadorFiltros = (int)Dapesa.Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidos.SoloLinea;
                }
                if(psClientes.Length >0 & psLineas.Length > 0)
                {
                    lnIndicadorFiltros = (int)Dapesa.Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidos.LineaCliente;
                }
                if (psArticulos.Length > 0 & psLineas.Length > 0)
                {
                    lnIndicadorFiltros = (int)Dapesa.Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidos.LineaArticulo;
                }
                if (psClientes.Length > 0 & psLineas.Length > 0 & psArticulos.Length > 0)
                {
                    lnIndicadorFiltros = (int)Dapesa.Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidos.Ambos;
                }
                if (poCoincidirEstados)
                {
                    lnIndicadorCoincidir = (int)Dapesa.Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidoCoincidir.SoloEstado;
                }
                if (poCoincidirClientes)
                {
                    lnIndicadorCoincidir = (int)Dapesa.Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidoCoincidir.SoloCliente;
                }
                if (poCoincidirClientes & poCoincidirEstados)
                {
                    lnIndicadorCoincidir = (int)Dapesa.Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidoCoincidir.Ambos;
                }
                loSentencia.Parametros[5].Valor = lnIndicadorFiltros;
                loSentencia.Parametros[9].Valor = lnIndicadorCoincidir;

                #endregion

                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });

                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Dapesa.Comun.Informes.Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable BuscarFacturas(Sesion poSesion, int pnRangoDias, int pnSucursal, string psMarcas, string psLineas, string psArticulos, String psEstados, String psClientes, bool poCoincidirEstados, bool poCoincidirClientes)
        {

            try
            {
                Sentencia loSentencia = new Sentencia();
                int lnIndicadorFiltros = (int)Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidos.Ninguno;
                int lnIndicadorCoincidir = (int)Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidoCoincidir.Ninguno;

                loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					}, 
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_RANGO_DIAS",
                        Tipo = DbType.Int32,
                        Valor = pnRangoDias
                    },      
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_CVE_ESTADO",
                        Tipo = DbType.String,
                        Valor = psEstados
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PDI_CVE_MARCA",
                        Tipo = DbType.String,
                        Valor = psMarcas
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_CVE_SUCURSAL",
                        Tipo = DbType.Int32,
                        Valor = pnSucursal
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_CVE_INDICADOR",
                        Tipo = DbType.Int32,
                        Valor = lnIndicadorFiltros
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PSO_CVE1",
                        Tipo = DbType.String,
                        Valor = psClientes
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PSO_CVE2",
                        Tipo = DbType.String,
                        Valor = psLineas
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PSO_CVE3",
                        Tipo = DbType.String,
                        Valor = psArticulos
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_CVE_COINCIDIR",
                        Tipo = DbType.Int32,
                        Valor = lnIndicadorCoincidir
                    }
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_MONITOREO.PROC_MONITOREO_FACTURAS";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;


                Planificador loPlanificador = new Planificador();

                #region Definir filtros
                if (psClientes.Length > 0)
                {
                    lnIndicadorFiltros = (int)Dapesa.Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidos.SoloCliente;
                }
                if (psLineas.Length > 0)
                {
                    lnIndicadorFiltros = (int)Dapesa.Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidos.SoloLinea;
                }
                if (psClientes.Length > 0 & psLineas.Length > 0)
                {
                    lnIndicadorFiltros = (int)Dapesa.Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidos.LineaCliente;
                }
                if (psArticulos.Length > 0 & psLineas.Length > 0)
                {
                    lnIndicadorFiltros = (int)Dapesa.Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidos.LineaArticulo;
                }
                if (psClientes.Length > 0 & psLineas.Length > 0 & psArticulos.Length > 0)
                {
                    lnIndicadorFiltros = (int)Dapesa.Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidos.Ambos;
                }
                if (poCoincidirEstados)
                {
                    lnIndicadorCoincidir = (int)Dapesa.Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidoCoincidir.SoloEstado;
                }
                if (poCoincidirClientes)
                {
                    lnIndicadorCoincidir = (int)Dapesa.Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidoCoincidir.SoloCliente;
                }
                if (poCoincidirClientes & poCoincidirEstados)
                {
                    lnIndicadorCoincidir = (int)Dapesa.Ventas.Pedidos.Comun.Definiciones.FiltroMonitoreoPedidoCoincidir.Ambos;
                }
                loSentencia.Parametros[5].Valor = lnIndicadorFiltros;
                loSentencia.Parametros[9].Valor = lnIndicadorCoincidir;

                #endregion



                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });

                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Dapesa.Comun.Informes.Comun.Excepcion(ex.Message, ex);
            }
        }
        
        #endregion
    }
}
