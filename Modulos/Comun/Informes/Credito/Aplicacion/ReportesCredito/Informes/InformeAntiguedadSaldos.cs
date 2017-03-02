using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Dapesa.Comun.Informes.Credito.IU.ReportesCredito.Informes
{
    public partial class InformeAntiguedadSaldos : DevExpress.XtraReports.UI.XtraReport
    {
        public InformeAntiguedadSaldos()
        {
            InitializeComponent();
        }

        private void GroupHeader2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblDiasVencido1.Text = 1 + " - " + (int.Parse(DiasVencido.Value.ToString())).ToString();
            lblDiasVencido2.Text = (1 + int.Parse(DiasVencido.Value.ToString())).ToString() + " - " + (2 * int.Parse(DiasVencido.Value.ToString())).ToString();
            lblDiasVencido3.Text = (1 + (2 * int.Parse(DiasVencido.Value.ToString()))).ToString() + " - " + (3 * int.Parse(DiasVencido.Value.ToString())).ToString();
            lblDiasVencido4.Text = (1 + (3 * int.Parse(DiasVencido.Value.ToString()))).ToString() + " - " + (4 * int.Parse(DiasVencido.Value.ToString())).ToString();
            lblDiasVencido5.Text = (1 + (4 * int.Parse(DiasVencido.Value.ToString()))).ToString() + " - " + (5 * int.Parse(DiasVencido.Value.ToString())).ToString();
            lblDiasVencido6.Text = (1 + (5 * int.Parse(DiasVencido.Value.ToString()))).ToString() + " - " + (6 * int.Parse(DiasVencido.Value.ToString())).ToString();
            lblDiasVencido7.Text = (1 + (6 * int.Parse(DiasVencido.Value.ToString()))).ToString() + " - " + "O MAS";
        }

        private void xrtcSaldoVigenteGrupo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrtcSaldoVencidoGrupo1_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            ColorTexto(sender);
        }

        private void xrtcSaldoVencidoGrupo2_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            ColorTexto(sender);
        }

        private void xrtcSaldoVencidoGrupo3_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            ColorTexto(sender);
        }

        private void xrtcSaldoVencidoGrupo4_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            ColorTexto(sender);
        }

        private void xrtcSaldoVencidoGrupo5_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            ColorTexto(sender);
        }

        private void xrtcSaldoVencidoGrupo6_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            ColorTexto(sender);
        }

        private void xrtcSaldoVencidoGrupo7_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            ColorTexto(sender);
        }

        private void xrtcSaldoGrupo_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            ColorTexto(sender);
        }

        private void xrtcSaldoVigenteGrupo_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            ColorTexto(sender);
        }

        private void ColorTexto(object sender)
        {
            var currentCell = sender as XRTableCell;
            if (!string.IsNullOrEmpty(currentCell.Text))
                if (double.Parse(currentCell.Text) < 0D)
                {
                    currentCell.ForeColor = Color.Red;
                    currentCell.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
                }
        }

    }
}
