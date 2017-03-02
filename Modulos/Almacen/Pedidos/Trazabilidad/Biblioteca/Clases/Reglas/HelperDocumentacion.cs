using Dapesa.AccesoDatos.Comun;
using Dapesa.AccesoDatos.Entidades;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.Comun.Entidades;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dapesa.Almacen.Pedidos.Trazabilidad.Reglas
{
	internal class HelperDocumentacion
	{
		#region Metodos

		internal DataTable ObtenerConsignatario(Sesion poSesion, string psClienteID, string psPolizaSeguro)
		{

			try
			{
				Sentencia loSentencia = new Sentencia();
				string lsSucursales = string.Empty;

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
						Nombre = "PSI_POLIZA_SEGURO",
						Tipo = DbType.String,
						Valor = psPolizaSeguro
					},
					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					}

					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_ALMACEN_PEDIDO_TRAZA.PROC_DOC_CONSIGNATARIO";
				loSentencia.Tipo = Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = Definiciones.TipoResultado.Conjunto;

                foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
                    loSentencia.Parametros.Add(new Parametro()
                    {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_CVE_SUCURSAL" + oSucursal.Clave,
                        Tipo = DbType.Int64,
                        Valor = oSucursal.Clave
                    });

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
				loSentencia.TextoComando = "PKG_DAP_ALMACEN_PEDIDO_TRAZA.PROC_DOC_REMITENTE";
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

		internal DataTable ObtenerTransportistas(Sesion poSesion)
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
					}

					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_ALMACEN_PEDIDO_TRAZA.PROC_DOC_TRANSPORTISTAS";
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
