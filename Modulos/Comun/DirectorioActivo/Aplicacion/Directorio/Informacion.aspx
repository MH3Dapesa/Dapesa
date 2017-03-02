<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informacion.aspx.cs" Inherits="Dapesa.Comun.DirectorioActivo.IU.Directorio.Informacion" MasterPageFile="~/Site.Master" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="cContenido" ContentPlaceHolderID="cphContenidoPrincipal" runat="server">
    <div>
        <asp:Panel ID="pnlParametros" runat="server" DefaultButton="btnBuscar">
            <table border="0">
                <tr>
                    <td>
                        <asp:Label ID="lblFiltro" runat="server" AccessKey="F" AssociatedControlID="ddlFiltro" Text="<u><b>F</b></u>iltro:" />
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlFiltro" runat="server" Width="370px" Height="20px">
                            <asp:ListItem Value="department" Text="DEPARTAMENTO" />
                            <asp:ListItem Value="name" Text="NOMBRE" Selected="True" />
                            <asp:ListItem Value="title" Text="PUESTO" />
                            <asp:ListItem Value="l" Text="SUCURSAL" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblValor" runat="server" AccessKey="V" AssociatedControlID="txtValor" Text="<u><b>V</b></u>alor:" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtValor" runat="server" Width="366px" CssClass="upperText" />
                    </td>
                    <td style="padding-left: 25px;">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" BackColor="#F5F5F5" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="22px" OnClick="btnBuscar_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 5px;" colspan="3">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:UpdatePanel ID="upPanelInformacion" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table border="0" style="padding-top: 15px;">
                    <tr>
                        <td>
                            <asp:GridView ID="gvInformacion" runat="server"  AutoGenerateColumns="false" BorderColor="Gray" BorderStyle="Solid" PageSize="18" Font-Size="8pt" EmptyDataText="No hay registros que coincidan con los par&aacute;metros b&uacute;squeda suministrados." OnPageIndexChanging="gvInformacion_PageIndexChanging" OnRowCommand="gvInformacion_RowCommand" OnRowCreated="gvInformacion_RowCreated">
                                
                                <PagerStyle BackColor="LightGray" Font-Bold="false" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <table>
                                                <tr>
                                                    <td style="width: 40px; text-align: left;">
                                                        <asp:Label ID="lblNumFila" runat="server" />
                                                    </td>
                                                    <td style="width: 300px; text-align: left;">
                                                        <asp:Label ID="lblNombre" runat="server" Text="Nombre" />
                                                    </td>
                                                    <td style="width: 240px; text-align: left;">
                                                        <asp:Label ID="lblDepartamento" runat="server" Text="Departamento" />
                                                    </td>
                                                    <td style="width: 230px; text-align: left;">
                                                        <asp:Label ID="lblPuesto" runat="server" Text="Puesto" />
                                                    </td>
                                                    <td style="width: 80px; text-align: left;">
                                                        <asp:Label ID="lblExtension" runat="server" Text="Extencion" />
                                                    </td>
                                                    <td style="width: 150px; text-align: left;">
                                                        <asp:Label ID="lblSucursal" runat="server" Text="Sucursal" />
                                                    </td>
                                                    <td style="width: 200px; text-align: left;" >
                                                        <asp:Label ID="lblCorreo" runat="server" Text="Correo" />
                                                    </td>
                                                   <%-- <td style="width: 60px; text-align: center;">
                                                        <asp:Label ID="lblDetalles" runat="server" Text="Detalles" />
                                                    </td>--%>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <td style="width: 40px; text-align: left;">
                                                        <asp:Label ID="lblNumFila"  runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Consecutivo"))) %>' />
                                                    </td>
                                                    <td style="width: 300px; text-align: left;">
                                                        <asp:LinkButton ID="lblNombre" CssClass="btnNombre" runat="server" CommandName="MostrarDetalles" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("NombreCompleto"))) %>' />
                                                    </td>
                                                    <td style="width: 240px; text-align: left;">
                                                        <asp:Label ID="lblDepartamento"  runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Departamento"))) %>' />
                                                    </td>
                                                    <td style="width: 230px; text-align: left;">
                                                        <asp:Label ID="lblPuesto" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Puesto"))) %>' />
                                                    </td>
                                                    <td style="width: 80px; text-align: left;">
                                                        <asp:Label ID="lblExtension" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Extension"))) %>' />
                                                    </td>
                                                    <td style="width: 150px; text-align: left;">
                                                        <asp:Label ID="lblSucursal" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Sucursal"))) %>' />
                                                    </td>
                                                    <td style="width: 200px; text-align: left;">
                                                        <asp:Label ID="lblCorreo" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Correo"))) %>' />
                                                    </td>
                                                  <%--  <td style="width: 60px; text-align: center;">
                                                        <asp:LinkButton ID="btnDetalles" runat="server" Text="Mostrar" CommandName="MostrarDetalles" />
                                                    </td>--%>
                                                </tr>
                                            </table>
                                            <asp:Label ID="lblColonia" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Colonia"))) %>' Visible="false" />
                                            <%--<asp:Label ID="lblCorreo" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Correo"))) %>' Visible="false" />--%>
                                            <asp:Label ID="lblCP" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("CP"))) %>' Visible="false" />
                                            <asp:Label ID="lblDireccion" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Direccion"))) %>' Visible="false" />
                                            <asp:Label ID="lblEstado" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Estado"))) %>' Visible="false" />
                                            <asp:Label ID="lblMovil" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Movil"))) %>' Visible="false" />
                                            <asp:Label ID="lblRadio" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Radio"))) %>' Visible="false" />
                                            <asp:Label ID="lblTelefono" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Telefono"))) %>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <script type="text/javascript">

                </script>
                <asp:Button ID="btnDummy" runat="server" Style="display: none;" />
                <asp:Panel ID="pnlDetalles" runat="server" Style="display: none">
                    <div style="background-color: #FFFFFF; border-width: 1px; border-color: #F5F5F5; border-style: solid; width: 800px; text-align: left; vertical-align: top; padding: 10px;">
                        <table border="0" style="width: 100%">
                            <tr>
                                <td style="text-align: center; font-weight: bold; width: 100%;">Detalles</td>
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
                                            <td style="width: 100px;">Nombre:</td>
                                            <td>
                                                <asp:Label ID="lblNombre" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Puesto:</td>
                                            <td>
                                                <asp:Label ID="lblPuesto" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Departamento:</td>
                                            <td>
                                                <asp:Label ID="lblDepartamento" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Tel&eacute;fono:</td>
                                            <td>
                                                <asp:Label ID="lblTelefono" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Celular:</td>
                                            <td>
                                                <asp:Label ID="lblMovil" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Nextel:</td>
                                            <td>
                                                <asp:Label ID="lblRadio" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Extensi&oacute;n:</td>
                                            <td>
                                                <asp:Label ID="lblExtension" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Correo:</td>
                                            <td style="cursor: pointer;">
                                                <asp:Label ID="lblCorreo" runat="server" ForeColor="Blue" Font-Underline="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Sucursal:</td>
                                            <td>
                                                <asp:Label ID="lblSucursal" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Direcci&oacute;n:</td>
                                            <td>
                                                <asp:Label ID="lblDireccion" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Colonia:</td>
                                            <td>
                                                <asp:Label ID="lblColonia" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Estado:</td>
                                            <td>
                                                <asp:Label ID="lblEstado" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>C.P.:</td>
                                            <td>
                                                <asp:Label ID="lblCP" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <asp:ModalPopupExtender ID="mpeDetalles" runat="server" TargetControlID="btnDummy" PopupControlID="pnlDetalles" CancelControlID="btnCerrar" BackgroundCssClass="updateProgressBackground" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSalir" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
