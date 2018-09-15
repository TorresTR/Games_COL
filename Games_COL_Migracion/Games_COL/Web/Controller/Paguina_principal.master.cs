using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Paguina_principal : System.Web.UI.MasterPage
{



    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        Int32 idioma = 1;
        Int32 id_pagina = 62;
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


        HL_ingresar.Text = compIdioma["HL_ingresar"].ToString();
        HL_registro.Text = compIdioma["HL_registro"].ToString();
        HL_contacto.Text = compIdioma["HL_contacto"].ToString();
        HL_informacion.Text = compIdioma["HL_informacion"].ToString();



    }


    //protected void DDL_lenguaje_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Int32 index = Int32.Parse(DDL_Idioma.SelectedValue.ToString());
    //    L_Usercs cambiar_cultura = new L_Usercs();
    //    String cultura = cambiar_cultura.select_idioma(index);
    //    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultura);
    //    Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultura);
    //    Session["mensajes"] = index;
    //    Int32 id_pagina = 62;
    //    try
    //    {
    //        L_Usercs Idio = new L_Usercs();
    //        DataTable info = Idio.traducir(id_pagina, index);

    //        Hashtable compIdioma = new Hashtable();
    //        Session["mensajes"] = compIdioma;
    //        compIdioma = Idio.hastableIdioma(info, compIdioma);


    //        HL_ingresar.Text = compIdioma["HL_ingresar"].ToString();
    //        HL_registro.Text = compIdioma["HL_registro"].ToString();
    //        HL_contacto.Text = compIdioma["HL_contacto"].ToString();
    //        HL_informacion.Text = compIdioma["HL_informacion"].ToString();
    //    }
    //    catch
    //    {

    //    }


    //}


}
