using System.Configuration;

namespace Dapesa.Facturacion.Servicios.Entidades.CodigosDiagnostico
{
	public class FlujoAccion : ConfigurationElement
	{
		#region Propiedades

		[ConfigurationProperty("tipo", DefaultValue="0", IsRequired=true)]
		[IntegerValidator(ExcludeRange=false, MaxValue=99, MinValue=0)]
		public int Tipo
		{
			get
			{
				return (int)this["tipo"];
			}
			set
			{
				this["tipo"] = value;
			}
		}

		[ConfigurationProperty("horasValidez", DefaultValue="0", IsRequired=false)]
		[IntegerValidator(ExcludeRange=false, MaxValue=24, MinValue=0)]
		public int HorasValidez
		{
			get
			{
				return (int)this["horasValidez"];
			}
			set
			{
				this["horasValidez"] = value;
			}
		}

		[ConfigurationProperty("reportar", DefaultValue="false", IsRequired=false)]
		public bool Reportar
		{
			get
			{
				return (bool)this["reportar"];
			}
			set
			{
				this["reportar"] = value;
			}
		}

		#endregion
	}
}
