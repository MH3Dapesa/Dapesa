using Dapesa.AccesoDatos.Entidades;
using Dapesa.Comun.Utilerias;
using Dapesa.Facturacion.Documentos.Comun;
using Dapesa.Seguridad.Entidades;
using Dapesa.Facturacion.Documentos.Reglas.Proxy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;


namespace Dapesa.Facturacion.Documentos.Reglas
{
    internal class HelperFacturas
    {
        internal DataTable ObtenerFoliosFacturas(Sesion poSesion, string pnNumeroFactura, string poFechaFactura)
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
							Nombre = "PNI_CVE_PERSONAL",
							Tipo = DbType.Int32,
							Valor = poSesion.Usuario.Id
						},
                        new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "PNI_NUMERO_FACTURA",
							Tipo = DbType.Int32,
							Valor = ((!string.IsNullOrEmpty(pnNumeroFactura)) ? pnNumeroFactura : null)
						},
                        new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "PNO_FECHA_FACTURA",
							Tipo = DbType.Date,
							Valor = ((string.IsNullOrEmpty(pnNumeroFactura) && !string.IsNullOrEmpty(poFechaFactura) ? DateTime.Now.AddMinutes(-double.Parse(poFechaFactura)) :  DateTime.Parse(DateTime.Now.ToShortDateString() + " 01:00:00")))
						}
						#endregion
					};
                loSentencia.TextoComando = "PKG_DAP_FACTURACION.PROC_CONSULTA_FOL_FACT";
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
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerFacturas(Sesion poSesion, string pnNumeroFactura)
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
							Nombre = "PNI_CVE_PERSONAL",
							Tipo = DbType.Int32,
							Valor = poSesion.Usuario.Id
						},
                        new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "PNI_NUMERO_FACTURA",
							Tipo = DbType.Int32,
							Valor = ((!string.IsNullOrEmpty(pnNumeroFactura)) ? pnNumeroFactura : null)
						}
						#endregion
					};
                loSentencia.TextoComando = "PKG_DAP_FACTURACION.PROC_CONSULTA_FACTURAS";
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
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerSucursal(Sesion poSesion)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
                Sentencia loSentencia = new Sentencia();
                loSentencia.Parametros = new List<Parametro>() {
						#region Parametros

                        new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "PNI_CVE_SUCURSAL",
							Tipo = DbType.Int32,
							Valor = poSesion.Usuario.Sucursal[0].Clave
                        },
                        new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "PSI_RAZON_SOCIAL",
							Tipo = DbType.String,
							Valor = ConfigurationManager.AppSettings["RazonSocial"]
						},
						new Parametro() {
							Direccion = ParameterDirection.Output,
							Nombre = "PCO_CURSOR",
							Tipo = DbType.Object
						}
						
						#endregion
					};
                loSentencia.TextoComando = "PKG_DAP_ALMACEN_PEDIDO_TRAZA.PROC_DOC_REMITENTE";
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
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }
    }
}
