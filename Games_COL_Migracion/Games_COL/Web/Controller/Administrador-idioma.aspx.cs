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

    Int32 idio =1;
    Int32 form = 1;
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 85;
        try
        {
            idioma = Int32.Parse(Session["valor_ddl"].ToString());
        }
        catch
        {
            idioma = 1;
        }
        
        L_Usercs Idio = new L_Usercs();
        DataTable info = Idio.traducir(id_pagina, idioma);

        Hashtable compIdioma = new Hashtable();
        Session["mensajes"] = compIdioma;
        compIdioma = Idio.hastableIdioma(info, compIdioma);


        LB_titElimina.Text = compIdioma["LB_titEliminar"].ToString();
        BT_eliminar.Text = compIdioma["BT_eliminar"].ToString();
        BT_guardar.Text = compIdioma["BT_guardar"].ToString();
        BT_volver.Text = compIdioma["BT_volver"].ToString();
        BT_agregar.Text = compIdioma["BT_agregar"].ToString();
        LB_titulo.Text = compIdioma["LB_titulo"].ToString();
        //GV_controles.DataBind();

    }

    

        protected void GV_Idioma_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        try
        {
            try
            {
                ((Button)e.Row.FindControl("BT_editar")).Text = ((Hashtable)Session["mensajes"])["BT_editar"].ToString();
                ((Label)e.Row.FindControl("LB_titCont")).Text = ((Hashtable)Session["mensajes"])["LB_titCont"].ToString();
                ((Label)e.Row.FindControl("LB_titEdit")).Text = ((Hashtable)Session["mensajes"])["LB_titEdit"].ToString();
            }
            catch (Exception exe)
            {

                ((Button)e.Row.FindControl("BT_editar")).Text = ((Hashtable)Session["mensajes"])["BT_editar"].ToString();
            }
        }
        catch (Exception exx)
        {
        }

    }

    protected void DDL_elimina_SelectedIndexChanged(object sender, EventArgs e)
    {
        LB_idiomaEli.Text = DDL_IdiomaEl.SelectedItem.ToString();
        LB_idEli.Text = DDL_IdiomaEl.SelectedValue.ToString();

    }

    protected void DDL_lenguaje_SelectedIndexChanged(object sender, EventArgs e)
    {
        L_Usercs log = new L_Usercs();
        L_persistencia llamado = new L_persistencia();
        idio = int.Parse(DDL_Idioma.SelectedValue.ToString());
        form = int.Parse(DDL_forms.SelectedValue.ToString());

      

        DataTable datos= log.ToDataTable(llamado.obtenerIdiomacontroles(idio,form));

        GV_controles.DataSource = datos;
        GV_controles.DataBind();

    }

    protected void changePage(object sender, GridViewPageEventArgs e)
    {
        GridView gv = new GridView();
        gv.PageIndex = e.NewPageIndex;
        

    }

    protected void BT_eliminar_Click(object sender, EventArgs e)
    {
       
        int i;
        int sesion=1;
        L_Usercs log = new L_Usercs();
        try
        {
             i = int.Parse(LB_idEli.Text);
            sesion = int.Parse(Session["valor_ddl"].ToString());
        }
        catch
        {
             i = 1;
        }
        
        U_Datos dato = log.comparaIdioma(i,sesion);
        string mensaje = dato.Mensaje1;
        ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
        Session["valor_ddl"] = dato.Id;
        LB_idEli.Text = "";
        L_Usercs dac = new L_Usercs();
        U_user datos = new U_user();
        U_Datos val = new U_Datos();

        datos.Session = Session.SessionID;
        datos = dac.cerrarse(datos);

        Session["user_id"] = null;


        val.Sesion = null;
        dac.validarCerrarsesion(val);

        Response.Redirect(datos.Link_observador);


    }

   

    protected void BT_guardar_Click(object sender, EventArgs e)
    {
        L_Usercs log = new L_Usercs();
        

        int id = int.Parse(LB_id.Text);
        string cont = TB_cont.Text;

        log.editarCont(id,cont);

        TB_cont.Text = "";
        LB_id.Text = "";
        //GV_controles.DataBind();
    }



 

    protected void BT_eliminarIdi_Click(object sender, EventArgs e)
    {
        LB_titElimina.Visible = true;
        DDL_IdiomaEl.Visible = true;
        BT_eliminar.Visible = true;
        
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Administrador.aspx");
    }

    protected void BT_agregar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Administrador_agregar_idioma.aspx");
    }

    
    protected void BT_editar_Click(object sender, EventArgs e)
    {
        Button bt = sender as Button;
        GridViewRow grid = (GridViewRow)bt.NamingContainer;
        Label IdRecogido = (Label)grid.FindControl("LB_idobp");
        Label content = (Label)grid.FindControl("LB_contentob");
        Label control = (Label)grid.FindControl("LB_controlob");
        Label formulario = (Label)grid.FindControl("LB_formuob");
        Label idioma = (Label)grid.FindControl("LB_idioob");

        TB_cont.Text = content.Text;
        LB_id.Text = IdRecogido.Text;
       
    }
}