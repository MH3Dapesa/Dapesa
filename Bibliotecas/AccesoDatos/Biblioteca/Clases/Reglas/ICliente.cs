using Dapesa.AccesoDatos.Entidades;
using System.Collections.Generic;

namespace Dapesa.AccesoDatos.Reglas
{
	interface ICliente
	{
		#region Metodos

		object Ejecutar(List<Sentencia> poSentencia);
		bool Validar();

		#endregion
	}
}
