using Dapesa.AccesoDatos.Entidades;
using Dapesa.Comun.Utilerias;
using Dapesa.Credito.Documentos.Comun;
using Dapesa.Credito.Documentos.Reglas.Proxy;
using Dapesa.Seguridad.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net.Mail;

namespace Dapesa.Credito.Documentos.Reglas
{
    internal class HelperDocumentos
    {
        #region Metodos

        internal DataTable ObtenerDocumentos(Sesion poSesion, Definiciones.TipoDocumento poTipoDocumento, string psClaveCliente, DateTime poFechaInicio, DateTime poFechaFin)
        {
            Sentencia loSentencia = new Sentencia()
            {
                #region Inicializar

                Parametros = new List<Parametro>(),
                Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query,
                TipoComando = CommandType.Text,
                TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion,
                TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto

                #endregion
            };
            string lsSucursales = string.Empty;

            foreach (Sucursal lsSucursal in poSesion.Usuario.Sucursal)
                lsSucursales += lsSucursal.Clave + ",";

            #region Establecer comando

            switch (poTipoDocumento)
            {
                case Definiciones.TipoDocumento.Factura:
                    loSentencia.TextoComando =
                        "SELECT 'DAP941221SYA_'||fe.folfac_folio||'_'||fe.numero as docto, fe.fecha " +
                        "FROM clientes, facturas_emitidas fe " +
                        "WHERE clientes.clave=fe.cli_clave AND TRUNC(fe.fecha) BETWEEN TO_DATE('" + poFechaInicio.ToShortDateString() + "','dd/MM/yyyy') AND TO_DATE('" + poFechaFin.ToShortDateString() + "','dd/MM/yyyy') " +
                        "AND fe.folfac_folio IN (SELECT DISTINCT folfac_folio FROM suc_folios_facturas WHERE suc_clave IN (" + lsSucursales.TrimEnd(',') + ") AND folfac_folio LIKE 'F%') AND fe.status_can='N' " +
                        "AND fe.cli_clave=COALESCE(" + ((string.IsNullOrEmpty(psClaveCliente)) ? "NULL" : "'" + psClaveCliente + "'") + ",fe.cli_clave) " +
                        "ORDER BY fe.fecha";
                    break;
                case Definiciones.TipoDocumento.NotaCargo:
                    loSentencia.TextoComando =
                        "SELECT 'DAP941221SYA_'||nc.fol_nc_em_folio||'_'||nc.numero as docto, nc.fecha " +
                        "FROM clientes, notas_cargo_emitidas nc " +
                        "WHERE clientes.clave=nc.cli_clave AND TRUNC(nc.fecha) BETWEEN TO_DATE('" + poFechaInicio.ToShortDateString() + "','dd/MM/yyyy') AND TO_DATE('" + poFechaFin.ToShortDateString() + "','dd/MM/yyyy') " +
                        "AND nc.fol_nc_em_folio IN (SELECT DISTINCT fol_nc_em_folio FROM suc_folios_notas_cargo_emi WHERE suc_clave IN (" + lsSucursales.TrimEnd(',') + ") AND fol_nc_em_folio LIKE 'CA%') AND nc.status_can='N' " +
                        "AND nc.cli_clave=COALESCE(" + ((string.IsNullOrEmpty(psClaveCliente)) ? "NULL" : "'" + psClaveCliente + "'") + ",nc.cli_clave) " +
                        "ORDER BY nc.fecha";
                    break;
                case Definiciones.TipoDocumento.NotaCredito:
                    loSentencia.TextoComando =
                        "SELECT 'DAP941221SYA_'||nc.fol_ncr_ct_folio||'_'||nc.numero as docto, nc.fecha " +
                        "FROM clientes, notas_credito_al_cte nc " +
                        "WHERE clientes.clave=nc.cli_clave AND TRUNC(nc.fecha) BETWEEN TO_DATE('" + poFechaInicio.ToShortDateString() + "','dd/MM/yyyy') AND TO_DATE('" + poFechaFin.ToShortDateString() + "','dd/MM/yyyy') " +
                        "AND nc.fol_ncr_ct_folio IN (SELECT DISTINCT fol_ncr_ct_folio FROM suc_folios_ncred_cte WHERE suc_clave IN (" + lsSucursales.TrimEnd(',') + ") AND fol_ncr_ct_folio LIKE 'CR%') AND nc.status_can='N' " +
                        "AND nc.cli_clave=COALESCE(" + ((string.IsNullOrEmpty(psClaveCliente)) ? "NULL" : "'" + psClaveCliente + "'") + ",nc.cli_clave) " +
                        "ORDER BY nc.fecha";
                    break;
                default:
                    break;
            }

            #endregion

            DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorGestorCxC");
            Serializacion loDeserializador = new Serializacion();
            DataTable loResultado = loDeserializador.DeserializarTabla(
                poSesion.Conexion.Credenciales.Cifrado.Descifrar(
                    (byte[])loDespachador.Despachar(poSesion.Conexion, new List<Sentencia>() { loSentencia }
                )));

            loDespachador.ChannelFactory.Close();
            loDespachador.Close();
            return loResultado;
        }

