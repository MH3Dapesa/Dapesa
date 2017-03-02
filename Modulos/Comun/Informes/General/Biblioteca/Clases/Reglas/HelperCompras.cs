using Dapesa.AccesoDatos.Entidades;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.Comun.Utilerias;
using Dapesa.Seguridad.Entidades;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace Dapesa.Comun.Informes.General.Reglas
{
    internal class HelperCompras
    {
        internal DataTable obtenerVentasResumenPorMarca(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal)
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
						Tipo = DbType.DateTime,
						Valor = poFechaInicio
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_FIN",
						Tipo = DbType.DateTime,
						Valor = poFechaFin
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = psSucursal
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_COMPRAS.PROC_REP_VENTAS_RESUMEN_MARCA";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                
                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });

                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Informes.General.Comun.Excepcion(ex.Message, ex);
            }
        }
    }
}
