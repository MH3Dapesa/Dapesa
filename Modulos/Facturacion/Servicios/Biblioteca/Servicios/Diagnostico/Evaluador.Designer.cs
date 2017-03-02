namespace Dapesa.Facturacion.Servicios.ASW.Diagnostico
{
	partial class Evaluador
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
			this.tmrCorreo = new System.Timers.Timer();
			this.tmrProceso = new System.Timers.Timer();
			((System.ComponentModel.ISupportInitialize)(this.tmrCorreo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tmrProceso)).BeginInit();
			// 
			// tmrCorreo
			// 
			this.tmrCorreo.Enabled = false;
			this.tmrCorreo.Elapsed += new System.Timers.ElapsedEventHandler(this.tmrCorreo_Tick);
			// 
			// tmrProceso
			// 
			this.tmrProceso.Enabled = false;
			this.tmrProceso.Elapsed += new System.Timers.ElapsedEventHandler(this.tmrProceso_Tick);
			((System.ComponentModel.ISupportInitialize)(this.tmrCorreo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tmrProceso)).EndInit();
			// 
			// Evaluador
			// 
			this.AutoLog = false;
			this.ServiceName = "Dap.Diagnostico";
		}

		#endregion

		private Dapesa.Facturacion.Servicios.Reglas.Diagnostico _oDiagnostico;
		private System.Diagnostics.EventLog _oLog;
		private System.Timers.Timer tmrCorreo;
		private System.Timers.Timer tmrProceso;
	}
}
