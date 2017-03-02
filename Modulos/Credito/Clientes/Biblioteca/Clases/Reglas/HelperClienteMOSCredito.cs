using Dapesa.AccesoDatos.Entidades;
using Dapesa.Comun.Utilerias;
using Dapesa.Credito.Clientes.Reglas.Proxy;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dapesa.Credito.Clientes.Reglas
{
	internal class HelperClienteMOSCredito
	{
		#region Metodos

		internal DataTable Obtener(Sesion poSesion, string psClaveCliente, int pnAnio)
		{

			try
			{
				List<Sentencia> loSentencias = new List<Sentencia>();
				Sentencia loSentencia = new Sentencia();

				loSentencia.Parametros = new List<Parametro>() {
						#region Parametros

						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "PSI_CVE_CLIENTE",
							Tipo = DbType.String,
							Valor = psClaveCliente
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "PNI_ANIO",
							Tipo = DbType.Int32,
							Valor = pnAnio
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
				loSentencia.TextoComando = "PKG_DAP_CREDITO_CTES.PROC_MOS_CREDITO";
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

		internal DataTable ObtenerEncabezado(Sesion poSesion, string psClaveCliente, int pnAnio)
		{

			try
			{
				List<Sentencia> loSentencias = new List<Sentencia>();
				Sentencia loSentencia = new Sentencia();

				loSentencia.Parametros = new List<Parametro>() {
						#region Parametros

						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "PSI_CVE_CLIENTE",
							Tipo = DbType.String,
							Valor = psClaveCliente
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "PSI_USR_PERSONAL",
							Tipo = DbType.String,
							Valor = poSesion.Usuario.Nombre.ToUpper()
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "PNI_ANIO",
							Tipo = DbType.Int32,
							Valor = pnAnio
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
				loSentencia.TextoComando = "PKG_DAP_CREDITO_CTES.PROC_MOS_CREDITO_ENCABEZADO";
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

		internal DataTable ObtenerSaldos(Sesion poSesion, string psClaveCliente)
		{

			try
			{
				List<Sentencia> loSentencias = new List<Sentencia>();
				Sentencia loSentencia = new Sentencia();

				loSentencia.Parametros = new List<Parametro>() {
						#region Parametros

						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "PSI_CVE_CLIENTE",
							Tipo = DbType.String,
							Valor = psClaveCliente
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
				loSentencia.TextoComando = "PKG_DAP_CREDITO_CTES.PROC_MOS_CREDITO_SALDOS";
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

		#endregion
	}
}
