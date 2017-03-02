using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;

namespace Credito.Documentos.ASW.MueveNotasIn
{
    [RunInstaller(true)]
    public partial class ServicioNotasInInstalador : System.Configuration.Install.Installer
    {
        public ServicioNotasInInstalador()
        {
            InitializeComponent();
        }

        private void siInNotasInstalador_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
