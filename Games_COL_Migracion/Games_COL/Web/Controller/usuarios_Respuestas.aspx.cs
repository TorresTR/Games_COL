using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_usuarios_Respuestas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();


        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        L_Usercs dac = new L_Usercs();
        U_respuestasPqr dat = new U_respuestasPqr();

        

        int dato = int.Parse(obQueryString["userid"].ToString());

        dat.Id_respuesta = dato;

        GV_comentariosuser.DataSource = dac.respuestaPqr(dat);
        GV_comentariosuser.DataBind();
    }

    protected void BT_reportar_Click(object sender, EventArgs e)
    {

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        Button bt = (Button)sender;
        TableCell tableCell = (TableCell)bt.Parent;
        GridViewRow row = (GridViewRow)tableCell.Parent;
        GV_comentariosuser.SelectedIndex = row.RowIndex;
        int fila = row.RowIndex;

      
        int b = int.Parse(obQueryString["userid"].ToString());
        string IdRecogido = ((Label)row.Cells[fila].FindControl("Label1")).Text;

        string x = b.ToString();
        obQueryString.Add("idresp", IdRecogido);
        obQueryString.Add("userid", x);

        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.redireccionMisrespuestaspqr();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
        

    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        U_user dat = new U_user();
        L_Usercs llamado = new L_Usercs();

        dat = llamado.volverUsuariosRegistrado();

        Response.Redirect(dat.Link_observador + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }
}