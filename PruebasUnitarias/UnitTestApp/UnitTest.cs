using Dapesa.AccesoDatos.Comun;
using Dapesa.AccesoDatos.Entidades;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.Comun.Entidades;
using Dapesa.Comunicaciones.Mensajeria.Entidades;
using Dapesa.Criptografia.Reglas;
using Dapesa.Facturacion.Servicios.Reglas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;

namespace UnitTestApp
{
	[TestClass]
	public class UnitTest
	{
		#region Atributos

		private Diagnostico _oDiagnostico;

		#endregion

		#region Constructor

		public UnitTest()
		{
			Cifrado loCifrado = new Cifrado(Dapesa.Criptografia.Comun.Definiciones.TipoCifrado.AES);

			this._oDiagnostico = new Diagnostico(new Dapesa.Facturacion.Servicios.Entidades.Diagnostico() {
				DirectorioDiagnostico = @"C:\Users\ricardo.melchor\Downloads\errores",
				DirectorioEntrada = @"C:\Users\ricardo.melchor\Downloads\entrada",
				DirectorioProcesados = @"C:\Users\ricardo.melchor\Downloads\procesados",
				Mensaje = new Correo()	{
					Asunto = "AVISO IMPORTANTE FACTURA CANCELADA NO PROCESADA ",
					Credenciales = new Credenciales {
						Cifrado = loCifrado,
						Contrasenia = loCifrado.Cifrar("mensajero"),
						Usuario = "mensajero@dapesa.com.mx"
					},
					Destinatario = "ricardo_melchor@dapesa.com.mx",
					Puerto = 25,
					Remitente = "mensajero@dapesa.com.mx",
					Servidor = "smtp.dapesa.com.mx"
				}
			});
		}

		#endregion

		#region Metodos de prueba

