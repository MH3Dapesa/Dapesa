using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Threading;

namespace Dapesa.Credito.Documentos.Reglas
{
    public class FacturasIn
    {
        public void FacturasMoverIn(EventLog poLog, string Correocuenta, string CorreoDestinatario, string CorreoServidor, string CorreoPuerto, string CorreoCP)
        {

            string lsUbicacionOrigen = ConfigurationManager.AppSettings["UbicacionOrigen"];  //Ruta origen

            while (true)
            {
                try
                {
                    foreach (string lsClave in ConfigurationManager.AppSettings.Keys) //Recorre cada clave del AppConfig
                    {
                        if (lsClave == "UbicacionOrigen" || lsClave.Contains("Correo") || lsClave.Contains("Hora")) //
                            continue;

                        string[] loArchivos = Directory.GetFiles(lsUbicacionOrigen, lsClave + "*.xml", SearchOption.TopDirectoryOnly);
                        Thread.Sleep(200);

                        foreach (string loArchivo in loArchivos) //Encuentra los archivos .xml que sean facturas
                        {

                            #region Validar si esta en uso el archivo *.xml

                            try
                            {
                                using (File.Open(loArchivo, FileMode.Open))
                                {

                                }
                            }
                            catch (Exception ex)
                            {
                                poLog.WriteEntry("Error. Validación FileOpen .xml:" + ex.Message, EventLogEntryType.Information);
                                continue;
                            }

                            #endregion

                            #region Mueve Archivos

                            try
                            {
                                if (File.Exists(loArchivo))
                                {
                                    if (File.Exists(Path.Combine(ConfigurationManager.AppSettings[lsClave], Path.GetFileName(loArchivo).Replace("[]", ""))))
                                    {
                                        File.Delete(Path.Combine(ConfigurationManager.AppSettings[lsClave], Path.GetFileName(loArchivo).Replace("[]", "")));
                                        File.Delete(Path.Combine(ConfigurationManager.AppSettings[lsClave], Path.GetFileName(loArchivo)));
                                    }
                                    Thread.Sleep(200);
                                    File.Move(loArchivo, Path.Combine(ConfigurationManager.AppSettings[lsClave], Path.GetFileName(loArchivo).Replace("[]", "")));
                                }
                            }
                            catch (Exception ex)
                            {
                                try
                                {
                                    EnviarAviso(ex.Message + " " + ex.Source, Correocuenta, CorreoDestinatario, CorreoServidor, CorreoPuerto, CorreoCP);
                                }
                                catch (Exception e)
                                {
                                    poLog.WriteEntry("Error. Mover .xml y enviar Email: " + e.Message + " " + ex.Source, EventLogEntryType.Information);
                                }
                                continue;
                            }

                            #endregion

                        }
                    }

                    GC.Collect();
                }
                catch (Exception ex)
                {
                    poLog.WriteEntry("Error. Metodo FacturasMoverIn:" + ex.Message + " " + ex.Source, EventLogEntryType.Information);
                    try
                    {
                        EnviarAviso("Error. Metodo FacturasMoverIn:" + ex.Message + " " + ex.Source, Correocuenta, CorreoDestinatario, CorreoServidor, CorreoPuerto, CorreoCP);
                    }
                    catch (Exception e)
                    {
                        poLog.WriteEntry("Error. FacturasMoverIn y enviar Email: " + e.Message + " " + ex.Source, EventLogEntryType.Information);

                    }
                    Thread.Sleep(30000);
                    continue;
                }
            }

        }
        #region Enviar Email
        private void EnviarAviso(string lsMsgError, string Correocuenta, string CorreoDestinatario, string CorreoServidor, string CorreoPuerto, string CorreoCP)
        {
            if (bool.Parse(ConfigurationManager.AppSettings["EnviarAviso"]))
            {
                MailMessage Mail = new MailMessage();
                Mail.To.Add(new MailAddress(CorreoDestinatario));
                Mail.From = new MailAddress(Correocuenta);
                Mail.Subject = ConfigurationManager.AppSettings["Asunto"];
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
    }
}
