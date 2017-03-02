using System;

namespace Dapesa.Ventas.Telemarketing.Comun
{
	public class ArgumentosEvento : EventArgs
	{
		#region Constructor
			
		public ArgumentosEvento(string psTexto)
		{
			this.Texto = psTexto;
		}

		#endregion

		#region Propiedades

		public string Texto { get; set; }

		#endregion
	}
}
