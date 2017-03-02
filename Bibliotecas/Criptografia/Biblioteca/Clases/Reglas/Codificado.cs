using Dapesa.Comun.Utilerias;
using System.Drawing;
using System.Drawing.Text;

namespace Dapesa.Criptografia.Reglas
{
	public abstract class Codificado
	{
		#region Atributos

		protected readonly Font _oFuente;

		#endregion

		#region Constructor

		protected Codificado(Comun.Definiciones.TipoFuente poTipoFuente, int pnTamanioFuente)
		{
			PrivateFontCollection loTipografia = new PrivateFontCollection();
			FontFamily loFamilia;

			loTipografia.AddFontFile("Resources/" + poTipoFuente.Descripcion() + ".ttf");
			loFamilia = loTipografia.Families[0];

			this._oFuente = new Font(loFamilia, (float)pnTamanioFuente);
		}

		#endregion
	}
}
