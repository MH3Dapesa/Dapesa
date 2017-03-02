<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="Dapesa.Comun.Informes.IU.Reporteador.InicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
	<title>Login::.Dapesa.Comun.DirectorioActivo.Directorio</title>
	<link rel="shortcut icon" type="image/png" href="favicon.png" />
	<link rel="stylesheet" type="text/css" href="Css/HojaEstilos.css" />
</head>
<body style="margin:0;padding:0;">
	<form id="frmMain" runat="server">
		<div>
			<table border="0" style="width:100%;height:100%;position:absolute;">
				<tr>
					<td style="width:50%;">&nbsp;</td>
					<td>
						<asp:Login ID="lgnLogin" runat="server" OnAuthenticate="lgnLogin_Authenticate" OnLoggedIn="lgnLogin_LoggedIn" OnLoginError="lgnLogin_LoginError">
							<LayoutTemplate>
								<asp:Panel ID="pnlLogin" runat="server" DefaultButton="LoginButton">
									<table border="0" style="border-collapse:collapse;padding:1px;">
										<tr>
											<td>
												<table border="0" style="padding:0px;">
													<tr>
														<td>&nbsp;</td>
														<td style="text-align:left;" colspan="2">
															<img alt="DAPESA" src="Img/dapesa500.png" width="200" />
														</td>
													</tr>
													<tr>
														<td style="text-align:center;" colspan="3">
															&nbsp;
														</td>
													</tr>
													<tr>
														<td style="text-align:right;">
															<asp:Label ID="UserNameLabel" runat="server" AccessKey="U" AssociatedControlID="UserName" Text="<u><b>U</b></u>suario:&nbsp;" />
														</td>
														<td style="text-align:left;">
															<asp:TextBox ID="UserName" runat="server" Width="200px" />
														</td>
														<td>
															<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El usuario es requerido" ToolTip="El usuario es requerido" ValidationGroup="LoginValidationGroup" Text="*" ForeColor="Red" />
														</td>
													</tr>
													<tr>
														<td style="text-align:right;">
															<asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Text="Contrase&ntilde;a:&nbsp;" />
														</td>
														<td style="text-align:left;">
															<asp:TextBox ID="Password" runat="server" TextMode="Password" Width="200px" />
														</td>
														<td>
															<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="La contrase&ntilde;a es requerida" ToolTip="La contrase&ntilde;a es requerida" ValidationGroup="LoginValidationGroup" Text="*" ForeColor="Red" />
														</td>
													</tr>
													<tr>
														<td style="white-space:nowrap;text-align:right;">
															<asp:Label ID="DomainLabel" runat="server" AssociatedControlID="Domain" Text="Dominio:&nbsp;" />
														</td>
														<td style="text-align:left;">
															<asp:TextBox ID="Domain" runat="server" Width="200px" Text="DAPESA.local" />
														</td>
														<td>
															<asp:RequiredFieldValidator ID="DomainRequired" runat="server" ControlToValidate="Domain" ErrorMessage="El dominio es requerido" ToolTip="El dominio es requerido" ValidationGroup="LoginValidationGroup" Text="*" ForeColor="Red" />
														</td>
													</tr>
													<tr>
														<td style="text-align:center;" colspan="3">
															&nbsp;
														</td>
													</tr>
													<tr>
														<td>&nbsp;</td>
														<td style="text-align:left;vertical-align:middle;" colspan="2">
															<asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Entrar" ValidationGroup="LoginValidationGroup" BackColor="#F5F5F5" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="22px" />&nbsp;&nbsp;&nbsp;
															<asp:CheckBox ID="RememberMe" runat="server" Text="Mantener sesi&oacute;n" Visible="false" />
														</td>
													</tr>
													<tr>
														<td style="text-align:center;" colspan="3">
															&nbsp;
														</td>
													</tr>
													<tr>
														<td style="text-align:center;color:red;font-size:8pt;" colspan="3">
															<asp:Literal ID="FailureText" runat="server" EnableViewState="false" />
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</asp:Panel>
							</LayoutTemplate>
						</asp:Login>
					</td>
					<td style="width:50%;">&nbsp;</td>
				</tr>
			</table>
		</div>
	</form>
</body>
</html>
