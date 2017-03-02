using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Dapesa.Credito.Clientes.Comun
{
    public class Definiciones
    {
        public enum TipoEstatusRegistro
        {
            [DescriptionAttribute("N")]
            Activo,
            [DescriptionAttribute("S")]
            Inactivo
        }
    }
}
