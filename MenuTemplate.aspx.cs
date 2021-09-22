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
    public partial class MenuTemplate : System.Web.UI.Page
    {
        #region Declaracion de variables
        string descripcionLog = string.Empty;
        string script = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region btnIngresar_Click
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                lblAlerta.Text = "";
                lblAlerta.Visible = false;
                icoAlerta.Visible = false;

                if (txtUsuario.Text.Trim() != "" && txtContrasena.Text.Trim() != "")
                {
                    EUsuario entUsuario = new EUsuario();
                    DataSet ds = new DataSet();
                    entUsuario.TipoAccion = 1;
                    entUsuario.Usuario = txtUsuario.Text.ToString();
                    entUsuario.Contrasena = txtContrasena.Text.ToString();
                    ds = NUsuario.MantenimientoUsuario(entUsuario);

                    if (ds.Tables[0].Rows.Count == 1 && ds.Tables[0].Rows[0]["USUARIO"].ToString() != "")
                    {
                        if (ds.Tables[0].Rows[0]["ESTADO"].ToString() == "Habilitado")
                        {
                            Session["sesionUsuario"] = ds.Tables[0].Rows[0]["USUARIO"];
                            Session["sesionTipoUsuario"] = ds.Tables[0].Rows[0]["TIPO"];
                            imgLogoUsuario.Src = "data:image/jpg;base64," + Convert.ToBase64String((byte[])ds.Tables[0].Rows[0]["LOGO_USUARIO"]);

                            foreach (DataRow rows in ds.Tables[1].Rows)
                            {
                                Control li = FindControl(rows["MODULOS"].ToString());
                                li.Visible = true;
                            }

                            liIngresar.Visible = false;
                            liUsuario.Visible = true;

                            ELog entLog = new ELog();
                            entLog.TipoAccion = 1;//LOG PROCESOS
                            entLog.Usuario = txtUsuario.Text.ToString();
                            entLog.Descripcion = "Ingreso al sistema EVALDTH";
                            NLog.InsertaLog(entLog);
                        }
                        else
                        {
                            lblAlerta.Text = "El usuario se encuentra deshabilitado";
                            lblAlerta.Visible = true;
                            icoAlerta.Visible = true;
                            
                            ELog entLog = new ELog();
                            entLog.TipoAccion = 1;//LOG PROCESOS
                            entLog.Usuario = txtUsuario.Text.ToString();
                            entLog.Descripcion = "Intento de ingreso al sistema sin credenciales";
                            NLog.InsertaLog(entLog);
                        }
                    }
                    else
                    {
                        lblAlerta.Text = "Usuario/Contraseña incorrecto";
                        lblAlerta.Visible = true;
                        icoAlerta.Visible = true;

                        ELog entLog = new ELog();
                        entLog.TipoAccion = 1;//LOG PROCESOS
                        entLog.Usuario = txtUsuario.Text.ToString();
                        entLog.Descripcion = "Intento de ingreso al sistema sin credenciales";
                        NLog.InsertaLog(entLog);
                    }
                }
                else
                {
                    lblAlerta.Text = "Ingrese los campos Usuario y Contraseña";
                    lblAlerta.Visible = true;
                    icoAlerta.Visible = true;
                }
            }
            catch (Exception ex)
            {
                descripcionLog = ex.Message.ToString();
                ELog entLog = new ELog();
                entLog.TipoAccion = 2;//LOG ERRORES
                entLog.Descripcion = "btnIngreso_Click" + descripcionLog;
                entLog.Usuario = "Sin credenciales";
                NLog.InsertaLog(entLog);
            }
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //EUsuario entUsuario = new EUsuario();
                //DataSet ds = new DataSet();
                //entUsuario.TipoAccion = 3;
                //ds = NUsuario.MantenimientoUsuario(entUsuario);

                //imgLogoUsuario.Src = "data:image/jpg;base64," + Convert.ToBase64String((byte[])ds.Tables[0].Rows[0]["LOGO_USUARIO"]);


                HttpFileCollection fuMultiAnexos = Request.Files;
                int NumArchivos = fuMultiAnexos.Count;

                for (int contador = 0; contador < NumArchivos; contador++)
                {
                    byte[] matriz = null;
                    HttpPostedFile fuArchivo = fuMultiAnexos[contador];
                    var binaryReader = new BinaryReader(fuArchivo.InputStream);
                    matriz = binaryReader.ReadBytes(fuArchivo.ContentLength);
                    EUsuario entUsuario = new EUsuario();
                    DataSet ds = new DataSet();
                    entUsuario.TipoAccion = 2;
                    entUsuario.Usuario = fuArchivo.FileName.Replace("Logo_", "").Replace("_.jpg", "");
                    entUsuario.Archivo = matriz;
                    entUsuario.ExtensionArchivo = Path.GetExtension(fuArchivo.FileName);
                    ds = NUsuario.MantenimientoUsuario(entUsuario);

                }
            
            
            }
            catch (Exception ex)
            {
                descripcionLog = ex.Message.ToString();
                ELog entLog = new ELog();
                entLog.TipoAccion = 2;//LOG ERRORES
                entLog.Descripcion = "btnIngreso_Click" + descripcionLog;
                entLog.Usuario = "Sin credenciales";
                NLog.InsertaLog(entLog);
            }

        }

      
    }
}