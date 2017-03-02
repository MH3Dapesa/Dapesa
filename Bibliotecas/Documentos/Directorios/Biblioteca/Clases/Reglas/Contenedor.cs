using Dapesa.Documentos.Directorios.Comun;
using System;
using System.IO;

namespace Dapesa.Documentos.Directorios.Reglas
{
	public class Contenedor : Directorio, IDirectorio
	{
		#region Constructor

		public Contenedor(string psDirectorio)
			: base(psDirectorio)
		{
			
		}

		#endregion

		#region Propiedades

		public Contenido Contenido
		{
			get
			{
				return base._oContenido;
			}
		}

		public string Ruta
		{
			get
			{
				return base._sRuta;
			}
			set
			{
				try
				{
					base._sRuta = value;

					if (!base._sRuta.EndsWith("\\"))
						base._sRuta += "\\";

					base._oContenido = new Contenido(new DirectoryInfo(base._sRuta).GetFiles());
				}
				catch (Exception ex)
				{
					throw new Excepcion(ex.Message, ex);
				}
			}
		}

		#endregion
	}
}
