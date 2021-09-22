using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TOVISIT.APP.Entidades;
using TOVISIT.APP.Negocio;
using System.Text;
using System.Net.Mail;
using System.IO;

namespace TOVISIT.APP
{
    public partial class OlvidoContrasena : System.Web.UI.Page
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
                AsignarColor();

                if (!IsPostBack)
                {
                    InicializarObjetos();
                }
            }
            catch (Exception ex)
            {
                descripcionLog = ex.Message.ToString();
                ELog entLog = new ELog();
                entLog.TipoAccion = 2;//LOG ERRORES
                entLog.Descripcion = "Page_Load" + " / " + descripcionLog;
                entLog.Usuario = Session["sesionUsuario"].ToString();
                NLog.InsertaLog(entLog);
            }
        }
        #endregion

        #region btnValidar_Click
        protected void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCorreoElectronico.Text != "")
                {
                    EUsuario entUsuario = new EUsuario();
                    DataSet ds = new DataSet();
                    entUsuario.TipoAccion = 71;
                    entUsuario.Correo = txtCorreoElectronico.Text;
                    ds = NUsuario.MantenimientoSuperUsuario(entUsuario);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        
                        ViewState["dtCredenciales"] = ds.Tables[0];
                        
                        script = "textboxSinValidar('txtCorreoElectronico', '#CADEC7');";
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Script", script, true);
                    }
                    else
                    {
                        MensajeError("El correo eletrónico ingresado no pertenece a ningún usuario registrado");
                    }
                }
                else
                {
                    MensajeError("Ingrese el correo eletrónico registrado");
                }
                
                script = "ajustarContenidoTiempo();";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Script", script, true);
            }
            catch (Exception ex)
            {
                descripcionLog = ex.Message.ToString();
                ELog entLog = new ELog();
                entLog.TipoAccion = 2;//LOG ERRORES
                entLog.Descripcion = "btnValidar_Click" + " / " + descripcionLog;
                entLog.Usuario = "Sin credenciales";
                NLog.InsertaLog(entLog);
            }
        }
        #endregion

        #region btnEnviar_Click
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (hfdIdColor.Value == "#CADEC7")
                {
                         #region Envio de Notificacion informando la creacion de tramite
                        DataTable dt = (DataTable)ViewState["dtCredenciales"];
                        DataRow[] RegistroExiste = dt.Select("CORREO = '" + txtCorreoElectronico.Text.ToString() + "'");
                        
                        ECorreo entCorreo = new ECorreo();
                        entCorreo.Html = "RecuperarContrasena.html";
                        string path = ConfigurationManager.AppSettings["PathHtml"].ToString();

                        StringBuilder emailHtml = new StringBuilder(File.ReadAllText(path + entCorreo.Html));
                          emailHtml.Replace("UsuarioRegistrado", RegistroExiste[0]["CODIGO"].ToString());
                        emailHtml.Replace("ContrasenaRegistrado", RegistroExiste[0]["CONTRASENA"].ToString());
                        StringBuilder asunto = new StringBuilder(ConfigurationManager.AppSettings["asuntoCreacion"]);
                        entCorreo.Asunto = "Recuperar contraseña del Evaluación del Desempeño";
                        entCorreo.Cuerpo = emailHtml.ToString();
                        MailMessage email = new MailMessage();
                        
                        email.To.Add(txtCorreoElectronico.Text.Trim());
                        EnviarNotificacion(entCorreo, email);
                        #endregion

                        txtCorreoElectronico.Text = "";
                        script = "textboxSinValidar('txtCorreoElectronico', '#FFFFFF');";
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Script", script, true);

                        MensajeOk("Su 'Usuario' y 'Contraseña' fueron enviados a su mail de registro.<br/>Nota: Si no ha recibido ningún correo en su 'Bandeja de entrada' por favor comprobar en los 'Correos no deseados'");
                    
                }
                else
                {
                    MensajeError("Validar el correo electrónico registrado");
                }
                script = "ajustarContenidoTiempo();";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Script", script, true);
            }
            catch (Exception ex)
            {
                descripcionLog = ex.Message.ToString();
                ELog entLog = new ELog();
                entLog.TipoAccion = 2;//LOG ERRORES
                entLog.Descripcion = "btnEnviar_Click" + " / " + descripcionLog;
                entLog.Usuario = "Sin credenciales";
                NLog.InsertaLog(entLog);
            }
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

        #region InicializarObjetos
        private void InicializarObjetos()
        {
           
        }
        #endregion

        #region CargaDropDownListVacio
        private void CargaDropDownListVacio(DropDownList ddlGeneral)
        {
            DataTable dtDropDownList = new DataTable();
            dtDropDownList.Columns.Add("CODIGO", typeof(String));
            dtDropDownList.Columns.Add("DESCRIPCION", typeof(String));
            DataRow dr = dtDropDownList.NewRow();
            dr["CODIGO"] = "0";
            dr["DESCRIPCION"] = "Seleccione...";
            dtDropDownList.Rows.InsertAt(dr, 0);

            ddlGeneral.DataSource = dtDropDownList;
            ddlGeneral.DataTextField = "DESCRIPCION";
            ddlGeneral.DataValueField = "CODIGO";
            ddlGeneral.DataBind();
        }
        #endregion 

        #region CargaDropDownList
        private void CargaDropDownList(DropDownList ddlGeneral, DataTable dt, int i)
        {
            if (i == 1)
            {
                DataRow dr = dt.NewRow();
                dr["CODIGO"] = "0";
                dr["DESCRIPCION"] = "Seleccione...";
                dt.Rows.InsertAt(dr, 0);

                ddlGeneral.DataSource = dt;
                ddlGeneral.DataTextField = "DESCRIPCION";
                ddlGeneral.DataValueField = "CODIGO";
                ddlGeneral.DataBind();

                dt.Rows.Remove(dr);
            }
            else
            {
                ddlGeneral.DataSource = dt;
                ddlGeneral.DataTextField = "DESCRIPCION";
                ddlGeneral.DataValueField = "CODIGO";
                ddlGeneral.DataBind();
            }
        }
        #endregion 
        
        #region
        private void AsignarColor()
        {
            txtCorreoElectronico.BackColor = System.Drawing.ColorTranslator.FromHtml(hfdIdColor.Value);
        }
        #endregion

        #region EnviarNotificacion
        private int EnviarNotificacion(ECorreo entCorreo, MailMessage email)
        {
            int valorRetorno = 0;
            valorRetorno = NCorreo.MantenimientoCorreos(entCorreo, email);
            return valorRetorno;
        }
        #endregion
    }
}