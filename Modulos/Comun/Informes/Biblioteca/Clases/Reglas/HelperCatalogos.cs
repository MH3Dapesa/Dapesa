using Dapesa.AccesoDatos.Entidades;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dapesa.Comun.Informes.Reglas
{
	internal class HelperCatalogos
	{
		#region Metodos

		internal DataTable ObtenerMarcas(Sesion poSesion, int pnIndicadorFila)
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
						Nombre = "PNI_INDICADOR_FILA",
						Tipo = DbType.Int32,
						Valor = pnIndicadorFila
					}
					
					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_INFORMES_COMUN.PROC_CAT_MARCAS";
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
				throw new Informes.Comun.Excepcion(ex.Message, ex);
			}
		}

		internal DataTable ObtenerSucursales(Sesion poSesion, int pnIndicadorFila)
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
						Nombre = "PNI_INDICADOR_FILA",
						Tipo = DbType.Int32,
						Valor = pnIndicadorFila
					}
					
					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_INFORMES_COMUN.PROC_CAT_SUCURSALES";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

				foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
					loSentencia.Parametros.Add(new Parametro()
					{
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_SUCURSAL" + oSucursal.Clave,
						Tipo = DbType.Int32,
						Valor = oSucursal.Clave
					});

				//foreach (Sucursal oSucursal in poSesion.Usuario.Sucursal)
				//    lsSucursales += oSucursal.Clave + ",";

				//if (lsSucursales != string.Empty)
				//    loSentencia.Parametros.Add(new Parametro()
				//    {
				//        Direccion = ParameterDirection.Input,
				//        Nombre = "PNI_CVES_SUCURSALES",
				//        Tipo = DbType.String,
				//        Valor = lsSucursales.TrimEnd(',')
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

		internal DataTable ObtenerTelemarketings(Sesion poSesion, string psClaveSucursal, int pnIndicadorFila)
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
						Nombre = "PNI_INDICADOR_FILA",
						Tipo = DbType.Int32,
						Valor = pnIndicadorFila
					}
					
					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_INFORMES_COMUN.PROC_CAT_TELEMARKETING";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

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

		internal DataTable ObtenerVendedores(Sesion poSesion, string psClaveSucursal, int pnIndicadorFila, int pnIndicadorCve)
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
						Nombre = "PNI_INDICADOR_FILA",
						Tipo = DbType.Int32,
						Valor = pnIndicadorFila
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_INDICADOR_CVE",
						Tipo = DbType.Int32,
						Valor = pnIndicadorCve
					}
					
					#endregion
				};
				loSentencia.TextoComando = "PKG_DAP_INFORMES_COMUN.PROC_CAT_VENDEDORES";
				loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
				loSentencia.TipoComando = CommandType.StoredProcedure;
				loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

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

        internal DataTable ObtenerVendedoresTlmk(Sesion poSesion, string psClaveSucursal, int pnIndicadorFila, int pnIndicadorCve)
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
						Nombre = "PNI_INDICADOR_FILA",
						Tipo = DbType.Int32,
						Valor = pnIndicadorFila
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_INDICADOR_CVE",
						Tipo = DbType.Int32,
						Valor = pnIndicadorCve
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_COMUN.PROC_CAT_VENDEDORES";
                loSentencia.Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query;
                loSentencia.TipoComando = CommandType.StoredProcedure;
                loSentencia.TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion;
                loSentencia.TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto;

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

        internal DataTable ObtenerClientes(Sesion poSesion, int pnIndicadorFila, int pnIndicadorCve, int psClaveSucursal, int pnClaveVendedor)
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
						Nombre = "PNI_INDICADOR_FILA",
						Tipo = DbType.Int32,
						Valor = pnIndicadorFila
					},
					new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_INDICADOR_CVE",
						Tipo = DbType.Int32,
						Valor = pnIndicadorCve
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = psClaveSucursal
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE1",
						Tipo = DbType.Int32,
						Valor = pnClaveVendedor
					}
					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_COMUN.PROC_CAT_CLIENTES";
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
                throw new Informes.Comun.Excepcion(ex.Message, ex);
            }

		}


        internal DataTable ObtenerComodines(Sesion poSesion, int pnClaveSucursal, int pnClaveVendedor,DateTime pdFechaInicial, DateTime pdFechaFinal)
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
						Nombre = "PNI_CVE_VENDEDOR",
						Tipo = DbType.Int32,
						Valor = pnClaveVendedor
					},
                    new Parametro() {
						Direccion = ParameterDirection.Input,
						Nombre = "PNI_CVE_SUCURSAL",
						Tipo = DbType.Int32,
						Valor = pnClaveSucursal
					},
                     new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PDI_FECHA_INICIO",
                        Tipo = DbType.Date,
                        Valor = pdFechaInicial
                    }, 
                     new Parametro() {
                        Direccion = ParameterDirection.Input,
                        Nombre = "PDI_FECHA_FIN",
                        Tipo = DbType.Date,
                        Valor = pdFechaFinal
                    }

					
					#endregion
				};
                loSentencia.TextoComando = "PKG_DAP_INFORMES_COMUN.PROC_CAT_VENDEDORES_COMODIN";
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
                throw new Informes.Comun.Excepcion(ex.Message, ex);
            }

        }



		#endregion
	}
}
