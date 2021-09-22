<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuTemplate.aspx.cs" Inherits="TOVISIT.APP.MenuTemplate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>rpm</title>

    <link rel="shortcut icon" href="images/favicon.ico" />
    <link href="css/General.css" rel="stylesheet" type="text/css" />
    <script src="js/General.js" type="text/javascript"></script>
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/nprogress.css" rel="stylesheet" type="text/css" />
    <link href="css/custom.min.css" rel="stylesheet" type="text/css" />

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
                <img src="images/Cordicom.png" alt="..." class="img-circle profile_img"/>
              </div>
              <div class="profile_info">
                <span>CORDICOM</span>
                <h2>Evaluación del Desempeño</h2>
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
                  <li id="mdlInicio"><a><i class="fa fa-home"></i> Inicio <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="index.aspx">Introducción</a></li>
                      <li><a href="index2.html">Beneficios</a></li>
                      <li><a href="index3.html">Documentación</a></li>
                        <%--CARGA FOTOS DE LOS USUARIOS
                        <li>
                            <table>
                                <tr>
                                    <td style="padding: 15px">Anexos LOGO:
                                    </td>
                                    <td>
                                        <asp:FileUpload ID="fuMultiple" AllowMultiple="true" runat="server" BackColor="#CCCCCC" />                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="Button1" runat="server" Text="cargar logos" OnClick="Button1_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img runat="server" id="image" src="~/images/Pantalla.jpg"  />
                                    </td>
                                </tr>
                            </table>
                        </li>--%>
                    </ul>
                  </li>
                  <li runat="server" id="mdlRegistro" visible="false"><a><i class="fa fa-edit"></i> Registro del medio <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="form.html">Consulta</a></li>
                      <li><a href="form_advanced.html">Modificación</a></li>
                    </ul>
                  </li>
                  <li runat="server" id="mdlAdministracion" visible="false"><a><i class="fa fa-desktop"></i> Administración <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="glyphicons.html">Nuevos funcionarios</a></li>
                      <li><a href="general_elements.html">Consulta medios</a></li>
                      <li><a href="media_gallery.html">Consulta funcionarios</a></li>
                      <li><a href="typography.html">Permisos</a></li>
                      <li><a href="icons.html">Solicitudes</a></li>
                      <li><a href="glyphicons.html">Parametrización</a></li>                      
                    </ul>
                  </li>
                  <li runat="server" id="mdlTablas" visible="false"><a><i class="fa fa-table"></i> Tablas de datos <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="chartjs.html">Reporte 1</a></li>
                      <li><a href="chartjs2.html">Reporte 2</a></li>
                      <li><a href="morisjs.html">Reporte 3</a></li>
                      <li><a href="echarts.html">Reporte 4</a></li>
                      <li><a href="other_charts.html">Reporte 5</a></li>                      
                    </ul>
                  </li>
                  <li runat="server" id="mdlPresentacion" visible="false"><a><i class="fa fa-bar-chart-o"></i> Presentación de datos <span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><a href="tables.html">Estadistica 1</a></li>
                      <li><a href="tables_dynamic.html">Estadistica 2</a></li>
                    </ul>
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
              <a data-toggle="tooltip" data-placement="top" title="Settings">
                <span class="glyphicon glyphicon-cog" aria-hidden="true"></span>
              </a>
              <a data-toggle="tooltip" data-placement="top" title="FullScreen">
                <span class="glyphicon glyphicon-fullscreen" aria-hidden="true"></span>
              </a>
              <a data-toggle="tooltip" data-placement="top" title="Lock">
                <span class="glyphicon glyphicon-eye-close" aria-hidden="true"></span>
              </a>
              <a data-toggle="tooltip" data-placement="top" title="Logout" href="login.html">
                <span class="glyphicon glyphicon-off" aria-hidden="true"></span>
              </a>
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
                
                <li  id="liIngresar" runat="server" class="">
                    <button type="button" class="user-profile" data-toggle="modal" data-target="#myModal">
                        <span class=" fa fa-user" style="font-size:22px"></span>  Ingresar
                    </button>        
                </li>    

                <li id="liUsuario" runat="server" visible="false" class="">                  
                  <a href="javascript:;" class="user-profile dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                    <img runat="server" id="imgLogoUsuario" src="~/images/Pantalla.jpg"  />CANELA
                    <span class=" fa fa-angle-down"></span>
                  </a>
                  <ul class="dropdown-menu dropdown-usermenu pull-right">
                    <li><a href="javascript:;"> Profile</a></li>
                    <li>
                      <a href="javascript:;">
                        <span class="badge bg-red pull-right">50%</span>
                        <span>Settings</span>
                      </a>
                    </li>
                    <li><a href="javascript:;">Help</a></li>
                    <li><a href="login.html"><i class="fa fa-sign-out pull-right"></i> Log Out</a></li>
                  </ul>
                </li>                
              </ul>
            </nav>
          </div>
        </div>
        <!-- /top navigation -->

        <!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">    
            <!-- Modal content-->
            <div class="modal-content">
            <div align="center" class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Inicio de sesión</h4>
            </div>
            <div align="center" class="modal-body">
                <table style="width:80%; height:100px" class="margenCero, paddingCero" cellpadding="0" cellspacing="0" >
                    <tr>
                        <td style="width:30%">
                            Usuario: 
                        </td>
                        <td>
                            <asp:TextBox CssClass="textbox" ID="txtUsuario" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:30%">
                            Contraseña: 
                        </td>
                        <td>
                            <asp:TextBox CssClass="textbox" ID="txtContrasena" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <a href="#">¿Olvido su Usuario/Contraseña?</a>
                        </td>
                    </tr>
                </table>                
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnIngresar" CssClass="button-gray" runat="server" Text="Entrar" Width="80px" OnClick="btnIngresar_Click" />
                <button type="button" class="button-gray" data-dismiss="modal" style="width:80px">Cancelar</button>
            </div>
            </div>      
        </div>
        </div>
        <!-- /Modal -->

        <!-- page content -->
        <div id="divContent" class="right_col" role="main">   
            <asp:Label ID="lblAlerta" runat="server" Text="Label" ForeColor="Red" Visible="false"></asp:Label>
            <i runat="server" id="icoAlerta" class="fa fa-exclamation-circle" aria-hidden="true" visible="false"></i>                     
            <iframe name="ifContenedor" id="ifContenedor" src="Inicio.aspx" scrolling="no" class="contenedor"></iframe>                        
        </div>
        <!-- /page content -->
          
        <!-- footer content -->
        <footer>
          <div class="pull-right">
            Gentelella - Bootstrap Admin Template by <a href="https://colorlib.com">Colorlib</a>
          </div>
          <div class="clearfix"></div>
        </footer>
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

        function ajustarContenido() {
            $height = document.getElementById('divContent').offsetHeight;
            autoAjustar($height)
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
