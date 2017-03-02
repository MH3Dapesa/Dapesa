<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Clientes/AnalisisVentasVendedor.aspx.cs" Inherits="Dapesa.Comun.Informes.General.IU.Reportes.Clientes.AnalisisVentasVendedor" EnableEventValidation="false" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

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
        <br/>
        <asp:Panel ID="pnlParametros" runat="server" DefaultButton="btnGenerar">
            <table style="border-spacing:0 3px; border-collapse:separate">
                <tr>
                    <td><u><b>F</b></u>echa inicial:</td>
                    <td>
                        <table>
                            <tr>
                                <td style="white-space: nowrap;" colspan="2">
                                    <asp:TextBox ID="txtFechaInicio" runat="server" Width="175px" Enabled="False" CssClass="upperText" />
                                    <asp:ImageButton ID="btnFechaInicio" runat="server" ImageUrl="~/Img/calendario.png" />
                                    <asp:CalendarExtender ID="ceFechaInicio" runat="server" PopupButtonID="btnFechaInicio" TargetControlID="txtFechaInicio" Format="dd/MM/yyyy" PopupPosition="BottomLeft"  />
                                </td>
                                <td>&nbsp;<u><b>F</b></u>echa final:</td>
                                <td style="white-space: nowrap;">
                                    <asp:TextBox ID="txtFechaFin" runat="server" Width="175px" Enabled="false" CssClass="upperText"  />
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
                <tr style="margin-top:10px;">
                    <td style="width:90px">
                        <asp:Label ID="lblSucursales" runat="server" AccessKey="S" AssociatedControlID="ddlSucursales" Text="<u><b>S</b></u>ucursal(es):" />
                    </td>
                    <td colspan="2" >
                        <asp:DropDownList ID="ddlSucursales" runat="server" Width="370px" Height="20px"  />
                        <%--<asp:RequiredFieldValidator ID="rfvSucursal" runat="server" ControlToValidate="ddlSucursales" ErrorMessage="*Debe seleccionar una sucursal.<br />" ToolTip="Debe seleccionar una sucursal.<br />" ForeColor="Red" Font-Size="8pt" />--%>
                    </td>
                </tr>
                <tr>
                    <td style="width:90px;">
                        <asp:Label ID="lblVendedores" runat="server" AccessKey="V" AssociatedControlID="ddlVendedores" Text="<u><b>V</b></u>endedor(es):" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlVendedores" runat="server" Width="370px" Height="20px" />
                    </td>
                    <td style="padding-left: 25px;"></td>
                </tr>      
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <div id="btnMasFiltros" onclick="MasFiltros()" style="width:85px;margin:0px auto;text-align:center;background-color:#3872c3;font-weight:bold;cursor:pointer;color:white;">Mas Filtros</div>
                    </td>                    
                </tr>
            </table>
            <table class="FiltrosOpcionales" style="border-spacing:0 3px; border-collapse:separate">
                <tr>
                    <td style="width:90px;">
                        <asp:Label ID="lblClaveCliente" runat="server" Text="<u><b>C</b></u>lave cliente:"/>
                    </td>
                    <td>
                        <asp:TextBox ID="txtClaveCliente" runat="server" CssClass="upperText" Enabled="false" Width="365px" />
                        <asp:RegularExpressionValidator ID="revClaveCliente" runat="server"
                                ControlToValidate="txtClaveCliente" ErrorMessage="*Ingrese valores alfanumericos"
                                ForeColor="Red"
                                ValidationExpression="^([a-zA-Z0-9]{1,20})$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <asp:Panel ID="pnlMasFiltros" runat="server" >
                        <td>
                            <asp:Label ID="lblMarca" runat="server" Text="<u><b>F</b></u>iltrar Por:" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMarcas" runat="server" Width="105px" Height="20px" ToolTip="Marca"></asp:DropDownList>
                            <asp:DropDownList ID="ddlLineas" runat="server" Width="110px" Height="20px" ToolTip="Línea"></asp:DropDownList>                           
                            <asp:TextBox ID="txtArticulo" runat="server" Width="145"/>
                        </td>
                    </asp:Panel>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMonto" runat="server" Text = "<u><b>M</b></u>onto:" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMonto" runat="server" Width="50">
                            <asp:ListItem Value="" Text="[Seleccione]" Selected="True" />
                            <asp:ListItem Value="1" Text="<="  />
                            <asp:ListItem Value="2" Text=">=" />
                        </asp:DropDownList>
                        <asp:TextBox ID="txtMonto" runat="server" />
                        <asp:FilteredTextBoxExtender ID="ftbxMonto" runat="server" FilterType="Numbers" TargetControlID="txtMonto"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPiezas" runat="server" Text = "<u><b>P</b></u>iezas:" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPiezas" runat="server" Width="50">
                            <asp:ListItem Value="" Text="[Seleccione]" Selected="True" />
                            <asp:ListItem Value="1" Text="<="  />
                            <asp:ListItem Value="2" Text=">=" />
                        </asp:DropDownList>
                        <asp:TextBox ID="txtPiezas" runat="server" />
                        <asp:FilteredTextBoxExtender ID="ftbxPiezas" runat="server" FilterType="Numbers" TargetControlID="txtPiezas"/>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnGenerar" runat="server" OnClick="btnGenerar_Click" Text="Generar"/>
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
            <asp:CascadingDropDown
                    ID="cddMarcas"
                    runat="server"
                    TargetControlID="ddlMarcas"
                    Category="CLAVE"
                    PromptText="[MARCA]"
                    ServicePath="~/DropDownAsincrono.asmx"
                    ServiceMethod="ObtenerMarcas" />
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
            $("#<%= txtFechaInicio.ClientID %>").val((new Date()).localeFormat("dd/MM/yyyy"));
            $("#<%= txtFechaFin.ClientID %>").val((new Date()).localeFormat("dd/MM/yyyy"));

            function limpiarMonto() {
                if ($("#<%=ddlMonto.ClientID %>").val() == "") {
                    $("#<%=txtMonto.ClientID %>").val("");
                };
            }
            function limpiarPiezas() {
                if ($("#<%=ddlPiezas.ClientID %>").val() == "") {
                    $("#<%=txtPiezas.ClientID %>").val("");
                };
            }
            function SeleccionarSucursal() {
                if ($("#<%=ddlSucursales.ClientID %>").val() == "") {
                    $("#<%=txtClaveCliente.ClientID %>").attr("disabled", true);
                }
                else { 
                    $("#<%=txtClaveCliente.ClientID %>").attr("disabled", false);
                }
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
                                        <asp:Label ID="lblError" runat="server" Font-Size="20px" ForeColor="Red" Text="" Visible="false"></asp:Label>
                                        <dx:ASPxDocumentViewer ID="xrInforme" runat="server" ReportTypeName="InformeVenta"  OnCacheReportDocument="xrInforme_CacheReportDocument"  OnRestoreReportDocumentFromCache="xrInforme_RestoreReportDocumentFromCache">
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
                                                <dx:ReportToolbarButton ItemKind ="SaveToDisk" />
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

