using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace Dapesa.Facturacion.Servicios.ASW.Diagnostico
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{

			try
			{
				ServiceBase[] ServicesToRun;
				ServicesToRun = new ServiceBase[] 
				{ 
					new Evaluador() 
				};
				ServiceBase.Run(ServicesToRun);
			}
			catch (Exception ex)
			{
				EventLog.WriteEntry("Application", ex.Source + "-" + ex.Message, EventLogEntryType.Error);
			}
		}
	}
}
