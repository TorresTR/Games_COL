using Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_Administrador_reporteUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 idioma = 1;
        Int32 id_pagina = 20;
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


        BT_volver.Text = compIdioma["BT_volver"].ToString();
        try
        {
            InforR_administrador reporte = ObtenerInforme();
            CRS_admin.ReportDocument.SetDataSource(reporte);
            CRV_administrador.ReportSource = CRS_admin;
        }
        catch (Exception)
        {

           
        }
    }

    protected InforR_administrador ObtenerInforme()
    {
        DataRow fila;  //dr
        DataTable informacion = new DataTable(); //dt

        L_persistencia info = new L_persistencia();

        InforR_administrador datos = new InforR_administrador();
        L_Usercs persona = new L_Usercs();
        DataTable inter = persona.listarUserAdmin();
        informacion = datos.Tables["User"];

        //DataTable intermedio = persona.listarUserAdmin();
        persona.reporteAdministrador(inter, informacion);


        return datos;
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {

        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.listadoUser();

        Response.Redirect(dat.Link_observador);
    }
}