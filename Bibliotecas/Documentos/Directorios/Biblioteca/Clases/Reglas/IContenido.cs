using Dapesa.Documentos.Directorios.Comun;
using System.Collections.Generic;

namespace Dapesa.Documentos.Directorios.Reglas
{
	interface IContenido
	{
		#region Metodos

		void CopiarArchivo(string psNombreArchivoOrigen, string psNombreArchivoDestino);
		void EliminarArchivo(string psNombreArchivo);
		List<string> Listar();
		void Ordenar(Definiciones.TipoOrdenamiento poTipoOrdenamiento);

		#endregion
	}
}