        internal bool CopiarDocumentos(DataTable poDocumentos, string psUbicacionOrigen, EventHandler loManejadorArchivos)
        {
            List<string> loArchivos = new List<string>();

            foreach (DataRow loDocumento in poDocumentos.Rows)
            {
                loArchivos.Clear();
                this.BuscarDocumento(psUbicacionOrigen, loDocumento["DOCTO"].ToString(), (DateTime)loDocumento["FECHA"], loArchivos);

                if (loArchivos.Count > 0 && !Directory.Exists(ConfigurationManager.AppSettings["UbicacionDestino"].TrimEnd('\\')))
                    Directory.CreateDirectory(ConfigurationManager.AppSettings["UbicacionDestino"].TrimEnd('\\'));

                foreach (string loArchivo in loArchivos)
                    if (File.Exists(loArchivo))
                    {
                        File.Copy(loArchivo, ConfigurationManager.AppSettings["UbicacionDestino"].TrimEnd('\\') + "\\" + loArchivo.Substring(loArchivo.LastIndexOf('\\') + 1), true);

                        if (loManejadorArchivos != null)
                            loManejadorArchivos(this, new EventArgs());
                    }
            }

            return true;
        }

        private void BuscarDocumento(string psUbicacionOrigen, string psNombreArchivo, DateTime poFecha, List<string> poArchivos)
        {

            foreach (string loArchivo in Directory.GetFiles(psUbicacionOrigen, psNombreArchivo + ".*", SearchOption.TopDirectoryOnly))
                poArchivos.Add(loArchivo);

            if (poArchivos.Count == 0)
            {
                foreach (string loArchivo in Directory.GetFiles(psUbicacionOrigen + "\\" + poFecha.ToString("yyyy") + "\\" + poFecha.ToString("yyyy-MM") + "\\" + poFecha.ToString("yyyy-MM-dd"), psNombreArchivo + ".*", SearchOption.TopDirectoryOnly))
                    poArchivos.Add(loArchivo);

                if (poArchivos.Count == 0)
                    foreach (string loArchivo in Directory.GetFiles(psUbicacionOrigen, psNombreArchivo + ".*", SearchOption.AllDirectories))
                        poArchivos.Add(loArchivo);
            }
        }

