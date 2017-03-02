using Dapesa.AccesoDatos.Comun;
using Dapesa.AccesoDatos.Entidades;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dapesa.Credito.NCR.Reglas
{
	internal class HelperImpresion
	{
		#region Metodos

		internal DataTable ObtenerConsignatario(Sesion poSesion, string psClienteID, DateTime poFecha)
		{

			try
			{
				Sentencia loSentencia = new Sentencia();

				loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_CLIENTE",
						Tipo = DbType.String,
						Valor = psClienteID
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA",
						Tipo = DbType.Date,
						Valor = poFecha
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = poSesion.Usuario.Sucursal[0].Clave
					},
					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					}

					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_CREDITO_NCR.PROC_SOBRES_CONSIGNATARIO";
				loSentencia.Tipo = Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = Definiciones.TipoResultado.Conjunto;

				Planificador loPlanificador = new Planificador();
				DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>(){ loSentencia });

				return loResultado;
			}
			catch (Exception ex)
			{
				throw new Comun.Excepcion(ex.Message, ex);
			}
		}

		internal DataTable ObtenerRemitente(Sesion poSesion, string psRazonSocial)
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
						Valor = poSesion.Usuario.Sucursal[0].Clave
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_RAZON_SOCIAL",
						Tipo = DbType.String,
						Valor = psRazonSocial
					},
					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					}

					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_CREDITO_NCR.PROC_SOBRES_REMITENTE";
				loSentencia.Tipo = Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = Definiciones.TipoResultado.Conjunto;

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
