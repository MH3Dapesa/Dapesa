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
	internal class HelperItinerario
	{
		#region Metodos

		internal bool Guardar(Sesion poSesion, Dictionary<string, Bitacora> poBitacoras, int pnAnio, int pnSemana)
		{

			try
			{
				List<Sentencia> loSentencias = new List<Sentencia>();

				foreach (string loKey in poBitacoras.Keys)
				{
					Sentencia loSentencia = new Sentencia();

					loSentencia.Parametros = new List<Parametro>() {
						#region Parametros

						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "CVE_CLIENTE",
							Tipo = DbType.String,
							Valor = loKey
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "LUNES",
							Tipo = DbType.String,
							Valor = poBitacoras[loKey].Lunes
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "MARTES",
							Tipo = DbType.String,
							Valor = poBitacoras[loKey].Martes
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "MIERCOLES",
							Tipo = DbType.String,
							Valor = poBitacoras[loKey].Miercoles
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "JUEVES",
							Tipo = DbType.String,
							Valor = poBitacoras[loKey].Jueves
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "VIERNES",
							Tipo = DbType.String,
							Valor = poBitacoras[loKey].Viernes
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "SABADO",
							Tipo = DbType.String,
							Valor = poBitacoras[loKey].Sabado
						}

						#endregion
					};
					loSentencia.TextoComando = 
						#region Definir sentencia de insercion/actualizacion

						"MERGE INTO DAP_VENTAS_TLMK_ITINERARIO I " +
						"		USING (SELECT " + poSesion.Usuario.Id + " AS CVE_PERSONAL,:1 AS CVE_CLIENTE," + pnAnio + " AS ANIO," + pnSemana + " AS SEMANA,:2 AS LUNES,:3 AS MARTES,:4 AS MIERCOLES,:5 AS JUEVES,:6 AS VIERNES,:7 AS SABADO FROM DUAL) D " +
						"		ON (I.CVE_PERSONAL=D.CVE_PERSONAL AND I.CVE_CLIENTE=D.CVE_CLIENTE AND I.ANIO=D.ANIO AND I.SEMANA=D.SEMANA) " +
						"	WHEN MATCHED THEN " +
						"		UPDATE SET I.LUNES=D.LUNES,I.MARTES=D.MARTES,I.MIERCOLES=D.MIERCOLES,I.JUEVES=D.JUEVES,I.VIERNES=D.VIERNES,I.SABADO=D.SABADO " +
						"	WHEN NOT MATCHED THEN " +
						"		INSERT (I.CVE_PERSONAL,I.CVE_CLIENTE,I.ANIO,I.SEMANA,I.LUNES,I.MARTES,I.MIERCOLES,I.JUEVES,I.VIERNES,I.SABADO) " +
						"		VALUES (D.CVE_PERSONAL,D.CVE_CLIENTE,D.ANIO,D.SEMANA,D.LUNES,D.MARTES,D.MIERCOLES,D.JUEVES,D.VIERNES,D.SABADO)";

						#endregion
					loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.NoQuery;
					loSentencia.TipoComando = CommandType.Text;
					loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.ContinuarTransaccion;
					loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Entero;
					loSentencias.Add(loSentencia);

					if (poBitacoras[loKey].Contacto != null)
					{
						loSentencia = new Sentencia();
						loSentencia.Parametros = new List<Parametro>() {
							#region Parametros

							new Parametro() {
								Direccion = ParameterDirection.Input,
								Nombre = "TIPO_PODER",
								Tipo = DbType.String,
								Valor = poBitacoras[loKey].Contacto.Observaciones
							},
							new Parametro() {
								Direccion = ParameterDirection.Input,
								Nombre = "CLAVE",
								Tipo = DbType.Int64,
								Valor = poBitacoras[loKey].Contacto.Clave
							},
							new Parametro() {
								Direccion = ParameterDirection.Input,
								Nombre = "CLI_CLAVE",
								Tipo = DbType.String,
								Valor = loKey
							}

							#endregion
						};
						loSentencia.TextoComando = "UPDATE CONTACTOS_CLIENTE SET TIPO_PODER=:1 WHERE CLAVE=:2 AND CLI_CLAVE=:3";
						loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.NoQuery;
						loSentencia.TipoComando = CommandType.Text;
						loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.ContinuarTransaccion;
						loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Entero;
						loSentencias.Add(loSentencia);
					}
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

		internal DataTable Obtener(Sesion poSesion, int pnAnio, int pnSemana)
		{
			try
			{
				List<Sentencia> loSentencias = new List<Sentencia>();
				Sentencia loSentencia = new Sentencia();

				loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_PERSONAL",
						Tipo = DbType.Int32,
						Valor = poSesion.Usuario.Id
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_USR_PERSONAL",
						Tipo = DbType.String,
						Valor = poSesion.Usuario.Clave
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = poSesion.Usuario.Sucursal[0].Clave
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_ANIO",
						Tipo = DbType.Int32,
						Valor = pnAnio
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_SEMANA",
						Tipo = DbType.Int32,
						Valor = pnSemana
					},
					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					}

					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_VENTAS.PROC_TLMK_ITINERARIO";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
				loSentencias.Add(loSentencia);

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

		internal DataTable ObtenerTotalSemanal(Sesion poSesion, DateTime poFechaSemanaActual, DateTime poFechaSemanaAnterior)
		{
			try
			{
				List<Sentencia> loSentencias = new List<Sentencia>();
				Sentencia loSentencia = new Sentencia();

				loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_USR_PERSONAL",
						Tipo = DbType.String,
						Valor = poSesion.Usuario.Clave
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_SEMANA_ACTUAL",
						Tipo = DbType.Date,
						Valor = poFechaSemanaActual
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_SEMANA_ANTERIOR",
						Tipo = DbType.Date,
						Valor = poFechaSemanaAnterior
					},
					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					}

					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_VENTAS.PROC_TLMK_TOTALxSEMANA";
                //loSentencia.TextoComando = "PKG_DAP_MONITOREO.PROC_TLMK_TOTALxSEMANA";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
				loSentencias.Add(loSentencia);

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

		#endregion
	}
}
