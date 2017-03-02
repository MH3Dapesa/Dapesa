namespace Dapesa.Almacen.Pedidos.IU.Mensajero.Rdl
{
    partial class InformeCliente
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
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformeCliente));
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.FiltrosReporte = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrtxtCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtxtVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtEncabezadoDetalle = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrtcTipo = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcDescripcion = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcPP1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcPP2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcAdicional = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcObservaciones = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcComision = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcMes3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcMes2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcMes1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcMes0 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcMeta = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrlblCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Usuario = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.DataSourceClientes = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.CLIENTE = new DevExpress.XtraReports.UI.CalculatedField();
            this.COMISION = new DevExpress.XtraReports.UI.CalculatedField();
            this.MES = new DevExpress.XtraReports.UI.CalculatedField();
            this.MES1 = new DevExpress.XtraReports.UI.CalculatedField();
            this.MES2 = new DevExpress.XtraReports.UI.CalculatedField();
            this.MES0 = new DevExpress.XtraReports.UI.CalculatedField();
            this.IMPORTE_MES0 = new DevExpress.XtraReports.UI.CalculatedField();
            this.IMPORTE_MES1 = new DevExpress.XtraReports.UI.CalculatedField();
            this.IMPORTE_MES2 = new DevExpress.XtraReports.UI.CalculatedField();
            this.IMPORTES_MES3 = new DevExpress.XtraReports.UI.CalculatedField();
            this.MENSUAL_META = new DevExpress.XtraReports.UI.CalculatedField();
            this.LPADCLIENTE = new DevExpress.XtraReports.UI.CalculatedField();
            this.VEND = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this.xrtEncabezadoDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel16,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel11,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel2,
            this.xrLabel1});
            this.Detail.HeightF = 23F;
            this.Detail.KeepTogetherWithDetailReports = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MENSUAL_META", "{0:n2}")});
            this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(978F, 0F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(70.99988F, 23F);
            this.xrLabel16.StylePriority.UseFont = false;
            this.xrLabel16.StylePriority.UsePadding = false;
            this.xrLabel16.StylePriority.UseTextAlignment = false;
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.IMPORTE_MES0", "{0:n2}")});
            this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(908F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(70F, 23F);
            this.xrLabel15.StylePriority.UseFont = false;
            this.xrLabel15.StylePriority.UsePadding = false;
            this.xrLabel15.StylePriority.UseTextAlignment = false;
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.IMPORTE_MES1", "{0:n2}")});
            this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(838F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(69.99994F, 22.99999F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UsePadding = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.IMPORTE_MES2", "{0:n2}")});
            this.xrLabel13.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(768F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(70F, 23F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UsePadding = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.IMPORTES_MES3", "{0:n2}")});
            this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(698.0001F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(69.99994F, 23F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UsePadding = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.FECHA_ULT_MOD", "{0:dd/MM/yyyy}")});
            this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(630.0001F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(68F, 23F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "xrLabel9";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COMISION")});
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(595.0001F, 0F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(34.99994F, 23F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UsePadding = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.OBSERVACIONES")});
            this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(375F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(220.0001F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UsePadding = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "xrLabel7";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PCT_DESCTO3")});
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(340F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(34.99997F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UsePadding = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PCT_DESCTO2")});
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(305.0001F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(34.99997F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UsePadding = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PCT_DESCTO1")});
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(269.9999F, 0F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 5, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(35.00006F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UsePadding = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.DESCRIPCION")});
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(39.99999F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(230F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UsePadding = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TIPO")});
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(40F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 42.79166F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.CanShrink = true;
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.FiltrosReporte, "Text", "")});
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(287.5F, 23.58333F);
            this.xrLabel10.Multiline = true;
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(758.5F, 32.83334F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // FiltrosReporte
            // 
            this.FiltrosReporte.Description = "FiltrosReporte";
            this.FiltrosReporte.Name = "FiltrosReporte";
            // 
            // xrLabel22
            // 
            this.xrLabel22.CanShrink = true;
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(287.5F, 56.41667F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(100F, 16F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "Fecha de emisión:";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 52F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "SIIL_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // xrLine1
            // 
            this.xrLine1.BackColor = System.Drawing.Color.Transparent;
            this.xrLine1.ForeColor = System.Drawing.Color.Gray;
            this.xrLine1.LineWidth = 2;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(6.357829E-05F, 16.66667F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(1049F, 25.12499F);
            this.xrLine1.StylePriority.UseBackColor = false;
            this.xrLine1.StylePriority.UseForeColor = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrtxtCliente,
            this.xrtxtVendedor,
            this.xrtEncabezadoDetalle,
            this.xrlblCliente,
            this.xrlblVendedor,
            this.xrLine1});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("CVE_VENDEDOR", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("LPADCLIENTE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader1.HeightF = 102.7917F;
            this.GroupHeader1.KeepTogether = true;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.RepeatEveryPage = true;
            // 
            // xrtxtCliente
            // 
            this.xrtxtCliente.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.CLIENTE")});
            this.xrtxtCliente.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrtxtCliente.LocationFloat = new DevExpress.Utils.PointFloat(99.99987F, 41.79166F);
            this.xrtxtCliente.Name = "xrtxtCliente";
            this.xrtxtCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtxtCliente.SizeF = new System.Drawing.SizeF(949.0001F, 19F);
            this.xrtxtCliente.StylePriority.UseFont = false;
            this.xrtxtCliente.StylePriority.UseTextAlignment = false;
            this.xrtxtCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrtxtVendedor
            // 
            this.xrtxtVendedor.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.VEND")});
            this.xrtxtVendedor.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrtxtVendedor.LocationFloat = new DevExpress.Utils.PointFloat(99.99981F, 60.79165F);
            this.xrtxtVendedor.Name = "xrtxtVendedor";
            this.xrtxtVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrtxtVendedor.SizeF = new System.Drawing.SizeF(949.0001F, 19F);
            this.xrtxtVendedor.StylePriority.UseFont = false;
            this.xrtxtVendedor.StylePriority.UseTextAlignment = false;
            this.xrtxtVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrtEncabezadoDetalle
            // 
            this.xrtEncabezadoDetalle.BackColor = System.Drawing.Color.DarkBlue;
            this.xrtEncabezadoDetalle.BorderColor = System.Drawing.Color.White;
            this.xrtEncabezadoDetalle.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrtEncabezadoDetalle.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Bold);
            this.xrtEncabezadoDetalle.ForeColor = System.Drawing.Color.White;
            this.xrtEncabezadoDetalle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 79.79166F);
            this.xrtEncabezadoDetalle.Name = "xrtEncabezadoDetalle";
            this.xrtEncabezadoDetalle.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrtEncabezadoDetalle.SizeF = new System.Drawing.SizeF(1049F, 23F);
            this.xrtEncabezadoDetalle.StylePriority.UseBackColor = false;
            this.xrtEncabezadoDetalle.StylePriority.UseBorderColor = false;
            this.xrtEncabezadoDetalle.StylePriority.UseBorders = false;
            this.xrtEncabezadoDetalle.StylePriority.UseFont = false;
            this.xrtEncabezadoDetalle.StylePriority.UseForeColor = false;
            this.xrtEncabezadoDetalle.StylePriority.UseTextAlignment = false;
            this.xrtEncabezadoDetalle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrtcTipo,
            this.xrtcDescripcion,
            this.xrtcPP1,
            this.xrtcPP2,
            this.xrtcAdicional,
            this.xrtcObservaciones,
            this.xrtcComision,
            this.xrTableCell3,
            this.xrtcMes3,
            this.xrtcMes2,
            this.xrtcMes1,
            this.xrtcMes0,
            this.xrtcMeta});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrtcTipo
            // 
            this.xrtcTipo.Name = "xrtcTipo";
            this.xrtcTipo.StylePriority.UseTextAlignment = false;
            this.xrtcTipo.Text = "TIPO";
            this.xrtcTipo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcTipo.Weight = 0.15625001960027146D;
            // 
            // xrtcDescripcion
            // 
            this.xrtcDescripcion.Name = "xrtcDescripcion";
            this.xrtcDescripcion.StylePriority.UseTextAlignment = false;
            this.xrtcDescripcion.Text = "DESCRIPCIÓN";
            this.xrtcDescripcion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcDescripcion.Weight = 0.89843756278908715D;
            // 
            // xrtcPP1
            // 
            this.xrtcPP1.Name = "xrtcPP1";
            this.xrtcPP1.StylePriority.UseTextAlignment = false;
            this.xrtcPP1.Text = "PP1";
            this.xrtcPP1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcPP1.Weight = 0.13671877035346935D;
            // 
            // xrtcPP2
            // 
            this.xrtcPP2.Name = "xrtcPP2";
            this.xrtcPP2.StylePriority.UseTextAlignment = false;
            this.xrtcPP2.Text = "PP2";
            this.xrtcPP2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcPP2.Weight = 0.13671877035346941D;
            // 
            // xrtcAdicional
            // 
            this.xrtcAdicional.Name = "xrtcAdicional";
            this.xrtcAdicional.StylePriority.UseTextAlignment = false;
            this.xrtcAdicional.Text = "AD";
            this.xrtcAdicional.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcAdicional.Weight = 0.13671876836720631D;
            // 
            // xrtcObservaciones
            // 
            this.xrtcObservaciones.Name = "xrtcObservaciones";
            this.xrtcObservaciones.StylePriority.UseTextAlignment = false;
            this.xrtcObservaciones.Text = "OBSERVACIONES";
            this.xrtcObservaciones.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcObservaciones.Weight = 0.85937506245314754D;
            // 
            // xrtcComision
            // 
            this.xrtcComision.Name = "xrtcComision";
            this.xrtcComision.StylePriority.UseTextAlignment = false;
            this.xrtcComision.Text = "COM";
            this.xrtcComision.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcComision.Weight = 0.13671876106373676D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "ULT. ACT.";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell3.Weight = 0.265625027812221D;
            // 
            // xrtcMes3
            // 
            this.xrtcMes3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MES", "{0:MMM. yyyy}")});
            this.xrtcMes3.Name = "xrtcMes3";
            this.xrtcMes3.Scripts.OnAfterPrint = "xrtcMes3_AfterPrint";
            this.xrtcMes3.Scripts.OnBeforePrint = "xrtcMes3_BeforePrint";
            this.xrtcMes3.StylePriority.UseTextAlignment = false;
            this.xrtcMes3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcMes3.Weight = 0.27343754142793308D;
            // 
            // xrtcMes2
            // 
            this.xrtcMes2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MES2", "{0:MMM. yyyy}")});
            this.xrtcMes2.Name = "xrtcMes2";
            this.xrtcMes2.Scripts.OnBeforePrint = "xrtcMes2_BeforePrint";
            this.xrtcMes2.StylePriority.UseTextAlignment = false;
            this.xrtcMes2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcMes2.Weight = 0.27343754129540188D;
            // 
            // xrtcMes1
            // 
            this.xrtcMes1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MES1", "{0:MMM. yyyy}")});
            this.xrtcMes1.Name = "xrtcMes1";
            this.xrtcMes1.Scripts.OnBeforePrint = "xrtcMes1_BeforePrint";
            this.xrtcMes1.StylePriority.UseTextAlignment = false;
            this.xrtcMes1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcMes1.Weight = 0.27343751243657866D;
            // 
            // xrtcMes0
            // 
            this.xrtcMes0.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.MES0", "{0:MMM. yyyy}")});
            this.xrtcMes0.Name = "xrtcMes0";
            this.xrtcMes0.Scripts.OnBeforePrint = "xrtcMes0_BeforePrint";
            this.xrtcMes0.StylePriority.UseTextAlignment = false;
            this.xrtcMes0.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcMes0.Weight = 0.27343754353280025D;
            // 
            // xrtcMeta
            // 
            this.xrtcMeta.Name = "xrtcMeta";
            this.xrtcMeta.StylePriority.UseTextAlignment = false;
            this.xrtcMeta.Text = "META";
            this.xrtcMeta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrtcMeta.Weight = 0.2773440164320482D;
            // 
            // xrlblCliente
            // 
            this.xrlblCliente.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrlblCliente.LocationFloat = new DevExpress.Utils.PointFloat(6.341934E-05F, 41.79166F);
            this.xrlblCliente.Name = "xrlblCliente";
            this.xrlblCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblCliente.SizeF = new System.Drawing.SizeF(100F, 19F);
            this.xrlblCliente.StylePriority.UseFont = false;
            this.xrlblCliente.StylePriority.UseTextAlignment = false;
            this.xrlblCliente.Text = "CLIENTE:";
            this.xrlblCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlblVendedor
            // 
            this.xrlblVendedor.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrlblVendedor.LocationFloat = new DevExpress.Utils.PointFloat(6.341934E-05F, 60.79166F);
            this.xrlblVendedor.Name = "xrlblVendedor";
            this.xrlblVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblVendedor.SizeF = new System.Drawing.SizeF(100F, 19F);
            this.xrlblVendedor.StylePriority.UseFont = false;
            this.xrlblVendedor.StylePriority.UseTextAlignment = false;
            this.xrlblVendedor.Text = "VENDEDOR:";
            this.xrlblVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.xrPageInfo1});
            this.PageFooter.HeightF = 23F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.Usuario, "Text", "")});
            this.xrLabel12.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(835.0001F, 23F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Usuario
            // 
            this.Usuario.Description = "Usuario";
            this.Usuario.Name = "Usuario";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Format = "Pag.{0}de {1}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(835.4998F, 0F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(213.5F, 23F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1,
            this.xrLabel19,
            this.xrLabel22,
            this.xrPageInfo2,
            this.xrLabel10,
            this.xrLabel3});
            this.PageHeader.HeightF = 72.41667F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(75F, 10.00001F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(136.4583F, 39.41665F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(287.5F, 0.5833308F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(758.5F, 23F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "CLIENTES DESCUENTOS ADICIONALES";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "{0:dddd, dd\' de \'MMMM\' de \'yyyy hh:mm tt}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(387.5F, 56.41667F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(658.4999F, 16F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.StylePriority.UseTextAlignment = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.xrLabel3.Font = new System.Drawing.Font("Arial Narrow", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(5.166753F, 49.41667F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(282.3333F, 23F);
            this.xrLabel3.StylePriority.UseBorderColor = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseForeColor = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "DISTRIBUIDORA DE AUTOPARTES PESCADOR S.A. DE C.V.";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // DataSourceClientes
            // 
            this.DataSourceClientes.ConnectionName = "PRUEBAS";
            this.DataSourceClientes.Name = "DataSourceClientes";
            customSqlQuery2.Name = "Query";
            customSqlQuery2.Sql = resources.GetString("customSqlQuery2.Sql");
            this.DataSourceClientes.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery2});
            this.DataSourceClientes.ResultSchemaSerializable = resources.GetString("DataSourceClientes.ResultSchemaSerializable");
            // 
            // CLIENTE
            // 
            this.CLIENTE.DataMember = "Query";
            this.CLIENTE.Expression = "Concat([CLI_CLAVE],\' \',[RAZON_SOCIAL],\'   (\',[STATUS],\')\' )";
            this.CLIENTE.Name = "CLIENTE";
            // 
            // COMISION
            // 
            this.COMISION.DataMember = "Query";
            this.COMISION.Expression = "Iif(IsNullOrEmpty([PCT_COMISION]), \'-\' , [PCT_COMISION])";
            this.COMISION.Name = "COMISION";
            // 
            // MES
            // 
            this.MES.DataMember = "Query";
            this.MES.DisplayName = "MES3";
            this.MES.Expression = "AddMonths(Now(),-3)";
            this.MES.Name = "MES";
            // 
            // MES1
            // 
            this.MES1.DataMember = "Query";
            this.MES1.Expression = "AddMonths(Now(),-1)";
            this.MES1.Name = "MES1";
            // 
            // MES2
            // 
            this.MES2.DataMember = "Query";
            this.MES2.Expression = "AddMonths(Now(),-2 )";
            this.MES2.Name = "MES2";
            // 
            // MES0
            // 
            this.MES0.DataMember = "Query";
            this.MES0.Expression = "Now()";
            this.MES0.Name = "MES0";
            // 
            // IMPORTE_MES0
            // 
            this.IMPORTE_MES0.DataMember = "Query";
            this.IMPORTE_MES0.Expression = "[VTA_MES] - [DEV_MES]";
            this.IMPORTE_MES0.Name = "IMPORTE_MES0";
            // 
            // IMPORTE_MES1
            // 
            this.IMPORTE_MES1.DataMember = "Query";
            this.IMPORTE_MES1.Expression = "[VTA_MES1] - [DEV_MES1]";
            this.IMPORTE_MES1.Name = "IMPORTE_MES1";
            // 
            // IMPORTE_MES2
            // 
            this.IMPORTE_MES2.DataMember = "Query";
            this.IMPORTE_MES2.Expression = "[VTA_MES2] - [DEV_MES2]";
            this.IMPORTE_MES2.Name = "IMPORTE_MES2";
            // 
            // IMPORTES_MES3
            // 
            this.IMPORTES_MES3.DataMember = "Query";
            this.IMPORTES_MES3.Expression = "[VTA_MES3] - [DEV_MES3]";
            this.IMPORTES_MES3.Name = "IMPORTES_MES3";
            // 
            // MENSUAL_META
            // 
            this.MENSUAL_META.DataMember = "Query";
            this.MENSUAL_META.Expression = "Iif(IsNullOrEmpty([META_MENSUAL]), \'-\' ,[META_MENSUAL])";
            this.MENSUAL_META.Name = "MENSUAL_META";
            // 
            // LPADCLIENTE
            // 
            this.LPADCLIENTE.DataMember = "Query";
            this.LPADCLIENTE.Expression = "PadLeft([CLI_CLAVE],20 )";
            this.LPADCLIENTE.Name = "LPADCLIENTE";
            // 
            // VEND
            // 
            this.VEND.DataMember = "Query";
            this.VEND.Expression = "Concat([CVE_VENDEDOR],\' \', [VENDEDOR])";
            this.VEND.Name = "VEND";
            // 
            // InformeCliente
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.PageFooter,
            this.PageHeader});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.CLIENTE,
            this.COMISION,
            this.MES,
            this.MES1,
            this.MES2,
            this.MES0,
            this.IMPORTE_MES0,
            this.IMPORTE_MES1,
            this.IMPORTE_MES2,
            this.IMPORTES_MES3,
            this.MENSUAL_META,
            this.LPADCLIENTE,
            this.VEND});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1,
            this.DataSourceClientes});
            this.DataMember = "Query";
            this.DataSource = this.DataSourceClientes;
            this.DefaultPrinterSettingsUsing.UsePaperKind = true;
            this.DisplayName = "Clientes - Descuentos adicionales";
            this.ExportOptions.Xlsx.DocumentOptions.Application = "REPORTES";
            this.ExportOptions.Xlsx.DocumentOptions.Author = "DISTRIBUIDORA DE AUTOPARTES PESCADOR S.A. DE C.V.";
            this.ExportOptions.Xlsx.DocumentOptions.Category = "VENTAS";
            this.ExportOptions.Xlsx.DocumentOptions.Comments = "Muestra los clientes por sucursal y sus trajes a la medida.";
            this.ExportOptions.Xlsx.DocumentOptions.Company = "DAPESA";
            this.ExportOptions.Xlsx.DocumentOptions.Title = "Clientes Descuentos Adicionales";
            this.ExportOptions.Xlsx.SheetName = "CLIENTES";
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(28, 23, 43, 52);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Usuario,
            this.FiltrosReporte});
            this.ScriptsSource = resources.GetString("$this.ScriptsSource");
            this.Version = "15.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrtEncabezadoDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.Parameters.Parameter Usuario;
        private DevExpress.XtraReports.Parameters.Parameter FiltrosReporte;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.DataAccess.Sql.SqlDataSource DataSourceClientes;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrlblCliente;
        private DevExpress.XtraReports.UI.XRLabel xrlblVendedor;
        private DevExpress.XtraReports.UI.XRTable xrtEncabezadoDetalle;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrtcTipo;
        private DevExpress.XtraReports.UI.XRTableCell xrtcDescripcion;
        private DevExpress.XtraReports.UI.XRTableCell xrtcPP1;
        private DevExpress.XtraReports.UI.XRTableCell xrtcPP2;
        private DevExpress.XtraReports.UI.XRTableCell xrtcAdicional;
        private DevExpress.XtraReports.UI.XRTableCell xrtcObservaciones;
        private DevExpress.XtraReports.UI.XRTableCell xrtcComision;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrtxtCliente;
        private DevExpress.XtraReports.UI.XRLabel xrtxtVendedor;
        private DevExpress.XtraReports.UI.CalculatedField CLIENTE;
        private DevExpress.XtraReports.UI.CalculatedField COMISION;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrtcMes3;
        private DevExpress.XtraReports.UI.XRTableCell xrtcMes2;
        private DevExpress.XtraReports.UI.XRTableCell xrtcMes1;
        private DevExpress.XtraReports.UI.XRTableCell xrtcMeta;
        private DevExpress.XtraReports.UI.CalculatedField MES;
        private DevExpress.XtraReports.UI.CalculatedField MES1;
        private DevExpress.XtraReports.UI.CalculatedField MES2;
        private DevExpress.XtraReports.UI.CalculatedField MES0;
        private DevExpress.XtraReports.UI.CalculatedField IMPORTE_MES0;
        private DevExpress.XtraReports.UI.CalculatedField IMPORTE_MES1;
        private DevExpress.XtraReports.UI.CalculatedField IMPORTE_MES2;
        private DevExpress.XtraReports.UI.CalculatedField IMPORTES_MES3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRTableCell xrtcMes0;
        private DevExpress.XtraReports.UI.CalculatedField MENSUAL_META;
        private DevExpress.XtraReports.UI.CalculatedField LPADCLIENTE;
        private DevExpress.XtraReports.UI.CalculatedField VEND;
    }
}
