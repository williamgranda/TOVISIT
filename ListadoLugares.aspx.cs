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
    public partial class ListadoLugares : System.Web.UI.Page
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
            DataTable dtLugar = new DataTable();
            dtLugar.Columns.Add("ID_LUGAR", typeof(String));
            dtLugar.Columns.Add("USUARIO", typeof(String));
            dtLugar.Columns.Add("DESCRIPCION", typeof(String));
            dtLugar.Columns.Add("NOMBRE_LUGAR", typeof(String));
            dtLugar.Columns.Add("DESCRIPCION_LUGAR", typeof(String));
            dtLugar.Columns.Add("IMAGEN_LUGAR", typeof(String));
            dtLugar.Columns.Add("COORDENADAS", typeof(String));
            dtLugar.Columns.Add("LAT", typeof(String));
            dtLugar.Columns.Add("LNG", typeof(String));
            dtLugar.Columns.Add("ESTADO", typeof(String));


            gvLugar.DataSource = dtLugar;
            gvLugar.DataBind();
            ViewState["dtLugar"] = dtLugar;



        }
        #endregion



        private void CargaDatos()
        {
            ELugar entLugar = new ELugar();
            DataSet ds = new DataSet();
            entLugar.TipoAccion = 6;
            ds = NLugar.MantenimientoLugares(entLugar);

            if (ds.Tables[0].Rows[0]["ID_LUGAR"].ToString() != "NO HAY DATOS")
            {
                gvLugar.DataSource = ds.Tables[0];
                gvLugar.DataBind();
                ViewState["dtLugar"] = ds.Tables[0];
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












        protected void gvLugar_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int Codigo = Convert.ToInt32(gvLugar.DataKeys[e.NewSelectedIndex].Value);
            Response.Redirect(string.Format("NuevoLugar.aspx?id={0}", Codigo));
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoLugar.aspx");
        }

        protected void gvLugar_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

        }



    }
}