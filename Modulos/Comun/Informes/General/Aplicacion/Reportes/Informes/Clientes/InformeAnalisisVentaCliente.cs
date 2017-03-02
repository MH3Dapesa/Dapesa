using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Dapesa.Comun.Informes.General.IU.Reportes.Informes.Clientes
{
    public partial class InformeAnalisisVentaCliente : DevExpress.XtraReports.UI.XtraReport
    {

        public InformeAnalisisVentaCliente()
        {
            InitializeComponent();
        }

        private void InformeAnalisisVentaCliente_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
         
            PageWidth = 850 + (215 *( 1 + ((Math.Abs((Convert.ToDateTime(FechaInicial.Value).Month - Convert.ToDateTime(FechaFinal.Value).Month) + 12 * (Convert.ToDateTime(FechaInicial.Value).Year - Convert.ToDateTime(FechaFinal.Value).Year))))));
        }
         

    }
}
