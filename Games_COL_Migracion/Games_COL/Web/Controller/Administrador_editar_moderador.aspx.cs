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


        Int32 idioma = 1;
        Int32 id_pagina = 7;
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



        LB_titNombre.Text = compIdioma["LB_titNombre"].ToString();
        LB_titNick.Text = compIdioma["LB_titNick"].ToString();
        LB_titPuntos.Text = compIdioma["LB_titPuntos"].ToString();
        LB_titRango.Text = compIdioma["LB_titRango"].ToString();
        LB_titCorreo.Text = compIdioma["LB_titCorreo"].ToString();
        BT_editar.Text = compIdioma["BT_editar"].ToString();
        BT_guardar.Text = compIdioma["BT_guardar"].ToString();
        BT_volver.Text = compIdioma["BT_volver"].ToString();


        L_Usercs dac = new L_Usercs();
        L_persistencia per = new L_persistencia();
        int a = int.Parse(Session["parametro"].ToString());

        DataTable regis = dac.ToDataTable(per.obtenerUser(a));
        U_Datos moder = dac.datosModerador(regis);
        
            LB_id.Text = moder.Id.ToString();
            LB_nombre.Text = moder.Nombre;
            LB_nick.Text = moder.Nick;
            LB_puntos.Text = moder.Puntos.ToString();
            LB_rango.Text = moder.Confirma;
            LB_correo.Text = moder.Correo;

            BT_guardar.Visible = moder.Bin;
            TB_nombre.Visible = moder.Bin;
            TB_nick.Visible = moder.Bin;
            TB_puntos.Visible = moder.Bin;
            DDL_rango.Visible = moder.Bin;
            TB_correo.Visible = moder.Bin;

        }
    

    protected void BT_guardar_Click(object sender, EventArgs e)
    {


        L_Usercs dac = new L_Usercs();
        U_Datos user = new U_Datos();
        int b = int.Parse(Session["userid"].ToString());

        user.Id = int.Parse(LB_id.Text.ToString());
        user.Nombre = TB_nombre.Text.ToString();
        user.Nick = TB_nick.Text.ToString();
        user.Puntos = int.Parse(TB_puntos.Text.ToString());
        user.Rango = int.Parse(DDL_rango.SelectedValue.ToString());
        user.Correo = TB_correo.Text.ToString();
        U_user dat = new U_user();

        dac.actualizarUser(user);
        dat = dac.listadoUser();

        Response.Redirect(dat.Link_observador);
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
       
        U_user dat = new U_user();
        L_Usercs dac = new L_Usercs();
        dat = dac.listadoUser();

        Response.Redirect(dat.Link_observador);
    }

    protected void BT_editar_Click(object sender, EventArgs e)
    {
        TB_nombre.Text = LB_nombre.Text;
        TB_nick.Text = LB_nick.Text;
        TB_puntos.Text = LB_puntos.Text;
        TB_correo.Text = LB_correo.Text;

        BT_guardar.Visible = true;
        TB_nombre.Visible = true;
        TB_nick.Visible = true;
        TB_puntos.Visible = true;
        DDL_rango.Visible = true;
        TB_correo.Visible = true;
    }

}