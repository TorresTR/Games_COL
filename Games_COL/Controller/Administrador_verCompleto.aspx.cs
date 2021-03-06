﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Plantilla_Administrador_verCompleto : System.Web.UI.Page
{
    int x, puntos = 0, num = 0, tot = 0;
    int h = 0;
    int puntos_total = 0;
    int val, pun;

    protected void Page_Load(object sender, EventArgs e)
    {


        Response.Cache.SetNoStore();

        EDatosCrearPost doc = new EDatosCrearPost();
        EDatosComenatrio comenta = new EDatosComenatrio();
        DAOUsuario dac = new DAOUsuario();

        int comparador_idpost = int.Parse(Request.Params["parametro"]);
        int comparador_iduser = int.Parse(Request.Params["userid"]);

        DataTable regisval = dac.obtenerpuntsval(comparador_iduser);

        DataTable data = dac.ObtenerInteraccion(comparador_iduser);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        if (inter == 10)
        {
            LB_mensaje.Text = "Maximo numero de interacciones por dia alcanzado";
            TB_comentarios.Visible = false;
            LB_comentar.Visible = false;
            BT_comentar.Visible = false;
            UpdatePanel1.Visible = false;
        }


        ClientScriptManager cm = this.ClientScript;
        doc.Id = int.Parse(Request.Params["parametro"]);
        int dato = int.Parse(Request.Params["parametro"]);



        DataTable regis = dac.verpag(doc);

        int contadordatos = regisval.Rows.Count;
        int contcolum = regisval.Columns.Count;


        foreach (DataRow fila in regisval.Rows)
        {
            string valor = fila["id_usuario"].ToString();
            string valor_post = fila["id_post"].ToString();

            if (comparador_idpost == int.Parse(valor_post) && comparador_iduser == int.Parse(valor))
            {
                UpdatePanel1.Visible = false;

            }
        }






        int b = int.Parse(Request.Params["userid"]);
        DataTable regis2 = dac.obtenerUss(b);
        String x = regis2.Rows[0]["nick"].ToString();
        String z = regis.Rows[0]["autor"].ToString();


   


        if (z == x)
        {
           
            UpdatePanel1.Visible = false;
        }




        if (regis.Rows.Count > 0)
        {

            LB_muestraPag.Text = regis.Rows[0]["contenido"].ToString();
            LB_autor.Text = regis.Rows[0]["autor"].ToString();

        }

        DataTable punt = dac.verpuntos(doc);
        if (punt.Rows.Count > 0)
        {
            puntos = int.Parse(punt.Rows[0]["puntos"].ToString());
            num = int.Parse(punt.Rows[0]["nump"].ToString());
            tot = puntos / num;
            LB_motrarPuntos.Text = tot.ToString();
        }

        GV_comentariosuser.DataSource = dac.ObtenerComent(dato);
        GV_comentariosuser.DataBind();




    }

    protected void Bt_uno_Click(object sender, EventArgs e)
    {


        ClientScriptManager cm = this.ClientScript;
        DAOUsuario dac = new DAOUsuario();
        EDatosCrearPost puntot = new EDatosCrearPost();

        int b = int.Parse(Request.Params["userid"]);
        int bn = int.Parse(Request.Params["parametro"]);
        DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(Request.Params["parametro"]);
        puntot.Id_user = int.Parse(Request.Params["userid"]);
        puntot.Fecha = dt;

        EDatosCrearPost doc = new EDatosCrearPost();
        doc.Id = int.Parse(Request.Params["parametro"]);
        Int32 v = int.Parse(Request.Params["parametro"]);

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = dac.obtenerUss(b);
        String o = regis2.Rows[0]["nick"].ToString();
        String p = regis.Rows[0]["autor"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        if (inter < 10)
        {
            inter = inter + 1;
            if (o != p)
            {

                String d = punt.Rows[0]["id"].ToString();

                if (v == int.Parse(d))
                {

                    String a = punt.Rows[0]["puntos"].ToString();

                    val = int.Parse(a);
                    val = val + 1;

                    String puntosA = punt.Rows[0]["puntosautor"].ToString();
                    pun = int.Parse(puntosA);
                    pun = pun + 1;


                    puntot.Puntos = val;
                    puntot.Interacciones = inter;
                    puntot.PuntosA = pun;

                    dac.guardaPuntos(puntot);
                }


            }
        }


        int z = int.Parse(Request.Params["parametro"]);


        DataTable regis3 = dac.obtenerUss(b);
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());

        x = x + 1;





        dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);

        Response.Redirect("Administrador_verCompleto.aspx?parametro=" + z + "&userid=" + b);

    }

    protected void BT_dos_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        DAOUsuario dac = new DAOUsuario();
        EDatosCrearPost puntot = new EDatosCrearPost();

        int b = int.Parse(Request.Params["userid"]);
        int bn = int.Parse(Request.Params["parametro"]);
        DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(Request.Params["parametro"]);
        puntot.Id_user = int.Parse(Request.Params["userid"]);
        puntot.Fecha = dt;

        EDatosCrearPost doc = new EDatosCrearPost();
        doc.Id = int.Parse(Request.Params["parametro"]);
        Int32 v = int.Parse(Request.Params["parametro"]);

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = dac.obtenerUss(b);
        String o = regis2.Rows[0]["nick"].ToString();
        String p = regis.Rows[0]["autor"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        if (inter < 10)
        {
            inter = inter + 1;
            if (o != p)
            {

                String d = punt.Rows[0]["id"].ToString();

                if (v == int.Parse(d))
                {

                    String a = punt.Rows[0]["puntos"].ToString();

                    val = int.Parse(a);
                    val = val + 2;

                    String puntosA = punt.Rows[0]["puntosautor"].ToString();
                    pun = int.Parse(puntosA);
                    pun = pun + 2;


                    puntot.Puntos = val;
                    puntot.Interacciones = inter;
                    puntot.PuntosA = pun;

                    dac.guardaPuntos(puntot);
                }


            }
        }


        int z = int.Parse(Request.Params["parametro"]);


        DataTable regis3 = dac.obtenerUss(b);
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());

        x = x + 1;





        dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);

        Response.Redirect("Administrador_verCompleto.aspx?parametro=" + z + "&userid=" + b);

    }

    protected void BT_tres_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        DAOUsuario dac = new DAOUsuario();
        EDatosCrearPost puntot = new EDatosCrearPost();

        int b = int.Parse(Request.Params["userid"]);
        int bn = int.Parse(Request.Params["parametro"]);
        DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(Request.Params["parametro"]);
        puntot.Id_user = int.Parse(Request.Params["userid"]);
        puntot.Fecha = dt;

        EDatosCrearPost doc = new EDatosCrearPost();
        doc.Id = int.Parse(Request.Params["parametro"]);
        Int32 v = int.Parse(Request.Params["parametro"]);

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = dac.obtenerUss(b);
        String o = regis2.Rows[0]["nick"].ToString();
        String p = regis.Rows[0]["autor"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        if (inter < 10)
        {
            inter = inter + 1;
            if (o != p)
            {

                String d = punt.Rows[0]["id"].ToString();

                if (v == int.Parse(d))
                {

                    String a = punt.Rows[0]["puntos"].ToString();

                    val = int.Parse(a);
                    val = val + 3;

                    String puntosA = punt.Rows[0]["puntosautor"].ToString();
                    pun = int.Parse(puntosA);
                    pun = pun + 3;


                    puntot.Puntos = val;
                    puntot.Interacciones = inter;
                    puntot.PuntosA = pun;

                    dac.guardaPuntos(puntot);
                }


            }
        }


        int z = int.Parse(Request.Params["parametro"]);


        DataTable regis3 = dac.obtenerUss(b);
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());

        x = x + 1;





        dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);

        Response.Redirect("Administrador_verCompleto.aspx?parametro=" + z + "&userid=" + b);

    }

    protected void BT_cuatro_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        DAOUsuario dac = new DAOUsuario();
        EDatosCrearPost puntot = new EDatosCrearPost();

        int b = int.Parse(Request.Params["userid"]);
        int bn = int.Parse(Request.Params["parametro"]);
        DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(Request.Params["parametro"]);
        puntot.Id_user = int.Parse(Request.Params["userid"]);
        puntot.Fecha = dt;

        EDatosCrearPost doc = new EDatosCrearPost();
        doc.Id = int.Parse(Request.Params["parametro"]);
        Int32 v = int.Parse(Request.Params["parametro"]);

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = dac.obtenerUss(b);
        String o = regis2.Rows[0]["nick"].ToString();
        String p = regis.Rows[0]["autor"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        if (inter < 10)
        {
            inter = inter + 1;
            if (o != p)
            {

                String d = punt.Rows[0]["id"].ToString();

                if (v == int.Parse(d))
                {

                    String a = punt.Rows[0]["puntos"].ToString();

                    val = int.Parse(a);
                    val = val + 4;

                    String puntosA = punt.Rows[0]["puntosautor"].ToString();
                    pun = int.Parse(puntosA);
                    pun = pun + 4;


                    puntot.Puntos = val;
                    puntot.Interacciones = inter;
                    puntot.PuntosA = pun;

                    dac.guardaPuntos(puntot);
                }


            }
        }


        int z = int.Parse(Request.Params["parametro"]);


        DataTable regis3 = dac.obtenerUss(b);
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());

        x = x + 1;





        dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);

        Response.Redirect("Administrador_verCompleto.aspx?parametro=" + z + "&userid=" + b);

    }

    protected void BT_cinco_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        DAOUsuario dac = new DAOUsuario();
        EDatosCrearPost puntot = new EDatosCrearPost();

        int b = int.Parse(Request.Params["userid"]);
        int bn = int.Parse(Request.Params["parametro"]);
        DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(Request.Params["parametro"]);
        puntot.Id_user = int.Parse(Request.Params["userid"]);
        puntot.Fecha = dt;

        EDatosCrearPost doc = new EDatosCrearPost();
        doc.Id = int.Parse(Request.Params["parametro"]);
        Int32 v = int.Parse(Request.Params["parametro"]);

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = dac.obtenerUss(b);
        String o = regis2.Rows[0]["nick"].ToString();
        String p = regis.Rows[0]["autor"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        if (inter < 10)
        {
            inter = inter + 1;
            if (o != p)
            {

                String d = punt.Rows[0]["id"].ToString();

                if (v == int.Parse(d))
                {

                    String a = punt.Rows[0]["puntos"].ToString();

                    val = int.Parse(a);
                    val = val + 5;

                    String puntosA = punt.Rows[0]["puntosautor"].ToString();
                    pun = int.Parse(puntosA);
                    pun = pun + 5;


                    puntot.Puntos = val;
                    puntot.Interacciones = inter;
                    puntot.PuntosA = pun;

                    dac.guardaPuntos(puntot);
                }


            }
        }


        int z = int.Parse(Request.Params["parametro"]);


        DataTable regis3 = dac.obtenerUss(b);
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());

        x = x + 1;





        dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);

        Response.Redirect("Administrador_verCompleto.aspx?parametro=" + z + "&userid=" + b);

    }


    protected void BT_comentar_Click(object sender, EventArgs e)
    {

        EDatosComenatrio coment = new EDatosComenatrio();
        DAOUsuario dac = new DAOUsuario();


        int b = int.Parse(Request.Params["userid"]);
        DateTime dt = DateTime.Now;
        coment.Fecha = dt;
        coment.Conetinido1 = TB_comentarios.Text.ToString();
        coment.Id_post = int.Parse(Request.Params["parametro"]);
        coment.Id_user = int.Parse(Request.Params["userid"]);

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        if (inter < 10)
        {
            inter = inter + 1;
            coment.Interaccion = inter;
            dac.insertarComentarios(coment);
            DataTable regis = dac.obtenerUss(b);
            int x = int.Parse(regis.Rows[0]["puntos"].ToString());
            x = x + 1;

            dac.actualizarpuntoUser(b, x);
        }
        else
        {
            LB_mensaje.Text = "Numero maximo de interacciones por dia alcanzado";
        }


        int q = int.Parse(Request.Params["userid"]);
        int z = int.Parse(Request.Params["parametro"]);
        Response.Redirect("Administrador_verCompleto.aspx?parametro=" + z + "&userid=" + b);

    }



    protected void B_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Administrador.aspx?userid=" + b);
    }

    protected void BT_reporte_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        int h = int.Parse(Request.Params["parametro"]);
        Response.Redirect("Administrador_reportar_post.aspx?parametro=" + h + "&userid=" + b);
    }




    protected void BT_reportar_Click(object sender, EventArgs e)
    {

        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_comentariosuser.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;

        int h = int.Parse(Request.Params["parametro"]);
        int b = int.Parse(Request.Params["userid"]);
        string IdRecogido = ((Label)row.Cells[fila].FindControl("Label1")).Text;
        
        Response.Redirect("Administrador_reportar_coment.aspx?userid=" + b + "&idcoment=" + IdRecogido + "&parametro=" + h);
    }


}