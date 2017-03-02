using Dapesa.AccesoDatos.Entidades;
using Dapesa.Comun.Utilerias;
using Dapesa.Credito.Pedidos.Reglas.Proxy;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dapesa.Credito.Pedidos.Reglas
{
    internal class HelperMensajeroCXC
    {
        #region Metodos

        internal DataTable ObtenerPedidos(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, int pnSucursal)
        {

            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
                Sentencia loSentencia = new Sentencia();


                loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_INICIO",
						Tipo = DbType.Date,
						Valor = poFechaInicio
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_FIN",
						Tipo = DbType.Date,
						Valor = poFechaFin
					},
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


                loSentencia.TextoComando = "PKG_DAP_ALMACEN_PEDIDO.PROC_CXC_MENSAJERO";
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
                DataTable lodtAuxiliar = loResultado.Clone();

                //DataRow[] query = loResultado.Select("ORDEN = 3 AND EXISTENCIA > 0");
                DataRow[] query = loResultado.Select("ORDEN = 3 ");

                foreach (DataRow fila in query)
                {
                    //lodtAuxiliar.Rows.Add(fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6], fila[7], fila[8], fila[9], fila[10], fila[11], fila[12], fila[13], fila[14], fila[15], fila[16]);
                    lodtAuxiliar.Rows.Add(fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6], fila[7], fila[8], fila[9], fila[10], fila[11], fila[12], fila[13], fila[14], fila[15], fila[16], fila[17], fila[18]);
                }
                loResultado.Rows.Clear();
                loResultado.Merge(lodtAuxiliar);


                loDespachador.ChannelFactory.Close();
                loDespachador.Close();
                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Pedidos.Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerSucursales(Sesion poSesion, int psCveUsuario)
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
						Nombre = "PSI_CVE_USUARIO",
						Tipo = DbType.Int32,
						Valor = psCveUsuario
					}
					
					#endregion
				};

                string lsSucursales = string.Empty;
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

                loSentencia.TextoComando = "PKG_DAP_ALMACEN_PEDIDO.PROC_SUCURSALES";
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
                throw new Pedidos.Comun.Excepcion(ex.Message, ex);
            }
        }
        #endregion
    }
}
