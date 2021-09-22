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
    public partial class ListadoActividad : System.Web.UI.Page
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
            DataTable dtActividad = new DataTable();
            dtActividad.Columns.Add("ID_ACTIVIDAD", typeof(String));
            dtActividad.Columns.Add("USUARIO", typeof(String));
            dtActividad.Columns.Add("NOMBRE_LUGAR", typeof(String));
            dtActividad.Columns.Add("NOMBRE_ACTIVIDAD", typeof(String));
            dtActividad.Columns.Add("DESCRIPCION_ACTIVIDAD", typeof(String));
            dtActividad.Columns.Add("FECHA_INICIO", typeof(String));
            dtActividad.Columns.Add("FECHA_FIN", typeof(String));
            dtActividad.Columns.Add("ESTADO", typeof(String));

                        gvActividad.DataSource = dtActividad;
            gvActividad.DataBind();
            ViewState["dtActividad"] = dtActividad;



        }
        #endregion



        private void CargaDatos()
        {
            ETipo entTipo = new ETipo();
            DataSet ds = new DataSet();
            entTipo.TipoAccion = 8;
            ds = NTipo.MantenimientoTipo(entTipo);

            if (ds.Tables[0].Rows[0]["ID_ACTIVIDAD"].ToString() != "NO HAY DATOS")
            {
                gvActividad.DataSource = ds.Tables[0];
                gvActividad.DataBind();
                ViewState["dtActividad"] = ds.Tables[0];
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












        protected void gvActividad_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int Codigo = Convert.ToInt32(gvActividad.DataKeys[e.NewSelectedIndex].Value);
            Response.Redirect(string.Format("NuevoActividad.aspx?id={0}", Codigo));
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoActividad.aspx");
        }

        protected void gvActividad_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

        }

        protected void gvActividad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvActividad_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //se obtiene el nombre de campo definido en el DataKeyNames del gridview
            int id = Convert.ToInt32(gvActividad.DataKeys[e.RowIndex].Value);

         DeleteById(id);

            
        }

        public static void DeleteById(int Id)
        {

            SqlConnection cnx = new SqlConnection("Data Source=localhost;Initial Catalog=TOVISIT_APP;Persist Security Info=True;User ID=sa;Password=2959714");

            
            {

                cnx.Open();
                string query = @"UPDATE TOVISIT_ACTIVIDAD SET ESTADO= 2 wHERE ID_ACTIVIDAD = @id";

                SqlCommand cmd = new SqlCommand(query, cnx);
                cmd.Parameters.AddWithValue("@id", Id);

                cmd.ExecuteNonQuery();

            }
        }

    }
}