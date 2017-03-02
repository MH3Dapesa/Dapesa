using AjaxControlToolkit;
using Dapesa.Comun.Informes.Reglas;
using Dapesa.Seguridad.Entidades;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Dapesa.Comun.Informes.IU.Reporteador
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
		/// Devuelve el catálogo de telemarketings
		/// </summary>
		/// <param name="knownCategoryValues">Conjunto de campos llave del catálogo de sucursales</param>
		/// <param name="category" />
		/// <returns>El catálogo de telemarketings de una sucursal en particular</returns>
		[WebMethod(Description="Devuelve el catálogo de telemarketings de una sucursal en particular",EnableSession=true)]
		[ScriptMethod]
		public CascadingDropDownNameValue[] ObtenerTelemarketings(string knownCategoryValues, string category)
		{
			StringDictionary loSucursales = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
			int lnClaveSucursal = 0;

			if (!loSucursales.ContainsKey("CLAVE") || !int.TryParse(loSucursales["CLAVE"], out lnClaveSucursal))
				return null;

			Catalogos loCatalogos = new Catalogos();
			DataTable loTelemarketings = loCatalogos.ObtenerTelemarketings((Sesion)HttpContext.Current.Session["Sesion"], lnClaveSucursal.ToString(), 0);

			return (
				from DataRow loTelemarketing in loTelemarketings.Rows
				select new CascadingDropDownNameValue (
					loTelemarketing["DESCRIPCION"].ToString(),
					loTelemarketing["CLAVE"].ToString()
				)
			).ToArray();
		}

		/// <summary>
		/// Devuelve el catálogo de vendedores
		/// </summary>
		/// <param name="knownCategoryValues">Conjunto de campos llave del catálogo de sucursales</param>
		/// <param name="category" />
		/// <returns>El catálogo de vendedores de una sucursal en particular</returns>
		[WebMethod(Description="Devuelve el catálogo de vendedores de una sucursal en particular",EnableSession=true)]
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
				select new CascadingDropDownNameValue (
					loVendedor["DESCRIPCION"].ToString(),
					loVendedor["CLAVE"].ToString()
				)
			).ToArray();
		}

        /// <summary>
        /// Devuelve el catálogo de vendedores
        /// </summary>
        /// <param name="knownCategoryValues">Conjunto de campos llave del catálogo de sucursales</param>
        /// <param name="category" />
        /// <returns>El catálogo de vendedores y telemarketing de una sucursal en particular</returns>
        [WebMethod(Description = "Devuelve el catálogo de vendedores y telemarketing de una sucursal en particular", EnableSession = true)]
        [ScriptMethod]
        public CascadingDropDownNameValue[] ObtenerVendedoresTlmk(string knownCategoryValues, string category)
        {
            StringDictionary loSucursales = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            int lnClaveSucursal = 0;

            if (!loSucursales.ContainsKey("CLAVE") || !int.TryParse(loSucursales["CLAVE"], out lnClaveSucursal))
                return null;

            Catalogos loCatalogos = new Catalogos();
            DataTable loVendedores = loCatalogos.ObtenerVendedoresTlmk((Sesion)HttpContext.Current.Session["Sesion"], lnClaveSucursal.ToString(), 1, 1);

            return (
                from DataRow loVendedor in loVendedores.Rows
                select new CascadingDropDownNameValue(
                    loVendedor["DESCRIPCION"].ToString(),
                    loVendedor["CLAVE"].ToString()
                )
            ).ToArray();
        }



        ///// <summary>
        ///// Devuelve el catálogo de Personal relacionado con Vendedores
        ///// </summary>
        ///// <param name="knownCategoryValues">Conjunto de campos llave de Vendedores</param>
        ///// <param name="category" />
        ///// <returns>El catálogo de Perasonas  de un vendedore en particular</returns>
        //[WebMethod(Description = "Devuelve el catálogo de Personas de un Vendedor en particular", EnableSession = true)]
        //[ScriptMethod]
        //public CascadingDropDownNameValue[] ObtenerPersonasVendedores(string knownCategoryValues)
        //{
        //    StringDictionary loSucursales = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        //    StringDictionary loVendedores = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        //    int lnClaveVendedor = 0;
        //    int lnClaveSucursal = 0;
        //    if (!loVendedores.ContainsKey("CLAVE1") || !int.TryParse(loVendedores["CLAVE1"], out lnClaveVendedor))
        //      return null;

             
        //    Catalogos loCatalogos = new Catalogos();
        //    DataTable loComodines = loCatalogos.ObtenerVendedoresComodines((Sesion)HttpContext.Current.Session["Sesion"],lnClaveSucursal,lnClaveVendedor);
        //    return (
        //        from DataRow loCliente in loComodines.Rows
        //        select new CascadingDropDownNameValue(
        //            loCliente["RAZON_SOCIAL"].ToString() + " (" + loCliente["CLAVE"].ToString() + ")",
        //            loCliente["CLAVE"].ToString()
        //        )
        //    ).ToArray();

        //}


        ///// <summary>
        ///// Devuelve el catálogo de clientes (Método desabilitado por solicitud del Área de Ventas)
        ///// </summary>
        ///// <param name="knownCategoryValues">Conjunto de campos llave del clientes de sucursales</param>
        ///// <param name="category" />
        ///// <returns>El catálogo de clientes de una sucursal en particular</returns>
        //[WebMethod(Description = "Devuelve el catálogo de clientes de una sucursal en particular", EnableSession = true)]
        //[ScriptMethod]
        //public CascadingDropDownNameValue[] ObtenerClientesSucursal(string knownCategoryValues, string category)
        //{
        //    StringDictionary loSucursales = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        //    int lnClaveSucursal = 0;
            
        //    if (!loSucursales.ContainsKey("CLAVE") || !int.TryParse(loSucursales["CLAVE"], out lnClaveSucursal))
        //        return null;

        //    Catalogos loCatalogos = new Catalogos();
        //    DataTable loClientes = loCatalogos.ObtenerClientes((Sesion)HttpContext.Current.Session["Sesion"], 1, 0, lnClaveSucursal, 0);
        //    return (
        //        from DataRow loCliente in loClientes.Rows
        //        select new CascadingDropDownNameValue(
        //            loCliente["RAZON_SOCIAL"].ToString() + " (" + loCliente["CLAVE"].ToString() + ")",
        //            loCliente["CLAVE"].ToString()
        //        )
        //    ).ToArray();
            
        //}

        ///// <summary>
        ///// Devuelve el catálogo de clientes (Método deshabilitado por solicitud del Área de Ventas)
        ///// </summary>
        ///// <param name="knownCategoryValues">Conjunto de campos llave del clientes de sucursales y vendedor</param>
        ///// <param name="category" />
        ///// <returns>El catálogo de clientes de una sucursal y vendedor en particular</returns>
        //[WebMethod(Description = "Devuelve el catálogo de clientes de una sucursal y vendedor en particular", EnableSession = true)]
        //[ScriptMethod]
        //public CascadingDropDownNameValue[] ObtenerClientesVendedores(string knownCategoryValues, string category)
        //{
        //    StringDictionary loVendedores = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        //    int lnClaveSucursal = 0;
        //    int lnClaveVendedor = 0;
        //    int lnIndicador_Cve=0;
        //    if (!loVendedores.ContainsKey("CLAVE") || !int.TryParse(loVendedores["CLAVE"], out lnClaveSucursal))
        //    {
        //        return null;
        //    }
        //    else if (!loVendedores.ContainsKey("CLAVE1") || !int.TryParse(loVendedores["CLAVE1"], out lnClaveVendedor))
        //        return null;
        //    else if (int.Parse(loVendedores["CLAVE1"]) != 0) {
        //        lnIndicador_Cve = 1;
        //    }

        //    Catalogos loCatalogos = new Catalogos();
        //    DataTable loClientes = loCatalogos.ObtenerClientes((Sesion)HttpContext.Current.Session["Sesion"], 1, lnIndicador_Cve, lnClaveSucursal, lnClaveVendedor);
        //    return (
        //        from DataRow loCliente in loClientes.Rows
        //        select new CascadingDropDownNameValue(
        //            loCliente["RAZON_SOCIAL"].ToString() + " (" + loCliente["CLAVE"].ToString() + ")",
        //            loCliente["CLAVE"].ToString()
        //        )
        //    ).ToArray();
        //}





		#endregion
	}
}
