using Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_Administrador_listado_user : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 10;
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

        LB_titUsarios.Text = compIdioma["LB_titUsuarios"].ToString();
        LB_titModer.Text = compIdioma["LB_titModer"].ToString();
        LB_titAdministradores.Text = compIdioma["LB_titAdministradores"].ToString();
        BT_reporUser.Text = compIdioma["BT_reporUser"].ToString();
        BT_reporModer.Text = compIdioma["BT_reporModer"].ToString();
        BT_reporAdmin.Text = compIdioma["BT_reporAdmin"].ToString();
        BT_volver.Text = compIdioma["BT_volver"].ToString();
        DL_admin.DataBind();
        DL_moder.DataBind();
        DL_usuarios.DataBind();

    }


    protected void DL_usuarios_RowDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Item.FindControl("LB_titNombre")).Text = ((Hashtable)Session["mensajes"])["LB_titNombre"].ToString();
                ((Label)e.Item.FindControl("LB_titNick")).Text = ((Hashtable)Session["mensajes"])["LB_titNick"].ToString();
                ((Label)e.Item.FindControl("LB_titPuntos")).Text = ((Hashtable)Session["mensajes"])["LB_titPuntos"].ToString();
                ((Label)e.Item.FindControl("LB_titRango")).Text = ((Hashtable)Session["mensajes"])["LB_titRango"].ToString();
                ((Label)e.Item.FindControl("LB_titCorreo")).Text = ((Hashtable)Session["mensajes"])["LB_titCorreo"].ToString();
                ((Button)e.Item.FindControl("BT_editar")).Text = ((Hashtable)Session["mensajes"])["BT_editar"].ToString();
                ((Button)e.Item.FindControl("BT_eliminar")).Text = ((Hashtable)Session["mensajes"])["BT_eliminar"].ToString();
                
            }
            catch (Exception exe)
            {

                ((Button)e.Item.FindControl("BT_editar")).Text = ((Hashtable)Session["mensajes"])["BT_editar"].ToString();
                ((Button)e.Item.FindControl("BT_eliminar")).Text = ((Hashtable)Session["mensajes"])["BT_eliminar"].ToString();
            }
        }
        catch (Exception exx)
        {
        }

    }

    protected void DL_moder_RowDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Item.FindControl("LB_titNombre")).Text = ((Hashtable)Session["mensajes"])["LB_titNombre"].ToString();
                ((Label)e.Item.FindControl("LB_titNick")).Text = ((Hashtable)Session["mensajes"])["LB_titNick"].ToString();
                ((Label)e.Item.FindControl("LB_titPuntos")).Text = ((Hashtable)Session["mensajes"])["LB_titPuntos"].ToString();
                ((Label)e.Item.FindControl("LB_titRango")).Text = ((Hashtable)Session["mensajes"])["LB_titRango"].ToString();
                ((Label)e.Item.FindControl("LB_titCorreo")).Text = ((Hashtable)Session["mensajes"])["LB_titCorreo"].ToString();
                ((Button)e.Item.FindControl("BT_editar")).Text = ((Hashtable)Session["mensajes"])["BT_editar"].ToString();
                ((Button)e.Item.FindControl("BT_eliminar")).Text = ((Hashtable)Session["mensajes"])["BT_eliminar"].ToString();

            }
            catch (Exception exe)
            {

                ((Button)e.Item.FindControl("BT_editar")).Text = ((Hashtable)Session["mensajes"])["BT_editar"].ToString();
                ((Button)e.Item.FindControl("BT_eliminar")).Text = ((Hashtable)Session["mensajes"])["BT_eliminar"].ToString();
            }
        }
        catch (Exception exx)
        {
        }

    }

    protected void DL_admin_RowDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Item.FindControl("LB_titNombre")).Text = ((Hashtable)Session["mensajes"])["LB_titNombre"].ToString();
                ((Label)e.Item.FindControl("LB_titNick")).Text = ((Hashtable)Session["mensajes"])["LB_titNick"].ToString();
                ((Label)e.Item.FindControl("LB_titPuntos")).Text = ((Hashtable)Session["mensajes"])["LB_titPuntos"].ToString();
                ((Label)e.Item.FindControl("LB_titRango")).Text = ((Hashtable)Session["mensajes"])["LB_titRango"].ToString();
                ((Label)e.Item.FindControl("LB_titCorreo")).Text = ((Hashtable)Session["mensajes"])["LB_titCorreo"].ToString();
                

            }
            catch (Exception exe)
            {

                
            }
        }
        catch (Exception exx)
        {
        }

    }


    protected void BT_editar_Click(object sender, EventArgs e)
    {

        L_Usercs log = new L_Usercs();
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int h = int.Parse(ID);
        U_user dat = new U_user();

        string ui = Session["user_id"].ToString();
        Session["parametro"] = ID;


        dat = log.editarListadoAdmin();

        Response.Redirect(dat.Link_observador);
    }

    protected void BT_editar_moder_Click(object sender, EventArgs e)
    {

        L_Usercs log = new L_Usercs();
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int h = int.Parse(ID);
        U_user dat = new U_user();

        string ui = Session["user_id"].ToString();
        Session["parametro"] = ID;


        dat = log.editarListadoAdminmoder();

        Response.Redirect(dat.Link_observador);
    }

    protected void BT_eliminar_Click(object sender, EventArgs e)
    {
       
        Button btn = (Button)sender;
        L_persistencia log = new L_persistencia();
        L_Usercs dac = new L_Usercs();
        Entity_usuario user = new Entity_usuario();
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int h = int.Parse(ID);
        DataTable dato = dac.obtenerUsuario(h);

        user.Id = h;
        user.Nombre = dato.Rows[0]["nombre"].ToString();
        user.Nick = dato.Rows[0]["nick"].ToString();
        user.Puntos = int.Parse(dato.Rows[0]["puntos"].ToString());
        user.Id_rango = int.Parse(dato.Rows[0]["id_rango"].ToString());
        user.Correo = dato.Rows[0]["correo"].ToString();
        user.Contra = dato.Rows[0]["contra"].ToString();
        user.Id_rol = int.Parse(dato.Rows[0]["id_rol"].ToString());
        user.Estado = int.Parse(dato.Rows[0]["estado"].ToString());
        user.Session = dato.Rows[0]["session"].ToString();
        user.Interaciones = int.Parse(dato.Rows[0]["interacciones"].ToString());
        user.Fecha_interaccion = DateTime.Parse(dato.Rows[0]["fecha_interaccion"].ToString());

        log.borrarUsuario(user);



        U_user dat = dac.retornoAdmin();

        Response.Redirect(dat.Link_observador );
    }

    protected void BT_reporUser_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();


        dat = llamado.reporteUser();

        Response.Redirect(dat.Link_observador );

    }

    protected void BT_reporModer_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();


        dat = llamado.reporteModer();

        Response.Redirect(dat.Link_observador);
    }

    protected void BT_reporAdmin_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();
 

        dat = llamado.reporteAdmin();

        Response.Redirect(dat.Link_observador );
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.retornoAdmin();

        Response.Redirect(dat.Link_observador);
    }
}