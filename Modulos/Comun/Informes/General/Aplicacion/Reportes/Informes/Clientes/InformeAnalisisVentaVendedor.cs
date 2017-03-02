using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Dapesa.Comun.Informes.General.IU.Reportes.Informes.Clientes
{
    public partial class InformeAnalisisVentaVendedor : DevExpress.XtraReports.UI.XtraReport
    {
        public InformeAnalisisVentaVendedor()
        {
            InitializeComponent();
        }

        private void InformeAnalisisVentaVendedor_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           PageWidth = 850 + (210 * (Math.Abs((Convert.ToDateTime(FechaInicio.Value).Month - Convert.ToDateTime(FechaFin.Value).Month) + 12 * (Convert.ToDateTime(FechaInicio.Value).Year - Convert.ToDateTime(FechaFin.Value).Year))));
           // PageWidth = 2300; PageKind = CUSTOM        
        }


    }
}
