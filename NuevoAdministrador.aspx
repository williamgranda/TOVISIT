<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevoAdministrador.aspx.cs" Inherits="TOVISIT.APP.NuevoAdministrador" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
        //ONKEYPRESS
        function validarNumero(e) {
            tecla = (document.all) ? e.keycode : e.which;
            if (tecla == 8) return true;
            alfanumerico = /[0-9]/;
            text = String.fromCharCode(tecla);
            return alfanumerico.test(text);
        }
        //FIN ONKEYPRESS

        //MASCARAS DE TEXTBOX
        function mascaraTextBox() {
            $('#txtFechaInicio').mask('####-##-##');
            $('#txtFechaFinal').mask('####-##-##');
        }
        //FIN MASCARAS DE TEXTBOX
    </script>

    <script type="text/javascript">
        function ajustarContenidoTiempo() {
            setTimeout("ajustarContenido();autoAjustarPadre();", 300);
        };
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 11px;
        }

        .auto-style2 {
            padding-bottom: 5px;
            height: 82px;
        }
    </style>
</head>
<body id="bodyInicio" onload="mascaraTextBox()">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="margenCero, paddingCero" cellpadding="0" cellspacing="0" style="overflow: hidden; width: 100%">
                        <tr>
                            <td>
                                <hr style="margin-top: 5px; border-color: #3E5367; border-width: 4px" />
                                <div id="divAlerta" runat="server" visible="false">
                                    <i runat="server" id="icoAlerta" class="fa fa-info-circle" aria-hidden="true" style="font-size: 25px"></i>
                                    <asp:Label ID="lblAlerta" runat="server" Text="" Font-Size="15px"></asp:Label>
                                </div>

                                <div align="center">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                        <ProgressTemplate>
                                            <img src="images/Cargando.gif" width="50" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </div>
                                <h3>Crear - Editar Usuarios</h3>
                                <table class="margenCero, paddingCero" cellpadding="0" cellspacing="0" style="width: 100%; border-bottom: solid; border-width: 1px; border-bottom-color: #b6b6b6">
                                    <tr>
                                        <td>
                                            <table class="margenCero, paddingCero" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="celdasSeparadas">Usuario</td>
                                                    <td class="celdasSeparadas">
                                                        <asp:TextBox ID="txtUsuario" runat="server" Width="235px" ></asp:TextBox>

                                                        <asp:TextBox ID="txtContrasena" runat="server" Enabled="False"></asp:TextBox>

                                                    </td>
                                                    <td class="celdasSeparadas">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="celdasSeparadas">Correo Electrónico:</td>
                                                    <td class="celdasSeparadas">
                                                        <asp:TextBox ID="txtCorreo" runat="server" Width="231px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="celdasSeparadas">Tipo:</td>
                                                    <td class="celdasSeparadas">
                                                        <asp:DropDownList ID="ddlTipo" runat="server">
                                                            <asp:ListItem>Seleccione..</asp:ListItem>
                                                            <asp:ListItem Text="Administrador" Value="4"></asp:ListItem>
                                                            <asp:ListItem Text="Director" Value="3"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                
                                                    <td class="auto-style2" align="center" colspan="2" style="padding-top: 30px">
                                                        <asp:Button ID="btnGuardar" runat="server" CssClass="button-gray" Font-Bold="true" OnClick="btnGuardar_Click" Text="Guardar" Width="120px" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnModificar" runat="server" CssClass="button-gray" Font-Bold="true" Visible="false" OnClick="btnModificar_Click" Text="Modificar" Width="120px" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnCancelar" runat="server" CssClass="button-gray" Font-Bold="true" OnClick="btnCancelar_Click" Text="Cancelar" Width="120px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>

                                <table id="tblCredenciales" runat="server" visible="false" class="margenCero, paddingCero" cellpadding="0" cellspacing="0" style="margin-top: 20px; width: 100%; border-bottom: solid; border-width: 1px; border-bottom-color: #b6b6b6">
                                    <tr>
                                        <td class="auto-style1">&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <%-- LABEL QUE GUARDA EL HEIGHT DE LA PAGINA PARA ASIGNARLO EN EL MENU AL IFRAME --%>
                    <asp:Label ID="lblHeightBody" runat="server" CssClass="numTamanoIframe" Text="AQUI VA EL TAMAÑO DE PAGINA"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
