<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="Dapesa.Almacen.Pedidos.IU.Mensajero.Listado" MasterPageFile="~/Site.Master" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="cEncabezado" ContentPlaceHolderID="cphEncabezado" runat="server">
    <script type="text/javascript">
        $(window).load(updateTime);
        $(window).load(function () {
            setInterval(updateTime, 1000);
        });
        function updateTime() {
            $("#<%= lblHora.ClientID %>").text((new Date()).localeFormat("dd/MM/yyyy HH:mm:ss"));
        }
    </script>
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
        <table border="0" style="width: 100%; padding-left: 14px; padding-top: 5px;">
            <tr>
                <td>
                    <asp:Panel ID="pnlParametros" runat="server" DefaultButton="btnGenerar">
                        <table>
                            <tr>
                                <td style="white-space: nowrap;">Fecha inicial:</td>
                                <td style="white-space: nowrap;" colspan="2">
                                    <asp:TextBox ID="txtFechaInicio" runat="server" Width="175px" Enabled="False" CssClass="upperText" />
                                    <asp:ImageButton ID="btnFechaInicio" runat="server" ImageUrl="~/Img/calendario.png" />
                                    <asp:CalendarExtender ID="ceFechaInicio" runat="server" PopupButtonID="btnFechaInicio" TargetControlID="txtFechaInicio" Format="dd/MM/yyyy" PopupPosition="BottomLeft" />
                                </td>
                            </tr>
                            <tr>
                                <td style="white-space: nowrap;">Fecha final:</td>
                                <td style="white-space: nowrap;">
                                    <asp:TextBox ID="txtFechaFin" runat="server" Width="175px" Enabled="false" CssClass="upperText" />
                                    <asp:ImageButton ID="btnFechaFin" runat="server" ImageUrl="~/Img/calendario.png" />
                                    <asp:CalendarExtender ID="ceFechaFin" runat="server" PopupButtonID="btnFechaFin" TargetControlID="txtFechaFin" Format="dd/MM/yyyy" PopupPosition="BottomLeft" />
                                </td>
                                <td style="padding-left: 25px;">
                                    <asp:Button ID="btnGenerar" CssClass="bindable" runat="server" Text="Generar" BackColor="#F5F5F5" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="22px" OnClick="btnGenerar_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 10px; color: red; font-size: 8pt;" colspan="3">
                                    <asp:CompareValidator ID="cvFechas" runat="server" ErrorMessage="La fecha final, debe ser mayor o igual a la fecha de inicio.<br />" Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtFechaInicio" ControlToValidate="txtFechaFin" />
                                </td>
                            </tr>
                        </table>
                        <script type="text/javascript">
                            $("#<%= txtFechaInicio.ClientID %>").val((new Date()).localeFormat("dd/MM/yyyy"));
                            $("#<%= txtFechaFin.ClientID %>").val((new Date()).localeFormat("dd/MM/yyyy"));
                        </script>
                        <script>

                            function desplaza() {
                                var scrollAncho = document.getElementById('panelgvPedidos').scrollLeft;
                                var scrollAlto = document.getElementById('panelgvPedidos').scrollTop;
                                if (scrollAlto > 14) {
                                    $("#divtblEncabezado").css("visibility", "visible");
                                    document.getElementById('divtblEncabezado').scrollLeft = scrollAncho;
                                }
                                else {
                                    $("#divtblEncabezado").css("visibility", "hidden");
                                }
                            }

                        </script>
                    </asp:Panel>
                </td>
                <td style="width: 100%;">
                    <table border="0" style="width: 100%; height: 100%">
                        <tr>
                            <td style="width: 100%; text-align: right; vertical-align: middle; font-weight: bold; font-size: x-large; padding-top: 10px; padding-right: 10px;">
                                <asp:UpdatePanel ID="upPanelFecha" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Label ID="lblHora" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: right; vertical-align: middle;">&nbsp;
								<img alt="DAPESA" src="Img/dapesa.png" height="35" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:Timer ID="tmrInfo" runat="server" OnTick="tmrInfo_Tick" />
        <asp:UpdatePanel ID="upPanelPedidos" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="margin: 0; padding: 0; overflow: hidden;">
                    <table border="0" style="width: 97%; height: 77%; padding-top: 2px; overflow: hidden;">
                        <tr>
                            <td>
                                <%--<asp:ReportViewer ID="rvPedidos" runat="server" Height="100%" Width="100%" ProcessingMode="Local" AsyncRendering="false" ShowToolBar="false" />--%>
                                <div id="divtblEncabezado" style="width: 52%; overflow: hidden; max-height: 500px; visibility: hidden;">
                                    <table id="tblEncabezados" class="tblEncabezados">
                                        <td id="thcol0" style="width: 35px;">#
                                        </td>
                                        <td id="thcol1" style="width: 35px;">VEND
                                        </td>
                                        <td id="thcol3" style="width: 215px;">CLIENTE
                                        </td>
                                        <td id="thcol4" style="width: 60px;">PEDIDO
                                        </td>
                                        <td id="thcol5" style="width: 130px;">TRANSPORTISTA
                                        </td>
                                        <td id="thcol6" style="width: 63px;">CONDICIÓN
                                        </td>
                                        <td id="thcol7" style="width: 120px;">AUTORIZACIÓN
                                        </td>
                                        <td id="thcol8" style="width: 135px;">FECHA
                                        </td>
                                        <td id="thcol9" style="width: 36px">RENG
                                        </td>
                                        <td id="thcol10" style="width: 1300px; text-align: left; padding: 0px 0px 0px 70px;">OBSERVACIONES
                                        </td>

                                    </table>
                                </div>
                                <div id="panelgvPedidos" onscroll="desplaza()" style="width: 52%; overflow: auto; max-height: 500px;">
                                    <asp:GridView ID="gvPedidos" runat="server" CssClass="gvPedidos" OnRowDataBound="GridView1_RowDataBound">
                                        <HeaderStyle CssClass="gridViewHeader" />
                                        <RowStyle CssClass="gvRow" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSalir" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnGenerar" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="tmrInfo" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
