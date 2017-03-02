using Dapesa.AccesoDatos.Entidades;
using Dapesa.Comun.Utilerias;
using Dapesa.Seguridad.Entidades;
using Dapesa.Ventas.Telemarketing.Entidades;
using Dapesa.Ventas.Telemarketing.Reglas.Proxy;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dapesa.Ventas.Telemarketing.Reglas
{
	internal class HelperLayoutCliente
	{
		#region Metodos

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

							"MERGE INTO DAP_VENTAS_TLMK_CTE" + ((pbAsignacionTemporal) ? "_TMP" : string.Empty) + " TC \r\n" +
							"		USING (SELECT :1 AS CVE_CLIENTE,(SELECT P.CLAVE FROM PERSONAL P WHERE P." + ((pbAsignacionTemporal) ? string.Empty : "USR_") + "CLAVE=:2) AS CVE_PERSONAL,:3 AS STATUS_CAN FROM DUAL) D \r\n" +
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

					DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorItinerario");
					
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

		internal bool Eliminar(Sesion poSesion, List<Asignacion> poAsignaciones)
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

						"DELETE FROM DAP_VENTAS_TLMK_CTE_TMP WHERE CVE_CLIENTE=:1 AND CVE_PERSONAL=:2";

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

					DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorItinerario");
					
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

		internal DataTable Obtener(Sesion poSesion)
		{

			try
			{
				List<Sentencia> loSentencias = new List<Sentencia>();
				Sentencia loSentencia = new Sentencia();
				string lsSucursales = string.Empty;

				loSentencia.Parametros = new List<Parametro>() {
						#region Parametros

						new Parametro() {
							Direccion = ParameterDirection.Output,
							Nombre = "PCO_CURSOR",
							Tipo = DbType.Object
						}

						#endregion
					};
				loSentencia.TextoComando = "PKG_DAP_VENTAS_LAYOUT.PROC_TLMK_CLIENTE";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
				loSentencias.Add(loSentencia);

				foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
					lsSucursales += oSucursal.Clave + ",";

				if (lsSucursales != string.Empty)
					loSentencia.Parametros.Add(new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVES_SUCURSALES",
						Tipo = DbType.String,
						Valor = lsSucursales.TrimEnd(',')
					});

				DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorItinerario");
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

		internal DataTable ObtenerClientes(Sesion poSesion, string psClaveTelemarketing, string psClaveVendedor, bool pbAsignacionTemporal)
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
				loSentencia.TextoComando = "PKG_DAP_VENTAS_LAYOUT.PROC_TLMK_CLIENTES" + ((pbAsignacionTemporal) ? "_TMP" : string.Empty);
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
				loSentencias.Add(loSentencia);

				if (!string.IsNullOrEmpty(psClaveTelemarketing))
				{
					long lnClaveVendedor = long.Parse(psClaveVendedor);

					loSentencia.Parametros.Add(new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_USUARIO",
						Tipo = DbType.Int64,
						Valor = long.Parse(psClaveTelemarketing)
					});

					if (lnClaveVendedor > 0)
						loSentencia.Parametros.Add(new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "PNI_CVE_VENDEDOR",
							Tipo = DbType.Int64,
							Valor = lnClaveVendedor
						});
				}

				DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorItinerario");
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

		internal DataTable ObtenerTelemarketing(Sesion poSesion, string psClaveTelemarketingExcluir)
		{

			try
			{
				List<Sentencia> loSentencias = new List<Sentencia>();
				Sentencia loSentencia = new Sentencia();
				string lsSucursales = string.Empty;

				loSentencia.Parametros = new List<Parametro>() {
						#region Parametros

						new Parametro() {
							Direccion = ParameterDirection.Output,
							Nombre = "PCO_CURSOR",
							Tipo = DbType.Object
						}

						#endregion
					};
				loSentencia.TextoComando = "PKG_DAP_VENTAS_LAYOUT.PROC_TLMK_LISTADO";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
				loSentencias.Add(loSentencia);

				long lnClaveTelemarketingExcluir = -1;

				if (!string.IsNullOrEmpty(psClaveTelemarketingExcluir))
					lnClaveTelemarketingExcluir = long.Parse(psClaveTelemarketingExcluir);

				loSentencia.Parametros.Add(new Parametro() {
					Direccion = ParameterDirection.Input,
					Nombre = "PNI_CVE_USUARIO",
					Tipo = DbType.Int64,
					Valor = lnClaveTelemarketingExcluir
				});

				foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
					lsSucursales += oSucursal.Clave + ",";

				if (lsSucursales != string.Empty)
					loSentencia.Parametros.Add(new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "PNI_CVES_SUCURSALES",
							Tipo = DbType.String,
							Valor = lsSucursales.TrimEnd(',')
						});

				DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorItinerario");
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

		internal DataTable ObtenerVendedores(Sesion poSesion, string psClaveTelemarketing, bool pbAsignacionTemporal)
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
				loSentencia.TextoComando = "PKG_DAP_VENTAS_LAYOUT.PROC_TLMK_VENDEDORES" + ((pbAsignacionTemporal) ? "_TMP" : string.Empty);
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
				loSentencias.Add(loSentencia);

				if (!string.IsNullOrEmpty(psClaveTelemarketing))
					loSentencia.Parametros.Add(new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_USUARIO",
						Tipo = DbType.Int64,
						Valor = long.Parse(psClaveTelemarketing)
					});

				DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorItinerario");
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

		internal bool PerteneceA(Sesion poSesion, string psClaveCliente, string psClaveUsuario)
		{

			try
			{
				List<Sentencia> loSentencias = new List<Sentencia>();
				Sentencia loSentencia = new Sentencia();
				string lsSucursales = string.Empty;
				
				loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.InputOutput,
						Nombre = "PNO_RESULTADO",
						Tipo = DbType.Int32,
						Valor = 0
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_CLIENTE",
						Tipo = DbType.String,
						Valor = psClaveCliente
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_USUARIO",
						Tipo = DbType.String,
						Valor = psClaveUsuario
					}

					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_VENTAS_LAYOUT.PROC_TLMK_PERTENECE_SUC";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Entero;
				loSentencias.Add(loSentencia);

				foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
					lsSucursales += oSucursal.Clave + ",";

					loSentencia.Parametros.Add(new Parametro()
					{
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVES_SUCURSALES",
						Tipo = DbType.String,
						Valor = lsSucursales.TrimEnd(',')
					});

				DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorItinerario");
				Parametro[] loParametrosSalida = new Parametro[] {};
				int loResultado = (int)loDespachador.Despachar(poSesion.Conexion, loSentencias);

				loDespachador.ChannelFactory.Close();
				loDespachador.Close();
				return (loResultado == 1) ? true : false;
			}
			catch (Exception ex)
			{
				throw new Comun.Excepcion(ex.Message, ex);
			}
		}

		#endregion
	}
}
