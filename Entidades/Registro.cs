using System;
namespace Dapesa.Compras.OrdenCompra.Entidades
{
    /// <summary>
    /// Atributos SuperSpec  Version 8.1 -- 02/12/2010
    /// Obtiene y establece los atributos a los campos de un registro de SuperSpec
    /// </summary>
    public class Registro
    {
        #region Sección RoutingInterno

        public class RoutingInterno
        {
            #region Atributos

            public string ValorRoutingInterno { get; set; }
            public string CalificativoEnviador { get; set; }
            public string IDRemitente { get; set; }
            public string CalificativoDestinatario { get; set; }
            public string IDDestinatario { get; set; }
            public string NumeroControlIntercambio { get; set; }
            public string NumeroVersionIntercambio { get; set; }
            public string PruebaOProduccion { get; set; }
            public string CodigoIDdelGrupo { get; set; }
            public string IDdelGrupoRemitente { get; set; }
            public string IDdelGrupoDestinatario { get; set; }
            public string FechaGrupo { get; set; }
            public string HoraGrupo { get; set; }
            public string GroupControlNumero { get; set; }
            public string VersionGrupo { get; set; }
            public string TransSetIDCodigo { get; set; }
            public string NumeroSetControlTransaccion { get; set; }

            #endregion
        }

        #endregion
        #region Sección Encabezado

        public class Orden
        {
            #region Atributos

            public string ValorOrden { get; set; }
            public string CodigodeIntencion { get; set; }
            public string CodigodelTipodeOC { get; set; }
            public string NumOC { get; set; }
            public string NumerodeSalida { get; set; }
            public DateTime FechaOC { get; set; }
            public string NumeroContrato { get; set; }
            public string TipodeReconocimiento { get; set; }
            public string CodigoTipoContrato { get; set; }

            #endregion
        }
        public class Divisas
        {
            #region Atributos

            public string ValorDivisas { get; set; }
            public string CodigoIDEntidad { get; set; }
            public string CodigoDivisa { get; set; }


            #endregion
        }
        public class TipodeReferencia
        {
            #region Atributos

            public string ValorTipodeReferencia { get; set; }
            public string TipodeReferenciaCodigo { get; set; }
            public string Referencia { get; set; }
            public string DescripciondeReferencia { get; set; }

            #endregion
        }
        public class ContactosAdmin
        {
            #region Atributos

            public string ValorContactosAdmin { get; set; }
            public string TipodeContacto { get; set; }
            public string NombredelContacto { get; set; }
            public string CalificativoTelefono { get; set; }
            public string NumerodeTelefono { get; set; }
            public string CalificativoFax { get; set; }
            public string NumerodeFax { get; set; }
            public string CalificativoEmail { get; set; }
            public string Email { get; set; }


            #endregion
        }
        public class FrancoaBordo
        {
            #region Atributos

            public string ValorFrancoaBordo { get; set; }
            public string MetodoPagoEnvio { get; set; }
            public string CalificativoUbicacion { get; set; }
            public string Descripcion { get; set; }
            public string CalificativoTerminosdeTransporte { get; set; }
            public string TerminosdeTransporte { get; set; }
            public string CalificativoUbicacion2 { get; set; }
            public string Descripcion2 { get; set; }
            public string CalificativoRiesgodePerdida { get; set; }
            public string DescripcionRiesgodePerdida { get; set; }

            #endregion
        }
        public class RequisitosdeVentas
        {
            #region Atributos

            public string ValorRequisitosdeVentas { get; set; }
            public string CodigodeRequisitosdeVentas { get; set; }

            #endregion
        }
        public class ConcesionesYCobros
        {
            #region Atributos

            public string ValorConcesionesYCobros { get; set; }
            public string Indicador { get; set; }
            public string CodigoSAC { get; set; }
            public string AgencyCodigoQualifier { get; set; }
            public string AgencyServicePromotion { get; set; }
            public string Cantidad { get; set; }
            public string CalificativoPorcentual { get; set; }
            public string PorCiento { get; set; }
            public string TasadeCobro { get; set; }
            public string UOM { get; set; }
            public string Cantidad1 { get; set; }
            public string Cantidad2 { get; set; }
            public string MetododeProcesamiento { get; set; }
            public string IDReferencia { get; set; }
            public string NumerodeOpcion { get; set; }
            public string Descripcion { get; set; }
            public string CodigoLenguaje { get; set; }

            #endregion
        }
        public class TerminosdeVenta
        {
            #region Atributos

