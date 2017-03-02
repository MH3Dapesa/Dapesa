<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BackOrderPedidos.aspx.cs" Inherits="Dapesa.Comun.Informes.General.IU.Reportes.Clientes.BackOrderPedidos" EnableEventValidation="false" %>

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
        <asp:Panel ID="pnlParametros" runat="server" DefaultButton="btnVistaPrevia">
            <table style="border-spacing: 0 3px; border-collapse: separate">
                <tr>
                    <td><u><b>F</b></u>echa inicial:</td>
                    <td>
                        <table>
                            <tr>
                                <td style="white-space: nowrap;" colspan="2">
                                    <asp:TextBox ID="txtFechaInicio" runat="server" Width="175px" Enabled="False" CssClass="upperText" />
                                    <asp:ImageButton ID="btnFechaInicio" runat="server" ImageUrl="~/Img/calendario.png" />
                                    <asp:CalendarExtender ID="ceFechaInicio" runat="server" PopupButtonID="btnFechaInicio" TargetControlID="txtFechaInicio" Format="dd/MM/yyyy" PopupPosition="BottomLeft" />
                                </td>
                                <td>&nbsp;<u><b>F</b></u>echa final:</td>
                                <td style="white-space: nowrap;">
                                    <asp:TextBox ID="txtFechaFin" runat="server" Width="175px" Enabled="false" CssClass="upperText" />
                                    <asp:ImageButton ID="btnFechaFin" runat="server" ImageUrl="~/Img/calendario.png" />
                                    <asp:CalendarExtender ID="ceFechaFin" runat="server" PopupButtonID="btnFechaFin" TargetControlID="txtFechaFin" Format="dd/MM/yyyy" PopupPosition="BottomLeft" />
                                </td>

                                <td style="padding-left: 10px; color: red; font-size: 8pt;" colspan="3">
                                    <asp:CompareValidator ID="cvFechas" runat="server" ErrorMessage="La fecha final, debe ser mayor o igual a la fecha de inicio.<br />" Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtFechaInicio" ControlToValidate="txtFechaFin" />
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

                        <asp:DropDownList ID="ddlSucursales" runat="server" Width="370px" Height="20px" />
                        <asp:RequiredFieldValidator ID="rfvSucursal" runat="server" ControlToValidate="ddlSucursales" ErrorMessage="*Debe seleccionar una sucursal.<br />" ToolTip="Debe seleccionar una sucursal.<br />" ForeColor="Red" Font-Size="8pt" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <div id="btnMasFiltros" onclick="MasFiltros()" style="width: 85px; margin: 0px auto; text-align: center; background-color: #3872c3; font-weight: bold; cursor: pointer; color: white;">Mas Filtros</div>
                    </td>
                </tr>
            </table>
            <table class="FiltrosOpcionales" style="border-spacing: 0 3px; border-collapse: separate">
                <tr>
                    <td style="width: 90px;">
                        <asp:Label ID="lblVendedores" runat="server" AccessKey="V" AssociatedControlID="ddlVendedores" Text="<u><b>V</b></u>endedor(es):" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlVendedores" runat="server" Width="370px" Height="20px" />
                    </td>
                    <td style="padding-left: 25px;"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblClaveCliente" runat="server" Text="<u><b>C</b></u>lave cliente:" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtClaveCliente" runat="server" CssClass="upperText" Width="365px" />
                        <asp:RegularExpressionValidator ID="revClaveCliente" runat="server"
                            ControlToValidate="txtClaveCliente" ErrorMessage="*Ingrese valores alfanumericos"
                            ForeColor="Red"
                            ValidationExpression="^([a-zA-Z0-9]{1,20})$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPedido" runat="server" Text="<u><b>P</b></u>edido:" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtFolioPedido" runat="server" CssClass="upperText" Width="100px" />
                        <asp:TextBox ID="txtNumeroPedido" runat="server" CssClass="upperText" Width="260px" />
                        <asp:RegularExpressionValidator ID="revFolioPedido" runat="server"
                            ControlToValidate="txtFolioPedido" ErrorMessage="*Ingrese valores de texto"
                            ForeColor="Red"
                            ValidationExpression="^([a-zA-Z]{1,20})$">
                        </asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="revNumeroPedido" runat="server"
                            ControlToValidate="txtNumeroPedido" ErrorMessage="*Ingrese Valores num&eacute;ricos"
                            ForeColor="Red"
                            ValidationExpression="^([0-9]{1,20})$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <asp:Panel ID="pnlMasFiltros" runat="server">
                        <td>
                            <asp:Label ID="lblMarca" runat="server" Text="<u><b>F</b></u>iltrar Por:" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMarcas" runat="server" Width="105px" Height="20px" ToolTip="Marca"></asp:DropDownList>
                            <asp:DropDownList ID="ddlLineas" runat="server" Width="110px" Height="20px" ToolTip="Línea"></asp:DropDownList>
                            <asp:TextBox ID="txtArticulo" runat="server" Width="145" />
                        </td>
                    </asp:Panel>
                </tr>
            </table>
            <table style="border-spacing: 0 3px; border-collapse: separate">
                <tr>
                    <td style="width: 90px;">
                        <asp:Label ID="lblMostrarExistencia" runat="server" Text="<u><b>M</b></u>ostrar articulo:" />
                    </td>
                    <td>
                        <asp:RadioButton ID="rbTodosArticulos" runat="server" Text="Todos." GroupName="ArticulosMostrar" Checked="true" />
                        <asp:RadioButton ID="rbaArticulosConExistencia" runat="server" Text="Con existencia." GroupName="ArticulosMostrar" />
                        <asp:RadioButton ID="rbSinArticulosSinExistencia" runat="server" Text="Sin existencia." GroupName="ArticulosMostrar" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnVistaPrevia" runat="server" OnClick="btnVistaPrevia_Click" Text="Generar" />
                        <asp:ImageButton ID="btnExportarExcel" runat="server" ImageUrl="~/Img/xls.png" AlternateText="Exportar a Excel"  OnClick="btnExportarExcel_Click" Visible="false" />
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
                ID="cddMarcas"
                runat="server"
                TargetControlID="ddlMarcas"
                Category="CLAVE"
                PromptText="[MARCA]"
                ServicePath="~/DropDownAsincrono.asmx"
                ServiceMethod="ObtenerMarcas" />
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
            <asp:CascadingDropDown
                ID="CddLineas"
                runat="server"
                TargetControlID="ddlLineas"
                ParentControlID="ddlMarcas"
                Category="CLAVE"
                PromptText="[LINEA]"
                ServicePath="~/DropDownAsincrono.asmx"
                SelectedValue="-1"
                ServiceMethod="ObtenerLineas" />
        </asp:Panel>
        <script>
            function ValidarEspacio(e, campo) {
                key = e.keyCode ? e.keyCode : e.which;
                if (key == 32) { return false; }
            }
            function MasFiltros() {
                var Encabezado = document.getElementById("btnMasFiltros").innerHTML;
                if (Encabezado == "Mas Filtros") {
                    var x = document.getElementsByClassName("FiltrosOpcionales");
                    var i;
                    for (i = 0; i < x.length; i++) {
                        x[i].style.display = "block";
                    }
                    document.getElementById("btnMasFiltros").innerHTML = "Menos Filtros";
                    document.getElementById("btnMasFiltros").style.backgroundColor = "#c38938";
                }
                else {
                    var x = document.getElementsByClassName("FiltrosOpcionales");
                    var i;
                    for (i = 0; i < x.length; i++) {
                        x[i].style.display = "none";
                    }
                    document.getElementById("btnMasFiltros").innerHTML = "Mas Filtros";
                    document.getElementById("btnMasFiltros").style.backgroundColor = "#3872c3";
                }
            }
        </script>

        <asp:UpdatePanel ID="upPanelContenido" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="divresultado" style="color: red; margin-top: 30px; font-weight: bold;">
                </div>
                <asp:UpdatePanel ID="upPanelMostrar" runat="server">
                    <ContentTemplate>
                        <div style="margin: 0; padding: 0;">
                            <table border="0" style="width: 97%; position: absolute; padding-top: 2px;">
                                <tr>
                                    <td>
                                        <dx:ASPxDocumentViewer ID="xrInforme" runat="server" OnCacheReportDocument="xrInforme_CacheReportDocument"  OnRestoreReportDocumentFromCache="xrInforme_RestoreReportDocumentFromCache" >
                                            <ToolbarItems>
                                                <dx:ReportToolbarButton ItemKind="FirstPage" />
                                                <dx:ReportToolbarButton ItemKind="PreviousPage" />
                                                <dx:ReportToolbarLabel ItemKind="Custom" Text="Página" />
                                                <dx:ReportToolbarComboBox ItemKind="PageNumber" Width="60" />
                                                <dx:ReportToolbarLabel ItemKind="Custom" Text="de" />
                                                <dx:ReportToolbarTextBox IsReadOnly="True" ItemKind="PageCount" />
                                                <dx:ReportToolbarButton ItemKind="NextPage" />
                                                <dx:ReportToolbarButton ItemKind="LastPage" />
                                                <dx:ReportToolbarSeparator />
                                                <dx:ReportToolbarComboBox ItemKind="SaveFormat" Width="130">
                                                    <Elements>
                                                        <dx:ListElement Value="pdf" Text="Pdf" />
                                                        <dx:ListElement Value="Xlsx" Text="Xlsx" />
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
                <asp:AsyncPostBackTrigger ControlID="btnVistaPrevia" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnExportarExcel" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
