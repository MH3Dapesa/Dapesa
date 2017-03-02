using System;

namespace Dapesa.Documentos.XML.Comun
{
	public class Excepcion : ApplicationException
	{
		/// <summary>
		/// Lanza una excepción específica de la capa de documentos, relativa a archivos XML
		/// </summary>
		/// <param name="psMensaje">Mensaje de error</param>
		/// <param name="poExcepcionOriginal">Excepción original</param>
		public Excepcion(string psMensaje, Exception poExcepcionOriginal)
			: base(psMensaje, poExcepcionOriginal)
		{

		}

		/// <summary>
		/// Lanza una excepción específica de la capa de documentos, relativa a archivos XML
		/// </summary>
		/// <param name="psMensaje">Mensaje de error</param>
		public Excepcion(string psMensaje)
			: base(psMensaje)
		{

		}
	}
}
