using Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        TB_idioma.ReadOnly = true;
        TB_terminacion.ReadOnly = true;
        L_Usercs log = new L_Usercs();
        string idioma = TB_idioma.Text;
        string terminacion = TB_terminacion.Text;
        log.insertarIdioma(idioma,terminacion);
        DataTable dat = log.ObtenerIdioE(idioma);
        LB_idIdioma.Text = dat.Rows[0]["id"].ToString();

    }

    protected void DDL_traduir_SelectedIndexChanged(object sender, EventArgs e)
    {
        L_Usercs log = new L_Usercs();

        int form = int.Parse(DDL_forms.SelectedValue.ToString());
        DataTable datos = log.controles(i, form);
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
       
        DataRow row = agrega.NewRow();
        DataColumn colum;

        colum = new DataColumn();
        colum.DataType = System.Type.GetType("System.String");
        colum.ColumnName = "contenido";
        agrega.Columns.Add(colum);

        row["contenido"] = TB_contenido.Text;
        agrega.Rows.Add(row);
    }
}