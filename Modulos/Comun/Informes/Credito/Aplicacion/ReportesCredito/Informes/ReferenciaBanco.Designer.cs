namespace Dapesa.Comun.Informes.Credito.IU.ReportesCredito.Informes
{
    partial class ReferenciaBanco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReferenciaBanco));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrtblDatos = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrClave = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrCliente = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrStatus = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrReferencia = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReferenciaBancoDataSource = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrpiPagina = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrlblUsuario = new DevExpress.XtraReports.UI.XRLabel();
            this.Usuario = new DevExpress.XtraReports.Parameters.Parameter();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrlblFiltrosAdicionales = new DevExpress.XtraReports.UI.XRLabel();
            this.FiltrosReporte = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrtblEncabezado = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrtcClave = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcRazonSocial = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcStatus = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrtcReferencia = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrlblVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.xrVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.cfVendedor = new DevExpress.XtraReports.UI.CalculatedField();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.cfCve_Cliente = new DevExpress.XtraReports.UI.CalculatedField();
            ((System.ComponentModel.ISupportInitialize)(this.xrtblDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrtblEncabezado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrtblDatos});
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("cfCve_Cliente", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrtblDatos
            // 
            this.xrtblDatos.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrtblDatos.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrtblDatos.Name = "xrtblDatos";
            this.xrtblDatos.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrtblDatos.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrtblDatos.SizeF = new System.Drawing.SizeF(748F, 23F);
            this.xrtblDatos.StylePriority.UseFont = false;
            this.xrtblDatos.StylePriority.UsePadding = false;
            this.xrtblDatos.StylePriority.UseTextAlignment = false;
            this.xrtblDatos.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrClave,
            this.xrCliente,
            this.xrStatus,
            this.xrReferencia});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrClave
            // 
            this.xrClave.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.CLAVE")});
            this.xrClave.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrClave.Name = "xrClave";
            this.xrClave.StylePriority.UseFont = false;
            this.xrClave.Weight = 0.72289131550617425D;
            // 
            // xrCliente
            // 
            this.xrCliente.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.RAZON_SOCIAL")});
            this.xrCliente.Name = "xrCliente";
            this.xrCliente.Weight = 3.2831323752039525D;
            // 
            // xrStatus
            // 
            this.xrStatus.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.STATUS")});
            this.xrStatus.Name = "xrStatus";
            this.xrStatus.Weight = 0.65060237838560386D;
            // 
            // xrReferencia
            // 
            this.xrReferencia.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.TEXTO1")});
            this.xrReferencia.Name = "xrReferencia";
            this.xrReferencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.xrReferencia.StylePriority.UsePadding = false;
            this.xrReferencia.StylePriority.UseTextAlignment = false;
            this.xrReferencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrReferencia.Weight = 0.75060262654621213D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 40F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 40F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReferenciaBancoDataSource
            // 
            this.ReferenciaBancoDataSource.ConnectionName = "Conexion_ReportesCredito";
            this.ReferenciaBancoDataSource.Name = "ReferenciaBancoDataSource";
            customSqlQuery1.Name = "Query";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.ReferenciaBancoDataSource.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.ReferenciaBancoDataSource.ResultSchemaSerializable = resources.GetString("ReferenciaBancoDataSource.ResultSchemaSerializable");
            // 
            // pageFooterBand1
            // 
            this.pageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrpiPagina,
            this.xrlblUsuario});
            this.pageFooterBand1.HeightF = 23F;
            this.pageFooterBand1.Name = "pageFooterBand1";
            // 
            // xrpiPagina
            // 
            this.xrpiPagina.Format = "Pag.{0}de {1}";
            this.xrpiPagina.LocationFloat = new DevExpress.Utils.PointFloat(602F, 0F);
            this.xrpiPagina.Name = "xrpiPagina";
            this.xrpiPagina.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrpiPagina.SizeF = new System.Drawing.SizeF(145.9998F, 23F);
            this.xrpiPagina.StylePriority.UseTextAlignment = false;
            this.xrpiPagina.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrlblUsuario
            // 
            this.xrlblUsuario.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.Usuario, "Text", "")});
            this.xrlblUsuario.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.xrlblUsuario.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrlblUsuario.Name = "xrlblUsuario";
            this.xrlblUsuario.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblUsuario.SizeF = new System.Drawing.SizeF(602F, 23F);
            this.xrlblUsuario.StylePriority.UseFont = false;
            this.xrlblUsuario.StylePriority.UseTextAlignment = false;
            this.xrlblUsuario.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Usuario
            // 
            this.Usuario.Description = "Usuario que genera el reporte.";
            this.Usuario.Name = "Usuario";
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.Title.ForeColor = System.Drawing.Color.Maroon;
            this.Title.Name = "Title";
            // 
            // FieldCaption
            // 
            this.FieldCaption.BackColor = System.Drawing.Color.Transparent;
            this.FieldCaption.BorderColor = System.Drawing.Color.Black;
            this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.FieldCaption.BorderWidth = 1F;
            this.FieldCaption.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.FieldCaption.ForeColor = System.Drawing.Color.Maroon;
            this.FieldCaption.Name = "FieldCaption";
            // 
            // PageInfo
            // 
            this.PageInfo.BackColor = System.Drawing.Color.Transparent;
            this.PageInfo.BorderColor = System.Drawing.Color.Black;
            this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageInfo.BorderWidth = 1F;
            this.PageInfo.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.Color.Black;
            this.PageInfo.Name = "PageInfo";
            // 
            // DataField
            // 
            this.DataField.BackColor = System.Drawing.Color.Transparent;
            this.DataField.BorderColor = System.Drawing.Color.Black;
            this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataField.BorderWidth = 1F;
            this.DataField.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.DataField.ForeColor = System.Drawing.Color.Black;
            this.DataField.Name = "DataField";
            this.DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(60.83342F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(136.4583F, 39.41665F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.xrPictureBox1.Visible = false;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(272.0417F, 0F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(475.9583F, 23F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "REFERENCIAS BANCARIAS";
            // 
            // xrLabel22
            // 
            this.xrLabel22.CanShrink = true;
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(272.0418F, 48.83334F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(111.4583F, 16F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "Fecha de emisión:";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo3
            // 
            this.xrPageInfo3.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo3.Format = "{0:dddd, dd\' de \'MMMM\' de \'yyyy hh:mm tt}";
            this.xrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(383.5001F, 48.83334F);
            this.xrPageInfo3.Name = "xrPageInfo3";
            this.xrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo3.SizeF = new System.Drawing.SizeF(364.4999F, 16F);
            this.xrPageInfo3.StylePriority.UseFont = false;
            this.xrPageInfo3.StylePriority.UseTextAlignment = false;
            this.xrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrlblFiltrosAdicionales
            // 
            this.xrlblFiltrosAdicionales.CanShrink = true;
            this.xrlblFiltrosAdicionales.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.FiltrosReporte, "Text", "")});
            this.xrlblFiltrosAdicionales.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrlblFiltrosAdicionales.LocationFloat = new DevExpress.Utils.PointFloat(272.0418F, 23.00002F);
            this.xrlblFiltrosAdicionales.Multiline = true;
            this.xrlblFiltrosAdicionales.Name = "xrlblFiltrosAdicionales";
            this.xrlblFiltrosAdicionales.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblFiltrosAdicionales.SizeF = new System.Drawing.SizeF(475.9582F, 25.83334F);
            this.xrlblFiltrosAdicionales.StylePriority.UseFont = false;
            this.xrlblFiltrosAdicionales.StylePriority.UseTextAlignment = false;
            this.xrlblFiltrosAdicionales.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // FiltrosReporte
            // 
            this.FiltrosReporte.Description = "Filtros que selecciona el usuario para mostrar el reporte.";
            this.FiltrosReporte.Name = "FiltrosReporte";
            // 
            // xrLabel3
            // 
            this.xrLabel3.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.xrLabel3.Font = new System.Drawing.Font("Arial Narrow", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 41.83334F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(272.0418F, 23.00001F);
            this.xrLabel3.StylePriority.UseBorderColor = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseForeColor = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "DISTRIBUIDORA DE AUTOPARTES PESCADOR S.A. DE C.V.";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrLabel3.Visible = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrtblEncabezado,
            this.xrLine1,
            this.xrlblVendedor,
            this.xrVendedor});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("CVE_VENDEDOR", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader1.HeightF = 92.08334F;
            this.GroupHeader1.KeepTogether = true;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.RepeatEveryPage = true;
            // 
            // xrtblEncabezado
            // 
            this.xrtblEncabezado.BackColor = System.Drawing.Color.DarkBlue;
            this.xrtblEncabezado.BorderColor = System.Drawing.Color.White;
            this.xrtblEncabezado.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrtblEncabezado.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrtblEncabezado.ForeColor = System.Drawing.Color.White;
            this.xrtblEncabezado.LocationFloat = new DevExpress.Utils.PointFloat(0F, 69.08334F);
            this.xrtblEncabezado.Name = "xrtblEncabezado";
            this.xrtblEncabezado.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrtblEncabezado.SizeF = new System.Drawing.SizeF(748F, 23F);
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
            this.xrtcClave,
            this.xrtcRazonSocial,
            this.xrtcStatus,
            this.xrtcReferencia});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrtcClave
            // 
            this.xrtcClave.Name = "xrtcClave";
            this.xrtcClave.Text = "CLAVE";
            this.xrtcClave.Weight = 0.9999996785481895D;
            // 
            // xrtcRazonSocial
            // 
            this.xrtcRazonSocial.Name = "xrtcRazonSocial";
            this.xrtcRazonSocial.Text = "CLIENTE";
            this.xrtcRazonSocial.Weight = 4.54166678297254D;
            // 
            // xrtcStatus
            // 
            this.xrtcStatus.Name = "xrtcStatus";
            this.xrtcStatus.Text = "ESTATUS";
            this.xrtcStatus.Weight = 0.89999996948242245D;
            // 
            // xrtcReferencia
            // 
            this.xrtcReferencia.Name = "xrtcReferencia";
            this.xrtcReferencia.Text = "REFERENCIA";
            this.xrtcReferencia.Weight = 1.0383332646348704D;
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Gray;
            this.xrLine1.LineWidth = 2;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(747.9999F, 23F);
            this.xrLine1.StylePriority.UseBackColor = false;
            this.xrLine1.StylePriority.UseBorderColor = false;
            this.xrLine1.StylePriority.UseForeColor = false;
            // 
            // xrlblVendedor
            // 
            this.xrlblVendedor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrlblVendedor.LocationFloat = new DevExpress.Utils.PointFloat(0F, 34.2083F);
            this.xrlblVendedor.Name = "xrlblVendedor";
            this.xrlblVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblVendedor.SizeF = new System.Drawing.SizeF(100F, 19F);
            this.xrlblVendedor.StylePriority.UseFont = false;
            this.xrlblVendedor.StylePriority.UseTextAlignment = false;
            this.xrlblVendedor.Text = "VENDEDOR";
            this.xrlblVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrVendedor
            // 
            this.xrVendedor.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Query.cfVendedor")});
            this.xrVendedor.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrVendedor.LocationFloat = new DevExpress.Utils.PointFloat(100F, 34.2083F);
            this.xrVendedor.Name = "xrVendedor";
            this.xrVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrVendedor.SizeF = new System.Drawing.SizeF(647.9998F, 19F);
            this.xrVendedor.StylePriority.UseFont = false;
            this.xrVendedor.StylePriority.UseTextAlignment = false;
            this.xrVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // cfVendedor
            // 
            this.cfVendedor.DataMember = "Query";
            this.cfVendedor.Expression = "Concat([CVE_VENDEDOR], \' \', [VENDEDOR]  )";
            this.cfVendedor.Name = "cfVendedor";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1,
            this.xrlblFiltrosAdicionales,
            this.xrPageInfo3,
            this.xrLabel22,
            this.xrLabel19,
            this.xrLabel3});
            this.PageHeader.HeightF = 64.83334F;
            this.PageHeader.Name = "PageHeader";
            // 
            // cfCve_Cliente
            // 
            this.cfCve_Cliente.DataMember = "Query";
            this.cfCve_Cliente.Expression = "PadLeft([CLAVE],10 , \'0\')";
            this.cfCve_Cliente.Name = "cfCve_Cliente";
            // 
            // ReferenciaBanco
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.pageFooterBand1,
            this.GroupHeader1,
            this.PageHeader});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.cfVendedor,
            this.cfCve_Cliente});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.ReferenciaBancoDataSource});
            this.DataMember = "Query";
            this.DataSource = this.ReferenciaBancoDataSource;
            this.DisplayName = "Referencias Bancarias de Clientes";
            this.ExportOptions.Pdf.DocumentOptions.Application = "REPORTES CREDITO";
            this.ExportOptions.Pdf.DocumentOptions.Author = "DISTRIBUIDORA DE AUTOPARTES PESCADOR S.A. DE C.V.";
            this.ExportOptions.Pdf.DocumentOptions.Title = "REFERENCIAS BANCARIAS";
            this.ExportOptions.Xlsx.DocumentOptions.Application = "REPORTES CREDITO";
            this.ExportOptions.Xlsx.DocumentOptions.Author = "DISTRIBUIDORA DE AUTOPARTES PESCADOR S.A. DE C.V.";
            this.ExportOptions.Xlsx.DocumentOptions.Category = "CREDITO";
            this.ExportOptions.Xlsx.DocumentOptions.Comments = "Muestra las referencias bancarias de clientes por sucursal y vendedor.";
            this.ExportOptions.Xlsx.DocumentOptions.Company = "DAPESA";
            this.ExportOptions.Xlsx.DocumentOptions.Title = "REFERENCIAS BANCARIAS";
            this.ExportOptions.Xlsx.SheetName = "REFERENCIAS BANCARIAS";
            this.Margins = new System.Drawing.Printing.Margins(60, 42, 40, 40);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.FiltrosReporte,
            this.Usuario});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.Version = "15.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrtblDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrtblEncabezado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.Sql.SqlDataSource ReferenciaBancoDataSource;
        private DevExpress.XtraReports.UI.PageFooterBand pageFooterBand1;
        private DevExpress.XtraReports.UI.XRControlStyle Title;
        private DevExpress.XtraReports.UI.XRControlStyle FieldCaption;
        private DevExpress.XtraReports.UI.XRControlStyle PageInfo;
        private DevExpress.XtraReports.UI.XRControlStyle DataField;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo3;
        private DevExpress.XtraReports.UI.XRLabel xrlblFiltrosAdicionales;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrlblVendedor;
        private DevExpress.XtraReports.UI.XRLabel xrVendedor;
        private DevExpress.XtraReports.UI.XRTable xrtblEncabezado;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrtcClave;
        private DevExpress.XtraReports.UI.XRTableCell xrtcRazonSocial;
        private DevExpress.XtraReports.UI.XRTableCell xrtcStatus;
        private DevExpress.XtraReports.UI.XRTableCell xrtcReferencia;
        private DevExpress.XtraReports.UI.XRTable xrtblDatos;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrClave;
        private DevExpress.XtraReports.UI.XRTableCell xrCliente;
        private DevExpress.XtraReports.UI.XRTableCell xrStatus;
        private DevExpress.XtraReports.UI.XRTableCell xrReferencia;
        private DevExpress.XtraReports.UI.XRPageInfo xrpiPagina;
        private DevExpress.XtraReports.UI.XRLabel xrlblUsuario;
        private DevExpress.XtraReports.UI.CalculatedField cfVendedor;
        private DevExpress.XtraReports.Parameters.Parameter FiltrosReporte;
        private DevExpress.XtraReports.Parameters.Parameter Usuario;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.CalculatedField cfCve_Cliente;
    }
}
