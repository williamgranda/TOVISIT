using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CORD.EVALDTH.Entidades;
using CORD.EVALDTH.Negocio;
using System.Net;
using System.Text.RegularExpressions;

namespace CORD.EVALDTH
{
    public partial class ReportesPrueba : System.Web.UI.Page
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
                //LimpiarAlertas();
                if (!IsPostBack)
                {

                    InicializarObjetos();
                    CargaInicial();
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

        #region btnBuscar_Click
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                tblResultados.Visible = false;

                ECabecera_Evaluacion entCabecera_Evaluacion = new ECabecera_Evaluacion();
                DataSet ds = new DataSet();
                entCabecera_Evaluacion.TipoAccion = 55;
                entCabecera_Evaluacion.Unidad = txtInfoT.Text;
                entCabecera_Evaluacion.Usuario = Session["sesionUsuario"].ToString();
                ds = NCabecera_Evaluacion.MantenimientoCabecera_Evaluacion(entCabecera_Evaluacion);

                

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvEvaluacion.DataSource = ds.Tables[0];
                    gvEvaluacion.DataBind();
                    ViewState["dtEvaluacion"] = ds.Tables[0];

                    tblResultados.Visible = true;
                    MensajeError("");
                }
                else
                {
                    MensajeError("No existe información para la Unidad");
                }

                script = "ajustarContenidoTiempo();";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Script", script, true);
            }
            catch (Exception ex)
            {
                descripcionLog = ex.Message.ToString();
                ELog entLog = new ELog();
                entLog.TipoAccion = 2;//LOG ERRORES
                entLog.Descripcion = "btnBuscar_Click" + " / " + descripcionLog;
                entLog.Usuario = Session["sesionUsuario"].ToString();
                NLog.InsertaLog(entLog);
            }
        }
        #endregion
        private void CargaDatos()
        {
            ECabecera_Evaluacion entCabecera_Evaluacion = new ECabecera_Evaluacion();
            DataSet ds = new DataSet();
            entCabecera_Evaluacion.TipoAccion = 55;
            entCabecera_Evaluacion.Usuario = Session["sesionUsuario"].ToString();
            ds = NCabecera_Evaluacion.MantenimientoCabecera_Evaluacion(entCabecera_Evaluacion);

            if (ds.Tables[0].Rows[0]["ID_CABECERA"].ToString() != "NO HAY DATOS")
            {
                gvEvaluacion.DataSource = ds.Tables[0];
                gvEvaluacion.DataBind();
                ViewState["dtEvaluacion"] = ds.Tables[0];
            }
        }

        #region InicializarObjetos
        private void InicializarObjetos()
        {
            DataTable dtEvaluacion = new DataTable();
            dtEvaluacion.Columns.Add("ID_CABECERA", typeof(String));
            //dtEvaluacion.Columns.Add("FECHA_INICIO", typeof(String));
            //dtEvaluacion.Columns.Add("FECHA_FINAL", typeof(String));
            dtEvaluacion.Columns.Add("PERIODO", typeof(String));
            dtEvaluacion.Columns.Add("CEDULA", typeof(String));
            dtEvaluacion.Columns.Add("APELLLIDOSNOMBRES", typeof(String));
            dtEvaluacion.Columns.Add("NOMBRE_UNIDAD", typeof(String));
            dtEvaluacion.Columns.Add("DESCRIPCION_PUESTO", typeof(String));
            dtEvaluacion.Columns.Add("DESCRIPCION_GRUPO", typeof(String));
            dtEvaluacion.Columns.Add("ROL", typeof(String));
            dtEvaluacion.Columns.Add("DIRECTOR", typeof(String));
            dtEvaluacion.Columns.Add("IDENTIFICACION", typeof(String));

            gvEvaluacion.DataSource = dtEvaluacion;
            gvEvaluacion.DataBind();
            ViewState["dtEvaluacion"] = dtEvaluacion;

        }
        #endregion

        #region CargaInicial
        private void CargaInicial()
        {
            ECabecera_Evaluacion entCabecera_Evaluacion = new ECabecera_Evaluacion();
            DataSet ds = new DataSet();
            entCabecera_Evaluacion.TipoAccion = 26;
            ds = NCabecera_Evaluacion.MantenimientoCabecera_Evaluacion(entCabecera_Evaluacion);
          
           
        }
        #endregion

        #region LimpiarAlertas
        //private void LimpiarAlertas()
        //{
        //    divAlerta.Visible = false;
        //    lblAlerta.Text = "";
        //}
        #endregion

        #region MensajeOk
        //private void MensajeOk(string msj)
        //{
        //    divAlerta.Visible = true;
        //    lblAlerta.ForeColor = System.Drawing.ColorTranslator.FromHtml("#00937c");
        //    lblAlerta.Text = msj;
        //    form1.Focus();
        //}
        #endregion

        #region MensajeError
        //private void MensajeError(string msj)
        //{
        //    divAlerta.Visible = true;
        //    lblAlerta.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
        //    lblAlerta.Text = msj;
        //    form1.Focus();
        //}
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

        protected void gvEvaluacion_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            int Id_cabecera = Convert.ToInt32(gvEvaluacion.DataKeys[e.NewSelectedIndex].Value);
            Response.Redirect(string.Format("Reportes/RptPrueba.aspx?id={0}", Id_cabecera));
            
        }

       

       
        
    }
}