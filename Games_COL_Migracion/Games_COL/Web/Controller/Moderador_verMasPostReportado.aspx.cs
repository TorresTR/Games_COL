using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Moderador_verMasPostReportado : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();


        U_userCrearpost doc = new U_userCrearpost();
        L_Usercs dac = new L_Usercs();


        doc.Id = int.Parse(Session["parametro"].ToString());
        int x = int.Parse(Session["parametro"].ToString());

        doc=dac.obtenerPostObservadorreportadomoder(doc);


        LB_contenido.Text = doc.Contenido1.ToString();
        LB_mostrarAutor.Text = doc.Autor1.ToString();

       
    }





    protected void BT_volver_Click(object sender, EventArgs e)
    {

        int t = int.Parse(Session["user_id"].ToString());

        string dat = t.ToString();


        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.recargarationpost();
        Response.Redirect(data.Link_observador);
       
    }
}