            public string ValorTerminosdeVenta { get; set; }
            public string CodigoTiposdeTerminos { get; set; }
            public string CodigoFechaenBaseaTerminos { get; set; }
            public string DescuentoPorcentualTerminos { get; set; }
            public string FechadeVencimientoTerminosDescuento { get; set; }
            public string DiaVencimientoTerminosDescuento { get; set; }
            public string FechaVencimientoTerminosNetos { get; set; }
            public string TerminosDiasNetos { get; set; }
            public string TerminosCantidadDescuento { get; set; }
            public string FechaVencimientoTerminosaPlazo { get; set; }
            public string CantidadaPlazoDebida { get; set; }
            public string PorcentofInvoicePayable { get; set; }
            public string Descripcion { get; set; }
            public string DiadelMes { get; set; }
            public string CodigoMetodoPago { get; set; }
            public string PorCiento { get; set; }

            #endregion
        }
        public class FechasdeOrden
        {
            #region Atributos

            public string ValorFechasdeOrden { get; set; }
            public string CalificativoFecha { get; set; }
            public string Fecha { get; set; }
            public string Hora { get; set; }

            #endregion
        }
        public class RoutingdePortador
        {
            #region Atributos

            public string ValorRoutingdePortador { get; set; }
            public string CodigoSecuenciaRouting { get; set; }
            public string CodigoCalificativoID { get; set; }
            public string CodigoID { get; set; }
            public string MetododeTransporte { get; set; }
            public string Routing { get; set; }
            public string Codigo1NivelServicio { get; set; }
            public string CodigoServicioNivel2 { get; set; }
            public string CodigoServicioNivel3 { get; set; }
            public string CodigoPais { get; set; }

            #endregion
        }

        #endregion
        #region  Sección MSG Loop

        public class ReferenciasdeOrden
        {
            #region Atributos Sección MSG Loop

            public string ValorReferenciasdeOrden { get; set; }
            public string TipodeReferencia { get; set; }
            public string Referencia { get; set; }
            public string RefDescr { get; set; }

            #endregion
        }
        public class MensajesdeOrden
        {
            #region Atributos Sección MSG Loop

            public string ValorMensajesdeOrden { get; set; }
            public string MensajeTexto { get; set; }

            #endregion
        }

        #endregion
        #region Sección Loop Partes Contractuantes

        public class ParteContractuante
        {
            #region Atributos sección Loop Partes Contractuantes

            public string ValorParteContractuante { get; set; }
            public string TipodeParteContr { get; set; }
            public string NombredeParteContr { get; set; }
            public string CodigoIDParteContr { get; set; }
            public string CodigoParteContr { get; set; }

            #endregion
        }
        public class AnadirNombreParteContr
        {
            #region Atributos sección Loop Partes Contractuantes

            public string ValorAnadirNombreParteContr { get; set; }
            public string AnadirNombreParteContr1 { get; set; }
            public string AnadirNombreParteContr2 { get; set; }

            #endregion
        }
        public class DireccionParteContr
        {
            #region Atributos sección Loop Partes Contractuantes

            public string ValorDireccionParteContr { get; set; }
            public string Direccion1 { get; set; }
            public string Direccion2 { get; set; }

            #endregion
        }
        public class UbicacionParteContr
        {
            #region Atributos sección Loop Partes Contractuantes

            public string ValorUbicacionParteContr { get; set; }
            public string Ciudad { get; set; }
            public string Estado { get; set; }
            public string CodigoPostal { get; set; }
            public string Pais { get; set; }
            public string CalificativoUbicacion { get; set; }
            public string IdentificadorUbicacion { get; set; }

            #endregion
        }
        public class ReferenciasParteContr
        {
            #region Atributos sección Loop Partes Contractuantes

            public string ValorReferenciasParteContr { get; set; }
            public string TipoRef { get; set; }
            public string NumeroReferencia { get; set; }

            #endregion
        }
        public class ContactosParteContr
        {
            #region Atributos sección Loop Partes Contractuantes

            public string ValorContactosParteContr { get; set; }
            public string TipodeContacto { get; set; }
            public string NombredeContacto { get; set; }
            public string CalificadorTelefono { get; set; }
            public string NumeroTelefono { get; set; }

            #endregion
        }

        #endregion
        #region Sección LoopArtículos

        public class Articulos
        {
            #region Atributos sección Loop Partes Contractuantes

            public string ValorArticulos { get; set; }
            public string NumeroLinea { get; set; }
            public string CantidadOrdenada { get; set; }
            public string CantidadUOM { get; set; }
            public decimal PrecioUnidad { get; set; }
            public string PrecioUnidadUOM { get; set; }
            public string CodigodePartedelComprador { get; set; }
            public string PartedelComprador { get; set; }
            public string CodigoPartedelVendedor { get; set; }
            public string PartedelVendedor { get; set; }
            public string CalificativoNumeroUPC { get; set; }
            public string NumeroUPC { get; set; }
            public string CalificativoCodigoFabricante { get; set; }
            public string CodigoFabricante { get; set; }
            public string CalificativoOtroCodigo { get; set; }
            public string OtroCodigo { get; set; }

