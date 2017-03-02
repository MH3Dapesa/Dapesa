using System;
using System.Collections.Generic;

namespace Dapesa.Sistemas.Seguridad.Reglas
{
    public interface IEnlace
    {
         void DatosBuscarGrupo(string liClave, string lsDescripcion, string lsEstado);
    }

}
