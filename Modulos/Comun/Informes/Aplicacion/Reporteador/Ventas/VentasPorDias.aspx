<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VentasPorDias.aspx.cs" Inherits="Dapesa.Comun.Informes.IU.Reporteador.VentasPorDias" MasterPageFile="~/Site.Master" EnableEventValidation="false" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="cContenido" ContentPlaceHolderID="cphContenidoPrincipal" runat="server">
    <div>
        <asp:Panel ID="pnlParametros" runat="server" DefaultButton="btnGenerar">

            <table border="0" style="border-collapse: separate; border-spacing: 1px;">
                <tr>
                    <td style="width: 90px"></td>
                    <td style="width: 120px"></td>
                    <td style="width: 15px"></td>
                    <td style="width: 70px">
                        <%--<asp:Label runat="server" Text="Seleccione el rango de Fechas a Consultar."></asp:Label>--%>
                    </td>
                    <td style="width: 120px"></td>
                    <td style="width: 100px"></td>
                    <td style="width: 80px"></td>
                    <td style="width: 380px"></td>
                    <td></td>
                    <td style="width: 20px"></td>
                </tr>
                <tr>
                    <td style="white-space: nowrap;">Fecha inicial:</td>
                    <td style="white-space: nowrap;" colspan="1">
                        <asp:TextBox ID="txtFechaInicio" runat="server" Width="115px" Enabled="False" CssClass="upperText" />
                        <asp:ImageButton ID="btnFechaInicio" runat="server" ImageUrl="~/Img/calendario.png" CausesValidation="false" />
                        <asp:CalendarExtender ID="ceFechaInicio" runat="server" PopupButtonID="btnFechaInicio" TargetControlID="txtFechaInicio" Format="dd/MM/yyyy" PopupPosition="BottomLeft" />
                    </td>
                    <td></td>
                    <td style="white-space: nowrap;" colspan="1">Fecha final:</td>
                    <td style="white-space: nowrap;" colspan="1">
                        <asp:TextBox ID="txtFechaFin" runat="server" Width="115px" Enabled="false" CssClass="upperText" />
                        <asp:ImageButton ID="btnFechaFin" runat="server" ImageUrl="~/Img/calendario.png" CausesValidation="false" />
                        <asp:CalendarExtender ID="ceFechaFin" runat="server" PopupButtonID="btnFechaFin" TargetControlID="txtFechaFin" Format="dd/MM/yyyy" PopupPosition="BottomLeft" ViewStateMode="Enabled" />
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSucursales" runat="server" AccessKey="S" AssociatedControlID="ddlSucursales" Text="<u><b>S</b></u>ucursal(es):" />
                    </td>
                    <td colspan="4" style="width: 380px">
                        <asp:DropDownList ID="ddlSucursales" runat="server" Width="370px" Height="20px" />
                    </td>
                    <td></td>
                    <td>
                 
                        <asp:Label ID="lblVendedores" runat="server" AccessKey="V" AssociatedControlID="ddlVendedores" Text="<u><b>V</b></u>endedor(es):" />
                    </td>
                    <td style="width: 390px">
                        <asp:UpdatePanel ID="upVendedores" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlVendedores" runat="server" Width="370px" Height="20px" AutoPostBack="true" OnSelectedIndexChanged="ddlVendedores_SelectedIndexChanged" />
                                <asp:CascadingDropDown
                                    ID="ccdVendedores"
                                    runat="server"
                                    TargetControlID="ddlVendedores"
                                    ParentControlID="ddlSucursales"
                                    Category="CLAVE1"
                                    EmptyText="[SELECCIONAR]"
                                    ServicePath="~/DropDownAsincrono.asmx"
                                    ServiceMethod="ObtenerVendedoresTlmk" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlVendedores" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                         <asp:UpdatePanel ID="upComodines0" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="LkbComodines" AccessKey="M"   Visible="false" runat="server"  OnClick="LkbComodines_Click"><u><b>M</b></u>arcar/Desmarcar Todos...</asp:LinkButton>
                        <%--<asp:Label ID="lbl_comodines" runat="server" Visible="false" AccessKey="M" AssociatedControlID="ddlVendedores" Text="<u><b>M</b></u>arque los Vendedores" />--%>
                                </ContentTemplate>
                             </asp:UpdatePanel>
                    </td>
                    <td colspan="8" style="vertical-align: top; align-content: flex-end; text-align: left; text-align-last: left">
                         <asp:UpdatePanel ID="upComodines" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:CheckBoxList ID="cklVendedores" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" BorderStyle="Solid" Font-Size="7pt" BorderWidth="1px">
                                </asp:CheckBoxList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>   
                    <td></td>
                </tr>
                  <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>                                  
                    <td colspan="3">
                         <asp:CheckBox ID="ckClienteceroPedidos" runat="server" Checked="false" Text="Mostrar clientes con cero pedidos" />
                        
                    </td>
                    <td colspan="2">
                       <asp:CheckBox ID="ckClientesEliminados" runat="server" Checked="false" Text="Mostrar clientes eliminados" />
                    </td>
                    <td colspan="1">
                                  <asp:Button ID="btnGenerar" runat="server" Text="Generar" BackColor="#F5F5F5" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="22px" OnClick="btnGenerar_Click" />
                    </td>
                    <td></td>
                          <td></td>
                 </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>

                    <td colspan="4">
                        <asp:RequiredFieldValidator ID="rfvSucursal" runat="server" ControlToValidate="ddlVendedores" ErrorMessage="Debe seleccionar un Vendedor.<br />" ToolTip="Debe seleccionar una sucursal.<br />" ForeColor="Red" Font-Size="8pt" />
                        <asp:UpdatePanel ID="upCantidadDias" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Label ID="lblInformacion" runat="server" ForeColor="Red" Font-Size="8pt"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td>
                    </td>
                </tr>
            </table>

            <script type="text/javascript">
                $(document).ready(function () {
                    $('#<%= this.ddlSucursales.ClientID %>').change(function () {
                        if ($("#<%= this.ddlSucursales.ClientID %>").val() > 0) {
                            $("#<%= this.cklVendedores.ClientID %>").empty();
                            $("#<%= this.upComodines.ClientID %>").show();

                        }
                        else {
                            $("#<%= this.cklVendedores.ClientID %>").empty();
                            $("#<%= this.cklVendedores.ClientID %>").hide();
                            $("#<%= this.upComodines.ClientID %>").hide();
                           
                        }
                        $("#<%= this.LkbComodines.ClientID %>").hide();
                    });
                });

                <%--$(document).ready(function () {
                    $('#<%= this.LkbComodines.ClientID %>').click(function () {
                        $("#<%= this.cklVendedores.ClientID %>").select();                         
                    });
                });--%>

            </script>


            <asp:CascadingDropDown
                ID="cddSucursales"
                runat="server"
                TargetControlID="ddlSucursales"
                Category="CLAVE"
                PromptText="[SELECCIONAR]"
                ServicePath="~/DropDownAsincrono.asmx"
                ServiceMethod="ObtenerSucursales" />

        </asp:Panel>

        <asp:UpdatePanel ID="upPanelVenta" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="margin: 0; padding: 0;">
                    <table border="0" style="width: 97%; height: 72%; position: absolute; padding-top: 2px;">
                        <tr>
                            <td>
                                <asp:ReportViewer ID="rvVenta" runat="server" Width="100%"  Height="100%" ProcessingMode="Local" ShowExportControls="false" ShowPrintButton="true" ShowRefreshButton="false" OnDrillthrough="rvVenta_Drillthrough" />
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
                <%--  <asp:AsyncPostBackTrigger ControlID="btnGenerarComodines" EventName="Click" />--%>
                <asp:AsyncPostBackTrigger ControlID="btnSalir" EventName="Click" />

            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
