<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportesPrueba.aspx.cs" Inherits="CORD.EVALDTH.ReportesPrueba" %>

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
            $('#txtFecha').mask('9999-99-99');
        }
        //FIN MASCARAS DE TEXTBOX
    </script>

    <script type="text/javascript">
        function ajustarContenidoTiempo() {
            setTimeout("ajustarContenido();autoAjustarPadre();", 300);
        };
    </script>
    </head>
<body id="bodyInicio" onload="mascaraTextBox()" style="height: 821px">
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

                                <table  class="margenCero, paddingCero" cellpadding="0" cellspacing="0" style="width: 100%; border-bottom: 1px solid #b6b6b6; height: 215px; border-left-width: 1px; border-right-width: 1px; border-top-width: 1px;">
                                    <tr>
                                        <td>

                                            <table align="center" >
                                                <tr>
                                                    <td>
                                                        <strong>Filtrar Unidad Administrativa : </strong><span style="color: red">* </span>
                                                        <asp:TextBox ID="txtInfoT" runat="server" CssClass="textbox" Style="text-transform: uppercase" Width="272px"></asp:TextBox>
                                                    <asp:LinkButton ID="btnBuscar" runat="server" OnClick="btnBuscar_Click">
                                                            <i aria-hidden="true" class="fa fa-search" style="font-size:19px"></i>
                                </asp:LinkButton>
                                                    </td>
                                                </tr>
                                                 <table id="tblResultados" runat="server" cellpadding="0" cellspacing="0" class="margenCero, paddingCero" style="width: 100%; border-bottom: solid; border-width: 1px; border-bottom-color: #b6b6b6" visible="false">
                                               
                                              
                                                <tr>
                                                    <td>
                                                        <h2 style="text-align: center">Reportes Evaluación Individual Período de Prueba</h2>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>

                                                        <asp:GridView ID="gvEvaluacion" runat="server" CssClass="mGrid" AutoGenerateColumns="False" Width="100%"   HorizontalAlign="Center" DataKeyNames="ID_CABECERA"  OnSelectedIndexChanging="gvEvaluacion_SelectedIndexChanging">

                                                            <Columns>

                                                                <asp:TemplateField ItemStyle-Width="20px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton runat="server" CommandName="Select">
                                                                                    <i class="fa fa-hand-o-right" aria-hidden="true"></i>
                                                                        </asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="20px" />
                                                                </asp:TemplateField>

                                                                
                                                                 <asp:BoundField DataField="ID_CABECERA" HeaderText="ID_CABECERA" Visible="false" SortExpression="ID_CABECERA" />
                                                                 <asp:BoundField DataField="PERIODO" HeaderText="Periodo" SortExpression="PERIODO" />
                                                                 <asp:BoundField DataField="CEDULA" HeaderText="Cédula" SortExpression="CEDULA" />
                                                                 <asp:BoundField DataField="APELLLIDOSNOMBRES" HeaderText="Apellidos - Nombres" SortExpression="APELLLIDOSNOMBRES" />
                                                                 <asp:BoundField DataField="NOMBRE_UNIDAD" HeaderText="Unidad" SortExpression="NOMBRE_UNIDAD" />
                                                                 <asp:BoundField DataField="DESCRIPCION_PUESTO" HeaderText="Puesto" SortExpression="DESCRIPCION_PUESTO" />
                                                                 <asp:BoundField DataField="DESCRIPCION_GRUPO" HeaderText="Grupo" SortExpression="DESCRIPCION_GRUPO" />
                                                                 <asp:BoundField DataField="ROL" HeaderText="Rol" SortExpression="ROL" />
                                                                 <asp:BoundField DataField="DIRECTOR" HeaderText="Jefe Inmediato" SortExpression="DIRECTOR" />
                                                                 <asp:BoundField DataField="IDENTIFICACION" HeaderText="Identificación" SortExpression="IDENTIFICACION" />


                                                            </Columns>

                                                        </asp:GridView>
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
        </div>
    </form>
</body>
</html>
