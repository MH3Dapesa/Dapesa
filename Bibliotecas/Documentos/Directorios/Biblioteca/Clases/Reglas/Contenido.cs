using Dapesa.Documentos.Directorios.Comun;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dapesa.Documentos.Directorios.Reglas
{
	public class Contenido : IEnumerable, IContenido
	{
		#region Atributos

		private FileInfo[] _oContenido;
		private Iterador _oIterador;

		#endregion

		#region Constructor

		public Contenido(FileInfo[] poContenido)
		{
			this._oContenido = new FileInfo[poContenido.Length];

			for (int loIndice = 0; loIndice < poContenido.Length; loIndice++)
				this._oContenido[loIndice] = poContenido[loIndice];

			this._oIterador = new Iterador(this._oContenido);
		}

		#endregion

		#region Metodos

		public void CopiarArchivo(string psNombreArchivoOrigen, string psNombreArchivoDestino)
		{

			try
			{
				File.Copy(psNombreArchivoOrigen, psNombreArchivoDestino, true);
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		public void EliminarArchivo(string psNombreArchivo)
		{

			try
			{
				File.Delete(psNombreArchivo); 
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return (IEnumerator)this.GetEnumerator();
		}

		public Iterador GetEnumerator()
		{
			return this._oIterador;
		}

		public List<string> Listar()
		{
			return this._oContenido.Select(item => item.Name).ToList();
		}
		
		public void Ordenar(Definiciones.TipoOrdenamiento poTipoOrdenamiento)
		{

			try
			{
				#region Ordenar contenido

				switch (poTipoOrdenamiento)
				{
					case Definiciones.TipoOrdenamiento.Fecha:
						this._oContenido = this._oContenido.OrderBy(item => item.LastWriteTime).ToArray();
						this._oIterador = new Iterador(this._oContenido);
						break;
					case Definiciones.TipoOrdenamiento.FechaDesc:
						this._oContenido = this._oContenido.OrderByDescending(item => item.LastWriteTime).ToArray();
						this._oIterador = new Iterador(this._oContenido);
						break;
					case Definiciones.TipoOrdenamiento.Nombre:
						this._oContenido = this._oContenido.OrderBy(item => item.Name).ToArray();
						this._oIterador = new Iterador(this._oContenido);
						break;
					case Definiciones.TipoOrdenamiento.NombreDesc:
						this._oContenido = this._oContenido.OrderByDescending(item => item.Name).ToArray();
						this._oIterador = new Iterador(this._oContenido);
						break;
					case Definiciones.TipoOrdenamiento.Tamanio:
						this._oContenido = this._oContenido.OrderBy(item => item.Length).ToArray();
						this._oIterador = new Iterador(this._oContenido);
						break;
					case Definiciones.TipoOrdenamiento.TamanioDesc:
						this._oContenido = this._oContenido.OrderByDescending(item => item.Length).ToArray();
						this._oIterador = new Iterador(this._oContenido);
						break;
					case Definiciones.TipoOrdenamiento.Tipo:
						this._oContenido = this._oContenido.OrderBy(item => item.Extension).ToArray();
						this._oIterador = new Iterador(this._oContenido);
						break;
					case Definiciones.TipoOrdenamiento.TipoDesc:
						this._oContenido = this._oContenido.OrderByDescending(item => item.Extension).ToArray();
						this._oIterador = new Iterador(this._oContenido);
						break;
					default:
						break;
				}

				#endregion
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}
		}

		#endregion
	}
}
