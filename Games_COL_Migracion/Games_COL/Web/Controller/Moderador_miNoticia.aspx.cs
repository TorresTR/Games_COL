using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Moderador_miNoticia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        L_Usercs dac = new L_Usercs();

        
        int dato = int.Parse(obQueryString["userid"].ToString());

        GV_miPost.DataSource = dac.minoticiagv(dato);
        GV_miPost.DataBind();

    }

    protected void BT_editar_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_miPost.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;


        int b = int.Parse(obQueryString["userid"].ToString());
        string IdRecogido = ((Label)row.Cells[fila].FindControl("LB_id")).Text;

        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        string c = b.ToString();
        obQueryString.Add("parametro", IdRecogido);
        obQueryString.Add("userid", c);

        dat = llamar.recargaminoticia();

       
        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
       
    }

    protected void BT_eliminar_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_miPost.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;


        int b = int.Parse(obQueryString["userid"].ToString());
        string IdRecogido = ((Label)row.Cells[fila].FindControl("LB_id")).Text;

        int x = int.Parse(IdRecogido);

        L_Usercs dac = new L_Usercs();
        dac.eliminarminoticia(x);

        U_user dat = new U_user();
        L_Usercs llamar = new L_Usercs();

        string c = b.ToString();
        obQueryString.Add("parametro", IdRecogido);
        obQueryString.Add("userid", c);

        dat = llamar.recargapgnotimoder();
        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
        
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        dat = llamado.irHomeModerador();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }
}