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
    public partial class NuevoLugar : System.Web.UI.Page
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
            ELugar entLugar = new ELugar();
            DataSet ds = new DataSet();
            entLugar.TipoAccion = 7;
            ds = NLugar.MantenimientoLugares(entLugar);

            CargaDropDownList(ddlTipo, ds.Tables[0], 1);

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
            Response.Redirect("ListadoLugares.aspx");
        }

        

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtNombre.Text != "")
                {
                    if (ddlTipo.Text != "Seleccione..")
                    {
                        
                            ELugar entLugar = new ELugar();
                            DataSet ds = new DataSet();
                            entLugar.TipoAccion = 3;
                            entLugar.Nombre_lugar = txtNombre.Text;
                            entLugar.Id_tipo_lugar = Convert.ToInt16(ddlTipo.SelectedValue.ToString());
                            entLugar.Descripcion_lugar = txtDescripcion.Text;
                            entLugar.Coordenadas = txtCoordenadas.Text;
                            entLugar.Lat = txtLatitud.Text;
                            entLugar.Lng = txtLongitud.Text;                         
                            entLugar.Estado = 1;
                            entLugar.Usuario = Session["sesionUsuario"].ToString();
                            
                             ds = NLugar.MantenimientoLugares(entLugar);

                           

                            if (ds.Tables[0].Rows[0]["RESULTADO"].ToString() == "0")
                            {
                                txtNombre.Text = "";
                                 ddlTipo.SelectedIndex = -1;
                                MensajeOk("La información se guardó correctamente");
                                Response.Redirect("ListadoLugares.aspx");
                                ELog entLog1 = new ELog();
                                entLog1.TipoAccion = 1;//LOG PROCESOS
                                entLog1.Usuario = Session["sesionUsuario"].ToString();
                                entLog1.Descripcion = "Creación nuevo Lugar" + " / " + txtNombre.Text;
                                NLog.InsertaLog(entLog1);

                            }
                            else
                            {
                                MensajeError("Error al guardar la información");
                           

                    }
                    
                }
                else
                {
                    MensajeError("Debe llenar los campos oblicatorios(*): 'TIPO '");
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

        
    }
}