using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using TOVISIT.APP.Entidades;
using TOVISIT.APP.Negocio;
using System.IO;



namespace TOVISIT.APP
{
    public partial class Index : System.Web.UI.Page
    {
        #region Declaracion de variables
        string descripcionLog = string.Empty;
        string script = string.Empty;
        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {   
            try
            {
                LimpiarAlertas();    
            }
            catch (Exception ex)
            {
                descripcionLog = ex.Message.ToString();
                ELog entLog = new ELog();
                entLog.TipoAccion = 2;//LOG ERRORES
                entLog.Descripcion = "btnIngreso_Click" + " / " + descripcionLog;
                entLog.Usuario = "Sin credenciales";
                NLog.InsertaLog(entLog);
            }
        }
        #endregion

        #region btnIngresar_Click
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text.Trim() != "" && txtContrasena.Text.Trim() != "")
                {
                    EUsuario entUsuario = new EUsuario();
                    DataSet ds = new DataSet();
                    entUsuario.TipoAccion = 1;
                    entUsuario.Usuario = txtUsuario.Text.ToString();
                    entUsuario.Contrasena = txtContrasena.Text.ToString();
                    ds = NUsuario.MantenimientoUsuario(entUsuario);

                    if(ds.Tables.Count == 3)
                    {
                        if (ds.Tables[0].Rows[0]["ESTADO"].ToString() == "Habilitado")
                        {
                            
                            lblUsuario.Text = ds.Tables[0].Rows[0]["USUARIO"].ToString();
                            Session["sesionUsuario"] = ds.Tables[0].Rows[0]["USUARIO"];
                            Session.Add("User", ds.Tables[0].Rows[0]["USUARIO"].ToString());
                            Session["sesionTipoUsuario"] = ds.Tables[0].Rows[0]["TIPO"];
                            ELog entLog = new ELog();
                            entLog.TipoAccion = 1;//LOG PROCESOS
                            entLog.Usuario = txtUsuario.Text.ToString();
                            entLog.Descripcion = "Ingreso al sistema Algoritmo de Medios";
                            NLog.InsertaLog(entLog);
                            if ((Convert.ToBase64String((byte[])ds.Tables[0].Rows[0]["LOGO_USUARIO"])).ToString() != "")
                            {
                                imgLogoUsuario.Src = "data:image/jpg;base64," + Convert.ToBase64String((byte[])ds.Tables[0].Rows[0]["LOGO_USUARIO"]);
                                imgLogoUsuarioPerfil.Src = "data:image/jpg;base64," + Convert.ToBase64String((byte[])ds.Tables[0].Rows[0]["LOGO_USUARIO"]);
                            }
                            else
                            {
                                imgLogoUsuario.Src = ResolveUrl(String.Format(@"~/images/{0}", "Cordicom.png"));
                                imgLogoUsuarioPerfil.Src = ResolveUrl(String.Format(@"~/images/{0}", "Cordicom.png"));
                            }
                            
                            foreach (DataRow rows in ds.Tables[1].Rows)
                            {
                                Control li = FindControl(rows["MODULOS"].ToString());
                                li.Visible = true;
                            }

                            foreach (DataRow rows in ds.Tables[2].Rows)
                            {
                                Control li = FindControl(rows["FORMULARIOS"].ToString());
                                li.Visible = true;
                            }

                            liIngresar.Visible = false;
                            liUsuario.Visible = true;

                           
                        }
                        else
                        {
                            MensajeError("El usuario se encuentra deshabilitado");

                            ELog entLog = new ELog();
                            entLog.TipoAccion = 1;//LOG PROCESOS
                            entLog.Usuario = txtUsuario.Text.ToString();
                            entLog.Descripcion = "Intento de ingreso al sistema usuario deshabilitado";
                            NLog.InsertaLog(entLog);
                        }
                    }
                    else
                    {
                        MensajeError("Usuario/Contraseña incorrecto");
                        
                        ELog entLog = new ELog();
                        entLog.TipoAccion = 1;//LOG PROCESOS
                        entLog.Usuario = txtUsuario.Text.ToString();
                        entLog.Descripcion = "Intento de ingreso al sistema sin credenciales";
                        NLog.InsertaLog(entLog);
                    }
                }
                else
                {
                    MensajeError("Ingrese los campos Usuario y Contraseña");
                }
            }
            catch (Exception ex)
            {
                descripcionLog = ex.Message.ToString();
                ELog entLog = new ELog();
                entLog.TipoAccion = 2;//LOG ERRORES
                entLog.Descripcion = "btnIngreso_Click" + " / " + descripcionLog;
                entLog.Usuario = "Sin credenciales";
                NLog.InsertaLog(entLog);
            }
        }
        #endregion

       

        #region btnSalir_Click
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarCampos();
                liIngresar.Visible = true;
                liUsuario.Visible = false;

            }
            catch (Exception ex)
            {
                descripcionLog = ex.Message.ToString();
                ELog entLog = new ELog();
                entLog.TipoAccion = 2;//LOG ERRORES
                entLog.Descripcion = "btnSalir_Click" + " / " + descripcionLog;
                entLog.Usuario = Session["sesionUsuario"].ToString();
                NLog.InsertaLog(entLog);
            }
        }
        #endregion

        #region LimpiarCampos
        private void LimpiarCampos()
        {
            LimpiarAlertas();
            LimpiarVariablesSesion();
            LimpiarModulos();
            LimpiarFormularios();

            txtUsuario.Text = "";
            txtContrasena.Text = "";
        }
        #endregion

        #region LimpiarAlertas
        private void LimpiarAlertas()
        {
            divAlerta.Visible = false;
            lblAlerta.Text = "";            
        }
        #endregion

        #region MensajeOk
        private void MensajeOk(string msj)
        {
            divAlerta.Visible = true;
            lblAlerta.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00937c");
            lblAlerta.Text = msj;
            form1.Focus();
        }
        #endregion

        #region MensajeError
        private void MensajeError(string msj)
        {
            divAlerta.Visible = true;
            lblAlerta.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
            lblAlerta.Text = msj;
            form1.Focus();
        }
        #endregion

        #region LimpiarVariablesSesion
        private void LimpiarVariablesSesion()
        {
            Session["sesionUsuario"] = "";
            Session["sesionTipoUsuario"] = "";
        }
        #endregion

        #region LimpiarModulos
        private void LimpiarModulos()
        {
            //DEFINIR LOS MÓDULOS PÚBLICOS
            mdlRegistro.Visible = false;
            mdlAdministracion.Visible = false;
           
            mdlReportes.Visible = false;
            mdlCertificado.Visible = false;
        }
        #endregion

        #region LimpiarFormularios
        private void LimpiarFormularios()
        {
            //DEFINIR LOS LimpiarFormularios PÚBLICOS
        }
        #endregion        
    }
}