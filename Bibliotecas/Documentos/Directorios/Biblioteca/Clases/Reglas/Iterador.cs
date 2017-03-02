using Dapesa.Documentos.Directorios.Comun;
using System;
using System.Collections;
using System.IO;

namespace Dapesa.Documentos.Directorios.Reglas
{
	public class Iterador : IEnumerator
	{
		#region Atributos

		private readonly FileInfo[] _oContenido;
		private int _nPosicion;

		#endregion

		#region Constructor

		public Iterador(FileInfo[] poContenido)
		{
			this._oContenido = poContenido;
			this._nPosicion = -1;
		}

		#endregion

		#region Metodos

		public bool MoveNext()
		{
			this._nPosicion++;
			return this._nPosicion < this._oContenido.Length;
		}

		public void Reset()
		{
			this._nPosicion = -1;
		}

		#endregion

		#region Propiedades

		object IEnumerator.Current
		{
			get
			{
				return this.Current;
			}
		}

		public FileInfo Current
		{
			get
			{

				try
				{
					return this._oContenido[this._nPosicion];
				}
				catch (IndexOutOfRangeException ioorex)
				{
					throw new Excepcion(ioorex.Message, ioorex);
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
