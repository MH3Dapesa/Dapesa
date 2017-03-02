using System.ComponentModel;
using System.Configuration.Install;

namespace Dapesa.Credito.Documentos.ASW.MueveFacturas
{
	[RunInstaller(true)]
	public partial class ServicioFacturasInstalador : Installer
	{
		public ServicioFacturasInstalador()
		{
			InitializeComponent();
		}
	}
}
