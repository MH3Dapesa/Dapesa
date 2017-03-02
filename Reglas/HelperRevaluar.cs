using Dapesa.AccesoDatos.Entidades;
using Dapesa.AccesoDatos.Reglas;
using Dapesa.Comun.Utilerias;
using Dapesa.Seguridad.Entidades;
using Dapesa.Seguridad.Reglas.Proxy;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.IO;
namespace Contabilidad.Reglas
{
    internal class HelperRevaluar
    {
        #region Metodos 

        internal DataTable Obtener(Sesion poSesion, int pnSucursal)
        {
            string loRutaArchivo = ConfigurationManager.AppSettings["Ruta_Distinct_Articulos"];
            DataTable res = CSV_Datatable(loRutaArchivo);

            return res;
            //try
            //{
            //    MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            //    builder.Server = ConfigurationManager.AppSettings["BDServidor"];
            //    builder.UserID = ConfigurationManager.AppSettings["Usuario"];
            //    builder.Password = ConfigurationManager.AppSettings["pass"];
            //    builder.Database = ConfigurationManager.AppSettings["basedatos"];
            //    MySqlConnection conn = new MySqlConnection(builder.ToString());
               

            //    MySqlCommand cmd = conn.CreateCommand();
            //    cmd.CommandText = "select DISTINCT art_clave as ARTICULO_CLAVE from muestra3 order by id  "; //44118-77774
            //    cmd.CommandTimeout = 0;
            //    conn.Open();
            //    MySqlDataReader reader = cmd.ExecuteReader();
            //    DataTable loResultado = new DataTable();
            //    loResultado.Load(reader);
            //    conn.Close();
            //    return loResultado;
            //}
            //catch (Exception ex)
            //{
            //    throw new Comun.Excepcion(ex.Message, ex);
            //}
        }

        internal DataTable ObtenerAgrupadoArticulo(Sesion poSesion, string psArticulo)
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = ConfigurationManager.AppSettings["BDServidor"];
                builder.UserID = ConfigurationManager.AppSettings["Usuario"];
                builder.Password = ConfigurationManager.AppSettings["pass"];
                builder.Database = ConfigurationManager.AppSettings["basedatos"];
                MySqlConnection conn = new MySqlConnection(builder.ToString());
               

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select  * from muestra3 where ART_CLAVE = '" + psArticulo + "' ORDER BY FECHA_MOV_ALMACEN ";
                //cmd.CommandText = "select  id,NUMERO,ART_CLAVE,CONCEPTO_MOV_ALMACEN,TIPO_MOVTO,FECHA_MOV_ALMACEN,NUM_MOVTO_ALMACEN,CANTIDAD,ULT_COSTO,CLAVE_ALMACEN,NUM_MOVTO_ALM_DEV,CXC,'' AS REF_COMPRA, '' AS FECHA_COMPRA, '' AS COSTO_COMPRA, '' AS CONTEO, '' AS REFERENCIA_CON_PZAS from muestra3 where ART_CLAVE = '" + psArticulo + "' ORDER BY FECHA_MOV_ALMACEN ";
                cmd.CommandTimeout = 0;
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable loResultado = new DataTable();
                loResultado.Load(reader);
                conn.Close();
                return loResultado;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal bool Revaluacion(Sesion poSesion, string psActualizar)
        {
            try
            {
                
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = ConfigurationManager.AppSettings["BDServidor"];
                builder.UserID = ConfigurationManager.AppSettings["Usuario"];
                builder.Password = ConfigurationManager.AppSettings["pass"];
                builder.Database = ConfigurationManager.AppSettings["basedatos"];
                MySqlConnection conn = new MySqlConnection(builder.ToString());
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandTimeout = 0;
                conn.Open();
                cmd.CommandText = 
                    "LOAD DATA " +
                    " local INFILE '" + psActualizar + "' " +
                    " INTO TABLE MUESTRAREVALUACION "+
                    " FIELDS TERMINATED BY ';' " +
                    " LINES TERMINATED BY '\r\n' ";
                cmd.ExecuteReader();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        public static DataTable CSV_Datatable(string loRutaArchivo)
        {
            try
            {
                StreamReader sr = new StreamReader(loRutaArchivo);
                string[] headers = sr.ReadLine().Split(';');
                DataTable dt = new DataTable();
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(';');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }

        internal DataTable ObtenerINPC()
        {
            string loRutaArchivo = ConfigurationManager.AppSettings["Ruta_INPC"];
            DataTable res = CSV_Datatable(loRutaArchivo);

            return res;
        }
        #endregion
    }
}
