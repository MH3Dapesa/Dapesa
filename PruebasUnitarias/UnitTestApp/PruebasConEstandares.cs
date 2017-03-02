using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dapesa.UnitTestApp
{
	[TestClass]
	public class PruebasConEstandares
	{
		#region Constructor

		public PruebasConEstandares()
		{

		}

		#endregion

		#region Metodos

		[TestMethod]
		public void RealizarTest()
		{
			double lnAcumuladoSalarios = 0;
			double[] lnSalarios = new double[] { 1, 2, 3, 4, 5, 6 };

			for (int indiceSalarios = 0; indiceSalarios < lnSalarios.Length; indiceSalarios++)
			{
				lnAcumuladoSalarios += lnSalarios[indiceSalarios];
			}
				
			Console.WriteLine("ACUMULADO = " + lnAcumuladoSalarios);
		}

		#endregion
	}
}
