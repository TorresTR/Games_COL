using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using Logica;
using Utilitarios;
using System.Web.UI.WebControls;

public partial class View_Administrador_editar_noticia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);
        Response.Cache.SetNoStore();

        U_userCrearpost doc = new U_userCrearpost();
        L_Usercs dac = new L_Usercs();


        doc.Id = int.Parse(obQueryString["parametro"].ToString());
        int x = int.Parse(obQueryString["userid"].ToString());

        doc = dac.postObservadorNoticias(doc);

        LB_muestraContenido.Text = doc.Contenido1.ToString();
        LB_verAutor.Text = doc.Autor1.ToString();
        Ck_editar.Visible = false;
        BT_editar.Visible = false;


    }

    protected void BT_editar_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        L_Usercs dac = new L_Usercs();
        U_userCrearpost post = new U_userCrearpost();
        U_user link = new U_user();

        post.Id = int.Parse(obQueryString["parametro"].ToString());
        post.Contenido1 = Ck_editar.Text.ToString();

        dac.actualizaModernoticia(post);
        link = dac.miNoticia();

        Response.Redirect(link.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

    }

    protected void Bt_editarCk_Click(object sender, EventArgs e)
    {
        Ck_editar.Text = LB_muestraContenido.Text;
        Ck_editar.Visible = true;
        BT_editar.Visible = true;
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        dat = llamado.miNoticia();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

    }
}