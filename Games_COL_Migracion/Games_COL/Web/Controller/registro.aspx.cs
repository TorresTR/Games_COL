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

public partial class View_registro : System.Web.UI.Page
{
    
    U_Datos datos = new U_Datos();
    L_Usercs dat = new L_Usercs();
    

    

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 57;
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


        LB_titReg.Text = compIdioma["LB_titReg"].ToString();
        LB_nombre.Text = compIdioma["LB_nombre"].ToString();
        LB_nick.Text = compIdioma["LB_nick"].ToString();
        LB_correo.Text = compIdioma["LB_correo"].ToString();
        LB_contra.Text = compIdioma["LB_contra"].ToString();
        LB_confirma.Text = compIdioma["LB_confirma"].ToString();
        B_registrar.Text = compIdioma["B_registrar"].ToString();
        B_volver.Text = compIdioma["B_volver"].ToString();


    }

    protected void B_registrar_Click(object sender, EventArgs e)
    {
        
        ClientScriptManager cm = this.ClientScript;
        datos.Nombre = TB_nombre.Text.ToString();
        datos.Nick = TB_nick.Text.ToString();
        datos.Pass = TB_pass.Text.ToString();
        datos.Correo = TB_email.Text.ToString();
        datos.Confirma = TB_confirmapass.Text.ToString();
        datos.Puntos = 0;
        datos.Rol = 1;
        datos.Rango = 1;
        datos.Estado = 1;
        datos.Fecha = DateTime.Now;


        datos = dat.insertarUsuarionuevo(datos);
        cm.RegisterClientScriptBlock(this.GetType(), "", datos.Mensaje1);
        LB_mensaje.Text = datos.Mensaje1.ToString();

    }


    protected void B_volver_Click(object sender, EventArgs e)
    {

        U_user inicio = new U_user();
        L_Usercs llamado = new L_Usercs();

        inicio = llamado.irInicio();
        Response.Redirect(inicio.Link_demas);
    }
}