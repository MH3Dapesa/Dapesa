using Dapesa.AccesoDatos.Entidades;
using Dapesa.Comun.Utilerias;
using Dapesa.Sistemas.Seguridad.Reglas.Proxy;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
namespace Dapesa.Sistemas.Seguridad.Reglas
{
    internal class HelperPermiso
    {
        #region Metodos

        internal DataTable BuscarGrupo(Sesion poSesion, string psDescripcion)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
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
							Nombre = "PSI_CVE_PERSONAL",
							Tipo = DbType.String,
							Valor = psDescripcion
						}
					
                        #endregion
					};
                loSentencia.TextoComando = "PKG_DAP_MONITOREO.PROC_MONITOREO_BUSCAR_GRUPO";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                loSentencias.Add(loSentencia);

                DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorGestorCxC");
                Serializacion loDeserializador = new Serializacion();
                DataTable loResultado = loDeserializador.DeserializarTabla(
                    poSesion.Conexion.Credenciales.Cifrado.Descifrar(
                        (byte[])loDespachador.Despachar(poSesion.Conexion, loSentencias
                    )));

                loDespachador.ChannelFactory.Close();
                loDespachador.Close();
                return loResultado;

            }
            catch (Exception ex)
            {
                throw new Seguridad.Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable BuscarPersonal(Sesion poSesion)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
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
                loSentencia.TextoComando = "PKG_DAP_MONITOREO.PROC_MONITOREO_BUSCAR_PERSONAL";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                loSentencias.Add(loSentencia);

                DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorGestorCxC");
                Serializacion loDeserializador = new Serializacion();
                DataTable loResultado = loDeserializador.DeserializarTabla(
                    poSesion.Conexion.Credenciales.Cifrado.Descifrar(
                        (byte[])loDespachador.Despachar(poSesion.Conexion, loSentencias
                    )));

                loDespachador.ChannelFactory.Close();
                loDespachador.Close();
                return loResultado;

            }
            catch (Exception ex)
            {
                throw new Seguridad.Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerGrupo(Sesion poSesion)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
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
                loSentencia.TextoComando = "PKG_DAP_MONITOREO.PROC_MONITOREO_OBTENER_GRUPO";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                loSentencias.Add(loSentencia);

                DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorGestorCxC");
                Serializacion loDeserializador = new Serializacion();
                DataTable loResultado = loDeserializador.DeserializarTabla(
                    poSesion.Conexion.Credenciales.Cifrado.Descifrar(
                        (byte[])loDespachador.Despachar(poSesion.Conexion, loSentencias
                    )));

                loDespachador.ChannelFactory.Close();
                loDespachador.Close();
                return loResultado;

            }
            catch (Exception ex)
            {
                throw new Seguridad.Comun.Excepcion(ex.Message, ex);
            }
        }
        
        internal DataTable ObtenerAplicacion(Sesion poSesion)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
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
                loSentencia.TextoComando = "PKG_DAP_MONITOREO.PROC_MONITOREO_OBTENER_APP";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                loSentencias.Add(loSentencia);

                DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorGestorCxC");
                Serializacion loDeserializador = new Serializacion();
                DataTable loResultado = loDeserializador.DeserializarTabla(
                    poSesion.Conexion.Credenciales.Cifrado.Descifrar(
                        (byte[])loDespachador.Despachar(poSesion.Conexion, loSentencias
                    )));

                loDespachador.ChannelFactory.Close();
                loDespachador.Close();
                return loResultado;

            }
            catch (Exception ex)
            {
                throw new Seguridad.Comun.Excepcion(ex.Message, ex);
            }
        }
        
        
        
        
        
        
        internal DataTable ObtenerPrueba(Sesion poSesion)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
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
                loSentencia.TextoComando = "PKG_DAP_PRUEBAS.PROC_PRUEBA_CONSULTA";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                loSentencias.Add(loSentencia);

                DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorGestorCxC");
                Serializacion loDeserializador = new Serializacion();
                DataTable loResultado = loDeserializador.DeserializarTabla(
                    poSesion.Conexion.Credenciales.Cifrado.Descifrar(
                        (byte[])loDespachador.Despachar(poSesion.Conexion, loSentencias
                    )));

                loDespachador.ChannelFactory.Close();
                loDespachador.Close();
                return loResultado;

            }
            catch (Exception ex)
            {
                throw new Seguridad.Comun.Excepcion(ex.Message, ex);
            }
        }
       
        internal bool Eliminar(Sesion poSesion, int pnValor)
        {

            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();


                    Sentencia loSentencia = new Sentencia();

                    loSentencia.Parametros = new List<Parametro>() {
						#region Parametros

						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "CVE_NUMERICA",
							Tipo = DbType.Int32,
							Valor = pnValor
						}

						#endregion
					};
                    loSentencia.TextoComando =
                    #region Definir sentencia de insercion/actualizacion

                    "DELETE FROM DAP_PRUEBAS2___ WHERE CVE_NUMERICA=:1";

                    #endregion
                    loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.NoQuery;
                    loSentencia.TipoComando = CommandType.Text;
                    loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.ContinuarTransaccion;
                    loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Entero;
                    loSentencias.Add(loSentencia);
                

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
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal bool Guardar(Sesion poSesion)
        {

            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();

                Sentencia loSentencia = new Sentencia();

                loSentencia.Parametros = new List<Parametro>() {
                        #region Parametros

						
                        new Parametro() {
                            Direccion = ParameterDirection.Input,
                            Nombre = "CVE_NUMERICA",
                            Tipo = DbType.Int32,
                            Valor = 1
                        },
                        new Parametro() {
                            Direccion = ParameterDirection.Input,
                            Nombre = "CVE_VALOR",
                            Tipo = DbType.String,
                            Valor = "Prueba2"
                        },
                        new Parametro() {
                            Direccion = ParameterDirection.Input,
                            Nombre = "FECHA_ULT_TRANSAC",
                            Tipo = DbType.Date,
                            Valor = DateTime.Now
                        }
                        #endregion
                    };
                loSentencia.TextoComando =
                #region Definir sentencia de insercion/actualizacion

 "MERGE INTO DAP_PRUEBAS2___  TC\r\n" +
                        "		USING (SELECT :1 AS CVE_NUMERICA,:2 AS CVE_VALOR, :3 AS FECHA_ULT_TRANSAC FROM DUAL) D \r\n" +
                        "		ON (TC.CVE_NUMERICA=D.CVE_NUMERICA) \r\n" +
                        "	WHEN MATCHED THEN \r\n" +
                        "		UPDATE SET TC.CVE_VALOR=D.CVE_VALOR,TC.FECHA_ULT_TRANSAC=SYSDATE \r\n" +
                        "	WHEN NOT MATCHED THEN \r\n" +
                        "		INSERT (TC.CVE_NUMERICA,TC.CVE_VALOR,TC.FECHA_ULT_TRANSAC) \r\n" +
                        "		VALUES (D.CVE_NUMERICA,D.CVE_VALOR,SYSDATE)";

                #endregion
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.NoQuery;
                loSentencia.TipoComando = CommandType.Text;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.ContinuarTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Entero;
                loSentencias.Add(loSentencia);


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
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }
        
        #endregion
    }
}
