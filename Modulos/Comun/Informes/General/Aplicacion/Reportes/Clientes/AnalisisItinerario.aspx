<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnalisisItinerario.aspx.cs" Inherits="Dapesa.Comun.Informes.General.IU.Reportes.Clientes.AnalisisItinerario" EnableEventValidation="false" %>

<%@ Register Assembly="DevExpress.XtraReports.v16.2.Web, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="cEncabezado" ContentPlaceHolderID="cphEncabezado" runat="server">
    <style>
        div#ctl00_cphContenidoPrincipal_rvPedidos_AsyncWait {
            background-color: transparent;
            opacity: 0.0;
            position: absolute;
            display: none;
            filter: alpha(opacity=0);
        }
    </style>
</asp:Content>
<asp:Content ID="cContenido" ContentPlaceHolderID="cphContenidoPrincipal" runat="server">
    <div>
        <br />
        <asp:Panel ID="pnlParametros" runat="server" DefaultButton="btnGenerar">
            <table style="border-spacing: 0 3px; border-collapse: separate;">
                <tr>
                    <td><u><b>F</b></u>echa inicial:</td>
                    <td>
                        <table>
                            <tr>
                                <td style="white-space: nowrap;" colspan="2">
                                    <asp:TextBox ID="txtFechaInicio" runat="server" Width="175px" Enabled="False" CssClass="upperText" />
                                    <asp:ImageButton ID="btnFechaInicio" runat="server" ImageUrl="~/Img/calendario.png" />
                                    <asp:CalendarExtender ID="ceFechaInicio" runat="server"  PopupButtonID="btnFechaInicio" TargetControlID="txtFechaInicio" Format="dd/MM/yyyy" PopupPosition="BottomLeft" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="margin-top: 10px;">
                    <td style="width: 90px">
                        <asp:Label ID="lblSucursales" runat="server" AccessKey="S" AssociatedControlID="ddlSucursales" Text="<u><b>S</b></u>ucursal(es):" />
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlSucursales" runat="server" Width="280px" Height="20px" />
                        <asp:RequiredFieldValidator ID="rfvSucursal" runat="server" ControlToValidate="ddlSucursales" ErrorMessage="*Debe seleccionar una sucursal.<br />" ToolTip="Debe seleccionar una sucursal.<br />" ForeColor="Red" Font-Size="8pt" />
                    </td>
                    <td rowspan="3">
                        <asp:UpdatePanel ID="UpTotalesTLMK" UpdateMode="Conditional" runat="server" >
                            <ContentTemplate>
                                <asp:GridView ID="gvTotalesTLMK" runat="server" OnRowDataBound="gvTotalesTLMK_RowDataBound"> 
                                    <HeaderStyle BackColor="#C0C0C0" Font-Bold="true" /> 
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTelemarketings" runat="server" AccessKey="T" AssociatedControlID="ddlTelemarketings" Text="<u><b>T</b></u>elemarketing(s):" />
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlTelemarketings" runat="server" Width="280px" Height="20px" />
                        <asp:RequiredFieldValidator ID="rfvTelemarketing" runat="server" ControlToValidate="ddlTelemarketings" ErrorMessage="*Debe seleccionar un telemarketing.<br />" ToolTip="Debe seleccionar un telemarketing.<br />" ForeColor="Red" Font-Size="8pt" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnGenerar" runat="server" OnClick="btnGenerar_Click" Text="Generar" />
                    </td>
                </tr>
            </table>
            <asp:CascadingDropDown
                ID="cddSucursales"
                runat="server"
                TargetControlID="ddlSucursales"
                Category="CLAVE"
                PromptText="[SELECCIONAR]"
                ServicePath="~/DropDownAsincrono.asmx"
                ServiceMethod="ObtenerSucursales" />
            <asp:CascadingDropDown 
				ID="ccdTelemarketings"
				runat="server"
				TargetControlID="ddlTelemarketings"
				ParentControlID="ddlSucursales"
				Category="CLAVE"
				PromptText="&nbsp;&nbsp;&nbsp;&nbsp;[SELECCIONAR]"
				ServicePath="~/DropDownAsincrono.asmx"
				ServiceMethod="ObtenerTelemarketings" />
        </asp:Panel>
        <script>
            $("#<%= txtFechaInicio.ClientID %>").val((new Date()).localeFormat("dd/MM/yyyy"));

            function ValidarEspacio(e, campo) {
                key = e.keyCode ? e.keyCode : e.which;
                if (key == 32) { return false; }
            }
        </script>

        <asp:UpdatePanel ID="upPanelContenido" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:UpdatePanel ID="upPanelMostrar" runat="server">
                    <ContentTemplate>
                        <br />
                        <div style="margin: 0; padding: 0;">
                            <table border="0" style="width: 97%; position: absolute; padding-top: 2px;">
                                <tr>
                                    <td>
                                        <dx:ASPxDocumentViewer ID="xrInforme" runat="server" OnCacheReportDocument="xrInforme_CacheReportDocument" OnRestoreReportDocumentFromCache="xrInforme_RestoreReportDocumentFromCache">
                                            <ToolbarItems>
                                                <dx:ReportToolbarSeparator />
                                                <dx:ReportToolbarButton ItemKind="FirstPage" />
                                                <dx:ReportToolbarButton ItemKind="PreviousPage" />
                                                <dx:ReportToolbarLabel ItemKind="Custom" Text="Page" />
                                                <dx:ReportToolbarComboBox ItemKind="PageNumber" Width="60" />
                                                <dx:ReportToolbarLabel ItemKind="Custom" Text="of" />
                                                <dx:ReportToolbarTextBox IsReadOnly="True" ItemKind="PageCount" />
                                                <dx:ReportToolbarButton ItemKind="NextPage" />
                                                <dx:ReportToolbarButton ItemKind="LastPage" />
                                                <dx:ReportToolbarSeparator />
                                                <dx:ReportToolbarSeparator />
                                                <dx:ReportToolbarComboBox ItemKind="SaveFormat" Width="100">
                                                    <Elements>
                                                        <dx:ListElement Value="pdf" Text="Pdf" />
                                                        <dx:ListElement Value="xlsx" Text="Excel" />
                                                    </Elements>
                                                </dx:ReportToolbarComboBox>
                                            </ToolbarItems>
                                        </dx:ASPxDocumentViewer>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSalir" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnGenerar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
