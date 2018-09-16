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
        Response.Cache.SetNoStore();
        L_Usercs log = new L_Usercs();
        int cont = Request.QueryString.Count;
        string var = Request.QueryString[0];

        U_token inicio = log.validaToken(cont,var);

        LB_mensaje.Text = inicio.Nombre;
        Session["user_id"] = inicio.Id;
        Int32 idioma = 1;
        Int32 id_pagina = 56;
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


        LB_titulo.Text = compIdioma["LB_titulo"].ToString();
        L_digite_nueva.Text = compIdioma["L_digite_nueva"].ToString();
        L_Repita_Contraseña.Text = compIdioma["L_Repita_Contraseña"].ToString();
        LB_mensaje.Text = compIdioma["LB_mensaje"].ToString();
        BT_cambiar_contraseña.Text = compIdioma["BT_cambiar_contraseña"].ToString();



    }

    protected void BT_cambiar_contraseña_Click(object sender, EventArgs e)
    {

        L_Usercs user = new L_Usercs();
        U_Datos eUser = new U_Datos();

        eUser.Id = int.Parse(Session["user_id"].ToString());
        eUser.Pass = TB_digite_nueva_contraseña.Text;

         user.contraseña(eUser);

        LB_mensaje.Text = "Su Contraseña ha sido actualizada";
        
    }
}