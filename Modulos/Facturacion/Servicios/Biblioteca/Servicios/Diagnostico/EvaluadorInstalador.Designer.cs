namespace Dapesa.Facturacion.Servicios.ASW.Diagnostico
{
	partial class EvaluadorInstalador
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
			this._oInstaladorProcesoServicio = new System.ServiceProcess.ServiceProcessInstaller();
			this._oInstaladorServicio = new System.ServiceProcess.ServiceInstaller();
			// 
			// _oInstaladorProcesoServicio
			// 
			this._oInstaladorProcesoServicio.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			this._oInstaladorProcesoServicio.Password = null;
			this._oInstaladorProcesoServicio.Username = null;
			// 
			// _oInstaladorServicio
			// 
			this._oInstaladorServicio.Description = "Servicio para diagnóstico de códigos de error en facturas y notas de crédito y cargo";
			this._oInstaladorServicio.DisplayName = "Dapesa.DiagnosticoFacturas";
			this._oInstaladorServicio.ServiceName = "Dap.Diagnostico";
			// 
			// EvaluadorInstalador
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
				this._oInstaladorProcesoServicio,
				this._oInstaladorServicio
			});
		}

		#endregion

		private System.ServiceProcess.ServiceProcessInstaller _oInstaladorProcesoServicio;
		private System.ServiceProcess.ServiceInstaller _oInstaladorServicio;
	}
}