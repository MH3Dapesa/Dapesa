using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;

namespace Credito.Documentos.ASW.MueveFacturasIn
{
    [RunInstaller(true)]
    public partial class ServicioFacturasInInstalador : Installer
    {
        public ServicioFacturasInInstalador()
        {
            InitializeComponent();
        }
    }
}
