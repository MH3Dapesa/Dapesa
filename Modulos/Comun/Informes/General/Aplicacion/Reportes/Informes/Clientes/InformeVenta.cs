using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;
using System.Web;

namespace Dapesa.Comun.Informes.General.IU.Reportes.Informes.Clientes
{
    public partial class InformeVenta : DevExpress.XtraReports.UI.XtraReport
    {
        public InformeVenta()
        {
            InitializeComponent(); 
        }
        private void xrtbcCveVendedor_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //xrtbcCveVendedor.NavigateUrl = "EnlaceAnalisisVenta.aspx?0407e8c8285ab85509ac2884025dcf42=" + xrtbcCveVendedor.Text;
        }
    }
}
