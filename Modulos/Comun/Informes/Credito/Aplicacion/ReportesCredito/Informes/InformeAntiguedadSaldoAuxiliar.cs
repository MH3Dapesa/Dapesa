using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Globalization;

namespace Dapesa.Comun.Informes.Credito.IU.ReportesCredito.Informes
{
    public partial class InformeAntiguedadSaldoAuxiliar : DevExpress.XtraReports.UI.XtraReport
    {
        public InformeAntiguedadSaldoAuxiliar()
        {
            InitializeComponent();
            #region Relación

            DateTime loFecha = DateTime.Now;
            DayOfWeek loDia = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(loFecha);
            if (loDia >= DayOfWeek.Monday && loDia <= DayOfWeek.Wednesday)
            {
                loFecha = loFecha.AddDays(3);
            }
            lblRelacion.Text = "RELACIÓN No. " +
                                (DateTime.Now.Year).ToString() +
                                "-" +
                                (CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(loFecha, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)).ToString();
            
            #endregion
        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblDiasVencido1.Text = 1 + " A " + (int.Parse(DiasVencido.Value.ToString())).ToString();
            lblDiasVencido2.Text = (1 + int.Parse(DiasVencido.Value.ToString())).ToString() + " A " + (2 * int.Parse(DiasVencido.Value.ToString())).ToString();
            lblDiasVencido3.Text = (1 + (2 * int.Parse(DiasVencido.Value.ToString()))).ToString() + " A " + (3 * int.Parse(DiasVencido.Value.ToString())).ToString();
            lblDiasVencido4.Text = ("MÁS DE " + (3 * int.Parse(DiasVencido.Value.ToString()))).ToString() + " DÍAS";
            lblDiasVencido5.Text = ("DE 1 A  MAS DE " + (3 * int.Parse(DiasVencido.Value.ToString()))).ToString() + " DÍAS";
        }

        private void xrTableCell49_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            ColorTexto(sender);
        }

        private void xrTableCell50_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            ColorTexto(sender);
        }

        private void ColorTexto(object sender)
        {
            var loCell = sender as XRTableCell;
            if (!string.IsNullOrEmpty(loCell.Text))
                if (!string.IsNullOrEmpty(loCell.Text.Substring(0, 5)))
                    if (double.Parse(loCell.Text.Substring(0, 5)) < 0D)
                        loCell.ForeColor = Color.Red;
        }

    }
}
