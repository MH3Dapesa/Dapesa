using System.Drawing;

namespace Dapesa.Criptografia.Reglas
{
	public class Codificacion39 : Codificado, ICodificado
	{
		#region Constructor

		public Codificacion39(Comun.Definiciones.TipoFuente poTipoFuente, int pnTamanioFuente)
			: base(poTipoFuente, pnTamanioFuente)
		{
			
		}

		#endregion

		#region Metodos

		public string Formatear(string psEntrada)
		{
			return string.Format("*{0}*", psEntrada);
		}

		#endregion

		#region Propiedades

		public Font Fuente
		{
			get
			{
				return base._oFuente;
			}
		}

		#endregion
	}
}
