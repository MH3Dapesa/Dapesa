using System;
using System.Configuration;

namespace Dapesa.Facturacion.Servicios.Entidades.CodigosDiagnostico
{
	[ConfigurationCollection(typeof(Error))]
	public class Errores : ConfigurationElementCollection
	{
		#region Atributos

		internal const string PROPERTY_NAME = "error";

		#endregion

		#region Propiedades

		public override ConfigurationElementCollectionType CollectionType
		{
			get
			{
				return ConfigurationElementCollectionType.BasicMapAlternate;
			}
		}

		protected override string ElementName
		{
			get
			{
				return Errores.PROPERTY_NAME;
			}
		}

		public Error this[int index]
		{
			get
			{
				return (Error)BaseGet(index);
			}
		}

		#endregion

		#region Metodos

		protected override ConfigurationElement CreateNewElement()
		{
			return new Error();
		}

		protected override object GetElementKey(ConfigurationElement poElemento)
		{
			return ((Error)poElemento).Codigo;
		}

		protected override bool IsElementName(string psNombreElemento)
		{
			return psNombreElemento.Equals(Errores.PROPERTY_NAME, StringComparison.InvariantCultureIgnoreCase);
		}

		public override bool IsReadOnly()
		{
			return false;
		}

		#endregion
	}
}
