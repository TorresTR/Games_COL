using Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Default : System.Web.UI.Page
{
    int i;
    DataTable agrega = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 idioma = 1;
        Int32 id_pagina = 86;
        try
        {
            idioma = Int32.Parse(Session["valor_ddl"].ToString());
            i = int.Parse(Session["valor_ddl"].ToString());
        }
        catch
        {
            idioma = 1;
            i = 1;
        }

        L_Usercs Idio = new L_Usercs();
        DataTable info = Idio.traducir(id_pagina, idioma);

        Hashtable compIdioma = new Hashtable();
        Session["mensajes"] = compIdioma;
        compIdioma = Idio.hastableIdioma(info, compIdioma);
        LB_idiomaA.Text = compIdioma["LB_idiomaA"].ToString();
        LB_terminacion.Text = compIdioma["LB_terminacion"].ToString();
        BT_agregar.Text = compIdioma["BT_agregar"].ToString();
        BT_traduccion.Text = compIdioma["BT_traduccion"].ToString();
        GV_agregar.DataBind();

    }

    protected void GV_Idioma_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Row.FindControl("LB_titCon")).Text = ((Hashtable)Session["mensajes"])["LB_titCon"].ToString();
                ((Label)e.Row.FindControl("LB_titTrad")).Text = ((Hashtable)Session["mensajes"])["LB_titTrad"].ToString();
            }
            catch (Exception exe)
            {

                ((Button)e.Row.FindControl("BT_traducir")).Text = ((Hashtable)Session["mensajes"])["BT_traducir"].ToString();
            }
        }
        catch (Exception exx)
        {
        }

    }

    protected void BT_agregar_Click(object sender, EventArgs e)
    {
        Session["idioma_agrega"] = TB_idioma.Text;
        BT_traduccion.Visible = true;
        TB_idioma.ReadOnly = true;
        TB_terminacion.ReadOnly = true;

        L_Usercs log = new L_Usercs();
        L_persistencia per = new L_persistencia();
        Entity_idioma idiom = new Entity_idioma();

        string idioma = TB_idioma.Text;
        string terminacion = TB_terminacion.Text;

        idiom.Nombre = idioma;
        idiom.Terminacion = terminacion;
        idiom.Estado = 2;

        Entity_usuario us = new Entity_usuario();
        us.Nombre = Session["user_id"].ToString();
        object segurity = new object();
        segurity = idiom;
        string schema = "usuario";
        string tabla = "idioma";
        per.auditoriaInsertar(segurity, us, schema, tabla);

        per.insertarIdioma(idiom);
       // log.insertarIdioma(idioma,terminacion);

        DataTable dat = log.ToDataTable(per.obtenerIdiomaEspe(idioma));

        LB_idIdioma.Text = dat.Rows[0]["id"].ToString();

        int i = int.Parse(LB_idIdioma.Text);
        
        

    }

    protected void DDL_traduir_SelectedIndexChanged(object sender, EventArgs e)
    {
        L_Usercs log = new L_Usercs();

        int form = int.Parse(DDL_forms.SelectedValue.ToString());

        L_persistencia contro = new L_persistencia();
        DataTable datos = log.ToDataTable(contro.obtenerControles(i, form));
        GV_agregar.DataSource = datos;
        GV_agregar.DataBind();
    }

        protected void BT_traducir_Click(object sender, EventArgs e)
    {
        LB_cont.Visible = true;
        TB_contenido.Visible = true;
        BT_traduccion.Visible = true;

        Button bt = sender as Button;
        GridViewRow grid = (GridViewRow)bt.NamingContainer;

        Label formulario = (Label)grid.FindControl("LB_formu");
        Label control = (Label)grid.FindControl("LB_contro");
        Label content = (Label)grid.FindControl("LB_content");
        Label Idformu = (Label)grid.FindControl("LB_idF");
        Label idioma = (Label)grid.FindControl("LB_idio");
        Label id = (Label)grid.FindControl("LB_idd");



        LB_idform.Text = Idformu.Text;
        LB_cont.Text = content.Text;
        LB_control.Text = control.Text;
    }

    protected void BT_traduccion_Click(object sender, EventArgs e)
    {
        //U_control control = new U_control();
        Entity_controlesIdioma contro = new Entity_controlesIdioma();
        try
        {
            contro.Nombre = LB_cont.Text;
            contro.Id_idioma = int.Parse(LB_idIdioma.Text);
            contro.Id_formulario = int.Parse(LB_idform.Text);
            contro.Contenido = TB_contenido.Text;

            //control.Nombre = LB_cont.Text;
            //control.Idioma = int.Parse(LB_idIdioma.Text);
            //control.Id_form = int.Parse(LB_idform.Text);
            //control.Contenido = TB_contenido.Text;

            L_persistencia per = new L_persistencia();
            L_Usercs log = new L_Usercs();
            per.insertarControlTraducido(contro);
            int i = int.Parse(LB_idIdioma.Text);
            log.comparaIdioma(i);
        }
        catch
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccione un control valido');", true);
        }
        
        LB_cont.Text = "";
        LB_control.Text = "";
        TB_contenido.Text = "";
       
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Administrador-idioma.aspx");
    }
}