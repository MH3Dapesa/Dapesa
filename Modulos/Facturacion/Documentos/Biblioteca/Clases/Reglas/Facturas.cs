using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
namespace Dapesa.Facturacion.Documentos.Reglas
{
    public class Facturas
    {

        public DataTable ObtenerFoliosFacturas(Sesion poSesion, string pnNumeroFactura, string poFechaFactura)
        {
            HelperFacturas loHelper = new HelperFacturas();
            return loHelper.ObtenerFoliosFacturas(poSesion, pnNumeroFactura, poFechaFactura);
        }

        public DataTable ObtenerFacturas(Sesion poSesion, string pnNumeroFactura)
        {
            HelperFacturas loHelper = new HelperFacturas();
            return loHelper.ObtenerFacturas(poSesion, pnNumeroFactura);
        }
        public DataTable ObtenerSucursal(Sesion poSesion)
        {
            HelperFacturas loHelper = new HelperFacturas();
            return loHelper.ObtenerSucursal(poSesion);
        }
    }
}
