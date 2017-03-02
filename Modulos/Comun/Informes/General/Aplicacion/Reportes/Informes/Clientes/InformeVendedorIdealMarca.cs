using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Dapesa.Comun.Informes.General.IU.Reportes.Informes.Clientes
{
    public partial class InformeVendedorIdealMarca : DevExpress.XtraReports.UI.XtraReport
    {
        public InformeVendedorIdealMarca()
        {
            InitializeComponent();
        }

        private void cellMarca_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (float.Parse(cellTotalPzas.Text) == 0)
            {
                cellMarca.BackColor = System.Drawing.ColorTranslator.FromHtml("#d33739");
                cellMarca.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                cellMarca.BackColor = System.Drawing.Color.Transparent;
                cellMarca.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void cellMontoVendedor_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (float.Parse(cellMontoVendedor.Text) > float.Parse(cellMontoTlmk.Text))
            {
                cellMontoVendedor.BackColor = System.Drawing.ColorTranslator.FromHtml("#92cddc");
            }
            else
            {
                cellMontoVendedor.BackColor = System.Drawing.Color.Transparent;
                cellMontoVendedor.ForeColor = System.Drawing.Color.Black;
            }

        }

        private void cellMontoTlmk_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (float.Parse(cellMontoVendedor.Text) < float.Parse(cellMontoTlmk.Text))
            {
                cellMontoTlmk.BackColor = System.Drawing.ColorTranslator.FromHtml("#92cddc");
            }
            else
            {
                cellMontoTlmk.BackColor = System.Drawing.Color.Transparent;
                cellMontoTlmk.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void cellTotalPzas_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (float.Parse(cellTotalPzas.Text) == 0)
            {
                cellTotalPzas.BackColor = System.Drawing.ColorTranslator.FromHtml("#d33739");
                cellTotalPzas.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                cellTotalPzas.BackColor = System.Drawing.Color.Transparent;
                cellTotalPzas.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void cellMontoIdeal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if ((float.Parse(cellMontoIdeal.Text) == float.Parse(cellTotalMonto.Text)) && float.Parse(cellMontoIdeal.Text) > 0)
            {
                cellMontoIdeal.BackColor = System.Drawing.ColorTranslator.FromHtml("#00b0f0");
                cellMontoIdeal.Font = new Font("Calibri", 6, FontStyle.Regular);
            }
            else
            {
                cellMontoIdeal.BackColor = System.Drawing.Color.Transparent;
                cellMontoIdeal.Font = new Font("Calibri", 6, FontStyle.Regular);

            }
        }
        private void cellPorcentajeMontoIdeal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (cellPorcentajeMontoIdeal.Text.ToString() == string.Empty)
            {
                cellPorcentajeMontoIdeal.Text = "00.00%";
            }
            if (decimal.Parse(cellPorcentajeMontoIdeal.Text.ToString().Replace("%", "")) <= decimal.Parse(PorcentajeIdealVenta.Value.ToString()) * 100)
            {
                cellPorcentajeMontoIdeal.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffc7ce");
                cellPorcentajeMontoIdeal.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9c0006");
            }
            else
            {
                cellPorcentajeMontoIdeal.BackColor = System.Drawing.Color.Transparent;
                cellPorcentajeMontoIdeal.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void cellPorcentajePzasIdeal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (cellPorcentajePzasIdeal.Text.ToString() == string.Empty)
            {
                cellPorcentajePzasIdeal.Text = "00.00%";
            }
            if (decimal.Parse(cellPorcentajePzasIdeal.Text.ToString().Replace("%", "")) <= decimal.Parse(PorcentajeIdealVenta.Value.ToString()) * 100)
            {
                cellPorcentajePzasIdeal.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffc7ce");
                cellPorcentajePzasIdeal.ForeColor = System.Drawing.ColorTranslator.FromHtml("#9c0006");
            }
            else
            {
                cellPorcentajePzasIdeal.BackColor = System.Drawing.Color.Transparent;
                cellPorcentajePzasIdeal.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void cellMarcasPorVender_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (cellMarcasPorVender.Text.ToString() == string.Empty)
            {
                cellMarcasPorVender.Text = "0";
            }
            if (decimal.Parse(cellMarcasPorVender.Text.ToString()) < 0)
            {
                cellMarcasPorVender.BackColor = System.Drawing.ColorTranslator.FromHtml("#d33739");
            }
            else
            {
                cellMarcasPorVender.BackColor = System.Drawing.Color.Transparent;
            }
        }

        private void InformeVendedorIdealMarca_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            GroupHeader2.Visible = bool.Parse(MostrarEncabezado.Value.ToString());
        }

        private void xrTable3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!bool.Parse(MostrarEncabezado.Value.ToString()))
            {
                xrTable3.BorderColor = System.Drawing.Color.LightGray;
                cellMontoIdeal.BorderColor = System.Drawing.Color.LightGray;
                cellIdealPzas.BorderColor = System.Drawing.Color.LightGray;
            }
        }

    }
}
