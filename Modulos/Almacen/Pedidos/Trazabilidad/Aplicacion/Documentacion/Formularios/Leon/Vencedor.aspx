<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vencedor.aspx.cs" Inherits="Dapesa.Almacen.Pedidos.Trazabilidad.IU.Documentacion.Vencedor" MasterPageFile="~/Site.Master" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="cContenido" ContentPlaceHolderID="cphContenidoPrincipal" runat="server">
	<div>
		<asp:Panel ID="pnlContenido" runat="server" DefaultButton="btnGenerar">
			<table border="0" style="width:100%;">
				<tr>
					<td>
						<asp:Label ID="lblClienteID" runat="server" AccessKey="C" AssociatedControlID="txtClienteID" Text="<u><b>C</b></u>liente:" />
					</td>
					<td>
						<asp:TextBox ID="txtClienteID" runat="server" CssClass="upperText" TabIndex="1" />
					</td>
					<td style="width:100%;">
						<asp:Button ID="btnGenerar" runat="server" Text="Generar" BackColor="#F5F5F5" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="22px" OnClick="btnGenerar_Click" />
					</td>
				</tr>
			</table>
			<br />
			<asp:UpdatePanel ID="upPanelGuia" runat="server" UpdateMode="Conditional">
				<ContentTemplate>
					<table border="0">
						<tr>
							<td style="text-align:left;font-size:8pt;" colspan="3">
								<asp:Label ID="lblMensaje" runat="server" />&nbsp;
							</td>
						</tr>
						<tr>
							<td style="text-align:right;vertical-align:middle;" colspan="2">
								<asp:CheckBox ID="cbOcurre" runat="server" Text="Ocurre" OnCheckedChanged="cbOcurre_CheckedChanged" AutoPostBack="true" />
							</td>
							<td>&nbsp;</td>
						</tr>
						<tr>
							<td>Nombre:</td>
							<td>
								<asp:TextBox ID="txtNombre" runat="server" Width="400px" CssClass="upperText" TabIndex="2" />
							</td>
							<td style="padding-left:20px;vertical-align:bottom;" rowspan="8">
								<asp:Label ID="lblImprimir" runat="server" AccessKey="P" AssociatedControlID="btnImprimir" />
								<asp:ImageButton ID="btnImprimir" runat="server" AlternateText="Imprimir" ImageUrl="~/Img/impresora.png" BackColor="#F5F5F5" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Visible="false" TabIndex="11" OnClick="btnImprimir_Click" />
							</td>
						</tr>
						<tr>
							<td style="white-space:nowrap;">Raz&oacute;n social:</td>
							<td>
								<asp:TextBox ID="txtRazonSocial" runat="server" Width="400px" CssClass="upperText" TabIndex="3" />
							</td>
						</tr>
						<tr>
							<td>Calle y n&uacute;mero:</td>
							<td>
								<asp:TextBox ID="txtDomicilio" runat="server" Width="400px" CssClass="upperText" TabIndex="4" />
							</td>
						</tr>
						<tr>
							<td>Colonia:</td>
							<td>
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
							<td>
								<asp:TextBox ID="txtTelefono" runat="server" Width="270px" CssClass="upperText" TabIndex="8" />
							</td>
						</tr>
						<tr>
							<td style="white-space:nowrap;">C&oacute;digo postal:</td>
							<td>
								<asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="upperText" TabIndex="9" />
							</td>
						</tr>
						<tr>
							<td>Copias:</td>
							<td>
								<asp:TextBox ID="txtCopias" runat="server" Text="1" TabIndex="10" MaxLength="2" />
								<asp:FilteredTextBoxExtender ID="ftxteCopias" runat="server" TargetControlID="txtCopias" FilterType="Numbers" />
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