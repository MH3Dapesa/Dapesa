using Dapesa.AccesoDatos.Entidades;
using Dapesa.Comun.Utilerias;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using Dapesa.Tesoreria.Bancos.Reglas.Proxy;
using System.Data.OleDb;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.Tesoreria.Bancos.Comun;

namespace Dapesa.Tesoreria.Bancos.Reglas
{
    internal class HelperMovimientos
    {
        internal DataTable ObtenerSucursalBanamex(Sesion poSesion, string psReferenciaBancaria)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
                Sentencia loSentencia = new Sentencia();
                loSentencia.Parametros = new List<Parametro>() {
						#region Parametros

						
						#endregion
					};
                loSentencia.TextoComando = "SELECT CLAVE CLI_CLAVE, RAZON_SOCIAL, SUC_CLAVE, (SELECT DESCRIPCION FROM SUCURSALES WHERE CLAVE = SC.SUC_CLAVE ) SUCURSAL FROM CLIENTES C, SUC_CLIENTES SC " +
                                            "WHERE C.TEXTO1 = (CASE WHEN LENGTH('" + psReferenciaBancaria + "') <= 7 THEN  SUBSTR('0000000',1,7-LENGTH('" + psReferenciaBancaria + "')) || '" + psReferenciaBancaria + "' " +
                                            "ELSE SUBSTR('" + psReferenciaBancaria + "',1,7) END) " +
                                            "AND C.CLAVE = SC.CLI_CLAVE AND SC.VER='S' AND SC.UTILIZAR='S' AND SC.SUC_CLAVE <> 4 " +
                                            "AND INSTR(','||COALESCE('1,2,3,4,5',TO_CHAR(SC.SUC_CLAVE))||',',','||SC.SUC_CLAVE||',')!=0  " +
                                            "AND CLAVE = SUBSTR('" + psReferenciaBancaria + "',1,LENGTH('" + psReferenciaBancaria + "')-2)";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.Text;
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
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerSucursal(Sesion poSesion, string psReferenciaBancaria)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
                Sentencia loSentencia = new Sentencia();
                loSentencia.Parametros = new List<Parametro>()
                {
                        #region Parametros


                        #endregion
                };
                loSentencia.TextoComando = "SELECT CLAVE CLI_CLAVE, RAZON_SOCIAL, SUC_CLAVE, (SELECT DESCRIPCION FROM SUCURSALES WHERE CLAVE = SC.SUC_CLAVE ) SUCURSAL FROM CLIENTES C, SUC_CLIENTES SC WHERE C.CLAVE = SC.CLI_CLAVE AND SC.UTILIZAR='S' AND SC.VER='S' AND C.TEXTO1 = SUBSTR('" + psReferenciaBancaria + "' ,-7,7)";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.Text;
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
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }
        
        internal DataTable ObtenerFormaDePagoBanamex(Sesion poSesion, string psFormaDePago)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
                Sentencia loSentencia = new Sentencia();
                loSentencia.Parametros = new List<Parametro>()
                {
                        #region Parametros


                        #endregion
                };
                loSentencia.TextoComando =
                    "SELECT (SELECT CLAVE FROM FORMAS_PAGO WHERE CLAVE = DAP_TESORERIA_TIPO_PAGO.CLAVE_FORMAPAGO) CLAVE,"
                   + "(SELECT DESCRIPCION FROM FORMAS_PAGO WHERE CLAVE = DAP_TESORERIA_TIPO_PAGO.CLAVE_FORMAPAGO) FORMA_PAGO "
                   + "FROM DAP_TESORERIA_TIPO_PAGO "
                   + "WHERE CLAVE_FORMAPAGO IN (SELECT CLAVE FROM FORMAS_PAGO) "
                   + "AND CLAVE_CUENTAS IN (SELECT CLAVE FROM CUENTAS) AND TIPO_PAGO = '" + psFormaDePago + "'";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.Text;
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
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerFormaDePago(Sesion poSesion, string psFormaDePago)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
                Sentencia loSentencia = new Sentencia();
                loSentencia.Parametros = new List<Parametro>()
                {
                        #region Parametros


                        #endregion
                };
                loSentencia.TextoComando =
                    "SELECT (SELECT CLAVE FROM FORMAS_PAGO WHERE CLAVE = DAP_TESORERIA_TIPO_PAGO.CLAVE_FORMAPAGO) CLAVE,"
                   + "(SELECT DESCRIPCION FROM FORMAS_PAGO WHERE CLAVE = DAP_TESORERIA_TIPO_PAGO.CLAVE_FORMAPAGO) FORMA_PAGO "
                   + "FROM DAP_TESORERIA_TIPO_PAGO "
                   + "WHERE CLAVE_FORMAPAGO IN (SELECT CLAVE FROM FORMAS_PAGO) "
                   + "AND CLAVE_CUENTAS IN (SELECT CLAVE FROM CUENTAS) AND DESCRIPCION = '" + psFormaDePago + "'";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.Text;
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
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ValidaCobro(Sesion poSesion, string psNumTransaccion, DateTime pdtFecha)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
                Sentencia loSentencia = new Sentencia();

                loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

						

