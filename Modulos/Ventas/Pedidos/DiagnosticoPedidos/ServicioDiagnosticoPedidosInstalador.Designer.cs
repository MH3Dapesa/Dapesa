namespace Ventas.Pedidos.ASW.DiagnosticoPedidos
{
    partial class ServicioDiagnosticoPedidosInstalador
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
            this.spiDPedidosInstaladorProceso = new System.ServiceProcess.ServiceProcessInstaller();
            this.siDPedidosInstalador = new System.ServiceProcess.ServiceInstaller();
            // 
            // spiDPedidosInstaladorProceso
            // 
            this.spiDPedidosInstaladorProceso.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.spiDPedidosInstaladorProceso.Password = null;
            this.spiDPedidosInstaladorProceso.Username = null;
            // 
            // siDPedidosInstalador
            // 
            this.siDPedidosInstalador.Description = "Servicio para detectar pedidos de marcas, lineas o articulos no autorizados por c" +
    "iudad";
            this.siDPedidosInstalador.DisplayName = "Dapesa.DiagPedidos";
            this.siDPedidosInstalador.ServiceName = "Dap.DiagPedidos";
            this.siDPedidosInstalador.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ServicioDiagnosticoPedidosInstalador
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.spiDPedidosInstaladorProceso,
            this.siDPedidosInstalador});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller spiDPedidosInstaladorProceso;
        private System.ServiceProcess.ServiceInstaller siDPedidosInstalador;
    }
}