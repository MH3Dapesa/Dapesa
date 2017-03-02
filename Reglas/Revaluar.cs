using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Contabilidad.Reglas
{
    public class Revaluar
    {

        #region Metodos

        public DataTable Obtener(Sesion poSesion, int psCveUsuario)
        {
            HelperRevaluar loHelper = new HelperRevaluar();

            return loHelper.Obtener(poSesion, psCveUsuario);
        }

        public DataTable ObtenerAgrupadoArticulo(Sesion poSesion, string psArticulo)
        {
            HelperRevaluar loHelper = new HelperRevaluar();

            return loHelper.ObtenerAgrupadoArticulo(poSesion, psArticulo);
        }

        public bool Revaluacion(Sesion poSesion, String psActualizar)
        {
            HelperRevaluar loHelper = new HelperRevaluar();

            return loHelper.Revaluacion(poSesion, psActualizar);
        }

        public DataTable ObtenerINPC()
        {
            HelperRevaluar loHelper = new HelperRevaluar();

            return loHelper.ObtenerINPC();
        }
        #endregion
    }
}
