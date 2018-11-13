using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Text;
using Utilitarios;
using Logica;
using System.Data;
using System.Collections;

public partial class View_Generar_token : System.Web.UI.Page
{
    string mensaje1;
    string mensaje2;
    string mensaje3;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 61;
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


        LB_digiteNick.Text = compIdioma["LB_digiteNick"].ToString();
        B_aceptar.Text = compIdioma["B_aceptar"].ToString();
        B_volver.Text = compIdioma["B_volver"].ToString();
        mensaje1 = compIdioma["enviada"].ToString();
        mensaje2 = compIdioma["token"].ToString();
        mensaje3 = compIdioma["usuario_existe"].ToString();
    }

    

    protected void B_aceptar_Click(object sender, EventArgs e)
    {
        L_Usercs log = new L_Usercs();
        string valida = TB_nick.Text;
        System.Data.DataTable validez = log.genera(valida);
        string mensaje = log.Token(validez,mensaje1,mensaje2,mensaje3);
        
        //L_error.Text =mensaje;
        Response.Write("<Script Language='JavaScript'>parent.alert('" + mensaje + "');</Script>");


    }

    

    protected void B_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Observador.aspx");
    }
}