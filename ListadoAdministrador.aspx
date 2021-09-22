<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoAdministrador.aspx.cs" Inherits="TOVISIT.APP.ListadoAdministrador" %>

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
            $('#txtCedulaEmpleado').mask('9999999999');
        }
        //FIN MASCARAS DE TEXTBOX
    </script>

    <script type="text/javascript">
        function ajustarContenidoTiempo() {
            setTimeout("ajustarContenido();autoAjustarPadre();", 300);
        };
    </script>
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
                                <h3>
                                    <asp:Button ID="btnNuevo" runat="server" CssClass="button-gray" Font-Bold="true"  Text="Nuevo " Width="120px" OnClick="btnNuevo_Click" />
                                </h3>
                                <p>
                                    LISTADO ADMINISTRADORES</p>
                                <table class="margenCero, paddingCero" cellpadding="0" cellspacing="0" style="width: 100%; border-bottom: solid; border-width: 1px; border-bottom-color: #b6b6b6">
                                    <tr>
                                        <td>
                                            <table class="margenCero, paddingCero" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    
                                                    
                                                         
                                                 <asp:GridView ID="gvAdministrador" runat="server" CssClass="mGrid" AutoGenerateColumns="False" Width="103%"  OnRowDeleting="gvAdministrador_RowDeleting" OnRowDataBound="gvAdministrador_RowDataBound"  DataKeyNames="CODIGO"  OnSelectedIndexChanging="gvAdministrador_SelectedIndexChanging"  >
                                                  
                                                            <Columns>
                                                                 <asp:TemplateField ItemStyle-Width="20px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton runat="server" CommandName="Select"> <i class="fa fa-hand-o-right" aria-hidden="true"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="20px" />
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField ItemStyle-Width="20px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton runat="server" CommandName="Delete"> <i class="fa fa-minus-square" aria-hidden="true"></i></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="CODIGO" HeaderText="CODIGO" Visible="false" SortExpression="CODIGO" />
                                                                <asp:BoundField DataField="USUARIO" HeaderText="Usuario" SortExpression="USUARIO" />                                                               
                                                                <asp:BoundField DataField="APELLLIDOSNOMBRES" HeaderText="Nombre" SortExpression="APELLLIDOSNOMBRES" />
                                                                <asp:BoundField DataField="ESTADO" HeaderText="Estado" Visible="false" SortExpression="ESTADO" />
                                                                
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                    
                                               
                                            </table>
                                        </td>
                                    </tr>
                                </table>

                                <table id="tblCredenciales" runat="server" visible="false" class="margenCero, paddingCero" cellpadding="0" cellspacing="0" style="margin-top: 20px; width: 100%; border-bottom: solid; border-width: 1px; border-bottom-color: #b6b6b6">
                                    
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
