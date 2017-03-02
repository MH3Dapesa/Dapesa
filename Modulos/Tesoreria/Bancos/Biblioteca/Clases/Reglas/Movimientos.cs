using Dapesa.Seguridad.Entidades;
using Dapesa.Tesoreria.Bancos.Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dapesa.Tesoreria.Bancos.Reglas
{
    public class Movimientos
    {
        public DataTable ObtenerSucursalBanamex(Sesion poSesion, string psReferenciaBancaria)
        {
            HelperMovimientos loHelper = new HelperMovimientos();
            return loHelper.ObtenerSucursalBanamex(poSesion, psReferenciaBancaria);
        }

        public DataTable ObtenerSucursal(Sesion poSesion, string psReferenciaBancaria)
        {
            HelperMovimientos loHelper = new HelperMovimientos();
            return loHelper.ObtenerSucursal(poSesion, psReferenciaBancaria);
        }

        public DataTable ObtenerFormaDePagoBanamex(Sesion poSesion, string psFormaDePago)
        {
            HelperMovimientos loHelper = new HelperMovimientos();
            return loHelper.ObtenerFormaDePagoBanamex(poSesion, psFormaDePago);
        }

        public DataTable ObtenerFormaDePago(Sesion poSesion, string psFormaDePago)
        {
            HelperMovimientos loHelper = new HelperMovimientos();
            return loHelper.ObtenerFormaDePago(poSesion, psFormaDePago);
        }

        public DataTable ValidaCobro(Sesion poSesion, string psNumTransaccion, DateTime pdtFecha)
        {
            HelperMovimientos loHelper = new HelperMovimientos();
            return loHelper.ValidaCobro(poSesion, psNumTransaccion, pdtFecha);
        }

        public bool InsertarCobroSIIL(Sesion poSesion, string psFechaAbono ,decimal pdTotal, string psNombreBanco,
            int piFormaPagoCobro, string psClaveCliente, int piSucursal)
        {
            HelperMovimientos loHelper = new HelperMovimientos();
            return loHelper.InsertarCobroSIIL(poSesion, psFechaAbono, pdTotal, psNombreBanco, 
                piFormaPagoCobro, psClaveCliente, piSucursal);
        }

        public bool InsertaCobroTablaDAP(Sesion poSesion, DataTable loMovimientos, string psArchivo, int psBanco)
        {
            HelperMovimientos loHelper = new HelperMovimientos();
            List<RegistroCobro> loCobro = new List<RegistroCobro>();

            foreach (DataRow loFila in loMovimientos.Rows)
                loCobro.Add(new RegistroCobro()
                {
                    #region Inicializar propiedades

                    NumTransaccion = loFila["Autorizacion"].ToString(),
                    RefNumerica = loFila["Ref_Numerica"].ToString(),
                    RefAlfanumerica = loFila["Ref_Alfanumerica"].ToString(),
                    Abono = Convert.ToDecimal(loFila["Depositos"].ToString().Replace(",","")),
                    Banco = psBanco,
                    Archivo = psArchivo,
                    FechaAbono = loFila["Fecha"].ToString(),
                    FormaPago = int.Parse(loFila["Forma_Pago"].ToString()),
                    SucBanco = loFila["Suc"].ToString(),
                    StatusTransaccion = loFila["Status"].ToString()

                    #endregion initialize
                });
            return loHelper.InsertaCobroTablaDAP(poSesion, loCobro);
        }

        public bool InsertaCobroBancomerTablaDAP(Sesion poSesion, DataTable loMovimientos, string psArchivo, int psBanco)
        {
            HelperMovimientos loHelper = new HelperMovimientos();
            List<RegistroCobro> loCobro = new List<RegistroCobro>();

            foreach (DataRow loFila in loMovimientos.Rows)
                loCobro.Add(new RegistroCobro()
                {
                    #region Inicializar propiedades

                    NumTransaccion = loFila["Guia_CIE"].ToString(),
                    RefNumerica = loFila["Referencia"].ToString(),
                    RefAlfanumerica = loFila["Concepto"].ToString(),
                    Abono = Convert.ToDecimal(loFila["Importe"].ToString().Replace(",", "")),
                    Banco = psBanco,
                    Archivo = psArchivo,
                    FechaAbono = loFila["Fecha"].ToString(),
                    FormaPago = int.Parse(loFila["Forma_Pago"].ToString()),
                    //SucBanco = loFila["Suc"].ToString(),
                    StatusTransaccion = loFila["Status"].ToString()

                    #endregion initialize
                });
            return loHelper.InsertaCobroTablaDAP(poSesion, loCobro);
        }

        public bool InsertaCobroSantanderTablaDAP(Sesion poSesion, DataTable loMovimientos, string psArchivo, int psBanco)
        {
            HelperMovimientos loHelper = new HelperMovimientos();
            List<RegistroCobro> loCobro = new List<RegistroCobro>();

            foreach (DataRow loFila in loMovimientos.Rows)
                loCobro.Add(new RegistroCobro()
                {
                    #region Inicializar propiedades

                    NumTransaccion = loFila["Referencia"].ToString(),
                    RefNumerica = loFila["Concepto_ref_bancaria"].ToString(),
                    //RefAlfanumerica = loFila["Concepto"].ToString(),
                    Abono = Convert.ToDecimal(loFila["Importe"].ToString().Replace(",", "")),
                    Banco = psBanco,
                    Archivo = psArchivo,
                    FechaAbono = loFila["Fecha"].ToString(),
                    FormaPago = int.Parse(loFila["Forma_Pago"].ToString()),
                    SucBanco = loFila["Suc_banco"].ToString(),
                    StatusTransaccion = loFila["Status"].ToString()

                    #endregion initialize
                });
            return loHelper.InsertaCobroTablaDAP(poSesion, loCobro);
        }

        public bool InsertaCobroBanorteTablaDAP(Sesion poSesion, DataTable loMovimientos, string psArchivo, int psBanco)
        {
            HelperMovimientos loHelper = new HelperMovimientos();
            List<RegistroCobro> loCobro = new List<RegistroCobro>();

            foreach (DataRow loFila in loMovimientos.Rows)
                loCobro.Add(new RegistroCobro()
                {
                    #region Inicializar propiedades

                    NumTransaccion = loFila["Folio_pago"].ToString(),
                    RefNumerica = loFila["Referencia1"].ToString(),
                    //RefAlfanumerica = loFila["Concepto"].ToString(),
                    Abono = Convert.ToDecimal(loFila["Importe_Neto"].ToString().Replace("$", "").Replace(",", "")),
                    Banco = psBanco,
                    Archivo = psArchivo,
                    FechaAbono = loFila["Fecha_pago"].ToString(),
                    FormaPago = int.Parse(loFila["Forma_Pago"].ToString()),
                    SucBanco = loFila["Suc_banco"].ToString(),
                    StatusTransaccion = loFila["Status"].ToString()

                    #endregion initialize
                });
            return loHelper.InsertaCobroTablaDAP(poSesion, loCobro);
        }
    }
}
