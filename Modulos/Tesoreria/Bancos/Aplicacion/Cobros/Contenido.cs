using Dapesa.Seguridad.Entidades;
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
    public partial class Contenido : Form
    {
        public Contenido()
        {
            InitializeComponent();
            #region Inicializar Componentes
            sfdGuardar.RestoreDirectory = ofdArchivo.RestoreDirectory = true;
            ofdArchivo.Filter = "Text files (*.txt)|*.txt";
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
        #endregion

        #region Métodos

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
                DataTable poMovimientos = LeerArchivo(loRutaArchivoMovimientos, 6);
                lblEstatus.Text = "Registros Procesados: " + poMovimientos.Rows.Count.ToString(); 
                DataTable loMovimientosFiltrados = poMovimientos.Clone();
                DataRow[] loQueryFiltrar = poMovimientos.Select("Columna3 = 'A' ");

                foreach (DataRow fila in loQueryFiltrar)
                    loMovimientosFiltrados.Rows.Add(fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6], fila[7].ToString().Replace(",", string.Empty), fila[8], fila[9]);
                poMovimientos.Rows.Clear();
                poMovimientos.Merge(loMovimientosFiltrados);
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

                poMovimientos.Columns.Add("Ref_Alfanumerica2", typeof(string));
                poMovimientos.Columns.Add("Suc_Clave", typeof(string));
                poMovimientos.Columns.Add("Cliente", typeof(string));
                poMovimientos.Columns.Add("#", typeof(int));
                poMovimientos.Columns.Add("Modificado", typeof(string));
                poMovimientos.Columns.Add("Forma_Pago", typeof(string));
                poMovimientos.Columns.Add("Sucursal", typeof(string));
                poMovimientos.Columns.Add("Status", typeof(string)); 

                poMovimientos = obtenerFormaDePago(poMovimientos); 
                poMovimientos = ObtenerMovimientosAMostrar(poMovimientos);

                pbMovimientos.Minimum = 1;
                pbMovimientos.Maximum = poMovimientos.Rows.Count;
                pbMovimientos.Value = 1;
                pbMovimientos.Step = 1;

                poMovimientos = GenerarVista(poMovimientos);
                this.gvMovimientosCorrectos.DataSource = ObtenerSucursal(ValidaCobro(poMovimientos));

                gvMovimientosCorrectos.Columns["#"].DisplayIndex = 1;
                gvMovimientosErrores.Columns["#"].DisplayIndex = 1;

                this.gvMovimientosCorrectos.Columns["Columna4"].Visible = false;
                this.gvMovimientosCorrectos.Columns["Columna5"].Visible = false;
                this.gvMovimientosCorrectos.Columns["Ref_Alfanumerica2"].Visible = false;
                this.gvMovimientosCorrectos.Columns["Forma_Pago"].Visible = false;
                this.gvMovimientosCorrectos.Columns["Modificado"].Visible = false;
                this.gvMovimientosCorrectos.Columns["Suc_Clave"].Visible = false;
                this.gvMovimientosCorrectos.Columns["Status"].Visible = false;

                this.gvMovimientosErrores.Columns["Columna4"].Visible = false;
                this.gvMovimientosErrores.Columns["Columna5"].Visible = false;
                this.gvMovimientosErrores.Columns["Ref_Alfanumerica2"].Visible = false;
                this.gvMovimientosErrores.Columns["Forma_Pago"].Visible = false;
                this.gvMovimientosErrores.Columns["Modificado"].Visible = false;
                this.gvMovimientosErrores.Columns["Suc_Clave"].Visible = false;
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

        public DataTable ValidaCobro(DataTable poMovimientos)
        {
            try
            {
                DataTable loResultado = poMovimientos.Clone();
                Movimientos loMovimientos = new Movimientos();

                for (int lnFila = 0; lnFila < poMovimientos.Rows.Count; lnFila++)
                {
                    DataTable loTablaFiltrada = (DataTable)loMovimientos.ValidaCobro(((InicioSesion)this.MdiParent.Owner).Sesion,
                        poMovimientos.Rows[lnFila]["Autorizacion"].ToString(), Convert.ToDateTime(poMovimientos.Rows[lnFila]["Fecha"].ToString()));

                    if (loTablaFiltrada.Rows.Count > 0)
                    {
                        for (int i = 0; i < loTablaFiltrada.Rows.Count; i++)
                        {
                            DataRow loFilas = loResultado.NewRow();                            
                            foreach (DataRow loFila in poMovimientos.Rows)
                            {
                                for (int ln = 0; ln < poMovimientos.Columns.Count; ln++)
                                {
                                    if (loFila["Autorizacion"].ToString() == loTablaFiltrada.Rows[i]["NUM_TRANSACCION"].ToString())
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
                        if (loFila["Autorizacion"].ToString() == loFilaCompara["Autorizacion"].ToString())
                        {
                            loFila.Delete();
                            break;
                        }
                    }                    
                }

                loResultado.Columns.Add("Status_P", typeof(string));

                gvExistentes.DataSource = ObtenerSucursalRegistrosProcesados(loResultado);

                this.gvExistentes.Columns["Columna4"].Visible = false;
                this.gvExistentes.Columns["Columna5"].Visible = false;
                this.gvExistentes.Columns["Ref_Alfanumerica2"].Visible = false;
                this.gvExistentes.Columns["Suc_Clave"].Visible = false;
                this.gvExistentes.Columns["Forma_Pago"].Visible = false;
                this.gvExistentes.Columns["Modificado"].Visible = false;
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
                            ((InicioSesion)this.MdiParent.Owner).Sesion, loFila.Cells["Fecha"].Value.ToString(), Convert.ToDecimal(loFila.Cells["Depositos"].Value.ToString().Replace(",", ""))
                            , "BANAMEX", int.Parse(loFila.Cells["Forma_pago"].Value.ToString()), loFila.Cells["Cliente"].Value.ToString(), int.Parse(loFila.Cells["Suc_clave"].Value.ToString())))
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
                    lnImporte += Convert.ToDecimal(loFilaLista.Cells["Depositos"].Value.ToString().Replace(",", ""));
                }

                if (gvMovimientosErrores.DataSource != null)
                {
                    DataTable loTablaErroresListaLlena = (DataTable)gvMovimientosErrores.DataSource;
                    foreach (DataRow loFila in loTablaErroresListaLlena.Rows)
                    {
                        loTablaCorrectos.ImportRow(loFila);
                    }
                }

                if (loMovimientos.InsertaCobroTablaDAP(
                            ((InicioSesion)this.MdiParent.Owner).Sesion, loTablaCorrectos, psArchivo, 1) // 1 - indica cuenta bancaria "Banamex Concentradora"
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

                decimal lnSubtotalImporteCargado = Convert.ToDecimal(lblImporteCargado.Text.Replace("$",""));
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

        private DataTable GenerarVista(DataTable poMovimientos)
        {
            poMovimientos.Columns["Columna1"].ColumnName = "Num";
            poMovimientos.Columns["Columna2"].ColumnName = "Fecha";
            poMovimientos.Columns["Columna3"].ColumnName = "Descripcion";
            poMovimientos.Columns["Columna6"].ColumnName = "Suc";
            poMovimientos.Columns["Columna7"].ColumnName = "Ref_Numerica";
            poMovimientos.Columns["Columna8"].ColumnName = "Ref_Alfanumerica";
            poMovimientos.Columns["Columna9"].ColumnName = "Depositos";
            poMovimientos.Columns["Columna10"].ColumnName = "Autorizacion";
            return poMovimientos;
        }

        private DataTable obtenerFormaDePago(DataTable poMovimientos) 
        {
            Movimientos loMovimientos = new Movimientos();
            for (int lnFila = 0; lnFila < poMovimientos.Rows.Count; lnFila++)
            {
                DataTable loResultado = loMovimientos.ObtenerFormaDePagoBanamex(((InicioSesion)this.MdiParent.Owner).Sesion, poMovimientos.Rows[lnFila][3].ToString() + poMovimientos.Rows[lnFila][4].ToString());

                if (loResultado.Rows.Count > 0)
                {
                    poMovimientos.Rows[lnFila][2] = loResultado.Rows[0][1].ToString();                    
                }
                poMovimientos.Rows[lnFila]["Forma_Pago"] = loResultado.Rows[0][0].ToString();
            }
            return poMovimientos;
        }

        private DataTable ObtenerSucursalRegistrosProcesados(DataTable poMovimientos)
        {
            Movimientos loSucursal = new Movimientos();
            DataTable loResultadoSinSucursal = poMovimientos.Clone();
            for (int lnFila = 0; lnFila < poMovimientos.Rows.Count; lnFila++)
            {
                DataTable loResultado = loSucursal.ObtenerSucursalBanamex(((InicioSesion)this.MdiParent.Owner).Sesion, poMovimientos.Rows[lnFila]["Ref_Numerica"].ToString());
                

                if (loResultado.Rows.Count > 0)
                {
                    poMovimientos.Rows[lnFila]["Cliente"] = loResultado.Rows[0][0].ToString();
                    poMovimientos.Rows[lnFila]["Suc_Clave"] = loResultado.Rows[0][2].ToString();
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
                DataTable loResultado = loSucursal.ObtenerSucursalBanamex(((InicioSesion)this.MdiParent.Owner).Sesion, poMovimientos.Rows[lnFila]["Ref_Numerica"].ToString());

                if (loResultado.Rows.Count > 0)
                {
                    poMovimientos.Rows[lnFila]["Cliente"] = loResultado.Rows[0][0].ToString();
                    poMovimientos.Rows[lnFila]["Suc_Clave"] = loResultado.Rows[0][2].ToString();
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

            for (int i = 0; i < loResultadoSinSucursal.Rows.Count; i++)
            {
                loResultadoSinSucursal.Rows[i]["Status"] = 'M';
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
                        if (loFila["Autorizacion"].ToString() == loFilaCompara["Autorizacion"].ToString())
                        {
                            loFila.Delete();
                            break;
                        }
                    }
                }
            }            

            this.gvMovimientosErrores.DataSource = loResultadoSinSucursal;
            DataTable loMovimientosFiltrados = poMovimientos.Clone();
            DataRow[] loQueryFiltrar = poMovimientos.Select("Sucursal <> ''");
            if (loQueryFiltrar.Length > 0)
            {
                int lnLugar = 1;
                foreach (DataRow fila in loQueryFiltrar)
                    loMovimientosFiltrados.Rows.Add(fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6], fila[7], fila[8], fila[9], fila[10], fila[11], fila[12], lnLugar++, fila[14], fila[15], fila[16], fila[17]);
            }

            return obtenerFormaDePago(loMovimientosFiltrados);
        }

        private void Imprimir(DataTable loMovimientos, string lsTituloReporte)
        {
            MovimientosCobros loInforme = new MovimientosCobros();
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
            MovimientosCobros loInforme = new MovimientosCobros();
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

        private void CargarImpresoras()
        {
            foreach (string loImpresora in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cbImpresora.Items.Add(loImpresora);
            }
        }

        private DataTable ObtenerMovimientosAMostrar(DataTable poMovimientos)
        {
            for (int lnFila = 0; lnFila < poMovimientos.Rows.Count; lnFila++)
            {
                poMovimientos.Rows[lnFila]["Modificado"] = 'N';

                #region Filtrar Deposito Mayor
                DataTable loMovimientosFiltrados = poMovimientos.Clone();
                DataRow[] loQueryFiltrar = poMovimientos.Select("Columna10 = '" + poMovimientos.Rows[lnFila][9].ToString() + "' AND Columna1 <> '" + poMovimientos.Rows[lnFila][0].ToString() + "'", "Columna8 desc,Columna5 asc");
                #endregion

                if (loQueryFiltrar.Length > 0)
                {
                    foreach (DataRow fila in loQueryFiltrar)
                        loMovimientosFiltrados.Rows.Add(fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6], fila[7], fila[8], fila[9], fila[10], fila[11], fila[12], fila[13], fila[14], fila[15]);

                    for (int lnFilaMovimientosFiltrados = 0; lnFilaMovimientosFiltrados < loMovimientosFiltrados.Rows.Count; lnFilaMovimientosFiltrados++)
                    {

                        if (lnFilaMovimientosFiltrados == 0)
                        {
                            poMovimientos.Rows[lnFila][1] = loMovimientosFiltrados.Rows[0][1];
                            poMovimientos.Rows[lnFila][2] = loMovimientosFiltrados.Rows[0][2];
                            poMovimientos.Rows[lnFila][5] = loMovimientosFiltrados.Rows[0][5];
                            poMovimientos.Rows[lnFila][6] = loMovimientosFiltrados.Rows[0][6];
                            poMovimientos.Rows[lnFila][10] = loMovimientosFiltrados.Rows[0][7];
                            poMovimientos.Rows[lnFila][15] = loMovimientosFiltrados.Rows[0][15];
                            poMovimientos.Rows[lnFila]["Modificado"] = 'S';
                        }

                        for (int lnFilaEliminar = 0; lnFilaEliminar < poMovimientos.Rows.Count; lnFilaEliminar++)
                        {
                            if (poMovimientos.Rows[lnFilaEliminar][0] == loMovimientosFiltrados.Rows[lnFilaMovimientosFiltrados][0])
                            {
                                poMovimientos.Rows[lnFilaEliminar].Delete();
                                break;
                            }
                        }
                    }
                }
            }
            return poMovimientos;
        }

        private void FormatoFilas(DataGridViewRow loFila)
        {
            if (loFila.Cells["Modificado"].Value == null)
                return;

            if (loFila.Cells["Modificado"].Value.ToString() == "S")
                loFila.DefaultCellStyle.BackColor = Color.LightYellow;
        }

        private void FormatoFilasManuales(DataGridViewRow loFila)
        {

            if (gvExistentes.Rows.Count < 1)
                return;

            if (loFila.Cells["Status"].Value.ToString() == "M")
                loFila.DefaultCellStyle.BackColor = Color.Gold;
        }

        private DataTable LeerArchivo(string loRutaArchivo, int lnRow)
        {
            try
            {                
                int lnColumna = 1;
                string[] loLines = System.IO.File.ReadAllLines(loRutaArchivo, System.Text.Encoding.Default);

                string[] loEncabezados = loLines[lnRow].Split('|');
                DataTable loDatos = new DataTable();

                foreach (string loEncabezado in loLines[lnRow].Split('|'))
                {
                    loDatos.Columns.Add("Columna" + lnColumna.ToString());
                    lnColumna++;
                }
                for (int lnFila = lnRow; lnFila < loLines.Length; lnFila++)
                {
                    string[] rows = loLines[lnFila].Split('|');
                    DataRow loFilas = loDatos.NewRow();
                    for (int i = 0; i < loEncabezados.Length; i++)
                    {
                        loFilas[i] = rows[i];
                    }
                    loDatos.Rows.Add(loFilas);
                }
                return loDatos;
            }
            catch (Exception ex)
            {
                throw new Comun.Excepcion(ex.Message, ex);
            }
        }        

        #endregion

        #region Eventos

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

        private void Contenido_Load(object sender, EventArgs e)
        {
            CargarImpresoras();            
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            DialogResult loDialogo = ofdArchivo.ShowDialog();

            if (loDialogo == DialogResult.OK)
            {
                Procesar(ofdArchivo.FileName, 6, Path.Combine(Application.StartupPath, @"Documentos\Codigos_Banamex.csv"));
            }            
        }

        private void btnImprimirMovimientoC_Click(object sender, EventArgs e)
        {
            Imprimir((DataTable)gvMovimientosCorrectos.DataSource, "MOVIMIENTOS BANAMEX - CORRECTO");
        }

        private void btnGuardarMovimientoC_Click(object sender, EventArgs e)
        {
            Guardar((DataTable)gvMovimientosCorrectos.DataSource, "MOVIMIENTOS BANAMEX - CORRECTO", (int)Comun.Definiciones.TipoArchivo.PDF);
        }

        private void btnImprimirMovimientoR_Click(object sender, EventArgs e)
        {
            Imprimir((DataTable)gvMovimientosErrores.DataSource, "MOVIMIENTOS BANAMEX - REVISAR");
        }

        private void btnGuardarMovimientoR_Click(object sender, EventArgs e)
        {
            Guardar((DataTable)gvMovimientosErrores.DataSource, "MOVIMIENTOS BANAMEX - REVISAR", (int)Comun.Definiciones.TipoArchivo.PDF);
        }

        private void gvMovimientosCorrectos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow loFila = ((DataGridView)sender).Rows[e.RowIndex];
            FormatoFilas(loFila);
        }

        private void gvMovimientosErrores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow loFila = ((DataGridView)sender).Rows[e.RowIndex];
            FormatoFilas(loFila);
        }

        private void gvExistentes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow loFila = ((DataGridView)sender).Rows[e.RowIndex];
            FormatoFilasManuales(loFila);
        }

        private void btnExportarXlsxC_Click(object sender, EventArgs e)
        {
            Guardar((DataTable)gvMovimientosCorrectos.DataSource, "MOVIMIENTOS BANAMEX - CORRECTO", (int)Comun.Definiciones.TipoArchivo.EXCEL);
        }

        private void btnExportarXlsxR_Click(object sender, EventArgs e)
        {
            Guardar((DataTable)gvMovimientosCorrectos.DataSource, "MOVIMIENTOS BANAMEX - REVISAR", (int)Comun.Definiciones.TipoArchivo.EXCEL);
        }
        #endregion   

    }
}
