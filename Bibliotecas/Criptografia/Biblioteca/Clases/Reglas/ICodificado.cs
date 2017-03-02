using System.Drawing;

namespace Dapesa.Criptografia.Reglas
{
	interface ICodificado
	{
		#region Metodos

		string Formatear(string psEntrada);

		#endregion

		#region Propiedades

		Font Fuente { get; }

		#endregion
	}
}
