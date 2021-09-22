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
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System.Configuration;
using System.Net.Mail;

namespace TOVISIT.APP
{
    public partial class NuevoAdministrador : System.Web.UI.Page
    {

        //Producción
        SqlConnection cnx = new SqlConnection("Data Source=localhost;Initial Catalog=TOVISIT_APP;Persist Security Info=True;User ID=sa;Password=2959714");

        #region Declaracion de variables
        string descripcionLog = string.Empty;
        string script = string.Empty;
        private int Codigo
        {
            get { return (int)Session["codigo"]; }
            set { Session["codigo"] = value; }
        }

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LimpiarAlertas();
                if (!IsPostBack)
                {
                    //tomo el id del  que vino en la url
                    if (Request.Params["id"] == null)
                        this.Codigo = -1; //si se seelcciono la opcion de nuevo
                    else
                        this.Codigo = Convert.ToInt32(Request.Params["id"]);

                    CargarUsuario(this.Codigo);

                    CargaInicial();
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


        #region CargaInicial
        private void CargaInicial()
        {
            EUsuario entUsuario = new EUsuario();
            DataSet ds = new DataSet();
            entUsuario.TipoAccion = 26;
            ds = NUsuario.MantenimientoSuperUsuario(entUsuario);
           

        }
        #endregion

        #region Carga Por ID
        private void CargarUsuario(int id)
        {
            try
            {

                string cadcon = "SELECT dbo.RPM_USUARIOS.USUARIO,dbo.RPM_USUARIOS.TIPO,dbo.EVALDTH_UNIDAD.NOMBRE_UNIDAD,dbo.RPM_USUARIOS.CORREO FROM dbo.RPM_USUARIOS INNER JOIN dbo.EVALDTH_UNIDAD ON dbo.RPM_USUARIOS.ID_UNIDAD = dbo.EVALDTH_UNIDAD.ID_UNIDAD Where CODIGO ='" + Codigo + "'";
                SqlCommand cm = new SqlCommand(cadcon, cnx);
                cnx.Open();

                SqlDataReader leer = cm.ExecuteReader();


                if (leer.Read() == true)
                {

                    txtUsuario.Text = leer["USUARIO"].ToString();
                    txtUsuario.Enabled = false;
                    txtCorreo.Text = leer["CORREO"].ToString();
                    btnModificar.Visible = true;
                    btnGuardar.Visible = false;

                }
                else
                {

                    txtUsuario.Text = "";
                    txtCorreo.Text = "";
                    
                    ddlTipo.SelectedIndex = -1;

                }
                cnx.Close();

            }

            catch (Exception ex)
            {
                MensajeError(ex.Message.ToString());
            }




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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoAdministrador.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text != "")
                {
                    if (ddlTipo.Text != "Seleccione..")
                    {
                            EUsuario entUsuario = new EUsuario();
                            DataSet ds = new DataSet();
                            entUsuario.TipoAccion = 70;
                            entUsuario.Codigo = Codigo;
                            entUsuario.Correo = txtCorreo.Text;
                            entUsuario.Tipo = Convert.ToInt16(ddlTipo.SelectedValue.ToString());
                           
                            ds = NUsuario.MantenimientoSuperUsuario(entUsuario);

                            if (ds.Tables[0].Rows[0]["RESULTADO"].ToString() == "0")
                            {
                                txtCorreo.Text = "";
                                ddlTipo.SelectedIndex = -1;
                                MensajeOk("La información se actualizó correctamente");

                                Response.Redirect("ListadoAdministrador.aspx");


                                ELog entLog1 = new ELog();
                                entLog1.TipoAccion = 1;//LOG PROCESOS
                                entLog1.Usuario = Session["sesionUsuario"].ToString();
                                entLog1.Descripcion = "Modifica Usuario" + " / " + txtUsuario.Text;
                                NLog.InsertaLog(entLog1);
                            }
                            else
                            {
                                MensajeError("Error al guardar la información");
                            }
                        

                    }
                    else
                    {
                        MensajeError("Debe llenar los campos oblicatorios(*): 'TIPO'");
                    }
                }
                else
                {
                    MensajeError("Debe llenar los campos oblicatorios(*): 'UNIDAD'");
                }

                script = "ajustarContenidoTiempo();";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Script", script, true);


            }
            catch (Exception ex)
            {
                descripcionLog = ex.Message.ToString();
                ELog entLog = new ELog();
                entLog.TipoAccion = 2;//LOG ERRORES
                entLog.Descripcion = "btnGuardar_Click" + " / " + descripcionLog;
                entLog.Usuario = Session["sesionUsuario"].ToString();
                NLog.InsertaLog(entLog);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtUsuario.Text != "")
                {
                    if (ddlTipo.Text != "Seleccione..")
                    {
                        
                            EUsuario entUsuario = new EUsuario();
                            DataSet ds = new DataSet();
                            entUsuario.TipoAccion = 67;
                            entUsuario.Usuario = txtUsuario.Text;
                            entUsuario.Correo = txtCorreo.Text;
                            //txtContrasena.Text = Encriptar(txtContrasena.text);
                            entUsuario.Contrasena = Encriptar(txtContrasena.Text);
                            entUsuario.Estado = 1;
                            entUsuario.Tipo = Convert.ToInt16(ddlTipo.SelectedValue.ToString());
                             ds = NUsuario.MantenimientoSuperUsuario(entUsuario);

                            //Envia Correo con usuario y contraseña

                            #region Envio de Notificacion
                            ECorreo entCorreo = new ECorreo();
                            entCorreo.Html = "PlantillaGeneral.html";
                            string path = ConfigurationManager.AppSettings["PathHtml"];
                            StringBuilder emailHtml = new StringBuilder(File.ReadAllText(path + entCorreo.Html));
                            emailHtml.Replace("usuario", txtUsuario.Text.ToString());
                            emailHtml.Replace("contrasena", txtContrasena.Text.ToString());
                            entCorreo.Asunto = ConfigurationManager.AppSettings["asuntoCreacion"];
                            entCorreo.Asunto = "Usuario - contraseña  del Sistema de Evaluación del Desempeño ";
                            entCorreo.Cuerpo = emailHtml.ToString();
                            MailMessage email = new MailMessage();
                            entCorreo.Para = txtCorreo.Text;
                            email.To.Add(new MailAddress(entCorreo.Para));
                            EnviarNotificacion(entCorreo, email);
                            #endregion

                            if (ds.Tables[0].Rows[0]["RESULTADO"].ToString() == "0")
                            {
                                txtUsuario.Text = "";
                                 ddlTipo.SelectedIndex = -1;
                                MensajeOk("La información se guardó correctamente");
                                Response.Redirect("ListadoAdministrador.aspx");
                                ELog entLog1 = new ELog();
                                entLog1.TipoAccion = 1;//LOG PROCESOS
                                entLog1.Usuario = Session["sesionUsuario"].ToString();
                                entLog1.Descripcion = "Creación nuevo Usuario" + " / " + txtUsuario.Text;
                                NLog.InsertaLog(entLog1);

                            }
                            else
                            {
                                MensajeError("Error al guardar la información");
                           

                    }
                    
                }
                else
                {
                    MensajeError("Debe llenar los campos oblicatorios(*): 'UNIDAD'");
                }

                script = "ajustarContenidoTiempo();";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Script", script, true);
                }

            }
            catch (Exception ex)
            {
                descripcionLog = ex.Message.ToString();
                ELog entLog = new ELog();
                entLog.TipoAccion = 2;//LOG ERRORES
                entLog.Descripcion = "btnGuardar_Click" + " / " + descripcionLog;
                entLog.Usuario = Session["sesionUsuario"].ToString();
                NLog.InsertaLog(entLog);
            }
        }

        public string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;


                    }


        /// Encripta una cadena
        //public static string Encriptar(this string _cadenaAencriptar)
        //{
        //    string result = string.Empty;
        //    byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
        //    result = Convert.ToBase64String(encryted);
        //    return result;
        //}

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