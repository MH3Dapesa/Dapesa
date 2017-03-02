using Dapesa.Documentos.XML.Reglas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Dapesa.AccesoDatos.Entidades;
using Dapesa.Comun.Entidades;
using Dapesa.Criptografia.Comun;
using Dapesa.Criptografia.Reglas;
using Dapesa.Seguridad.Entidades;
using Dapesa.Seguridad.Reglas;
using System.Diagnostics;
using System.Data;
using System.Net.Mail;

namespace Dapesa.Ventas.Pedidos.Reglas
{
    public class DiagPedidos
    {

        private MailMessage Mail;


        #region Metodos

        public void Monitoreo(EventLog poLog)
        {

            while (true)
            {

                Thread.Sleep(int.Parse(ConfigurationManager.AppSettings["TemporizadorProceso"]));

                #region Validar dias/horas de actividad/inactividad

                DateTime loFechaHoraActual = DateTime.Now;

                if (loFechaHoraActual.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }
                else
                {
                    if (loFechaHoraActual.DayOfWeek == DayOfWeek.Saturday)
                    {
                        if ((TimeSpan)loFechaHoraActual.TimeOfDay < TimeSpan.Parse(ConfigurationManager.AppSettings["HoraReanudacion"]) ||
                            (TimeSpan)loFechaHoraActual.TimeOfDay > TimeSpan.Parse(ConfigurationManager.AppSettings["HoraDetencionSabado"]))
                        {
                            continue;
                        }
                        else
                        {
                            ConsultarPedidos(poLog);
                        }
                    }
                    else
                    {
                        if ((TimeSpan)loFechaHoraActual.TimeOfDay < TimeSpan.Parse(ConfigurationManager.AppSettings["HoraReanudacion"]) ||
                            (TimeSpan)loFechaHoraActual.TimeOfDay > TimeSpan.Parse(ConfigurationManager.AppSettings["HoraDetencion"]))
                        {
                            continue;
                        }
                        else
                        {
                            ConsultarPedidos(poLog);
                        }
                    }
                }



                #endregion


                GC.Collect();
            }


        }

        #region Metodos

        private void ConsultarPedidos(EventLog poLog)
        {
            try
            {
                string[] lsClaveSucursales = ConfigurationManager.AppSettings["ClaveSucursales"].Split(new Char[] { ';' });
                int lnRangoDias = int.Parse(ConfigurationManager.AppSettings["RangoDias"]);
                string lsCorreoAsuntoPedidos = ConfigurationManager.AppSettings["CorreoAsuntoPedidos"];
                string lsCorreoAsuntoFacturas = ConfigurationManager.AppSettings["CorreoAsuntoFacturas"];

                for (int i = 0; i <= lsClaveSucursales.Length - 1; i++)
                {

                    string lsClaveMarcas = ConfigurationManager.AppSettings["ClaveMarcas" + lsClaveSucursales[i]];
                    string lsClaveLineas = ConfigurationManager.AppSettings["ClaveLineas" + lsClaveSucursales[i]];
                    string lsClaveArticulos = ConfigurationManager.AppSettings["ClaveArticulos" + lsClaveSucursales[i]];
                    string lsClaveEstados = ConfigurationManager.AppSettings["ClaveEstados" + lsClaveSucursales[i]];
                    string lsClaveClientes = ConfigurationManager.AppSettings["ClaveClientes" + lsClaveSucursales[i]];
                    bool loCoincidirEstados = bool.Parse(ConfigurationManager.AppSettings["CoincidirEstados" + lsClaveSucursales[i]]);
                    bool loCoincidirClientes = bool.Parse(ConfigurationManager.AppSettings["CoincidirClientes" + lsClaveSucursales[i]]);
                    string lsCorreoDestinatario = ConfigurationManager.AppSettings["CorreoDestinatario" + lsClaveSucursales[i]];
                    DiagnosticoPedidos loDiagnosticoPedidos = new DiagnosticoPedidos();
                    DataTable loRegistrosPedidos = loDiagnosticoPedidos.BuscarPedidos((Sesion)EstablecerSesion(), lnRangoDias, int.Parse(lsClaveSucursales[i]), lsClaveMarcas, lsClaveLineas, lsClaveArticulos, lsClaveEstados, lsClaveClientes, loCoincidirEstados, loCoincidirClientes);
                    ObtenerMensaje(loRegistrosPedidos, lsCorreoDestinatario, lsCorreoAsuntoPedidos, "<b>INFORMACI&Oacute;N DE PEDIDOS NO AUTORIZADOS</b> <br/><br/>", "<b>FECHA DEL PEDIDO:&nbsp;", "NUMERO DEL PEDIDO:&nbsp;", lsClaveLineas, lsClaveArticulos);

                    DataTable loRegistrosFacturas = loDiagnosticoPedidos.BuscarFacturas((Sesion)EstablecerSesion(), lnRangoDias, int.Parse(lsClaveSucursales[i]), lsClaveMarcas, lsClaveLineas, lsClaveArticulos, lsClaveEstados, lsClaveClientes, loCoincidirEstados, loCoincidirClientes);
                    ObtenerMensaje(loRegistrosFacturas, lsCorreoDestinatario, lsCorreoAsuntoFacturas, "<b>INFORMACI&Oacute;N DE FACTURAS NO AUTORIZADAS</b> <br/><br/>", "<b>FECHA DE FACTURA:&nbsp;", "NUMERO DE FACTURA:&nbsp;", lsClaveLineas, lsClaveArticulos);
                    //poLog.WriteEntry("CONSULTA TERMINADA.", EventLogEntryType.Information);
                }
            }
            catch (Exception ex)
            {
                poLog.WriteEntry("ERROR EXCEPTION...ERROR. EN EL SERVICIO DIAGNOSTICO PEDIDO" + ex, EventLogEntryType.Information);
                EnviarEmail("ERROR EXCEPTION..." + ex, "ERROR. EN EL SERVICIO DIAGNOSTICO PEDIDO", ConfigurationManager.AppSettings["CorreoException"]);
                Thread.Sleep(int.Parse(ConfigurationManager.AppSettings["TiempoException"]));
                ex.Source = string.Empty;
            }
        }

