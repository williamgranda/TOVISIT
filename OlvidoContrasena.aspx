<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OlvidoContrasena.aspx.cs" Inherits="TOVISIT.APP.OlvidoContrasena" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Evaluación del Desempeño</title>
    <link rel="shortcut icon" href="images/favicon.ico" />
    <link href="css/General.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

    <script type="text/javascript">
        //AJUSTA CONTENIDO A LA PANTALLA
        function autoAjustarPadre() {
            window.parent.ajutarDesdeIframe();
            var ancho = document.getElementById('bodyInicio').scrollWidth;
            $("#divLabTrabajadores").width(ancho - 150);
        }

        function ajustarContenido() {
            var alto = document.getElementById('bodyInicio').scrollHeight;
            document.getElementById('lblHeightBody').textContent = alto;
        }

        $(window).resize(function () {
            var alto = document.getElementById('bodyInicio').scrollHeight;
            document.getElementById('lblHeightBody').textContent = alto;
            ajustarContenidoTiempo();
        });

        $(document).ready(function () {
            var alto = document.getElementById('bodyInicio').scrollHeight;
            document.getElementById('lblHeightBody').textContent = alto;
        });
        //FIN AJUSTA CONTENIDO A LA PANTALLA
    </script>

    <script type="text/javascript">
        function ajustarContenidoTiempo() {
            setTimeout("ajustarContenido();autoAjustarPadre();", 300);
        };
    </script>

    <script type="text/javascript">
        function textboxSinValidar(id, color) {
            document.getElementById(id).style.backgroundColor = color;
            cambiaValorColor(color);
        }

        function cambiaValorColor(color) {
            $("#<%= hfdIdColor.ClientID %>").val(color);
        }
    </script>
</head>
<body id="bodyInicio">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="margenCero, paddingCero" cellpadding="0" cellspacing="0" style="overflow: hidden; width: 100%">
                        <tr>
                            <td>
                                <div id="divAlerta" runat="server" visible="false">
                                    <i runat="server" id="icoAlerta" class="fa fa-info-circle" aria-hidden="true" style="font-size: 25px"></i>
                                    <asp:Label ID="lblAlerta" runat="server" Text="" Font-Size="15px"></asp:Label>
                                </div>
                                <h3>Ingrese los datos solicitados para el envío de su contraseña</h3>
                                <table class="margenCero, paddingCero" cellpadding="0" cellspacing="0" style="width: 100%; border-bottom: solid; border-width: 1px; border-bottom-color: #b6b6b6">
                                    <tr>
                                        <td>
                                            <table class="margenCero, paddingCero" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="celdasSeparadas" style="width: 200px">Correo electrónico registrado:
                                                        <span style="color: red">*</span>
                                                    </td>
                                                    <td class="celdasSeparadas">
                                                        <asp:TextBox CssClass="textbox" ID="txtCorreoElectronico" runat="server" Width="300px" onkeyup="textboxSinValidar('txtCorreoElectronico', '#FFFFFF')"></asp:TextBox>                                                        
                                                    </td>
                                                    <td class="celdasSeparadas" style="vertical-align:bottom">
                                                        <asp:LinkButton ID="btnValidar" runat="server" OnClick="btnValidar_Click">
                                                            <i class="fa fa-check-square" aria-hidden="true" style="font-size:20px"></i>
                                                        </asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="celdasSeparadas" colspan="2" style="padding-top: 30px">
                                                        <asp:Button ID="btnEnviar" CssClass="button-gray" runat="server" Text="Enviar" Width="120px" Font-Bold="true" OnClick="btnEnviar_Click" />
                                                    </td>
                                                </tr>                                                
                                            </table>
                                        </td>
                                    </tr>
                                </table>                                                                
                            </td>
                        </tr>
                    </table>
                    <%--MANTENER EL COLOR DEL TEXTBOX EN EL POSTBACK--%>
                    <asp:HiddenField ID="hfdIdColor" runat="server" Value="#FFFFFF" />
                    <%-- LABEL QUE GUARDA EL HEIGHT DE LA PAGINA PARA ASIGNARLO EN EL MENU AL IFRAME --%>
                    <asp:Label ID="lblHeightBody" runat="server" CssClass="numTamanoIframe" Text="AQUI VA EL TAMAÑO DE PAGINA"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
