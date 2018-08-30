using System;
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
        try
        {
            InfoR_moderador reporte = ObtenerInforme();
            CRS_moderador.ReportDocument.SetDataSource(reporte);
            CRV_reporte_moderador.ReportSource = CRS_moderador;
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected InfoR_moderador ObtenerInforme()
    {
      
        DataTable informacion = new DataTable(); //dt
        InfoR_moderador datos = new InfoR_moderador();
        

        informacion = datos.Tables["Usuarios"];

        L_Usercs persona = new L_Usercs();

        persona.listadoModerador(informacion);

        return datos;
    }


    protected void BT_eliminar_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int h = int.Parse(ID);

        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        int b = int.Parse(obQueryString["userid"].ToString());



        L_Usercs dac = new L_Usercs();
        U_user data = new U_user();
       
       
        dac.eliminarUsermoderador(h);

      ;

        Response.Redirect("Moderador_listado_user.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        QueryString obQueryString = new QueryString(Request.QueryString);
        obQueryString = L_encriptadoDesencriptado.DecryptQueryString(obQueryString);

        Response.Redirect("Moderador_listado_user.aspx" + L_encriptadoDesencriptado.EncryptQueryString(obQueryString).ToString());
    }

   
}