					#endregion
				};
                loSentencia.TextoComando = 
                #region Definir sentencia de insercion/actualizacion
                    "SELECT DTC.NUM_TRANSACCION, DTC.REF_NUMERICA, DTC.REF_ALFANUMERICA, DTC.ABONO, "
                   + "DTC.FECHA_ABONO, DTC.SUC_BANCO,(SELECT DESCRIPCION FROM FORMAS_PAGO WHERE CLAVE = "
                   + "DTC.CLAVE_FORMAPAGO) CLAVE_FORMAPAGO, DTC.STATUS_TRANS FROM DAP_TESORERIA_COBROS_PROC DTC WHERE NUM_TRANSACCION = "
                   + "'" + psNumTransaccion + "' AND STATUS_TRANS IN ('C','M')";
                #endregion
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.Text;
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
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal bool InsertaCobroTablaDAP(Sesion poSesion, List<RegistroCobro> loCobro)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();

                foreach (RegistroCobro loAsignacion in loCobro)
                {
                    Sentencia loSentencia = new Sentencia();

                    loSentencia.Parametros = new List<Parametro>() {
						#region Parametros

                        //1
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "NUM_TRASACCION",
							Tipo = DbType.String,
							Valor = loAsignacion.NumTransaccion 
						},
                        //2
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "REF_NUMERICA",
							Tipo = DbType.String,
							Valor = loAsignacion.RefNumerica
						},
                        //3
                        new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "REF_ALFANUMERICA",
							Tipo = DbType.String,
							Valor = loAsignacion.RefAlfanumerica
						},
                        //4
                        new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "ABONO",
							Tipo = DbType.Decimal,
							Valor = loAsignacion.Abono
						},
                        //5
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "FECHA_ABONO",
							Tipo = DbType.String,
							Valor = loAsignacion.FechaAbono
						},
                        //6
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "BANCO",
							Tipo = DbType.Int32,
							Valor = loAsignacion.Banco
						},
                        //7
                        new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "FORMA_PAGO",
							Tipo = DbType.Int32,
							Valor = loAsignacion.FormaPago
						},
                        //8
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "ARCHIVO",
							Tipo = DbType.String,
							Valor = loAsignacion.Archivo
						},
                        //9
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "SUC_BANCO",
							Tipo = DbType.String,
							Valor = loAsignacion.SucBanco
						},
                        //10
                        new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "STATUS_TRANSACCION",
							Tipo = DbType.String,
							Valor = loAsignacion.StatusTransaccion
						}
						#endregion
					};

                    loSentencia.TextoComando =
                    #region Definir sentencia de insercion/actualizacion

                            "   MERGE INTO DAP_TESORERIA_COBROS_PROC DTP \r\n" +
                            "		USING (SELECT :1 AS NumTransaccion, :2 AS RefNumerica, :3 AS RefAlfanumerica, :4 AS Abono,:5 AS FechaAbono, :6 AS Banco,:7 AS FormaPago ,:8 AS Archivo,  :9 AS SucBanco, :10 StatusTransaccion FROM DUAL) T \r\n" +
                            "		ON (DTP.NUM_TRANSACCION = T.NumTransaccion) \r\n" +
                            "   WHEN MATCHED THEN \r\n" +
                            "   UPDATE SET DTP.USR_ACTUALIZA = USER, DTP.FECHA_ACTUALIZA = SYSDATE, DTP.STATUS_TRANS = T.StatusTransaccion \r\n" +
                            "	WHEN NOT MATCHED THEN \r\n" +
                            "		INSERT (DTP.NUM_TRANSACCION, DTP.REF_NUMERICA, DTP.REF_ALFANUMERICA, DTP.ABONO, DTP.FECHA_ABONO, DTP.SUC_BANCO, \r\n" +
                            "       DTP.CLAVE_FORMAPAGO,DTP.CLAVE_CUENTAS,DTP.NOMBRE_ARCHIVO,DTP.USUARIO_SIIL,DTP.FECHA_ALTA,DTP.STATUS_TRANS) \r\n" +
                            "		VALUES (T.NumTransaccion,T.RefNumerica,T.RefAlfanumerica,T.Abono,TO_DATE(T.FechaAbono,'DD/MM/YY'),T.SucBanco,T.FormaPago,T.Banco,T.Archivo,USER,SYSDATE,T.StatusTransaccion)";

                    #endregion
                    loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.NoQuery;
                    loSentencia.TipoComando = CommandType.Text;
                    loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.ContinuarTransaccion;
                    loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Entero;
                    loSentencias.Add(loSentencia);
                }

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

        internal bool InsertarCobroSIIL(Sesion poSesion, string pdFechaAbono, decimal pdTotal, string psNombreBanco, int piFormaPagoCobro, 
            string psClaveCliente, int piSucursal)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
                Sentencia loSentencia = new Sentencia();

                loSentencia.TextoComando =
                "declare result number; begin result := PKG_CXC.FNC_CREAR_COBRO(TO_DATE('" + pdFechaAbono + "','DD/MM/YY'),NULL,NULL,NULL,NULL,NULL,NULL,NULL," + pdTotal + ",1,'" + psNombreBanco + "'," + piFormaPagoCobro + ",1,'" + psClaveCliente + "','S',TO_DATE(SYSDATE,'DD/MM/YY')," + piSucursal + ");  end;";

                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.NoQuery;
                loSentencia.TipoComando = CommandType.Text;                
                loSentencias.Add(loSentencia);                

                DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorGestorCxC");

                loDespachador.Despachar(poSesion.Conexion, loSentencias);
                loDespachador.ChannelFactory.Close();
                loDespachador.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }
    }
}
