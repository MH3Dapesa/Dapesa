using Dapesa.AccesoDatos.Entidades;
using Dapesa.Comun.Entidades;
using Dapesa.Comun.Utilerias;
using Dapesa.Seguridad.Comun;
using Dapesa.Seguridad.Reglas.Proxy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Dapesa.Seguridad.Reglas
{
	internal class Usuario
	{
		#region Metodos

		internal Entidades.Usuario Obtener(Conexion poConexion)
		{

			try
			{
				Entidades.Usuario loUsuario = new Entidades.Usuario() {
					Clave = poConexion.Credenciales.Usuario,
					Estatus = Seguridad.Comun.Definiciones.EstatusUsuario.Valido,
					Sucursal = new List<Entidades.Sucursal>()
				};
				Sentencia loSentencia = new Sentencia();

				loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_USUARIO",
						Tipo = DbType.String,
						Valor = poConexion.Credenciales.Usuario
					},
					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					}

					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_SEGURIDAD.PROC_PERSONAL_SUCURSALES";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

				DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorSeguridad");
				Serializacion loDeserializador = new Serializacion();
				DataTable loResultado = loDeserializador.DeserializarTabla(
					poConexion.Credenciales.Cifrado.Descifrar(
						(byte[])loDespachador.Despachar(poConexion, new List<Sentencia>() { loSentencia }
					)));

				foreach (DataRow oUsuarioSucursal in loResultado.Rows)
				{
					loUsuario.Id = int.Parse(oUsuarioSucursal["ID"].ToString());
					loUsuario.Nombre = oUsuarioSucursal["NOMBRE"].ToString();
					loUsuario.Sucursal.Add(new Entidades.Sucursal()	{
						Clave = int.Parse(oUsuarioSucursal["CLAVE"].ToString()),
						Descripcion = oUsuarioSucursal["DESCRIPCION"].ToString(),
						DescripcionCorta = oUsuarioSucursal["DESC_CORTA"].ToString()
					});
				}

				loUsuario.Grupo = this.ObtenerGrupos(poConexion, loUsuario.Id);
				loUsuario.Permiso = this.ObtenerPermisos(poConexion, loUsuario.Id);
				return loUsuario;
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		internal List<Entidades.Grupo> ObtenerGrupos(Conexion poConexion, int pnIdUsuario)
		{

			try
			{
				List<Entidades.Grupo> loGrupo = new List<Entidades.Grupo>();
				Sentencia loSentencia = new Sentencia();

				loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_PERSONAL",
						Tipo = DbType.Int32,
						Valor = pnIdUsuario
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_KEY_ID",
						Tipo = DbType.String,
						Valor = poConexion.IdAplicacion
					},
					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					}

					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_SEGURIDAD.PROC_GRUPOS";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

				DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorSeguridad");
				Serializacion loDeserializador = new Serializacion();
				DataTable loResultado = loDeserializador.DeserializarTabla(
					poConexion.Credenciales.Cifrado.Descifrar(
						(byte[])loDespachador.Despachar(poConexion, new List<Sentencia>() { loSentencia }
					)));

				foreach (DataRow oGrupo in loResultado.Rows)
				{
					loGrupo.Add(new Entidades.Grupo()	{
						Clave = int.Parse(oGrupo["CVE_GRUPO"].ToString()),
						Descripcion = oGrupo["GRUPO"].ToString()
					});
				}

				return loGrupo;
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		internal List<Entidades.Permiso> ObtenerPermisos(Conexion poConexion, int pnIdUsuario)
		{

			try
			{
				Dictionary<int, Entidades.Permiso> loPermisos = new Dictionary<int,Entidades.Permiso>();
				Sentencia loSentencia = new Sentencia();

				loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_PERSONAL",
						Tipo = DbType.Int32,
						Valor = pnIdUsuario
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_KEY_ID",
						Tipo = DbType.String,
						Valor = poConexion.IdAplicacion
					},
					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					}

					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_SEGURIDAD.PROC_PERMISOS";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

				DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorSeguridad");
				Serializacion loDeserializador = new Serializacion();
				DataTable loResultado = loDeserializador.DeserializarTabla(
					poConexion.Credenciales.Cifrado.Descifrar(
						(byte[])loDespachador.Despachar(poConexion, new List<Sentencia>() { loSentencia }
					)));

				foreach (DataRow oPermiso in loResultado.Rows)
				{
					int lnClavePermiso = int.Parse(oPermiso["CLAVE"].ToString());

					if (loPermisos.ContainsKey(lnClavePermiso))
					{
						loPermisos[lnClavePermiso].TipoPermiso.Add(
							(Definiciones.TipoPermiso)int.Parse(oPermiso["CVE_TIPO_PERMISO"].ToString())
						);
						continue;
					}

					loPermisos.Add(lnClavePermiso, new Entidades.Permiso()	{
						Agrupador = (oPermiso["CVE_AGRUPADOR"]==DBNull.Value) ? (long?)null : long.Parse(oPermiso["CVE_AGRUPADOR"].ToString()),
						Aplicacion = new Entidades.Aplicacion() {
							Clave = int.Parse(oPermiso["CVE_APLICACION"].ToString()),
							Descripcion = oPermiso["APLICACION"].ToString(),
							KeyId = poConexion.IdAplicacion
						},
						Clave = lnClavePermiso,
						Descripcion = oPermiso["DESCRIPCION"].ToString(),
						Orden = int.Parse(oPermiso["ORDEN"].ToString()),
						TipoElemento = (Definiciones.TipoElemento)int.Parse(oPermiso["CVE_TIPO_ELEMENTO"].ToString()),
						TipoPermiso = new List<Definiciones.TipoPermiso>() {
							(Definiciones.TipoPermiso)int.Parse(oPermiso["CVE_TIPO_PERMISO"].ToString())
						},
						Url = oPermiso["URL"].ToString(),
					});
				}

				return loPermisos.Values.ToList();
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		#endregion
	}
}
