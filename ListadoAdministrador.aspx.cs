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
    public partial class ListadoAdministrador : System.Web.UI.Page
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
            DataTable dtAdministrador = new DataTable();
            dtAdministrador.Columns.Add("CODIGO", typeof(String));
            dtAdministrador.Columns.Add("USUARIO", typeof(String));
            dtAdministrador.Columns.Add("APELLLIDOSNOMBRES", typeof(String));
            dtAdministrador.Columns.Add("ESTADO", typeof(String));
            dtAdministrador.Columns.Add("TIPO", typeof(String));
            dtAdministrador.Columns.Add("CORREO", typeof(String));
            dtAdministrador.Columns.Add("ID_UNIDAD", typeof(String));
            gvAdministrador.DataSource = dtAdministrador;
            gvAdministrador.DataBind();
            ViewState["dtAdministrador"] = dtAdministrador;
        
        
        
        }
        #endregion

        

        private void CargaDatos()
        {
            EUsuario entUsuario = new EUsuario();
            DataSet ds = new DataSet();
            entUsuario.TipoAccion = 68;
            ds = NUsuario.MantenimientoSuperUsuario(entUsuario);

            if (ds.Tables[0].Rows[0]["CODIGO"].ToString() != "NO HAY DATOS")
            {
                gvAdministrador.DataSource = ds.Tables[0];
                gvAdministrador.DataBind();
                ViewState["dtAdministrador"] = ds.Tables[0];
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

        
       

       

        #region gvPeriodo_RowDeleting


        protected void gvAdministrador_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)ViewState["dtAdministrador"];
                EUsuario entUsuario = new EUsuario();
                DataSet ds = new DataSet();
                entUsuario.TipoAccion = 67;
              
               
                entUsuario.Codigo = Convert.ToInt32(dt.Rows[e.RowIndex]["CODIGO"].ToString());

                ds = NUsuario.MantenimientoSuperUsuario(entUsuario);

                if (ds.Tables[0].Rows[0]["RESULTADO"].ToString() == "0")
                {
                    dt.Rows.Remove(dt.Rows[e.RowIndex]);

                    gvAdministrador.DataSource = dt;
                    gvAdministrador.DataBind();
                    ViewState["dtAdministrador"] = dt;

                    ELog entLog = new ELog();
                    entLog.TipoAccion = 1;//LOG PROCESOS
                    entLog.Usuario = Session["sesionUsuario"].ToString();
                    entLog.Descripcion = "Elimina Usuario";
                    NLog.InsertaLog(entLog);

                }
                else
                {
                    MensajeError("Error al eliminar usuario");
                }

                script = "ajustarContenidoTiempo();";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Script", script, true);

            }
            catch (Exception ex)
            {
                descripcionLog = ex.Message.ToString();
                ELog entLog = new ELog();
                entLog.TipoAccion = 2;//LOG ERRORES
                entLog.Descripcion = "gvAdministrador_RowDeleting" + " / " + descripcionLog;
                entLog.Usuario = Session["sesionUsuario"].ToString();
                NLog.InsertaLog(entLog);
            }
        }

        #endregion

        protected void gvAdministrador_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int Codigo = Convert.ToInt32(gvAdministrador.DataKeys[e.NewSelectedIndex].Value);
           Response.Redirect(string.Format("NuevoAdministrador.aspx?id={0}", Codigo));
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoAdministrador.aspx");
        }

        protected void gvAdministrador_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.Cells[5].Text == "3")
            {
                e.Row.Cells[5].Text =  "Director";
            }

            if (e.Row.Cells[5].Text == "4")
            {
                e.Row.Cells[5].Text = "Administrador";
            }


            if (e.Row.Cells[4].Text == "1")
            {
                e.Row.Cells[4].Text = "Activo";
            }

            if (e.Row.Cells[4].Text == "2")
            {
                e.Row.Cells[4].Text = "Inactivo";
            }
        }

       

    }
}