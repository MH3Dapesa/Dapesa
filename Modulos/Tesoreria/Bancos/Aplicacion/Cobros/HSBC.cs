using Dapesa.Tesoreria.Bancos.IU.Cobros.Reportes;
using Dapesa.Tesoreria.Bancos.Reglas;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Dapesa.Tesoreria.Bancos.IU.Cobros
{
    public partial class HSBC : Form
    {
        public HSBC()
        {
            InitializeComponent();
            #region Inicializar Componentes
            CargarImpresoras();
            sfdGuardar.RestoreDirectory = ofdArchivo.RestoreDirectory = true;
            ofdArchivo.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
            sfdGuardar.Filter = "files (*.pdf, *.xls, *.xlsx)|*.pdf; *.xls; *.xlsx";
            #endregion
        }

        #region Metodo

        private void Procesar(string loRutaArchivoMovimientos, int lnIniciarLecturaMovimientos, string loRutaArchivoCodigosMovimientos)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;

            try
            {
                txtArchivo.Text = loRutaArchivoMovimientos;

                #region Filtrar datos solo abonos.
                DataTable poMovimientos = LeerArchivoHTML(loRutaArchivoMovimientos, lnIniciarLecturaMovimientos);
                lblEstatus.Text = "Registros Procesados: " + poMovimientos.Rows.Count.ToString();
                #endregion

                poMovimientos.Columns.Add("Sucursal", typeof(string));
                poMovimientos.Columns.Add("Cliente", typeof(string));
                poMovimientos.Columns.Add("Lugar", typeof(int));
                pbMovimientos.Minimum = 1;
                pbMovimientos.Maximum = poMovimientos.Rows.Count;
                pbMovimientos.Value = 1;
                pbMovimientos.Step = 1;
                poMovimientos = GenerarVista(poMovimientos);
                this.gvMovimientosCorrectos.DataSource = ObtenerSucursal(poMovimientos);
                gvMovimientosCorrectos.Columns["Lugar"].DisplayIndex = 0;
                gvMovimientosErrores.Columns["Lugar"].DisplayIndex = 0;
                MessageBox.Show("Archivo procesado correctamente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private DataTable GenerarVista(DataTable poMovimientos)
        {
            poMovimientos.Columns["Columna8"].ColumnName = "Ref_banco";
            poMovimientos.Columns["Columna9"].ColumnName = "Narrativa_adicional";
            poMovimientos.Columns["Columna10"].ColumnName = "Ref_cliente";
            poMovimientos.Columns["Columna11"].ColumnName = "Tipo_TRN";
            poMovimientos.Columns["Columna12"].ColumnName = "Fecha_deposito";
            poMovimientos.Columns["Columna13"].ColumnName = "Importe_deposito";
            return poMovimientos;
        }

        private static DataTable LeerArchivoHTML(string loRutaArchivo, int lnRow)
        {
            try
            {
                WebClient client = new WebClient();
                string loHtml = client.DownloadString(loRutaArchivo);

                HtmlAgilityPack.HtmlDocument loDocumento = new HtmlAgilityPack.HtmlDocument();
                loDocumento.LoadHtml(loHtml);

                DataTable loDatos = new DataTable();

                var table = loDocumento.DocumentNode
                            .Descendants("tr")
                            .Select(n => n.Elements("td")
                                .Select(e => e.InnerText.Replace(" ",string.Empty)).ToArray());

                for (int i = 1; i < 18; ++i )
                {
                    loDatos.Columns.Add("Columna" + i.ToString());
                }

                foreach (var loFila in table)
                {
                    loDatos.Rows.Add(loFila);
                }

                loDatos.Rows.RemoveAt(0);

                for (int i = loDatos.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow loFilasVacias = loDatos.Rows[i];
                    if (loFilasVacias["Columna13"].ToString() == string.Empty)
                    {
                        loFilasVacias.Delete();
                    }
                }

                for (int lnIndiceReversa = loDatos.Columns.Count - 1; lnIndiceReversa >= 13; lnIndiceReversa--)
                {
                    loDatos.Columns.RemoveAt(lnIndiceReversa);
                }

                for (int lnIndiceAdelante = 6; lnIndiceAdelante >= 0; lnIndiceAdelante--)
                {
                    loDatos.Columns.RemoveAt(lnIndiceAdelante);
                }

                return loDatos;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }
        
        private DataTable ObtenerSucursal(DataTable poMovimientos)
        {
            Movimientos loSucursal = new Movimientos();
            DataTable loResultadoSinSucursal = poMovimientos.Clone();
            for (int lnFila = 0; lnFila < poMovimientos.Rows.Count; lnFila++)
            {
                DataTable loResultado = loSucursal.ObtenerSucursal(((InicioSesion)this.MdiParent.Owner).Sesion, poMovimientos.Rows[lnFila][1].ToString());

                if (loResultado.Rows.Count > 0)
                {
                    poMovimientos.Rows[lnFila][6] = loResultado.Rows[0][2].ToString();
                    poMovimientos.Rows[lnFila][7] = loResultado.Rows[0][0].ToString();
                }
                else
                {
                    DataRow dr = loResultadoSinSucursal.NewRow();
                    for (int lnEncabezado = 0; lnEncabezado < poMovimientos.Columns.Count; lnEncabezado++)
                    {
                        dr[lnEncabezado] = poMovimientos.Rows[lnFila][lnEncabezado];
                    }
                    loResultadoSinSucursal.Rows.Add(dr);
                    loResultadoSinSucursal.Rows[loResultadoSinSucursal.Rows.Count - 1]["Lugar"] = loResultadoSinSucursal.Rows.Count;
                }
                pbMovimientos.PerformStep();
            }

            this.gvMovimientosErrores.DataSource = loResultadoSinSucursal;
            DataTable loMovimientosFiltrados = poMovimientos.Clone();
            DataRow[] loQueryFiltrar = poMovimientos.Select("Sucursal <> ''");
            if (loQueryFiltrar.Length > 0)
            {
                int lnLugar = 1;
                foreach (DataRow fila in loQueryFiltrar)
                    loMovimientosFiltrados.Rows.Add(fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6], fila[7], lnLugar++);
            }
            return loMovimientosFiltrados;

        }

        private void CargarImpresoras()
        {
            foreach (string loImpresora in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cbImpresora.Items.Add(loImpresora);
            }
        }

        private void Imprimir(DataTable loMovimientos, string lsTituloReporte)
        {
            MovimientosHSBC loInforme = new MovimientosHSBC();
            loInforme.Parameters["Titulo"].Value = lsTituloReporte;
            loInforme.Parameters["Usuario"].Value = ((InicioSesion)this.MdiParent.Owner).Sesion.Usuario.Nombre;
            loInforme.DataSource = loMovimientos;
            loInforme.FillDataSource();
            loInforme.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            using (ReportPrintTool printTool = new ReportPrintTool(loInforme))
            {
                if (cbImpresora.SelectedIndex.Equals(-1))
                {
                    MessageBox.Show("Debe de seleccionar una impresora.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                printTool.Print(cbImpresora.SelectedItem.ToString());
            }
        }

        private void Guardar(DataTable loMovimientos, string lsTituloReporte, int TipoArchivo)
        {
            MovimientosHSBC loInforme = new MovimientosHSBC();
            DialogResult loDialogo = sfdGuardar.ShowDialog();

            try
            {
                if (loDialogo != DialogResult.OK || sfdGuardar.FileName == string.Empty)
                    return;

                loInforme.Parameters["Titulo"].Value = lsTituloReporte;
                loInforme.Parameters["Usuario"].Value = ((InicioSesion)this.MdiParent.Owner).Sesion.Usuario.Nombre;
                loInforme.DataSource = loMovimientos;
                loInforme.FillDataSource();

                switch (TipoArchivo)
                {
                    case 1:
                        loInforme.ExportToXlsx(sfdGuardar.FileName.Replace(".pdf", ".xlsx"));
                        break;
                    case 2:
                        loInforme.ExportToPdf(sfdGuardar.FileName);
                        break;
                }

                MessageBox.Show("Documento guardado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error. ¡El documento no puede ser guardado!.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #endregion

        #region Eventos

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            DialogResult loDialogo = ofdArchivo.ShowDialog();

            if (loDialogo == DialogResult.OK)
            {
                Procesar(ofdArchivo.FileName, 225, Path.Combine(Application.StartupPath, @"C:\Dapesa\Desarrollo\Proyectos\CodigoFuente\Dapesa\Modulos\Tesoreria\Bancos\Aplicacion\Cobros\Documentos\Codigos_HSBC.csv"));
            }
        }

        private void btnImprimirMovimientoC_Click(object sender, EventArgs e)
        {
            Imprimir((DataTable)gvMovimientosCorrectos.DataSource, "MOVIMIENTOS HSBC - CORRECTO");
        }

        private void btnExportarXlsxC_Click(object sender, EventArgs e)
        {
            Guardar((DataTable)gvMovimientosCorrectos.DataSource, "MOVIMIENTOS HSBC - CORRECTO", (int)Comun.Definiciones.TipoArchivo.EXCEL);
        }

        private void btnGuardarMovimientoC_Click(object sender, EventArgs e)
        {
            Guardar((DataTable)gvMovimientosCorrectos.DataSource, "MOVIMIENTOS HSBC - CORRECTO", (int)Comun.Definiciones.TipoArchivo.PDF);
        }

        private void btnImprimirMovimientoR_Click(object sender, EventArgs e)
        {
            Imprimir((DataTable)gvMovimientosErrores.DataSource, "MOVIMIENTOS HSBC - ERROR");
        }

        private void btnExportarXlsxR_Click(object sender, EventArgs e)
        {
            Guardar((DataTable)gvMovimientosErrores.DataSource, "MOVIMIENTOS HSBC - ERROR", (int)Comun.Definiciones.TipoArchivo.EXCEL);
        }

        private void btnGuardarMovimientoR_Click(object sender, EventArgs e)
        {
            Guardar((DataTable)gvMovimientosErrores.DataSource, "MOVIMIENTOS HSBC - ERROR", (int)Comun.Definiciones.TipoArchivo.PDF);
        }        

        #endregion

        
    }
}
