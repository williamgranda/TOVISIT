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
    public partial class NuevoTipo : System.Web.UI.Page
    {

        //Producción
        SqlConnection cnx = new SqlConnection("Data Source=localhost;Initial Catalog=TOVISIT_APP;Persist Security Info=True;User ID=sa;Password=2959714");

        #region Declaracion de variables
        string descripcionLog = string.Empty;
        string script = string.Empty;
        

        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
             
                if (!IsPostBack)
                {
                    LimpiarAlertas();

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
            ETipo entTipo = new ETipo();
            DataSet ds = new DataSet();
            entTipo.TipoAccion = 5;
            ds = NTipo.MantenimientoTipo(entTipo);
           

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
            Response.Redirect("ListadoTipo.aspx");
        }

       

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtDescripcion.Text != "")
                {
                       
                            ETipo entTipo = new ETipo();
                            DataSet ds = new DataSet();
                            entTipo.TipoAccion = 2;
                            entTipo.Descripcion = txtDescripcion.Text;
                            ds = NTipo.MantenimientoTipo(entTipo);                          

                            if (ds.Tables[0].Rows[0]["RESULTADO"].ToString() == "0")
                            {
                                txtDescripcion.Text = "";
                                
                                MensajeOk("La información se guardó correctamente");
                                Response.Redirect("ListadoTipo.aspx");
                                ELog entLog1 = new ELog();
                                entLog1.TipoAccion = 1;//LOG PROCESOS
                                entLog1.Usuario = Session["sesionUsuario"].ToString();
                                entLog1.Descripcion = "Creación Tipo" + " / " + txtDescripcion.Text;
                                NLog.InsertaLog(entLog1);

                            }
                            else
                            {
                                MensajeError("Error al guardar la información");
                           

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