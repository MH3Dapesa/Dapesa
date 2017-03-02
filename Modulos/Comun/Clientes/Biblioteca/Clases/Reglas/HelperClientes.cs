using Dapesa.AccesoDatos.Comun;
using Dapesa.AccesoDatos.Entidades;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;


namespace Comun.Clientes.Reglas
{
   internal class HelperClientes
    {
       #region Metodos

       internal DataTable ObtenerCliente(Sesion poSesion, string psCliente)
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
						Nombre = "PSI_CLIENTE",
						Tipo = DbType.String,
						Valor = psCliente
                    }
					#endregion
				};
               loSentencia.TextoComando = "PKG_DAP_MONITOREO.PROC_BUSCAR_CLIENTE";
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
