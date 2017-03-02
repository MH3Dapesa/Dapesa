<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HB.aspx.cs" Inherits="Dapesa.Almacen.Pedidos.Trazabilidad.IU.Documentacion.Formularios.Monterrey.HB" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="cContenido" ContentPlaceHolderID="cphContenidoPrincipal" runat="server">
    <div>
        <asp:Panel ID="pnlContenido" runat="server" DefaultButton="btnGenerar">
            <table border="0" style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="lblClienteID" runat="server" AccessKey="C" AssociatedControlID="txtClienteID" Text="<u><b>C</b></u>liente:" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtClienteID" runat="server" CssClass="upperText" TabIndex="1" />
                    </td>
                    <td style="width: 100%;">
                        <asp:Button ID="btnGenerar" runat="server" Text="Generar" BackColor="#F5F5F5" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="22px" OnClick="btnGenerar_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:UpdatePanel ID="upPanelGuia" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table border="0">
                        <tr>
                            <td style="text-align: left; font-size: 8pt;" colspan="4">
                                <asp:Label ID="lblMensaje" runat="server" />&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; vertical-align: middle;" colspan="2">
                                <asp:CheckBox ID="cbOcurre" runat="server" Text="Ocurre" OnCheckedChanged="cbOcurre_CheckedChanged" AutoPostBack="true" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Nombre:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtNombre" runat="server" Width="400px" CssClass="upperText" TabIndex="2" />
                            </td>
                            <td style="vertical-align: bottom;" rowspan="11">
                                <asp:Label ID="lblImprimir" runat="server" AccessKey="P" AssociatedControlID="btnImprimir" />
                                <asp:ImageButton ID="btnImprimir" runat="server" AlternateText="Imprimir" ImageUrl="~/Img/impresora.png" BackColor="#F5F5F5" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Visible="false" TabIndex="14" OnClick="btnImprimir_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="white-space: nowrap;">Raz&oacute;n social:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtRazonSocial" runat="server" Width="400px" CssClass="upperText" TabIndex="3" />
                            </td>
                        </tr>
                        <tr>
                            <td>Domicilio:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtDomicilio" runat="server" Width="400px" CssClass="upperText" TabIndex="4" />
                            </td>
                        </tr>
                        <tr>
                            <td>Colonia:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtColonia" runat="server" Width="400px" CssClass="upperText" TabIndex="5" />
                            </td>
                        </tr>
                        <tr>
                            <td>Ciudad:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtCiudad" runat="server" Width="400px" CssClass="upperText" TabIndex="6" />
                            </td>
                        </tr>
                        <tr>
                            <td>Estado:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtEstado" runat="server" Width="400px" CssClass="upperText" TabIndex="7" />
                            </td>
                        </tr>
                        <tr>
                            <td>Tel&eacute;fono:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtTelefono" runat="server" Width="270px" CssClass="upperText" TabIndex="8" />
                            </td>
                        </tr>
                        <tr>
                            <td style="white-space: nowrap;">C&oacute;digo postal:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="upperText" TabIndex="9" />
                            </td>
                        </tr>
                        <tr><td>  </td></tr> <tr><td>  </td></tr>  <tr><td></td><td>Valor declarado</td></tr>
                        <tr>
                            <td>Cantidad:</td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtCantidad1" runat="server" Text="1" TabIndex="10" MaxLength="2" Width="35" />
                                            <asp:FilteredTextBoxExtender ID="ftxteCantidad1" runat="server" TargetControlID="txtCantidad1" FilterType="Numbers" />
                                        </td>
                                        <td>Peso:</td>
                                        <td>
                                            <asp:TextBox ID="txtPeso1" runat="server" Text="" TabIndex="11" MaxLength="6" Width="35" />
                                            <asp:RegularExpressionValidator ID="revPeso1" runat="server" ControlToValidate="txtPeso1" ValidationExpression="^(\d|-)?(\d|,)*\.?\d*$" Text="Solo se permiten números." Display="Dynamic" />
                                        </td>
                                        <td>Art&iacute;culo:</td>
                                        <td>
                                            <asp:TextBox ID="txtArticulo1" runat="server" Text="CAJA" TabIndex="10" Width="70" placeholder="Artículo" />
                                        </td>
                                        <td>Contenido:</td>
                                        <td>
                                            <asp:TextBox ID="txtContenido1" runat="server" Text="AUTOPARTES" TabIndex="10" Width="90" placeholder="Contenido" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>Cantidad:</td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtCantidad2" runat="server" Text="" TabIndex="10" MaxLength="2" Width="35" />
                                            <asp:FilteredTextBoxExtender ID="ftxteCantidad2" runat="server" TargetControlID="txtCantidad2" FilterType="Numbers" />
                                        </td>
                                        <td>Peso:</td>
                                        <td>
                                            <asp:TextBox ID="txtPeso2" runat="server" Text="" TabIndex="11" MaxLength="6" Width="35" />
                                            <asp:RegularExpressionValidator ID="revPeso2" runat="server" ControlToValidate="txtPeso2" ValidationExpression="^(\d|-)?(\d|,)*\.?\d*$" Text="Solo se permiten números." Display="Dynamic" />
                                        </td>
                                        <td>Art&iacute;culo:</td>
                                        <td>
                                            <asp:TextBox ID="txtArticulo2" runat="server" Text="" TabIndex="10" Width="70" placeholder="Artículo" />
                                        </td>
                                        <td>Contenido:</td>
                                        <td>
                                            <asp:TextBox ID="txtContenido2" runat="server" Text="" TabIndex="10" Width="90" placeholder="Contenido" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>Cantidad:</td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtCantidad3" runat="server" Text="" TabIndex="10" MaxLength="2" Width="35" />
                                            <asp:FilteredTextBoxExtender ID="ftxteCantidad3" runat="server" TargetControlID="txtCantidad3" FilterType="Numbers" />
                                        </td>
                                        <td>Peso:</td>
                                        <td>
                                            <asp:TextBox ID="txtPeso3" runat="server" Text="" TabIndex="11" MaxLength="6" Width="35" />
                                            <asp:RegularExpressionValidator ID="revPeso3" runat="server" ControlToValidate="txtPeso3" ValidationExpression="^(\d|-)?(\d|,)*\.?\d*$" Text="Solo se permiten números." Display="Dynamic" />
                                        </td>
                                        <td>Art&iacute;culo:</td>
                                        <td>
                                            <asp:TextBox ID="txtArticulo3" runat="server" Text="" TabIndex="10" Width="70" placeholder="Artículo" />
                                        </td>
                                        <td>Contenido:</td>
                                        <td>
                                            <asp:TextBox ID="txtContenido3" runat="server" Text="" TabIndex="10" Width="90" placeholder="Contenido" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>Copias:</td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtCopias" runat="server" Text="1" TabIndex="12" MaxLength="2" />
                                            <asp:FilteredTextBoxExtender ID="ftxteCopias" runat="server" TargetControlID="txtCopias" FilterType="Numbers" />
                                        </td>
                                        <td style="width: auto; text-align: right;">
                                            <asp:CheckBox ID="cbRemitente" runat="server" Text="Imprimir remitente" OnCheckedChanged="cbRemitente_CheckedChanged" AutoPostBack="true" TabIndex="13" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSalir" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnGenerar" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
</asp:Content>
