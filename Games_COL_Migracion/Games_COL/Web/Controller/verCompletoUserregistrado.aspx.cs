using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;
using Datos;

public partial class View_verCompletoUserregistrado : System.Web.UI.Page
{
    int x,puntos=0,num=0,tot=0;
    int h = 0;
    int puntos_total=0;
    int val,pun;

    protected void Page_Load(object sender, EventArgs e)
    {


        Response.Cache.SetNoStore();

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        U_userCrearpost doc = new U_userCrearpost();
      
        L_Usercs log = new L_Usercs();
        D_User dac = new D_User();
        

        int comparador_idpost = int.Parse(obQueryString["parametro"].ToString());
        int comparador_iduser = int.Parse(obQueryString["userid"].ToString());

        DataTable regisval = dac.obtenerpuntsval(comparador_iduser);

        DataTable data = dac.ObtenerInteraccion(comparador_iduser);
        int inter = int.Parse(data.Rows[0]["id"].ToString());
        U_Interaccion inte = new U_Interaccion();
        inte.Iteraccion = inter;
        inte = log.validarInteraccion(inte);

        
        LB_mensaje.Text = inte.Mensaje;
        TB_comentarios.Visible = inte.Estado;
        LB_comentar.Visible = inte.Estado;
        BT_comentar.Visible = inte.Estado;
        UpdatePanel1.Visible = inte.Estado;
       


        ClientScriptManager cm = this.ClientScript;
        doc.Id = int.Parse(obQueryString["parametro"].ToString());
        int dato = int.Parse(obQueryString["userid"].ToString());



        DataTable regis = dac.verpag(doc);

        int contadordatos = regisval.Rows.Count;
        int contcolum = regisval.Columns.Count;

        Boolean estado = log.comparaPropioP(regisval, comparador_idpost, comparador_iduser);
       
       
        UpdatePanel1.Visible = estado;


        int b = int.Parse(obQueryString["userid"].ToString());
        DataTable regis2 = dac.obtenerUss(b);
        String x = regis2.Rows[0]["nick"].ToString();
        String z = regis.Rows[0]["autor"].ToString();


        BT_reporte.Visible = true;

        Boolean est = log.compara(z, x);
        
        BT_reporte.Visible = est;
        UpdatePanel1.Visible = est;



        U_userCrearpost datos = new U_userCrearpost();

        datos = log.comp(regis);
        
        LB_muestraPag.Text = datos.Contenido1;
        LB_autor.Text = datos.Autor1;

        
        
        DataTable punt = dac.verpuntos(doc);
        datos = log.promedioPunt(punt);
        puntos = datos.PuntosA;
        num = datos.Nump;
        tot = puntos / num;
        LB_motrarPuntos.Text = tot.ToString();

        datos.Comentarios1 = dato;
        GV_comentariosuser.DataSource = log.obtenerComentario(comparador_idpost);
        GV_comentariosuser.DataBind();



    }

    protected void Bt_uno_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        D_User dac = new D_User();
        U_userCrearpost puntot = new U_userCrearpost();
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        int b = int.Parse(obQueryString["userid"].ToString());
        int bn = int.Parse(obQueryString["parametro"].ToString());
        DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(obQueryString["parametro"].ToString());
        puntot.Id_user = int.Parse(obQueryString["userid"].ToString());
        puntot.Fecha = dt;

        U_userCrearpost doc = new U_userCrearpost();
        doc.Id = int.Parse(obQueryString["parametro"].ToString());
        Int32 v = int.Parse(obQueryString["parametro"].ToString());

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = dac.obtenerUss(b);

        puntot.Nick = regis2.Rows[0]["nick"].ToString();
        puntot.Autor1 = regis.Rows[0]["autor"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        L_Usercs llamado = new L_Usercs();

        llamado.puntosBoton(punt, inter, puntot);




        int z = int.Parse(obQueryString["parametro"].ToString());


        DataTable regis3 = dac.obtenerUss(b);
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());

        x = x + 1;





        dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);
        string ui = obQueryString["userid"].ToString();
        string par = obQueryString["parametro"].ToString();

        obQueryString.Add("parametro", par);
        obQueryString.Add("userid", ui);



        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletousuarioregistrado();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

    }

    protected void BT_dos_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        D_User dac = new D_User();
        U_userCrearpost puntot = new U_userCrearpost();
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        int b = int.Parse(obQueryString["userid"].ToString());
        int bn = int.Parse(obQueryString["parametro"].ToString());
        DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(obQueryString["parametro"].ToString());
        puntot.Id_user = int.Parse(obQueryString["userid"].ToString());
        puntot.Fecha = dt;

        U_userCrearpost doc = new U_userCrearpost();
        doc.Id = int.Parse(obQueryString["parametro"].ToString());
        Int32 v = int.Parse(obQueryString["parametro"].ToString());

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = dac.obtenerUss(b);

        puntot.Nick = regis2.Rows[0]["nick"].ToString();
        puntot.Autor1 = regis.Rows[0]["autor"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        L_Usercs llamado = new L_Usercs();

        llamado.puntosBoton(punt ,inter,puntot);
        



        int z = int.Parse(obQueryString["parametro"].ToString());


        DataTable regis3 = dac.obtenerUss(b);
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());

        x = x + 1;





        dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);
        string ui = obQueryString["userid"].ToString();
        string par = obQueryString["parametro"].ToString();

        obQueryString.Add("parametro", par);
        obQueryString.Add("userid", ui);

       

        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletousuarioregistrado();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

    }

    protected void BT_tres_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        D_User dac = new D_User();
        U_userCrearpost puntot = new U_userCrearpost();
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        int b = int.Parse(obQueryString["userid"].ToString());
        int bn = int.Parse(obQueryString["parametro"].ToString());
        DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(obQueryString["parametro"].ToString());
        puntot.Id_user = int.Parse(obQueryString["userid"].ToString());
        puntot.Fecha = dt;

        U_userCrearpost doc = new U_userCrearpost();
        doc.Id = int.Parse(obQueryString["parametro"].ToString());
        Int32 v = int.Parse(obQueryString["parametro"].ToString());

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = dac.obtenerUss(b);

        puntot.Nick = regis2.Rows[0]["nick"].ToString();
        puntot.Autor1 = regis.Rows[0]["autor"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        L_Usercs llamado = new L_Usercs();

        llamado.puntosBoton(punt, inter, puntot);




        int z = int.Parse(obQueryString["parametro"].ToString());


        DataTable regis3 = dac.obtenerUss(b);
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());

        x = x + 1;





        dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);
        string ui = obQueryString["userid"].ToString();
        string par = obQueryString["parametro"].ToString();

        obQueryString.Add("parametro", par);
        obQueryString.Add("userid", ui);



        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletousuarioregistrado();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

    }

    protected void BT_cuatro_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        D_User dac = new D_User();
        U_userCrearpost puntot = new U_userCrearpost();
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        int b = int.Parse(obQueryString["userid"].ToString());
        int bn = int.Parse(obQueryString["parametro"].ToString());
        DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(obQueryString["parametro"].ToString());
        puntot.Id_user = int.Parse(obQueryString["userid"].ToString());
        puntot.Fecha = dt;

        U_userCrearpost doc = new U_userCrearpost();
        doc.Id = int.Parse(obQueryString["parametro"].ToString());
        Int32 v = int.Parse(obQueryString["parametro"].ToString());

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = dac.obtenerUss(b);

        puntot.Nick = regis2.Rows[0]["nick"].ToString();
        puntot.Autor1 = regis.Rows[0]["autor"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        L_Usercs llamado = new L_Usercs();

        llamado.puntosBoton(punt, inter, puntot);




        int z = int.Parse(obQueryString["parametro"].ToString());


        DataTable regis3 = dac.obtenerUss(b);
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());

        x = x + 1;





        dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);
        string ui = obQueryString["userid"].ToString();
        string par = obQueryString["parametro"].ToString();

        obQueryString.Add("parametro", par);
        obQueryString.Add("userid", ui);



        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletousuarioregistrado();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());


    }

    protected void BT_cinco_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        D_User dac = new D_User();
        U_userCrearpost puntot = new U_userCrearpost();
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        int b = int.Parse(obQueryString["userid"].ToString());
        int bn = int.Parse(obQueryString["parametro"].ToString());
        DataTable punt = dac.ObtenerPuntos(bn);
        DateTime dt = DateTime.Now;
        puntot.Id = int.Parse(obQueryString["parametro"].ToString());
        puntot.Id_user = int.Parse(obQueryString["userid"].ToString());
        puntot.Fecha = dt;

        U_userCrearpost doc = new U_userCrearpost();
        doc.Id = int.Parse(obQueryString["parametro"].ToString());
        Int32 v = int.Parse(obQueryString["parametro"].ToString());

        DataTable regis = dac.verpag(doc);


        DataTable regis2 = dac.obtenerUss(b);

        puntot.Nick = regis2.Rows[0]["nick"].ToString();
        puntot.Autor1 = regis.Rows[0]["autor"].ToString();

        DataTable data = dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        L_Usercs llamado = new L_Usercs();

        llamado.puntosBoton(punt, inter, puntot);




        int z = int.Parse(obQueryString["parametro"].ToString());


        DataTable regis3 = dac.obtenerUss(b);
        int x = int.Parse(regis3.Rows[0]["puntos"].ToString());
        int f = int.Parse(regis3.Rows[0]["id"].ToString());

        x = x + 1;





        dac.actualizarpuntoUser(b, x);

        dac.ValidarPuntuacion(b, z);
        string ui = obQueryString["userid"].ToString();
        string par = obQueryString["parametro"].ToString();

        obQueryString.Add("parametro", par);
        obQueryString.Add("userid", ui);



        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletousuarioregistrado();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

    }


    protected void BT_comentar_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);
        L_Usercs log = new L_Usercs();
        U_comentarios coment = new U_comentarios();
        D_User dac = new D_User();


        int b = int.Parse(obQueryString["userid"].ToString());
        DateTime dt = DateTime.Now;
        coment.Fecha = dt;
        coment.Conetinido1 = TB_comentarios.Text.ToString();
        coment.Id_post = int.Parse(obQueryString["parametro"].ToString());
        coment.Id_user = int.Parse(obQueryString["userid"].ToString());

        DataTable data =dac.ObtenerInteraccion(b);
        int inter = int.Parse(data.Rows[0]["id"].ToString());

        string mensaje = log.comentar(inter, coment );
        
            LB_mensaje.Text =mensaje;
        
        

        string q = obQueryString["userid"].ToString();
        string z = obQueryString["parametro"].ToString();
        obQueryString.Add("parametro", z);
        obQueryString.Add("userid", q);
        

        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        dat = llamar.redirigirCompletousuarioregistrado();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

    }



    protected void B_volver_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        string z = obQueryString["userid"].ToString();


        obQueryString.Add("userid", z);

        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.volverUsuariosRegistrado();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

    }

    protected void BT_reporte_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);
        string q = obQueryString["userid"].ToString();
        string z = obQueryString["parametro"].ToString();
        obQueryString.Add("parametro", z);
        obQueryString.Add("userid", q);
        

        L_Usercs data = new L_Usercs();
        U_user dat = new U_user();

        dat = data.reporteUsuariopost();

        Response.Redirect( dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());

    }
   
    protected void BT_reportar_Click(object sender, EventArgs e)
    {

        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_comentariosuser.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;

        

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);
        string q = obQueryString["userid"].ToString();
        string z = obQueryString["parametro"].ToString();

        string IdRecogido = ((Label)row.Cells[fila].FindControl("Label1")).Text.ToString();

        obQueryString.Add("parametro", z);
        obQueryString.Add("userid", q);
        obQueryString.Add("idcoment", IdRecogido);
        

        L_Usercs data = new L_Usercs();
        U_user dat = new U_user();

        dat = data.reporteUsuariocoment();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());


    }



}