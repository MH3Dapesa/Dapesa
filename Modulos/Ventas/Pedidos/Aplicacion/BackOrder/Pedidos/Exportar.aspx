<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exportar.aspx.cs" Inherits="Ventas.Pedidos.BackOrder.UI.Pedidos.Exportar" EnableEventValidation="false" %>

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
        <asp:UpdatePanel ID="upPanelContenido" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="divresultado" style="color: red; margin-top: 30px; font-weight: bold;">
                    <asp:Label ID="lblResultadoConsulta" runat="server"></asp:Label>
                </div>
                <asp:UpdatePanel ID="upPanelMostrar" runat="server">
                    <ContentTemplate>
                        <div style="margin: 0; padding: 0;">
                            <table border="0" style="width: 97%; position: absolute; padding-top: 2px;">
                                <tr>
                                    <td>
                                        <dx:ASPxDocumentViewer ID="xrInforme" runat="server" >
                                            <ToolbarItems>
                                                <dx:ReportToolbarButton ItemKind="PrintReport" />
                                                <dx:ReportToolbarButton ItemKind="PrintPage" />
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
                                                <dx:ReportToolbarButton ItemKind="SaveToDisk" />
                                                <dx:ReportToolbarComboBox ItemKind="SaveFormat" Width="130">
                                                    <Elements>
                                                        <dx:ListElement Value="pdf" Text="Pdf" />
                                                    </Elements>
                                                </dx:ReportToolbarComboBox>
                                                <dx:ReportToolbarSeparator />
                                                <dx:ReportToolbarButton ImageUrl="Img/xls.png" ToolTip="Exportar a Excel" Name="rtbExportarExcel" />
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
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>