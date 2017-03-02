using Dapesa.Documentos.XML.Reglas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;

namespace Dapesa.Credito.Documentos.Reglas
{
    public class NotasTemporal
    {
        public void MoverTemporal(EventLog poLog, string Correocuenta, string CorreoDestinatario, string CorreoServidor, string CorreoPuerto, string CorreoCP)
        {

            string lsUbicacionOrigen = ConfigurationManager.AppSettings["UbicacionOrigen"];  //ruta origen

            while (true)
            {
                try
                {
                    string[] loArchivosTotal;
                    loArchivosTotal = Directory.GetFiles(lsUbicacionOrigen, "*.xml", SearchOption.TopDirectoryOnly);

                    if (loArchivosTotal.Length <= int.Parse(ConfigurationManager.AppSettings["MaximoIn"]))
                    {
                        Thread.Sleep(200);
                        continue;
                    }

                    foreach (string lsClave in ConfigurationManager.AppSettings.Keys) //recorre cada clave del appconfig
                    {
                        if (lsClave == "UbicacionOrigen" || lsClave == "MaximoIn" || lsClave.Contains("Correo") || lsClave.Contains("Hora")) //
                            continue;

                        string[] loArchivos;
                        loArchivos = Directory.GetFiles(lsUbicacionOrigen, lsClave + "*.xml", SearchOption.TopDirectoryOnly);
                        Thread.Sleep(200);

                        foreach (string loArchivo in loArchivos) //encuentra los archivos xml que sean notas
                        {
                            loArchivosTotal = Directory.GetFiles(lsUbicacionOrigen, "*.xml", SearchOption.TopDirectoryOnly);

                            if (loArchivosTotal.Length <= int.Parse(ConfigurationManager.AppSettings["MaximoIn"]))
                            {
                                Thread.Sleep(200);
                                continue;
                            }

                            Thread.Sleep(200);

                            #region Validar si esta en uso el archivo *.xml

                            try
                            {
                                using (File.Open(loArchivo, FileMode.Open))
                                {

                                }
                            }
                            catch (Exception ex)
                            {
                                //poLog.WriteEntry("Validación FileOpen .xml:" + ex.Message, EventLogEntryType.Information);
                                EnviarAviso(ex.Message + " " + ex.Source, Correocuenta, CorreoDestinatario, CorreoServidor, CorreoPuerto, CorreoCP);
                                continue;
                            }

                            #endregion

                            #region Mueve Archivos

                            try
                            {
                                if (File.Exists(loArchivo))
                                {
                                    if (File.Exists(Path.Combine(ConfigurationManager.AppSettings[lsClave], Path.GetFileName(loArchivo))))
                                    {
                                        File.Delete(Path.Combine(ConfigurationManager.AppSettings[lsClave], Path.GetFileName(loArchivo)));
                                    }

                                    if (File.Exists(Path.Combine(ConfigurationManager.AppSettings[lsClave], Path.GetFileName(loArchivo).Replace("[]", ""))))
                                    {
                                        File.Delete(Path.Combine(ConfigurationManager.AppSettings[lsClave], Path.GetFileName(loArchivo).Replace("[]", "")));
                                    }

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
                                    poLog.WriteEntry("Error al enviar Email: " + e.Message + " " + ex.Source, EventLogEntryType.Information);
                                }
                                continue;
                            }

                            #endregion

                        }
                    }

                    GC.Collect();
                    //poLog.WriteEntry("MENSAJE", EventLogEntryType.Information);

                }
                catch (Exception ex)
                {
                    poLog.WriteEntry("Ocurrio la siguiente Excepcion en el metodo MoverTemporal:" + ex.Message + " " + ex.Source, EventLogEntryType.Information);
                    try 
                    {
                        EnviarAviso("Ocurrio la siguiente Excepcion en el metodo MoverTemporal:" + ex.Message + " " + ex.Source, Correocuenta, CorreoDestinatario, CorreoServidor, CorreoPuerto, CorreoCP);
                    }
                    catch (Exception e)
                    {
                        poLog.WriteEntry("Error al enviar Email: " + e.Message + " " + ex.Source, EventLogEntryType.Information);

                    }
                    Thread.Sleep(30000);
                    continue;
                }
            }

        }

        private void EnviarAviso(string lsMsgError, string Correocuenta, string CorreoDestinatario, string CorreoServidor, string CorreoPuerto, string CorreoCP)
        {
            if (bool.Parse(ConfigurationManager.AppSettings["EnviarAviso"]))
            {
                MailMessage Mail = new MailMessage();
                Mail.To.Add(new MailAddress(CorreoDestinatario));
                Mail.From = new MailAddress(Correocuenta);
                Mail.Subject = "Error en Servicio MoverNotasTemporal";
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
    }
}