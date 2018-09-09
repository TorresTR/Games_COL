using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Administrador_verpqrCompleto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();


        U_Datospqr respuesa = new U_Datospqr();
        L_Usercs logica = new L_Usercs();

        respuesa.Id_pqr = int.Parse(Session["parametro"].ToString());



        DataTable regis = logica.pqr(respuesa);
        respuesa = logica.pqr(regis);

        LB_muestraPag.Text = respuesa.Contenido;
        LB_autor.Text = respuesa.Autor;
    }

    protected void BT_responder_Click(object sender, EventArgs e)
    {
 
        L_Usercs user = new L_Usercs();
        U_Datospqr respuesa = new U_Datospqr();


        int b = int.Parse(Session["user_id"].ToString());
        int q = int.Parse(Session["parametro"].ToString());
        int a = 1;
        DateTime dt = DateTime.Now;

        respuesa.Id_respondedor = b;
        respuesa.Fecha_respuesta = dt;
        respuesa.Respuesta = TB_respuestapqr.Text.ToString();
        respuesa.Id_pqr = q;
        respuesa.Estado_respuesta = a;

        user.actualizarpqr(respuesa);
        string par = q.ToString();
        string ui = b.ToString();

        Response.Redirect("Administrador_ver_pqr.aspx");

    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
      
        string q = Session["user_id"].ToString();
        string z = Session["parametro"].ToString();

        Response.Redirect("Administrador_ver_pqr.aspx" );
    }
}