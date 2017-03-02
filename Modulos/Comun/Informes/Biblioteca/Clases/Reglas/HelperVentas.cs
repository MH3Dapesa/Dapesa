using Dapesa.AccesoDatos.Entidades;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.Comun.Utilerias;
using Dapesa.Seguridad.Entidades;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace Dapesa.Comun.Informes.Reglas
{
	internal class HelperVentas
	{
		#region Metodos

		internal DataTable ObtenerAnalisisAnual(Sesion poSesion, string psClaveSucursal, string psClaveVendedor, string psClaveMarca, bool pbMostrarClienteEliminado)
		{

			try
			{
				Sentencia loSentencia = new Sentencia();
				int lnIndicadorFiltros = (int)Informes.Comun.Definiciones.TipoFiltrosReporteClientesConDecremento.Ninguno;

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
						Valor = int.Parse(psClaveSucursal)
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_INDICADOR",
						Tipo = DbType.Int32,
						Valor = lnIndicadorFiltros
					}
					
					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS.PROC_REP_ANALISIS_ANUAL";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

				#region Definir filtros del reporte

				if (!string.IsNullOrEmpty(psClaveVendedor))
				{
					lnIndicadorFiltros = (int)Informes.Comun.Definiciones.TipoFiltrosReporteClientesConDecremento.SoloVendedor;
					loSentencia.Parametros.Add(new Parametro()
					{
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE1",
						Tipo = DbType.Int32,
						Valor = int.Parse(psClaveVendedor)
					});

					if (!string.IsNullOrEmpty(psClaveMarca))
					{
						lnIndicadorFiltros = (int)Informes.Comun.Definiciones.TipoFiltrosReporteClientesConDecremento.Ambos;
						loSentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "PNI_CVE2",
							Tipo = DbType.Int32,
							Valor = int.Parse(psClaveMarca)
						});
					}
				}
				else

					if (!string.IsNullOrEmpty(psClaveMarca))
					{
						lnIndicadorFiltros = (int)Informes.Comun.Definiciones.TipoFiltrosReporteClientesConDecremento.SoloMarca;
						loSentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "PNI_CVE1",
							Tipo = DbType.Int32,
							Valor = int.Parse(psClaveMarca)
						});
					}

				loSentencia.Parametros[2].Valor = lnIndicadorFiltros;

				#endregion

				Planificador loPlanificador = new Planificador();
				DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });
				DataTable dtAuxiliar = loResultado.Clone();
				if (!pbMostrarClienteEliminado)
				{
					DataRow[] query = loResultado.Select("GES_CLAVE < 1000 OR GES_CLAVE>2000");

					foreach (DataRow fila in query)
						dtAuxiliar.Rows.Add(fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6], fila[7], fila[8]);

                    //Agregar Columna de Numero de Fila para controlar el orden interactivo en reportviewer
                    //dtAuxiliar.Columns.Add("NUMERO_DE_FILA",typeof(int));
                    //DataRow loAgregarFila;
                    //loAgregarFila = dtAuxiliar.NewRow();
                    //int loNumeroDeFilas = dtAuxiliar.Rows.Count;
                    //for (int i = 0; i < loNumeroDeFilas; i++)
                    //{

                    //    dtAuxiliar.Rows[i]["NUMERO_DE_FILA"] = i;
                    //}

                    loResultado.Rows.Clear();
					loResultado.Merge(dtAuxiliar);
				}

				return loResultado;
			}
			catch (Exception ex)
			{
				throw new Informes.Comun.Excepcion(ex.Message, ex);
			}
		}

		internal DataTable ObtenerAnalisisAnualMarcas(Sesion poSesion, string psClaveCliente, string psClaveMarca)
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
					}
					
					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS.PROC_REP_ANALISIS_MARCAS";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

				if (!string.IsNullOrEmpty(psClaveMarca))
					loSentencia.Parametros.Add(new Parametro()
					{
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_MARCA",
						Tipo = DbType.Int32,
						Valor = int.Parse(psClaveMarca)
					});

				Planificador loPlanificador = new Planificador();
				DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });

				return loResultado;
			}
			catch (Exception ex)
			{
				throw new Informes.Comun.Excepcion(ex.Message, ex);
			}
		}

		//Revisar
		internal DataTable ObtenerAnalisisAnualLineas(Sesion poSesion, string psClaveCliente, string psClaveMarca)
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
						Nombre = "PNI_CVE_MARCA",
						Tipo = DbType.Int32,
						Valor = psClaveMarca
					}
					
					#endregion
				};


				loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS.PROC_REP_ANALISIS_LINEAS";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

				//if (!string.IsNullOrEmpty(psClaveMarca))
				//    loSentencia.Parametros.Add(new Parametro()
				//    {
				//        Direccion = ParameterDirection.Input,
				//        Nombre = "PNI_CVE_MARCA",
				//        Tipo = DbType.Int32,
				//        Valor = int.Parse(psClaveMarca)
				//    });

				Planificador loPlanificador = new Planificador();
				DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });

				return loResultado;
			}
			catch (Exception ex)
			{
				throw new Informes.Comun.Excepcion(ex.Message, ex);
			}
		}

		internal DataTable ObtenerAnalisisAnualArticulos(Sesion poSesion, string psClaveCliente, string psClaveLinea)
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
						Nombre = "PNI_CVE_LINEA",
						Tipo = DbType.Int32,
						Valor = psClaveLinea
					}
					
					#endregion
				};


				loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS.PROC_REP_ANALISIS_ARTICULOS";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

				//if (!string.IsNullOrEmpty(psClaveMarca))
				//    loSentencia.Parametros.Add(new Parametro()
				//    {
				//        Direccion = ParameterDirection.Input,
				//        Nombre = "PNI_CVE_MARCA",
				//        Tipo = DbType.Int32,
				//        Valor = int.Parse(psClaveMarca)
				//    });

				Planificador loPlanificador = new Planificador();
				DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });

				return loResultado;
			}
			catch (Exception ex)
			{
				throw new Informes.Comun.Excepcion(ex.Message, ex);
			}
		}



		internal Entidades.Cliente ObtenerAnalisisAnualMotivosInac(Sesion poSesion, string psClaveCliente)
		{

			try
			{
				Entidades.Cliente loCliente = new Entidades.Cliente() { FechaInac = DateTime.MinValue };
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
					}
					
					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS.PROC_REP_ANALISIS_MINAC";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

				Planificador loPlanificador = new Planificador();
				DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });

				foreach (DataRow oCliente in loResultado.Rows)
				{
					loCliente.Clave = oCliente["CLAVE"].ToString();
					loCliente.Estatus = oCliente["ESTATUS"].ToString(); ;
					loCliente.Nombre = oCliente["NOMBRE"].ToString(); ;

					if (loCliente.Estatus == Informes.Comun.Definiciones.TipoEstatusCliente.Inactivo.Descripcion())
					{
						loCliente.FechaInac = (DateTime)oCliente["FECHA_INAC"];
						loCliente.MotivosInac = oCliente["MOTIVOS_INAC"].ToString();
					}
				}

				return loCliente;
			}
			catch (Exception ex)
			{
				throw new Informes.Comun.Excepcion(ex.Message, ex);
			}
		}

		internal DataTable ObtenerAsignaciones(Sesion poSesion, string psClaveSucursal, string psClavePersonal, string psEstatus, string psSemaforo)
		{

			try
			{
				Sentencia loSentencia = new Sentencia();
				DateTime loFehaInicio = DateTime.MinValue;
				DateTime loFechaFin = DateTime.MaxValue;

				loSentencia.Parametros = new List<Parametro>() {
					#region Parametros

					new Parametro() {
						Direccion = ParameterDirection.Output,
						Nombre = "PCO_CURSOR",
						Tipo = DbType.Object
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_PERSONAL",
						Tipo = DbType.Int32,
						Valor = (string.IsNullOrEmpty(psClavePersonal)) ? (int?)null : int.Parse(psClavePersonal)
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_ESTATUS_CTE",
						Tipo = DbType.String,
						Valor = psEstatus
					}
					
					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS.PROC_REP_ITINERARIO";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

				#region Determinar el filtro de fechas, en base a la semaforización de ventas

				if (!string.IsNullOrEmpty(psSemaforo) &&
					psSemaforo != Informes.Comun.Definiciones.TipoSemaforoVenta.SinVenta.Descripcion())
				{
					DateTime loFechaAuxiliar = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

					if (psSemaforo == Informes.Comun.Definiciones.TipoSemaforoVenta.MesActual.Descripcion())
					{
						loFehaInicio = loFechaAuxiliar;
						loFechaFin = new DateTime(loFehaInicio.Year, loFehaInicio.Month, DateTime.DaysInMonth(loFehaInicio.Year, loFehaInicio.Month));
					}
					else if (psSemaforo == Informes.Comun.Definiciones.TipoSemaforoVenta.MenorIgual90Dias.Descripcion())
					{
						loFehaInicio = DateTime.Now.AddDays(-90);
						loFechaFin = loFechaAuxiliar.AddDays(-1);
					}
					else if (psSemaforo == Informes.Comun.Definiciones.TipoSemaforoVenta.Mayor90Dias.Descripcion())
						loFechaFin = DateTime.Now.AddDays(-91);
				}

				loSentencia.Parametros.Add(new Parametro()
				{
					Direccion = ParameterDirection.Input,
					Nombre = "PDI_FECHA_INICIO",
					Tipo = DbType.Date,
					Valor = loFehaInicio
				});
				loSentencia.Parametros.Add(new Parametro()
				{
					Direccion = ParameterDirection.Input,
					Nombre = "PDI_FECHA_FIN",
					Tipo = DbType.Date,
					Valor = loFechaFin
				});
				loSentencia.Parametros.Add(new Parametro()
				{
					Direccion = ParameterDirection.Input,
					Nombre = "PNI_INCLUIR_FECHAS_NULAS",
					Tipo = DbType.Int32,
					Valor = (string.IsNullOrEmpty(psSemaforo) ||
						psSemaforo == Informes.Comun.Definiciones.TipoSemaforoVenta.SinVenta.Descripcion()
					) ? 1 : 0
				});
				loSentencia.Parametros.Add(new Parametro()
				{
					Direccion = ParameterDirection.Input,
					Nombre = "PNI_INCLUIR_RANGO_FECHAS",
					Tipo = DbType.Int32,
					Valor = (psSemaforo != Informes.Comun.Definiciones.TipoSemaforoVenta.SinVenta.Descripcion()) ? 1 : 0
				});

				#endregion

				if (string.IsNullOrEmpty(psClaveSucursal))
				{
					string lsSucursales = string.Empty;

					foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
						lsSucursales += oSucursal.Clave + ",";

					if (lsSucursales != string.Empty)
						loSentencia.Parametros.Add(new Parametro()
						{
							Direccion = ParameterDirection.Input,
							Nombre = "PNI_CVES_SUCURSALES",
							Tipo = DbType.String,
							Valor = lsSucursales.TrimEnd(',')
						});
				}
				else
					loSentencia.Parametros.Add(new Parametro()
					{
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVES_SUCURSALES",
						Tipo = DbType.String,
						Valor = psClaveSucursal
					});

				Planificador loPlanificador = new Planificador();
				DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });

				return loResultado;
			}
			catch (Exception ex)
			{
				throw new Informes.Comun.Excepcion(ex.Message, ex);
			}
		}

		//agregado
		internal DataTable ObtenerVentasPorDias(Sesion poSesion, DateTime poFechaInicial, DateTime poFechaFinal, int piCantidadDias, string psClaveSucursal, string psClaveVendedor, string psClavesComodines, bool pbMostrarClienteEliminado, bool pbMostrarClienteCeroPedidos)
		{

			try
			{
				Sentencia loSentencia = new Sentencia();
				int lnIndicadorFiltros = (int)Informes.Comun.Definiciones.TipoFiltrosReporteVentasPorDias.Ninguno;

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
						Tipo = DbType.String,
						Valor = poFechaInicial.ToString("dd/MM/yyyy")
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_FIN",
						Tipo = DbType.String,
						Valor = poFechaFinal.ToString("dd/MM/yyyy")
					},                 
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CANTIDAD_DIAS",
						Tipo = DbType.Int32,
						Valor = piCantidadDias
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = psClaveSucursal
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_INDICADOR",
						Tipo = DbType.Int32,
						Valor = lnIndicadorFiltros
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE1",
						Tipo = DbType.Int32,
						Valor = int.Parse(psClaveVendedor)
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSO_CVE2",
						Tipo = DbType.String,
						Valor = psClavesComodines
					}
					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS.PROC_REP_DIAS_CON_PEDIDOS";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

				#region Definir filtros del reporte

				if (!string.IsNullOrEmpty(psClaveVendedor) && psClaveVendedor != "0")
				{
					lnIndicadorFiltros = (int)Informes.Comun.Definiciones.TipoFiltrosReporteVentasPorDias.Ambos;

					//if (!string.IsNullOrEmpty(psClaveCliente))
					//{
					//    lnIndicadorFiltros = (int)Informes.Comun.Definiciones.TipoFiltrosReporteVentasPorDias.Ambos;
					//}
				}
				else
				{
					//if (!string.IsNullOrEmpty(psClaveCliente))
					//{
					//    lnIndicadorFiltros = (int)Informes.Comun.Definiciones.TipoFiltrosReporteVentasPorDias.SoloCliente;
					//}
				}
				loSentencia.Parametros[5].Valor = lnIndicadorFiltros;

				#endregion

				Planificador loPlanificador = new Planificador();
				DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });
				DataTable dtAuxiliar = loResultado.Clone();


				if (!pbMostrarClienteEliminado && !pbMostrarClienteCeroPedidos)
				{
					DataRow[] loQueryGesClave = loResultado.Select("(GES_CLAVE < 1000 OR GES_CLAVE>2000) AND TDIAS > 0");

					foreach (DataRow loFila in loQueryGesClave)
						dtAuxiliar.Rows.Add(loFila[0], loFila[1], loFila[2], loFila[3], loFila[4], loFila[5], loFila[6], loFila[7]);
					loResultado.Rows.Clear();
					loResultado.Merge(dtAuxiliar);
				}
				if (!pbMostrarClienteEliminado && pbMostrarClienteCeroPedidos )
				{
					DataRow[] loQueryGesClave = loResultado.Select("(GES_CLAVE < 1000 OR GES_CLAVE>2000)");

					foreach (DataRow loFila in loQueryGesClave)
						dtAuxiliar.Rows.Add(loFila[0], loFila[1], loFila[2], loFila[3], loFila[4], loFila[5], loFila[6], loFila[7]);
					loResultado.Rows.Clear();
					loResultado.Merge(dtAuxiliar);
				}
				if (pbMostrarClienteEliminado && !pbMostrarClienteCeroPedidos)
				{
					DataRow[] loQueryGesClave = loResultado.Select("TDIAS > 0");

					foreach (DataRow loFila in loQueryGesClave)
						dtAuxiliar.Rows.Add(loFila[0], loFila[1], loFila[2], loFila[3], loFila[4], loFila[5], loFila[6], loFila[7]);
					loResultado.Rows.Clear();
					loResultado.Merge(dtAuxiliar);
				}


				return loResultado;
			}
			catch (Exception ex)
			{
				throw new Informes.Comun.Excepcion(ex.Message, ex);
			}
		}

		internal DataTable ObtenerVentasPorDiasDetalle(Sesion poSesion, string psClaveCliente, int piClaveSucursal, DateTime poFechaInicial, DateTime poFechaFinal, int piClaveVendedor, string psClavesComodines)
		{

			try
			{
				Sentencia loSentencia = new Sentencia();
				int lnIndicadorFiltros = (int)Informes.Comun.Definiciones.TipoFiltrosReporteVentasPorDias.Ninguno;

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
						Valor = piClaveSucursal
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_INICIO",
						Tipo = DbType.String,
						Valor = poFechaInicial.ToString("dd/MM/yyyy")
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_FIN",
						Tipo = DbType.String,
						Valor = poFechaFinal.ToString("dd/MM/yyyy")
					},                 
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_INDICADOR",
						Tipo = DbType.Int32,
						Valor = lnIndicadorFiltros
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE1",
						Tipo = DbType.Int32,
						Valor = piClaveVendedor
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSO_CVE2",
						Tipo = DbType.String,
						Valor = psClavesComodines
					}
					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS.PROC_CAT_IMPORTE_PEDIDOS_DIAS";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

				#region Definir filtros del reporte

				if (piClaveVendedor != 0)
				{
					lnIndicadorFiltros = (int)Informes.Comun.Definiciones.TipoFiltrosReporteVentasPorDias.Ambos;
				}
				//else
				//{
				//    //if (!string.IsNullOrEmpty(psClaveCliente))
				//    //{
				//    //    lnIndicadorFiltros = (int)Informes.Comun.Definiciones.TipoFiltrosReporteVentasPorDias.SoloCliente;
				//    //}
				//}
				loSentencia.Parametros[5].Valor = lnIndicadorFiltros;

				#endregion

				Planificador loPlanificador = new Planificador();
				DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });
				DataTable dtAuxiliar = loResultado.Clone();           

				return loResultado;
			}
			catch (Exception ex)
			{
				throw new Informes.Comun.Excepcion(ex.Message, ex);
			}
		}

		internal DataTable ObtenerFolioPedidosDias(Sesion poSesion, string psClaveCliente, int piClaveSucursal, DateTime poFechaInicial, int piClaveVendedor, string psClavesComodines)
		{

			try
			{
				Sentencia loSentencia = new Sentencia();
				int lnIndicadorFiltros = (int)Informes.Comun.Definiciones.TipoFiltrosReporteVentasPorDias.Ninguno;

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
						Valor = piClaveSucursal
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_INICIO",
						Tipo = DbType.String,
						Valor = poFechaInicial.ToString("dd/MM/yyyy")
					},          
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_INDICADOR",
						Tipo = DbType.Int32,
						Valor = lnIndicadorFiltros
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE1",
						Tipo = DbType.Int32,
						Valor = piClaveVendedor
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSO_CVE2",
						Tipo = DbType.String,
						Valor = psClavesComodines
					}
					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS.PROC_CAT_FOLIOS_PEDIDOS_DIAS";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

				#region Definir filtros del reporte

				if (piClaveVendedor != 0)
				{
					lnIndicadorFiltros = (int)Informes.Comun.Definiciones.TipoFiltrosReporteVentasPorDias.Ambos;
				}
				//else
				//{
				//    //if (!string.IsNullOrEmpty(psClaveCliente))
				//    //{
				//    //    lnIndicadorFiltros = (int)Informes.Comun.Definiciones.TipoFiltrosReporteVentasPorDias.SoloCliente;
				//    //}
				//}
				loSentencia.Parametros[4].Valor = lnIndicadorFiltros;

				#endregion

				Planificador loPlanificador = new Planificador();
				DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });
				DataTable dtAuxiliar = loResultado.Clone();

				return loResultado;
			}
			catch (Exception ex)
			{
				throw new Informes.Comun.Excepcion(ex.Message, ex);
			}
		}

		internal DataTable ObtenerArticulosPedidosDias(Sesion poSesion, string psClaveCliente, int piClaveSucursal, DateTime poFechaInicial, string psFolio, int piNumero, int piClaveVendedor, string psClavesComodines)
		{

			try
			{
				Sentencia loSentencia = new Sentencia();
				int lnIndicadorFiltros = (int)Informes.Comun.Definiciones.TipoFiltrosReporteVentasPorDias.Ninguno;

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
						Valor = piClaveSucursal
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PDI_FECHA_INICIO",
						Tipo = DbType.String,
						Valor = poFechaInicial.ToString("dd/MM/yyyy")
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSI_FOLPED_FOLIO",
						Tipo = DbType.String,
						Valor = psFolio
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_PED_NUMERO",
						Tipo = DbType.Int32,
						Valor = piNumero
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_INDICADOR",
						Tipo = DbType.Int32,
						Valor = lnIndicadorFiltros
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE1",
						Tipo = DbType.Int32,
						Valor = piClaveVendedor
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PSO_CVE2",
						Tipo = DbType.String,
						Valor = psClavesComodines
					}
					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_INFORMES_VENTAS.PROC_REP_PEDIDOS_ARTICULOS";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

				#region Definir filtros del reporte

				if (piClaveVendedor != 0)
				{
					lnIndicadorFiltros = (int)Informes.Comun.Definiciones.TipoFiltrosReporteVentasPorDias.Ambos;
				}
				//else
				//{
				//    //if (!string.IsNullOrEmpty(psClaveCliente))
				//    //{
				//    //    lnIndicadorFiltros = (int)Informes.Comun.Definiciones.TipoFiltrosReporteVentasPorDias.SoloCliente;
				//    //}
				//}
				loSentencia.Parametros[6].Valor = lnIndicadorFiltros;

				#endregion

				Planificador loPlanificador = new Planificador();
				DataTable loResultado = (DataTable)loPlanificador.Servir(poSesion.Conexion, new List<Sentencia>() { loSentencia });
				DataTable dtAuxiliar = loResultado.Clone();

				return loResultado;
			}
			catch (Exception ex)
			{
				throw new Informes.Comun.Excepcion(ex.Message, ex);
			}
		}


		#endregion
	}
}
