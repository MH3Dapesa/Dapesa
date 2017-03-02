using Dapesa.Documentos.XML.Comun;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace Dapesa.Documentos.XML.Reglas
{
	public class Iterador : Documento, IDocumento
	{
		#region Constructor

		public Iterador(string psDocumento)
			: base(psDocumento)
		{

		}

		#endregion

		#region Metodos

		public IList<string> ObtenerAtributo(string psNombreElemento, string psNombreAtributo, Definiciones.TipoSalida poTipoSalida)
		{
			IList<string> loValores = new List<string>();

			try
			{

				using (XmlTextReader loLector = new XmlTextReader(base._sDocumento))
				{
					loLector.WhitespaceHandling = WhitespaceHandling.None;

					while (loLector.Read())
					{

						if (loLector.NodeType != XmlNodeType.Element)
							continue;

						if (loLector.LocalName == psNombreElemento)

							while (loLector.MoveToNextAttribute())

								if (loLector.Name == psNombreAtributo)
								{
									loValores.Add(loLector.Value);

									if (poTipoSalida == Definiciones.TipoSalida.Simple)
										break;
								}
					}
				}
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}

			return loValores;
		}

		public IList<string> ObtenerElemento(string psNombreElemento, Definiciones.TipoSalida poTipoSalida)
		{
			IList<string> loValores = new List<string>();

			try
			{

				using (XmlTextReader loLector = new XmlTextReader(base._sDocumento))
				{
					loLector.WhitespaceHandling = WhitespaceHandling.None;

					while (loLector.Read())
					{

						if (loLector.NodeType != XmlNodeType.Element)
							continue;

						if (loLector.LocalName == psNombreElemento && !loLector.IsEmptyElement)
						{
							XElement loNodo = (XElement)XNode.ReadFrom(loLector);

							if (loNodo.HasElements)
								
								foreach (XElement loElemento in loNodo.Elements())
									loValores.Add(loElemento.ToString());
							else
								loValores.Add(loNodo.Value);

							if (poTipoSalida == Definiciones.TipoSalida.Simple)
								break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new Excepcion(ex.Message, ex);
			}

			return loValores;
		}

		#endregion
	}
}
