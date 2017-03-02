using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dapesa.Credito.Clientes.Reglas;
using System.Diagnostics;

namespace Dapesa.Credito.Clientes.IU.MonitoreoSaldos
{
    public partial class Contenido : Form
    {
        public Contenido()
        {
            InitializeComponent();
            #region Inicializar configuración log

            this._oLog = new EventLog();

            if (!EventLog.SourceExists("Dap.MonitoreoSaldo.Src"))
                EventLog.CreateEventSource("Dap.MonitoreoSaldo.Src", "Dap.MonitoreoSaldo.Log");

            this._oLog.Source = "Dap.MonitoreoSaldo.Src";
            this._oLog.Log = "Dap.MonitoreoSaldo.Log";

            #endregion
        }

        private void Contenido_Shown(object sender, EventArgs e)
        {
            try
            {
                MOSGestor loSaldos = new MOSGestor();
                loSaldos.Monitoreo(this._oLog);
                Close();
            }
            catch(Exception ex)
            {
                this._oLog.WriteEntry("Error: " + ex.Message + "\r\nFuente: " + ex.Source, EventLogEntryType.Error);
            }
        }
    }
}
