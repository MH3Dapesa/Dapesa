using System;
namespace Sistemas.Seguridad.Entidades
{
    public class Grupo
    {
        #region Propiedades.
        public string lsDescripcion { get; set; }
        public DateTime loFechaUltTransact { get; set; }
        public string lsStatusCan { get; set; }
        public string lsUsuarioUltAct { get; set; }
        #endregion
    }
}
