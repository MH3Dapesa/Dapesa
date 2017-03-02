using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Dapesa.Facturacion.Documentos.Reglas;
using System.Windows.Forms;
using Dapesa.Facturacion.Documentos.IU.EmisionFacturas.Informe;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;
using System.Drawing.Printing;


namespace Dapesa.Facturacion.Documentos.IU.EmisionFacturas
{
    public partial class Contenido : Form
    {
        public Contenido()
        {
            InitializeComponent();
        }

        private void dtpFechaInicial_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            BuscarFacturas();
            this.cbFacturas.Enabled = true;

        }

        #region Metodos
        private void BuscarFacturas()
        {
            Facturas loResultado = new Facturas();
            clbFacturas.DataSource = loResultado.ObtenerFoliosFacturas(((InicioSesion)this.MdiParent.Owner).Sesion, txtFactura.Text, txtFecha.Text);
            clbFacturas.DisplayMember = "FOLIO";
            cbFacturas.Checked = true;
        }

        private void BuscarImpresoras()
        {
            foreach (string strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                //cmbPrinters.Items.Add(printerName)
                cbImpresora.Items.Add(strPrinter);
            }
        }

        private void SeleccionarFacturas(CheckedListBox poCheckedList, bool pbIndicador)
        {
            for (int lnIndice = 0; lnIndice < poCheckedList.Items.Count; lnIndice++)
                poCheckedList.SetItemChecked(lnIndice, pbIndicador);
        }

        #endregion

        private void cbFacturas_CheckedChanged(object sender, EventArgs e)
        {
            this.SeleccionarFacturas(clbFacturas, ((CheckBox)sender).Checked);
        }

        private void tlpContenido_Paint(object sender, PaintEventArgs e)
        {

        }
        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back))
                return;

            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back))
                return;

            if (!char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void lblFechaInicial_Click(object sender, EventArgs e)
        {

        }

        private void txtFactura_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void Imprimir()
        {
            Facturas loResultado = new Facturas();
            foreach (DataRowView loItem in clbFacturas.CheckedItems.OfType<DataRowView>().ToList())
            {
                Factura loFactura = new Factura();
                DataTable loObtenerFacturas = loResultado.ObtenerFacturas(((InicioSesion)this.MdiParent.Owner).Sesion, loItem["FOLIO_FAC"].ToString());
                DataTable loSucursal = loResultado.ObtenerSucursal(((InicioSesion)this.MdiParent.Owner).Sesion);

                DataSet loFuenteDatos = new DataSet();
                loFuenteDatos.DataSetName = "DataSourceFactura";
                loFuenteDatos.Tables.Add(loObtenerFacturas);
                loFuenteDatos.Tables[0].TableName = "Facturas";
                loFuenteDatos.Tables.Add(loSucursal);
                loFuenteDatos.Tables[1].TableName = "Sucursal";
                loFuenteDatos.AcceptChanges();

                loFactura.DataMember = "DataSourceFactura";
                loFactura.DataSource = loFuenteDatos;
                loFactura.FillDataSource();

                using (ReportPrintTool printTool = new ReportPrintTool(loFactura))
                {
                    // Invoke the Print dialog.
                    // printTool.PrintDialog();

                    //// Send the report to the default printer.
                    //printTool.Print();
                    // IF thisform.combo1.Value = "" OR thisform.combo2.Value = ""

                    if (cbImpresora.SelectedIndex.Equals(-1))
                        MessageBox.Show("Seleccione una impresora", "¡Atención!");
                    else
                    {
                        // Send the report to the specified printer.
                        // printTool.Print("TI-SR");
                        printTool.Print(cbImpresora.SelectedItem.ToString());
                        //   printTool.ClosePreview();
                    }
                }
                return;
            }

        }

        private void Contenido_Load(object sender, EventArgs e)
        {
            BuscarImpresoras();
        }

        private void clbFacturas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Unchecked)
            {
                if (clbFacturas.CheckedItems.Count == 1)
                {
                    btnImprimir.Enabled = false;
                }
            }
            else
            {
                btnImprimir.Enabled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
