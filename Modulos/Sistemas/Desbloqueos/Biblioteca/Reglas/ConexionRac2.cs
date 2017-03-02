using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Oracle.DataAccess.Client;
using System.Configuration;
using System.Data;

namespace Sistemas.Desbloqueos.Reglas
{
    class ConexionRac2
    {
        private OracleConnection loConexion;
        private OracleDataAdapter loAdaptadorDatos;
        private DataTable loLlenarTabla;
        private OracleCommand loComando;

        public enum TipoProcesamiento
        {
            NonQuery = 1,
            DataTable = 2
        }

        public void Conectar()
        {
            loConexion = new OracleConnection(ConfigurationManager.ConnectionStrings["ConexionRac2"].ConnectionString);
            loConexion.Open();
        }

        public object EjecutarConsulta(string sConsulta, TipoProcesamiento loTipoProceso, bool bAlerta = true)
        {
            try
            {
                Conectar();
                if (loTipoProceso == TipoProcesamiento.NonQuery)
                {
                    loComando = new OracleCommand(sConsulta, loConexion);
                    loComando.ExecuteNonQuery();
                    return true;
                }
                else if (loTipoProceso == TipoProcesamiento.DataTable)
                {
                    loAdaptadorDatos = new OracleDataAdapter(sConsulta, loConexion);
                    loLlenarTabla = new DataTable();
                    loAdaptadorDatos.Fill(loLlenarTabla);
                    return loLlenarTabla;
                }
                else
                {
                    throw new Exception("Tipo de procesamiento no válido");
                }

            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
            finally
            {
                loConexion.Close();
            }
        }
    }
}
