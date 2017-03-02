using Dapesa.Comun.Entidades;
using Dapesa.Comunicaciones.Mensajeria.Entidades;
using Dapesa.Criptografia.Comun;
using Dapesa.Criptografia.Reglas;
using log4net;
using log4net.Config;
using System;
using System.Configuration;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;

namespace Dapesa.Facturacion.Servicios.ASW.Diagnostico
{
	public partial class Evaluador : ServiceBase
	{
		#region Atributos

		private static readonly ILog Logger = LogManager.GetLogger(typeof(Evaluador));
		
		#endregion

		public Evaluador()
		{
			InitializeComponent();
			#region Inicializar objetos

			try
			{
				#region Configuración log

				this._oLog = new EventLog();
				XmlConfigurator.Configure();

				if (!EventLog.SourceExists("Dap.Diagnostico.Src"))
					EventLog.CreateEventSource("Dap.Diagnostico.Src", "Dap.Diagnostico.Log");

				this._oLog.Source = "Dap.Diagnostico.Src";
				this._oLog.Log = "Dap.Diagnostico.Log";

				#endregion
			}
			catch(Exception ex)
			{
				Evaluador.Logger.Info("Fuente: " + ex.Source);
				Evaluador.Logger.Error(ex.Message);
			}

			#endregion
		}

		protected override void OnStart(string[] args)
		{
			
			try
			{
				this._oLog.WriteEntry("Configurando elementos de diagnóstico...", EventLogEntryType.Information);

				#region Configuración elementos diagnóstico

				Cifrado loCifrado = new Cifrado(Definiciones.TipoCifrado.AES);

				this._oDiagnostico = new Reglas.Diagnostico(new Entidades.Diagnostico() {
					DirectorioDiagnostico = ConfigurationManager.AppSettings["DirectorioDiagnostico"],
					DirectorioEntrada = ConfigurationManager.AppSettings["DirectorioEntrada"],
					DirectorioProcesados = ConfigurationManager.AppSettings["DirectorioProcesados"],
					HoraDetencion = ConfigurationManager.AppSettings["HoraDetencion"],
					HoraDetencionSabado = ConfigurationManager.AppSettings["HoraDetencionSabado"],
					HoraReanudacion = ConfigurationManager.AppSettings["HoraReanudacion"],
					Mensaje = new Correo()	{
						Asunto = ConfigurationManager.AppSettings["CorreoAsunto"],
						CC = (string.IsNullOrEmpty(ConfigurationManager.AppSettings["CorreoCC"])) ? null : ConfigurationManager.AppSettings["CorreoCC"],
						Credenciales = new Credenciales	{
							Cifrado = loCifrado,
							Contrasenia = loCifrado.Cifrar(ConfigurationManager.AppSettings["CorreoCP"]),
							Usuario = ConfigurationManager.AppSettings["CorreoCuenta"]
						},
						Destinatario = ConfigurationManager.AppSettings["CorreoDestinatario"],
						Puerto = int.Parse(ConfigurationManager.AppSettings["CorreoPuerto"]),
						Remitente = ConfigurationManager.AppSettings["CorreoCuenta"],
						Servidor = ConfigurationManager.AppSettings["CorreoServidor"]
					}
				});

				#endregion
			
				this._oLog.WriteEntry("Proceso iniciado...", EventLogEntryType.Information);
				tmrProceso.Interval = int.Parse(ConfigurationManager.AppSettings["TemporizadorProceso"]);
				tmrCorreo.Interval = int.Parse(ConfigurationManager.AppSettings["TemporizadorCorreo"]);
				tmrProceso.Enabled = true; 
				tmrCorreo.Enabled = true;
			}
			catch (Exception ex)
			{
				this._oLog.WriteEntry("Error: " + ex.Message + ". Fuente: " + ex.Source, EventLogEntryType.Error);
			}
		}

		protected override void OnStop()
		{
			
			try
			{
				this._oLog.WriteEntry("... proceso detenido.", EventLogEntryType.Information);
				tmrProceso.Enabled = false; 
				tmrCorreo.Enabled = false;
			}
			catch (Exception ex)
			{
				this._oLog.WriteEntry("Error: " + ex.Message + ". Fuente: " + ex.Source, EventLogEntryType.Error);
			}
		}

		#region Eventos

		protected void tmrCorreo_Tick(object sender, ElapsedEventArgs args)
		{

			try
			{
				this._oDiagnostico.EnviarReporte();
			}
			catch(Exception ex)
			{
				this._oLog.WriteEntry("Error: " + ex.Message + ". Fuente: " + ex.Source, EventLogEntryType.Error);
			}
		}

		protected void tmrProceso_Tick(object sender, ElapsedEventArgs args)
		{

			try
			{
				this._oDiagnostico.ProcesarDocumento();
			}
			catch(Exception ex)
			{
				this._oLog.WriteEntry("Error: " + ex.Message + ". Fuente: " + ex.Source, EventLogEntryType.Error);
			}
		}

		#endregion
	}
}
