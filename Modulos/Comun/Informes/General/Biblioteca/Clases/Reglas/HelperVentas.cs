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
    internal class HelperVentas
    {
        #region Metodos

        internal DataTable AnalisisVendedores(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal, string psCveVendedor, string psCveCliente, string psCveMarca, string psCveLinea, string psCveArticulo, string pnCveFiltroMonto, int pnFiltroMonto)
        {
            try
            {
                int? lnValorNull = null;
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
						Nombre = "PSI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = ((psSucursal == string.Empty)?lnValorNull:int.Parse(psSucursal))
					},
                     new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_VENDEDOR",
						Tipo = DbType.Int32,
						Valor = ((psCveVendedor == string.Empty)?lnValorNull:int.Parse(psCveVendedor))
					},
                     new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_CLIENTE",
						Tipo = DbType.String,
						Valor = psCveCliente
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_MARCA",
						Tipo = DbType.Int32,
						Valor = ((psCveMarca == string.Empty)?lnValorNull:int.Parse(psCveMarca))
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_LINEA",
						Tipo = DbType.Int32,
						Valor = ((psCveLinea == string.Empty)?lnValorNull:int.Parse(psCveLinea))
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_ARTICULO",
						Tipo = DbType.String,
						Valor = psCveArticulo
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_FILTRO_MONTO",
						Tipo = DbType.String,
						Valor = pnCveFiltroMonto
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_FILTRO_MONTO",
						Tipo = DbType.Int32,
						Valor = pnFiltroMonto
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS.PROC_REP_ANALISIS_VENDEDOR";
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

        internal DataTable AnalisisGestor(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal, string psCveVendedor, string psCveCliente, string psCveMarca, string psCveLinea, string psCveArticulo, string pnCveFiltroMonto, int pnFiltroMonto)
        {
            try
            {
                int? lnValorNull = null;
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
						Nombre = "PSI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = ((psSucursal == string.Empty)?lnValorNull:int.Parse(psSucursal))
					},
                     new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_VENDEDOR",
						Tipo = DbType.Int32,
						Valor = ((psCveVendedor == string.Empty)?lnValorNull:int.Parse(psCveVendedor))
					},
                     new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_CLIENTE",
						Tipo = DbType.String,
						Valor = psCveCliente
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_MARCA",
						Tipo = DbType.Int32,
						Valor = ((psCveMarca == string.Empty)?lnValorNull:int.Parse(psCveMarca))
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_LINEA",
						Tipo = DbType.Int32,
						Valor = ((psCveLinea == string.Empty)?lnValorNull:int.Parse(psCveLinea))
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_ARTICULO",
						Tipo = DbType.String,
						Valor = psCveArticulo
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_FILTRO_MONTO",
						Tipo = DbType.String,
						Valor = pnCveFiltroMonto
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_FILTRO_MONTO",
						Tipo = DbType.Int32,
						Valor = pnFiltroMonto
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS.PROC_REP_ANALISIS_GESTOR";
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

        internal DataTable AnalisisCliente(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal, string psCveVendedor, string psCveCliente, string psCveMarca, string psCveLinea, string psCveArticulo, string pnCveFiltroMonto, int pnFiltroMonto)
        {
            try
            {
                int? lnValorNull = null;
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
						Nombre = "PSI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = ((psSucursal == string.Empty)?lnValorNull:int.Parse(psSucursal))
					},
                     new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_VENDEDOR",
						Tipo = DbType.Int32,
						Valor = ((psCveVendedor == string.Empty)?lnValorNull:int.Parse(psCveVendedor))
					},
                     new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_CLIENTE",
						Tipo = DbType.String,
						Valor = psCveCliente
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_MARCA",
						Tipo = DbType.Int32,
						Valor = ((psCveMarca == string.Empty)?lnValorNull:int.Parse(psCveMarca))
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_LINEA",
						Tipo = DbType.Int32,
						Valor = ((psCveLinea == string.Empty)?lnValorNull:int.Parse(psCveLinea))
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_ARTICULO",
						Tipo = DbType.String,
						Valor = psCveArticulo
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_FILTRO_MONTO",
						Tipo = DbType.String,
						Valor = pnCveFiltroMonto
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_FILTRO_MONTO",
						Tipo = DbType.Int32,
						Valor = pnFiltroMonto
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS.PROC_REP_ANALISIS_CLIENTE";
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

        internal DataTable VentasMarcaLinea(Sesion poSesion, string psSucursal, DateTime poFechaInicio, DateTime poFechaFin, string psCveMarca, string psCveLinea, string psCveArticulos, bool poMostrarLineasSinVenta)
        {
            try
            {
                if (string.IsNullOrEmpty(psSucursal))
                {
                    foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
                        psSucursal += oSucursal.Clave + ",";
                }


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
						Nombre = "PSI_CVE_SUCURSAL",
						Tipo = DbType.String,
						Valor = psSucursal.TrimEnd(',')
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_INICIO",
						Tipo = DbType.String,
						Valor = poFechaInicio.ToShortDateString().ToString()
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_FIN",
						Tipo = DbType.String,
						Valor = poFechaFin.ToShortDateString().ToString()
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_MARCA",
						Tipo = DbType.String,
						Valor = ((string.IsNullOrEmpty(psCveMarca)) ? "NULL" : psCveMarca)
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_LINEA",
						Tipo = DbType.String,
						Valor = ((string.IsNullOrEmpty(psCveLinea)) ? "NULL" : psCveLinea)
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_ARTICULO",
						Tipo = DbType.String,
						Valor = ((string.IsNullOrEmpty(psCveArticulos)) ? "NULL" : "'" + psCveArticulos + "'")
					}
					#endregion
				};


                loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS.PROC_REP_VENTAS_MARCA_LINEA";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });
                DataTable dtAuxiliar = loResultado.Clone();


                if (!poMostrarLineasSinVenta)
                {
                    DataRow[] loQueryGesClave = loResultado.Select("IMPORTE <> 0 ");

                    foreach (DataRow loFila in loQueryGesClave)
                        dtAuxiliar.Rows.Add(loFila[0], loFila[1], loFila[2], loFila[3], loFila[4], loFila[5], loFila[6], loFila[7]);
                    loResultado.Rows.Clear();
                    dtAuxiliar.DefaultView.Sort = "LINEA ASC, MARCA ASC, MES ASC, ANIO ASC";
                    dtAuxiliar = dtAuxiliar.DefaultView.ToTable();
                    loResultado.Merge(dtAuxiliar);
                }

                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable AnalisisVentasPorPoblacion(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal, string psCveVendedor, string psCveCliente, string psCveMarca, string psCveLinea, string psCveArticulo)
        {
            try
            {
                int? lnValorNull = null;
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
						Nombre = "PSI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = ((psSucursal == string.Empty)?lnValorNull:int.Parse(psSucursal))
					},
                     new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_VENDEDOR",
						Tipo = DbType.Int32,
						Valor = ((psCveVendedor == string.Empty)?lnValorNull:int.Parse(psCveVendedor))
					},
                     new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_CLIENTE",
						Tipo = DbType.String,
						Valor = psCveCliente
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_MARCA",
						Tipo = DbType.String,
                        Valor = psCveMarca 
					    //Valor = psCveMarca 
                    },
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_LINEA",
						Tipo = DbType.String,
                        //Valor = psCveLinea 
                        Valor = psCveLinea
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_ARTICULO",
						Tipo = DbType.String,
						Valor = psCveArticulo
					}
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS.PROC_REP_VENTAS_POR_POBLACION";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });

                for (int lnColumna = 6; lnColumna < loResultado.Columns.Count; lnColumna++)
                {
                    for (int lnFila = 0; lnFila < loResultado.Rows.Count; lnFila++)
                    {
                        if (loResultado.Rows[lnFila][lnColumna].ToString() == string.Empty)
                            loResultado.Rows[lnFila][lnColumna] = 0;
                    }
                }
                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable AnalisisVendedorIdeal(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal, string psCveVendedor)
        {
            try
            {
                int? lnValorNull = null;
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
						Nombre = "PSI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = ((psSucursal == string.Empty)?lnValorNull:int.Parse(psSucursal))
					},
                     new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_VENDEDOR",
						Tipo = DbType.Int32,
						Valor = ((psCveVendedor == string.Empty)?lnValorNull:int.Parse(psCveVendedor))
					}
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS.PROC_REP_VENDEDOR_IDEAL";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });

                for (int lnColumna = 3; lnColumna < loResultado.Columns.Count; lnColumna++)
                {
                    for (int lnFila = 0; lnFila < loResultado.Rows.Count; lnFila++)
                    {
                        if (loResultado.Rows[lnFila][lnColumna].ToString() == string.Empty)
                            loResultado.Rows[lnFila][lnColumna] = 0;
                    }
                }
                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerItineario(Sesion poSesion, int pnClaveTLMK, int pnSucursal, int pnAnio, int pnSemana)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
                Sentencia loSentencia = new Sentencia();

                loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_PERSONAL",
						Tipo = DbType.Int32,
						Valor = pnClaveTLMK
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_USR_PERSONAL",
						Tipo = DbType.String,
						Valor = ObtenerUsuarioTLMK(poSesion, pnClaveTLMK)
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = pnSucursal
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_ANIO",
						Tipo = DbType.Int32,
						Valor = pnAnio
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_SEMANA",
						Tipo = DbType.Int32,
						Valor = pnSemana
					},
					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					}

					#endregion
				};

                loSentencia.TextoComando = "PKG_DAP_VENTAS.PROC_TLMK_ITINERARIO";
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

        internal DataTable ObtenerTotalSemanal(Sesion poSesion, int pnClaveTLMK, DateTime poFechaSemanaActual, DateTime poFechaSemanaAnterior)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
                Sentencia loSentencia = new Sentencia();

                loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_USR_PERSONAL",
						Tipo = DbType.String,
						Valor = ObtenerUsuarioTLMK(poSesion, pnClaveTLMK)
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_SEMANA_ACTUAL",
						Tipo = DbType.Date,
						Valor = poFechaSemanaActual
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_SEMANA_ANTERIOR",
						Tipo = DbType.Date,
						Valor = poFechaSemanaAnterior
					},
					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					}

					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_VENTAS.PROC_TLMK_TOTALxSEMANA";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });
                loResultado.Rows[0][0] = "TOTAL (PEDIDO)";
                loResultado.Rows[1][0] = "TOTAL (FACTURADO)";
                loResultado.Rows[2][0] = "SEMANA ANTERIOR (PEDIDO)";

                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal string ObtenerUsuarioTLMK(Sesion poSesion, int pnClaveTLMK)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
                Sentencia loSentencia = new Sentencia();

                loSentencia.TextoComando = "SELECT USR_CLAVE FROM PERSONAL WHERE CLAVE = " + pnClaveTLMK.ToString() + " ";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.Text;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                loSentencias.Add(loSentencia);

                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });

                return ((loResultado.Rows.Count == 0) ? "" : (loResultado.Rows[0][0].ToString()));
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerVtaMarcaGeo(Sesion poSesion, int pnSucursal, DateTime poFechaInicial, DateTime poFechaFinal)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
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
						Valor = pnSucursal
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_INICIO",
						Tipo = DbType.Date,
						Valor = poFechaInicial
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_FIN",
						Tipo = DbType.Date,
						Valor = poFechaFinal
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_MONITOREO.PROC_MAX_VTA_MCA_GEO";
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

        internal DataTable ObtenerListaPrecios(Sesion poSesion, int pnCveListaPrecios, int pnAlmacen, string psCveMarca, string psCveLinea)
        {
            try
            {
                List<Sentencia> loSentencias = new List<Sentencia>();
                Sentencia loSentencia = new Sentencia();
                int? lnValorNull = null;

                loSentencia.Parametros = new List<Parametro>() {
					#region Parametros
                    new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
                    },
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_L_PRECIOS",
						Tipo = DbType.Int32,
						Valor = pnCveListaPrecios
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_ALMACEN",
						Tipo = DbType.Int32,
						Valor = pnAlmacen
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_MARCA",
						Tipo = DbType.Int32,
						Valor = ((psCveMarca == string.Empty)?lnValorNull:int.Parse(psCveMarca))
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_LINEA",
						Tipo = DbType.Int32,
						Valor = ((psCveLinea == string.Empty)?lnValorNull:int.Parse(psCveLinea))
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS.PROC_REP_LISTA_PRECIOS";
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

        internal DataTable AnalisisVentaVendedor(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal, string psCveVendedor, string psCveCliente, string psCveMarca, string psCveLinea, string psCveArticulo, string pnCveFiltroMonto, int pnFiltroMonto, string pnCveFiltroPiezas, int pnFiltroPiezas)
        {
            try
            {
                int? lnValorNull = null;
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
						Nombre = "PSI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = ((psSucursal == string.Empty)?lnValorNull:int.Parse(psSucursal))
					},
                     new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_VENDEDOR",
						Tipo = DbType.Int32,
						Valor = ((psCveVendedor == string.Empty)?lnValorNull:int.Parse(psCveVendedor))
					},
                     new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_CLIENTE",
						Tipo = DbType.String,
						Valor = psCveCliente
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_MARCA",
						Tipo = DbType.Int32,
						Valor = ((psCveMarca == string.Empty)?lnValorNull:int.Parse(psCveMarca))
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_LINEA",
						Tipo = DbType.Int32,
						Valor = ((psCveLinea == string.Empty)?lnValorNull:int.Parse(psCveLinea))
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_ARTICULO",
						Tipo = DbType.String,
						Valor = psCveArticulo
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_FILTRO_MONTO",
						Tipo = DbType.String,
						Valor = pnCveFiltroMonto
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_FILTRO_MONTO",
						Tipo = DbType.Int32,
						Valor = pnFiltroMonto
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_FILTRO_PIEZAS",
						Tipo = DbType.String,
						Valor = pnCveFiltroPiezas
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_FILTRO_PIEZAS",
						Tipo = DbType.Int32,
						Valor = pnFiltroPiezas
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS_2.PROC_REP_ANALISIS_VENTA_VEND";
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

        internal DataTable AnalisisVentaCliente(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal, string psCveVendedor, string psCveCliente, string psCveMarca, string psCveLinea, string psCveArticulo, string pnCveFiltroMonto, int pnFiltroMonto, string pnCveFiltroPiezas, int pnFiltroPiezas)
        {
            try
            {
                string lsSucursales = psSucursal;
                int? lnValorNull = null;

                if (psSucursal == string.Empty)
                    foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
                        lsSucursales += oSucursal.Clave + ",";

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
						Nombre = "PSI_CVES_SUCURSALES",
						Tipo = DbType.String,
						Valor = lsSucursales.TrimEnd(',')
					},
                     new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_VENDEDOR",
						Tipo = DbType.Int32,
						Valor = ((psCveVendedor == string.Empty)?lnValorNull:int.Parse(psCveVendedor))
					},
                     new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_CLIENTE",
						Tipo = DbType.String,
						Valor = psCveCliente
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_MARCA",
						Tipo = DbType.Int32,
						Valor = ((psCveMarca == string.Empty)?lnValorNull:int.Parse(psCveMarca))
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_LINEA",
						Tipo = DbType.Int32,
						Valor = ((psCveLinea == string.Empty)?lnValorNull:int.Parse(psCveLinea))
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_ARTICULO",
						Tipo = DbType.String,
						Valor = psCveArticulo
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_FILTRO_MONTO",
						Tipo = DbType.String,
						Valor = pnCveFiltroMonto
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_FILTRO_MONTO",
						Tipo = DbType.Int32,
						Valor = pnFiltroMonto
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_FILTRO_PIEZAS",
						Tipo = DbType.String,
						Valor = pnCveFiltroPiezas
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_FILTRO_PIEZAS",
						Tipo = DbType.Int32,
						Valor = pnFiltroPiezas
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS_2.PROC_REP_ANALISIS_VENTA_CLI";
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

                loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS_2.PROC_REP_BACKORDER_PEDIDOS";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;
                Planificador loPlanificador = new Planificador();
                DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });


                if (pnMostrarArticulos != (int)Comun.Definiciones.MostrarArticulos.Todos)
                {
                    DataTable dtAuxiliar = loResultado.Clone();
                    if (pnMostrarArticulos == (int)Comun.Definiciones.MostrarArticulos.ConExistencia)
                    {
                        DataRow[] loQueryGesClave = loResultado.Select("EXISTENCIA > 0");
                        foreach (DataRow loFila in loQueryGesClave)
                            dtAuxiliar.Rows.Add(loFila[0], loFila[1], loFila[2], loFila[3], loFila[4], loFila[5], loFila[6], loFila[7], loFila[8], loFila[9], loFila[10], loFila[11], loFila[12], loFila[13], loFila[14]);
                    }
                    else if (pnMostrarArticulos == (int)Comun.Definiciones.MostrarArticulos.SinExistencia)
                    {
                        DataRow[] loQueryGesClave = loResultado.Select("EXISTENCIA <= 0");
                        foreach (DataRow loFila in loQueryGesClave)
                            dtAuxiliar.Rows.Add(loFila[0], loFila[1], loFila[2], loFila[3], loFila[4], loFila[5], loFila[6], loFila[7], loFila[8], loFila[9], loFila[10], loFila[11], loFila[12], loFila[13], loFila[14]);
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

        internal DataTable AnalisisVentaVendedor2(Sesion poSesion, DateTime poFechaInicio, DateTime poFechaFin, string psSucursal, string psCveVendedor, string psCveCliente, string psCveMarca, string psCveLinea, string psCveArticulo, string pnCveFiltroMonto, int pnFiltroMonto, string pnCveFiltroPiezas, int pnFiltroPiezas)
        {
            try
            {
                string lsSucursales = psSucursal;
                int? lnValorNull = null;

                if (psSucursal == string.Empty)
                    foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
                        lsSucursales += oSucursal.Clave + ",";

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
						Nombre = "PSI_CVES_SUCURSALES",
						Tipo = DbType.String,
						Valor = lsSucursales.TrimEnd(',')
					},
                     new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_VENDEDOR",
						Tipo = DbType.Int32,
						Valor = ((psCveVendedor == string.Empty)?lnValorNull:int.Parse(psCveVendedor))
					},
                     new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_CLIENTE",
						Tipo = DbType.String,
						Valor = psCveCliente
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_MARCA",
						Tipo = DbType.Int32,
						Valor = ((psCveMarca == string.Empty)?lnValorNull:int.Parse(psCveMarca))
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_LINEA",
						Tipo = DbType.Int32,
						Valor = ((psCveLinea == string.Empty)?lnValorNull:int.Parse(psCveLinea))
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_CVE_ARTICULO",
						Tipo = DbType.String,
						Valor = psCveArticulo
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_FILTRO_MONTO",
						Tipo = DbType.String,
						Valor = pnCveFiltroMonto
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_FILTRO_MONTO",
						Tipo = DbType.Int32,
						Valor = pnFiltroMonto
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_FILTRO_PIEZAS",
						Tipo = DbType.String,
						Valor = pnCveFiltroPiezas
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_FILTRO_PIEZAS",
						Tipo = DbType.Int32,
						Valor = pnFiltroPiezas
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS_2.PROC_REP_ANALISIS_VENTA_VEND2";
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
