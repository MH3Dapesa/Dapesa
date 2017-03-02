<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="Dapesa.Comun.Informes.IU.Reporteador.Asignaciones" MasterPageFile="~/Site.Master" EnableEventValidation="false" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="asp" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="cContenido" ContentPlaceHolderID="cphContenidoPrincipal" runat="server">
	<div>
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
						<asp:Label ID="lblTelemarketings" runat="server" AccessKey="T" AssociatedControlID="ddlTelemarketings" Text="<u><b>T</b></u>elemarketing(s):" />
					</td>
					<td colspan="2">
						<asp:DropDownList ID="ddlTelemarketings" runat="server" Width="370px" Height="20px" />
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="lblEstatus" runat="server" AccessKey="E" AssociatedControlID="ddlEstatus" Text="<u><b>E</b></u>status:" />
					</td>
					<td colspan="2">
						<asp:DropDownList ID="ddlEstatus" runat="server" Width="370px" Height="20px">
							<asp:ListItem Value="" Text="&nbsp;&nbsp;&nbsp;&nbsp;[SELECCIONAR]" Selected="True" />
							<asp:ListItem Value="A" Text="ACTIVO" />
							<asp:ListItem Value="I" Text="INACTIVO" />
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="lblSemaforo" runat="server" AccessKey="V" AssociatedControlID="ddlSemaforo" Text="Sem&aacute;foro&nbsp;<u><b>V</b></u>enta:" />
					</td>
					<td>
						<asp:DropDownList ID="ddlSemaforo" runat="server" Width="370px" Height="20px">
							<asp:ListItem Value="" Text="&nbsp;&nbsp;&nbsp;&nbsp;[SELECCIONAR]" Selected="True" />
							<asp:ListItem Value="Azul" Text="MES&nbsp;ACTUAL&nbsp;(AZUL)" />
							<asp:ListItem Value="Blanco" Text="MENOR&nbsp;O&nbsp;IGUAL&nbsp;A&nbsp;90&nbsp;D&Iacute;AS&nbsp;(BLANCO)" />
							<asp:ListItem Value="Rojo" Text="MAYOR&nbsp;A&nbsp;90&nbsp;D&Iacute;AS&nbsp;(ROJO)" />
							<asp:ListItem Value="Nulo" Text="SIN&nbsp;VENTA&nbsp;(NULO)" />
						</asp:DropDownList>
					</td>
					<td style="padding-left:25px;">
						<asp:Button ID="btnGenerar" runat="server" Text="Generar" BackColor="#F5F5F5" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="22px" OnClick="btnGenerar_Click" />
					</td>
				</tr>
				<tr>
					<td style="height:5px;" colspan="3">&nbsp;</td>
				</tr>
			</table>
			<asp:CascadingDropDown 
				ID="cddSucursales"
				runat="server"
				TargetControlID="ddlSucursales"
				Category="CLAVE"
				PromptText="&nbsp;&nbsp;&nbsp;&nbsp;[SELECCIONAR]"
				ServicePath="~/DropDownAsincrono.asmx"
				ServiceMethod="ObtenerSucursales" />
			<asp:CascadingDropDown 
				ID="ccdTelemarketings"
				runat="server"
				TargetControlID="ddlTelemarketings"
				ParentControlID="ddlSucursales"
				Category="CLAVE"
				PromptText="&nbsp;&nbsp;&nbsp;&nbsp;[SELECCIONAR]"
				ServicePath="~/DropDownAsincrono.asmx"
				ServiceMethod="ObtenerTelemarketings" />
		</asp:Panel>
		<asp:UpdatePanel ID="upPanelItinerario" runat="server" UpdateMode="Conditional">
			<ContentTemplate>
				<div style="margin:0;padding:0;">
					<table border="0" style="width:97%;height:65%;position:absolute;padding-top:2px;">
						<tr>
							<td>
								<asp:ReportViewer ID="rvItinerario" runat="server" Width="100%" Height="100%" ProcessingMode="Local" />
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