using Dapesa.AccesoDatos.Entidades;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dapesa.Comun.Informes.General.Reglas
{
     internal class HelperDatosClientes
    {
        #region Metodos
            internal DataTable ObtenerClientes(Sesion poSesion, int psClaveSucursal, string psClaveVendedor, string psCliente)
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
						Nombre = "PNI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = psClaveSucursal
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_VENDEDOR",
						Tipo = DbType.Int32,
						Valor = psClaveVendedor
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_CLIENTE",
						Tipo = DbType.String,
						Valor = psCliente
					}
					
					#endregion
				};
                    loSentencia.TextoComando = "PKG_DAP_MONITOREO.PROC_CTE_TRAJES_MEDIDAS";
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
                    throw new Comun.Excepcion(ex.Message, ex);
                }
            }
        #endregion
    }
}
