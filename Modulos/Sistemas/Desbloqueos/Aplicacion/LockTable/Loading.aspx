<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loading.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Sistemas.Desbloqueos.IU.LockTable.Loading" %>

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
                <asp:CheckBox ID="chkRefresh" CssClass="material-switch pull-left" runat="server" Text=" " OnCheckedChanged="chkRefresh_CheckedChanged" AutoPostBack="true" />
                <asp:Label ID="Label2" Style="padding-left: 15px;" runat="server" Text="Actualizar automático"></asp:Label>
            </div>
            <div class="col-lg-2"></div>
        </div>
        <asp:UpdatePanel ID="uPanelSeller" runat="server">
            <ContentTemplate>
                <asp:Panel runat="server" CssClass="panel-group" ScrollBars="Vertical">
                    <div style="height: 490px;">
                        <asp:GridView ID="gvProcesos" runat="server" CssClass="table table-condensed" GridLines="None" BorderStyle="None" Width="100%"
                            Style="font-size: 12px;" EmptyDataText="No se encontraron vendedores conectados." ShowHeaderWhenEmpty="True" OnRowDataBound="gvProcesos_RowDataBound">
                            <HeaderStyle CssClass="GridHeader" />
                        </asp:GridView>
                    </div>
                </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

