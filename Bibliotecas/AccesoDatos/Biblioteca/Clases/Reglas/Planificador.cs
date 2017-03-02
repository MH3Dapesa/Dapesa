using Dapesa.AccesoDatos.Comun;
using Dapesa.AccesoDatos.Entidades;
using Dapesa.Comun.Entidades;
using System;
using System.Collections.Generic;

namespace Dapesa.AccesoDatos.Reglas
{
	public class Planificador
	{
		#region Metodos

		/// <summary>
		/// Atiende los requerimientos entrantes, provenientes de la Capa de Negocio
		/// </summary>
		/// <param name="poConexion">Parámetros de conexión a la base de datos</param>
		/// <returns>True, si los parámetros de conexión son válidos. False, en caso contrario.</returns>
		public bool Servir(Conexion poConexion)
		{

			try
			{

				switch (poConexion.TipoCliente)
				{
					case Dapesa.Comun.Definiciones.TipoCliente.MySql:
						ClienteMySql loClienteMySql = new ClienteMySql(poConexion);

						return loClienteMySql.Validar();
					case Dapesa.Comun.Definiciones.TipoCliente.Oracle:
						ClienteOracle loClienteOracle = new ClienteOracle(poConexion);

						return loClienteOracle.Validar();
					case Dapesa.Comun.Definiciones.TipoCliente.SqlServer:
						ClienteSqlServer loClienteSqlServer = new ClienteSqlServer(poConexion);

						return loClienteSqlServer.Validar();
					default:
						return false;
				}
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		/// <summary>
		/// Atiende los requerimientos entrantes, provenientes de la Capa de Negocio
		/// </summary>
		/// <param name="poConexion">Parámetros de conexion a la base de datos</param>
		/// <param name="poSentencia">Lista de sentencias a servir</param>
		/// <returns>Objeto que contiene el resultado de la ejecución del conjunto de sentencias</returns>
		public object Servir(Conexion poConexion, List<Sentencia> poSentencia)
		{

			try
			{

				switch (poConexion.TipoCliente)
				{
					case Dapesa.Comun.Definiciones.TipoCliente.MySql:
						ClienteMySql loClienteMySql = new ClienteMySql(poConexion);

						return loClienteMySql.Ejecutar(poSentencia);
					case Dapesa.Comun.Definiciones.TipoCliente.Oracle:
						ClienteOracle loClienteOracle = new ClienteOracle(poConexion);

						return loClienteOracle.Ejecutar(poSentencia);
					case Dapesa.Comun.Definiciones.TipoCliente.SqlServer:
						ClienteSqlServer loClienteSqlServer = new ClienteSqlServer(poConexion);

						return loClienteSqlServer.Ejecutar(poSentencia);
					default:
						return Definiciones.TipoResultado.Vacio;
				}
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		#endregion
	}
}
