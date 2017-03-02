using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sistemas.Desbloqueos.Reglas
{
    internal class HelperConsultas
    {
        ConexionRac1 loConexionRac1 = new ConexionRac1();
        ConexionRac2 loConexionRac2 = new ConexionRac2();
        ConexionBalanceador loConexionBalanceador = new ConexionBalanceador();

        internal DataTable todosLosProcesos()
        {
            DataTable loResultado = new DataTable();

            string sConsulta =
                 "select distinct s.USERNAME DB_USR, s.MACHINE ||' - '|| s.OSUSER as OS_USR,"
               + "to_char(logon_time,'hh:mi:ss pm dd-mon-yy') LOGON_TIME,"
               + "decode (s.status, 'INACTIVE', 'Si', 'No') ACTIVE, sw.event event,"
               + "s.program, s.sid ||',' || s.serial# ||',@'|| s.inst_id sid_serial_RAC,"
               + "DECODE(sq.sql_text, NULL,'– Not Available -', sq.sql_text) AS SQL "
               + "from v$session_wait sw, gv$session s, v$sql sq where s.sid = sw.sid and "
               + "s.sql_hash_value = sq.hash_value(+) "
               + "and upper(sq.sql_text) not like '%CONFIGURATION%' order by s.USERNAME asc nulls last";

            loResultado = unirRAC(RAC1(sConsulta), RAC2(sConsulta));

            return loResultado;
        }

        internal DataTable llenarBloqueados()
        {
            DataTable loResultado = new DataTable();

            string sConsulta =
                     "select distinct s.USERNAME DB_USR, s.MACHINE ||' - '|| s.OSUSER as OS_USR,"
                  +  "to_char(logon_time,'hh:mi:ss pm dd-mon-yy') LOGON_TIME,"
                  +  "decode (s.status, 'INACTIVE', 'Si', 'No') ACTIVE, sw.event event,"
                  +  "s.program, s.sid ||','|| s.serial# sid_serial, '@'|| s.inst_id RAC "
                  +  "from v$session_wait sw,gv$session s, v$sql sq where s.sid = sw.sid and "
                  +  "sw.event NOT LIKE 'SQL%' AND s.sql_hash_value = sq.hash_value(+) "
                  +  "and upper(sq.sql_text) not like '%CONFIGURATION%' "
                  + "order by 1 desc NULLS LAST";

            loResultado = unirRAC(RAC1(sConsulta), RAC2(sConsulta));

            return loResultado;
        }

        internal DataTable llenarVendedores()
        {
            DataTable loResultado = new DataTable();

            string sConsulta =
                  "SELECT distinct s.username AS DB_USR, s.machine ||' - '|| s.osuser AS OS_USR,"
                + "TO_CHAR(logon_time,'hh:mi:ss pm dd-mon-yy') AS LOGON_TIME,"
                + "DECODE(s.status, 'INACTIVE', 'Si', 'No') AS ACTIVE, sw.event AS EVENT, '@' || s.inst_id RAC,"
                + "DECODE(sq.sql_text, NULL,'– Not Available -', sq.sql_text) AS SQL "
                + "FROM v$session_wait sw, gv$session s, v$sql sq WHERE s.username LIKE 'VEND%' AND  s.sid = sw.sid "
                + "AND s.sql_hash_value = sq.hash_value(+) AND UPPER(sq.sql_text) NOT LIKE '%CONFIGURATION%' "
                + "ORDER BY 1 DESC";

            loResultado = unirRAC(RAC1(sConsulta), RAC2(sConsulta));

            return loResultado;
        }

        internal DataTable RAC1(string sConsulta)
        {
            try
            {
                DataTable loTablaRAC1 = (DataTable)loConexionRac1.EjecutarConsulta(sConsulta, ConexionRac1.TipoProcesamiento.DataTable, true);
                return loTablaRAC1;
            }
            catch
            {
                return null;
            }            
        }

        internal DataTable RAC2(string sConsulta)
        {
            try 
            { 
            DataTable loTablaRAC2 = (DataTable)loConexionRac2.EjecutarConsulta(sConsulta, ConexionRac2.TipoProcesamiento.DataTable, true);
            return loTablaRAC2;
            }
            catch
            {
                return null;
            }      
        }

        internal DataTable Balanceador(string sConsulta)
        {
            DataTable loTablaBalanceador = (DataTable)loConexionBalanceador.EjecutarConsulta(sConsulta, ConexionBalanceador.TipoProcesamiento.DataTable, true);
            return loTablaBalanceador;
        }

        internal DataTable unirRAC(DataTable loTablaRAC1, DataTable loTablaRAC2)
        {
            DataTable lotablaUnion = new DataTable();

            if(loTablaRAC1 == null)
            {
                return loTablaRAC2;
            }

            if (loTablaRAC2 == null)
            {
                return loTablaRAC1;
            }

            DataColumn[] loColumnasTablaRAC1 = new DataColumn[loTablaRAC1.Columns.Count];

            for (int i = 0; i < loTablaRAC1.Columns.Count; i++)
            {
                loColumnasTablaRAC1[i] = new DataColumn(
                loTablaRAC1.Columns[i].ColumnName, loTablaRAC1.Columns[i].DataType);
            }

            lotablaUnion.Columns.AddRange(loColumnasTablaRAC1);
            lotablaUnion.BeginLoadData();
            
            foreach (DataRow loFila in loTablaRAC2.Rows)
            {
                lotablaUnion.LoadDataRow(loFila.ItemArray, true);
            }

            lotablaUnion.EndLoadData();
            return lotablaUnion;
        }

        internal object Desconectar(string sParametros, string sRAC, DataTable loTablaRAC)
        {
            DataTable loResultado = new DataTable();
            loResultado = (DataTable)loTablaRAC;

            string sConsulta = "ALTER SYSTEM DISCONNECT SESSION '" + sParametros + "," + sRAC + "' IMMEDIATE";

            try
            {
                foreach (DataRow loFila in loResultado.Rows)
                {
                    foreach (DataColumn loColumna in loResultado.Columns)
                    {
                        string sApuntador = loFila["RAC"].ToString();
                        if (sApuntador.ToString() == "@1")
                        {
                            loConexionRac1.EjecutarConsulta(sConsulta, ConexionRac1.TipoProcesamiento.NonQuery, true);
                            return true;
                        }
                        if (sApuntador.ToString() == "@2")
                        {
                            loConexionRac2.EjecutarConsulta(sConsulta, ConexionRac2.TipoProcesamiento.NonQuery, true);
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
            return true;
        }

        internal object Matar(string sParametros, string sRAC, DataTable loTablaRAC)
        {
            DataTable loResultado = new DataTable();
            loResultado = (DataTable)loTablaRAC;

            string sConsulta = "ALTER SYSTEM KILL SESSION '" + sParametros + "," + sRAC + "' IMMEDIATE";
            
            try
            {
                foreach(DataRow loFila in loResultado.Rows)
                {
                    foreach (DataColumn loColumna in loResultado.Columns)
                    {
                        string sApuntador = loFila["RAC"].ToString();
                        if (sApuntador.ToString() == "@1")
                        {
                            loConexionRac1.EjecutarConsulta(sConsulta, ConexionRac1.TipoProcesamiento.NonQuery, true);
                            return true;
                        }
                        if (sApuntador.ToString() == "@2")
                        {
                            loConexionRac2.EjecutarConsulta(sConsulta, ConexionRac2.TipoProcesamiento.NonQuery, true);
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
            return true;
        }
    }
}
