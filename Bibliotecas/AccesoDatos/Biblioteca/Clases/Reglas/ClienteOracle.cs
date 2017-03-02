using Dapesa.AccesoDatos.Comun;
using Dapesa.AccesoDatos.Entidades;
using Dapesa.Comun.Entidades;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Dapesa.AccesoDatos.Reglas
{
	internal class ClienteOracle : Cliente, ICliente
	{
		#region Atributos

		private OracleDataAdapter _oAdaptadorDatos;
		private OracleCommand _oComando;
		private OracleConnection _oConexion;
		private OracleTransaction _oTransaccion;
		
		#endregion

		#region Constructor

		internal ClienteOracle(Conexion poConexion)
			: base((poConexion.Tipo == Dapesa.Comun.Definiciones.TipoConexion.CredencialesExplicitas)
				? "User Id=" + poConexion.Credenciales.Usuario + ";Password=" + poConexion.Credenciales.Cifrado.Descifrar(poConexion.Credenciales.Contrasenia) + ";Data Source=" + poConexion.BaseDatos + ";"
				: ((poConexion.Tipo == Dapesa.Comun.Definiciones.TipoConexion.NombreConexion)
				? ConfigurationManager.ConnectionStrings[poConexion.Nombre].ConnectionString
				: "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=" + poConexion.Servidor + ")(PORT=" + poConexion.Puerto + "))" +
					"(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + poConexion.IdServicio + ")));User Id=" + poConexion.Credenciales.Usuario + ";Password=" + poConexion.Credenciales.Cifrado.Descifrar(poConexion.Credenciales.Contrasenia) + ";")
			)
		{

		}

		#endregion

		#region Metodos
		
		protected override bool Conectar()
		{

			if (this._oConexion != null && this._oConexion.State != ConnectionState.Closed)
				return false;

			try
			{

				if (this._oConexion == null)
				{
					this._oConexion = new OracleConnection();
					this._oConexion.ConnectionString = base._sCadenaConexion;
				}

				this._oConexion.Open();
				return true;
			}
			catch (DataException dex)
			{
				throw new Excepcion("Error al conectarse a la base de datos", dex);
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		protected override void CrearComando(Sentencia poSentencia)
		{
			
			try
			{
				this._oComando = new OracleCommand();
				this._oComando.Connection = this._oConexion;
				this._oComando.CommandType = poSentencia.TipoComando;
				this._oComando.CommandText = poSentencia.TextoComando;
				this._oComando.CommandTimeout = 0;

				if (poSentencia.TipoManejadorTransaccion == Definiciones.TipoManejadorTransaccion.IniciarTransaccion)
					this._oTransaccion = this._oConexion.BeginTransaction(IsolationLevel.ReadCommitted);
					
				if (poSentencia.Parametros != null)

					foreach (Parametro oParametro in poSentencia.Parametros)
					{
						OracleParameter loParametro = new OracleParameter();

						loParametro.Direction = (ParameterDirection)oParametro.Direccion;
						loParametro.ParameterName = oParametro.Nombre;

						switch (oParametro.Tipo)
						{
							case DbType.Object:
								loParametro.OracleDbType = OracleDbType.RefCursor;
								break;
							default:
								loParametro.DbType = oParametro.Tipo;
								break;
						}

						loParametro.Value = oParametro.Valor;
						this._oComando.Parameters.Add(loParametro);
					}
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		protected override bool Desconectar()
		{

			try
			{

				if (this._oConexion.State == ConnectionState.Open)
					this._oConexion.Close();

				return true;
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		protected override object EjecutarEscalar()
		{

			try
			{
				return this._oComando.ExecuteScalar();
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		protected override int EjecutarNoQuery()
		{

			try
			{
				return this._oComando.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		protected override DataTable EjecutarQuery()
		{
			
			try
			{
				DataTable loResultado = new DataTable();

				this._oAdaptadorDatos = new OracleDataAdapter();
				this._oAdaptadorDatos.SelectCommand = this._oComando;
				this._oAdaptadorDatos.SelectCommand.CommandTimeout = 0;
				this._oAdaptadorDatos.Fill(loResultado);
				return loResultado;
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		protected override object ObtenerParametro(string psNombreParametro)
		{
			return this._oComando.Parameters[psNombreParametro].Value;
		}

		public object Ejecutar(List<Sentencia> poSentencia)
		{
			object loResultado = null;

			try
			{
				this.Conectar();

				switch (poSentencia[0].Tipo)
				{
					case Definiciones.TipoSentencia.Escalar:
						this.CrearComando(poSentencia[0]);
						loResultado = this.EjecutarEscalar();
						break;
					case Definiciones.TipoSentencia.NoQuery:

						foreach (Sentencia oSentencia in poSentencia)
						{
							this.CrearComando(oSentencia);
							loResultado = this.EjecutarNoQuery();
						}

						if (poSentencia[poSentencia.Count - 1].TipoManejadorTransaccion == Definiciones.TipoManejadorTransaccion.FinalizarTransaccion)
							this._oTransaccion.Commit();

						break;
					case Definiciones.TipoSentencia.Query:
						this.CrearComando(poSentencia[0]);
						loResultado = this.EjecutarQuery();

						if (poSentencia[0].TipoComando == CommandType.StoredProcedure && poSentencia[0].Parametros != null)
							foreach (Parametro oParametro in poSentencia[0].Parametros)
							{

								if (oParametro.Direccion != ParameterDirection.InputOutput && 
									oParametro.Direccion != ParameterDirection.Output)
									continue;

								oParametro.Valor = this.ObtenerParametro(oParametro.Nombre);

								if (poSentencia[0].TipoResultado != Definiciones.TipoResultado.Conjunto &&
									poSentencia[0].TipoResultado != Definiciones.TipoResultado.Vacio)
									loResultado = oParametro.Valor;
							}

						break;
					default:
						break;
				}
			}
			catch (Exception ex)
			{

				if (poSentencia[poSentencia.Count - 1].TipoManejadorTransaccion == Definiciones.TipoManejadorTransaccion.FinalizarTransaccion)
					this._oTransaccion.Rollback();

				throw new Excepcion(ex.Message, ex);
			}
			finally
			{
				this.Desconectar();
			}

			return loResultado;
		}

		public bool Validar()
		{

			if (this.Conectar())
				return this.Desconectar();

			return false;
		}

		#endregion
	}
}
