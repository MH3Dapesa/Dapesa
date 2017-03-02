using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace Ventas.Pedidos.ASW.DiagnosticoPedidos
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
				{ 
					new ServicioDiagnosticoPedidos() 
				};
                ServiceBase.Run(ServicesToRun);

        }
    }
}
