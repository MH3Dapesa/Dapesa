<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="Dapesa.Credito.Facturas.IU.NoParte.Listado" MasterPageFile="~/Site.Master" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="cContenido" ContentPlaceHolderID="cphContenidoPrincipal" runat="server">
	<div>
		<asp:Panel ID="pnlParametros" runat="server" DefaultButton="btnGenerar">
			<table border="0">
				<tr>
					<td>
						<asp:Label ID="lblClienteID" runat="server" AccessKey="C" AssociatedControlID="txtClienteID" Text="<u><b>C</b></u>liente:" />
					</td>
					<td colspan="2">
						<asp:TextBox ID="txtClienteID" runat="server" Width="175px" CssClass="upperText" />
					</td>
				</tr>
				<tr>
					<td>Fecha inicial:</td>
					<td colspan="2">
						<asp:TextBox ID="txtFechaInicio" runat="server" Width="175px" Enabled="False" CssClass="upperText" />
						<asp:ImageButton ID="btnFechaInicio" runat="server" ImageUrl="~/Img/calendario.png" />
						<asp:CalendarExtender ID="ceFechaInicio" runat="server" PopupButtonID="btnFechaInicio" TargetControlID="txtFechaInicio" Format="dd/MM/yyyy" PopupPosition="BottomLeft" />
					</td>
				</tr>
				<tr>
					<td>Fecha final:</td>
					<td>
						<asp:TextBox ID="txtFechaFin" runat="server" Width="175px" Enabled="false" CssClass="upperText" />
						<asp:ImageButton ID="btnFechaFin" runat="server" ImageUrl="~/Img/calendario.png" />
						<asp:CalendarExtender ID="ceFechaFin" runat="server" PopupButtonID="btnFechaFin" TargetControlID="txtFechaFin" Format="dd/MM/yyyy" PopupPosition="BottomLeft" />
					</td>
					<td style="padding-left:25px;">
						<asp:Button ID="btnGenerar" runat="server" Text="Generar" BackColor="#F5F5F5" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="22px" OnClick="btnGenerar_Click" />
					</td>
				</tr>
				<tr>
					<td style="height:5px;" colspan="3">&nbsp;</td>
				</tr>
				<tr>
					<td style="padding-left:10px;color:red;font-size:8pt;" colspan="3">
						<asp:RequiredFieldValidator ID="rfvClienteID" runat="server" ErrorMessage="Debe proporcionar un ID de cliente v&aacute;lido.<br />" ControlToValidate="txtClienteID" />
						<asp:CompareValidator ID="cvFechas" runat="server" ErrorMessage="La fecha final, debe ser mayor o igual a la fecha de inicio.<br />" Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtFechaInicio" ControlToValidate="txtFechaFin" />
					</td>
				</tr>
			</table>
		</asp:Panel>
		<asp:UpdatePanel ID="upPanelNoParte" runat="server" UpdateMode="Conditional">
			<ContentTemplate>
				<table border="0">
					<tr>
						<td>
							<asp:GridView ID="gvNoParte" runat="server" AllowPaging="true" AutoGenerateColumns="false" BorderColor="Gray" BorderStyle="Solid" PageSize="15" Font-Size="8pt" EmptyDataText="No hay registros que coincidan con los par&aacute;metros b&uacute;squeda suministrados." OnPageIndexChanging="gvNoParte_PageIndexChanging">
								<PagerSettings Mode="NumericFirstLast" PageButtonCount="20" Position="Bottom" Visible="true" />
								<PagerStyle BackColor="LightGray" Font-Bold="false" />
								<Columns>
									<asp:TemplateField>
										<HeaderTemplate>
											<table>
												<tr>
													<td style="width:70px;text-align:left;">
														<asp:Label ID="lblNumFila" runat="server" />
													</td>
													<td style="width:200px;text-align:left;">
														<asp:Label ID="lblNoParte" runat="server" Text="No. parte" />
													</td>
													<td style="width:100px;text-align:right;">
														<asp:Label ID="lblCantidad" runat="server" Text="Cantidad" />
													</td>
													<td style="width:150px;text-align:right;">
														<asp:Label ID="lblPrecio" runat="server" Text="Precio" />
													</td>
												</tr>
											</table>
										</HeaderTemplate>
										<ItemTemplate>
											<table>
												<tr>
													<td style="width:70px;text-align:left;">
														<asp:Label ID="lblNumFila" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString( Eval("NUM_FILA"))) %>' />
													</td>
													<td style="width:200px;text-align:left;">
														<asp:Label ID="lblNoParte" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString( Eval("ART_CLAVE"))) %>' />
													</td>
													<td style="width:100px;text-align:right;">
														<asp:Label ID="lblCantidad" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString( Eval("CANTIDAD"))) %>' />
													</td>
													<td style="width:150px;text-align:right;">
														<asp:Label ID="lblPrecio" runat="server" Text='<%# HttpUtility.HtmlEncode(Convert.ToString( Eval("PRECIO"))) %>' />
													</td>
												</tr>
											</table>
										</ItemTemplate>
									</asp:TemplateField>
								</Columns>
							</asp:GridView>
						</td>
						<td style="width:120px;text-align:right;vertical-align:top;padding-top:10px;">
							<asp:LinkButton ID="lbExportar" runat="server" Text="Exportar" OnClick="lbExportar_Click" />
						</td>
					</tr>
				</table>
			</ContentTemplate>
			<Triggers>
				<asp:AsyncPostBackTrigger ControlID="btnSalir" EventName="Click" />
				<asp:AsyncPostBackTrigger ControlID="btnGenerar" EventName="Click" />
				<asp:PostBackTrigger ControlID="lbExportar" />
			</Triggers>
		</asp:UpdatePanel>
	</div>
</asp:Content>