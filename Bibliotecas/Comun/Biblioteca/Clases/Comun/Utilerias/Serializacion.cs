using System;
using System.Data;
using System.IO;
using System.Xml.Serialization;

namespace Dapesa.Comun.Utilerias
{
	public class Serializacion
	{
		#region Metodos

		public object DeserializarObjeto(string psEntrada, Type poTipo)
		{
			XmlSerializer loDeserializador = new XmlSerializer(poTipo);
			object loResultado = null;

			using (StringReader loLector = new StringReader(psEntrada))
			{
				loResultado = loDeserializador.Deserialize(loLector);
			}
			
			return loResultado;
		}

		public DataTable DeserializarTabla(string psEntrada)
		{
			DataTable loResultado = new DataTable();

			loResultado.ReadXml(new StringReader(psEntrada));
			//Para establecer el estado de las filas a: "Unchanged", 
			//	y así, posteriormente, poder obtener las filas modificadas ("Modified")
			loResultado.AcceptChanges();
			return loResultado;
		}

		public string SerializarObjeto(object poEntrada)
		{
			XmlSerializer loSerializador = new XmlSerializer(poEntrada.GetType());
			string loResultado = string.Empty;

			using (StringWriter loEscritor = new StringWriter())
			{
				loSerializador.Serialize(loEscritor, poEntrada);
				loResultado = loEscritor.ToString();
			}

			return loResultado;
		}

		public string SerializarTabla(DataTable poEntrada)
		{
			string loResultado = string.Empty;

			using (StringWriter loEscritor = new StringWriter())
			{

				if (string.IsNullOrEmpty(poEntrada.TableName))
					poEntrada.TableName = "Resultado";

				poEntrada.WriteXml(loEscritor, XmlWriteMode.WriteSchema);
				loResultado = loEscritor.ToString();
			}

			return loResultado;
		}

		#endregion
	}
}
