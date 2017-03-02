namespace Dapesa.Credito.Documentos.ASW.MueveFacturas
{
	partial class ServicioFacturasInstalador
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
			this.spiServicioFacturasInstaladorProceso = new System.ServiceProcess.ServiceProcessInstaller();
			this.siServicioFacturasInstalador = new System.ServiceProcess.ServiceInstaller();
			// 
			// spiServicioFacturasInstaladorProceso
			// 
			this.spiServicioFacturasInstaladorProceso.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			this.spiServicioFacturasInstaladorProceso.Password = null;
			this.spiServicioFacturasInstaladorProceso.Username = null;
			// 
			// siServicioFacturasInstalador
			// 
			this.siServicioFacturasInstalador.Description = "Servicio para mover facturas del out del buzón fiscal, a la ubicación que le corr" +
    "esponde";
			this.siServicioFacturasInstalador.DisplayName = "Dapesa.MueveFacturas";
			this.siServicioFacturasInstalador.ServiceName = "Dap.FacturasMover";
			this.siServicioFacturasInstalador.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
			// 
			// ServicioFacturasInstalador
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.spiServicioFacturasInstaladorProceso,
            this.siServicioFacturasInstalador});

		}

		#endregion

		private System.ServiceProcess.ServiceProcessInstaller spiServicioFacturasInstaladorProceso;
		private System.ServiceProcess.ServiceInstaller siServicioFacturasInstalador;
	}
}