using Dapesa.Documentos.XML.Reglas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Net.Mail;

namespace Dapesa.Credito.Documentos.Reglas
{
    public class Facturas
    {

        Documentos loDocumentos = new Documentos();

        #region Metodos

        public void Mover(EventLog poLog, string lsIndicadorEnvio, string Correocuenta, string CorreoDestinatario, string CorreoServidor, string CorreoPuerto, string CorreoCP, int lnTiempoEsperaError)
        {
            string lsUbicacionOrigen = ConfigurationManager.AppSettings["UbicacionOrigen"];

            while (true)
            {
                try
                {
                    foreach (string lsClave in ConfigurationManager.AppSettings.Keys)
                    {

                        if (lsClave == "UbicacionOrigen" || lsClave.Contains("Correo") || lsClave.Contains("Error") || lsClave.Contains("Hora"))
                            continue;

                        string[] loArchivos = Directory.GetFiles(lsUbicacionOrigen, lsClave + "*.xml", SearchOption.TopDirectoryOnly);

                        foreach (string loArchivo in loArchivos)
                        {
                            Thread.Sleep(2000);

                            if (!File.Exists(loArchivo.Replace("xml", "pdf")))
                                continue;

                            Iterador loIteradorXML = new Iterador(loArchivo);
                            List<string> loFechaComprobante = (List<string>)loIteradorXML.ObtenerAtributo("Comprobante", "fecha", Dapesa.Documentos.XML.Comun.Definiciones.TipoSalida.Simple);

                            #region Crear directorios
                            try
                            {

                                if (!Directory.Exists(Path.Combine(ConfigurationManager.AppSettings[lsClave], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10))))
                                {

                                    if (!Directory.Exists(ConfigurationManager.AppSettings[lsClave].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4) + "\\" + loFechaComprobante[0].Substring(0, 7)))
                                    {

                                        if (!Directory.Exists(ConfigurationManager.AppSettings[lsClave].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4)))
                                        {
                                            Directory.CreateDirectory(ConfigurationManager.AppSettings[lsClave].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4));
                                            Directory.CreateDirectory(ConfigurationManager.AppSettings[lsClave].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4) + "\\" + loFechaComprobante[0].Substring(0, 7));
                                            Directory.CreateDirectory(ConfigurationManager.AppSettings[lsClave].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4) + "\\" + loFechaComprobante[0].Substring(0, 7) + "\\" + loFechaComprobante[0].Substring(0, 10));
                                        }
                                        else
                                        {
                                            Directory.CreateDirectory(ConfigurationManager.AppSettings[lsClave].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4) + "\\" + loFechaComprobante[0].Substring(0, 7));
                                            Directory.CreateDirectory(ConfigurationManager.AppSettings[lsClave].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4) + "\\" + loFechaComprobante[0].Substring(0, 7) + "\\" + loFechaComprobante[0].Substring(0, 10));
                                        }
                                    }
                                    else
                                    {
                                        Directory.CreateDirectory(ConfigurationManager.AppSettings[lsClave].TrimEnd('\\') + "\\" + loFechaComprobante[0].Substring(0, 4) + "\\" + loFechaComprobante[0].Substring(0, 7) + "\\" + loFechaComprobante[0].Substring(0, 10));
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                poLog.WriteEntry("Error. Creación de Directorios: " + ex.Message, EventLogEntryType.Information);
                                loDocumentos.EnviarAviso("Error. Creadión de Directorios:" + ex.Message + " " + ex.Source, lsIndicadorEnvio, Correocuenta, CorreoDestinatario, CorreoServidor, CorreoPuerto, CorreoCP);
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

                                using (File.Open(loArchivo, FileMode.Open))
                                {

                                }
                            }
                            catch
                            {
                                continue;
                            }

                            #endregion

                            #region MoverArchivos
                            try
                            {
                                if (File.Exists(loArchivo) && File.Exists(loArchivo.Replace("xml", "pdf")))
                                {
                                    if (File.Exists(loArchivo))
                                    {

                                        if (File.Exists(Path.Combine(ConfigurationManager.AppSettings[lsClave], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo))) ||
                                            File.Exists(Path.Combine(ConfigurationManager.AppSettings[lsClave], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("xml", "pdf"))))
                                        {
                                            File.Delete(Path.Combine(ConfigurationManager.AppSettings[lsClave], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo)));
                                            File.Delete(Path.Combine(ConfigurationManager.AppSettings[lsClave], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("xml", "pdf")));
                                        }
                                        if (File.Exists(Path.Combine(ConfigurationManager.AppSettings[lsClave], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", ""))) ||
                                            File.Exists(Path.Combine(ConfigurationManager.AppSettings[lsClave], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", "").Replace("xml", "pdf"))))
                                        {
                                            File.Delete(Path.Combine(ConfigurationManager.AppSettings[lsClave], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", "")));
                                            File.Delete(Path.Combine(ConfigurationManager.AppSettings[lsClave], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", "").Replace("xml", "pdf")));
                                        }
                                        if (!File.Exists(Path.Combine(ConfigurationManager.AppSettings[lsClave], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", ""))) &&
                                            !File.Exists(Path.Combine(ConfigurationManager.AppSettings[lsClave], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", "").Replace("xml", "pdf"))))
                                        {
                                            File.Move(loArchivo.Replace("xml", "pdf"), Path.Combine(ConfigurationManager.AppSettings[lsClave], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", "").Replace("xml", "pdf")));
                                            File.Move(loArchivo, Path.Combine(ConfigurationManager.AppSettings[lsClave], loFechaComprobante[0].Substring(0, 4), loFechaComprobante[0].Substring(0, 7), loFechaComprobante[0].Substring(0, 10), Path.GetFileName(loArchivo).Replace("[]", "")));
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                poLog.WriteEntry("Error. Mover Archivos: " + ex.Message, EventLogEntryType.Information);
                                this.loDocumentos.EnviarAviso("Error. Mover Archivos: " + ex.Message + " " + ex.Source, lsIndicadorEnvio, Correocuenta, CorreoDestinatario, CorreoServidor, CorreoPuerto, CorreoCP);
                                Thread.Sleep(lnTiempoEsperaError);
                                continue;
                            }
                            #endregion

                        }
                    }
                }
                catch (Exception ex)
                {
                    poLog.WriteEntry("Error.Metodo Mover." + ex.Message, EventLogEntryType.Information);
                    try
                    {
                        this.loDocumentos.EnviarAviso("Error. Mover Archivos: " + ex.Message + " " + ex.Source, lsIndicadorEnvio, Correocuenta, CorreoDestinatario, CorreoServidor, CorreoPuerto, CorreoCP);
                        continue;
                    }
                    catch (Exception e)
                    {
                        poLog.WriteEntry("Error. " + e.Message);
                        continue;
                    }
                }
                GC.Collect();
            }
        }
        #endregion
    }
}