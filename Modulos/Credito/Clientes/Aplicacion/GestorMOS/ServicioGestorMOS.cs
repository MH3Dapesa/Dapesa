using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using Dapesa.Credito.Clientes.Reglas;

namespace Dapesa.Credito.Clientes.GestorMOS 
{
    public partial class ServicioGestorMOS : ServiceBase
    {
        public ServicioGestorMOS()
        {
            InitializeComponent();
            #region Inicializar configuración log

            this._oLog = new EventLog();

            if (!EventLog.SourceExists("Dap.GestorMOS.Src"))
                EventLog.CreateEventSource("Dap.GestorMOS.Src", "Dap.GestorMOS.Log");

            this._oLog.Source = "Dap.GestorMOS.Src";
            this._oLog.Log = "Dap.GestorMOS.Log";

            #endregion
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                this._oLog.WriteEntry("Servicio iniciado correctamente y en escucha.", EventLogEntryType.Information);
                this._oTemporizador.Interval = 2000;
                this._oTemporizador.Enabled = true;
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
                this._oLog.WriteEntry("Servicio detenido.", EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                this._oLog.WriteEntry("Error: " + ex.Message + "\r\nFuente: " + ex.Source, EventLogEntryType.Error);
            }
        }

        #region Eventos

        private void _oTemporizador_Tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                MOSGestor loClientesSaldo = new MOSGestor();

                this._oTemporizador.Enabled = false;
                this._oLog.WriteEntry("Temporizador detenido. Método GestorMOS invocado...", EventLogEntryType.Information);
                loClientesSaldo.Monitoreo(this._oLog);
                this._oLog.WriteEntry("METODO MONITOREO TERMINADO.... DETENER SERVICIO...", EventLogEntryType.Information);
                this.Stop();
            }
            catch (Exception ex)
            {
                this._oLog.WriteEntry("Error: " + ex.Message + "\r\nFuente: " + ex.Source, EventLogEntryType.Error);
            }
        }
        #endregion Eventos
    }
}
