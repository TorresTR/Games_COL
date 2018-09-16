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

public partial class View_contactenos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 60;
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


        LB_contactenos.Text = compIdioma["LB_contactenos"].ToString();
        LB_titulo.Text = compIdioma["LB_titulo"].ToString();
        LB_correo.Text = compIdioma["LB_correo"].ToString();
        LB_duda.Text = compIdioma["LB_duda"].ToString();
        BT_envioContacto.Text = compIdioma["BT_envio_Contacto"].ToString();
        B_volver.Text = compIdioma["B_volver"].ToString();
    }

    protected void BT_envioContacto_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        U_Sugerencia sugere = new U_Sugerencia();
        L_Usercs user = new L_Usercs();

        sugere.Correo = TB_correo.Text.ToString();
        sugere.Sugerencia = TB_sugerencias.Text.ToString();

       sugere = user.sugerenciasUsuarios(sugere);

        cm.RegisterClientScriptBlock(this.GetType(), "",sugere.Mensaje );
        Response.Redirect(sugere.Link);
        
        
    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
        U_user inicio = new U_user();
        L_Usercs llamado = new L_Usercs();

        inicio = llamado.irInicio();
        Response.Redirect(inicio.Link_demas);
    }
}