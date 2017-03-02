<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Dapesa.Credito.Facturas.IU.NoParte.Error" MasterPageFile="~/Site.Master" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="cContenido" ContentPlaceHolderID="cphContenidoPrincipal" runat="server">
	<div>
		<table style="width:100%;">
			<tr>
				<td style="color:red;">
					<asp:Label ID="lblMensaje" runat="server" Text="" />
				</td>
			</tr>
		</table>
	</div>
</asp:Content>
