using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;


public partial class View_usuario_miPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();


        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        U_misPost mio = new U_misPost();
        L_Usercs dac = new L_Usercs();


        int dato = int.Parse(obQueryString["userid"].ToString());

        mio.Id_mipost = dato;

        GV_miPost.DataSource = dac.misPost(mio);
        GV_miPost.DataBind();

        try
        {
            InfoR_usuario reporte = ObtenerInforme();
            CRS_reporte_usuario.ReportDocument.SetDataSource(reporte);
            CRV_reporteUsuario.ReportSource = CRS_reporte_usuario;
            
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected InfoR_usuario ObtenerInforme()
    {
          //dr
        DataTable informacion = new DataTable(); //dt
        InfoR_usuario datos = new InfoR_usuario();

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        int dato = int.Parse(obQueryString["userid"].ToString());

        informacion = datos.Tables["Post"];

        L_Usercs persona = new L_Usercs();

        persona.misPostCristal(informacion,dato);

        return datos;
    }


    protected void BT_editar_Click(object sender, EventArgs e)
    {
        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_miPost.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);


        int b = int.Parse(obQueryString["userid"].ToString());
        string IdRecogido = ((Label)row.Cells[fila].FindControl("LB_id")).Text;

        string dat = b.ToString(); 

        obQueryString.Add("parametro", IdRecogido);
        obQueryString.Add("userid", dat);

        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.editarMispost();

        Response.Redirect(data.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }

    protected void BT_eliminar_Click(object sender, EventArgs e)
    {
        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_miPost.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);


        int b = int.Parse(obQueryString["userid"].ToString());
        string IdRecogido = ((Label)row.Cells[fila].FindControl("LB_id")).Text;

        int x = int.Parse(IdRecogido);

        L_Usercs dac = new L_Usercs();
        U_misPost dato = new U_misPost();

        dato.Id_mipost = x;

        dac.eliminarMipost(dato);



        U_user data = new U_user();
        L_Usercs llamado = new L_Usercs();

        data = llamado.redireccionMispost();

        Response.Redirect(data.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        dat = llamado.volverUsuariosRegistrado();

        int b = int.Parse(obQueryString["userid"].ToString());
        string data = b.ToString();
        obQueryString.Add("userid", data);


        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }
}