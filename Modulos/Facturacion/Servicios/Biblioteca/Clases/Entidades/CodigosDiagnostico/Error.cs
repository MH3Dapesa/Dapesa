using System.Configuration;

namespace Dapesa.Facturacion.Servicios.Entidades.CodigosDiagnostico
{
	public class Error : ConfigurationElement
	{
		#region Propiedades

		[ConfigurationProperty("codigo", DefaultValue="0", IsKey=true, IsRequired=true)]
		[IntegerValidator(ExcludeRange=false, MaxValue=999, MinValue=0)]
		public int Codigo
		{
			get
			{
				return (int)this["codigo"];
			}
			set
			{
				this["codigo"] = value;
			}
		}

		[ConfigurationProperty("mensaje", DefaultValue="No definido", IsRequired=true)]
		[StringValidator(InvalidCharacters="~!@#$%^&*'\"|\\", MinLength=0, MaxLength=512)]
		public string Mensaje
		{
			get
			{
				return (string)this["mensaje"];
			}
			set
			{
				this["mensaje"] = value;
			}
		}

		[ConfigurationProperty("flujoAccion")]
		public FlujoAccion FlujoAccion
		{
			get
			{
				return (FlujoAccion)this["flujoAccion"];
			}
			set
			{
				this["flujoAccion"] = value;
			}
		}

		#endregion
	}
}
