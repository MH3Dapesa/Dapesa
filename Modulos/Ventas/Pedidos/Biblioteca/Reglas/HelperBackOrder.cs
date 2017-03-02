using Dapesa.AccesoDatos.Comun;
using Dapesa.AccesoDatos.Entidades;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ventas.Pedidos.BackOrder.Reglas
{
   internal class HelperBackOrder
    {
       internal DataTable ObtenerBackOrderPedidos(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, int pnSucursal, int? pnClaveVendedor, string psClaveCliente, int? pnPedidoNumero, string psPedidoFolio, string psArticuloClave, int? pnLineaClave, int? pnMarcaClave, int pnMostrarArticulos)
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
                        Nombre = "PNI_CVE_SUCURSAL",
                        Tipo = DbType.Int32,
                        Valor = pnSucursal
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_CVE_VENDEDOR",
                        Tipo = DbType.Int32,
                        Valor = pnClaveVendedor
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PSI_CVE_CLIENTE",
                        Tipo = DbType.String,
                        Valor = psClaveCliente
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_PED_NUMERO",
                        Tipo = DbType.Int32,
                        Valor = pnPedidoNumero
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PSI_PED_FOLPED_FOLIO",
                        Tipo = DbType.String,
                        Valor = psPedidoFolio
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PSI_ART_CLAVE",
                        Tipo = DbType.String,
                        Valor = psArticuloClave
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_LIN_ART_CLAVE",
                        Tipo = DbType.Int32,
                        Valor = pnLineaClave
                    },
                    new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PNI_MCA_CLAVE",
                        Tipo = DbType.Int32,
                        Valor = pnMarcaClave
                    }
					#endregion
				};

                loSentencia.TextoComando = "PKG_DAP_MONITOREO.PROC_BACKORDER_PEDIDOS";
                loSentencia.Tipo = Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = Definiciones.TipoResultado.Conjunto;

                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });
                

                if(pnMostrarArticulos != (int)Comun.Definiciones.MostrarArticulos.Todos)
                {
                    DataTable dtAuxiliar = loResultado.Clone();
                    if(pnMostrarArticulos == (int)Comun.Definiciones.MostrarArticulos.ConExistencia)
                    {
                        DataRow[] loQueryGesClave = loResultado.Select("EXISTENCIA > 0");
                        foreach (DataRow loFila in loQueryGesClave)
                            dtAuxiliar.Rows.Add(loFila[0], loFila[1], loFila[2], loFila[3], loFila[4], loFila[5], loFila[6], loFila[7], loFila[8], loFila[9], loFila[10], loFila[11], loFila[12], loFila[13]);
                    }
                    else if (pnMostrarArticulos == (int)Comun.Definiciones.MostrarArticulos.SinExistencia)
                    {
                        DataRow[] loQueryGesClave = loResultado.Select("EXISTENCIA <= 0");
                        foreach (DataRow loFila in loQueryGesClave)
                            dtAuxiliar.Rows.Add(loFila[0], loFila[1], loFila[2], loFila[3], loFila[4], loFila[5], loFila[6], loFila[7], loFila[8], loFila[9], loFila[10], loFila[11], loFila[12], loFila[13]);
                    }
                    loResultado.Rows.Clear();
                    loResultado.Merge(dtAuxiliar);
                }

                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }
    }
}
