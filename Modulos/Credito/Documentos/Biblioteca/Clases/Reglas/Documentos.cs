using Dapesa.Credito.Documentos.Comun;
using Dapesa.Seguridad.Entidades;
using System;
using System.Data;
using System.Net.Mail;

namespace Dapesa.Credito.Documentos.Reglas
{
    public class Documentos
    {
        public event EventHandler DocumentosRecuperados;
        public event EventHandler DocumentoProcesado;

        #region Metodos

        public bool AgruparDocumentos(Sesion poSesion, Definiciones.TipoDocumento poTipoDocumento, string psClaveCliente, string psUbicacionOrigen, DateTime poFechaInicio, DateTime poFechaFin)
        {
            HelperDocumentos loHelper = new HelperDocumentos();
            DataTable loDocumentos = loHelper.ObtenerDocumentos(poSesion, poTipoDocumento, psClaveCliente, poFechaInicio, poFechaFin);
            EventHandler loManejadorArchivos = null;

            if (loDocumentos.Rows.Count > 0)
            {
                EventHandler loManejadorDocumentos = DocumentosRecuperados;

                this.TotalDocumentosRecuperados = loDocumentos.Rows.Count;
                loManejadorArchivos = DocumentoProcesado;

                if (loManejadorDocumentos != null)
                    loManejadorDocumentos(this, new EventArgs());
            }

            return loHelper.CopiarDocumentos(loDocumentos, psUbicacionOrigen, loManejadorArchivos);
        }

        public string EnviarAvisoCancelacion(Sesion poSesion, Definiciones.TipoDocumento poTipoDocumento, string psFolioDocumento, int pnNumeroDocumento)
        {
            bool  poEnviarEmail = false;
            string psMensajeRespuesta = string.Empty;
            HelperDocumentos loHelper = new HelperDocumentos();
            DataTable loDocumentos = loHelper.ObtenerDocumentoCancelado(poSesion, poTipoDocumento, psFolioDocumento, pnNumeroDocumento);
            switch (loDocumentos.Rows.Count)
            {
                case 0:
                    psMensajeRespuesta = "No existe información del documento solicitado.";
                    break;

                case 1:
                    if (loDocumentos.Rows[0]["STATUS_CAN"].ToString() != string.Empty && loDocumentos.Rows[0]["STATUS_CAN"].ToString() == "S" && loDocumentos.Rows[0]["EMAIL_CFD1"].ToString() != string.Empty)
                        poEnviarEmail = loHelper.EnviarAviso(poTipoDocumento
                                            , loDocumentos.Rows[0]["DOCTO"].ToString()
                                            , loDocumentos.Rows[0]["CLAVE"].ToString()
                                            , loDocumentos.Rows[0]["RAZON_SOCIAL"].ToString()
                                            , loDocumentos.Rows[0]["EMAIL_CFD1"].ToString()
                                            , loDocumentos.Rows[0]["STATUS_CAN"].ToString());
                    if (loDocumentos.Rows[0]["STATUS_CAN"].ToString() == "N")
                        psMensajeRespuesta = "¡El documento no esta cancelado!";
                    if (loDocumentos.Rows[0]["EMAIL_CFD1"].ToString() == string.Empty)
                        psMensajeRespuesta = "¡El cliente no tiene correo electrónico!";
                    if (poEnviarEmail)
                        psMensajeRespuesta = "¡Mensaje enviado con exito!";
                    else
                        psMensajeRespuesta = "¡No se envio el mensaje!";
                    break;

                case 2:
                    psMensajeRespuesta = "La consulta obtuvo mas de 2 resultados y no se pudo enviar el E-Mail.";
                    break;
            }

            return psMensajeRespuesta;
        }
        //Para enviar correos cuando se detecte algun error o se reinicie el servicio a causa de un problema
        public void EnviarAviso(string lsMsgError, string lsIndicadorEnvio, string Correocuenta, string CorreoDestinatario, string CorreoServidor, string CorreoPuerto, string CorreoCP)
        {
            if (lsIndicadorEnvio == "SI")
            {
                MailMessage Mail = new MailMessage();
                Mail.To.Add(new MailAddress(CorreoDestinatario));
                Mail.From = new MailAddress(Correocuenta);
                Mail.Subject = "Error en Servicio MoverFacturas";
                Mail.Body = "Se detectó el siguiente error: " + lsMsgError;
                Mail.IsBodyHtml = false;

                SmtpClient cliente = new SmtpClient(CorreoServidor, int.Parse(CorreoPuerto));
                using (cliente)
                {
                    cliente.Credentials = new System.Net.NetworkCredential(Correocuenta, CorreoCP);
                    cliente.EnableSsl = false;
                    cliente.Send(Mail);
                }
            }
        }

        #endregion

        #region Propiedades

        public int TotalDocumentosRecuperados
        {
            get;
            set;
        }

        #endregion
    }
}
