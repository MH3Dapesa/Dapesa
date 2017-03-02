namespace Credito.Documentos.ASW.MueveFacturasIn
{
    partial class ServicioFacturasInInstalador
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
            this.spiInMFacturasInstaladorProceso = new System.ServiceProcess.ServiceProcessInstaller();
            this.siInMoverFacturasInstalador = new System.ServiceProcess.ServiceInstaller();
            // 
            // spiInMFacturasInstaladorProceso
            // 
            this.spiInMFacturasInstaladorProceso.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.spiInMFacturasInstaladorProceso.Password = null;
            this.spiInMFacturasInstaladorProceso.Username = null;
            // 
            // siInMoverFacturasInstalador
            // 
            this.siInMoverFacturasInstalador.Description = "Servicio para mover facturas de la carpeta IN  del servidor de facturación a otra" +
    " ubicación";
            this.siInMoverFacturasInstalador.DisplayName = "Dapesa.InMueveFacturas";
            this.siInMoverFacturasInstalador.ServiceName = "Dap.InFacturasMover";
            this.siInMoverFacturasInstalador.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ServicioFacturasInInstalador
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.spiInMFacturasInstaladorProceso,
            this.siInMoverFacturasInstalador});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller spiInMFacturasInstaladorProceso;
        private System.ServiceProcess.ServiceInstaller siInMoverFacturasInstalador;
    }
}