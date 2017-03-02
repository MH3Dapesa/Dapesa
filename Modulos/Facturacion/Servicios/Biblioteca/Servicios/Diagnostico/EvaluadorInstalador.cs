using System.ComponentModel;
using System.Configuration.Install;

namespace Dapesa.Facturacion.Servicios.ASW.Diagnostico
{
	[RunInstaller(true)]
	public partial class EvaluadorInstalador : Installer
	{
		public EvaluadorInstalador()
		{
			InitializeComponent();
		}
	}
}
