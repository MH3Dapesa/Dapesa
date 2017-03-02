namespace Dapesa.Credito.Informes.IU.ClientesPlazoPagoNeto.Informe
{
    partial class ClientesPlazoPagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientesPlazoPagos));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrtblContenido = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellCliente = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellRazonSocial = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellStatus = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellVendedor = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellPlazoNeto = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellCondicionNeto = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellPlazoProntoPago = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellCondicionProntoPago = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellProntoPago1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellProntoPago2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellSeguro = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellPorcentajeSeguro = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellComisionSeguro = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrlblFechaEmision = new DevExpress.XtraReports.UI.XRLabel();
            this.lblFechaEmision = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPeriodoReporte = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblPeriodoReporte = new DevExpress.XtraReports.UI.XRLabel();
            this.lblFiltros = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblTituloReporte = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrtblEncabezado = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrcellCliente = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrcellRazonSocial = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrcellStatus = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrcellVendedor = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrcellPlazoNeto = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrcellCondicionNeto = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrcellPlazoProntoPago = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrcellCodicionProntoPago = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrcellPlazoProntoPago1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrcellPlazoProntoPago2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrcellSeguro = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrcellPorcentajeSeguro = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrcellComisionSeguro = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrtblPiePagina = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellUsuario = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrcellPagina = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrcellNoPagina = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrpiNoPagina = new DevExpress.XtraReports.UI.XRPageInfo();
            ((System.ComponentModel.ISupportInitialize)(this.xrtblContenido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrtblEncabezado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrtblPiePagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrtblContenido});
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrtblContenido
            // 
            this.xrtblContenido.BackColor = System.Drawing.Color.Transparent;
            this.xrtblContenido.BorderColor = System.Drawing.Color.Gainsboro;
            this.xrtblContenido.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrtblContenido.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrtblContenido.ForeColor = System.Drawing.Color.Black;
            this.xrtblContenido.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrtblContenido.Name = "xrtblContenido";
            this.xrtblContenido.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrtblContenido.SizeF = new System.Drawing.SizeF(1024F, 25F);
            this.xrtblContenido.StylePriority.UseBackColor = false;
            this.xrtblContenido.StylePriority.UseBorderColor = false;
            this.xrtblContenido.StylePriority.UseBorders = false;
            this.xrtblContenido.StylePriority.UseFont = false;
            this.xrtblContenido.StylePriority.UseForeColor = false;
            this.xrtblContenido.StylePriority.UseTextAlignment = false;
            this.xrtblContenido.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellCliente,
            this.cellRazonSocial,
            this.cellStatus,
            this.cellVendedor,
            this.cellPlazoNeto,
            this.cellCondicionNeto,
            this.cellPlazoProntoPago,
            this.cellCondicionProntoPago,
            this.cellProntoPago1,
            this.cellProntoPago2,
            this.cellSeguro,
            this.cellPorcentajeSeguro,
            this.cellComisionSeguro});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // cellCliente
            // 
            this.cellCliente.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.CLAVE")});
            this.cellCliente.Name = "cellCliente";
            this.cellCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.cellCliente.StylePriority.UsePadding = false;
            this.cellCliente.StylePriority.UseTextAlignment = false;
            this.cellCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cellCliente.Weight = 0.20195702179265923D;
            // 
            // cellRazonSocial
            // 
            this.cellRazonSocial.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.RAZON_SOCIAL")});
            this.cellRazonSocial.Name = "cellRazonSocial";
            this.cellRazonSocial.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.cellRazonSocial.StylePriority.UsePadding = false;
            this.cellRazonSocial.StylePriority.UseTextAlignment = false;
            this.cellRazonSocial.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cellRazonSocial.Weight = 0.86553021097033878D;
            // 
            // cellStatus
            // 
            this.cellStatus.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.STATUS")});
            this.cellStatus.Name = "cellStatus";
            this.cellStatus.StylePriority.UseTextAlignment = false;
            this.cellStatus.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.cellStatus.Weight = 0.057702005417521157D;
            // 
            // cellVendedor
            // 
            this.cellVendedor.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.VEND_CLAVE")});
            this.cellVendedor.Name = "cellVendedor";
            this.cellVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.cellVendedor.StylePriority.UsePadding = false;
            this.cellVendedor.StylePriority.UseTextAlignment = false;
            this.cellVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cellVendedor.Weight = 0.14425501443233871D;
            // 
            // cellPlazoNeto
            // 
            this.cellPlazoNeto.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PLAZO")});
            this.cellPlazoNeto.Name = "cellPlazoNeto";
            this.cellPlazoNeto.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.cellPlazoNeto.StylePriority.UsePadding = false;
            this.cellPlazoNeto.StylePriority.UseTextAlignment = false;
            this.cellPlazoNeto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cellPlazoNeto.Weight = 0.1731059365322247D;
            // 
            // cellCondicionNeto
            // 
            this.cellCondicionNeto.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.DESC_CONDICION")});
            this.cellCondicionNeto.Name = "cellCondicionNeto";
            this.cellCondicionNeto.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.cellCondicionNeto.StylePriority.UsePadding = false;
            this.cellCondicionNeto.StylePriority.UseTextAlignment = false;
            this.cellCondicionNeto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cellCondicionNeto.Weight = 0.23080820564666757D;
            // 
            // cellPlazoProntoPago
            // 
            this.cellPlazoProntoPago.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PLAZO_PP")});
            this.cellPlazoProntoPago.Name = "cellPlazoProntoPago";
            this.cellPlazoProntoPago.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.cellPlazoProntoPago.StylePriority.UsePadding = false;
            this.cellPlazoProntoPago.StylePriority.UseTextAlignment = false;
            this.cellPlazoProntoPago.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cellPlazoProntoPago.Weight = 0.17310566770226954D;
            // 
            // cellCondicionProntoPago
            // 
            this.cellCondicionProntoPago.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.CONDICION")});
            this.cellCondicionProntoPago.Name = "cellCondicionProntoPago";
            this.cellCondicionProntoPago.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.cellCondicionProntoPago.StylePriority.UsePadding = false;
            this.cellCondicionProntoPago.StylePriority.UseTextAlignment = false;
            this.cellCondicionProntoPago.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cellCondicionProntoPago.Weight = 0.23080819296892763D;
            // 
            // cellProntoPago1
            // 
            this.cellProntoPago1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PP1")});
            this.cellProntoPago1.Name = "cellProntoPago1";
            this.cellProntoPago1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.cellProntoPago1.StylePriority.UsePadding = false;
            this.cellProntoPago1.StylePriority.UseTextAlignment = false;
            this.cellProntoPago1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cellProntoPago1.Weight = 0.11540402198555994D;
            // 
            // cellProntoPago2
            // 
            this.cellProntoPago2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PP2")});
            this.cellProntoPago2.Name = "cellProntoPago2";
            this.cellProntoPago2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.cellProntoPago2.StylePriority.UsePadding = false;
            this.cellProntoPago2.StylePriority.UseTextAlignment = false;
            this.cellProntoPago2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cellProntoPago2.Weight = 0.11540366623961819D;
            // 
            // cellSeguro
            // 
            this.cellSeguro.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COB_SEGURO")});
            this.cellSeguro.Name = "cellSeguro";
            this.cellSeguro.StylePriority.UseTextAlignment = false;
            this.cellSeguro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.cellSeguro.Weight = 0.21722969927611646D;
            // 
            // cellPorcentajeSeguro
            // 
            this.cellPorcentajeSeguro.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.PSEGURO")});
            this.cellPorcentajeSeguro.Name = "cellPorcentajeSeguro";
            this.cellPorcentajeSeguro.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.cellPorcentajeSeguro.StylePriority.UsePadding = false;
            this.cellPorcentajeSeguro.StylePriority.UseTextAlignment = false;
            this.cellPorcentajeSeguro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cellPorcentajeSeguro.Weight = 0.19232521211989687D;
            // 
            // cellComisionSeguro
            // 
            this.cellComisionSeguro.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.COMISION_SEGURO")});
            this.cellComisionSeguro.Name = "cellComisionSeguro";
            this.cellComisionSeguro.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.cellComisionSeguro.StylePriority.UsePadding = false;
            this.cellComisionSeguro.StylePriority.UseTextAlignment = false;
            this.cellComisionSeguro.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.cellComisionSeguro.Weight = 0.23670789940061979D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 30F;
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
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "CLIENTES_PLAZO_PAGO";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlblFechaEmision,
            this.lblFechaEmision,
            this.lblPeriodoReporte,
            this.xrlblPeriodoReporte,
            this.lblFiltros,
            this.xrlblTituloReporte,
            this.xrLabel1,
            this.xrPictureBox1,
            this.xrtblEncabezado});
            this.PageHeader.HeightF = 150.7292F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrlblFechaEmision
            // 
            this.xrlblFechaEmision.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrlblFechaEmision.LocationFloat = new DevExpress.Utils.PointFloat(346.0828F, 73.93748F);
            this.xrlblFechaEmision.Name = "xrlblFechaEmision";
            this.xrlblFechaEmision.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblFechaEmision.SizeF = new System.Drawing.SizeF(112.5F, 17F);
            this.xrlblFechaEmision.StylePriority.UseFont = false;
            this.xrlblFechaEmision.StylePriority.UseTextAlignment = false;
            this.xrlblFechaEmision.Text = "Fecha Emisión:";
            this.xrlblFechaEmision.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblFechaEmision
            // 
            this.lblFechaEmision.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.lblFechaEmision.LocationFloat = new DevExpress.Utils.PointFloat(458.5828F, 73.93748F);
            this.lblFechaEmision.Name = "lblFechaEmision";
            this.lblFechaEmision.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblFechaEmision.SizeF = new System.Drawing.SizeF(565.4173F, 17F);
            this.lblFechaEmision.StylePriority.UseFont = false;
            this.lblFechaEmision.StylePriority.UseTextAlignment = false;
            this.lblFechaEmision.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblPeriodoReporte
            // 
            this.lblPeriodoReporte.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.lblPeriodoReporte.LocationFloat = new DevExpress.Utils.PointFloat(458.5828F, 56.93747F);
            this.lblPeriodoReporte.Name = "lblPeriodoReporte";
            this.lblPeriodoReporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPeriodoReporte.SizeF = new System.Drawing.SizeF(565.4172F, 17F);
            this.lblPeriodoReporte.StylePriority.UseFont = false;
            this.lblPeriodoReporte.StylePriority.UseTextAlignment = false;
            this.lblPeriodoReporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlblPeriodoReporte
            // 
            this.xrlblPeriodoReporte.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrlblPeriodoReporte.LocationFloat = new DevExpress.Utils.PointFloat(346.0828F, 56.93748F);
            this.xrlblPeriodoReporte.Name = "xrlblPeriodoReporte";
            this.xrlblPeriodoReporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblPeriodoReporte.SizeF = new System.Drawing.SizeF(112.5F, 17F);
            this.xrlblPeriodoReporte.StylePriority.UseFont = false;
            this.xrlblPeriodoReporte.StylePriority.UseTextAlignment = false;
            this.xrlblPeriodoReporte.Text = "Periodo de Reporte:";
            this.xrlblPeriodoReporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblFiltros
            // 
            this.lblFiltros.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.lblFiltros.LocationFloat = new DevExpress.Utils.PointFloat(346.0828F, 39.93747F);
            this.lblFiltros.Name = "lblFiltros";
            this.lblFiltros.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblFiltros.SizeF = new System.Drawing.SizeF(677.9172F, 17F);
            this.lblFiltros.StylePriority.UseFont = false;
            this.lblFiltros.StylePriority.UseTextAlignment = false;
            this.lblFiltros.Text = "lblFiltros";
            this.lblFiltros.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlblTituloReporte
            // 
            this.xrlblTituloReporte.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.xrlblTituloReporte.LocationFloat = new DevExpress.Utils.PointFloat(346.0828F, 15.93749F);
            this.xrlblTituloReporte.Name = "xrlblTituloReporte";
            this.xrlblTituloReporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblTituloReporte.SizeF = new System.Drawing.SizeF(677.9172F, 23.99999F);
            this.xrlblTituloReporte.StylePriority.UseFont = false;
            this.xrlblTituloReporte.StylePriority.UseTextAlignment = false;
            this.xrlblTituloReporte.Text = "Clientes plazo pago neto";
            this.xrlblTituloReporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 65.93748F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(346.0829F, 23.00001F);
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Distribuidora de Autopartes Pescador S.A. DE C.V.";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(84.71703F, 15.93748F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(150F, 50F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrtblEncabezado
            // 
            this.xrtblEncabezado.BackColor = System.Drawing.Color.MidnightBlue;
            this.xrtblEncabezado.BorderColor = System.Drawing.Color.White;
            this.xrtblEncabezado.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrtblEncabezado.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrtblEncabezado.ForeColor = System.Drawing.Color.White;
            this.xrtblEncabezado.LocationFloat = new DevExpress.Utils.PointFloat(0F, 116.7292F);
            this.xrtblEncabezado.Name = "xrtblEncabezado";
            this.xrtblEncabezado.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrtblEncabezado.SizeF = new System.Drawing.SizeF(1024F, 33.99999F);
            this.xrtblEncabezado.StylePriority.UseBackColor = false;
            this.xrtblEncabezado.StylePriority.UseBorderColor = false;
            this.xrtblEncabezado.StylePriority.UseBorders = false;
            this.xrtblEncabezado.StylePriority.UseFont = false;
            this.xrtblEncabezado.StylePriority.UseForeColor = false;
            this.xrtblEncabezado.StylePriority.UseTextAlignment = false;
            this.xrtblEncabezado.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrcellCliente,
            this.xrcellRazonSocial,
            this.xrcellStatus,
            this.xrcellVendedor,
            this.xrcellPlazoNeto,
            this.xrcellCondicionNeto,
            this.xrcellPlazoProntoPago,
            this.xrcellCodicionProntoPago,
            this.xrcellPlazoProntoPago1,
            this.xrcellPlazoProntoPago2,
            this.xrcellSeguro,
            this.xrcellPorcentajeSeguro,
            this.xrcellComisionSeguro});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrcellCliente
            // 
            this.xrcellCliente.Name = "xrcellCliente";
            this.xrcellCliente.Text = "CLIENTE";
            this.xrcellCliente.Weight = 0.20195702142106373D;
            // 
            // xrcellRazonSocial
            // 
            this.xrcellRazonSocial.Name = "xrcellRazonSocial";
            this.xrcellRazonSocial.Text = "RAZÓN SOCIAL";
            this.xrcellRazonSocial.Weight = 0.86553010011465714D;
            // 
            // xrcellStatus
            // 
            this.xrcellStatus.Name = "xrcellStatus";
            this.xrcellStatus.Text = "S";
            this.xrcellStatus.Weight = 0.057702006220823207D;
            // 
            // xrcellVendedor
            // 
            this.xrcellVendedor.Name = "xrcellVendedor";
            this.xrcellVendedor.Text = "VEND";
            this.xrcellVendedor.Weight = 0.14425501689142661D;
            // 
            // xrcellPlazoNeto
            // 
            this.xrcellPlazoNeto.Name = "xrcellPlazoNeto";
            this.xrcellPlazoNeto.Text = "PLAZO";
            this.xrcellPlazoNeto.Weight = 0.173106019026426D;
            // 
            // xrcellCondicionNeto
            // 
            this.xrcellCondicionNeto.Name = "xrcellCondicionNeto";
            this.xrcellCondicionNeto.Text = "CONDICIÓN";
            this.xrcellCondicionNeto.Weight = 0.23080803189844756D;
            // 
            // xrcellPlazoProntoPago
            // 
            this.xrcellPlazoProntoPago.Name = "xrcellPlazoProntoPago";
            this.xrcellPlazoProntoPago.Text = "PLAZO";
            this.xrcellPlazoProntoPago.Weight = 0.17310602082728849D;
            // 
            // xrcellCodicionProntoPago
            // 
            this.xrcellCodicionProntoPago.Name = "xrcellCodicionProntoPago";
            this.xrcellCodicionProntoPago.Text = "CONDICIÓN";
            this.xrcellCodicionProntoPago.Weight = 0.23080802805703016D;
            // 
            // xrcellPlazoProntoPago1
            // 
            this.xrcellPlazoProntoPago1.Name = "xrcellPlazoProntoPago1";
            this.xrcellPlazoProntoPago1.Text = "P.P. 1";
            this.xrcellPlazoProntoPago1.Weight = 0.11540401648266777D;
            // 
            // xrcellPlazoProntoPago2
            // 
            this.xrcellPlazoProntoPago2.Name = "xrcellPlazoProntoPago2";
            this.xrcellPlazoProntoPago2.Text = "P.P. 2";
            this.xrcellPlazoProntoPago2.Weight = 0.11540401292182678D;
            // 
            // xrcellSeguro
            // 
            this.xrcellSeguro.Name = "xrcellSeguro";
            this.xrcellSeguro.Text = "SEGURO";
            this.xrcellSeguro.Weight = 0.21722936910258439D;
            // 
            // xrcellPorcentajeSeguro
            // 
            this.xrcellPorcentajeSeguro.Name = "xrcellPorcentajeSeguro";
            this.xrcellPorcentajeSeguro.Text = "% SEGURO";
            this.xrcellPorcentajeSeguro.Weight = 0.19232521211989687D;
            // 
            // xrcellComisionSeguro
            // 
            this.xrcellComisionSeguro.Name = "xrcellComisionSeguro";
            this.xrcellComisionSeguro.Text = "COMISIÓN SEGURO";
            this.xrcellComisionSeguro.Weight = 0.23670789940061979D;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrtblPiePagina});
            this.PageFooter.HeightF = 26.04167F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrtblPiePagina
            // 
            this.xrtblPiePagina.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrtblPiePagina.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrtblPiePagina.Name = "xrtblPiePagina";
            this.xrtblPiePagina.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrtblPiePagina.SizeF = new System.Drawing.SizeF(1019.5F, 25F);
            this.xrtblPiePagina.StylePriority.UseFont = false;
            this.xrtblPiePagina.StylePriority.UseTextAlignment = false;
            this.xrtblPiePagina.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellUsuario,
            this.xrcellPagina,
            this.xrcellNoPagina});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // cellUsuario
            // 
            this.cellUsuario.Name = "cellUsuario";
            this.cellUsuario.Weight = 2.7101901131656487D;
            // 
            // xrcellPagina
            // 
            this.xrcellPagina.Name = "xrcellPagina";
            this.xrcellPagina.Text = "Pag.";
            this.xrcellPagina.Weight = 0.096031634556491038D;
            // 
            // xrcellNoPagina
            // 
            this.xrcellNoPagina.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrpiNoPagina});
            this.xrcellNoPagina.Name = "xrcellNoPagina";
            this.xrcellNoPagina.Weight = 0.23101757700477149D;
            // 
            // xrpiNoPagina
            // 
            this.xrpiNoPagina.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrpiNoPagina.Name = "xrpiNoPagina";
            this.xrpiNoPagina.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrpiNoPagina.SizeF = new System.Drawing.SizeF(77.54492F, 25F);
            // 
            // ClientesPlazoPagos
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.PageFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "Query";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(36, 40, 30, 30);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "15.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrtblContenido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrtblEncabezado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrtblPiePagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel xrlblFechaEmision;
        private DevExpress.XtraReports.UI.XRLabel lblFechaEmision;
        private DevExpress.XtraReports.UI.XRLabel lblPeriodoReporte;
        private DevExpress.XtraReports.UI.XRLabel xrlblPeriodoReporte;
        private DevExpress.XtraReports.UI.XRLabel lblFiltros;
        private DevExpress.XtraReports.UI.XRLabel xrlblTituloReporte;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRTable xrtblEncabezado;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrcellCliente;
        private DevExpress.XtraReports.UI.XRTableCell xrcellRazonSocial;
        private DevExpress.XtraReports.UI.XRTableCell xrcellStatus;
        private DevExpress.XtraReports.UI.XRTableCell xrcellVendedor;
        private DevExpress.XtraReports.UI.XRTableCell xrcellPlazoNeto;
        private DevExpress.XtraReports.UI.XRTableCell xrcellCondicionNeto;
        private DevExpress.XtraReports.UI.XRTableCell xrcellPlazoProntoPago;
        private DevExpress.XtraReports.UI.XRTableCell xrcellCodicionProntoPago;
        private DevExpress.XtraReports.UI.XRTableCell xrcellPlazoProntoPago1;
        private DevExpress.XtraReports.UI.XRTableCell xrcellPlazoProntoPago2;
        private DevExpress.XtraReports.UI.XRTableCell xrcellSeguro;
        private DevExpress.XtraReports.UI.XRTableCell xrcellPorcentajeSeguro;
        private DevExpress.XtraReports.UI.XRTableCell xrcellComisionSeguro;
        private DevExpress.XtraReports.UI.XRTable xrtblContenido;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell cellCliente;
        private DevExpress.XtraReports.UI.XRTableCell cellRazonSocial;
        private DevExpress.XtraReports.UI.XRTableCell cellStatus;
        private DevExpress.XtraReports.UI.XRTableCell cellVendedor;
        private DevExpress.XtraReports.UI.XRTableCell cellPlazoNeto;
        private DevExpress.XtraReports.UI.XRTableCell cellCondicionNeto;
        private DevExpress.XtraReports.UI.XRTableCell cellPlazoProntoPago;
        private DevExpress.XtraReports.UI.XRTableCell cellCondicionProntoPago;
        private DevExpress.XtraReports.UI.XRTableCell cellProntoPago1;
        private DevExpress.XtraReports.UI.XRTableCell cellProntoPago2;
        private DevExpress.XtraReports.UI.XRTableCell cellSeguro;
        private DevExpress.XtraReports.UI.XRTableCell cellPorcentajeSeguro;
        private DevExpress.XtraReports.UI.XRTableCell cellComisionSeguro;
        private DevExpress.XtraReports.UI.XRTable xrtblPiePagina;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell cellUsuario;
        private DevExpress.XtraReports.UI.XRTableCell xrcellPagina;
        private DevExpress.XtraReports.UI.XRTableCell xrcellNoPagina;
        private DevExpress.XtraReports.UI.XRPageInfo xrpiNoPagina;
    }
}
