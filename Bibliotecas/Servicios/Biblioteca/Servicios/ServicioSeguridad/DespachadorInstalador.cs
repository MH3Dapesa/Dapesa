using System.ComponentModel;
using System.Configuration.Install;

namespace Dapesa.Servicios.ASW.ServicioSeguridad
{
	[RunInstaller(true)]
	public partial class DespachadorInstalador : Installer
	{
		public DespachadorInstalador()
		{
			InitializeComponent();
		}
	}
}
