using System.Configuration;

namespace Dapesa.Facturacion.Servicios.Entidades.CodigosDiagnostico
{
	public class CodigosError : ConfigurationSection
	{
		#region Propiedades

		[ConfigurationProperty("errores")]
		public Errores Errores
		{
			get 
			{
				return (Errores)base["errores"];
			}
			set 
			{ 
				base["errores"] = value;
			}
		}

		#endregion
	}
}
