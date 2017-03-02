using Dapesa.Seguridad.Entidades;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dapesa.Credito.Clientes.IU.Gestor
{
    public partial class Contenido : Form, IMessageFilter
    {
        #region Constructor

        public Contenido()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            ttInformacion.SetToolTip(btnGenerar, "Generar informe (F8)");
            dtpAnio.Format = DateTimePickerFormat.Custom;
            dtpAnio.CustomFormat = "yyyy";
            dtpAnio.ShowUpDown = true;
        }

        #endregion

        #region Eventos

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            this.GenerarInforme(txtCliente.Text, dtpAnio.Value.Year);
        }

        private void Contenido_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            txtCliente.Focus();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            sfdRutaArchivo.Title = "GUARDAR ARCHIVO.";
            sfdRutaArchivo.Filter = "Pdf Files (.pdf)|*.pdf";
            DialogResult result = sfdRutaArchivo.ShowDialog();

            if (result == DialogResult.OK)
            {
                GuardarPDF(rvReporte, sfdRutaArchivo.FileName);
                MessageBox.Show("¡Archivo creado correctamente!", "Mensaje", MessageBoxButtons.OK);
            }
        }

        #endregion

        #region Metodos

        protected void GenerarInforme(string psClaveCliente, int pnAnio)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;

            try
            {
                Reglas.ClienteMOSCredito loGestor = new Reglas.ClienteMOSCredito();

                rvReporte.Reset();
                //rvReporte.ProcessingMode = ProcessingMode.Local;
                rvReporte.LocalReport.ReportPath = "Informes/MOSCredito.rdl";
                rvReporte.LocalReport.ReportEmbeddedResource = "Informes/MOSCredito.rdl";

                rvReporte.LocalReport.DisplayName = "ClienteMOSCredito_" + psClaveCliente + "_" + pnAnio.ToString();
                DataTable loResultado = loGestor.Obtener(((InicioSesion)this.MdiParent.Owner).Sesion, psClaveCliente, pnAnio);
                DataTable loResultadoPromedioMesCompleto= new DataTable();

                loResultadoPromedioMesCompleto.Columns.Add("IMPORTE", typeof(Decimal));
                loResultadoPromedioMesCompleto.Columns.Add("IMPORTEM", typeof(Decimal));
                

                Decimal liSumaImporteCliente =0;
                Decimal liSumaImporteClienteM = 0;

                int a = 0;
                a = System.DateTime.Now.Month; 
                for (int i = 0; i < loResultado.Rows.Count; i++ )
                {
                    if (System.DateTime.Now.Year == Int32.Parse(pnAnio.ToString()))
                    {
                        if (Int32.Parse(loResultado.Rows[i]["MES"].ToString()) < Int32.Parse(System.DateTime.Now.ToString("MM")) && !loResultado.Rows[i]["CLIENTE"].ToString().Contains("M"))
                        {
                            liSumaImporteCliente += Convert.ToDecimal(loResultado.Rows[i]["IMPORTE"].ToString());
                        }
                        else
                        {
                            if (Int32.Parse(loResultado.Rows[i]["MES"].ToString()) < Int32.Parse(System.DateTime.Now.ToString("MM")) && loResultado.Rows[i]["CLIENTE"].ToString().Contains("M"))
                            {
                                liSumaImporteClienteM += Convert.ToDecimal(loResultado.Rows[i]["IMPORTE"].ToString());
                            }
                        }
                    }
                    else
                    {
                        if (System.DateTime.Now.Year > Int32.Parse(pnAnio.ToString()))
                        {
                            if (!loResultado.Rows[i]["CLIENTE"].ToString().Contains("M"))
                            {
                                liSumaImporteCliente += Convert.ToDecimal(loResultado.Rows[i]["IMPORTE"].ToString());
                            }
                            else
                            {
                                if (loResultado.Rows[i]["CLIENTE"].ToString().Contains("M"))
                                {
                                    liSumaImporteClienteM += Convert.ToDecimal(loResultado.Rows[i]["IMPORTE"].ToString());
                                }
                            }
                             
                        }
                    }
                    
                }
                loResultadoPromedioMesCompleto.Rows.Add(liSumaImporteCliente,liSumaImporteClienteM);
                rvReporte.LocalReport.DataSources.Add(
                    new ReportDataSource("dsCompras", loResultado));
                rvReporte.LocalReport.DataSources.Add(
                    new ReportDataSource("dsImporteMesCompleto", loResultadoPromedioMesCompleto));
                //rvReporte.LocalReport.DataSources.Add(
                //    new ReportDataSource("dsCompras", loGestor.Obtener(
                //        ((InicioSesion)this.MdiParent.Owner).Sesion, psClaveCliente, pnAnio
                //    )));
                rvReporte.LocalReport.DataSources.Add(
                    new ReportDataSource("dsEncabezado", loGestor.ObtenerEncabezado(
                        ((InicioSesion)this.MdiParent.Owner).Sesion, psClaveCliente, pnAnio
                    )));
                rvReporte.LocalReport.DataSources.Add(
                    new ReportDataSource("dsSaldos", loGestor.ObtenerSaldos(
                        ((InicioSesion)this.MdiParent.Owner).Sesion, psClaveCliente
                    )));

                rvReporte.ShowToolBar = true;
                rvReporte.ShowPrintButton = true;
                rvReporte.ShowZoomControl = false;
                rvReporte.ShowDocumentMapButton = false;
                rvReporte.ShowExportButton = false;
                rvReporte.ShowBackButton = false;
                rvReporte.ShowContextMenu = false;
                rvReporte.ShowRefreshButton = false;
                rvReporte.ShowPageNavigationControls = false;
                rvReporte.ShowFindControls = false;
                rvReporte.ShowZoomControl = true;
                rvReporte.ShowPromptAreaButton = false;
                rvReporte.PromptAreaCollapsed = false;
                rvReporte.ShowStopButton = false;
                rvReporte.ShowParameterPrompts = false;
                rvReporte.RefreshReport();
                btnImprimir.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                this.Enabled = true;
            }
        }

        public void GuardarPDF(ReportViewer viewer, string savePath)
        {
            byte[] Bytes = viewer.LocalReport.Render(format: "PDF", deviceInfo: "");

            using (FileStream stream = new FileStream(savePath, FileMode.Create))
            {
                stream.Write(Bytes, 0, Bytes.Length);
            }
        }


        public bool PreFilterMessage(ref Message poMensajeWindows)
        {
            Keys loCodigo = (Keys)(int)poMensajeWindows.WParam & Keys.KeyCode;

            if (loCodigo == Keys.Snapshot)
            {
                Clipboard.Clear();
                return true;
            }

            return false;
        }

        protected override bool ProcessCmdKey(ref Message poMensajeWindows, Keys poOpcion)
        {
            switch (poOpcion)
            {
                case Keys.F8:
                    this.GenerarInforme(txtCliente.Text, dtpAnio.Value.Year);
                    return true;
                default:
                    return base.ProcessCmdKey(ref poMensajeWindows, poOpcion);
            }
        }

        #endregion

    }
}
