using System.ComponentModel;
using System.Configuration.Install;

namespace Dapesa.Servicios.ASW.ServicioGestorCxC
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
