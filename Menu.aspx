<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="TOVISIT.APP.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>TOVISIT</title>
    <link rel="shortcut icon" href="images/favicon.ico" />
    <link href="css/General.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.min.js"></script>

    <script type="text/javascript">
        //AJUSTA CONTENIDO A LA PANTALLA
        function autoAjustar(e) {
            $('#ifContenedor').height(e - 85);
            $('#cuerpo').height(e - 80);
        }

        function ajustarContenido() {
            $height = $(window).height();
            autoAjustar($height)
        }

        $(window).resize(function () {
            setTimeout(ajustarContenido(), 2000);
        });

        $(document).ready(function () {
            setTimeout(ajustarContenido(), 2000);
        });
        //FIN AJUSTA CONTENIDO A LA PANTALLA

        function tamanoPantalla() {
            var width = $(window).width();
            var height = $(window).height();
            alert('ancho = ' + width + '; alto = ' + height);
        }

        $(function () {
            // elementos de la lista
            var menues = $('#divMenu a');
            // manejador de click sobre todos los elementos
            menues.click(function () {
                // eliminamos active de todos los elementos
                menues.removeClass('active');
                // activamos el elemento clicado.
                $(this).addClass('active');
            });

        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="margenCero, paddingCero" cellpadding="0" cellspacing="0" style="min-width: 870px; width: 100%">
                    <tr>
                        <%--FRANJA SUPERIOR - TITULO BOTONES LOGIN FB TWITTER--%>
                        <td style="background-color: #444444; width: 100%; height: 60px">
                            <table style="width: 100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 70%">
                                        <table style="width: 100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="padding: 10px; background: linear-gradient( 90deg, #fff, #444444)">
                                                    <asp:Image ID="imgLogo" runat="server" Height="60px" ImageUrl="~/images/Logo3.png" />
                                                </td>
                                                <td>
                                                    <div align="center" style="font-size: 28px; color: white">
                                                        Evaluación del Desempeño
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="center" style="width: 30%">
                                        <table style="width: 50%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 25%">
                                                    <div align="center">
                                                        <asp:LinkButton CssClass="fa6 fa-user-circle-o" ID="btnUsuario" OnClientClick="tamanoPantalla()" Font-Underline="false" runat="server"></asp:LinkButton>
                                                    </div>
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="lblUsuario" runat="server" ForeColor="White" Font-Size="Large" Text="10488962015"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <%--CONTENEDOR DE PÁGINAS--%>
                        <td style="width: 100%; vertical-align: top">
                            <table id="cuerpo" style="width: 100%" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="center" style="width: 17%">
                                        <table class="navigationBar" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="center" style="vertical-align:top">
                                                    <div id="divMenu" class="vertical-menu">
                                                        <a href="Inicio.aspx" target="ifContenedor" class="active">Inicio</a>
                                                        <a href="Certificado.aspx" target="ifContenedor">Certificado</a>
                                                        <a href="#" target="ifContenedor">Consulta Registro</a>
                                                        <a href="#" target="ifContenedor">Modificación Registro</a>
                                                        <a href="#" target="ifContenedor">Administración Permisos</a>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 0.5%; background: linear-gradient( 90deg, #171717, #000)"></td>
                                    <td style="width: 0.5%; background: linear-gradient( 90deg, #000, #fff)"></td>
                                    <td align="center" style="vertical-align: top">
                                        <iframe name="ifContenedor" id="ifContenedor" src="Inicio.aspx" class="contenedor"></iframe>
                                    </td>

                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
