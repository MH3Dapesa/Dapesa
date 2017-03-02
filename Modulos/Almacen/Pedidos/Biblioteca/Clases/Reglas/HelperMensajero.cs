using Dapesa.AccesoDatos.Comun;
using Dapesa.AccesoDatos.Entidades;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dapesa.Almacen.Pedidos.Reglas
{
	internal class HelperMensajero
	{
		#region Metodos

		internal DataTable ObtenerPedidos(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin)
		{

			try
			{
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
						Valor = poSesion.Usuario.Sucursal[0].Clave
					},
					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					}

					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_ALMACEN_PEDIDO.PROC_MENSAJERO";
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

		#endregion
	}
}
