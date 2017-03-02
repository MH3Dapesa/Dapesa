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
    internal class HelperCatalogos
    {
        #region Metodos

        internal DataTable ObtenerSucursales(Sesion poSesion, int pnIndicadorFila)
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
						Nombre = "PNI_INDICADOR_FILA",
						Tipo = DbType.Int32,
						Valor = pnIndicadorFila
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_COMUN.PROC_CAT_SUCURSALES";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

                foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
                    loSentencia.Parametros.Add(new Parametro()
                    {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_CVE_SUCURSAL" + oSucursal.Clave,
                        Tipo = DbType.Int32,
                        Valor = oSucursal.Clave
                    });

                //foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
                //    lsSucursales += oSucursal.Clave + ",";

                //if (lsSucursales != string.Empty)
                //    loSentencia.Parametros.Add(new Parametro()
                //    {
                //        Direccion = ParameterDirection.Input,
                //        Nombre = "PNI_CVES_SUCURSALES",
                //        Tipo = DbType.String,
                //        Valor = lsSucursales.TrimEnd(',')
                //    });

                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });

                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }


        internal DataTable ObtenerVendedores(Sesion poSesion, string psClaveSucursal, int pnIndicadorFila, int pnIndicadorCve)
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
						Nombre = "PNI_INDICADOR_FILA",
						Tipo = DbType.Int32,
						Valor = pnIndicadorFila
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_INDICADOR_CVE",
						Tipo = DbType.Int32,
						Valor = pnIndicadorCve
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_COMUN.PROC_CAT_VENDEDORES";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

                if (string.IsNullOrEmpty(psClaveSucursal))
                {
                    string lsSucursales = string.Empty;

                    foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
                        lsSucursales += oSucursal.Clave + ",";

                    if (lsSucursales != string.Empty)
                        loSentencia.Parametros.Add(new Parametro()
                        {
                            Direccion = ParameterDirection.Input,
                            Nombre = "PNI_CVES_SUCURSALES",
                            Tipo = DbType.String,
                            Valor = lsSucursales.TrimEnd(',')
                        });
                }
                else
                    loSentencia.Parametros.Add(new Parametro()
                    {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_CVES_SUCURSALES",
                        Tipo = DbType.String,
                        Valor = psClaveSucursal
                    });


                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });

                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerGestores(Sesion poSesion, string psClaveSucursal, int pnIndicadorFila)
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
						Nombre = "PNI_INDICADOR_FILA",
						Tipo = DbType.Int32,
						Valor = pnIndicadorFila
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_COMUN.PROC_CAT_GESTORES";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

                if (string.IsNullOrEmpty(psClaveSucursal))
                {
                    string lsSucursales = string.Empty;

                    foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
                        lsSucursales += oSucursal.Clave + ",";

                    if (lsSucursales != string.Empty)
                        loSentencia.Parametros.Add(new Parametro()
                        {
                            Direccion = ParameterDirection.Input,
                            Nombre = "PNI_CVES_SUCURSALES",
                            Tipo = DbType.String,
                            Valor = lsSucursales.TrimEnd(',')
                        });
                }
                else
                    loSentencia.Parametros.Add(new Parametro()
                    {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_CVES_SUCURSALES",
                        Tipo = DbType.String,
                        Valor = psClaveSucursal
                    });


                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });

                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerAuxiliares(Sesion poSesion, string psClaveSucursal, int pnClaveAuxiliar)
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
						Nombre = "PSI_CVES_SUCURSALES",
						Tipo = DbType.String,
						Valor = psClaveSucursal
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_USUARIO",
						Tipo = DbType.Int32,
						Valor = pnClaveAuxiliar
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_CXC_LAYOUT.PROC_AUXILIAR_CXC_LISTADO";
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
