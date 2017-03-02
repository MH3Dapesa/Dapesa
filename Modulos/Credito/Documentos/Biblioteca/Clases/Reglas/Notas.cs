using Dapesa.Documentos.XML.Reglas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Mail;

namespace Dapesa.Credito.Documentos.Reglas
{
    public class Notas
    {
        Documentos loDocumentos = new Documentos();

        #region Metodos

        public void Mover(EventLog poLog, string lsIndicadorEnvio, string Correocuenta, string CorreoDestinatario, string CorreoServidor, string CorreoPuerto, string CorreoCP, int lnTiempoEsperaError)
        {
            string lsUbicacionOrigen = ConfigurationManager.AppSettings["UbicacionOrigen"];  //ruta origen

            while (true)
            {
                foreach (string lsClave in ConfigurationManager.AppSettings.Keys) //recorre cada clave del appconfig
                {

                    if (lsClave == "UbicacionOrigen" || lsClave.Contains("cancela") || lsClave.Contains("Correo") || lsClave.Contains("Error") || lsClave.Contains("Hora")) //
                        continue;

                    // Convertir en arreglo lsClave para extraer las dos rutas donde se guardaran los archivos.
                    string[] lsClaves = ConfigurationManager.AppSettings[lsClave].Split(new Char[] { ';' });

                    string[] loArchivos = Directory.GetFiles(lsUbicacionOrigen, lsClave + "*.xml", SearchOption.TopDirectoryOnly);

                    foreach (string loArchivo in loArchivos) //encuentra los archivos xml que sean notas
                    {
                        Thread.Sleep(2000);

                        if (!File.Exists(loArchivo.Replace("xml", "pdf")))
                            continue;
                        //extrae nombre del archivo hayado descriminado la extencion             
                        //string lsNombreArchivo = loArchivo.Substring(loArchivo.LastIndexOf('\\') + 1).Replace(".xml", "");

                        Iterador loIteradorXML = new Iterador(loArchivo);
                        List<string> loFechaComprobante = (List<string>)loIteradorXML.ObtenerAtributo("Comprobante", "fecha", Dapesa.Documentos.XML.Comun.Definiciones.TipoSalida.Simple); //obtiene la fecha del documento xml

                        #region CrearDirectorios
                        try
                        {
                            for (int i = 0; i <= lsClaves.Length - 1; i++)
                            {
                                if (!Directory.Exists(lsClaves[i].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4) + "\\" + loFechaComprobante[0].Substring(0, 7) + "\\" + loFechaComprobante[0].Substring(0, 10)))
                                {

                                    if (!Directory.Exists(lsClaves[i].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4) + "\\" + loFechaComprobante[0].Substring(0, 7)))
                                    {

                                        if (!Directory.Exists(lsClaves[i].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4)))
                                        {
                                            Directory.CreateDirectory(lsClaves[i].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4)); //año
                                            Directory.CreateDirectory(lsClaves[i].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4) + "\\" + loFechaComprobante[0].Substring(0, 7)); //mes
                                            Directory.CreateDirectory(lsClaves[i].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4) + "\\" + loFechaComprobante[0].Substring(0, 7) + "\\" + loFechaComprobante[0].Substring(0, 10)); //dia
                                        }
                                        else
                                        {
                                            Directory.CreateDirectory(lsClaves[i].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4) + "\\" + loFechaComprobante[0].Substring(0, 7));//mes
                                            Directory.CreateDirectory(lsClaves[i].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4) + "\\" + loFechaComprobante[0].Substring(0, 7) + "\\" + loFechaComprobante[0].Substring(0, 10));//dia
                                        }
                                    }
                                    else
                                    {
                                        Directory.CreateDirectory(lsClaves[i].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4) + "\\" + loFechaComprobante[0].Substring(0, 7) + "\\" + loFechaComprobante[0].Substring(0, 10));//dia
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                loDocumentos.EnviarAviso(ex.Message + " " + ex.Source, lsIndicadorEnvio, Correocuenta, CorreoDestinatario, CorreoServidor, CorreoPuerto, CorreoCP);
                            }
                            catch (Exception e)
                            {
                                poLog.WriteEntry("Ocurrio un error al enviar Email: " + e.Message, EventLogEntryType.Information);
                                continue;
                            }
                            Thread.Sleep(lnTiempoEsperaError);
                            continue;
                        }

                        #endregion

                        #region Validar PDF

                        try
                        {
                            using (File.Open(loArchivo.Replace("xml", "pdf"), FileMode.Open))
                            {

                            }
                        }
                        catch
                        {
                            //poLog.WriteEntry("Validación FileOpen .pdf:" + ex.Message, EventLogEntryType.Information);
                            continue;
                        }

                        #endregion

                        #region Mueve Archivos

                        try
                        {
                            for (int i = 0; i <= lsClaves.Length - 1; i++)
                            {
                                if (File.Exists(loArchivo) && File.Exists(loArchivo.Replace("xml", "pdf")))
                                {
                                    if (File.Exists(Path.Combine(lsClaves[i], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo))) ||
                                        File.Exists(Path.Combine(lsClaves[i], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("xml", "pdf"))))
                                    {
                                        File.Delete(Path.Combine(lsClaves[i], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("xml", "pdf")));
                                        File.Delete(Path.Combine(lsClaves[i], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo)));
                                    }

                                    if (File.Exists(Path.Combine(lsClaves[i], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", ""))) ||
                                        File.Exists(Path.Combine(lsClaves[i], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", "").Replace("xml", "pdf"))))
                                    {
                                        File.Delete(Path.Combine(lsClaves[i], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", "").Replace("xml", "pdf")));
                                        File.Delete(Path.Combine(lsClaves[i], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", "")));

                                    }
                                    // !File.Exists(Path.Combine(ConfigurationManager.AppSettings[lsClave], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo))) &&
                                    //!File.Exists(Path.Combine(ConfigurationManager.AppSettings[lsClave], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("xml", "pdf"))))

                                    //File.Delete(Path.Combine(ConfigurationManager.AppSettings[lsClave], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", "")));
                                    //File.Delete(Path.Combine(ConfigurationManager.AppSettings[lsClave], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", "").Replace("xml", "pdf")));

                                    if (i == 0)
                                    {
                                        File.Copy(loArchivo.Replace("xml", "pdf"), Path.Combine(lsClaves[i], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", "").Replace("xml", "pdf")));
                                        File.Copy(loArchivo, Path.Combine(lsClaves[i], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", "")));
                                    }
                                    if (i == 1)
                                    {
                                        File.Move(loArchivo.Replace("xml", "pdf"), Path.Combine(lsClaves[i], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", "").Replace("xml", "pdf")));
                                        File.Move(loArchivo, Path.Combine(lsClaves[i], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", "")));
                                    }

                                    //File.Delete(ConfigurationManager.AppSettings[lsClave].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4) + "\\" + loFechaComprobante[0].Substring(0, 7) + "\\" + loFechaComprobante[0].Substring(0, 10) + "\\" + lsNombreArchivo + ".xml");
                                    //File.Delete(ConfigurationManager.AppSettings[lsClave].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4) + "\\" + loFechaComprobante[0].Substring(0, 7) + "\\" + loFechaComprobante[0].Substring(0, 10) + "\\" + lsNombreArchivo + ".pdf");
                                    //File.Move(lsUbicacionOrigen.TrimEnd('\\') + "\\" + lsNombreArchivo + ".xml", ConfigurationManager.AppSettings[lsClave].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4) + "\\" + loFechaComprobante[0].Substring(0, 7) + "\\" + loFechaComprobante[0].Substring(0, 10) + "\\" + lsNombreArchivo + ".xml");
                                    //File.Move(lsUbicacionOrigen.TrimEnd('\\') + "\\" + lsNombreArchivo + ".pdf", ConfigurationManager.AppSettings[lsClave].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4) + "\\" + loFechaComprobante[0].Substring(0, 7) + "\\" + loFechaComprobante[0].Substring(0, 10) + "\\" + lsNombreArchivo + ".pdf");

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                this.loDocumentos.EnviarAviso(ex.Message + " " + ex.Source, lsIndicadorEnvio, Correocuenta, CorreoDestinatario, CorreoServidor, CorreoPuerto, CorreoCP);
                            }
                            catch (Exception e)
                            {
                                poLog.WriteEntry("Ocurrio un error al enviar Email: " + e.Message, EventLogEntryType.Information);
                                continue;
                            }
                            Thread.Sleep(lnTiempoEsperaError);
                            continue;
                        }

                        #endregion

                    }
                }

                #region Procesa los .txt

                try
                {
                    foreach (string lsClave in ConfigurationManager.AppSettings.Keys) //recorre cada clave del appconfig
                    {
                        // Convertir en arreglo lsClave para extraer las dos rutas donde se guardaran los archivos.

                        if (lsClave == "UbicacionOrigen" || lsClave.Contains("Correo") || lsClave.Contains("Error") || lsClave.Contains("Hora")) //
                            continue;



                        string[] loArchivos = Directory.GetFiles(lsUbicacionOrigen, lsClave + "*.txt", SearchOption.TopDirectoryOnly);
                        string[] lsClaves = ConfigurationManager.AppSettings[lsClave].Split(new Char[] { ';' });

                        foreach (string loArchivo in loArchivos)
                        {
                            string lsNombreArchivo = loArchivo.Substring(loArchivo.LastIndexOf('\\') + 1).Replace(".txt", "");
                            for (int i = 0; i <= lsClaves.Length - 1; i++)
                            {
                                if (!Directory.Exists(lsClaves[i].TrimEnd('\\')))
                                {
                                    Directory.CreateDirectory(lsClaves[i].TrimEnd('\\'));
                                }
                                File.Delete(Path.Combine(lsClaves[i], Path.GetFileName(loArchivo).Replace("[]", "")));

                                if (i == 0)
                                {
                                    poLog.WriteEntry(lsClaves[i], EventLogEntryType.Information);
                                    File.Copy(loArchivo, Path.Combine(lsClaves[i], Path.GetFileName(loArchivo).Replace("[]", "")));

                                }
                                if (i == 1)
                                {
                                    poLog.WriteEntry(lsClaves[i], EventLogEntryType.Information);
                                    File.Move(loArchivo, Path.Combine(lsClaves[i], Path.GetFileName(loArchivo).Replace("[]", "")));
                                }
                                //File.Delete(ConfigurationManager.AppSettings[lsClave].TrimEnd('\\') + "\\" + lsNombreArchivo + ".txt");
                                //File.Move(lsUbicacionOrigen.TrimEnd('\\') + "\\" + lsNombreArchivo + ".txt", ConfigurationManager.AppSettings[lsClave].TrimEnd('\\') + "\\" + lsNombreArchivo + ".txt");
                                //File.Move(loArchivo, Path.Combine(ConfigurationManager.AppSettings[lsClaves[i]], Path.GetFileName(loArchivo).Replace("[]", "")));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        this.loDocumentos.EnviarAviso("Procesamiento de .txt " + ex.Message + "-" + ex.Source, lsIndicadorEnvio, Correocuenta, CorreoDestinatario, CorreoServidor, CorreoPuerto, CorreoCP);
                    }
                    catch (Exception e)
                    {
                        poLog.WriteEntry("Ocurrio un error al enviar Email: " + e.Message, EventLogEntryType.Information);
                        continue;
                    }
                    Thread.Sleep(lnTiempoEsperaError);
                    continue;
                }
                #endregion

                GC.Collect();
            }
        }

        //private void EnviarAviso(string lsMsgError, string Correocuenta, string CorreoDestinatario, string CorreoServidor, string CorreoPuerto, string CorreoCP)
        //{
        //    MailMessage Mail = new MailMessage();
        //    Mail.To.Add(new MailAddress(Correocuenta));
        //    Mail.From = new MailAddress(CorreoDestinatario);
        //    Mail.Subject = "Error en Servicio MoverNotas";
        //    Mail.Body = "Se detectó el siguiente error: " + lsMsgError;
        //    Mail.IsBodyHtml = false;

        //    SmtpClient cliente = new SmtpClient(CorreoServidor, int.Parse(CorreoPuerto));
        //    using (cliente)
        //    {
        //        cliente.Credentials = new System.Net.NetworkCredential(Correocuenta, CorreoCP);
        //        cliente.EnableSsl = false;
        //        cliente.Send(Mail);
        //    }
        //}

        #endregion
    }
}