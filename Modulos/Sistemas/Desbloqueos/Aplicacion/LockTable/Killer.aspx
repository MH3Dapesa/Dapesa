<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Killer.aspx.cs" Inherits="Dapesa.Sistemas.Desbloqueos.IU.LockTable.Killer" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="cEncabezado" ContentPlaceHolderID="cphEncabezado" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, user.scalable=no, initial-scale=1.0, minimun-sacale=1.0, maximun-scale=1.0" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="stylesheet" href="css/font-awesome.css" />
    <link rel="stylesheet" href="css/font-awesome.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/jquery-1.9.1.js"></script>
    <script src="js/jquery-1.9.1.min.js"></script>

    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <style>
        .GridHeader {
            color: white;
            background-color: #4d7893;
            font-weight: bold;
            font-size: 12px;
        }
    </style>
</asp:Content>

<asp:Content ID="cContenido" ContentPlaceHolderID="cphContenidoPrincipal" runat="server">
    <div class="container-fluid">
        <div class="row" style="margin: 10px;">
            <div class="col-lg-1">
                <asp:LinkButton ID="lnkActualizar" runat="server" Text="<i class='fa fa-refresh'> Refrescar </i>" CssClass="btn btn-default" OnClick="lnkActualizar_Click" />
            </div>
            <div class="col-lg-9">
                <asp:CheckBox ID="chkRefresh" CssClass="material-switch pull-left" runat="server" Text=" " OnCheckedChanged="chkRefresh_CheckedChanged" AutoPostBack="true"/>
                <asp:Label ID="Label2" Style="padding-left: 15px;" runat="server" Text="Actualizar automático"></asp:Label>
            </div>
            <div class="col-lg-2"></div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel runat="server" CssClass="panel-group" ScrollBars="Vertical">
                    <div style="height: 500px;">
                        <asp:GridView ID="gvBloqueadas" runat="server" CssClass="table table-condensed" Width="100%" GridLines="None" BorderStyle="None"
                            Style="font-size: 12px;" OnRowDataBound="gvBloqueadas_RowDataBound" OnRowCommand="gvBloqueadas_RowCommand" EmptyDataText="No se encontraron transacciones activas." ShowHeaderWhenEmpty="True">
                            <HeaderStyle CssClass="GridHeader" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="btn-group">
                                            <asp:LinkButton ID="lnkDesconectar" runat="server" Width="50%" CssClass="btn btn-warning" ToolTip="Desconectar proceso!" Font-Size="13px" Text="<i class='text-warning'><i class='fa fa-chain-broken' style='color:white;'></i></i>" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Desconectar" />
                                            <asp:LinkButton ID="lnkMatar" runat="server" Width="50%" CssClass="btn btn-danger" ToolTip="Matar proceso!" Font-Size="13px" Text="<i class='text-danger'><i class='fa fa-times' style='color:white;'></i></i>" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Matar" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
                <asp:Panel runat="server" ID="pNotificacion" Style="text-align: center;">
                    <asp:Label ID="lblUsuario" runat="server" Text="" />
                </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
</asp:Content>
