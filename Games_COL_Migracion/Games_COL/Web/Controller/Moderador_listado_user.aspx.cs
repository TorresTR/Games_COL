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
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 idioma = 1;
        Int32 id_pagina = 36;
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

        DL_usuarios.DataBind();
        BT_volver.Text = compIdioma["BT_volver"].ToString();

        try
        {
            InfoR_moderador reporte = ObtenerInforme();
            CRS_moderador.ReportDocument.SetDataSource(reporte);
            CRV_reporte_moderador.ReportSource = CRS_moderador;
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void DL_noticias_RowDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Item.FindControl("LB_nick")).Text = ((Hashtable)Session["mensajes"])["LB_nick"].ToString();
                ((Label)e.Item.FindControl("LB_titPuntos")).Text = ((Hashtable)Session["mensajes"])["LB_titPuntos"].ToString();
                ((Label)e.Item.FindControl("LB_titRango")).Text = ((Hashtable)Session["mensajes"])["LB_titRango"].ToString();
                ((Button)e.Item.FindControl("BT_eliminar")).Text = ((Hashtable)Session["mensajes"])["BT_eliminar"].ToString();


            }
            catch (Exception exe)
            {

                ((Button)e.Item.FindControl("BT_verNoticias")).Text = ((Hashtable)Session["mensajes"])["BT_verNoticias"].ToString();
            }
        }
        catch (Exception exx)
        {
        }

    }

    protected InfoR_moderador ObtenerInforme()
    {
      
        DataTable informacion = new DataTable(); //dt
        InfoR_moderador datos = new InfoR_moderador();
        

        informacion = datos.Tables["Usuarios"];

        L_Usercs persona = new L_Usercs();

        persona.listadoModerador(informacion);

        return datos;
    }


    protected void BT_eliminar_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int h = int.Parse(ID);


        int b = int.Parse(Session["id"].ToString());



        L_Usercs dac = new L_Usercs();
        U_user data = new U_user();
       
       
        dac.eliminarUsermoderador(h);

      

        Response.Redirect("Moderador_listado_user.aspx" );
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {


        Response.Redirect("Moderador_listado_user.aspx" );
    }



    protected void DL_usuarios_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
}