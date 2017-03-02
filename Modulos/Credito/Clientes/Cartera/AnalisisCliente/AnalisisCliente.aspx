<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnalisisCliente.aspx.cs" Inherits="Credito.Clientes.Cartera.UI.AnalisisCliente.AnalisisCliente" MasterPageFile="~/Site.Master" %>

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
        <table border="0" style="width: 100%; padding-left: 14px; padding-top: 5px;">
            <tr>
                <td style="width: 100%;">
                    <table border="0" style="width: 100%; height: 100%">
                        <tr>
                            <td style="text-align: right; vertical-align: middle;">&nbsp;
								<img alt="DAPESA" src="Img/dapesa.png" height="35" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblClaveCliente" runat="server" Text="CLAVE DEL CLIENTE:" CssClass="upperText"/>
                </td>
                <td>
                    <asp:TextBox ID="txtClaveCliente" runat="server" CssClass="upperText" Width="300px" />
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revClaveCliente" runat="server"
                            ControlToValidate="txtClaveCliente" ErrorMessage="*Ingrese valores alfanumericos"
                            ForeColor="Red"
                            ValidationExpression="^([a-zA-Z0-9]{1,20})$">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMontoSolicitado" runat="server" Text="MONTO SOLICITADO:"/>
                </td>
                <td>
                    <asp:TextBox ID="txtMontoSolicitad" runat="server" CssClass="upperText" Width="300px"/>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revMontoSolicitado" runat="server"
                            ControlToValidate="txtMontoSolicitad" ErrorMessage="*Ingrese valores numéricos"
                            ForeColor="Red"
                            ValidationExpression="^[+-]?(?:\d+\.?\d*|\d*\.?\d+)[\r\n]*$">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPlazoRequerido" runat="server" Text="PLAZO P.P. REQUERIDO:"/>
                </td>
                <td>
                    <asp:TextBox ID="txtPlazoRequerid" runat="server"  CssClass="upperText" Width="300px"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMovimientoSolicitado" Width="150" runat="server" Text="MOVIMIENTO SOLICITADO:"/>
                </td>
                <td>
                    <asp:TextBox ID="txtMovimientoSolicitado" runat="server" TextMode="MultiLine" CssClass="upperText" Width="300px"/>
                </td>
                <td>

                </td>
            </tr>         
        </table>
        <asp:UpdatePanel ID="upPanelContenido" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="margin-left:160px;">
                <asp:Button ID="btnVistaPrevia" runat="server" OnClick="btnVistaPrevia_Click" Text="Vista previa"/>
                <asp:Button ID="btnImprimir" runat="server"  Text="Imprimir" OnClientClick="Imprimir('divContenido');return false;" />
                <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar"/>
                </div>
                <div id="divresultado" style="color:red; margin-top:30px; font-weight:bold;">
                <asp:Label ID="lblResultadoConsulta" runat="server"></asp:Label>
                </div>
                <asp:UpdatePanel ID="upPanelMostrar" runat="server">
                    <ContentTemplate>
                        <div id="divPanelContenido" style="width:100%;  padding: 0; overflow: hidden;">
                            <div id="divContenido">
                                <table id="tblContenido">
                                    <tr>
                                        <td  style="height: 3.8cm; text-align: center;"><b style="font-size:14pt;">ANALISIS DE CARTERA POR CLIENTE</b></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 0.5cm; padding: 0cm 0cm 0cm 0.13cm">
                                            <div style="width: 12cm; font-weight:bold;">Informe proporcionado por el depto. de Crédito y Cobranza</div>
                                            <div style="width: 6cm; text-align: center;">SOLICITA EL ANALISIS:</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="tdSolicitaAnalisis" style="height: 1cm; text-align: center; padding: 0cm 0cm 0cm 0.13cm;">
                                            <div style="width: 11cm; height: 0.8cm;"></div>
                                            <div style="width: 0.8cm; height: 0.8cm; line-height: 3; font-size: 7pt;">MJMC</div>
                                            <div style="width: 0.8cm; height: 0.8cm;">
                                                <div id="divMJMC" style="width: 0.4cm; height: 0.4cm; margin: 0.175cm 0.175cm; border: 1px solid black;" class="MarcarCasillas" onclick="MarcarCasillas('divMJMC')" ></div>
                                            </div>
                                            <div style="width: 0.8cm; height: 0.8cm; line-height: 3; font-size: 7pt;">JRPS</div>
                                            <div style="width: 0.8cm; height: 0.8cm;">
                                                <div id="divJRPS" style="width: 0.4cm; height: 0.4cm; margin: 0.175cm 0.175cm; border: 1px solid black;" class="MarcarCasillas" onclick="MarcarCasillas('divJRPS')" ></div>
                                            </div>
                                            <div style="width: 0.8cm; height: 0.8cm; line-height: 3; font-size: 7pt;">DPO</div>
                                            <div style="width: 0.75cm; height: 0.8cm; ">
                                                <div id="divDPO" style="width: 0.4cm; height: 0.4cm; margin: 0.175cm 0.175cm; border: 1px solid black;" class="MarcarCasillas" onclick="MarcarCasillas('divDPO')"></div>
                                            </div>
                                            <div style="width: 0.8cm; height: 0.8cm; line-height: 3; font-size: 7pt;">DAPO</div>
                                            <div style="width: 0.8cm; height: 0.8cm;">
                                                <div id="divDAPO" style="width: 0.4cm; height: 0.4cm; margin: 0.175cm 0.175cm; border: 1px solid black;" class="MarcarCasillas" onclick="MarcarCasillas('divDAPO')"></div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 1cm; padding: 0cm 0cm 0cm 0.13cm">DATOS DE LA SOLICITUD DE CONDICIONES ESPECIALES:</td>
                                    </tr>
                                    <tr>
                                        <td id="tdCambiosCuenta" style="height: 2cm; padding: 0cm 0cm 0cm 0.13cm;">
                                            <div style="width: 4cm; height: 1.3cm; border: 1px solid black; border-right: 1px none black; padding: 5px 5px;">
                                                MOVIMIENTO SOLICITADO:
                                            </div>
                                            <div id="divMovimientoSolicitado" style="width: 6cm; height: 1.3cm; border: 1px solid black; border-left: 1px none black; padding: 5px 5px;" class="upperText">
                                               <asp:Label ID="lblMovimientoSolicitad" runat="server" />
                                            </div>
                                            <div style="width: 2.5cm; padding: 5px 5px;">CONSULTADO EL:</div>
                                            <div style="width: 5.7cm; text-align: center; padding: 5px 0px;">
                                                <asp:Label  ID="lblFechaConsulta" runat="server" Font-Size="9pt"></asp:Label>
                                            </div>
                                            </div>
                                            <div style="width: 2.5cm; height: 0.8cm; line-height: 3; font-size: 7pt; padding: 0px 5px;">UNICO PEDIDO:</div>
                                            <div style="width: 0.8cm; height: 0.8cm;">
                                                <div id="divUPEDIDO" style="width: 0.4cm; height: 0.4cm; margin: 0.175cm 0.175cm; border: 1px solid black;" class="MarcarCasillas" onclick="MarcarCasillas('divUPEDIDO')"></div>
                                            </div>
                                            <div style="width: 2.5cm; height: 0.8cm; line-height: 3; font-size: 7pt; text-align: center;">PERMANENTE:</div>
                                            <div style="width: 0.8cm; height: 0.8cm;">
                                                <div id="divPERMANENTE" style="width: 0.4cm; height: 0.4cm; margin: 0.175cm 0.175cm; border: 1px solid black;" class="MarcarCasillas" onclick="MarcarCasillas('divPERMANENTE')"></div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 0.5cm; margin-top: 0.5cm; padding: 0cm 0cm 0cm 0.13cm">
                                            <div style="width: 3.3cm; height:0.4cm; border: 1px solid black; padding: 0px 5px; border-right-style:none;">MONTO SOLICITADO:</div>
                                            <div style="width: 3.6cm; height:0.4cm; text-align: right; padding: 0px 5px; border: 1px solid black; border-right-style:none;">
                                                <asp:Label ID="lblSetMontoSolicitado" runat="server"></asp:Label>
                                            </div>
                                            <div style="width: 4cm; height:0.4cm; text-align: center; border: 1px solid black; border-right-style:none;">PLAZO P.P. REQUERIDO:</div>
                                            <div style="width: 2.6cm; height:0.4cm; text-align: right; padding: 0px 5px; border: 1px solid black; border-right-style:none;">
                                                <asp:Label ID="lblSetPlazoRequerido" runat="server"></asp:Label>
                                            </div>
                                            <div style="width: 2.5cm; height:0.4cm; text-align: center; border: 1px solid black; border-right-style:none;">No. DE CLIENTE:</div>
                                            <div style="width: 1.6cm; height:0.4cm; text-align: right; padding: 0px 5px; border: 1px solid black;">
                                                <asp:Label ID="lblSetClaveCliente" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 1.5cm; padding: 0cm 0cm 0cm 0.13cm">
                                            <div style="width: 3.4cm; border: 1px solid black; border-bottom-style:none; border-right:none;">NOMBRE DEL CLIENTE:</div>
                                            <div style="width: 9.9cm; border: 1px solid black; border-bottom-style:none; border-right:none;">
                                                <asp:Label ID="lblNombreCliente" runat="server"></asp:Label>
                                            </div>
                                            <div style="width: 1.9cm; text-align: center; border: 1px solid black; border-bottom-style:none; border-right:none;" >CTE. DESDE:</div>
                                            <div style="width: 3.28cm; border: 1px solid black; border-bottom-style:none;" >
                                                <asp:Label ID="lblClienteDesde" runat="server"></asp:Label>
                                            </div>
                                            <div style="width: 3.4cm; border: 1px solid black; border-bottom-style:none; border-right:none;">CIUDAD Y ESTADO:</div>
                                            <div style="width: 7.4cm; border: 1px solid black; border-bottom-style:none; border-right:none;">
                                                <asp:Label ID="lblDireccion" runat="server"></asp:Label>
                                            </div>
                                            <div style="width: 1.4cm; border: 1px solid black; border-bottom-style:none; border-right:none;">AUXILIAR:</div>
                                            <div style="width: 6.28cm; border: 1px solid black; border-bottom-style:none; ">
                                                <asp:Label ID="lblAuxiliar" runat="server" ></asp:Label>
                                            </div>
                                            <div style="width: 3.4cm; border: 1px solid black; border-right-style:none;">OTRAS CUENTAS:</div>
                                            <div style="width: 2.5cm; border: 1px solid black; border-right-style:none;">
                                                <asp:Label ID="lblOtrasCuentas" runat="server" Text="NO"></asp:Label>
                                            </div>
                                            <div style="width: 1.5cm; border: 1px solid black; border-right-style:none;">No. VEND:</div>
                                            <div style="width: 2.8cm; border: 1px solid black; border-right-style:none;">
                                                <asp:Label ID="lblClaveVendedor" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div style="width: 1.7cm; border: 1px solid black; border-right-style:none;">VENDEDOR:</div>
                                            <div style="width: 6.25cm; border: 1px solid black;">
                                                <asp:Label ID="lblNombreVendedor" runat="server" Text=""></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 0.5cm; padding: 0cm 0cm 0cm 0.13cm">
                                            <div style="width:9cm; float:left;">
                                                EN LA CUENTA QUE SOLICITA EL CLIENTE:
                                            </div>
                                            <div style="width:9.8cm; float:left; text-align:center;">
                                                OBSERVACIONES:
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height:2cm;"> 
                                            <table style="border-collapse:collapse; font-size:8pt; margin-left:0.1cm;"> 
                                                <tr>    
                                                    <td style="width: 4.5cm; padding: 0px 5px; border:1px solid black; border-right-style:none; border-bottom-style:none;"> 
                                                        SALDO DEUDOR A LA FECHA:
                                                    </td>
                                                    <td style="width: 4cm; padding: 0px 5px; border:1px solid black; border-right-style:none; border-bottom-style:none;"> 
                                                        <asp:Label ID="lblSaldoDeudor" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td rowspan="4" style="width:9.87cm; font-size:7pt; border-color:black; border:1px solid black; padding: 0px 0px 0px 0.1cm;">
                                                        <asp:Label ID="lblDescripcionCliente" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>    
                                                    <td style="width: 4.5cm; padding: 0px 5px; border:1px solid black; border-right-style:none; border-bottom-style:none;"> 
                                                        LIMITE DE CREDITO:
                                                    </td>
                                                    <td style="width: 4cm; padding: 0px 5px; border:1px solid black; border-right-style:none; border-bottom-style:none;"> 
                                                        <asp:Label ID="lblLimiteCredito" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>    
                                                    <td style="width: 4.5cm; padding: 0px 5px; border:1px solid black; border-right-style:none; border-bottom-style:none;"> 
                                                        PLAZO CON PRONTO PAGO:
                                                    </td>
                                                    <td style="width: 4cm; padding: 0px 5px; border:1px solid black; border-right-style:none; border-bottom-style:none;"> 
                                                        <asp:Label ID="lblPlazoProntoPago" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>    
                                                    <td style="width: 4.5cm; padding: 0px 5px; border:1px solid black; border-right-style:none;"> 
                                                        DESCUENTOS AUTORIZADOS:
                                                    </td>
                                                    <td style="width: 4cm; padding: 0px 5px; border:1px solid black; border-right-style:none;"> 
                                                        <asp:Label ID="lblDescuentoAutorizado" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>                                        
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 0.5cm; padding: 0cm 0cm 0cm 0.13cm">COMPRAS EN EL ULTIMO AÑO: (Considerar si el cliente pagó con pronto pago o sin descuento).
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:18.6cm">
                                            <asp:GridView ID="gvVenta" runat="server" CssClass="gvVenta" OnRowDataBound="gvVenta_RowDataBound"/>
                                            <%--FILA TOTALES--%>
                                            <%--   <table style="border-collapse:collapse;margin-left:0.13cm; width:18.6cm">
                                                <tr>
                                                <td style="width:2.7cm; border:1px solid #323232; border-top-style:none;">TOTAL</td>
                                                <td style="width:4.1cm; border:1px solid #323232; border-top-style:none;">$ 432.545</td>
                                                <td style="width:1.8cm; border:1px solid #323232; border-top-style:none;">PROMEDIO</td>
                                                <td style="width:1.8cm; border:1px solid #323232; border-top-style:none;">Por meses:</td>
                                                <td style="width:3cm;   border:1px solid #323232; border-top-style:none;">$564668.6156</td>
                                                <td style="width:1.8cm; border:1px solid #323232; border-top-style:none;">Por Compras:</td>
                                                <td style="width:3.15cm; border:1px solid #323232; border-top-style:none;">$564668.6156</td>
                                                </tr>
                                            </table>--%>
                                            <div style="width:2.97cm; margin-left:0.135cm; border:1px solid black; border-right-style:none; border-top-style:none;">TOTAL</div>
                                            <div style="width:3.8cm; border:1px solid black; border-right-style:none; border-top-style:none; text-align:right; padding:0px 3px 0px 0px;">
                                                <asp:Label ID="lblTotalImporte" runat="server"/>
                                            </div>
                                            <div style="width:1.8cm; border:1px solid black; border-right-style:none; border-top-style:none;">PROMEDIO</div>
                                            <div style="width:1.8cm; border:1px solid black; border-right-style:none; border-left-style:none; border-top-style:none;">Por meses:</div>
                                            <div style="width:3cm;   border:1px solid black; border-right-style:none; border-top-style:none; text-align:right; padding: 0px 5px 0px 0px;">
                                                <asp:Label ID="lblPromedioImporte" runat="server"/>
                                            </div>
                                            <div style="width:1.85cm; border:1px solid black; border-right-style:none; border-top-style:none;">Por Compras:</div>
                                            <div style="width:2.85cm; border:1px solid black; border-top-style:none; text-align:right; padding:0px 5px 0px 0px;">
                                                <asp:Label ID="lblPromedioCompras" runat="server"/>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height:1.5cm; padding: 0cm 0cm 0cm 0.13cm">
                                            <br />
                                            <table id="tblComentarios" style="width:19.15cm; border-collapse:collapse;">
                                                <tr>
                                                    <td style="width:4.5cm;">
                                                        COMENTARIOS DEL AUXILIAR:
                                                    </td>
                                                    <td id="tdComentarioAuxiliar" style="width:10.8cm;">
                                                        <input id="txtComentarioAuxiliar" type="text" style="width:99%; color:black;" class="MarcarCasillas"/>
                                                    </td>
                                                    <td style="width:1.1cm;">
                                                        Viable:
                                                    </td>
                                                    <td style="width:0.5cm;">
                                                        SI:
                                                    </td>
                                                    <td id="tdAuxiliarSI" class="MarcarCasillas" onclick="MarcarCasillas('tdAuxiliarSI')" style="width:0.5cm;">
                                                    </td>
                                                    <td style="width:0.5cm;">
                                                        NO:
                                                    </td>
                                                    <td id="tdAuxiliarNO" class="MarcarCasillas" onclick="MarcarCasillas('tdAuxiliarNO')" style="width:0.5cm;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        COMENTARIOS DEL GERENTE:
                                                    </td>
                                                    <td id="tdCometarioGerente">
                                                        <input id="txtComentarioGerente" type="text" style="width:99%; color:black;" class="MarcarCasillas"/>
                                                    </td>
                                                    <td>
                                                        Viable:
                                                    </td>
                                                    <td>
                                                        SI:
                                                    </td>
                                                    <td id="tdGerenteSI" class="MarcarCasillas" onclick="MarcarCasillas('tdGerenteSI')">
                                                    </td>
                                                    <td>
                                                        NO:
                                                    </td>
                                                    <td id="tdGerenteNO" class="MarcarCasillas" onclick="MarcarCasillas('tdGerenteNO')">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        COMENTARIOS DEL DIRECTOR:
                                                    </td>
                                                    <td id="tdComentarioDirector">
                                                        <input id="txtComentarioDirector" type="text" style="width:99%; color:black;" class="MarcarCasillas"/>
                                                    </td>
                                                    <td>
                                                        Viable:
                                                    </td>
                                                    <td>
                                                        SI:
                                                    </td>
                                                    <td id="tdDirectorSI" class="MarcarCasillas" onclick="MarcarCasillas('tdDirectorSI')">
                                                    </td>
                                                    <td>
                                                        NO:
                                                    </td>
                                                    <td id="tdDirectorNO" class="MarcarCasillas" onclick="MarcarCasillas('tdDirectorNO')">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:center;">
                                            <br />
                                            <table style="width:100%;text-align:center;">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblElaboro" runat="server"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                 <tr>
                                                    <td>ELABORÓ AUX. DE CREDITO.</td>
                                                    <td>Vo. Bo. GERENTE CREDITO</td>
                                                    <td>AUTORIZA DIRECCIÓN</td>
                                                </tr>
                                            </table>                                          
                                        </td>
                                    </tr>     
                                </table>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <script type="text/javascript">
                    function Imprimir(idElemento) {
                       
                        if (VerificaCasillasMarcadas() == true)
                        {
                            document.getElementById("tdSolicitaAnalisis").style.borderWidth = "0px";
                            document.getElementById("tdCambiosCuenta").style.borderWidth = "0px";
                            document.getElementById("tdComentarioAuxiliar").innerHTML = document.getElementById("txtComentarioAuxiliar").innerHTML;
                            document.getElementById("tdCometarioGerente").innerHTML = document.getElementById("txtComentarioGerente").innerHTML;
                            document.getElementById("tdComentarioDirector").innerHTML = document.getElementById("txtComentarioDirector").innerHTML;
                            ventana = window.open("", "", "width=800,height=1000");
                            contenido = document.getElementById('divContenido').innerHTML;
                            ventana.document.open();
                            ventana.document.write("<html><head><link rel='stylesheet' href='Css/HojaEstilosImpresion.css' type='text/css'/> </head><body  onload='window.print();window.close();' onunload='alert('hola');'>" + contenido + "</body></html>");
                            ventana.document.close();
                            document.getElementById('divContenido').style.display = "none";
                            $("#<%=btnImprimir.ClientID%>").css("display", "none");
                        }                       
                    }

                    function MarcarCasillas(idElemento) {

                        var texto = document.getElementById(idElemento).innerHTML;
                        
                        if(texto == "X")
                        {
                            document.getElementById(idElemento).innerHTML= "";
                        }
                        else
                        {
                            document.getElementById(idElemento).innerHTML = "X";
                        }
                    }
                    
                    function  VerificaCasillasMarcadas()
                    {
                        var divMJMC = document.getElementById('divMJMC').innerHTML;
                        var divJRPS = document.getElementById('divJRPS').innerHTML;
                        var divDPO = document.getElementById('divDPO').innerHTML;
                        var divDAPO = document.getElementById('divDAPO').innerHTML;
                        var divUPEDIDO = document.getElementById('divUPEDIDO').innerHTML;
                        var divPERMANENTE = document.getElementById('divPERMANENTE').innerHTML;

                        if (divMJMC == "X" || divJRPS == "X" || divDPO == "X" || divDAPO == "X")
                        {                            

                            if (divUPEDIDO == "X" || divPERMANENTE == "X")
                            {
                                document.getElementById("divresultado").innerHTML = "";
                                return true;
                            }
                            else
                            {
                                document.getElementById("tdSolicitaAnalisis").style.borderWidth = "0px";
                                document.getElementById("tdCambiosCuenta").style.border = "1px solid red";
                                document.getElementById("divresultado").innerHTML = "Seleccione una opción en el área de color rojo.";
                                return false;
                            }
                            
                        }
                        else
                        {
                            document.getElementById("tdCambiosCuenta").style.borderWidth = "0px";
                            document.getElementById("tdSolicitaAnalisis").style.border = "1px solid red";
                            document.getElementById("divresultado").innerHTML = "Seleccione una opción en el área de color rojo.";
                            return false;
                        }
                    }
                </script>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSalir" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnVistaPrevia" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnLimpiar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
