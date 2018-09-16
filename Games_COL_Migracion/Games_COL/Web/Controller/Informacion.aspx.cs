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


public partial class View_Informacionaspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 idioma = 1;
        Int32 id_pagina = 59;
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
        LB_puntosNec.Text = compIdioma["LB_puntosNec"].ToString();
        LB_bebe.Text = compIdioma["LB_bebe"].ToString();
        LB_iniciado.Text = compIdioma["LB_iniciado"].ToString();
        LB_campesino.Text = compIdioma["LB_campesino"].ToString();
        LB_caballero.Text = compIdioma["LB_caballero"].ToString();
        LB_heroe.Text = compIdioma["LB_heroe"].ToString();
        LB_ascendido.Text = compIdioma["LB_ascendido"].ToString();
        LB_info2.Text = compIdioma["LB_info2"].ToString();
        BT_volver.Text = compIdioma["BT_volver"].ToString();
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        U_user inicio = new U_user();
        L_Usercs llamado = new L_Usercs();

        inicio = llamado.irInicio();
        Response.Redirect(inicio.Link_demas);
    }
}