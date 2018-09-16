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

public partial class View_Moderador_informacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 35;
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


        LB_informacion.Text = compIdioma["LB_informacion"].ToString();
        LB_info.Text = compIdioma["LB_info"].ToString();
        LB_rango.Text = compIdioma["LB_rango"].ToString();
        LB_puntos.Text = compIdioma["LB_puntos"].ToString();
        LB_rey.Text = compIdioma["LB_rey"].ToString();
        LB_dios.Text = compIdioma["LB_dios"].ToString();
        LB_mano.Text = compIdioma["LB_mano"].ToString();
        LB_info2.Text = compIdioma["LB_info2"].ToString();
        BT_volver.Text = compIdioma["BT_volver"].ToString();
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();


        dat = llamado.irHomeModerador();

        Response.Redirect(dat.Link_observador);
    }
}