namespace Ventas.Pedidos.ASW.DiagnosticoPedidos
{
    partial class ServicioDiagnosticoPedidos
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._oLog = new System.Diagnostics.EventLog();
            this._oTemporizador = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this._oLog)).BeginInit();
            // 
            // _oTemporizador
            // 
            this._oTemporizador.Enabled = false;
            this._oTemporizador.Elapsed += new System.Timers.ElapsedEventHandler(this._oTemporizador_Tick);
            // 
            // ServicioDiagnosticoPedidos
            // 
            this.ServiceName = "Dap.DiagPedidos";
            ((System.ComponentModel.ISupportInitialize)(this._oLog)).EndInit();

        }

        #endregion

        private System.Diagnostics.EventLog _oLog;
        private System.Timers.Timer _oTemporizador;
    }
}
