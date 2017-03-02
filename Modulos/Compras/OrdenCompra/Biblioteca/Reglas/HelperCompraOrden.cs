using Dapesa.AccesoDatos.Entidades;
using Dapesa.Comun.Utilerias;
using Dapesa.Compras.OrdenCompra.Reglas.Proxy;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;


namespace Dapesa.Compras.OrdenCompra.Reglas
{
    internal class HelperCompraOrden
    {
        internal DataTable Obtener(Sesion poSesion, string psFolioOrdenCompra, int pnSucursal)
        {

            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
                Sentencia loSentencia = new Sentencia();

                //loSentencia.Parametros = new List<Parametro>() {
                //         #region Parametros

                //         new Parametro() {
                //             Direccion = ParameterDirection.Input,
                //             Nombre = "PSI_CVE_CLIENTE",
                //             Tipo = DbType.String,
                //             Valor = psClaveCliente
                //         },
                //         new Parametro() {
                //             Direccion = ParameterDirection.Input,
                //             Nombre = "PNI_ANIO",
                //             Tipo = DbType.Int32,
                //             Valor = pnAnio
                //         },
                //         new Parametro() {
                //             Direccion = ParameterDirection.Input,
                //             Nombre = "PNI_CVE_SUCURSAL",
                //             Tipo = DbType.Int32,
                //             Valor = poSesion.Usuario.Sucursal[0].Clave
                //         },
                //         new Parametro() {
                //             Direccion = ParameterDirection.Output,
                //             Nombre = "PCO_CURSOR",
                //             Tipo = DbType.Object
                //         }

                //         #endregion
                //     };
                loSentencia.TextoComando = "SELECT  OC.FOLOC_FOLIO,OC.NUMERO,OC.FECHA,SUC.SUCURSAL,P.RAZON_SOCIAL,(SELECT M.DESC_CORTA FROM MONEDAS M WHERE CLAVE = OC.MON_CLAVE)MONEDA,OC.USUARIO_AUT,( SELECT PER.NOMBRE||' ' || PER.NOMBRE2 ||' ' || PER.APELLIDO_PATERNO ||' ' || PER.APELLIDO_MATERNO FROM PERSONAL PER WHERE PER.USR_CLAVE = OC.USUARIO) PERSONAL " +
 " FROM (SELECT SFOC.FOLOC_FOLIO,SFOC.SUC_CLAVE,S.DESCRIPCION AS SUCURSAL FROM SUC_FOLIOS_ORDENES_COMPRAS SFOC, SUCURSALES S WHERE SFOC.SUC_CLAVE=S.CLAVE AND SFOC.VER='S' AND SFOC.UTILIZAR='S')SUC, ORDENES_COMPRAS OC, PROVEEDORES P, SUC_ALMACENES SA" +
 " WHERE OC.FOLOC_FOLIO=SUC.FOLOC_FOLIO AND OC.PROV_CLAVE = P.CLAVE AND SA.ALM_CLAVE=OC.ALM_CLAVE AND SA.SUC_CLAVE=SUC.SUC_CLAVE AND SUC.SUC_CLAVE=" + pnSucursal + " AND P.CLAVE = 254 " + " AND OC.FOLOC_FOLIO||OC.NUMERO ='" + psFolioOrdenCompra + "' AND  OC.STATUS_CAN='N' ";

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

        internal DataTable ObtenerDatosOrdenCompra(Sesion poSesion, string psFolioOrdenCompra, int pnNumeroOrdenCompra, int pnSucursal)
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
                            Nombre = "PSI_OC_FOLIO",
                            Tipo = DbType.String,
                            Valor = psFolioOrdenCompra
                        },
                        new Parametro() {
                            Direccion = ParameterDirection.Input,
                            Nombre = "PNI_OC_NUMERO",
                            Tipo = DbType.Int32,
                            Valor = pnNumeroOrdenCompra
                        },
                        new Parametro() {
                            Direccion = ParameterDirection.Input,
                            Nombre = "PNI_CVE_SUCURSAL",
                            Tipo = DbType.Int32,
                            Valor = pnSucursal
                        }

                        #endregion
               };
                loSentencia.TextoComando = "PKG_DAP_MONITOREO.PROC_COMPRAS_OC";
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

        internal DataTable ObtenerSucursal(Sesion poSesion, string psClavePersonal)
        {

            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
                Sentencia loSentencia = new Sentencia();

                //loSentencia.Parametros = new List<Parametro>() {
                //         #region Parametros

                //         new Parametro() {
                //             Direccion = ParameterDirection.Input,
                //             Nombre = "PSI_CVE_CLIENTE",
                //             Tipo = DbType.String,
                //             Valor = psClaveCliente
                //         },
                //         new Parametro() {
                //             Direccion = ParameterDirection.Input,
                //             Nombre = "PNI_ANIO",
                //             Tipo = DbType.Int32,
                //             Valor = pnAnio
                //         },
                //         new Parametro() {
                //             Direccion = ParameterDirection.Input,
                //             Nombre = "PNI_CVE_SUCURSAL",
                //             Tipo = DbType.Int32,
                //             Valor = poSesion.Usuario.Sucursal[0].Clave
                //         },
                //         new Parametro() {
                //             Direccion = ParameterDirection.Output,
                //             Nombre = "PCO_CURSOR",
                //             Tipo = DbType.Object
                //         }

                //         #endregion
                //     };
                loSentencia.TextoComando = "SELECT S.CLAVE, S.DESCRIPCION FROM SUCURSALES S WHERE S.CLAVE IN(1,2,3,5) ORDER BY DESCRIPCION ASC";

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

        internal DataTable ObtenerProveedores(Sesion poSesion)
        {

            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
                Sentencia loSentencia = new Sentencia();

                //loSentencia.Parametros = new List<Parametro>() {
                //         #region Parametros

                //         new Parametro() {
                //             Direccion = ParameterDirection.Input,
                //             Nombre = "PSI_CVE_CLIENTE",
                //             Tipo = DbType.String,
                //             Valor = psClaveCliente
                //         },
                //         new Parametro() {
                //             Direccion = ParameterDirection.Input,
                //             Nombre = "PNI_ANIO",
                //             Tipo = DbType.Int32,
                //             Valor = pnAnio
                //         },
                //         new Parametro() {
                //             Direccion = ParameterDirection.Input,
                //             Nombre = "PNI_CVE_SUCURSAL",
                //             Tipo = DbType.Int32,
                //             Valor = poSesion.Usuario.Sucursal[0].Clave
                //         },
                //         new Parametro() {
                //             Direccion = ParameterDirection.Output,
                //             Nombre = "PCO_CURSOR",
                //             Tipo = DbType.Object
                //         }

                //         #endregion
                //     };
                loSentencia.TextoComando = "select CLAVE,RAZON_SOCIAL from proveedores where clave=254 and STATUS='A'";

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
    }
}
