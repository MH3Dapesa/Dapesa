<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Analisis.aspx.cs" Inherits="Dapesa.Comun.Informes.IU.Reporteador.Analisis" MasterPageFile="~/Site.Master" EnableEventValidation="false" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="asp" %>
<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="asp" %>--%>
<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A" Namespace="Microsoft.Reporting.WebForms" TagPrefix="asp" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="cContenido" ContentPlaceHolderID="cphContenidoPrincipal" runat="server">


    <div>
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
             </ContentTemplate>
        </asp:UpdatePanel>--%>

        <asp:Panel ID="pnlParametros" runat="server" DefaultButton="btnGenerar">
            
            <table border="0" style="border-collapse: separate; border-spacing: 1px;">
                <tr>
                    <td>
                        <asp:Label ID="lblSucursales" runat="server" AccessKey="S" AssociatedControlID="ddlSucursales" Text="<u><b>S</b></u>ucursal(es):" />
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlSucursales" runat="server" Width="370px" Height="20px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblVendedores" runat="server" AccessKey="V" AssociatedControlID="ddlVendedores" Text="<u><b>V</b></u>endedor(es):" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlVendedores" runat="server" Width="370px" Height="20px" />
                    </td>
                    <td style="padding-left: 25px;"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMarcas" runat="server" AccessKey="M" AssociatedControlID="ddlMarcas" Text="<u><b>M</b></u>arca(s):" />
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlMarcas" runat="server" Width="370px" Height="20px" DataTextField="DESCRIPCION" DataValueField="CLAVE" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:CheckBox ID="ckDecremento" runat="server" Checked="true" Text="Con Decremento" />
                        <asp:CheckBox ID="ckClientesEliminados" runat="server" Checked="false" Text="Mostrar Clientes Eliminados" />
                        <span style="margin-left: 80px">
                            <asp:Button ID="btnGenerar" runat="server" Text="Generar" BackColor="#F5F5F5" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="22px" OnClick="btnGenerar_Click" />
                        </span>
                        <span style="margin-left: 120px">
                             <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" BackColor="#F5F5F5" Visible="false" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="22px" OnClick="btnImprimir_Click"/>                           
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator ID="rfvSucursal" runat="server" ControlToValidate="ddlSucursales" ErrorMessage="Debe seleccionar una sucursal.<br />" ToolTip="Debe seleccionar una sucursal.<br />" ForeColor="Red" Font-Size="8pt" />

                        <asp:UpdatePanel ID="UpMensajes" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red" Font-Size="8pt" Visible="false"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        

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
                ID="ccdVendedores"
                runat="server"
                TargetControlID="ddlVendedores"
                ParentControlID="ddlSucursales"
                Category="CLAVE"
                PromptText="[SELECCIONAR]"
                ServicePath="~/DropDownAsincrono.asmx"
                SelectedValue="-1"
                ServiceMethod="ObtenerVendedores" />
        </asp:Panel>

        <asp:UpdatePanel ID="upPanelVenta" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="margin: 0; padding: 0;" id="ReportDiv">
                    <table border="0" style="width: 97%; height: 72%; position: absolute; padding-top: 2px;">
                        <tr>
                            <td>
                                <asp:ReportViewer ID="rvVenta" runat="server" Width="100%" Height="100%" ProcessingMode="Local" ShowExportControls="false" ShowPrintButton="true" ShowRefreshButton="false" OnDrillthrough="rvVenta_Drillthrough" />
                                        
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:Button ID="btnDummy" runat="server" Style="display: none;" />
                <asp:Panel ID="pnlMotivosInac" runat="server" Style="display: none">
                    <div style="background-color: #FFFFFF; border-width: 1px; border-color: #F5F5F5; border-style: solid; width: 600px; text-align: left; vertical-align: top; padding: 10px;">
                        <table border="0" style="width: 100%">
                            <tr>
                                <td style="text-align: center; font-weight: bold; width: 100%;">Motivos de inactivaci&oacute;n</td>
                                <td style="text-align: right;">
                                    <asp:ImageButton ID="btnCerrar" runat="server" ImageUrl="~/Img/cerrar.png" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table border="1" style="border-collapse: collapse; border-spacing: 0px; width: 100%; font-size: 8pt;">
                                        <tr>
                                            <td style="width: 70px;">Cliente:</td>
                                            <td>
                                                <asp:Label ID="lblCliente" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Motivos:</td>
                                            <td>
                                                <asp:Label ID="lblMotivosInac" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Fecha:</td>
                                            <td>
                                                <asp:Label ID="lblFechaInac" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <asp:ModalPopupExtender ID="mpeMotivosInac" runat="server" TargetControlID="btnDummy" PopupControlID="pnlMotivosInac" CancelControlID="btnCerrar" BackgroundCssClass="updateProgressBackground" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnGenerar" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnImprimir" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSalir" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
