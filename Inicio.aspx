<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TOVISIT.APP.Inicio" %>

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
    <style type="text/css">
        .auto-style1 {
            width: 556px;
            height: 276px;
            margin-top: 0px;
        }
        .auto-style2 {
            font-size: x-large;
        }
        .auto-style3 {
            font-size: xx-large;
        }
    </style>
</head>
<body id="bodyInicio">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table id="tblInicio" runat="server" class="margenCero, paddingCero" cellpadding="0" cellspacing="0" style="overflow: hidden; width: 100%">
                    <tr>
                        <td class="text-center"><span class="auto-style2">Servicio Turístico Para Dispositivos Móviles<br  />
                            <br />
                            </span><br  />
                            <span class="auto-style3">Administración - Tovisit</span><i>
                            <br />
                            <br />
                            <br />
</i>
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <img alt="th"  style="background-size:cover;background-repeat:repeat-x;background-attachment:fixed" longdesc="th" src="images/logo_tovisit.png" />
                            <br />
                            <br />
                            &nbsp;<br /><%--<asp:LinkButton ID="btnValidacion" runat="server" OnClick="btnValidacion_Click">
                                <i class="fa fa-file-text-o" aria-hidden="true" style="font-size:20px"></i> Validación de certificados
                            </asp:LinkButton>--%><%--<asp:LinkButton ID="btnValidacion" runat="server" OnClick="btnValidacion_Click">
                                <i class="fa fa-file-text-o" aria-hidden="true" style="font-size:20px"></i> Validación de certificados
                            </asp:LinkButton>--%></td>
                    </tr>
                </table>
                <table id="tblValidacion" runat="server" visible="false" class="margenCero, paddingCero" cellpadding="0" cellspacing="0" style="overflow: hidden; width: 100%">
                    <tr>
                        <td>
                            <div id="divAlerta" runat="server" visible="false">
                                <i runat="server" id="icoAlerta" class="fa fa-info-circle" aria-hidden="true" style="font-size: 25px"></i>
                                <asp:Label ID="lblAlerta" runat="server" Text="" Font-Size="15px"></asp:Label>
                            </div>
                            <table class="margenCero, paddingCero" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="celdasSeparadas" style="width: 250px">Código de validación:
                                         <span style="color: red">*</span>
                                    </td>
                                   
                                </tr>
                            </table>
                            <table id="tblInfoMedio" runat="server" visible="false" class="margenCero, paddingCero" cellpadding="0" cellspacing="0" style="width: 100%; border-bottom: solid; border-width: 1px; border-bottom-color: #b6b6b6">
                                <tr>
                                    <td>
                                        <h4>Información del código de validación</h4>
                                        <table class="margenCero, paddingCero" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="celdasSeparadas" style="width: 250px">RUC:
                                                        <span style="color: red">*</span>
                                                </td>
                                                <td class="celdasSeparadas">
                                                    <asp:Label CssClass="label_enable" ID="lblRuc" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="celdasSeparadas">Razón social:
                                                        <span style="color: red">*</span>
                                                </td>
                                                <td class="celdasSeparadas">
                                                    <asp:Label CssClass="label_enable" ID="lblRazonSocial" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="celdasSeparadas">Nombre comercial:
                                                        <span style="color: red">*</span>
                                                </td>
                                                <td class="celdasSeparadas">
                                                    <asp:Label CssClass="label_enable" ID="lblNombreComercial" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="celdasSeparadas" colspan="2" style="padding-top: 30px">
                                                    <asp:Label ID="lblEstado" runat="server" Text="El medio de comunicación terminó su proceso de registro con éxito" Font-Size="22px" ForeColor="#00937c"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <%-- LABEL QUE GUARDA EL HEIGHT DE LA PAGINA PARA ASIGNARLO EN EL MENU AL IFRAME --%>
                <asp:Label ID="lblHeightBody" runat="server" CssClass="numTamanoIframe" Text="AQUI VA EL TAMAÑO DE PAGINA"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
