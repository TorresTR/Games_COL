using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Moderador_ver_noticias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        U_userCrearpost doc = new U_userCrearpost();
        L_Usercs dac = new L_Usercs();


        doc.Id = int.Parse(obQueryString["parametro"].ToString());
        int x = int.Parse(obQueryString["parametro"].ToString());

        doc = dac.postObservadorNoticias(doc);


        LB_verPost.Text = doc.Contenido1.ToString();
        LB_autor.Text = doc.Autor1.ToString();

        GV_comentarios.DataSource = dac.obtenerComentario(x);
        GV_comentarios.DataBind();



    }



    protected void B_volver_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        string z = obQueryString["userid"].ToString();


        obQueryString.Add("userid", z);

        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.irHomeModerador();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

    }
}