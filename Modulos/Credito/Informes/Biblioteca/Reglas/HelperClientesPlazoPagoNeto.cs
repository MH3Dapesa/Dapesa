using Dapesa.AccesoDatos.Comun;
using Dapesa.AccesoDatos.Entidades;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dapesa.Credito.Informes.Reglas
{
    internal class HelperClientesPlazoPagoNeto
    {
        #region Metodos

        internal DataTable Obtener(Sesion poSesion, string psClienteID, DateTime poFechaInicio, DateTime poFechaFin)
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
                loSentencia.TextoComando = "PKG_DAP_CREDITO_FACTURAS.PROC_NO_PARTE";
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