        internal DataTable ObtenerDocumentoCancelado(Sesion poSesion, Definiciones.TipoDocumento poTipoDocumento, string lsFolioDocumento, int lnNumeroDocumento)
        {
            Sentencia loSentencia = new Sentencia()
            {
                #region Inicializar

                Parametros = new List<Parametro>(),
                Tipo = AccesoDatos.Comun.Definiciones.TipoSentencia.Query,
                TipoComando = CommandType.Text,
                TipoManejadorTransaccion = AccesoDatos.Comun.Definiciones.TipoManejadorTransaccion.NoTransaccion,
                TipoResultado = AccesoDatos.Comun.Definiciones.TipoResultado.Conjunto

                #endregion
            };


            #region Establecer comando

            switch (poTipoDocumento)
            {
                case Definiciones.TipoDocumento.Factura:
                    loSentencia.TextoComando =
                        "SELECT F.FOLFAC_FOLIO || '-'  || F.NUMERO AS DOCTO, C.CLAVE, C.RAZON_SOCIAL, C.EMAIL_CFD1, F.STATUS_CAN " +
                        "FROM CLIENTES C, FACTURAS_EMITIDAS F, SUC_CLIENTES SC " +
                        "WHERE C.CLAVE = F.CLI_CLAVE AND SC.CLI_CLAVE=C.CLAVE AND F.FOLFAC_FOLIO = '" + lsFolioDocumento + "' AND F.NUMERO=" + lnNumeroDocumento + " " +
                        "AND SC.SUC_CLAVE IN (SELECT SUC_CLAVE FROM PERSONAL_SUCURSALES WHERE PERS_CLAVE IN (SELECT CLAVE FROM PERSONAL WHERE USR_CLAVE= '" + poSesion.Usuario.Clave.ToString() + "'))";
                    break;
                case Definiciones.TipoDocumento.NotaCargo:
                    loSentencia.TextoComando =
                        "SELECT N.FOL_NC_EM_FOLIO || '-'  || N.NUMERO AS DOCTO,  C.CLAVE, C.RAZON_SOCIAL, C.EMAIL_CFD1, N.STATUS_CAN "+
                        "FROM CLIENTES C, NOTAS_CARGO_EMITIDAS N, SUC_CLIENTES SC "+
                        "WHERE C.CLAVE = N.CLI_CLAVE AND SC.CLI_CLAVE=C.CLAVE AND N.FOL_NC_EM_FOLIO = '"+lsFolioDocumento+"' AND N.NUMERO="+lnNumeroDocumento+" "+
                        "AND SC.SUC_CLAVE IN (SELECT SUC_CLAVE FROM PERSONAL_SUCURSALES WHERE PERS_CLAVE IN (SELECT CLAVE FROM PERSONAL WHERE USR_CLAVE= '" + poSesion.Usuario.Clave.ToString() + "'))";
                    break;
                case Definiciones.TipoDocumento.NotaCredito:
                    loSentencia.TextoComando =
                        "SELECT N.FOL_NCR_CT_FOLIO || '-'  || N.NUMERO AS DOCTO, C.CLAVE, C.RAZON_SOCIAL, C.EMAIL_CFD1, N.STATUS_CAN " +
                        "FROM CLIENTES C, NOTAS_CREDITO_AL_CTE N, SUC_CLIENTES SC " +
                        "WHERE C.CLAVE = N.CLI_CLAVE AND SC.CLI_CLAVE=C.CLAVE AND N.FOL_NCR_CT_FOLIO= '"+lsFolioDocumento+"' AND N.NUMERO ="+lnNumeroDocumento+" " +
                        "AND SC.SUC_CLAVE IN (SELECT SUC_CLAVE FROM PERSONAL_SUCURSALES WHERE PERS_CLAVE IN (SELECT CLAVE FROM PERSONAL WHERE USR_CLAVE= '" + poSesion.Usuario.Clave.ToString() + "'))";
                    break;
                default:
                    break;
            }

            #endregion

            DespachadorClient loDespachador = new DespachadorClient("netTcpBinding_IDespachadorGestorCxC");
            Serializacion loDeserializador = new Serializacion();
            DataTable loResultado = loDeserializador.DeserializarTabla(
                poSesion.Conexion.Credenciales.Cifrado.Descifrar(
                    (byte[])loDespachador.Despachar(poSesion.Conexion, new List<Sentencia>() { loSentencia }
                )));

            loDespachador.ChannelFactory.Close();
            loDespachador.Close();
            return loResultado;
        }

        internal bool EnviarAviso(Definiciones.TipoDocumento poTipoDocumento, string psDocumento, string psClaveCliente, string psRazonSocial, string psEmail, string psStatus)
        {
            bool EnviarEmail = false;
            try
            {
                MailMessage Mail = new MailMessage();
                Mail.To.Add(new MailAddress(psEmail));
                Mail.From = new MailAddress(ConfigurationManager.AppSettings["CorreoCuenta"]);
                Mail.Subject = ConfigurationManager.AppSettings["CorreoAsunto"] + poTipoDocumento.ToString().ToUpper() + " " + psDocumento;
                Mail.Body = "Estimado Cliente : " + psRazonSocial
                            + "\r\n" + "Hemos cancelado el Comprobante Fiscal Digital " + poTipoDocumento.ToString().ToUpper() + " " + psDocumento + ", "
                            + "el cual ha quedado sin efectos fiscales para su empresa por lo que le pedimos eliminarlo y no incluirlo en su contabilidad."
                            + "\r\n" + "El no tomar estas medidas puede representar un problema fiscal para usted."
                            + "\r\n" + "Este correo es informativo, favor no responder a esta dirección de correo, ya que no se encuentra habilitada para recibir mensajes."
                            + "\r\n" + "Atentamente, Distribuidora de Autopartes Pescador, S.A. de C.V.";
                Mail.IsBodyHtml = false;

                SmtpClient cliente = new SmtpClient(ConfigurationManager.AppSettings["CorreoServidor"], int.Parse(ConfigurationManager.AppSettings["CorreoPuerto"]));
                using (cliente)
                {
                    cliente.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["CorreoCuenta"], ConfigurationManager.AppSettings["CorreoCP"]);
                    cliente.EnableSsl = true;
                    cliente.Send(Mail);
                }
                EnviarEmail = true;
            }
            catch(Exception)
            {
               
            }
            return EnviarEmail;
        }

        #endregion
    }
}
