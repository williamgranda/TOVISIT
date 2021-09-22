<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TOVISIT.APP.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>TOVISIT</title>

    <link rel="shortcut icon" href="images/favicon.ico" />
    <link href="css/General.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/nprogress.css" rel="stylesheet" type="text/css" />
    <link href="css/custom.min.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function redireccionar(ruta) {
            alert('entra ' + ruta);
            var iframe = document.getElementById("ifContenedor");
            iframe.setAttribute("src", ruta);
            alert('salida');
        }
    </script>
</head>
<body class="nav-md">
    <form id="form1" runat="server">
        <div class="container body">
            <div class="main_container">
                <div class="col-md-3 left_col">
                    <div class="left_col scroll-view">

                        <div class="clearfix"></div>

                        <!-- menu profile quick info -->
                        <div class="profile clearfix">
                            <div class="profile_pic">
                                <img src="images/Tovisit.png" alt="..."  />
                            </div>
                            
                            <div class="clearfix"></div>
                        </div>
                        <!-- /menu profile quick info -->

                        <br />

                        <!-- sidebar menu -->
                        <div id="sidebar-menu" class="main_menu_side hidden-print main_menu">
                            <div class="menu_section">
                                <h3>General</h3>
                                <ul class="nav side-menu">
                                    <li id="mdlInicio"><a target="ifContenedor" href="Inicio.aspx"><i class="fa fa-home"></i>Inicio</a>
                                     
                                    </li>
                                    <li runat="server" id="mdlRegistro" visible="false"><a><i class="fa fa-edit"></i>Procesos Unidad <span class="fa fa-chevron-down"></span></a>
                                        <ul class="nav child_menu">
                                            <li><a target="ifContenedor" href="ListadoEmpleado.aspx">Listado Servidores/as Unidad</a></li>
                                            <li runat="server" id="fmlRegConsulta" visible="false"><a target="ifContenedor" href="Evaluacion.aspx">Asignación de Responsabilidades</a></li>
                                            <li runat="server" id="fmlRegModificacion" visible="false"><a target="ifContenedor" href="EvaluacionPrueba.aspx">Asignación de Responsabilidades Período de Prueba</a></li>
                                            <li runat="server" id="fmlRegCalificacionN" visible="false"><a target="ifContenedor" href="Calificacion.aspx">Niveles de Eficiencia</a></li>
                                            <li runat="server" id="fmlRegCalificacionP" visible="false"><a target="ifContenedor" href="CalificacionPrueba.aspx">Niveles de Eficiencia - Prueba</a></li>
                                            <li><a target="ifContenedor" href="MetasUnidad.aspx">Metas por Unidad</a></li>
                                              <li><a target="ifContenedor" href="MatrizCorrelacion.aspx">Nivel de Satisfacción Usuarios Internos</a></li>



                                        </ul>
                                    </li>
                                    <li runat="server" id="mdlAdministracion" visible="false"><a><i class="fa fa-desktop"></i>Administración <span class="fa fa-chevron-down"></span></a>
                                        <ul class="nav child_menu">

                                            <li><a target="ifContenedor" href="ListadoAdministrador.aspx">Crear Usuarios</a></li>
                                              <li><a target="ifContenedor" href="ListadoTipo.aspx">Tipo de Lugar</a></li>
                                            <li><a target="ifContenedor" href="ListadoLugares.aspx">Lugares</a></li>
                                            <li><a target="ifContenedor" href="ListadoActividad.aspx">Actividades</a></li>
                                            
                                             
                                        </ul>
                                    </li>
                                   
                                    <li runat="server" id="mdlReportes" visible="false"><a><i class="fa fa-bar-chart"></i>Reportes <span class="fa fa-chevron-down"></span></a>
                                        <ul class="nav child_menu">
                                            <li><a target="ifContenedor" href="ReportesAdministrador.aspx">Reportes Evaluación Individual</a></li>
                                             <li><a target="ifContenedor" href="Reportes/Consolidado.aspx">Reportes Consolidado Evaluación Individual</a></li>
                                            
                                        
                                        
                                        </ul>
                                    </li>
                                    <li runat="server" id="mdlCertificado" visible="false"><a target="ifContenedor" href="Manuales/Manual de Usuario V2.0.pdf"><i class="fa fa-file-text-o"></i>Manual Usuario</a>


                                    </li>
                                    <%--<li><a><i class="fa fa-clone"></i>Layouts <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="fixed_sidebar.html">Fixed Sidebar</a></li>
                      <li><a href="fixed_footer.html">Fixed Footer</a></li>
                    </ul>
                  </li>--%>
                                </ul>
                            </div>
                        </div>
                        <!-- /sidebar menu -->

                        <!-- /menu footer buttons -->
                        <div class="sidebar-footer hidden-small">
                            <a data-toggle="tooltip" data-placement="top" style="width: 100%" title="Ayuda" target="_blank" href="https://www.youtube.com/watch?v=gL0EldTobfc">
                                <span class="glyphicon glyphicon-question-sign" aria-hidden="true"></span>
                            </a>
                            <%--<a data-toggle="tooltip" data-placement="top" title="FullScreen">
                                <span class="glyphicon glyphicon-fullscreen" aria-hidden="true"></span>
                            </a>
                            <a data-toggle="tooltip" data-placement="top" title="Lock">
                                <span class="glyphicon glyphicon-eye-close" aria-hidden="true"></span>
                            </a>
                            <a data-toggle="tooltip" data-placement="top" title="Logout" href="login.html">
                                <span class="glyphicon glyphicon-off" aria-hidden="true"></span>
                            </a>--%>
                        </div>
                        <!-- /menu footer buttons -->
                    </div>
                </div>

                <!-- top navigation -->
                <div class="top_nav">
                    <div class="nav_menu">
                        <nav>
                            <div class="nav toggle">
                                <a id="menu_toggle"><i class="fa fa-bars"></i></a>
                            </div>

                            <ul class="nav navbar-nav navbar-right">

                                <li id="liIngresar" runat="server" class="">
                                    <button type="button" class="user-profile" data-toggle="modal" data-target="#myModal">
                                        <span class=" fa fa-user" style="font-size: 22px"></span>Ingresar
                                    </button>
                                </li>

                                <li id="liUsuario" runat="server" visible="false" class="">
                                    <a href="javascript:;" class="user-profile dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                        <img runat="server" id="imgLogoUsuario" src="~/images/No disponible.jpg" />
                                        <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                                        <span class=" fa fa-angle-down"></span>
                                    </a>
                                    <ul class="dropdown-menu dropdown-usermenu pull-right">
                                        <li>
                                            <button type="button" class="button-empty" data-toggle="modal" data-target="#myModalPerfil">
                                                Perfil
                                            </button>
                                        </li>
                                        <%--<li>
                                            <button type="button" class="button-empty" data-toggle="modal" data-target="#myModalRegistro">
                                                Registro
                                            </button>
                                            <span class="badge bg-red pull-right" style="margin-top: 9px">60%</span>
                                        </li>--%>
                                        <li>
                                            <asp:Button ID="btnSalir" CssClass="button-empty" runat="server" Text="Salir" OnClick="btnSalir_Click" />
                                            <i class="fa fa-sign-out pull-right" style="margin-top: 9px; font-size: 20px"></i>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </nav>
                    </div>
                </div>
                <!-- /top navigation -->

                <!-- Modal Login-->
                <div class="modal fade" id="myModal" role="dialog">
                    <div class="modal-dialog">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div align="center" class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Inicio de sesión</h4>
                            </div>
                            <div align="center" class="modal-body">
                                <table style="width: 80%; height: 100px" class="margenCero, paddingCero" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 30%">Usuario: 
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="textbox" ID="txtUsuario" runat="server" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%">Contraseña: 
                                        </td>
                                        <td>
                                            <asp:TextBox CssClass="textbox" ID="txtContrasena" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <a target="ifContenedor" href="OlvidoContrasena.aspx" onclick="$('#myModal').modal('hide')">¿Olvido su Usuario/Contraseña?</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnIngresar" CssClass="button-gray" runat="server" Text="Entrar" Width="80px" OnClick="btnIngresar_Click" />
                                <button type="button" class="button-gray" data-dismiss="modal" style="width: 80px">Cancelar</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /Modal Login-->

                <!-- Modal Perfil-->
                <div class="modal fade" id="myModalPerfil" role="dialog">
                    <div class="modal-dialog">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div align="center" class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Perfil del usuario</h4>
                            </div>
                            <div align="center" class="modal-body">
                                <table style="width: 80%; height: 100px" class="margenCero, paddingCero" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="center" class="user-profile">
                                            <img runat="server" style="width: 85px; height: 85px" id="imgLogoUsuarioPerfil" src="~/images/No disponible.jpg" />
                                        </td>
                                    </tr>
                                </table>
                                <table style="width: 80%; height: 100px" class="margenCero, paddingCero" cellpadding="0" cellspacing="0">
                                    <tr style="border-bottom: dotted; border-width: 1px">
                                        <td style="width: 30%">Razón social: 
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblPerfilRazonSocial" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <%--<tr style="border-bottom: dotted; border-width: 1px">
                                        <td style="width: 30%">Clasificación: 
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblPerfilClasificacion" runat="server" Text="Audio y video por Suscripción"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%">Tipo: 
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblPerfilTipo" runat="server" Text="Privado"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="button-gray" data-dismiss="modal" style="width: 80px">Listo</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /Modal Perfil-->

                <!-- Modal Registro-->
                <div class="modal fade" id="myModalRegistro" role="dialog">
                    <div class="modal-dialog">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div align="center" class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Porcentaje de registro</h4>
                            </div>
                            <div align="center" class="modal-body">
                                <table style="width: 70%; height: 175px" class="margenCero, paddingCero" cellpadding="0" cellspacing="0">
                                    <tr style="border-bottom: dotted; border-width: 1px">
                                        <td style="width: 30%">General: 
                                        </td>
                                        <td>
                                            <span class="badge bg-red pull-right">10%</span>
                                        </td>
                                    </tr>
                                    <tr style="border-bottom: dotted; border-width: 1px">
                                        <td style="width: 30%">Clasificación: 
                                        </td>
                                        <td>
                                            <span class="badge bg-red pull-right">90%</span>
                                        </td>
                                    </tr>
                                    <tr style="border-bottom: dotted; border-width: 1px">
                                        <td style="width: 30%">Cobertura: 
                                        </td>
                                        <td>
                                            <span class="badge bg-red pull-right">80%</span>
                                        </td>
                                    </tr>
                                    <tr style="border-bottom: dotted; border-width: 1px">
                                        <td style="width: 30%">Contenidos: 
                                        </td>
                                        <td>
                                            <span class="badge bg-red pull-right">76%</span>
                                        </td>
                                    </tr>
                                    <tr style="border-bottom: dotted; border-width: 1px">
                                        <td style="width: 30%">Laboral: 
                                        </td>
                                        <td>
                                            <span class="badge bg-red pull-right">50%</span>
                                        </td>
                                    </tr>
                                    <tr style="border-bottom: dotted; border-width: 1px">
                                        <td style="width: 30%">Sociertaria: 
                                        </td>
                                        <td>
                                            <span class="badge bg-red pull-right">25%</span>
                                        </td>
                                    </tr>
                                    <tr style="border-bottom: dotted; border-width: 1px">
                                        <td style="width: 30%">Representante: 
                                        </td>
                                        <td>
                                            <span class="badge bg-red pull-right">30%</span>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width: 85%; margin-top: 15px" class="margenCero, paddingCero" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 30%">Total registro: 
                                        </td>
                                        <td>
                                            <span class="badge bg-red pull-right">60%</span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="button-gray" data-dismiss="modal" style="width: 80px">Listo</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /Modal Registro-->

                <!-- page content -->
                <div id="divContent" class="right_col" role="main">
                    <div id="divAlerta" runat="server" visible="false">
                        <i runat="server" id="icoAlerta" class="fa fa-info-circle" aria-hidden="true" style="font-size: 25px"></i>
                        <asp:Label ID="lblAlerta" runat="server" Text="" Font-Size="15px"></asp:Label>
                    </div>
                    <%--<iframe name="ifContenedor" id="ifContenedor" src="Inicio.aspx" scrolling="no" class="contenedor"></iframe>--%>
                    <iframe name="ifContenedor" id="ifContenedor" src="Inicio.aspx" scrolling="no" class="contenedor"></iframe>
                </div>
                <!-- /page content -->

                <!-- footer content -->
                <%--<footer>
          <div class="pull-right">
            
          </div>
          <div class="clearfix"></div>
        </footer>--%>
                <!-- /footer content -->
            </div>
        </div>

        <script src="js/jquery.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/fastclick.js"></script>
        <script src="js/nprogress.js"></script>
        <script src="js/custom.min.js"></script>
        <script type="text/javascript">
            //AJUSTA CONTENIDO A LA PANTALLA
            function autoAjustar(e) {
                $("#ifContenedor").on('load', function () {
                    var iFrame = document.getElementById('ifContenedor');
                    var innerDoc = iFrame.contentDocument || iFrame.contentWindow.document;
                    var heightContent = parseInt(innerDoc.getElementById('lblHeightBody').innerHTML);
                    $('#ifContenedor').height(heightContent);
                    $('#divContent').height(heightContent + 150);
                });
            }

            function ajutarDesdeIframe() {
                $("#ifContenedor").load();
            }

            function ajustarContenido() {
                $height = document.getElementById('divContent').offsetHeight;
                autoAjustar($height);
            }

            $(window).resize(function () {
                setTimeout(ajustarContenido(), 2000);
            });

            $(document).ready(function () {
                setTimeout(ajustarContenido(), 2000);
            });
            //FIN AJUSTA CONTENIDO A LA PANTALLA
        </script>
    </form>
</body>
</html>
