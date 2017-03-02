using Dapesa.AccesoDatos.Entidades;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dapesa.Comun.Informes.Credito.Reglas
{
    internal class HelperInformeClientes
    {
        #region Metodos
        internal DataTable ObtenerClientes(Sesion poSesion, int psClaveSucursal, string psClaveVendedor, string psCliente)
        {
            try
            {
                Sentencia loSentencia = new Sentencia();
                loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = psClaveSucursal
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_VENDEDOR",
						Tipo = DbType.Int32,
						Valor = psClaveVendedor
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_CLIENTE",
						Tipo = DbType.String,
						Valor = psCliente
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_CREDITO.PROC_REP_REFERENCIAS_BANCARIAS";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });
                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable CobrosDiarios(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, int psClaveSucursal, string psClaveVendedor, string psCliente)
        {
            try
            {
                Sentencia loSentencia = new Sentencia();
                loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_INICIO",
						Tipo = DbType.DateTime,
						Valor = poFechaInicio
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_FIN",
						Tipo = DbType.DateTime,
						Valor = poFechaFin
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = psClaveSucursal
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_VENDEDOR",
						Tipo = DbType.Int32,
						Valor = psClaveVendedor
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_CLIENTE",
						Tipo = DbType.String,
						Valor = psCliente
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_CREDITO.PROC_REP_COBROS_DIARIOS";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });
                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerAntiguedadSaldos(Sesion poSesion, int psClaveSucursal, DateTime poFecha, int pnDiasPeriodo, int pnTipoFecha, int pnDiasAdicionales, string psClaveGestor, string psCliente)
        {
            try
            {
                Sentencia loSentencia = new Sentencia();
                loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = psClaveSucursal
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA",
						Tipo = DbType.DateTime,
						Valor = poFecha
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_DIAS_PERIODO",
						Tipo = DbType.Int32,
						Valor = pnDiasPeriodo
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_TIPO_FECHA",
						Tipo = DbType.Int32,
						Valor = pnTipoFecha
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_DIAS_ADICIONALES",
						Tipo = DbType.Int32,
						Valor = pnDiasAdicionales
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_GESTOR",
						Tipo = DbType.Int32,
						Valor = psClaveGestor
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_CLIENTE",
						Tipo = DbType.String,
						Valor = ((string.IsNullOrEmpty(psCliente)) ? null : psCliente)
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_CREDITO.PROC_REP_ANTIGUEDAD_SALDOS";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });
                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerAntiguedadSaldosGeneral(Sesion poSesion, int psClaveSucursal, DateTime poFecha, int pnDiasPeriodo, int pnTipoFecha, int pnDiasAdicionales, string psClaveGestor, string psCliente, int pnIndicadorUsuario)
        {
            try
            {
                Sentencia loSentencia = new Sentencia();
                loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = psClaveSucursal
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA",
						Tipo = DbType.DateTime,
						Valor = poFecha
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_DIAS_PERIODO",
						Tipo = DbType.Int32,
						Valor = pnDiasPeriodo
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_TIPO_FECHA",
						Tipo = DbType.Int32,
						Valor = pnTipoFecha
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_DIAS_ADICIONALES",
						Tipo = DbType.Int32,
						Valor = pnDiasAdicionales
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_GESTOR",
						Tipo = DbType.Int32,
						Valor = psClaveGestor
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_CLIENTE",
						Tipo = DbType.String,
						Valor = ((string.IsNullOrEmpty(psCliente)) ? null : psCliente)
					}, /// añadido
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_INDICADOR_USUARIO",
						Tipo = DbType.Int32,
						Valor = pnIndicadorUsuario
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_CREDITO.PROC_REP_ANTIGUEDAD_SALDOS_GEN";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });
                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerAntiguedadSaldosAuxiliar(Sesion poSesion, int psClaveSucursal, DateTime poFecha, int pnDiasPeriodo, int pnTipoFecha, int pnDiasAdicionales, string psClaveGestor, string psCliente, int pnIndicadorUsuario)
        {
            try
            {
                Sentencia loSentencia = new Sentencia();
                loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = psClaveSucursal
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA",
						Tipo = DbType.DateTime,
						Valor = poFecha
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_DIAS_PERIODO",
						Tipo = DbType.Int32,
						Valor = pnDiasPeriodo
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_TIPO_FECHA",
						Tipo = DbType.Int32,
						Valor = pnTipoFecha
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_DIAS_ADICIONALES",
						Tipo = DbType.Int32,
						Valor = pnDiasAdicionales
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_GESTOR",
						Tipo = DbType.Int32,
						Valor = psClaveGestor
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_CLIENTE",
						Tipo = DbType.String,
						Valor = ((string.IsNullOrEmpty(psCliente)) ? null : psCliente)
					}, /// añadido
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_INDICADOR_USUARIO",
						Tipo = DbType.Int32,
						Valor = pnIndicadorUsuario
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_CREDITO.PROC_REP_ANTIGUEDAD_SALDOS_AUX";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });
                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal int ObtenerClienteSinAsignar(Sesion poSesion, int psClaveSucursal)
        {
            try
            {
                Sentencia loSentencia = new Sentencia();
                loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = psClaveSucursal
					}
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_CXC_LAYOUT.PROC_CXC_CLIENTES_SIN_ASIGNAR";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });
                
                return loResultado.Rows.Count;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerEmailPersonal(Sesion poSesion, int pnClavePersonal)
        {
            try
            {
                Sentencia loSentencia = new Sentencia();

                loSentencia.Parametros = new List<Parametro>() {
					#region Parametros
                    new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					}
					#endregion
				};
                loSentencia.TextoComando = "SELECT E_MAIL,CLAVE FROM PERSONAL WHERE CLAVE = " + pnClavePersonal; 
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.Text;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });

                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }
        #endregion
    }
}