            #endregion
        }
        public class DescripcionArticulos
        {
            #region Atributos sección Loop Partes Contractuantes

            public string ValorDescripcionArticulos { get; set; }
            public string TipoDescripcionArticulo { get; set; }
            public string DescripciondeArticulo { get; set; }
            public string SubcalificativoFuente { get; set; }

            #endregion
        }
        public class DetallesFisicosArticulos
        {
            #region Atributos sección Loop Partes Contractuantes

            public string ValorDetallesFisicosArticulos { get; set; }
            public string Paquete { get; set; }
            public string Tamano { get; set; }
            public string UOM { get; set; }
            public string CodigoEmpaquetamiento { get; set; }
            public string CalificativoPeso { get; set; }
            public string PesoPorPaqueteBruto { get; set; }
            public string UOMPesoBruto { get; set; }
            public string VolumenPorPaqueteBruto { get; set; }
            public string VolumenUOMbruto { get; set; }
            public string Largo { get; set; }
            public string Ancho { get; set; }
            public string Altura { get; set; }
            public string TamanoUOM { get; set; }
            public string PosicionCapaSuperficie { get; set; }
            public string AsignadoID1 { get; set; }
            public string AsignadoID2 { get; set; }
            public string Numero { get; set; }

            #endregion
        }
        public class ConcesionesyCobro
        {
            #region Atributos sección Loop Partes Contractuantes

            public string ValorConcesionesyCobro { get; set; }
            public string Indicador { get; set; }
            public string CodigoSAC { get; set; }
            public string AgencyCodigoQualifier { get; set; }
            public string AgencyServicePromotion { get; set; }
            public string Cantidad { get; set; }
            public string CalificativoPorcuentual { get; set; }
            public string PorCiento { get; set; }
            public string ChargeRate { get; set; }
            public string UOM { get; set; }
            public string Qty1 { get; set; }
            public string Qty2 { get; set; }
            public string MethodOfHandling { get; set; }
            public string RefID { get; set; }
            public string OptionNumero { get; set; }
            public string Description { get; set; }
            public string LanguageCodigo { get; set; }

            #endregion
        }
        public class CondicionesdeVenta
        {
            #region Atributos sección Loop Partes Contractuantes

            public string ValorCondicionesdeVenta { get; set; }
            public string SalesRequirementCodigo { get; set; }

            #endregion
        }
        public class DetallesDescuento
        {
            #region Atributos sección Loop Partes Contractuantes

            public string ValorDetallesDescuento { get; set; }
            public string DiscountTermsTypeCodigo { get; set; }
            public string DiscountBaseQualifier { get; set; }
            public string DiscountBaseValor { get; set; }
            public string DiscountControlLimitQualifier { get; set; }
            public string DiscountControlLimit1 { get; set; }
            public string DiscountControlLimit2 { get; set; }

            #endregion
        }
        public class FechasArticulos
        {
            #region Atributos sección Loop Partes Contractuantes

            public string ValorFechasArticulos { get; set; }
            public string FechaQual { get; set; }
            public string Fecha { get; set; }

            #endregion
        }
        public class ItemSchedule
        {
            #region Atributos sección Loop Partes Contractuantes

            public string ValorItemSchedule { get; set; }
            public string Quantity { get; set; }
            public string QuantityUOM { get; set; }
            public string DTQualifier { get; set; }
            public DateTime Fecha { get; set; }
            public string Time { get; set; }

            #endregion
        }

        #endregion
        #region Sección Item MSG Loop

        public class OrderReferences
        {
            #region Atributos sección Item MSG Loop

            public string ValorOrderReferences { get; set; }
            public string RefType { get; set; }
            public string Reference { get; set; }
            public string RefDescr { get; set; }

            #endregion
        }
        public class OrderMessages
        {
            #region Atributos sección Item MSG Loop

            public string ValorOrderMessages { get; set; }
            public string MsgText { get; set; }

            #endregion
        }

        #endregion
        #region Sección Resumen
        public class CTT
        {
            #region Atributos sección Resumen

            public string ValorCTT { get; set; }
            public string NumLineItems { get; set; }
            public string TotalQuantity { get; set; }
            public string Weight { get; set; }
            public string WeightUOM { get; set; }
            public string Volume { get; set; }
            public string VolumeUOM { get; set; }

            #endregion
        }
        #endregion
    }
}
