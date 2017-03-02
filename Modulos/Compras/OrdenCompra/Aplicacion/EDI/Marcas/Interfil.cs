using Dapesa.Compras.OrdenCompra.Entidades;
using System;
using System.IO;
using System.Text;
using Dapesa.Compras.OrdenCompra.Comun;
using System.Configuration;
using System.Data;
using System.Collections.Generic;

namespace Dapesa.Compras.OrdenCompra.IU.EDI.Marcas
{
    internal class Interfil
    {
        private string GenerarTextoPlano(DataTable loOrdenCompra, int lnSucursal)
        {
            #region Secciones

            Registro.RoutingInterno loRoutingInterno = new Registro.RoutingInterno();
            Registro.Orden loOrden = new Registro.Orden();
            Registro.Divisas loDivisas = new Registro.Divisas();
            Registro.TipodeReferencia loTipodeReferencia = new Registro.TipodeReferencia();
            Registro.ContactosAdmin loContactosAdmin = new Registro.ContactosAdmin();
            Registro.FrancoaBordo loFrancoaBordo = new Registro.FrancoaBordo();
            Registro.RequisitosdeVentas loRequisitosdeVentas = new Registro.RequisitosdeVentas();
            Registro.ConcesionesYCobros loConcesionesYCobros = new Registro.ConcesionesYCobros();
            Registro.TerminosdeVenta loTerminosdeVenta = new Registro.TerminosdeVenta();
            Registro.FechasdeOrden loFechasdeOrden = new Registro.FechasdeOrden();
            Registro.RoutingdePortador loRoutingdePortador = new Registro.RoutingdePortador();
            Registro.ReferenciasdeOrden loReferenciasdeOrden = new Registro.ReferenciasdeOrden();
            Registro.MensajesdeOrden loMensajesdeOrden =  new Registro.MensajesdeOrden();
            Registro.ParteContractuante loParteContractuante = new Registro.ParteContractuante();
            Registro.AnadirNombreParteContr loAnadirNombreParteContr =  new Registro.AnadirNombreParteContr();
            Registro.DireccionParteContr loDireccionParteContr = new Registro.DireccionParteContr();
            Registro.UbicacionParteContr loUbicacionParteContr = new Registro.UbicacionParteContr();
            Registro.ReferenciasParteContr loReferenciasParteContr = new Registro.ReferenciasParteContr();
            Registro.ContactosParteContr loContactosParteContr = new Registro.ContactosParteContr();
            Registro.Articulos loArticulos = new Registro.Articulos();
            Registro.DescripcionArticulos loDescripcionArticulos = new Registro.DescripcionArticulos();
            Registro.DetallesFisicosArticulos loDetallesFisicosArticulos = new Registro.DetallesFisicosArticulos();
            Registro.CTT loCTT = new Registro.CTT();
            #endregion
            #region Asinacion a los atributos 
            loRoutingInterno.ValorRoutingInterno="IRR";
            loRoutingInterno.CalificativoEnviador = "12";
            loRoutingInterno.IDRemitente = ConfigurationManager.AppSettings["Telefono"+lnSucursal];
            loRoutingInterno.CalificativoDestinatario = "01";
            loRoutingInterno.IDDestinatario = ConfigurationManager.AppSettings["TelefonoDestinatario"];
            loOrden.ValorOrden = "ORD";
            loOrden.CodigodeIntencion = "00";
            loOrden.CodigodelTipodeOC = "SA";
            loOrden.NumOC = loOrdenCompra.Rows[0]["NUMERO"].ToString();
            loOrden.FechaOC = Convert.ToDateTime(loOrdenCompra.Rows[0]["FECHA"]);
            loDivisas.ValorDivisas = "CUR";
            loDivisas.CodigoIDEntidad = "BY";
            loDivisas.CodigoDivisa = loOrdenCompra.Rows[0]["MONEDA"].ToString();
            loTipodeReferencia.ValorTipodeReferencia = "REF";
            loTipodeReferencia.TipodeReferenciaCodigo = "PG";
            loTipodeReferencia.Referencia = "XYZ";
            loContactosAdmin.ValorContactosAdmin = "PER";
            loContactosAdmin.TipodeContacto = "BD";
            loContactosAdmin.NombredelContacto = loOrdenCompra.Rows[0]["NOMBRE_USUARIO"].ToString();
            loContactosAdmin.CalificativoTelefono = "PH";
            loContactosAdmin.NumerodeTelefono = loOrdenCompra.Rows[0]["TELEFONO"].ToString();
            loContactosAdmin.CalificativoFax = "PX";
            loContactosAdmin.NumerodeFax = loOrdenCompra.Rows[0]["TELEFONO"].ToString();
            loContactosAdmin.CalificativoEmail = "EM";
            loContactosAdmin.Email = loOrdenCompra.Rows[0]["E_MAIL"].ToString();
            loFrancoaBordo.ValorFrancoaBordo = "FOB";
            loFrancoaBordo.MetodoPagoEnvio = "CC";
            loRequisitosdeVentas.ValorRequisitosdeVentas = "CSH";
            loRequisitosdeVentas.CodigodeRequisitosdeVentas = "Y";
            loConcesionesYCobros.ValorConcesionesYCobros = "SAC";
            loTerminosdeVenta.ValorTerminosdeVenta = "ITD";
            loFechasdeOrden.ValorFechasdeOrden = "DTM";
            loRoutingdePortador.ValorRoutingdePortador = "TD5";
            loReferenciasdeOrden.ValorReferenciasdeOrden = "ORE";
            loReferenciasdeOrden.TipodeReferencia = "ZZ";
            loParteContractuante.ValorParteContractuante = "N11";
            loParteContractuante.NombredeParteContr = loOrdenCompra.Rows[0]["SUCURSAL"].ToString();
            loParteContractuante.TipodeParteContr = "ST";
            loParteContractuante.CodigoIDParteContr = "92";
            loParteContractuante.CodigoParteContr = "0" + loOrdenCompra.Rows[0]["SUC_CLAVE"].ToString();
            loArticulos.ValorArticulos = "PO1";
            loArticulos.PrecioUnidadUOM = "PE";
            loArticulos.CodigodePartedelComprador = "BP";
            loArticulos.CalificativoCodigoFabricante = "MF";
            loDescripcionArticulos.ValorDescripcionArticulos = "PID";
            loDescripcionArticulos.TipoDescripcionArticulo = "F";
            loDetallesFisicosArticulos.ValorDetallesFisicosArticulos = "PO4";
            loCTT.ValorCTT = "CTT";
            #endregion
            #region Sección RoutingInterno

            string loEncabezadoRoutingInterno = loRoutingInterno.ValorRoutingInterno
                                             + "," + loRoutingInterno.CalificativoEnviador
                                             + "," + loRoutingInterno.IDRemitente
                                             + "," + loRoutingInterno.CalificativoDestinatario
                                             + "," + loRoutingInterno.IDDestinatario
                                             + "," + loRoutingInterno.NumeroControlIntercambio
                                             + "," + loRoutingInterno.NumeroVersionIntercambio
                                             + "," + loRoutingInterno.PruebaOProduccion
                                             + "," + loRoutingInterno.CodigoIDdelGrupo
                                             + "," + loRoutingInterno.IDdelGrupoRemitente
                                             + "," + loRoutingInterno.IDdelGrupoDestinatario
                                             + "," + loRoutingInterno.FechaGrupo
                                             + "," + loRoutingInterno.HoraGrupo
                                             + "," + loRoutingInterno.GroupControlNumero
                                             + "," + loRoutingInterno.VersionGrupo
                                             + "," + loRoutingInterno.TransSetIDCodigo
                                             + "," + loRoutingInterno.NumeroSetControlTransaccion;
            #endregion
            #region Sección Encabezado
            string loEncabezadoOrden = loOrden.ValorOrden
                                    + "," + loOrden.CodigodeIntencion
                                    + "," + loOrden.CodigodelTipodeOC
                                    + "," + loOrden.NumOC
                                    + "," + loOrden.NumerodeSalida
                                    + "," + loOrden.FechaOC
                                    + "," + loOrden.NumeroContrato;
                                    //+ "," + loOrden.TipodeReconocimiento
                                    //+ "," + loOrden.CodigoTipoContrato
            string loEncabezadoDivisas = loDivisas.ValorDivisas
                                    + "," + loDivisas.CodigoIDEntidad 
                                    + "," + loDivisas.CodigoDivisa;
            string loEncabezadoTipodeReferencia = loTipodeReferencia.ValorTipodeReferencia
                                    + "," + loTipodeReferencia.TipodeReferenciaCodigo
                                    + "," + loTipodeReferencia.Referencia;
                                    //+ "," + loTipodeReferencia.DescripciondeReferencia;
            string loEncabezadoContactosAdmin = loContactosAdmin.ValorContactosAdmin
                                    + "," + loContactosAdmin.TipodeContacto
                                    + "," + loContactosAdmin.NombredelContacto
                                    + "," + loContactosAdmin.CalificativoTelefono
                                    + "," + loContactosAdmin.NumerodeTelefono
                                    + "," + loContactosAdmin.CalificativoFax
                                    + "," + loContactosAdmin.NumerodeFax
                                    + "," + loContactosAdmin.CalificativoEmail
                                    + "," + loContactosAdmin.Email
                                    + ","
                                    + ",";
            string loEncabezadoFrancoaBordo = loFrancoaBordo.ValorFrancoaBordo
                                    + "," + loFrancoaBordo.MetodoPagoEnvio
                                    + "," + loFrancoaBordo.CalificativoUbicacion
                                    + "," + loFrancoaBordo.Descripcion
                                    + "," + loFrancoaBordo.CalificativoTerminosdeTransporte
                                    + "," + loFrancoaBordo.TerminosdeTransporte
                                    + "," + loFrancoaBordo.CalificativoUbicacion2
                                    + "," + loFrancoaBordo.Descripcion2;
                                   // + "," + loFrancoaBordo.CalificativoRiesgodePerdida
                                   // + "," + loFrancoaBordo.DescripcionRiesgodePerdida;
            string loEncabezadoRequisitosdeVentas = loRequisitosdeVentas.ValorRequisitosdeVentas
                                    + "," + loRequisitosdeVentas.CodigodeRequisitosdeVentas
                                    + ","
                                    + ","
                                    + ","
                                    + ","
                                    + ","
                                    + ","
                                    + ","
                                    + ","
                                    + ",";
            string loEncabezadoConcesionesYCobros = loConcesionesYCobros.ValorConcesionesYCobros
                                    + "," + loConcesionesYCobros.Indicador
                                    + "," + loConcesionesYCobros.CodigoSAC
                                    + "," + loConcesionesYCobros.AgencyCodigoQualifier
                                    + "," + loConcesionesYCobros.AgencyServicePromotion
                                    + "," + loConcesionesYCobros.Cantidad
                                    + "," + loConcesionesYCobros.CalificativoPorcentual
                                    + "," + loConcesionesYCobros.PorCiento
                                    + "," + loConcesionesYCobros.TasadeCobro
                                    + "," + loConcesionesYCobros.UOM
                                    + "," + loConcesionesYCobros.Cantidad1
                                    + "," + loConcesionesYCobros.Cantidad2
                                    + "," + loConcesionesYCobros.MetododeProcesamiento
                                    + "," + loConcesionesYCobros.IDReferencia
                                    + "," + loConcesionesYCobros.NumerodeOpcion
                                    + "," + loConcesionesYCobros.Descripcion
                                    + "," + loConcesionesYCobros.CodigoLenguaje;
            string loEncabezadoTerminosdeVenta = loTerminosdeVenta.ValorTerminosdeVenta
                                    + "," + loTerminosdeVenta.CodigoTiposdeTerminos
                                    + "," + loTerminosdeVenta.CodigoFechaenBaseaTerminos
                                    + "," + loTerminosdeVenta.DescuentoPorcentualTerminos
                                    + "," + loTerminosdeVenta.FechadeVencimientoTerminosDescuento
                                    + "," + loTerminosdeVenta.DiaVencimientoTerminosDescuento
                                    + "," + loTerminosdeVenta.FechaVencimientoTerminosNetos
                                    + "," + loTerminosdeVenta.TerminosDiasNetos
                                    + "," + loTerminosdeVenta.TerminosCantidadDescuento
                                    + "," + loTerminosdeVenta.FechaVencimientoTerminosaPlazo
                                    + "," + loTerminosdeVenta.CantidadaPlazoDebida
                                    + "," + loTerminosdeVenta.PorcentofInvoicePayable
                                    + "," + loTerminosdeVenta.Descripcion
                                    + "," + loTerminosdeVenta.DiadelMes
                                    + "," + loTerminosdeVenta.CodigoMetodoPago
                                    + "," + loTerminosdeVenta.PorCiento;
            string loEncabezadoFechasdeOrden = loFechasdeOrden.ValorFechasdeOrden
                                    + "," + loFechasdeOrden.CalificativoFecha
                                    + "," + loFechasdeOrden.Fecha
                                    + "," + loFechasdeOrden.Hora;
            string loEncabezadoRoutingdePortador = loRoutingdePortador.ValorRoutingdePortador
                                    + "," + loRoutingdePortador.CodigoSecuenciaRouting
                                    + "," + loRoutingdePortador.CodigoCalificativoID
                                    + "," + loRoutingdePortador.CodigoID
                                    + "," + loRoutingdePortador.MetododeTransporte
                                    + "," + loRoutingdePortador.Routing
                                    + "," + loRoutingdePortador.Codigo1NivelServicio
                                    + "," + loRoutingdePortador.CodigoServicioNivel2
                                    + "," + loRoutingdePortador.CodigoServicioNivel3
                                    + "," + loRoutingdePortador.CodigoPais;
            #endregion
            #region Sección MSG Loop
            string loMSGLoopReferenciasdeOrden = loReferenciasdeOrden.ValorReferenciasdeOrden
                                    + "," + loReferenciasdeOrden.TipodeReferencia
                                    + "," + loReferenciasdeOrden.Referencia
                                    + "," + loReferenciasdeOrden.RefDescr;
            string loMSGLoopMensajesdeOrden = loMensajesdeOrden.ValorMensajesdeOrden
                                    + "," + loMensajesdeOrden.MensajeTexto;
            #endregion
            #region Sección Loop Partes Contractuantes
            string loLoopPartesContractuantesParteContractuante = loParteContractuante.ValorParteContractuante
                                    + "," + loParteContractuante.TipodeParteContr
                                    + "," + loParteContractuante.NombredeParteContr
                                    + "," + loParteContractuante.CodigoIDParteContr
                                    + "," + loParteContractuante.CodigoParteContr
                                    +",";
            string loLoopPartesContractuantesAnadirNombreParteContr = loAnadirNombreParteContr.ValorAnadirNombreParteContr
                                    + "," + loAnadirNombreParteContr.AnadirNombreParteContr1
                                    + "," + loAnadirNombreParteContr.AnadirNombreParteContr2;
            string loLoopPartesContractuantesDireccionParteContr = loDireccionParteContr.ValorDireccionParteContr
                                    + "," + loDireccionParteContr.Direccion1
                                    + "," + loDireccionParteContr.Direccion2;
            string loLoopPartesContractuantesUbicacionParteContr = loUbicacionParteContr.ValorUbicacionParteContr
                                    + "," + loUbicacionParteContr.Ciudad
                                    + "," + loUbicacionParteContr.Estado
                                    + "," + loUbicacionParteContr.CodigoPostal
                                    + "," + loUbicacionParteContr.Pais
                                    + "," + loUbicacionParteContr.CalificativoUbicacion
                                    + "," + loUbicacionParteContr.IdentificadorUbicacion;
            string loLoopPartesContractuantesReferenciasParteContr = loReferenciasParteContr.ValorReferenciasParteContr
                                    + "," + loReferenciasParteContr.TipoRef
                                    + "," + loReferenciasParteContr.NumeroReferencia;
            string loLoopPartesContractuantesContactosParteContr = loContactosParteContr.ValorContactosParteContr
                                    + "," + loContactosParteContr.TipodeContacto
                                    + "," + loContactosParteContr.NombredeContacto
                                    + "," + loContactosParteContr.CalificadorTelefono
                                    + "," + loContactosParteContr.NumeroTelefono;

            #endregion
            #region Sección LoopArtículos
            string loArticulostxt = string.Empty;
            for (int i = 0; i < loOrdenCompra.Rows.Count; i++)
            {
                loArticulos.NumeroLinea = (i+1).ToString();
                loArticulos.CantidadOrdenada = loOrdenCompra.Rows[i]["CANTIDAD"].ToString();
                loArticulos.CantidadUOM = loOrdenCompra.Rows[i]["UM_CLAVE"].ToString();
                loArticulos.PrecioUnidad = decimal.Parse(loOrdenCompra.Rows[i]["COSTO"].ToString());
                loArticulos.PartedelComprador = loOrdenCompra.Rows[i]["ART_CLAVE"].ToString();
                loDescripcionArticulos.DescripciondeArticulo = loOrdenCompra.Rows[i]["DESCRIPCION_ART"].ToString();
            
                string loLoopArticulos = loArticulos.ValorArticulos
                                    + "," + loArticulos.NumeroLinea
                                    + "," + loArticulos.CantidadOrdenada
                                    + "," + loArticulos.CantidadUOM
                                    + "," + loArticulos.PrecioUnidad
                                    + "," + loArticulos.PrecioUnidadUOM
                                    + "," + loArticulos.CodigodePartedelComprador
                                    + "," + loArticulos.PartedelComprador
                                    + "," + loArticulos.CodigoPartedelVendedor
                                    + "," + loArticulos.PartedelVendedor
                                    + "," + loArticulos.CalificativoNumeroUPC
                                    + "," + loArticulos.NumeroUPC
                                    + "," + loArticulos.CalificativoCodigoFabricante
                                    + "," + loArticulos.CodigoFabricante;
                                    //+ "," + loArticulos.CalificativoOtroCodigo
                                    //+ "," + loArticulos.OtroCodigo;
            string loLoopArticulosDescripcionArticulos = loDescripcionArticulos.ValorDescripcionArticulos
                                    + "," + loDescripcionArticulos.TipoDescripcionArticulo
                                    + "," + loDescripcionArticulos.DescripciondeArticulo
                                    + "," + loDescripcionArticulos.SubcalificativoFuente;
            string loLoopArticulosDetallesFisicosArticulos = loDetallesFisicosArticulos.ValorDetallesFisicosArticulos
                                    + "," + loDetallesFisicosArticulos.Paquete
                                    + "," + loDetallesFisicosArticulos.Tamano;
                                    //+ "," + loDetallesFisicosArticulos.UOM
                                    //+ "," + loDetallesFisicosArticulos.CodigoEmpaquetamiento
                                    //+ "," + loDetallesFisicosArticulos.CalificativoPeso
                                    //+ "," + loDetallesFisicosArticulos.PesoPorPaqueteBruto
                                    //+ "," + loDetallesFisicosArticulos.UOMPesoBruto
                                    //+ "," + loDetallesFisicosArticulos.VolumenPorPaqueteBruto
                                    //+ "," + loDetallesFisicosArticulos.VolumenUOMbruto
                                    //+ "," + loDetallesFisicosArticulos.Largo
                                    //+ "," + loDetallesFisicosArticulos.Ancho
                                    //+ "," + loDetallesFisicosArticulos.Altura
                                    //+ "," + loDetallesFisicosArticulos.TamanoUOM
                                    //+ "," + loDetallesFisicosArticulos.PosicionCapaSuperficie
                                    //+ "," + loDetallesFisicosArticulos.AsignadoID1
                                    //+ "," + loDetallesFisicosArticulos.AsignadoID2
                                    //+ "," + loDetallesFisicosArticulos.Numero;    
            loArticulostxt = loArticulostxt
                                + loLoopArticulos
                                + "\r\n" + loLoopArticulosDescripcionArticulos
                                + "\r\n" + loLoopArticulosDetallesFisicosArticulos
                                + "\r\n"; 
            }
            #endregion
            #region Sección Resumen
            string loResumenCTT = loCTT.ValorCTT
                                    + "," + loCTT.NumLineItems
                                    + "," + loCTT.TotalQuantity
                                    + "," + loCTT.Weight
                                    + "," + loCTT.WeightUOM
                                    + "," + loCTT.Volume
                                    + "," + loCTT.VolumeUOM
                                    + ",";
            #endregion
            string locontenidotxt = loEncabezadoRoutingInterno
                                    + "\r\n" + loEncabezadoOrden
                                    + "\r\n" + loEncabezadoDivisas
                                    + "\r\n" + loEncabezadoTipodeReferencia
                                    + "\r\n" + loEncabezadoContactosAdmin
                                    + "\r\n" + loEncabezadoFrancoaBordo
                                    + "\r\n" + loEncabezadoRequisitosdeVentas
                                    + "\r\n" + loEncabezadoConcesionesYCobros
                                    + "\r\n" + loEncabezadoTerminosdeVenta
                                    + "\r\n" + loEncabezadoFechasdeOrden
                                    + "\r\n" + loEncabezadoRoutingdePortador
                                    + "\r\n" + loMSGLoopReferenciasdeOrden
                                    + "\r\n" + loLoopPartesContractuantesParteContractuante
                                    + "\r\n" + loArticulostxt
                                    + loResumenCTT;

            return locontenidotxt;
                        
        }
        internal Boolean Generartxt(DataTable loOrdenCompra, int lnSucursal)
        {

            try
            {
                string loFacturaOrdenCompra = loOrdenCompra.Rows[0]["FOLOC_FOLIO"].ToString() + loOrdenCompra.Rows[0]["NUMERO"].ToString();
                
                if (!Directory.Exists(ConfigurationManager.AppSettings["DirectorioFacturastxt"]))
                {
                    Directory.CreateDirectory(ConfigurationManager.AppSettings["DirectorioFacturastxt"]);
                    StreamWriter swFacturatxt = new StreamWriter(ConfigurationManager.AppSettings["DirectorioFacturastxt"] + "\\" + loFacturaOrdenCompra + ".txt");
                    swFacturatxt.WriteLine(GenerarTextoPlano(loOrdenCompra, lnSucursal));
                    swFacturatxt.Close();
                }
                else
                {
                    if (!File.Exists(ConfigurationManager.AppSettings["DirectorioFacturastxt"] + "\\" + loFacturaOrdenCompra + ".txt"))
                    {
                        StreamWriter swFacturatxt = new StreamWriter(ConfigurationManager.AppSettings["DirectorioFacturastxt"] + "\\" + loFacturaOrdenCompra + ".txt");
                        swFacturatxt.WriteLine(GenerarTextoPlano(loOrdenCompra, lnSucursal));
                        swFacturatxt.Close();
                    }
                    else
                    {
                        File.Delete(ConfigurationManager.AppSettings["DirectorioFacturastxt"] + "\\" + loFacturaOrdenCompra + ".txt");
                        StreamWriter swFacturatxt = new StreamWriter(ConfigurationManager.AppSettings["DirectorioFacturastxt"] + "\\" + loFacturaOrdenCompra + ".txt");
                        swFacturatxt.WriteLine(GenerarTextoPlano(loOrdenCompra, lnSucursal));
                        swFacturatxt.Close();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }



        }

    }

}

