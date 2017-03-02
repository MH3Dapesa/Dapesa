namespace GestorMOS
{
    partial class ServicioGestorMOSInstalador
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
            this.spiGestorMOSInstaladorProceso = new System.ServiceProcess.ServiceProcessInstaller();
            this.siGestorMOSInstalador = new System.ServiceProcess.ServiceInstaller();
            // 
            // spiGestorMOSInstaladorProceso
            // 
            this.spiGestorMOSInstaladorProceso.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.spiGestorMOSInstaladorProceso.Password = null;
            this.spiGestorMOSInstaladorProceso.Username = null;
            // 
            // siGestorMOSInstalador
            // 
            this.siGestorMOSInstalador.Description = "Servicio para detectar saldos vencidos de pago neto Facturas y Notas de Cargo de " +
    "clientes que son padres e hijos.";
            this.siGestorMOSInstalador.DisplayName = "Dapesa.GestorMOS";
            this.siGestorMOSInstalador.ServiceName = "Dap.GestorMOS";
            this.siGestorMOSInstalador.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ServicioGestorMOSInstalador
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.spiGestorMOSInstaladorProceso,
            this.siGestorMOSInstalador});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller spiGestorMOSInstaladorProceso;
        private System.ServiceProcess.ServiceInstaller siGestorMOSInstalador;
    }
}