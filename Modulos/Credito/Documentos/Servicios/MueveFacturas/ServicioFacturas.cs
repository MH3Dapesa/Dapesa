using Dapesa.Credito.Documentos.Reglas;
using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;
using System.Configuration;
using Dapesa.Credito.Documentos;

namespace Dapesa.Credito.Documentos.ASW.MueveFacturas
{
    public partial class ServicioFacturas : ServiceBase
    {

        public ServicioFacturas()
        {
            InitializeComponent();
            #region Inicializar configuración log

            this._oLog = new EventLog();

            if (!EventLog.SourceExists("Dap.FacturasMover.Src"))
                EventLog.CreateEventSource("Dap.FacturasMover.Src", "Dap.FacturasMover.Log");

            this._oLog.Source = "Dap.FacturasMover.Src";
            this._oLog.Log = "Dap.FacturasMover.Log";

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
                Facturas loFacturas = new Facturas();
                this._oTemporizador.Enabled = false;
                this._oLog.WriteEntry("Temporizador detenido. Método MOVER invocado.", EventLogEntryType.Information);
                loFacturas.Mover(this._oLog, ConfigurationManager.AppSettings["EnvioCorreoActivado"], ConfigurationManager.AppSettings["CorreoCuenta"], ConfigurationManager.AppSettings["CorreoDestinatario"],
                    ConfigurationManager.AppSettings["CorreoServidor"], ConfigurationManager.AppSettings["CorreoPuerto"], ConfigurationManager.AppSettings["CorreoCP"], int.Parse(ConfigurationManager.AppSettings["TiempoEsperaError"]));
            }
            catch (Exception ex)
            {
                this._oLog.WriteEntry("Error: " + ex.Message + "\r\nFuente: " + ex.Source, EventLogEntryType.Error);

                Reglas.Documentos loDocumentos = new Reglas.Documentos();
                loDocumentos.EnviarAviso("Error: " + ex.Message + "\r\nFuente: " + ex.Source, ConfigurationManager.AppSettings["EnvioCorreoActivado"], ConfigurationManager.AppSettings["CorreoCuenta"], ConfigurationManager.AppSettings["CorreoDestinatario"],
                                    ConfigurationManager.AppSettings["CorreoServidor"], ConfigurationManager.AppSettings["CorreoPuerto"], ConfigurationManager.AppSettings["CorreoCP"]);
                GC.Collect();
            }
        }



        #endregion
    }
}
