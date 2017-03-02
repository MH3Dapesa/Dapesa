using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Net.Mail;
using System.Configuration;
using System.Threading;

namespace Dapesa.Credito.Documentos.ASW.MueveFacturas
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
					new ServicioFacturas() 
				};
				ServiceBase.Run(ServicesToRun);
			}
			catch (Exception ex)
			{
				EventLog.WriteEntry("Application", ex.Source + "-" + ex.Message, EventLogEntryType.Error);

                Reglas.Documentos loDocumentos = new Reglas.Documentos();
                loDocumentos.EnviarAviso("Error en Applicacion:" + ex.Source + "-" + ex.Message, ConfigurationManager.AppSettings["EnvioCorreoActivado"], ConfigurationManager.AppSettings["CorreoCuenta"], ConfigurationManager.AppSettings["CorreoDestinatario"],
                   ConfigurationManager.AppSettings["CorreoServidor"], ConfigurationManager.AppSettings["CorreoPuerto"], ConfigurationManager.AppSettings["CorreoCP"]);
                Thread.Sleep(int.Parse(ConfigurationManager.AppSettings["TiempoEsperaError"]));
                
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
				{ 
					new ServicioFacturas() 
				};
                ServiceBase.Run(ServicesToRun);
			}
		}

      


	}
}
