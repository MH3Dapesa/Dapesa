namespace Dapesa.Credito.Documentos.ASW.MueveNotas
{
    partial class ServicioNotasInstalador
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
            this.spiNotasInstaladorProceso = new System.ServiceProcess.ServiceProcessInstaller();
            this.siNotasInstalador = new System.ServiceProcess.ServiceInstaller();
            // 
            // spiNotasInstaladorProceso
            // 
            this.spiNotasInstaladorProceso.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.spiNotasInstaladorProceso.Password = null;
            this.spiNotasInstaladorProceso.Username = null;
            // 
            // siNotasInstalador
            // 
            this.siNotasInstalador.Description = "Servicio para mover notas de credito, cargo y cancelaciones del buzon fiscal a su" +
    " carpeta correspondiente";
            this.siNotasInstalador.DisplayName = "Dapesa.MueveNotas";
            this.siNotasInstalador.ServiceName = "Dap.NotasMover";
            this.siNotasInstalador.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ServicioNotasInstalador
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.spiNotasInstaladorProceso,
            this.siNotasInstalador});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller spiNotasInstaladorProceso;
        private System.ServiceProcess.ServiceInstaller siNotasInstalador;
    }
}