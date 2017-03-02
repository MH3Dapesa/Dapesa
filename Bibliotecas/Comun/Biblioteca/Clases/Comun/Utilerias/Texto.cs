using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace Dapesa.Comun.Utilerias
{
	public class Texto
	{
		#region Metodos

		/// <summary>
		/// Elimina caracteres unicode no-ASCII y no-imprimibles, y divide la entrada en campos
		/// </summary>
		/// <param name="psEntrada">Entrada a procesar</param>
		/// <param name="psSeparador">Caracter separador de campos</param>
		/// <param name="pbSustituirCaracteres">Indicador de eliminación de caracteres unicode</param>
		/// <returns>Arreglo de cadenas que contiene los campos que conforman la entrada</returns>
		public string[] FormatearDividir(string psEntrada, string psSeparador, bool pbSustituirCaracteres)
		{
			string lsResultado = (pbSustituirCaracteres) ? Regex.Replace(psEntrada, @"[^\u0000-\u007F]", "") : psEntrada;
			string lsAuxiliar = string.Empty;
			int lnIndice = lsResultado.IndexOf('"');

			while (lnIndice > 0)
			{
				lsAuxiliar = lsResultado.Substring(lnIndice + 1);
				lnIndice = lsAuxiliar.IndexOf('"');
				lsAuxiliar = lsAuxiliar.Substring(0, lnIndice);
				lsResultado = lsResultado.Replace('"' + lsAuxiliar + '"', lsAuxiliar.Replace(",", "").Replace("$", ""));
				lnIndice = lsResultado.IndexOf('"');
			}

			return lsResultado.Split(psSeparador[0]);
		}

		/// <summary>
		/// Constryu un stream de texto, a partir del contenido de un DataTable donde, cada línea, 
		///		representa una secuencia de campos
		/// </summary>
		/// <param name="poEntrada">DataTable de entrada</param>
		/// <param name="pnIndiceCampoInicio">Indice del campo a partir del cuál se construirá cada secuencia</param>
		/// <param name="pbEncomillarEntrada">Indica si la secuencia debe ir, o no, entre comillas</param>
		/// <returns>Conjunto de secuencias que representan los campos que conforman la entrada</returns>
		public string Unir(DataTable poEntrada, int pnIndiceCampoInicio, bool pbEncomillarEntrada)
		{
			StringBuilder loResultado = new StringBuilder();

			foreach (DataRow loItem in poEntrada.Rows)
			{
				string lsEntrada = string.Empty;

				for (int i = pnIndiceCampoInicio; i < loItem.ItemArray.Length; i++)
					lsEntrada += lsEntrada == string.Empty ? loItem.ItemArray[i].ToString() : "," + loItem.ItemArray[i].ToString();

				loResultado.AppendLine((pbEncomillarEntrada) ? "\"" + lsEntrada + "\"" : lsEntrada);
			}

			return loResultado.ToString();
		}

		#endregion
	}
}
