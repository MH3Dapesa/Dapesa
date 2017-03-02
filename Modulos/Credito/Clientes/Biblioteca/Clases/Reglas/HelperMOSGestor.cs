using Dapesa.AccesoDatos.Entidades;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.Comun.Utilerias;
using Dapesa.Credito.Clientes.Reglas.Proxy;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace Dapesa.Credito.Clientes.Reglas
{
    internal class HelperMOSGestor
    {

        #region Metodos

        internal DataTable BuscarSaldosClientes(Sesion poSesion, int pnSucursal)
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
                        Valor = pnSucursal
                    }
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_MONITOREO.PROC_MONITOREO_SALDOS";
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

        internal bool InactivarClientes(Sesion poSesion, DataTable poClientes, EventLog poLog)
        {
            try
            {
                int lnMotivo = 0;
                List<Sentencia> loSentencias = new List<Sentencia>();

                #region Actualizar solo clientes padre e hijos con saldo vencido.
                foreach (DataRow loCliente in poClientes.Rows)
                {
                    if (decimal.Parse(loCliente["SALDO_PADRE"].ToString()) > 0 || decimal.Parse(loCliente["SALDO_HIJO"].ToString()) > 0)
                    {
                        #region Obtener Motivo de inactivación.
                        if (decimal.Parse(loCliente["SALDO_PADRE"].ToString()) > 0 && decimal.Parse(loCliente["SALDO_HIJO"].ToString()) > 0)
                        {
                            lnMotivo = int.Parse(ConfigurationManager.AppSettings["ConceptoInactivacionPadreHijo"]);
                        }
                        else
                        {
                            if (decimal.Parse(loCliente["SALDO_PADRE"].ToString()) > 0)
                            {
                                lnMotivo = int.Parse(ConfigurationManager.AppSettings["ConceptoInactivacionPadre"]);
                            }
                            else
                            {
                                lnMotivo = int.Parse(ConfigurationManager.AppSettings["ConceptoInactivacionHijo"]);
                            }
                        }
                        #endregion
                        Sentencia loSentencia = new Sentencia();

                        loSentencia.Parametros = new List<Parametro>() {
						#region Parametros

						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "CVE_CLIENTE",
							Tipo = DbType.String,
							Valor = loCliente["CLAVE"]
						},
                        new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "MINAC_CLAVE",
							Tipo = DbType.Int32,
							Valor = lnMotivo
						}
						#endregion
					    };
                        loSentencia.TextoComando =
                        #region Definir sentencia de insercion/actualizacion

                        "UPDATE CLIENTES SET FECHA_INAC = SYSDATE, FECHA_ULT_ACT=SYSDATE, USUARIO_ULT_ACT='SIIL_OWNER', STATUS='I', MINAC_CLAVE = "
                          + lnMotivo.ToString() + " WHERE STATUS='A' AND CLAVE IN('" + loCliente["CLAVE"] + "','" + loCliente["CLAVE"] + "M')";

                        #endregion
                        loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.NoQuery;
                        loSentencia.TipoComando = CommandType.Text;
                        loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.ContinuarTransaccion;
                        loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Entero;
                        loSentencias.Add(loSentencia);
                    }
                }
                #endregion

                #region Actualizar el limite de crédito a cero solo de cuentas hijo 
                foreach (DataRow loCliente in poClientes.Rows)
                {
                    if (decimal.Parse(loCliente["LIMITE_CREDITO_HIJO"].ToString()) > 0)
                    {
                        Sentencia loSentencia = new Sentencia();

                        loSentencia.Parametros = new List<Parametro>() {
						#region Parametros

						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "CVE_CLIENTE",
							Tipo = DbType.String,
							Valor = loCliente["CLAVE"]
						}
						#endregion
					    };
                        loSentencia.TextoComando =
                        #region Definir sentencia de insercion/actualizacion

                        "UPDATE CLIENTES SET FECHA_ULT_ACT=SYSDATE, USUARIO_ULT_ACT='SIIL_OWNER', LIMITE_CREDITO = 0 WHERE ZON_CLAVE = 2 AND LIMITE_CREDITO > 0 AND CLAVE ='" + loCliente["CLAVE"] + "M'";

                        #endregion
                        loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.NoQuery;
                        loSentencia.TipoComando = CommandType.Text;
                        loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.ContinuarTransaccion;
                        loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Entero;
                        loSentencias.Add(loSentencia);
                    }
                }
                #endregion
                #region Preparar/ejecutar transaccion

                if (loSentencias.Count > 0)
                {

                    if (loSentencias.Count > 1)
                    {
                        loSentencias[0].TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.IniciarTransaccion;
                        loSentencias[loSentencias.Count - 1].TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.FinalizarTransaccion;
                    }
                    else
                        loSentencias[0].TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;

                    DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorGestorCxC");

                    loDespachador.Despachar(poSesion.Conexion, loSentencias);
                    loDespachador.ChannelFactory.Close();
                    loDespachador.Close();
                }

                #endregion
                return true;
            }
            catch (Exception ex)
            {
                poLog.WriteEntry("ERROR AL INACTIVAR CLIENTES." + ex, EventLogEntryType.Information);
                return false;
            }
        }

        internal DataTable ObtenerEmailPersonal(Sesion poSesion, int pnSucursal)
        {
            try
            {
                Sentencia loSentencia = new Sentencia();

                loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_CVE_SUCURSAL",
                        Tipo = DbType.Int32,
                        Valor = pnSucursal
                    },
                    new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					}
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_CREDITO_CTES.PROC_MOS_PERSONAL";
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
        #endregion
    }
}
