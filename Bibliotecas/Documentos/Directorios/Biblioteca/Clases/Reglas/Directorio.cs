using Dapesa.Documentos.Directorios.Comun;
using System;
using System.IO;

namespace Dapesa.Documentos.Directorios.Reglas
{
	public abstract class Directorio
	{
		#region Atributos

		protected string _sRuta;
		protected Contenido _oContenido;

		#endregion

		#region Constructor

		protected Directorio(string psDirectorio)
		{

			try
			{
				this._sRuta = psDirectorio;

				if (!this._sRuta.EndsWith("\\"))
					this._sRuta += "\\";

				this._oContenido = new Contenido(new DirectoryInfo(this._sRuta).GetFiles());
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		#endregion
	}
}
