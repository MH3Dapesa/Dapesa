using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;

namespace GestorMOS
{
    [RunInstaller(true)]
    public partial class ServicioGestorMOSInstalador : System.Configuration.Install.Installer
    {
        public ServicioGestorMOSInstalador()
        {
            InitializeComponent();
        }
    }
}
