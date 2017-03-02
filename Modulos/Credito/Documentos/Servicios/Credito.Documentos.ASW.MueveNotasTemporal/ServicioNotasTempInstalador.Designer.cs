namespace Credito.Documentos.ASW.MueveNotasTemporal
{
    partial class ServicioNotasTempInstalador
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
            this.spiTempMNotasInstaladorProceso = new System.ServiceProcess.ServiceProcessInstaller();
            this.siTempMoverNotasInstalador = new System.ServiceProcess.ServiceInstaller();
            // 
            // spiTempMNotasInstaladorProceso
            // 
            this.spiTempMNotasInstaladorProceso.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.spiTempMNotasInstaladorProceso.Password = null;
            this.spiTempMNotasInstaladorProceso.Username = null;
            // 
            // siTempMoverNotasInstalador
            // 
            this.siTempMoverNotasInstalador.Description = "Servicio para detectar pedidos de marcas, lineas o articulos no autorizados por c" +
    "iudad";
            this.siTempMoverNotasInstalador.DisplayName = "Dapesa.TempMueveNotas";
            this.siTempMoverNotasInstalador.ServiceName = "Dap.TempNotasMover";
            this.siTempMoverNotasInstalador.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ServicioNotasTempInstalador
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.spiTempMNotasInstaladorProceso,
            this.siTempMoverNotasInstalador});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller spiTempMNotasInstaladorProceso;
        private System.ServiceProcess.ServiceInstaller siTempMoverNotasInstalador;
    }
}