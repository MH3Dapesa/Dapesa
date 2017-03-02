using System.ComponentModel;
using System.Configuration.Install;

namespace Dapesa.Servicios.ASW.ServicioItinerario
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
