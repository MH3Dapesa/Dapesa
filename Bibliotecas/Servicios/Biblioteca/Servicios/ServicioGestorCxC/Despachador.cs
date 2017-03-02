using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceProcess;

namespace Dapesa.Servicios.ASW.ServicioGestorCxC
{
	public partial class Despachador : ServiceBase
	{
		public Despachador()
		{
			InitializeComponent();
			#region Inicializar configuración log

			this._oLog = new EventLog();

			if (!EventLog.SourceExists("Dap.CxCGestor.Src"))
				EventLog.CreateEventSource("Dap.CxCGestor.Src", "Dap.CxCGestor.Log");

			this._oLog.Source = "Dap.CxCGestor.Src";
			this._oLog.Log = "Dap.CxCGestor.Log";

			#endregion 
		}

		protected override void OnStart(string[] args)
		{

			try
			{

				if (this._oHost != null)
				{
					this._oHost.Close();
				}

				this._oHost = new ServiceHost(typeof(Servicios.ServicioGestorCxC.Despachador));
				this._oHost.Open();
				this._oLog.WriteEntry("Servicio iniciado correctamente y en escucha.", EventLogEntryType.Information);
			}
			catch (Exception ex)
			{
				this._oLog.WriteEntry("Error: " + ex.Message + "\r\nFuente: " + ex.Source, EventLogEntryType.Error);
			}
		}

		protected override void OnStop()
		{

			try
			{

				if (this._oHost != null)
				{
					this._oHost.Close();
					this._oHost = null;
					this._oLog.WriteEntry("Servicio detenido.", EventLogEntryType.Information);
				}
			}
			catch (Exception ex)
			{
				this._oLog.WriteEntry("Error: " + ex.Message + "\r\nFuente: " + ex.Source, EventLogEntryType.Error);
			}
		}
	}
}
