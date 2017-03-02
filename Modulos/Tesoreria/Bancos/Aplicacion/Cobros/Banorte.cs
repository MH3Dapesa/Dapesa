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
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Dapesa.Tesoreria.Bancos.IU.Cobros
{
    public partial class Banorte : Form
    {
        public Banorte()
        {
            InitializeComponent();
            #region Inicializar Componentes
            CargarImpresoras();
            sfdGuardar.RestoreDirectory = ofdArchivo.RestoreDirectory = true;
            ofdArchivo.Filter = "File Default (*.htm;)|*.htm";
            sfdGuardar.Filter = "files (*.pdf, *.xls, *.xlsx)|*.pdf; *.xls; *.xlsx";
            #endregion
        }

        #region Propiedades
        private string psArchivo;

        public string psNombreArchivo
        {
            get { return this.psArchivo; }
            set { this.psArchivo = value; }
        }

        public class CheckBoxHeaderCellEventArgs : EventArgs
        {
            private bool _isChecked;
            public bool IsChecked
            {
                get { return _isChecked; }
            }

            public CheckBoxHeaderCellEventArgs(bool _checked)
            {
                _isChecked = _checked;

            }

        }

        #endregion

        #region Metodo       

        public delegate void CheckBoxHeaderClickHandler(CheckBoxHeaderCellEventArgs e);

        class CheckBoxHeaderCell : DataGridViewColumnHeaderCell
        {
            Size checkboxsize;
            bool ischecked;
            Point location;
            Point cellboundsLocation;
            CheckBoxState state = CheckBoxState.UncheckedNormal;

            public event CheckBoxHeaderClickHandler OnCheckBoxHeaderClick;

            public CheckBoxHeaderCell()
            {
                location = new Point();
                cellboundsLocation = new Point();
                ischecked = false;
            }

            protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
            {
                Point clickpoint = new Point(e.X + cellboundsLocation.X, e.Y + cellboundsLocation.Y);

                if ((clickpoint.X > location.X && clickpoint.X < (location.X + checkboxsize.Width)) && (clickpoint.Y > location.Y && clickpoint.Y < (location.Y + checkboxsize.Height)))
                {
                    ischecked = !ischecked;
                    if (OnCheckBoxHeaderClick != null)
                    {
                        OnCheckBoxHeaderClick(new CheckBoxHeaderCellEventArgs(ischecked));
                        this.DataGridView.InvalidateCell(this);
                    }
                }
                base.OnMouseClick(e);
            }

            protected override void Paint(Graphics graphics, Rectangle clipBounds,
                 Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText,
                DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle
                advancedBorderStyle, DataGridViewPaintParts paintParts)
            {

                base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState,
               value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

                checkboxsize = CheckBoxRenderer.GetGlyphSize(graphics, CheckBoxState.UncheckedNormal);
                location.X = cellBounds.X + (cellBounds.Width / 2 - checkboxsize.Width / 2);
                location.Y = cellBounds.Y + (cellBounds.Height / 2 - checkboxsize.Height / 2);
                cellboundsLocation = cellBounds.Location;

                if (ischecked)
                    state = CheckBoxState.CheckedNormal;
                else
                    state = CheckBoxState.UncheckedNormal;

                CheckBoxRenderer.DrawCheckBox(graphics, location, state);
            }
        } 

        private void Procesar(string loRutaArchivoMovimientos, int lnIniciarLecturaMovimientos, string loRutaArchivoCodigosMovimientos)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;
            DataGridViewCheckBoxColumn loAgregaCheck = new DataGridViewCheckBoxColumn();
            lblProcesados.Text = "0";
            lblImporteCargado.Text = "$ 00.00";

            psArchivo = loRutaArchivoMovimientos;
            gvExistentes.DataSource = null;

            try
            {
                txtArchivo.Text = loRutaArchivoMovimientos;

                #region Filtrar datos solo abonos.
                DataTable poMovimientos = LeerArchivo(loRutaArchivoMovimientos, lnIniciarLecturaMovimientos);
                lblEstatus.Text = "Registros Procesados: " + poMovimientos.Rows.Count.ToString();
                #endregion

                if (gvMovimientosCorrectos.Columns.Count < 1)
                {
                    loAgregaCheck = new DataGridViewCheckBoxColumn();
                    CheckBoxHeaderCell loCheckheader = new CheckBoxHeaderCell();
                    loCheckheader.OnCheckBoxHeaderClick += loCheckheader_OnCheckBoxHeaderClick;
                    loAgregaCheck.HeaderCell = loCheckheader;
                    gvMovimientosCorrectos.Columns.Insert(0, loAgregaCheck);
                }

                if (gvMovimientosErrores.Columns.Count < 1)
                {
                    loAgregaCheck = new DataGridViewCheckBoxColumn();
                    loAgregaCheck.Width = 1;
                    gvMovimientosErrores.Columns.Insert(0, loAgregaCheck);
                    this.gvMovimientosErrores.Columns[0].Resizable = 0;
                }

                poMovimientos.Columns.Add("Tipo_pago", typeof(string));
                poMovimientos.Columns.Add("Suc", typeof(string));
                poMovimientos.Columns.Add("Cliente", typeof(string));
                poMovimientos.Columns.Add("#", typeof(int));
                poMovimientos.Columns.Add("Forma_Pago", typeof(string));
                poMovimientos.Columns.Add("Sucursal", typeof(string));
                poMovimientos.Columns.Add("Status", typeof(string));

                obtenerFormaDePago(poMovimientos);

                pbMovimientos.Minimum = 1;
                pbMovimientos.Maximum = poMovimientos.Rows.Count;
                pbMovimientos.Value = 1;
                pbMovimientos.Step = 1;

                poMovimientos = GenerarVista(poMovimientos);
                this.gvMovimientosCorrectos.DataSource = ObtenerSucursal(ValidaCobro(poMovimientos));

                gvMovimientosCorrectos.Columns["#"].DisplayIndex = 1;
                gvMovimientosErrores.Columns["#"].DisplayIndex = 1;

                this.gvMovimientosCorrectos.Columns["Columna10"].Visible = false;
                this.gvMovimientosCorrectos.Columns["Forma_Pago"].Visible = false;
                this.gvMovimientosCorrectos.Columns["Suc"].Visible = false;
                this.gvMovimientosCorrectos.Columns["Status"].Visible = false;

                this.gvMovimientosErrores.Columns["Columna10"].Visible = false;
                this.gvMovimientosErrores.Columns["Forma_Pago"].Visible = false;
                this.gvMovimientosErrores.Columns["Suc"].Visible = false;
                this.gvMovimientosErrores.Columns["Status"].Visible = false;

                for (int ln = 1; ln < gvMovimientosCorrectos.Columns.Count; ln++)
                {
                    gvMovimientosCorrectos.Columns[ln].ReadOnly = true;
                }

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
            poMovimientos.Columns["Columna2"].ColumnName = "Referencia1";
            poMovimientos.Columns["Columna8"].ColumnName = "Importe_Neto";
            poMovimientos.Columns["Columna11"].ColumnName = "Folio_pago";
            poMovimientos.Columns["Columna12"].ColumnName = "Suc_banco";
            poMovimientos.Columns["Columna15"].ColumnName = "Fecha_pago";
            return poMovimientos;
        }

        private static DataTable LeerArchivo(string loRutaArchivo, int lnRow)
        {
            try
            {
                int lnColumna = 1;
                string[] loLineas = System.IO.File.ReadAllLines(loRutaArchivo, System.Text.Encoding.Default);
                loLineas = loLineas.Select(sBusca => sBusca.Replace("<br/>", string.Empty)).ToArray();
                loLineas = loLineas.Select(sBusca => sBusca.Replace("</pre></font></div></body></html>", "|||||||||||||||")).ToArray();

                string[] loEncabezados = loLineas[lnRow].Split('|');
                DataTable loDatos = new DataTable();

                foreach (string loEncabezado in loLineas[lnRow].Split('|'))
                {
                    loDatos.Columns.Add("Columna" + lnColumna.ToString());
                    lnColumna++;
                }

                for (int lnFila = lnRow; lnFila < loLineas.Length; lnFila++)
                {
                    string[] rows = loLineas[lnFila].Split('|');
                    DataRow loFilas = loDatos.NewRow();
                    for (int i = 0; i < loEncabezados.Length; i++)
                    {
                        loFilas[i] = rows[i];
                    }
                    loDatos.Rows.Add(loFilas);
                }

                for (int i = loDatos.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow loFilasCargos = loDatos.Rows[i];
                    if (loFilasCargos["Columna15"].ToString() == string.Empty)
                    {
                        loFilasCargos.Delete();
                    }
                }

                loDatos.Columns.RemoveAt(13); 
                loDatos.Columns.RemoveAt(12);
                loDatos.Columns.RemoveAt(8);
                loDatos.Columns.RemoveAt(0);

                for (int lnIndiceAdelante = 5; lnIndiceAdelante >= 1; lnIndiceAdelante--)
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

        private DataTable obtenerFormaDePago(DataTable poMovimientos)
        {
            Movimientos loMovimientos = new Movimientos();
            for (int lnFila = 0; lnFila < poMovimientos.Rows.Count; lnFila++)
            {
                DataTable loResultado = loMovimientos.ObtenerFormaDePago(((InicioSesion)this.MdiParent.Owner).Sesion, poMovimientos.Rows[lnFila]["Columna10"].ToString().ToUpper()); // id de transaccion

                if (loResultado.Rows.Count > 0)
                {
                    poMovimientos.Rows[lnFila]["Tipo_pago"] = loResultado.Rows[0][1].ToString();
                    poMovimientos.Rows[lnFila]["Forma_Pago"] = loResultado.Rows[0][0].ToString();
                }
            }
            return poMovimientos;
        }

        public DataTable ValidaCobro(DataTable poMovimientos)
        {
            try
            {
                DataTable loResultado = poMovimientos.Clone();
                Movimientos loMovimientos = new Movimientos();

                for (int lnFila = 0; lnFila < poMovimientos.Rows.Count; lnFila++)
                {
                    DataTable loTablaFiltrada = (DataTable)loMovimientos.ValidaCobro(((InicioSesion)this.MdiParent.Owner).Sesion,
                        poMovimientos.Rows[lnFila]["Folio_pago"].ToString(), Convert.ToDateTime(poMovimientos.Rows[lnFila]["Fecha_pago"].ToString()));

                    if (loTablaFiltrada.Rows.Count > 0)
                    {
                        for (int i = 0; i < loTablaFiltrada.Rows.Count; i++)
                        {
                            DataRow loFilas = loResultado.NewRow();
                            foreach (DataRow loFila in poMovimientos.Rows)
                            {
                                for (int ln = 0; ln < poMovimientos.Columns.Count; ln++)
                                {
                                    if (loFila["Folio_pago"].ToString() == loTablaFiltrada.Rows[i]["NUM_TRANSACCION"].ToString())
                                    {
                                        loFila["Status"] = loTablaFiltrada.Rows[i]["STATUS_TRANS"].ToString();
                                        loFilas[ln] = loFila[ln];
                                    }
                                }
                            }
                            loResultado.Rows.Add(loFilas);
                            pbMovimientos.PerformStep();
                        }
                    }
                }

                if (loResultado.Rows.Count == 0)
                {
                    for (int i = 0; i < poMovimientos.Rows.Count; i++)
                    {
                        poMovimientos.Rows[i]["Status"] = 'C';
                    }

                    return poMovimientos;
                }

                for (int i = poMovimientos.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow loFila = poMovimientos.Rows[i];
                    poMovimientos.Rows[i]["Status"] = 'C';
                    for (int l = 0; l < loResultado.Rows.Count; l++)
                    {
                        DataRow loFilaCompara = loResultado.Rows[l];
                        if (loFila["Folio_pago"].ToString() == loFilaCompara["Folio_pago"].ToString())
                        {
                            loFila.Delete();
                            break;
                        }
                    }
                }

                loResultado.Columns.Add("Status_P", typeof(string));

                gvExistentes.DataSource = ObtenerSucursalRegistrosProcesados(loResultado);

                this.gvExistentes.Columns["Columna10"].Visible = false;
                this.gvExistentes.Columns["Suc"].Visible = false;
                this.gvExistentes.Columns["Forma_Pago"].Visible = false;
                this.gvExistentes.Columns["Status"].Visible = false;

                foreach (DataGridViewRow loFila in gvExistentes.Rows)
                {
                    loFila.Cells["Status_P"].Value = "Procesados";
                    if (loFila.Cells["Status"].Value.ToString() == "M")
                    {
                        loFila.Cells["Status_P"].Value = "Manual";
                    }
                }

                gvExistentes.Columns["#"].DisplayIndex = 0;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return poMovimientos;
        }

        private DataTable ObtenerSucursalRegistrosProcesados(DataTable poMovimientos)
        {
            Movimientos loSucursal = new Movimientos();
            DataTable loResultadoSinSucursal = poMovimientos.Clone();
            for (int lnFila = 0; lnFila < poMovimientos.Rows.Count; lnFila++)
            {
                DataTable loResultado = loSucursal.ObtenerSucursal(((InicioSesion)this.MdiParent.Owner).Sesion, poMovimientos.Rows[lnFila]["Referencia1"].ToString());


                if (loResultado.Rows.Count > 0)
                {
                    poMovimientos.Rows[lnFila]["Suc"] = loResultado.Rows[0][2].ToString();
                    poMovimientos.Rows[lnFila]["Cliente"] = loResultado.Rows[0][0].ToString();
                    poMovimientos.Rows[lnFila]["Sucursal"] = loResultado.Rows[0][3].ToString();
                }
            }

            int lnLugar = 1;
            foreach (DataRow loFila in poMovimientos.Rows)
            {
                loFila["#"] = lnLugar++;
            }

            return obtenerFormaDePago(poMovimientos);
        }

        private DataTable ObtenerSucursal(DataTable poMovimientos)
        {
            Movimientos loSucursal = new Movimientos();
            DataTable loResultadoSinSucursal = poMovimientos.Clone();
            for (int lnFila = 0; lnFila < poMovimientos.Rows.Count; lnFila++)
            {
                DataTable loResultado = loSucursal.ObtenerSucursal(((InicioSesion)this.MdiParent.Owner).Sesion, poMovimientos.Rows[lnFila]["Referencia1"].ToString());

                if (loResultado.Rows.Count > 0)
                {
                    poMovimientos.Rows[lnFila]["Suc"] = loResultado.Rows[0][2].ToString();
                    poMovimientos.Rows[lnFila]["Cliente"] = loResultado.Rows[0][0].ToString();
                    poMovimientos.Rows[lnFila]["Sucursal"] = loResultado.Rows[0][3].ToString();
                }
                else
                {
                    DataRow dr = loResultadoSinSucursal.NewRow();
                    for (int lnEncabezado = 0; lnEncabezado < poMovimientos.Columns.Count; lnEncabezado++)
                    {
                        dr[lnEncabezado] = poMovimientos.Rows[lnFila][lnEncabezado];
                    }
                    loResultadoSinSucursal.Rows.Add(dr);
                    loResultadoSinSucursal.Rows[loResultadoSinSucursal.Rows.Count - 1]["#"] = loResultadoSinSucursal.Rows.Count;
                }
                pbMovimientos.PerformStep();
            }

            DataTable loTablaExiste = (DataTable)gvExistentes.DataSource;

            if (loTablaExiste != null)
            {
                for (int i = loResultadoSinSucursal.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow loFila = loResultadoSinSucursal.Rows[i];
                    for (int l = 0; l < loTablaExiste.Rows.Count; l++)
                    {
                        DataRow loFilaCompara = loTablaExiste.Rows[l];
                        if (loFila["Folio_pago"].ToString() == loFilaCompara["Folio_pago"].ToString())
                        {
                            loFila.Delete();
                        }
                    }
                }
            }

            for (int i = 0; i < loResultadoSinSucursal.Rows.Count; i++)
            {
                loResultadoSinSucursal.Rows[i]["Status"] = 'M';
            }

            this.gvMovimientosErrores.DataSource = loResultadoSinSucursal;
            DataTable loMovimientosFiltrados = poMovimientos.Clone();
            DataRow[] loQueryFiltrar = poMovimientos.Select("Sucursal <> ''");
            if (loQueryFiltrar.Length > 0)
            {
                int lnLugar = 1;
                foreach (DataRow fila in loQueryFiltrar)
                    loMovimientosFiltrados.Rows.Add(fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6], fila[7], fila[8], lnLugar++, fila[10], fila[11], fila[12]);
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
            MovimientosBanorte loInforme = new MovimientosBanorte();
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
            MovimientosBanorte loInforme = new MovimientosBanorte();
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

        public void InsertaCobrosSIIL()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List<DataGridViewRow> loLista = new List<DataGridViewRow>();
                Movimientos loMovimientos = new Movimientos();
                DataTable loTablaCorrectos = (DataTable)gvMovimientosCorrectos.DataSource;

                decimal lnImporte = 0;
                foreach (DataGridViewRow loFila in gvMovimientosCorrectos.Rows)
                {
                    DataGridViewCheckBoxCell cbVerdadero = loFila.Cells[0] as DataGridViewCheckBoxCell;
                    if (Convert.ToBoolean(cbVerdadero.Value))
                    {
                        loLista.Add(loFila);
                        if (loMovimientos.InsertarCobroSIIL(
                            ((InicioSesion)this.MdiParent.Owner).Sesion, loFila.Cells["Fecha_pago"].Value.ToString(), Convert.ToDecimal(loFila.Cells["Importe_Neto"].Value.ToString().Replace("$", "").Replace(",",""))
                            , "BANORTE", int.Parse(loFila.Cells["Forma_pago"].Value.ToString()), loFila.Cells["Cliente"].Value.ToString(), int.Parse(loFila.Cells["Suc"].Value.ToString())))
                        { }
                    }
                    pbMovimientos.PerformStep();
                }

                if (loLista.Count == 0)
                {
                    MessageBox.Show("¡Debe seleccionar un cobro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (loLista.Count < 1)
                {
                    MessageBox.Show("¡Seleccione archivo a procesar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (DataRow loFila in loTablaCorrectos.Rows)
                {
                    loFila["Status"] = "N";
                }

                foreach (DataGridViewRow loFilaLista in loLista)
                {
                    loFilaLista.Cells["Status"].Value = "C";
                    lnImporte += Convert.ToDecimal(loFilaLista.Cells["Importe_Neto"].Value.ToString().Replace("$", "").Replace(",", ""));
                }

                if (gvMovimientosErrores.DataSource != null)
                {
                    DataTable loTablaErroresListaLlena = (DataTable)gvMovimientosErrores.DataSource;
                    foreach (DataRow loFila in loTablaErroresListaLlena.Rows)
                    {
                        loTablaCorrectos.ImportRow(loFila);
                    }
                }

                if (loMovimientos.InsertaCobroBanorteTablaDAP(
                            ((InicioSesion)this.MdiParent.Owner).Sesion, loTablaCorrectos, psArchivo, 16) // 16 - indica cuenta bancaria "Banorte Cheque en SIIL"
                            )
                { }

                if (gvExistentes.DataSource != null)
                {
                    DataTable loTablaExisten = (DataTable)gvExistentes.DataSource;
                    foreach (DataRow loFila in loTablaExisten.Rows)
                    {
                        loTablaCorrectos.ImportRow(loFila);
                    }
                }

                gvMovimientosCorrectos.DataSource = ObtenerSucursal(ValidaCobro(loTablaCorrectos));

                if (lblProcesados.Text == "0")
                {
                    int piProcesados = int.Parse(loLista.Count.ToString());
                    lblProcesados.Text = piProcesados.ToString();
                    lblImporteCargado.Text = lnImporte.ToString("C");
                    MessageBox.Show("Información procesada satisfactoriamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                decimal lnSubtotalImporteCargado = Convert.ToDecimal(lblImporteCargado.Text.Replace("$", ""));
                decimal lnTotalImporteCargado = lnImporte + lnSubtotalImporteCargado;
                lblImporteCargado.Text = lnTotalImporteCargado.ToString("C");

                int piSubTotalProcesados = int.Parse(lblProcesados.Text);
                int piTotal = piSubTotalProcesados + loLista.Count;
                lblProcesados.Text = piTotal.ToString();

                loLista.Clear();
                MessageBox.Show("Información procesada satisfactoriamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\nFuente: " + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void FormatoFilasManuales(DataGridViewRow loFila)
        {

            if (gvExistentes.Rows.Count < 1)
                return;

            if (loFila.Cells["Status"].Value.ToString() == "M")
                loFila.DefaultCellStyle.BackColor = Color.Gold;
        }

        #endregion

        #region Eventos

        private void btnAñadirCobro_Click(object sender, EventArgs e)
        {
            if (gvMovimientosCorrectos.Rows.Count > 0)
            {
                if (MessageBox.Show("¿ Desea procesar cobros ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    InsertaCobrosSIIL();
                    return;
                }
                return;
            }
            MessageBox.Show("¡Debe subir archivo!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void loCheckheader_OnCheckBoxHeaderClick(CheckBoxHeaderCellEventArgs e)
        {
            if (gvMovimientosCorrectos.Rows.Count > 0)
            {
                gvMovimientosCorrectos.BeginEdit(true);
                foreach (DataGridViewRow loFila in gvMovimientosCorrectos.Rows)
                {
                    loFila.Cells[0].Value = e.IsChecked;
                }
            }
            gvMovimientosCorrectos.EndEdit();
        } 

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            DialogResult lodialogo = ofdArchivo.ShowDialog();

            if (lodialogo == DialogResult.OK)
            {
                Procesar(ofdArchivo.FileName, 1, Path.Combine(Application.StartupPath, @"c:\dapesa\desarrollo\proyectos\codigofuente\dapesa\modulos\tesoreria\bancos\aplicacion\cobros\documentos\codigos_hsbc.csv"));
            }
        }

        private void btnImprimirMovimientoC_Click(object sender, EventArgs e)
        {
            Imprimir((DataTable)gvMovimientosCorrectos.DataSource, "MOVIMIENTOS BANORTE - CORRECTO");
        }

        private void btnExportarXlsxC_Click(object sender, EventArgs e)
        {
            Guardar((DataTable)gvMovimientosCorrectos.DataSource, "MOVIMIENTOS BANORTE - CORRECTO", (int)Comun.Definiciones.TipoArchivo.EXCEL);
        }

        private void btnGuardarMovimientoC_Click(object sender, EventArgs e)
        {
            Guardar((DataTable)gvMovimientosCorrectos.DataSource, "MOVIMIENTOS BANORTE - CORRECTO", (int)Comun.Definiciones.TipoArchivo.PDF);
        }

        private void btnImprimirMovimientoR_Click(object sender, EventArgs e)
        {
            Imprimir((DataTable)gvMovimientosErrores.DataSource, "MOVIMIENTOS BANORTE - REVISAR");
        }

        private void btnExportarXlsxR_Click(object sender, EventArgs e)
        {
            Guardar((DataTable)gvMovimientosErrores.DataSource, "MOVIMIENTOS BANORTE - REVISAR", (int)Comun.Definiciones.TipoArchivo.EXCEL);
        }

        private void btnGuardarMovimientoR_Click(object sender, EventArgs e)
        {
            Guardar((DataTable)gvMovimientosErrores.DataSource, "MOVIMIENTOS BANORTE - REVISAR", (int)Comun.Definiciones.TipoArchivo.PDF);
        }

        private void gvExistentes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow loFila = ((DataGridView)sender).Rows[e.RowIndex];
            FormatoFilasManuales(loFila);
        }
        #endregion

    }
}
