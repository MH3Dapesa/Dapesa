using Dapesa.AccesoDatos.Entidades;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.AccesoDatos.Comun;
using Dapesa.Seguridad.Entidades;
using Dapesa.Credito.Clientes.Cartera.Comun;
using System;
using System.Collections.Generic;
using System.Data;

namespace Credito.Clientes.Cartera.Reglas
{
    internal class HelperAnalisisCliente
    {
        #region Metodos

        internal DataTable ObtenerVentaCliente(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psClaveCliente)
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
					},
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
						Nombre = "PSI_CVE_CLIENTE",
						Tipo = DbType.String,
						Valor = psClaveCliente
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = poSesion.Usuario.Sucursal[0].Clave
					}

					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_MONITOREO.PROC_CTE_CREDITO";
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
                throw new Dapesa.Credito.Clientes.Cartera.Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerClienteEncabezado(Sesion poSesion,string psClaveCliente)
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
					},				        
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
					}

					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_MONITOREO.PROC_CTE_CREDITO_ENCABEZADO";
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
                throw new Dapesa.Credito.Clientes.Cartera.Comun.Excepcion(ex.Message, ex);
            }
        }
        
        #endregion
    }
}

