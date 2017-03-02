using Dapesa.Seguridad.Entidades;
using System.Data;

namespace Dapesa.Sistemas.Seguridad.Reglas
{
    public class Permiso
    {
        #region Metodos
        public DataTable BuscarGrupo(Sesion poSesion, string psDescripcion)
        {
            HelperPermiso loHelper = new HelperPermiso();

            return loHelper.BuscarGrupo(poSesion, psDescripcion);
        }

        public DataTable BuscarPersonal(Sesion poSesion)
        {
            HelperPermiso loHelper = new HelperPermiso();

            return loHelper.BuscarPersonal(poSesion);
        }

        public DataTable ObtenerGrupo(Sesion poSesion)
        {
            HelperPermiso loHelper = new HelperPermiso();

            return loHelper.ObtenerGrupo(poSesion);
        }

        public DataTable ObtenerAplicacion(Sesion poSesion)
        {
            HelperPermiso loHelper = new HelperPermiso();
            return loHelper.ObtenerAplicacion(poSesion);
        }


        ///pruebas
        ///
        public DataTable ObtenerPrueba(Sesion poSesion)
        {
            HelperPermiso loHelper = new HelperPermiso();
            return loHelper.ObtenerPrueba(poSesion);
        }
        public bool Eliminar(Sesion poSesion, int valor)
        {
            HelperPermiso loHelper = new HelperPermiso();
            return loHelper.Eliminar(poSesion, valor);
        }
        public bool Guardar(Sesion poSesion)
        {
            HelperPermiso loHelper = new HelperPermiso();
            return loHelper.Guardar(poSesion);
        }
        #endregion
    }
}
