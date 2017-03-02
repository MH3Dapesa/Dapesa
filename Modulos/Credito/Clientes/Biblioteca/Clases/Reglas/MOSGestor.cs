using Dapesa.Comun.Entidades;
using Dapesa.Criptografia.Reglas;
using Dapesa.Seguridad.Entidades;
using Dapesa.Seguridad.Reglas;
using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Dapesa.Credito.Clientes.Reglas
{

    public class MOSGestor
    {
        private MailMessage Mail;

        #region Metodos

        public void Monitoreo(EventLog poLog)
        {
            try
            {
                Sesion poSesion = (Sesion)EstablecerSesion(poLog);
                string[] lsClaveSucursales = ConfigurationManager.AppSettings["ClaveSucursales"].Split(new Char[] { ';' });
                string lsCorreoAsunto = ConfigurationManager.AppSettings["CorreoAsunto"];
                string lsCorreoAlerta = ConfigurationManager.AppSettings["CorreoAlerta"];

                for (int lnSucursal = 0; lnSucursal <= lsClaveSucursales.Length - 1; lnSucursal++)
                {
                    string lsCorreoDestinatario = ConfigurationManager.AppSettings["CorreoDestinatario" + lsClaveSucursales[lnSucursal]];
                    HelperMOSGestor loMonitoreoSaldos = new HelperMOSGestor();
                    DataTable loClientes = loMonitoreoSaldos.BuscarSaldosClientes(poSesion, int.Parse(lsClaveSucursales[lnSucursal]));
                    bool loInactivarClientes = loMonitoreoSaldos.InactivarClientes(poSesion, loClientes, poLog);

                    if (loInactivarClientes)
                    {
                        DataSet loClientesSaldoVencido = new DataSet();
                        loClientesSaldoVencido.Merge(loClientes.Select("(SALDO_PADRE > 0 OR SALDO_HIJO > 0)"));

                        if (loClientesSaldoVencido.Tables.Count > 0)
                        {
                            AgruparClientePersonal(loClientes, lsCorreoAsunto, poLog);
                            ObtenerMensaje(loClientes, lsCorreoDestinatario, lsCorreoAsunto, poLog);
                            ObtenerMensaje(loClientes,
                                           NotificarPersonal(poSesion, loClientes, lsCorreoDestinatario, int.Parse(lsClaveSucursales[lnSucursal])),
                                           lsCorreoAsunto, poLog);
                        
                        }
                        else
                        {
                            loClientes.Clear();
                            ObtenerMensaje(loClientes,
                                           NotificarPersonal(poSesion, loClientes, lsCorreoDestinatario, int.Parse(lsClaveSucursales[lnSucursal])),
                                           lsCorreoAsunto, poLog);
                        }
                    }
                    else
                    {
                        EnviarEmail("Ocurrio un problema al inactivar clientes con saldo vencido.", lsCorreoAsunto, lsCorreoAlerta, poLog);
                    }
                }
            }
            catch (Exception ex)
            {
                poLog.WriteEntry("ERROR METODO MONITOREO SALDOS." + ex, EventLogEntryType.Information);
            }
            GC.Collect();
        }

        private Sesion EstablecerSesion(EventLog poLog)
        {
            Administrador loAdministrador = new Administrador();
            Cifrado loCifrado = new Cifrado(Criptografia.Comun.Definiciones.TipoCifrado.AES);
            Conexion loConexion = new Conexion()
            {
                BaseDatos = "SIIL",
                Credenciales = new Credenciales()
                {
                    Cifrado = loCifrado,
                    Contrasenia = loCifrado.Cifrar(Descifrar(ConfigurationManager.AppSettings["Password"], poLog)),
                    Usuario = ConfigurationManager.AppSettings["Usuario"]
                },
                Tipo = Dapesa.Comun.Definiciones.TipoConexion.CredencialesExplicitas,
                TipoCliente = Dapesa.Comun.Definiciones.TipoCliente.Oracle
            };

            Sesion loSesion = loAdministrador.ObtenerSesion(loConexion);
            loSesion.Estatus = Seguridad.Comun.Definiciones.EstatusSesion.Iniciada;
            return loSesion;
        }

        private void ObtenerMensaje(DataTable loClientes, string lsCorreoDestinatario, string lsCorreoAsunto, EventLog poLog)
        {
            StringBuilder lsMensaje = new StringBuilder();
            lsMensaje.AppendLine("<table width='770' id='tblEncabezado'>"
                                     + "<tr style='font-size:12pt;font-weight:bold;'>"
                                     + "<td width='230' rowspan=2 style='text-align:center;'><img src='http://ve-iis02/Directorio/Img/dapesa500.png' width='100' head='50'/> </td>"
                                     + "<td width='540' >Cuentas Mostrador a cr&eacute;dito con saldo vencido</td>"
                                     + "</tr>"
                                     + "<tr style='font-size:8pt'>"
                                     + "<td width='540' head='40'>Fecha de emisi&oacute;n: " + System.DateTime.Now.ToString("dddd, d MMMM yyyy, HH:mm:ss tt", CultureInfo.CreateSpecificCulture("es-MX")) + "</td>"
                                     + "</tr>"
                                     + "<tr style='font-size:6pt'>"
                                     + "<td width='230'>DISTRIBUIDORA DE AUTOPARTES PESCADOR S.A. DE C.V.</td>"
                                     + "</tr></table>"
                                     + "<br/>");

            if (loClientes.Rows.Count > 0)
            {
                lsMensaje.AppendLine("<table id='tblContenido' border='2' style='font-size:9pt'>"
                                         + "<tr style='text-align:center;font-weight:bold;background-color:#483D8B;color:white;border: 3px solid white;'>"
                                         + "<td width='50'>CLIENTE</td>"
                                         + "<td width='220'>RAZ&Oacute;N SOCIAL</td>"
                                         + "<td width='220'>VENDEDOR</td>"
                                         + "<td width='80'>D&Iacute;AS ATRASO PADRE</td>"
                                         + "<td width='100'>SALDO VENCIDO PADRE</td>"
                                         + "<td width='80'>D&Iacute;AS ATRASO HIJO</td>"
                                         + "<td width='100'>SALDO VENCIDO HIJO</td>"
                                         + "<td width='200'>AUXILIAR</td>"
                                         + "</tr>");

                for (int i = 0; i < loClientes.Rows.Count; i++)
                {
                    if (decimal.Parse(loClientes.Rows[i]["SALDO_PADRE"].ToString()) > 0 || decimal.Parse(loClientes.Rows[i]["SALDO_HIJO"].ToString()) > 0)
                        lsMensaje.AppendLine("<tr style='text-align:left; border:2px solid black; font-size:8pt;'> "
                                     + "<td width='50' style='padding:0px 10px;'>" + loClientes.Rows[i]["CLAVE"].ToString() + "</td>"
                                     + "<td width='220' style='padding:0px 10px;'>" + loClientes.Rows[i]["RAZON_SOCIAL"].ToString() + "</td>"
                                     + "<td width='220' style='padding:0px 10px;'>" + loClientes.Rows[i]["VEND_CLAVE"].ToString() + " " + loClientes.Rows[i]["VENDEDOR"].ToString() + "</td>"
                                     + "<td width='80' style='padding:0px 10px;'>" + loClientes.Rows[i]["DIAS_ATRASO_PADRE"].ToString() + "</td>"
                                     + "<td width='100' style='padding:0px 10px; " + ((decimal.Parse(loClientes.Rows[i]["SALDO_PADRE"].ToString()) > 0) ? "background-color:#d33739; color:white" : "") + "'>" + decimal.Parse(loClientes.Rows[i]["SALDO_PADRE"].ToString()).ToString("N2", CultureInfo.CurrentCulture) + "</td>"
                                     + "<td width='80' style='padding:0px 10px;'>" + loClientes.Rows[i]["DIAS_ATRASO_HIJO"].ToString() + "</td>"
                                     + "<td width='100' style='padding:0px 10px; " + ((decimal.Parse(loClientes.Rows[i]["SALDO_HIJO"].ToString()) > 0) ? "background-color:#d33739; color:white" : "") + "'>" + decimal.Parse(loClientes.Rows[i]["SALDO_HIJO"].ToString()).ToString("N2", CultureInfo.CurrentCulture) + "</td>"
                                     + "<td width='100' style='padding:0px 10px;'>" + ((loClientes.Rows[i]["PERSONAL"] != DBNull.Value) ? ((loClientes.Rows[i]["EMAIL_PERSONAL"] != DBNull.Value)
                                     ? loClientes.Rows[i]["PERSONAL"].ToString() : loClientes.Rows[i]["PERSONAL"].ToString().Substring(0, 16) + "**NO E-MAIL**") : "NO ASIGNADO") + "</td>"
                                     + "</tr>");
                }
                lsMensaje.AppendLine("</table>");

            }
            else
            {
                lsMensaje.AppendLine("<div style='text-align:left; font-size:16pt; font-weight: bold; width:700px'> "
                                            + "NO EXISTEN CLIENTES CON SALDO VENCIDO DE LAS CUENTAS PADRE E HIJO."
                                            + "</div>");
            }
            EnviarEmail(lsMensaje.ToString(), lsCorreoAsunto, lsCorreoDestinatario, poLog);
        }

        private void EnviarEmail(string lsMensaje, string lsAsunto, string lsCorreoDestinatario, EventLog poLog)
        {
            try
            {
                Mail = new MailMessage();
                string[] lsDestinatarios = lsCorreoDestinatario.Split(new Char[] { ';' });

                foreach (string poDestinatarios in lsDestinatarios)
                    Mail.To.Add(new MailAddress(poDestinatarios.ToString()));

                Mail.From = new MailAddress(ConfigurationManager.AppSettings["CorreoCuenta"]);
                Mail.Subject = lsAsunto;
                Mail.Body = lsMensaje;
                Mail.IsBodyHtml = true;

                SmtpClient cliente = new SmtpClient(ConfigurationManager.AppSettings["CorreoServidor"], int.Parse(ConfigurationManager.AppSettings["CorreoPuerto"]));
                using (cliente)
                {
                    cliente.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["CorreoCuenta"], ConfigurationManager.AppSettings["CorreoCP"]);
                    cliente.EnableSsl = false;
                    cliente.Send(Mail);
                }
            }
            catch (Exception ex)
            {
                poLog.WriteEntry("ERROR NO SE A PODIDO ENVIAR EL EMAIL." + ex, EventLogEntryType.Information);
            }
        }

        private void AgruparClientePersonal(DataTable loClientes, string lsCorreoAsunto, EventLog poLog)
        {
            DataTable loPersonal = new DataTable();
            loPersonal = loClientes.DefaultView.ToTable(true, "PERSONAL");
            foreach (DataRow Personal in loPersonal.Rows)
            {
                if (Personal[0] != DBNull.Value)
                {
                    DataSet loClientesPersonal = new DataSet();
                    loClientesPersonal.Merge(loClientes.Select("PERSONAL = '" + Personal[0] + "' AND (SALDO_PADRE > 0 OR SALDO_HIJO > 0)"));

                    if (loClientesPersonal.Tables.Count > 0)
                    {
                        loClientesPersonal.Tables[0].DefaultView.Sort = "VEND_CLAVE asc";
                        if (loClientesPersonal.Tables[0].Rows[0]["EMAIL_PERSONAL"] != DBNull.Value)
                            ObtenerMensaje(loClientesPersonal.Tables[0], loClientesPersonal.Tables[0].Rows[0]["EMAIL_PERSONAL"].ToString(), lsCorreoAsunto, poLog);
                    }
                }
            }
        }

        private string NotificarPersonal(Sesion poSesion, DataTable loClientes, string lsCorreoDestinatario, int lnSucursal)
        {
            
            string lsCorreoDestinatarioTemp = string.Empty;
            HelperMOSGestor loGestor = new HelperMOSGestor();
            DataTable loResultado = loGestor.ObtenerEmailPersonal(poSesion, lnSucursal);

            if (loClientes.Rows.Count > 0)
            {
                string[] lsDestinatarios = lsCorreoDestinatario.Split(new Char[] { ';' });
                lsCorreoDestinatario = "E_MAIL NOT IN( ";

                foreach (string poDestinatarios in lsDestinatarios)
                {
                    lsCorreoDestinatario = lsCorreoDestinatario + "'" + poDestinatarios + "' ,";
                }
                foreach (DataRow lsEmailPersonal in loClientes.Rows)
                {
                    lsCorreoDestinatario = lsCorreoDestinatario  + "'" + lsEmailPersonal["EMAIL_PERSONAL"].ToString() + "' ,";
                }

                lsCorreoDestinatario = lsCorreoDestinatario.TrimEnd(',');

                foreach (DataRow lsCliente in loResultado.Select(lsCorreoDestinatario+ ")"))
                {
                    lsCorreoDestinatarioTemp = lsCorreoDestinatarioTemp + lsCliente["E_MAIL"].ToString() + ";";
                }
            }
            else
            {
                foreach (DataRow lsCliente in loResultado.Rows)
                    lsCorreoDestinatario = lsCorreoDestinatario + ";" + lsCliente["E_MAIL"];
                lsCorreoDestinatarioTemp = lsCorreoDestinatario;
            }

            loClientes.Clear();
            return lsCorreoDestinatarioTemp.TrimEnd(';');
        }

        /// <summary>
        /// Descifra la contraseña colocada en el App.Config del usuario de BD.
        /// </summary>
        /// <param name="pscadena">Cadena cifrada</param>
        private string Descifrar(string pscadena, EventLog poLog)
        {
            try
            {
                byte[] loLlave;
                byte[] loArreglo = Convert.FromBase64String(pscadena);

                MD5CryptoServiceProvider loMD5 = new MD5CryptoServiceProvider();
                loLlave = loMD5.ComputeHash(UTF8Encoding.UTF8.GetBytes("DAPESA_SIIL_APP"));
                loMD5.Clear();
                TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
                tripledes.Key = loLlave;
                tripledes.Mode = CipherMode.ECB;
                tripledes.Padding = PaddingMode.PKCS7;
                ICryptoTransform loConvertir = tripledes.CreateDecryptor();
                byte[] loResultado = loConvertir.TransformFinalBlock(loArreglo, 0, loArreglo.Length);
                tripledes.Clear();

                string poCadenaDescifrada = UTF8Encoding.UTF8.GetString(loResultado);
                return poCadenaDescifrada;
            }
            catch (Exception ex)
            {
                poLog.WriteEntry("ERROR, AL INICIAR SESIÓN." + ex, EventLogEntryType.Information);
                return "";
            }
        }

        #endregion Metodos

    }
}
