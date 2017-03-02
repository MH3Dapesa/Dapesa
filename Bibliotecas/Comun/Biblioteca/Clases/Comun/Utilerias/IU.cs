using System;
using System.Windows.Forms;

namespace Dapesa.Comun.Utilerias
{
	public class IU
	{
		#region Metodos

		public static bool ExisteFormulario(Type poTipoFormulario, Form[] poMdiHijos)
		{

			foreach (Form loFormularioHijo in poMdiHijos)
				if (loFormularioHijo.GetType() == poTipoFormulario)
				{
					loFormularioHijo.WindowState = FormWindowState.Normal;
					loFormularioHijo.Activate();
					return true;
				}

			return false;
		}

		#endregion
	}
}
