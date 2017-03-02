<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Impresion.aspx.cs" Inherits="Dapesa.Credito.NCR.IU.Sobres.Impresion" MasterPageFile="~/Site.Master" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="cContenido" ContentPlaceHolderID="cphContenidoPrincipal" runat="server">
	<div>
		<asp:Panel ID="pnlParametros" runat="server" DefaultButton="btnGenerar">
			<table border="0">
				<tr>
					<td>
						<asp:Label ID="lblClienteID" runat="server" AccessKey="C" AssociatedControlID="txtClienteID" Text="<u><b>C</b></u>liente(s):" />
					</td>
					<td colspan="2">
						<asp:TextBox ID="txtClienteID" runat="server" Width="175px" CssClass="upperText" />
					</td>
				</tr>
				<tr>
					<td>Fecha:</td>
					<td>
						<asp:TextBox ID="txtFecha" runat="server" Width="175px" Enabled="False" CssClass="upperText" />
						<asp:ImageButton ID="btnFecha" runat="server" ImageUrl="~/Img/calendario.png" />
						<asp:CalendarExtender ID="ceFecha" runat="server" PopupButtonID="btnFecha" TargetControlID="txtFecha" Format="dd/MM/yyyy" PopupPosition="BottomLeft" />
					</td>
					<td style="padding-left:25px;">
						<asp:Button ID="btnGenerar" runat="server" Text="Generar" BackColor="#F5F5F5" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="22px" OnClick="btnGenerar_Click" />
					</td>
				</tr>
				<tr>
					<td style="height:5px;" colspan="3">&nbsp;</td>
				</tr>
			</table>
		</asp:Panel>
		<asp:UpdatePanel ID="upPanelImpresion" runat="server" UpdateMode="Conditional">
			<ContentTemplate>
				<div style="margin:0;padding:0;">
					<table border="0" style="width:97%;height:64.5%;position:absolute;padding-top:2px;">
						<tr>
							<td>
								<asp:ReportViewer ID="rvSobre" runat="server" Width="100%" Height="100%" ShowRefreshButton="false" ShowZoomControl="false" ShowFindControls="false" ProcessingMode="Local" />
							</td>
						</tr>
					</table>
				</div>
			</ContentTemplate>
			<Triggers>
				<asp:AsyncPostBackTrigger ControlID="btnSalir" EventName="Click" />
				<asp:AsyncPostBackTrigger ControlID="btnGenerar" EventName="Click" />
			</Triggers>
		</asp:UpdatePanel>
	</div>
</asp:Content>