using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;
using Datos;
using System.Collections;

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 58;
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


        LB_ingresar.Text = compIdioma["LB_ingresar"].ToString();
        L_UserName.Text = compIdioma["L_UserName"].ToString();
        L_contraseña.Text = compIdioma["L_contraseña"].ToString();
        HL_recuperar.Text = compIdioma["HL_recuperar"].ToString();
        BT_Ingresar.Text = compIdioma["BT_ingresar"].ToString();
        BT_registro.Text = compIdioma["BT_registro"].ToString();
        B_volver.Text = compIdioma["B_volver"].ToString();

    }




    protected void BT_Ingresar_Click(object sender, EventArgs e)
    {


        U_logueo usuario = new U_logueo();
        U_user link = new U_user();
        D_User datos = new D_User();
        L_Usercs user = new L_Usercs();
        U_Datos llamado = new U_Datos();

        usuario.Nick = TB_UserName.Text.ToString();
        usuario.Pass = TB_Contraseña.Text.ToString();
        string a = Session.SessionID;
        int id = user.consultaid(usuario.Nick);
        user.validar_Bloqueo(id);
        
        DataTable registros = datos.loggin(usuario);
        llamado.Sesion = registros.Rows[0]["user_id"].ToString();
        //string sesion = Session["user_id"].ToString();

        Session["user_id"] = llamado.Sesion;

        link = user.loggin(registros,a,usuario.Nick,id);

        L_error.Text = link.Mensaje_Alertaobservador1;
        Response.Redirect(link.Link_demas);

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
