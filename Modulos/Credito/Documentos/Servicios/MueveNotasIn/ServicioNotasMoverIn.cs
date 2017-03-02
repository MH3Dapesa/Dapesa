using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using Dapesa.Credito.Documentos.Reglas;
using System.Configuration;

namespace Credito.Documentos.ASW.MueveNotasIn
{
    public partial class ServicioNotasMoverIn : ServiceBase
    {
        public ServicioNotasMoverIn()
        {
            InitializeComponent();
            #region Inicializar configuración log

            this._oLog = new EventLog();

            if (!EventLog.SourceExists("Dap.InNotasMover.Src"))
                EventLog.CreateEventSource("Dap.InNotasMover.Src", "Dap.InNotasMoverLog");

            this._oLog.Source = "Dap.InNotasMoverSrc";
            this._oLog.Log = "Dap.InNotasMoverLog";

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
                NotasIn loDiagnosticoPedidos = new NotasIn();

                this._oTemporizador.Enabled = false;
                this._oLog.WriteEntry("Temporizador detenido. Método MOVER invocado...", EventLogEntryType.Information);
                loDiagnosticoPedidos.MoverIn(this._oLog, ConfigurationManager.AppSettings["CorreoCuenta"], ConfigurationManager.AppSettings["CorreoDestinatario"],
                    ConfigurationManager.AppSettings["CorreoServidor"], ConfigurationManager.AppSettings["CorreoPuerto"], ConfigurationManager.AppSettings["CorreoCP"]);
            }
            catch (Exception ex)
            {
                this._oLog.WriteEntry("Error: " + ex.Message + "\r\nFuente: " + ex.Source, EventLogEntryType.Error);
            }
        }
        #endregion Eventos
    }
}