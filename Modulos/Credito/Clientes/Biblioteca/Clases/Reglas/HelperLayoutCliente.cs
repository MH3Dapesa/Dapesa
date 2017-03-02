using Dapesa.Credito.Clientes.Reglas.Proxy;
using Credito.Clientes.Entidades;
using Dapesa.AccesoDatos.Entidades;
using Dapesa.Comun.Utilerias;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dapesa.Credito.Clientes.Reglas
{
    internal class HelperLayoutCliente
    {
        internal DataTable ObtenerSucursal(Sesion poSesion)
        {

            try
            {
                string lsSucursales = string.Empty;
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
							Nombre = "PSI_CVE_USUARIO",
							Tipo = DbType.Int32,
                            Valor = poSesion.Usuario.Id
						}

						#endregion
					};
                loSentencia.TextoComando = "PKG_DAP_ALMACEN_PEDIDO.PROC_SUCURSALES";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                loSentencias.Add(loSentencia);

                foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
                    lsSucursales += oSucursal.Clave + ",";

                if (lsSucursales != string.Empty)
                    loSentencia.Parametros.Add(new Parametro()
                    {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PSI_CVES_SUCURSALES",
                        Tipo = DbType.String,
                        Valor = lsSucursales.TrimEnd(',')
                    });

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
                throw new Clientes.Comun.Excepcion(ex.Message, ex);
            }
        }

        internal bool Guardar(Sesion poSesion, List<Asignacion> poAsignaciones, bool pbAsignacionTemporal)
        {

            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();

                foreach (Asignacion loAsignacion in poAsignaciones)
                {
                    Sentencia loSentencia = new Sentencia();

                    loSentencia.Parametros = new List<Parametro>() {
						#region Parametros

						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "CVE_CLIENTE",
							Tipo = DbType.String,
							Valor = loAsignacion.ClaveCliente
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "USR_CLAVE",
							Tipo = DbType.String,
							Valor = loAsignacion.ClaveUsuario
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "STATUS_CAN",
							Tipo = DbType.String,
							Valor = loAsignacion.Estatus
						}

						#endregion
					};
                    loSentencia.TextoComando =
                    #region Definir sentencia de insercion/actualizacion

                            "   MERGE INTO DAP_CXC_AUXILIAR_CTE" + ((pbAsignacionTemporal) ? "_TMP" : string.Empty) + " TC \r\n" +
                            "		USING (SELECT :1 AS CVE_CLIENTE,:2 AS CVE_PERSONAL,:3 AS STATUS_CAN FROM DUAL) D \r\n" +
                            "		ON (TC.CVE_CLIENTE=D.CVE_CLIENTE) \r\n" +
                            "	WHEN MATCHED THEN \r\n" +
                            "		UPDATE SET TC.CVE_PERSONAL=D.CVE_PERSONAL,TC.USUARIO_ULT_ACT='" + poSesion.Usuario.Clave + "',TC.FECHA_ULT_TRANSAC=SYSDATE,TC.STATUS_CAN=D.STATUS_CAN \r\n" +
                            "	WHEN NOT MATCHED THEN \r\n" +
                            "		INSERT (TC.CVE_PERSONAL,TC.CVE_CLIENTE,TC.USUARIO_ULT_ACT,TC.FECHA_ULT_TRANSAC) \r\n" +
                            "		VALUES (D.CVE_PERSONAL,D.CVE_CLIENTE,'" + poSesion.Usuario.Clave + "',SYSDATE)";

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

        internal bool Eliminar(Sesion poSesion, List<Asignacion> poAsignaciones, bool pbAsignacionTemporal)
        {

            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();

                foreach (Asignacion loAsignacion in poAsignaciones)
                {
                    Sentencia loSentencia = new Sentencia();

                    loSentencia.Parametros = new List<Parametro>() {
						#region Parametros

						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "CVE_CLIENTE",
							Tipo = DbType.String,
							Valor = loAsignacion.ClaveCliente
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "USR_CLAVE",
							Tipo = DbType.String,
							Valor = loAsignacion.ClaveUsuario
						}

						#endregion
					};
                    loSentencia.TextoComando =
                    #region Definir sentencia de insercion/actualizacion

                    "DELETE FROM DAP_CXC_AUXILIAR_CTE" + ((pbAsignacionTemporal) ? "_TMP" : string.Empty) + " WHERE CVE_CLIENTE=:1 AND CVE_PERSONAL=:2";

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

        internal DataTable ObtenerClientesNoAsignados(Sesion poSesion, int pnCveGestor, int pnClaveSucursal)
        {

            try
            {
                string lsSucursales = string.Empty;
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
							Nombre = "PSI_CVES_SUCURSALES",
							Tipo = DbType.Int32,
                            Valor = pnClaveSucursal
						}

						#endregion
					};
                loSentencia.TextoComando = "PKG_DAP_CXC_LAYOUT.PROC_CXC_CLIENTES_SIN_ASIGNAR";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                loSentencias.Add(loSentencia);

                //foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
                //    lsSucursales += oSucursal.Clave + ",";

                //if (lsSucursales != string.Empty)
                //    loSentencia.Parametros.Add(new Parametro()
                //    {
                //        Direccion = ParameterDirection.Input,
                //        Nombre = "PSI_CVES_SUCURSALES",
                //        Tipo = DbType.String,
                //        Valor = lsSucursales.TrimEnd(',')
                //    });

                if (pnCveGestor > 0)
                    loSentencia.Parametros.Add(new Parametro()
                    {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_CVE_VENDEDOR",
                        Tipo = DbType.Int32,
                        Valor = pnCveGestor
                    });

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
                throw new Clientes.Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerGestoresNoAsignados(Sesion poSesion, int pnClaveSucursal)
        {

            try
            {
                string lsSucursales = string.Empty;
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
							Nombre = "PSI_CVES_SUCURSALES",
							Tipo = DbType.Int32,
                            Valor = pnClaveSucursal
						}

						#endregion
					};
                loSentencia.TextoComando = "PKG_DAP_CXC_LAYOUT.PROC_CXC_GESTORES_SIN_ASIGNAR";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                loSentencias.Add(loSentencia);

                //foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
                //    lsSucursales += oSucursal.Clave + ",";

                //if (lsSucursales != string.Empty)
                //    loSentencia.Parametros.Add(new Parametro()
                //    {
                //        Direccion = ParameterDirection.Input,
                //        Nombre = "PSI_CVES_SUCURSALES",
                //        Tipo = DbType.String,
                //        Valor = lsSucursales.TrimEnd(',')
                //    });

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
                throw new Clientes.Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerAuxiliarCXC(Sesion poSesion, string psClaveAuxiliarExcluir, int pnClaveSucursal)
        {

            try
            {
                string lsSucursales = string.Empty;
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
							Nombre = "PSI_CVES_SUCURSALES",
							Tipo = DbType.Int32,
                            Valor= pnClaveSucursal
						}

						#endregion
					};
                loSentencia.TextoComando = "PKG_DAP_CXC_LAYOUT.PROC_AUXILIAR_CXC_LISTADO";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                loSentencias.Add(loSentencia);

                //foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
                //    lsSucursales += oSucursal.Clave + ",";

                //if (lsSucursales != string.Empty)
                //    loSentencia.Parametros.Add(new Parametro()
                //    {
                //        Direccion = ParameterDirection.Input,
                //        Nombre = "PSI_CVES_SUCURSALES",
                //        Tipo = DbType.String,
                //        Valor = lsSucursales.TrimEnd(',')
                //    });

                long lnClaveAuxiliarExcluir = -1;

                if (!string.IsNullOrEmpty(psClaveAuxiliarExcluir))
                    lnClaveAuxiliarExcluir = long.Parse(psClaveAuxiliarExcluir);

                loSentencia.Parametros.Add(new Parametro()
                {
                    Direccion = ParameterDirection.Input,
                    Nombre = "PNI_CVE_USUARIO",
                    Tipo = DbType.Int64,
                    Valor = lnClaveAuxiliarExcluir
                });

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
                throw new Clientes.Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerGestores(Sesion poSesion, int pnClaveSucursal)
        {

            try
            {
                string lsSucursales = string.Empty;
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
							Nombre = "PSI_CVES_SUCURSALES",
							Tipo = DbType.Int32,
                            Valor = pnClaveSucursal
						}

						#endregion
					};
                loSentencia.TextoComando = "PKG_DAP_CXC_LAYOUT.PROC_AUXILIAR_CXC_GESTORES";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                loSentencias.Add(loSentencia);

                //foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
                //    lsSucursales += oSucursal.Clave + ",";

                //if (lsSucursales != string.Empty)
                //    loSentencia.Parametros.Add(new Parametro()
                //    {
                //        Direccion = ParameterDirection.Input,
                //        Nombre = "PSI_CVES_SUCURSALES",
                //        Tipo = DbType.String,
                //        Valor = lsSucursales.TrimEnd(',')
                //    });

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
                throw new Clientes.Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerClientes(Sesion poSesion, int pnCveGestor, int pnClaveSucursal)
        {

            try
            {
                string lsSucursales = string.Empty;
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
							Nombre = "PSI_CVES_SUCURSALES",
							Tipo = DbType.Int32,
                            Valor = pnClaveSucursal
						}

						#endregion
					};
                loSentencia.TextoComando = "PKG_DAP_CXC_LAYOUT.PROC_AUXILIAR_CXC_CLIENTES";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                loSentencias.Add(loSentencia);

                //foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
                //    lsSucursales += oSucursal.Clave + ",";

                //if (lsSucursales != string.Empty)
                //    loSentencia.Parametros.Add(new Parametro()
                //    {
                //        Direccion = ParameterDirection.Input,
                //        Nombre = "PSI_CVES_SUCURSALES",
                //        Tipo = DbType.String,
                //        Valor = lsSucursales.TrimEnd(',')
                //    });

                if (pnCveGestor > 0)
                    loSentencia.Parametros.Add(new Parametro()
                    {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_CVE_VENDEDOR",
                        Tipo = DbType.Int32,
                        Valor = pnCveGestor
                    });

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
                throw new Clientes.Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerAuxiliarCXCSuprimir(Sesion poSesion, int pnClaveSucursal)
        {

            try
            {
                string lsSucursales = string.Empty;
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
							Nombre = "PSI_CVES_SUCURSALES",
							Tipo = DbType.Int32,
                            Valor = pnClaveSucursal
						}

						#endregion
					};
                loSentencia.TextoComando = "PKG_DAP_CXC_LAYOUT.PROC_AUXILIAR_CXC_LISTADO_SUP";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                loSentencias.Add(loSentencia);

                //foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
                //    lsSucursales += oSucursal.Clave + ",";

                //if (lsSucursales != string.Empty)
                //    loSentencia.Parametros.Add(new Parametro()
                //    {
                //        Direccion = ParameterDirection.Input,
                //        Nombre = "PSI_CVES_SUCURSALES",
                //        Tipo = DbType.String,
                //        Valor = lsSucursales.TrimEnd(',')
                //    });

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
                throw new Clientes.Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerGestoresSuprimir(Sesion poSesion, int pnAuxiliar)
        {

            try
            {
                string lsSucursales = string.Empty;
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
							Nombre = "PNI_CVE_AUXILIAR",
                            Tipo = DbType.Int32,
                            Valor = pnAuxiliar
						}

						#endregion
					};
                loSentencia.TextoComando = "PKG_DAP_CXC_LAYOUT.PROC_AUXILIAR_CXC_GESTORES_SUP";
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
                throw new Clientes.Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerClientesSuprimir(Sesion poSesion, int pnAuxiliar, int pnCveGestor)
        {

            try
            {
                string lsSucursales = string.Empty;
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
							Nombre = "PNI_CVE_AUXILIAR",
                            Tipo = DbType.Int32,
                            Valor = pnAuxiliar
						},
                        new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "PNI_CVE_GESTOR",
                            Tipo = DbType.Int32,
                            Valor = pnCveGestor
						}

						#endregion
					};
                loSentencia.TextoComando = "PKG_DAP_CXC_LAYOUT.PROC_AUXILIAR_CXC_CLIENTES_SUP";
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
                throw new Clientes.Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerAuxiliarCXCTemporal(Sesion poSesion, int pnClaveSucursal)
        {

            try
            {
                string lsSucursales = string.Empty;
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
							Nombre = "PSI_CVES_SUCURSALES",
							Tipo = DbType.Int32,
                            Valor = pnClaveSucursal
						}

						#endregion
					};
                loSentencia.TextoComando = "PKG_DAP_CXC_LAYOUT.PROC_AUXILIAR_CXC_LISTADO_TMP";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                loSentencias.Add(loSentencia);

                //foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
                //    lsSucursales += oSucursal.Clave + ",";

                //if (lsSucursales != string.Empty)
                //    loSentencia.Parametros.Add(new Parametro()
                //    {
                //        Direccion = ParameterDirection.Input,
                //        Nombre = "PSI_CVES_SUCURSALES",
                //        Tipo = DbType.String,
                //        Valor = lsSucursales.TrimEnd(',')
                //    });

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
                throw new Clientes.Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerGestoresTemporal(Sesion poSesion, int pnAuxiliar)
        {

            try
            {
                string lsSucursales = string.Empty;
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
							Nombre = "PNI_CVE_AUXILIAR",
                            Tipo = DbType.Int32,
                            Valor = pnAuxiliar
						}

						#endregion
					};
                loSentencia.TextoComando = "PKG_DAP_CXC_LAYOUT.PROC_AUXILIAR_CXC_GESTORES_TMP";
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
                throw new Clientes.Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerClientesTemporal(Sesion poSesion, int pnAuxiliar, int pnCveGestor)
        {

            try
            {
                string lsSucursales = string.Empty;
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
							Nombre = "PNI_CVE_AUXILIAR",
                            Tipo = DbType.Int32,
                            Valor = pnAuxiliar
						},
                        new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "PNI_CVE_GESTOR",
                            Tipo = DbType.Int32,
                            Valor = pnCveGestor
						}

						#endregion
					};
                loSentencia.TextoComando = "PKG_DAP_CXC_LAYOUT.PROC_AUXILIAR_CXC_CLIENTES_TMP";
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
                throw new Clientes.Comun.Excepcion(ex.Message, ex);
            }
        }
    }
}
