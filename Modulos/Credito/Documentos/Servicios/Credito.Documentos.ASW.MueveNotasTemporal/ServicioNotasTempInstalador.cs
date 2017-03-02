using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;

namespace Credito.Documentos.ASW.MueveNotasTemporal
{
    [RunInstaller(true)]
    public partial class ServicioNotasTempInstalador : System.Configuration.Install.Installer
    {
        public ServicioNotasTempInstalador()
        {
            InitializeComponent();
        }
    }
}
