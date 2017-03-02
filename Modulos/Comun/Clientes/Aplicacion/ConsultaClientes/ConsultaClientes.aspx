<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaClientes.aspx.cs" Inherits="Comun.Clientes.ConsultaClientes.ConsultaClientes" EnableEventValidation="false" %>

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
            <table style="border-spacing:0 3px; border-collapse:separate; background-color:#ceecf6; border-radius: 50px;  width:100%">
                <tr>
                    <td style="width:5%;">
                        <asp:Button ID="btnGenerar" runat="server" CssClass="btnGenerar" OnClick="btnGenerar_Click" Text="Buscar"/>
                    </td>
                    <td style="width:95%">
                        <asp:TextBox ID="txtCliente" runat="server" style="width:97%; font-size:12pt; border-top-right-radius: 50px; border-bottom-right-radius: 50px; margin-left:15px;height:25px; text-transform: uppercase;"  />
                    </td>
                </tr>      
            </table>
            <asp:RequiredFieldValidator ID="rfvCliente" runat="server" ControlToValidate="txtCliente" />
        </asp:Panel>
        <asp:UpdatePanel ID="upPanelContenido" runat="server" UpdateMode="Conditional">
            <ContentTemplate> 
                <asp:UpdatePanel ID="upPanelMostrar" runat="server">
                    <ContentTemplate>
                        <br />
                        <div style="margin: 0; padding: 0; width:100%">
                            <asp:GridView ID="gvContenido" runat="server" CssClass="gvContenido" EmptyDataText="La busqueda no obtuvo ningun resultado." >
                                <HeaderStyle CssClass="gvContenido_Header" />
                                <RowStyle CssClass="gvContenido_Rows" />
                            </asp:GridView>
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
