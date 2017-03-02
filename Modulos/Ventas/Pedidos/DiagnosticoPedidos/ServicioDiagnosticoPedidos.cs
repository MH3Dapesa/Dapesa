using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using Dapesa.Ventas.Pedidos.Reglas;

namespace Ventas.Pedidos.ASW.DiagnosticoPedidos
{
    public partial class ServicioDiagnosticoPedidos : ServiceBase
    {
        public ServicioDiagnosticoPedidos()
        {
            InitializeComponent();
            #region Inicializar configuración log

            this._oLog = new EventLog();

            if (!EventLog.SourceExists("Dap.DiagPedidos.Src"))
                EventLog.CreateEventSource("Dap.DiagPedidos.Src", "Dap.DiagPedidos.Log");

            this._oLog.Source = "Dap.DiagPedidos.Src";
            this._oLog.Log = "Dap.DiagPedidos.Log";

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
                DiagPedidos loDiagnosticoPedidos = new DiagPedidos();

                this._oTemporizador.Enabled = false;
                this._oLog.WriteEntry("Temporizador detenido. Método MOVER invocado...", EventLogEntryType.Information);
                loDiagnosticoPedidos.Monitoreo(this._oLog);
            }
            catch (Exception ex)
            {
                this._oLog.WriteEntry("Error: " + ex.Message + "\r\nFuente: " + ex.Source, EventLogEntryType.Error);
            }
        }
        #endregion Eventos
    }
}