        private Sesion EstablecerSesion()
        {

            Administrador loAdministrador = new Administrador();
            Cifrado loCifrado = new Cifrado(Criptografia.Comun.Definiciones.TipoCifrado.AES);
            Conexion loConexion = new Conexion()
            {
                BaseDatos = "SIIL",
                Credenciales = new Credenciales()
                {
                    Cifrado = loCifrado,
                    Contrasenia = loCifrado.Cifrar("isilav"),
                    Usuario = "SIIL_OWNER"
                },
                Tipo = Dapesa.Comun.Definiciones.TipoConexion.CredencialesExplicitas,
                TipoCliente = Dapesa.Comun.Definiciones.TipoCliente.Oracle
            };

            Sesion loSesion = loAdministrador.ObtenerSesion(loConexion);
            loSesion.Estatus = Seguridad.Comun.Definiciones.EstatusSesion.Iniciada;
            return loSesion;
        }

        private void ObtenerMensaje(DataTable loRegistros, string lsCorreoDestinatario, string lsCorreoAsunto, string lsTituloMensaje, string lsEtiquetaFecha, string lsEtiquetaNumero, string lsClaveLineas, string lsClaveArticulos)
        {
            if (loRegistros.Rows.Count > 0)
            {
                StringBuilder lsMensaje = new StringBuilder();

                for (int i = 0; i < loRegistros.Rows.Count; i++)
                {
                    DateTime lofecha = DateTime.Parse(loRegistros.Rows[i]["FECHA"].ToString());
                    //string loLinea = (lsClaveLineas.Length == 0) ? string.Empty : ("<b>LINEA:&nbsp;</b>" + loRegistros.Rows[i]["CLAVE_LINEA"].ToString() + "&nbsp;-&nbsp;" + loRegistros.Rows[i]["LINEA"].ToString() + "<br/>");
                    //string loArticulo = (lsClaveArticulos.Length == 0) ? string.Empty : ("<b>ARTICULO:&nbsp;</b>" + loRegistros.Rows[i]["ART_CLAVE"].ToString() + "&nbsp;-&nbsp;" + loRegistros.Rows[i]["ARTICULO"].ToString());
                    lsMensaje.AppendLine(
                        "<div style='font-size:13px;'>" +
                        lsTituloMensaje +
                        lsEtiquetaFecha + "<b style='background-color: yellow;'>" + lofecha.ToString("dd/MM/yyyy") + "</b>" + " &nbsp;&nbsp;&nbsp;" +
                        lsEtiquetaNumero + "<b style='background-color: yellow;'>" + loRegistros.Rows[i]["FOLPED_FOLIO"].ToString() + "&nbsp;-&nbsp;" + loRegistros.Rows[i]["NUMERO"].ToString() + "</b></b><br/>" +
                        "<b>CLAVE DEL CLIENTE:&nbsp;</b>" + "<b style='background-color: yellow;'>" + loRegistros.Rows[i]["CLI_CLAVE"].ToString() + "</b><br/>" +
                        "<b>RAZ&Oacute;N SOCIAL:&nbsp;</b>" + loRegistros.Rows[i]["RAZON_SOCIAL"].ToString() + "<br/>" +
                        "<b>CIUDAD:&nbsp;</b>" + "<b style='background-color: yellow;'>" + loRegistros.Rows[i]["CIUDAD"].ToString() + "</b><br/>" +
                        "<b>VENDEDOR:&nbsp;</b>" + loRegistros.Rows[i]["CLAVE_VENDEDOR"].ToString() + "&nbsp;-&nbsp;" + loRegistros.Rows[i]["VENDEDOR"].ToString() + "<br/>" +
                        "<b>MARCA:&nbsp;</b>" + loRegistros.Rows[i]["CLAVE_MARCA"].ToString() + "&nbsp;-&nbsp;" + loRegistros.Rows[i]["MARCA"].ToString() + "<br/>" +
                        //loLinea +
                        //loArticulo +
                        "</div> <br/><br/>");
                }
                EnviarEmail(lsMensaje.ToString(), lsCorreoAsunto, lsCorreoDestinatario);
            }

        }

        private void EnviarEmail(string lsMensaje, string lsAsunto, string lsCorreoDestinatario)
        {
            Mail = new MailMessage();


            string[] lsDestinatarios = lsCorreoDestinatario.Split(new Char[] { ';' });

            foreach (string poDestinatarios in lsDestinatarios)
                Mail.To.Add(new MailAddress(poDestinatarios.ToString()));
            //Mail.To.Add(new MailAddress(ConfigurationManager.AppSettings["CorreoDestinatario"]));

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

        #endregion Metodos

        #endregion
    }
}
