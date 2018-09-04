﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;
using Datos;


public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Response.Cache.SetNoStore();

    }




    protected void BT_Ingresar_Click(object sender, EventArgs e)
    {


        U_logueo usuario = new U_logueo();
        U_user link = new U_user();
        D_User datos = new D_User();
        L_Usercs user = new L_Usercs();
        usuario.Nick = TB_UserName.Text.ToString();
        usuario.Pass = TB_Contraseña.Text.ToString();
        string a = Session.SessionID;
        
        DataTable registros = datos.loggin(usuario);
        Session["user_id"] = registros.Rows[0]["user_id"].ToString();
        string sesion = Session["user_id"].ToString();
        QueryString obQueryString = new QueryString();

        link = user.loggin(registros, sesion,a);
        string b = registros.Rows[0]["user_id"].ToString();

        obQueryString.Add("userid", b);
        Response.Redirect(link.Link_demas + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

    }



    protected void BT_registro_Click(object sender, EventArgs e)
    {
        Response.Redirect("registro.aspx");
    }

    protected void B_olvido_Click(object sender, EventArgs e)
    {
        Response.Redirect("Generar_token.aspx");
    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
        U_userCrearpost retorno = new U_userCrearpost();
        L_Usercs data = new L_Usercs();

        retorno = data.retornoObservador();
        Response.Redirect(retorno.Link);

    }
}
