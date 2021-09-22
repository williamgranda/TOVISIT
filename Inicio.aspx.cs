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

namespace TOVISIT.APP
{
    public partial class Inicio : System.Web.UI.Page
    {
        #region Declaracion de variables
        string descripcionLog = string.Empty;
        string script = string.Empty;
        #endregion
        
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
                entLog.Descripcion = "Page_Load" + " / " + descripcionLog;
                entLog.Usuario = "N/A";
                NLog.InsertaLog(entLog);
            }
        }

        protected void btnValidacion_Click(object sender, EventArgs e)
        {
            try
            {
                tblInicio.Visible = false;
                tblValidacion.Visible = true;
                tblInfoMedio.Visible = false;

                script = "ajustarContenidoTiempo();";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Script", script, true);

            }
            catch (Exception ex)
            {
                descripcionLog = ex.Message.ToString();
                ELog entLog = new ELog();
                entLog.TipoAccion = 2;//LOG ERRORES
                entLog.Descripcion = "btnValidacion_Click" + " / " + descripcionLog;
                entLog.Usuario = "N/A";
                NLog.InsertaLog(entLog);
            }
        }

        
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
    }
}