using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Drawing.Printing;
using System.Globalization;

namespace Dapesa.Comun.Informes.General.IU.Reportes.Informes.Clientes
{
    public partial class InformeVentasPorPoblacion : DevExpress.XtraReports.UI.XtraReport
    {
        private string loBinding = "";
        public InformeVentasPorPoblacion()
        {
            InitializeComponent();
        }

        private void InformeVentasPorPoblacion_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.GroupHeader1.Controls.Add(EncabezadoMesesXRTable());
            this.GroupHeader1.Controls.Add(EncabezadoPzasImporteXRTable());
            this.Detail.Controls.Add(DetalleVentaXRTable());
            PageWidth = 670 + (120 * (1 + Math.Abs((Convert.ToDateTime(FechaInicial.Value).Month - Convert.ToDateTime(FechaFinal.Value).Month) + 12 * (Convert.ToDateTime(FechaInicial.Value).Year - Convert.ToDateTime(FechaFinal.Value).Year))));
        }

        #region Crear detalle de venta
        public XRTable DetalleVentaXRTable()
        {
            int lnColumasDinamicas = (1 + Math.Abs((Convert.ToDateTime(FechaInicial.Value).Month - Convert.ToDateTime(FechaFinal.Value).Month) + 12 * (Convert.ToDateTime(FechaInicial.Value).Year - Convert.ToDateTime(FechaFinal.Value).Year))) * 2;
            int lnFilasDinamicas = 2;
            int lnIndicadorColumnaDetalle = 1;
            float lfAlturaFila = 22;

            XRTable loTabladetalle = new XRTable();
            loTabladetalle.Borders = DevExpress.XtraPrinting.BorderSide.None;
            loTabladetalle.BeginInit();

            for (int lnFila = 1; lnFila < lnFilasDinamicas; lnFila++)
            {
                XRTableRow row = new XRTableRow();
                row.HeightF = lfAlturaFila;
                for (int lnColumna = 1; lnColumna < lnColumasDinamicas + 1; lnColumna++)
                {
                    loBinding = "Query.AGRUPADOR" + lnIndicadorColumnaDetalle + "_ART_CANTIDAD";
                    if (lnColumna % 2 == 0)
                    {
                        loBinding = "Query.AGRUPADOR" + lnIndicadorColumnaDetalle + "_IMPORTE";
                        lnIndicadorColumnaDetalle = lnIndicadorColumnaDetalle + 1;
                    }
                    XRTableCell cell = new XRTableCell();
                    cell.Width = 60;
                    cell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                            new DevExpress.XtraReports.UI.XRBinding("Text", null, loBinding, "{0:n2}")});
                    cell.Name = "xrAgrupado" + lnColumna;
                    cell.StylePriority.UseTextAlignment = false;
                    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    row.Cells.Add(cell);
                }
                loTabladetalle.Rows.Add(row);
            }
            loTabladetalle.BeforePrint += new PrintEventHandler(DetalleVentaXRTable_BeforePrint);
            loTabladetalle.AdjustSize();
            loTabladetalle.EndInit();
            return loTabladetalle;
        }

        void DetalleVentaXRTable_BeforePrint(object sender, PrintEventArgs e)
        {
            XRTable loTabladetalle = ((XRTable)sender);
            loTabladetalle.LocationF = new DevExpress.Utils.PointFloat(602F, 0F);
            loTabladetalle.Font = new System.Drawing.Font("Times New Roman", 7F);
            int loMeses = 1 + Math.Abs((Convert.ToDateTime(FechaInicial.Value).Month - Convert.ToDateTime(FechaFinal.Value).Month) + 12 * (Convert.ToDateTime(FechaInicial.Value).Year - Convert.ToDateTime(FechaFinal.Value).Year));
            loTabladetalle.Width = 2 * loMeses * 60; ;
        }
        #endregion

        #region Crear encabezado meses
        public XRTable EncabezadoMesesXRTable()
        {
            int lnColumasDinamicas = (1 + Math.Abs((Convert.ToDateTime(FechaInicial.Value).Month - Convert.ToDateTime(FechaFinal.Value).Month) + 12 * (Convert.ToDateTime(FechaInicial.Value).Year - Convert.ToDateTime(FechaFinal.Value).Year)));
            int lnFilasDinamicas = 2;
            float lfAlturaFila = 22;

            XRTable loTabladetalle = new XRTable();
            loTabladetalle.Borders = DevExpress.XtraPrinting.BorderSide.None;
            loTabladetalle.BeginInit();

            for (int lnFila = 1; lnFila < lnFilasDinamicas; lnFila++)
            {
                XRTableRow row = new XRTableRow();
                row.HeightF = lfAlturaFila;
                for (int lnColumna = 1; lnColumna < lnColumasDinamicas + 1; lnColumna++)
                {
                    XRTableCell cell = new XRTableCell();
                    cell.Width = 120;
                    cell.Text = Convert.ToDateTime(FechaInicial.Value).AddMonths(lnColumna - 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es-MX")).ToUpper().Substring(0, 3) + ". " + Convert.ToDateTime(FechaInicial.Value).Year;
                    cell.Name = "xrAgrupadoMeses" + lnColumna;
                    cell.StylePriority.UseTextAlignment = false;
                    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    row.Cells.Add(cell);
                }
                loTabladetalle.Rows.Add(row);
            }
            loTabladetalle.BeforePrint += new PrintEventHandler(EncabezadoMesesXRTable_BeforePrint);
            loTabladetalle.AdjustSize();
            loTabladetalle.EndInit();
            return loTabladetalle;
        }

        void EncabezadoMesesXRTable_BeforePrint(object sender, PrintEventArgs e)
        {
            XRTable loTablaMeses = ((XRTable)sender);
            loTablaMeses.BackColor = System.Drawing.Color.DarkBlue;
            loTablaMeses.BorderColor = System.Drawing.Color.White;
            loTablaMeses.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
            | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            loTablaMeses.BorderWidth = 1F;
            loTablaMeses.LocationFloat = new DevExpress.Utils.PointFloat(603.4167F, 1.541678F);
            loTablaMeses.ForeColor = System.Drawing.Color.White;
            loTablaMeses.Font = new System.Drawing.Font("Times New Roman", 6.5F, FontStyle.Bold);
            int loMeses = 1 + Math.Abs((Convert.ToDateTime(FechaInicial.Value).Month - Convert.ToDateTime(FechaFinal.Value).Month) + 12 * (Convert.ToDateTime(FechaInicial.Value).Year - Convert.ToDateTime(FechaFinal.Value).Year));
            loTablaMeses.Width = loMeses * 120;
        }
        #endregion

        #region Crear encabezado piezas e importe
        public XRTable EncabezadoPzasImporteXRTable()
        {
            int lnColumasDinamicas = (1 + Math.Abs((Convert.ToDateTime(FechaInicial.Value).Month - Convert.ToDateTime(FechaFinal.Value).Month) + 12 * (Convert.ToDateTime(FechaInicial.Value).Year - Convert.ToDateTime(FechaFinal.Value).Year))) * 2;
            int lnFilasDinamicas = 2;
            int lnIndicadorColumnaDetalle = 1;
            float lfAlturaFila = 22;

            XRTable loTabladetalle = new XRTable();
            loTabladetalle.Borders = DevExpress.XtraPrinting.BorderSide.None;
            loTabladetalle.BeginInit();

            for (int lnFila = 1; lnFila < lnFilasDinamicas; lnFila++)
            {
                XRTableRow row = new XRTableRow();
                row.HeightF = lfAlturaFila;
                for (int lnColumna = 1; lnColumna < lnColumasDinamicas + 1; lnColumna++)
                {
                    loBinding = "PIEZAS";
                    if (lnColumna % 2 == 0)
                    {
                        loBinding = "IMPORTE";
                        lnIndicadorColumnaDetalle = lnIndicadorColumnaDetalle + 1;
                    }
                    XRTableCell cell = new XRTableCell();
                    cell.Width = 60;
                    cell.Text = loBinding;
                    cell.Name = "xrAgrupadoPzasImporte" + lnColumna;
                    cell.StylePriority.UseTextAlignment = false;
                    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    row.Cells.Add(cell);
                }
                loTabladetalle.Rows.Add(row);
            }
            loTabladetalle.BeforePrint += new PrintEventHandler(EncabezadoPzasImporteXRTable_BeforePrint);
            loTabladetalle.AdjustSize();
            loTabladetalle.EndInit();
            return loTabladetalle;
        }

        void EncabezadoPzasImporteXRTable_BeforePrint(object sender, PrintEventArgs e)
        {
            XRTable loTablaMeses = ((XRTable)sender);
            loTablaMeses.BackColor = System.Drawing.Color.DarkBlue;
            loTablaMeses.BorderColor = System.Drawing.Color.White;
            loTablaMeses.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
            | DevExpress.XtraPrinting.BorderSide.Right)
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            loTablaMeses.BorderWidth = 1F;
            loTablaMeses.LocationFloat = new DevExpress.Utils.PointFloat(603.4167F, 23.54167F);
            loTablaMeses.ForeColor = System.Drawing.Color.White;
            loTablaMeses.Font = new System.Drawing.Font("Times New Roman", 6.5F, FontStyle.Bold);
            int loMeses = 1 + Math.Abs((Convert.ToDateTime(FechaInicial.Value).Month - Convert.ToDateTime(FechaFinal.Value).Month) + 12 * (Convert.ToDateTime(FechaInicial.Value).Year - Convert.ToDateTime(FechaFinal.Value).Year));
            loTablaMeses.Width = loMeses * 120;
        }
        #endregion
    }


}

