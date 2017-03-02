using AjaxControlToolkit;
using Ventas.Pedidos.BackOrder.Reglas;
using Dapesa.Seguridad.Entidades;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Ventas.Pedidos.BackOrder.UI.Pedidos
{
	/// <summary>
	/// DropDown Asíncrono
	/// </summary>
	[WebService(Namespace="http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	[ScriptService]
	public class DropDownAsincrono : WebService
	{
		#region Metodos-Web

		/// <summary>
		/// Devuelve el catálogo de sucursales
		/// </summary>
		/// <param name="knownCategoryValues" />
		/// <param name="category" />
		/// <returns>El catálogo de sucursales</returns>
		[WebMethod(Description="Devuelve el catálogo de sucursales",EnableSession=true)]
		[ScriptMethod]
		public CascadingDropDownNameValue[] ObtenerSucursales(string knownCategoryValues, string category)
		{
			Catalogos loCatalogos = new Catalogos();
			DataTable loSucursales = loCatalogos.ObtenerSucursales((Sesion)HttpContext.Current.Session["Sesion"], 0);

			return (
				from DataRow loSucursal in loSucursales.Rows
				select new CascadingDropDownNameValue(
					loSucursal["DESCRIPCION"].ToString(),
					loSucursal["CLAVE"].ToString()
				)
			).ToArray();
		}
        /// <summary>
        /// Devuelve el catálogo de marcas
        /// </summary>
        /// <param name="knownCategoryValues" />
        /// <param name="category" />
        /// <returns>El catálogo de marca</returns>
        [WebMethod(Description = "Devuelve el catálogo de marcas", EnableSession = true)]
        [ScriptMethod]
        public CascadingDropDownNameValue[] ObtenerMarcas(string knownCategoryValues, string category)
        {
            Catalogos loCatalogos = new Catalogos();
            DataTable loMarca = loCatalogos.ObtenerMarcas((Sesion)HttpContext.Current.Session["Sesion"], 0);

            return (
                from DataRow loSucursal in loMarca.Rows
                select new CascadingDropDownNameValue(
                    loSucursal["DESCRIPCION"].ToString(),
                    loSucursal["CLAVE"].ToString()
                )
            ).ToArray();
        }
        /// <summary>
        /// Devuelve el catálogo de vendedores
        /// </summary>
        /// <param name="knownCategoryValues">Conjunto de campos llave del catálogo de sucursales</param>
        /// <param name="category" />
        /// <returns>El catálogo de vendedores de una sucursal en particular</returns>
        [WebMethod(Description = "Devuelve el catálogo de vendedores de una sucursal en particular", EnableSession = true)]
        [ScriptMethod]
        public CascadingDropDownNameValue[] ObtenerVendedores(string knownCategoryValues, string category)
        {
            StringDictionary loSucursales = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            int lnClaveSucursal = 0;

            if (!loSucursales.ContainsKey("CLAVE") || !int.TryParse(loSucursales["CLAVE"], out lnClaveSucursal))
                return null;

            Catalogos loCatalogos = new Catalogos();
            DataTable loVendedores = loCatalogos.ObtenerVendedores((Sesion)HttpContext.Current.Session["Sesion"], lnClaveSucursal.ToString(), 0, 1);

            return (
                from DataRow loVendedor in loVendedores.Rows
                select new CascadingDropDownNameValue(
                    loVendedor["DESCRIPCION"].ToString(),
                    loVendedor["CLAVE"].ToString()
                )
            ).ToArray();
        }
        /// <summary>
        /// Devuelve el catálogo de líneas de artículos
        /// </summary>
        /// <param name="knownCategoryValues">Conjunto de campos llave del catálogo de marcas</param>
        /// <param name="category" />
        /// <returns>El catálogo de líneas de una marca en particular</returns>
        [WebMethod(Description = "Devuelve el catálogo de lineas de una marca en particular", EnableSession = true)]
        [ScriptMethod]
        public CascadingDropDownNameValue[] ObtenerLineas(string knownCategoryValues, string category)
        {
            StringDictionary loSucursales = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            int lnCveMarca = 0;

            if (!loSucursales.ContainsKey("CLAVE") || !int.TryParse(loSucursales["CLAVE"], out lnCveMarca))
                return null;

            Catalogos loCatalogos = new Catalogos();
            DataTable loLineas = loCatalogos.ObtenerLineasArticulos((Sesion)HttpContext.Current.Session["Sesion"], lnCveMarca, 0);
            return (
                from DataRow loLinea in loLineas.Rows
                select new CascadingDropDownNameValue(
                    loLinea["DESCRIPCION"].ToString(),
                    loLinea["CLAVE"].ToString()
                )
            ).ToArray();
        }
		#endregion
	}
}

