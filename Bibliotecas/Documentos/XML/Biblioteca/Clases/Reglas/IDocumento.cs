using Dapesa.Documentos.XML.Comun;
using System.Collections.Generic;

namespace Dapesa.Documentos.XML.Reglas
{
	interface IDocumento
	{
		#region Metodos

		IList<string> ObtenerAtributo(string psNombreElemento, string psNombreAtributo, Definiciones.TipoSalida poTipoSalida);
		IList<string> ObtenerElemento(string psNombreElemento, Definiciones.TipoSalida poTipoSalida);

		#endregion
	}
}
