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

namespace TOVISIT.APP
{
    public partial class ListadoTipo : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                    InicializarObjetos();
                    CargaDatos();

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

        

        #region InicializarObjetos
        private void InicializarObjetos()
        {
            DataTable dtTipo = new DataTable();
            dtTipo.Columns.Add("ID_TIPO_LUGAR", typeof(String));
            dtTipo.Columns.Add("DESCRIPCION", typeof(String));
            
            gvTipo.DataSource = dtTipo;
            gvTipo.DataBind();
            ViewState["dtTipo"] = dtTipo;
        
        
        
        }
        #endregion

        

        private void CargaDatos()
        {
            ETipo entTipo = new ETipo();
            DataSet ds = new DataSet();
            entTipo.TipoAccion = 5;
            ds = NTipo.MantenimientoTipo(entTipo);

            if (ds.Tables[0].Rows[0]["ID_TIPO_LUGAR"].ToString() != "NO HAY DATOS")
            {
                gvTipo.DataSource = ds.Tables[0];
                gvTipo.DataBind();
                ViewState["dtTipo"] = ds.Tables[0];
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






      


        
 

        protected void gvTipo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int Codigo = Convert.ToInt32(gvTipo.DataKeys[e.NewSelectedIndex].Value);
           Response.Redirect(string.Format("NuevoTipo.aspx?id={0}", Codigo));
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoTipo.aspx");
        }

        protected void gvTipo_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            
        }

       

    }
}