		[TestMethod]
		public void TestClientesBd()
		{
			object loResultado = null;
			
			try
			{
				List<Sentencia> loSentencia = new List<Sentencia>();
				Planificador loPlanificador = new Planificador();
				Conexion loConexionMySql = new Conexion();
				Conexion loConexionOracle = new Conexion();
				Conexion loConexionSqlSvr = new Conexion();
								
				#region Recuperacion de conjuntos de datos

				#region MySql

				Sentencia loQryMySql = new Sentencia();

				loConexionMySql.Nombre = "WORLD";
				loConexionMySql.Tipo = Dapesa.Comun.Definiciones.TipoConexion.NombreConexion;
				loConexionMySql.TipoCliente = Dapesa.Comun.Definiciones.TipoCliente.MySql;
				loQryMySql.TextoComando = "SELECT * FROM world.city";
				loQryMySql.Tipo = Definiciones.TipoSentencia.Query;
				loQryMySql.TipoComando = CommandType.Text;
				loQryMySql.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loQryMySql.TipoResultado = Definiciones.TipoResultado.Conjunto;

				loSentencia.Add(loQryMySql);
				loResultado = loPlanificador.Servir(loConexionMySql, loSentencia);

				#endregion
				#region Oracle

				Sentencia loQryOracle = new Sentencia();

				loConexionOracle.Nombre = "SIIL_DEMO";
				loConexionOracle.Tipo = Dapesa.Comun.Definiciones.TipoConexion.NombreConexion;
				loConexionOracle.TipoCliente = Dapesa.Comun.Definiciones.TipoCliente.Oracle;
				loQryOracle.TextoComando = "SELECT * FROM SIIL_DEMO.DAP_CAJA";
				loQryOracle.Tipo = Definiciones.TipoSentencia.Query;
				loQryOracle.TipoComando = CommandType.Text;
				loQryOracle.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loQryOracle.TipoResultado = Definiciones.TipoResultado.Conjunto;

				loSentencia.Clear();
				loSentencia.Add(loQryOracle);
				loResultado = loPlanificador.Servir(loConexionOracle, loSentencia);

				#endregion
				#region SqlServer

				Sentencia loQrySqlSvr = new Sentencia();

				loConexionSqlSvr.Nombre = "NORTHWIND";
				loConexionSqlSvr.Tipo = Dapesa.Comun.Definiciones.TipoConexion.NombreConexion;
				loConexionSqlSvr.TipoCliente = Dapesa.Comun.Definiciones.TipoCliente.SqlServer;
				loQrySqlSvr.TextoComando = "SELECT C.CategoryID, C.CategoryName FROM Northwind.dbo.Categories C";
				loQrySqlSvr.Tipo = Definiciones.TipoSentencia.Query;
				loQrySqlSvr.TipoComando = CommandType.Text;
				loQrySqlSvr.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loQrySqlSvr.TipoResultado = Definiciones.TipoResultado.Conjunto;

				loSentencia.Clear();
				loSentencia.Add(loQrySqlSvr);
				loResultado = loPlanificador.Servir(loConexionSqlSvr, loSentencia);

				#endregion

				#endregion
				#region Recuperacion de escalares

				#region Cadena

				Sentencia loValCadena = new Sentencia();

				loValCadena.TextoComando = "SELECT 'HOLA' AS MENSAJE";
				loValCadena.Tipo = Definiciones.TipoSentencia.Escalar;
				loValCadena.TipoComando = CommandType.Text;
				loValCadena.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loValCadena.TipoResultado = Definiciones.TipoResultado.Cadena;

				loSentencia.Clear();
				loSentencia.Add(loValCadena);
				loResultado = loPlanificador.Servir(loConexionMySql, loSentencia);

				#endregion
				#region Decimal

				Sentencia loValDecimal = new Sentencia();

				loValDecimal.TextoComando = "SELECT AVG(VALOR) FROM (SELECT 4 AS VALOR FROM DUAL UNION SELECT 5 FROM DUAL) R";
				loValDecimal.Tipo = Definiciones.TipoSentencia.Escalar;
				loValDecimal.TipoComando = CommandType.Text;
				loValDecimal.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loValDecimal.TipoResultado = Definiciones.TipoResultado.Decimal;

				loSentencia.Clear();
				loSentencia.Add(loValDecimal);
				loResultado = loPlanificador.Servir(loConexionOracle, loSentencia);

				#endregion
				#region Entero

				Sentencia loValEntero = new Sentencia();

				loValEntero.TextoComando = "SELECT COUNT(*) FROM Northwind.dbo.Categories";
				loValEntero.Tipo = Definiciones.TipoSentencia.Escalar;
				loValEntero.TipoComando = CommandType.Text;
				loValEntero.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loValEntero.TipoResultado = Definiciones.TipoResultado.Entero;

				loSentencia.Clear();
				loSentencia.Add(loValEntero);
				loResultado = loPlanificador.Servir(loConexionSqlSvr, loSentencia);

				#endregion

				#endregion
				#region Uso de parametros en consultas

				#region MySql

				Sentencia loQryParamMySql = new Sentencia();
				
				#region Parametros

				Parametro loParamCodPais = new Parametro();
				
				loParamCodPais.Direccion = ParameterDirection.Input;
				loParamCodPais.Nombre = "codigoPais";
				loParamCodPais.Tipo = DbType.String;
				loParamCodPais.Valor = "AF%";

				#endregion

				loQryParamMySql.Parametros = new List<Parametro>();
				loQryParamMySql.Parametros.Add(loParamCodPais);
				loQryParamMySql.TextoComando = "SELECT * FROM world.city C WHERE C.CountryCode LIKE @codigoPais";
				loQryParamMySql.Tipo = Definiciones.TipoSentencia.Query;
				loQryParamMySql.TipoComando = CommandType.Text;
				loQryParamMySql.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loQryParamMySql.TipoResultado = Definiciones.TipoResultado.Conjunto;

				loSentencia.Clear();
				loSentencia.Add(loQryParamMySql);
				loResultado = loPlanificador.Servir(loConexionMySql, loSentencia);

				#endregion
				#region Oracle

				Sentencia loQryParamOracle = new Sentencia();
				
				#region Parametros

				Parametro loParamFolPedido = new Parametro();

				loParamFolPedido.Direccion = ParameterDirection.Input;
				loParamFolPedido.Nombre = "folioPedido";
				loParamFolPedido.Tipo = DbType.String;
				loParamFolPedido.Valor = "A";

				Parametro loParamNumPedido = new Parametro();

				loParamNumPedido.Direccion = ParameterDirection.Input;
				loParamNumPedido.Nombre = "numeroPedido";
				loParamNumPedido.Tipo = DbType.Int32;
				loParamNumPedido.Valor = 450685;

				#endregion

				loQryParamOracle.Parametros = new List<Parametro>();
				loQryParamOracle.Parametros.Add(loParamFolPedido);
				loQryParamOracle.Parametros.Add(loParamNumPedido);
				loQryParamOracle.TextoComando = "SELECT P.SUBTOTAL, P.IVA, P.TOTAL FROM SIIL_DEMO.PEDIDOS P WHERE P.FOLPED_FOLIO=:1 AND P.NUMERO=:2";
				loQryParamOracle.Tipo = Definiciones.TipoSentencia.Query;
				loQryParamOracle.TipoComando = CommandType.Text;
				loQryParamOracle.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loQryParamOracle.TipoResultado = Definiciones.TipoResultado.Conjunto;

				loSentencia.Clear();
				loSentencia.Add(loQryParamOracle);
				loResultado = loPlanificador.Servir(loConexionOracle, loSentencia);

				#endregion
				#region SqlServer

				Sentencia loQryParamSqlSvr = new Sentencia();

				#region Parametros

				Parametro loParamCategoria = new Parametro();

				loParamCategoria.Direccion = ParameterDirection.Input;
				loParamCategoria.Nombre = "categoria";
				loParamCategoria.Tipo = DbType.Int32;
				loParamCategoria.Valor = 1;

				#endregion

				loQryParamSqlSvr.Parametros = new List<Parametro>();
				loQryParamSqlSvr.Parametros.Add(loParamCategoria);
				loQryParamSqlSvr.TextoComando = "SELECT C.CategoryID, C.CategoryName FROM Northwind.dbo.Categories C WHERE C.CategoryID=@categoria";
				loQryParamSqlSvr.Tipo = Definiciones.TipoSentencia.Query;
				loQryParamSqlSvr.TipoComando = CommandType.Text;
				loQryParamSqlSvr.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loQryParamSqlSvr.TipoResultado = Definiciones.TipoResultado.Conjunto;

				loSentencia.Clear();
				loSentencia.Add(loQryParamSqlSvr);
				loResultado = loPlanificador.Servir(loConexionSqlSvr, loSentencia);

				#endregion

				#endregion
				#region Llamada a procedimientos almacenados

				#region MySql

				Sentencia loProcMySql = new Sentencia();

				#region Parametros

				Parametro loParamIdPelicula = new Parametro();

				loParamIdPelicula.Direccion = ParameterDirection.Input;
				loParamIdPelicula.Nombre = "p_film_id";
				loParamIdPelicula.Tipo = DbType.Int32;
				loParamIdPelicula.Valor = 1;

				Parametro loParamIdTienda = new Parametro();

				loParamIdTienda.Direccion = ParameterDirection.Input;
				loParamIdTienda.Nombre = "p_store_id";
				loParamIdTienda.Tipo = DbType.Int32;
				loParamIdTienda.Valor = 1;

				Parametro loParamNumCoincidencias = new Parametro();

				loParamNumCoincidencias.Direccion = ParameterDirection.Output;
				loParamNumCoincidencias.Nombre = "p_film_count";
				loParamNumCoincidencias.Tipo = DbType.Int32;

				#endregion

				loProcMySql.Parametros = new List<Parametro>();
				loProcMySql.Parametros.Add(loParamIdPelicula);
				loProcMySql.Parametros.Add(loParamIdTienda);
				loProcMySql.Parametros.Add(loParamNumCoincidencias);
				loProcMySql.TextoComando = "sakila.film_in_stock";
				loProcMySql.Tipo = Definiciones.TipoSentencia.Query;
				loProcMySql.TipoComando = CommandType.StoredProcedure;
				loProcMySql.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loProcMySql.TipoResultado = Definiciones.TipoResultado.Conjunto;

				loConexionMySql.Nombre = "SAKILA";
				loSentencia.Clear();
				loSentencia.Add(loProcMySql);
				loResultado = loPlanificador.Servir(loConexionMySql, loSentencia);
				loResultado = loParamNumCoincidencias.Valor;

				#endregion
				#region Oracle

				Sentencia loProcOracle = new Sentencia();

				#region Parametros

				Parametro loParamValor = new Parametro();

				loParamValor.Direccion = ParameterDirection.InputOutput;
				loParamValor.Nombre = "VALOR";
				loParamValor.Tipo = DbType.Int64;
				loParamValor.Valor = 100;

				#endregion

				loProcOracle.Parametros = new List<Parametro>();
				loProcOracle.Parametros.Add(loParamValor);
				loProcOracle.TextoComando = "SIIL_DEMO.DAP_TEST";
				loProcOracle.Tipo = Definiciones.TipoSentencia.Query;
				loProcOracle.TipoComando = CommandType.StoredProcedure;
				loProcOracle.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loProcOracle.TipoResultado = Definiciones.TipoResultado.Conjunto;

				loSentencia.Clear();
				loSentencia.Add(loProcOracle);
				loResultado = loPlanificador.Servir(loConexionOracle, loSentencia);
				loResultado = loParamValor.Valor;

				#endregion
				#region SqlServer

				Sentencia loProcSqlSvr = new Sentencia();

				#region Parametros

				Parametro loParamIdOrden = new Parametro();

				loParamIdOrden.Direccion = ParameterDirection.Input;
				loParamIdOrden.Nombre = "OrderID";
				loParamIdOrden.Tipo = DbType.Int32;
				loParamIdOrden.Valor = 10248;

				#endregion

				loProcSqlSvr.Parametros = new List<Parametro>();
				loProcSqlSvr.Parametros.Add(loParamIdOrden);
				loProcSqlSvr.TextoComando = "Northwind.dbo.CustOrdersDetail";
				loProcSqlSvr.Tipo = Definiciones.TipoSentencia.Query;
				loProcSqlSvr.TipoComando = CommandType.StoredProcedure;
				loProcSqlSvr.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.NoTransaccion;
				loProcSqlSvr.TipoResultado = Definiciones.TipoResultado.Conjunto;

				loSentencia.Clear();
				loSentencia.Add(loProcSqlSvr);
				loResultado = loPlanificador.Servir(loConexionSqlSvr, loSentencia);

				#endregion

				#endregion
				#region Manejo de transacciones

				//Primera sentencia de insercion
				Sentencia loQryInsercion1 = new Sentencia();

				loQryInsercion1.TextoComando = "INSERT INTO test.prueba VALUES(4,'CUATRO');";
				loQryInsercion1.Tipo = Definiciones.TipoSentencia.NoQuery;
				loQryInsercion1.TipoComando = CommandType.Text;
				loQryInsercion1.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.IniciarTransaccion;
				loQryInsercion1.TipoResultado = Definiciones.TipoResultado.Entero;

				//Segunda sentencia de insercion
				Sentencia loQryInsercion2 = new Sentencia();

				loQryInsercion2.TextoComando = "INSERT INTO test.prueba VALUES(5,'CINCO');";
				loQryInsercion2.Tipo = Definiciones.TipoSentencia.NoQuery;
				loQryInsercion2.TipoComando = CommandType.Text;
				loQryInsercion2.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.ContinuarTransaccion;
				loQryInsercion2.TipoResultado = Definiciones.TipoResultado.Entero;

				//Tercera sentencia de insercion
				Sentencia loQryInsercion3 = new Sentencia();

				loQryInsercion3.TextoComando = "INSERT INTO test.prueba VALUES(3,'TRES');";
				loQryInsercion3.Tipo = Definiciones.TipoSentencia.NoQuery;
				loQryInsercion3.TipoComando = CommandType.Text;
				loQryInsercion3.TipoManejadorTransaccion = Definiciones.TipoManejadorTransaccion.FinalizarTransaccion;
				loQryInsercion3.TipoResultado = Definiciones.TipoResultado.Entero;


				loConexionMySql.Nombre = "TEST";
				loSentencia.Clear();
				loSentencia.Add(loQryInsercion1);
				loSentencia.Add(loQryInsercion2);
				loSentencia.Add(loQryInsercion3);
				loResultado = loPlanificador.Servir(loConexionMySql, loSentencia);

				#endregion
			} 
			catch (Exception ex)
			{ 
				Console.WriteLine(ex.Source + ": " + ex.Message);
			}
		}

		[TestMethod]
		public void TestSrvDiagnosticoFactura()
		{
			this._oDiagnostico.ProcesarDocumento();
			this._oDiagnostico.EnviarReporte();
		}

		#endregion
	}
}
