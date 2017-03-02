namespace Dapesa.Comun.Informes.General.IU.Reportes.Informes.Clientes
{
    partial class InformeAnalisisVentaVendedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.ConnectionParameters.OracleConnectionParameters oracleConnectionParameters1 = new DevExpress.DataAccess.ConnectionParameters.OracleConnectionParameters();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformeAnalisisVentaVendedor));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.DataSourceAnalisisVentaVendedor = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.Art_Clave = new DevExpress.XtraReports.Parameters.Parameter();
            this.FechaInicio = new DevExpress.XtraReports.Parameters.Parameter();
            this.FechaFin = new DevExpress.XtraReports.Parameters.Parameter();
            this.Monto = new DevExpress.XtraReports.Parameters.Parameter();
            this.Usuario = new DevExpress.XtraReports.Parameters.Parameter();
            this.Linea = new DevExpress.XtraReports.Parameters.Parameter();
            this.Marca = new DevExpress.XtraReports.Parameters.Parameter();
            this.FiltrosReporte = new DevExpress.XtraReports.Parameters.Parameter();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Periodo = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.fieldVENDCLAVE1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldNOMVENDEDOR1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldMES1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldPIEZAS1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldIMPORTE1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldSERIEVENDEDOR1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.Piezas = new DevExpress.XtraReports.Parameters.Parameter();
            this.Cliente = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 12.29167F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 30F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DataSourceAnalisisVentaVendedor
            // 
            this.DataSourceAnalisisVentaVendedor.ConnectionName = "siil_Connection";
            oracleConnectionParameters1.ServerName = "siil";
            this.DataSourceAnalisisVentaVendedor.ConnectionParameters = oracleConnectionParameters1;
            this.DataSourceAnalisisVentaVendedor.Name = "DataSourceAnalisisVentaVendedor";
            customSqlQuery1.Name = "Query";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.DataSourceAnalisisVentaVendedor.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.DataSourceAnalisisVentaVendedor.ResultSchemaSerializable = resources.GetString("DataSourceAnalisisVentaVendedor.ResultSchemaSerializable");
            // 
            // Art_Clave
            // 
            this.Art_Clave.Description = "articulo clave";
            this.Art_Clave.Name = "Art_Clave";
            this.Art_Clave.Visible = false;
            // 
            // FechaInicio
            // 
            this.FechaInicio.Description = "fecha inicial";
            this.FechaInicio.Name = "FechaInicio";
            this.FechaInicio.Visible = false;
            // 
            // FechaFin
            // 
            this.FechaFin.Description = "fecha final";
            this.FechaFin.Name = "FechaFin";
            this.FechaFin.Visible = false;
            // 
            // Monto
            // 
            this.Monto.Description = "monto";
            this.Monto.Name = "Monto";
            this.Monto.Visible = false;
            // 
            // Usuario
            // 
            this.Usuario.Description = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.Visible = false;
            // 
            // Linea
            // 
            this.Linea.Description = "Linea";
            this.Linea.Name = "Linea";
            this.Linea.Visible = false;
            // 
            // Marca
            // 
            this.Marca.Description = "marca";
            this.Marca.Name = "Marca";
            this.Marca.Visible = false;
            // 
            // FiltrosReporte
            // 
            this.FiltrosReporte.Description = "filtro reporte";
            this.FiltrosReporte.Name = "FiltrosReporte";
            this.FiltrosReporte.Visible = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel15,
            this.xrLabel4,
            this.xrLabel16,
            this.xrLabel14,
            this.xrLabel12,
            this.xrLabel10,
            this.xrLabel8,
            this.xrPageInfo1,
            this.xrLabel22,
            this.xrLabel19,
            this.xrPictureBox1,
            this.xrLabel3,
            this.xrLabel5,
            this.xrLabel7,
            this.xrLabel9,
            this.xrLabel11,
            this.xrLabel13,
            this.xrLabel1,
            this.xrLabel2});
            this.PageHeader.HeightF = 120.125F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel16
            // 
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(270.4165F, 32.99999F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(80.75018F, 16F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.Text = "SUCURSAL:";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(556.9583F, 64.99999F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(81.45837F, 16F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "ARTICULO:";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(270.4169F, 64.99999F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(80.74979F, 16F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "LINEA:";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(421.1666F, 80.99998F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(67F, 16F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "PIEZAS:";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(270.4167F, 48.99999F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(80.75F, 16F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "MARCA:";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(378.25F, 96.99999F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(394.875F, 16F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel22
            // 
            this.xrLabel22.CanShrink = true;
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(270.4167F, 96.99999F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(107.8333F, 16F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "FECHA DE EMISIÓN:";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(270.4166F, 10.00001F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(502.7084F, 23F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "ANALISIS DE VENTAS POR VENDEDOR";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(72.33326F, 16.58335F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(136.4583F, 39.41665F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrLabel3
            // 
            this.xrLabel3.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.xrLabel3.Font = new System.Drawing.Font("Arial Narrow", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(24.16669F, 56.00001F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(228.1666F, 23F);
            this.xrLabel3.StylePriority.UseBorderColor = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseForeColor = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "DISTRIBUIDORA DE AUTOPARTES PESCADOR S.A. DE C.V.";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.FiltrosReporte, "Text", "")});
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(351.1667F, 32.99999F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(205.7916F, 16F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.Marca, "Text", "")});
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(351.1666F, 48.99999F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(421.9584F, 16F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.Linea, "Text", "")});
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(351.1667F, 64.99999F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(205.7916F, 16F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.Art_Clave, "Text", "")});
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(638.4167F, 64.99999F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(134.7083F, 16F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.Piezas, "Text", "{0:c2}")});
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(488.1666F, 80.99998F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(68.79166F, 16F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.Periodo, "Text", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(638.4167F, 32.99999F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(134.7083F, 16F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Periodo
            // 
            this.Periodo.Description = "Periodo fecha";
            this.Periodo.Name = "Periodo";
            this.Periodo.Visible = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(556.9583F, 32.99999F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(81.45837F, 16F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "PERIODO:";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
            this.ReportFooter.HeightF = 102.5F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrPivotGrid1
            // 
            this.xrPivotGrid1.Appearance.Cell.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.xrPivotGrid1.Appearance.Cell.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.xrPivotGrid1.Appearance.CustomTotalCell.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.xrPivotGrid1.Appearance.CustomTotalCell.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.xrPivotGrid1.Appearance.FieldHeader.BackColor = System.Drawing.Color.DarkBlue;
            this.xrPivotGrid1.Appearance.FieldHeader.ForeColor = System.Drawing.Color.White;
            this.xrPivotGrid1.Appearance.FieldHeader.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrPivotGrid1.Appearance.FieldHeader.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.xrPivotGrid1.Appearance.FieldValue.BackColor = System.Drawing.Color.DarkBlue;
            this.xrPivotGrid1.Appearance.FieldValue.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrPivotGrid1.Appearance.FieldValue.ForeColor = System.Drawing.Color.White;
            this.xrPivotGrid1.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrPivotGrid1.Appearance.FieldValue.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.xrPivotGrid1.Appearance.FieldValueGrandTotal.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.xrPivotGrid1.Appearance.FieldValueGrandTotal.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.xrPivotGrid1.Appearance.FieldValueTotal.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.xrPivotGrid1.Appearance.FieldValueTotal.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.xrPivotGrid1.Appearance.GrandTotalCell.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.xrPivotGrid1.Appearance.GrandTotalCell.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.xrPivotGrid1.Appearance.TotalCell.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.xrPivotGrid1.Appearance.TotalCell.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.xrPivotGrid1.DataMember = "Query";
            this.xrPivotGrid1.DataSource = this.DataSourceAnalisisVentaVendedor;
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldVENDCLAVE1,
            this.fieldNOMVENDEDOR1,
            this.fieldMES1,
            this.fieldPIEZAS1,
            this.fieldIMPORTE1,
            this.fieldSERIEVENDEDOR1});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OLAPConnectionString = "";
            this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
            this.xrPivotGrid1.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.xrPivotGrid1.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.xrPivotGrid1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.xrPivotGrid1.OptionsPrint.PrintHeadersOnEveryPage = true;
            this.xrPivotGrid1.OptionsPrint.PrintHorzLines = DevExpress.Utils.DefaultBoolean.True;
            this.xrPivotGrid1.OptionsPrint.PrintUnusedFilterFields = false;
            this.xrPivotGrid1.OptionsPrint.PrintVertLines = DevExpress.Utils.DefaultBoolean.True;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(563.4583F, 102.5F);
            // 
            // fieldVENDCLAVE1
            // 
            this.fieldVENDCLAVE1.Appearance.FieldValue.BackColor = System.Drawing.Color.White;
            this.fieldVENDCLAVE1.Appearance.FieldValue.ForeColor = System.Drawing.Color.Black;
            this.fieldVENDCLAVE1.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.fieldVENDCLAVE1.Appearance.FieldValue.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fieldVENDCLAVE1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldVENDCLAVE1.AreaIndex = 2;
            this.fieldVENDCLAVE1.FieldName = "VEND_CLAVE";
            this.fieldVENDCLAVE1.Name = "fieldVENDCLAVE1";
            this.fieldVENDCLAVE1.Width = 50;
            // 
            // fieldNOMVENDEDOR1
            // 
            this.fieldNOMVENDEDOR1.Appearance.FieldValue.BackColor = System.Drawing.Color.White;
            this.fieldNOMVENDEDOR1.Appearance.FieldValue.ForeColor = System.Drawing.Color.Black;
            this.fieldNOMVENDEDOR1.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.fieldNOMVENDEDOR1.Appearance.FieldValue.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fieldNOMVENDEDOR1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldNOMVENDEDOR1.AreaIndex = 1;
            this.fieldNOMVENDEDOR1.FieldName = "NOM_VENDEDOR";
            this.fieldNOMVENDEDOR1.Name = "fieldNOMVENDEDOR1";
            this.fieldNOMVENDEDOR1.Width = 250;
            // 
            // fieldMES1
            // 
            this.fieldMES1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldMES1.AreaIndex = 0;
            this.fieldMES1.FieldName = "MES";
            this.fieldMES1.Name = "fieldMES1";
            this.fieldMES1.ValueFormat.FormatString = "MMMM\' de \' yyyy";
            this.fieldMES1.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            // 
            // fieldPIEZAS1
            // 
            this.fieldPIEZAS1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldPIEZAS1.AreaIndex = 0;
            this.fieldPIEZAS1.CellFormat.FormatString = "N2";
            this.fieldPIEZAS1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldPIEZAS1.EmptyCellText = "0";
            this.fieldPIEZAS1.EmptyValueText = "0";
            this.fieldPIEZAS1.FieldName = "PIEZAS";
            this.fieldPIEZAS1.Name = "fieldPIEZAS1";
            this.fieldPIEZAS1.ValueFormat.FormatString = "N2";
            this.fieldPIEZAS1.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // fieldIMPORTE1
            // 
            this.fieldIMPORTE1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldIMPORTE1.AreaIndex = 1;
            this.fieldIMPORTE1.EmptyCellText = "0";
            this.fieldIMPORTE1.EmptyValueText = "0";
            this.fieldIMPORTE1.FieldName = "IMPORTE";
            this.fieldIMPORTE1.Name = "fieldIMPORTE1";
            // 
            // fieldSERIEVENDEDOR1
            // 
            this.fieldSERIEVENDEDOR1.Appearance.FieldValue.BackColor = System.Drawing.Color.White;
            this.fieldSERIEVENDEDOR1.Appearance.FieldValue.ForeColor = System.Drawing.Color.Black;
            this.fieldSERIEVENDEDOR1.Appearance.FieldValue.TextHorizontalAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.fieldSERIEVENDEDOR1.Appearance.FieldValue.TextVerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.fieldSERIEVENDEDOR1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldSERIEVENDEDOR1.AreaIndex = 0;
            this.fieldSERIEVENDEDOR1.FieldName = "SERIE_VENDEDOR";
            this.fieldSERIEVENDEDOR1.Name = "fieldSERIEVENDEDOR1";
            this.fieldSERIEVENDEDOR1.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            this.fieldSERIEVENDEDOR1.Width = 30;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6});
            this.PageFooter.HeightF = 18F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrLabel6
            // 
            this.xrLabel6.CanShrink = true;
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.Usuario, "Text", "")});
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(242.3333F, 18F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(270.4169F, 80.99999F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(80.75F, 16F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "CLIENTE:";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.Cliente, "Text", "{0:c2}")});
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(351.1666F, 80.99998F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(70F, 16F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel17
            // 
            this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(556.9583F, 80.99998F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(81.45837F, 16F);
            this.xrLabel17.StylePriority.UseFont = false;
            this.xrLabel17.StylePriority.UseTextAlignment = false;
            this.xrLabel17.Text = "MONTO:";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.Monto, "Text", "{0:c2}")});
            this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 8.25F);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(638.4167F, 80.99998F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(134.7083F, 16F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Piezas
            // 
            this.Piezas.Description = "Piezas";
            this.Piezas.Name = "Piezas";
            this.Piezas.Visible = false;
            // 
            // Cliente
            // 
            this.Cliente.Description = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.Visible = false;
            // 
            // InformeAnalisisVentaVendedor
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.ReportFooter,
            this.PageFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.DataSourceAnalisisVentaVendedor});
            this.DataMember = "Query";
            this.DataSource = this.DataSourceAnalisisVentaVendedor;
            this.Margins = new System.Drawing.Printing.Margins(29, 21, 12, 30);
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Art_Clave,
            this.FechaInicio,
            this.FechaFin,
            this.Monto,
            this.Usuario,
            this.Linea,
            this.Marca,
            this.FiltrosReporte,
            this.Periodo,
            this.Piezas,
            this.Cliente});
            this.Version = "15.2";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.InformeAnalisisVentaVendedor_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource DataSourceAnalisisVentaVendedor;
        private DevExpress.XtraReports.Parameters.Parameter Art_Clave;
        private DevExpress.XtraReports.Parameters.Parameter FechaInicio;
        private DevExpress.XtraReports.Parameters.Parameter FechaFin;
        private DevExpress.XtraReports.Parameters.Parameter Monto;
        private DevExpress.XtraReports.Parameters.Parameter Usuario;
        private DevExpress.XtraReports.Parameters.Parameter Linea;
        private DevExpress.XtraReports.Parameters.Parameter Marca;
        private DevExpress.XtraReports.Parameters.Parameter FiltrosReporte;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPivotGrid xrPivotGrid1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldVENDCLAVE1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldNOMVENDEDOR1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldMES1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldPIEZAS1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldIMPORTE1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldSERIEVENDEDOR1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.Parameters.Parameter Periodo;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.Parameters.Parameter Piezas;
        private DevExpress.XtraReports.Parameters.Parameter Cliente;
    }
}
