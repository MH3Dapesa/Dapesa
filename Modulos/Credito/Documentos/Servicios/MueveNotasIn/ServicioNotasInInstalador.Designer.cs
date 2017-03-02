namespace Credito.Documentos.ASW.MueveNotasIn
{
    partial class ServicioNotasInInstalador
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
            this.spiInMNotasInstaladorProceso = new System.ServiceProcess.ServiceProcessInstaller();
            this.siInMoverNotasInstalador = new System.ServiceProcess.ServiceInstaller();
            // 
            // spiInMNotasInstaladorProceso
            // 
            this.spiInMNotasInstaladorProceso.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.spiInMNotasInstaladorProceso.Password = null;
            this.spiInMNotasInstaladorProceso.Username = null;
            // 
            // siInMoverNotasInstalador
            // 
            this.siInMoverNotasInstalador.Description = "Servicio para mover notas y cancelaciones a temporal";
            this.siInMoverNotasInstalador.DisplayName = "Dapesa.InMueveNotas";
            this.siInMoverNotasInstalador.ServiceName = "Dap.InNotasMover";
            this.siInMoverNotasInstalador.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ServicioNotasInInstalador
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.spiInMNotasInstaladorProceso,
            this.siInMoverNotasInstalador});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller spiInMNotasInstaladorProceso;
        private System.ServiceProcess.ServiceInstaller siInMoverNotasInstalador;

    }
}