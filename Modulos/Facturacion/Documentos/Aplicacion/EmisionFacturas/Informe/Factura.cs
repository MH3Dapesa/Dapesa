using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Dapesa.Facturacion.Documentos.Reglas;

namespace Dapesa.Facturacion.Documentos.IU.EmisionFacturas.Informe
{
    public partial class Factura : DevExpress.XtraReports.UI.XtraReport
    {
        public Factura()
        {
            InitializeComponent();

        }

        private void xrTableCell26_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Numalet let = null;
            let = new Numalet();
            //al uso en México (creo):
            let.MascaraSalidaDecimal = "00/100 M.N.";
            let.SeparadorDecimalSalida = "pesos";
            //observar que sin esta propiedad queda "veintiuno pesos" en vez de "veintiún pesos":
            let.ApocoparUnoParteEntera = true;
            //MessageBox.Show("Son: " + let.ToCustomCardinal(1121.24));
            xrTableCell26.Text = let.ToCustomCardinal(decimal.Parse(xrTableCell26.Text));
            //Son: un mil ciento veintiún pesos 24/100 M.N.
        }

        private void xrLabel83_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            Numalet let = null;
            let = new Numalet();
            //al uso en México (creo):
            let.MascaraSalidaDecimal = "00/100 M.N.";
            let.SeparadorDecimalSalida = "pesos";
            //observar que sin esta propiedad queda "veintiuno pesos" en vez de "veintiún pesos":
            let.ApocoparUnoParteEntera = true;
            //MessageBox.Show("Son: " + let.ToCustomCardinal(1121.24));
            xrLabel83.Text = let.ToCustomCardinal(decimal.Parse(xrLabel83.Text));
            //Son: un mil ciento veintiún pesos 24/100 M.N.
        }


        private void tblSucursal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (xrLabel4.Text == "1")
            {
                tblSucursal.Visible = false;
            }
        }

    }
}