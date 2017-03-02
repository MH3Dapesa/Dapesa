using Dapesa.Comun.Informes.Credito.Reglas;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using AjaxControlToolkit;
using System.Collections.Specialized;



namespace Dapesa.Comun.Informes.Credito.IU.ReportesCredito
{
    /// <summary>
    /// DropDown Asíncrono
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
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
        [WebMethod(Description = "Devuelve el catálogo de sucursales", EnableSession = true)]
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
        /// Devuelve el catálogo de gestores
        /// </summary>
        /// <param name="knownCategoryValues">Conjunto de campos llave del catálogo de sucursales</param>
        /// <param name="category" />
        /// <returns>El catálogo de gestores de una sucursal en particular</returns>
        [WebMethod(Description = "Devuelve el catálogo de gestores de una sucursal en particular", EnableSession = true)]
        [ScriptMethod]
        public CascadingDropDownNameValue[] ObtenerGestores(string knownCategoryValues, string category)
        {
            StringDictionary loSucursales = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            int lnClaveSucursal = 0;

            if (!loSucursales.ContainsKey("CLAVE") || !int.TryParse(loSucursales["CLAVE"], out lnClaveSucursal))
                return null;

            Catalogos loCatalogos = new Catalogos();
            DataTable loGestores = loCatalogos.ObtenerGestores((Sesion)HttpContext.Current.Session["Sesion"], lnClaveSucursal.ToString(), 0);

            return (
                from DataRow loGestor in loGestores.Rows
                select new CascadingDropDownNameValue(
                    loGestor["DESCRIPCION"].ToString(),
                    loGestor["CLAVE"].ToString()
                )
            ).ToArray();
        }

        /// <summary>
        /// Devuelve el catálogo de auxiliares
        /// </summary>
        /// <param name="knownCategoryValues">Conjunto de campos llave del catálogo de auxiliares</param>
        /// <param name="category" />
        /// <returns>El catálogo de auxiliares de una sucursal en particular</returns>
        [WebMethod(Description = "Devuelve el catálogo de auxiliares de una sucursal en particular", EnableSession = true)]
        [ScriptMethod]
        public CascadingDropDownNameValue[] ObtenerAuxiliares(string knownCategoryValues, string category)
        {
            StringDictionary loSucursales = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            int lnClaveSucursal = 0;

            if (!loSucursales.ContainsKey("CLAVE") || !int.TryParse(loSucursales["CLAVE"], out lnClaveSucursal))
                return null;

            Catalogos loCatalogos = new Catalogos();
            DataTable loAuxiliares = loCatalogos.ObtenerAuxiliares((Sesion)HttpContext.Current.Session["Sesion"], lnClaveSucursal.ToString(), 0);

            return (
                from DataRow loAuxiliar in loAuxiliares.Rows
                select new CascadingDropDownNameValue(
                    loAuxiliar["DESCRIPCION"].ToString(),
                    loAuxiliar["CLAVE"].ToString()
                )
            ).ToArray();
        }
        #endregion
    }
}
