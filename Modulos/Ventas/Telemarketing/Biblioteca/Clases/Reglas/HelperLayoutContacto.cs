using Dapesa.AccesoDatos.Comun;
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
	internal class HelperLayoutContacto
	{
		#region Metodos

		internal bool Guardar(Sesion poSesion, List<ContactoCliente> poContactos)
		{

			try
			{
				List<Sentencia> loSentencias = new List<Sentencia>();

				foreach (ContactoCliente loContacto in poContactos)
				{
					Sentencia loSentencia = new Sentencia();

					loSentencia.Parametros = new List<Parametro>() {
						#region Parametros

						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "CLI_CLAVE",
							Tipo = DbType.String,
							Valor = loContacto.ClaveCliente
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "NOMBRE",
							Tipo = DbType.String,
							Valor = loContacto.Nombre
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "APELLIDO_PATERNO",
							Tipo = DbType.String,
							Valor = loContacto.ApellidoPaterno
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "NOMBRE_APODO",
							Tipo = DbType.String,
							Valor = loContacto.Apodo
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "TIPO",
							Tipo = DbType.String,
							Valor = loContacto.Puesto
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "TEL_EXT",
							Tipo = DbType.String,
							Valor = loContacto.Telefono
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "CELULAR",
							Tipo = DbType.String,
							Valor = loContacto.Celular
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "RADIO_LOC",
							Tipo = DbType.String,
							Valor = loContacto.Nextel
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "EMAIL",
							Tipo = DbType.String,
							Valor = loContacto.Correo
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "TIPO_PODER",
							Tipo = DbType.String,
							Valor = loContacto.Observaciones
						}

						#endregion
					};
					loSentencia.TextoComando = 
						#region Definir sentencia de insercion/actualizacion

							"MERGE INTO CONTACTOS_CLIENTE C \r\n" +
							"		USING (SELECT :1 AS CLI_CLAVE,:2 AS NOMBRE,:3 AS APELLIDO_PATERNO,:4 AS NOMBRE_APODO,:5 AS TIPO,:6 AS TEL_EXT,:7 AS CELULAR,:8 AS RADIO_LOC,:9 AS EMAIL,:10 AS TIPO_PODER FROM DUAL) D \r\n" +
							"		ON (C.CLI_CLAVE=D.CLI_CLAVE) \r\n" +
							"	WHEN MATCHED THEN \r\n" +
							"		UPDATE SET C.NOMBRE=D.NOMBRE,C.APELLIDO_PATERNO=D.APELLIDO_PATERNO,C.NOMBRE_APODO=D.NOMBRE_APODO,C.TIPO=D.TIPO,C.TEL_EXT=D.TEL_EXT,C.CELULAR=D.CELULAR,C.RADIO_LOC=D.RADIO_LOC,C.EMAIL=D.EMAIL,C.TIPO_PODER=D.TIPO_PODER,C.TEXTO1='" + poSesion.Usuario.Clave + "',C.FECHA1=SYSDATE \r\n" +
							"	WHEN NOT MATCHED THEN \r\n" +
							"		INSERT (C.CLAVE,C.CLI_CLAVE,C.NOMBRE,C.APELLIDO_PATERNO,C.NOMBRE_APODO,C.TIPO,C.TEL_EXT,C.CELULAR,C.RADIO_LOC,C.EMAIL,C.TIPO_PODER,C.TI_CON_CLAVE,C.TEXTO1,C.FECHA1) \r\n" +
							"		VALUES (S_CONTACTOS_CLIENTE.NEXTVAL,D.CLI_CLAVE,D.NOMBRE,D.APELLIDO_PATERNO,D.NOMBRE_APODO,D.TIPO,D.TEL_EXT,D.CELULAR,D.RADIO_LOC,D.EMAIL,D.TIPO_PODER,4,'" + poSesion.Usuario.Clave + "',SYSDATE)";

						#endregion
					loSentencia.Tipo = Definiciones.TipoSentencia.NoQuery;
					loSentencia.TipoComando = CommandType.Text;
					loSentencia.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.ContinuarTransaccion;
					loSentencia.TipoResultado = Definiciones.TipoResultado.Entero;
					loSentencias.Add(loSentencia);
				}

				#region Preparar/ejecutar transaccion

				if (loSentencias.Count > 0)
				{

					if (loSentencias.Count > 1)
					{
						loSentencias[0].TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.IniciarTransaccion;
						loSentencias[loSentencias.Count - 1].TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.FinalizarTransaccion;
					}
					else
						loSentencias[0].TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion;

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

		internal ContactoCliente ObtenerContacto(Sesion poSesion, string psClaveCliente)
		{

			try
			{
				ContactoCliente loContacto = new ContactoCliente() {
					Puesto = Telemarketing.Comun.Definiciones.TipoContactoCliente.Compras.Descripcion()
				};List<Sentencia> loSentencias = new List<Sentencia>();
				Sentencia loSentencia = new Sentencia();
				string lsSucursales = string.Empty;

				loSentencia.Parametros = new List<Parametro>() {
						#region Parametros

						new Parametro() {
							Direccion = ParameterDirection.Output,
							Nombre = "PCO_CURSOR",
							Tipo = DbType.Object
						},
						new Parametro() {
							Direccion = ParameterDirection.Input,
							Nombre = "PSI_CVE_CLIENTE",
							Tipo = DbType.String,
							Valor = psClaveCliente
						}

						#endregion
					};
				loSentencia.TextoComando = "PKG_DAP_VENTAS_LAYOUT.PROC_TLMK_CONTACTO";
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

				foreach (DataRow oContacto in loResultado.Rows)
				{
					loContacto.ApellidoPaterno = oContacto["APELLIDO_PATERNO"].ToString().Trim();
					loContacto.Apodo = oContacto["NOMBRE_APODO"].ToString().Trim();
					loContacto.Celular = oContacto["CELULAR"].ToString().Trim();
					loContacto.Clave = int.Parse(oContacto["CLAVE"].ToString());
					loContacto.ClaveCliente = psClaveCliente;
					loContacto.Correo = oContacto["EMAIL"].ToString().Trim();
					loContacto.Nextel = oContacto["RADIO_LOC"].ToString().Trim();
					loContacto.Nombre = oContacto["NOMBRE"].ToString().Trim();
					loContacto.Puesto = oContacto["TIPO"].ToString().Trim();
					loContacto.Telefono = oContacto["TEL_EXT"].ToString().Trim();
				}

				return loContacto;
			}
			catch (Exception ex)
			{
				throw new Comun.Excepcion(ex.Message, ex);
			}
		}

		#endregion
	}
}
