using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sistemas.Desbloqueos.Reglas
{
    public class Consultas
    {
        public DataTable llenarProcesos()
        {
            HelperConsultas loProceso = new HelperConsultas();
            return loProceso.todosLosProcesos();
        }

        public DataTable llenarBloqueados()
        {
            HelperConsultas loBloqueos = new HelperConsultas();
            return loBloqueos.llenarBloqueados();
        }

        public DataTable llenarVendedores()
        {
            HelperConsultas loVendedores = new HelperConsultas();
            return loVendedores.llenarVendedores();
        }

        public object Desconectar(string sParametros, string sRAC, DataTable loTablaRAC)
        {
            HelperConsultas loDesconectar = new HelperConsultas();
            loDesconectar.Desconectar(sParametros, sRAC, loTablaRAC);
            return true;
        }

        public object Matar(string sParametros,string sRAC,DataTable loTablaRAC)
        {
            HelperConsultas loMatar = new HelperConsultas();
            loMatar.Matar(sParametros, sRAC, loTablaRAC);
            return true;
        }
    }
}
