using Dapesa.Credito.Documentos.Reglas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace MueveFacturasIn
{
    public partial class ServicioFacturasMoverIn : ServiceBase
    {
        public ServicioFacturasMoverIn()
        {
            InitializeComponent();
            #region Inicializar configuración log

            this._oLog = new EventLog();

            if (!EventLog.SourceExists("Dap.InFacturasMover.Src"))
                EventLog.CreateEventSource("Dap.InFacturasMover.Src", "Dap.InFacturasMoverLog");

            this._oLog.Source = "Dap.InFacturasMoverSrc";
            this._oLog.Log = "Dap.InFacturasMoverLog";

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
                this._oLog.WriteEntry("Servicio detenido.", EventLogEntryType.Information);
        }

        #region Eventos

        private void _oTemporizador_Tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                FacturasIn loMoverFacturasIn = new FacturasIn();

                this._oTemporizador.Enabled = false;
                this._oLog.WriteEntry("Temporizador detenido. Método mover facturas invocado.", EventLogEntryType.Information);
                loMoverFacturasIn.FacturasMoverIn(this._oLog, ConfigurationManager.AppSettings["CorreoCuenta"], ConfigurationManager.AppSettings["CorreoDestinatario"],
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

