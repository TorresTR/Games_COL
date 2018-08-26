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
        DataRow fila;  //dr
        DataTable informacion = new DataTable(); //dt
        InfoR_moderador datos = new InfoR_moderador();
        

        informacion = datos.Tables["Usuarios"];

        DAOUsuario persona = new DAOUsuario();

        DataTable intermedio = persona.ListarUsuariosR();

        for (int i = 0; i < intermedio.Rows.Count; i++)
        {
            fila = informacion.NewRow();

            fila["Nick"] = intermedio.Rows[i]["nick"].ToString();
            fila["Puntos"] = int.Parse(intermedio.Rows[i]["puntos"].ToString());
            fila["Rango"] = intermedio.Rows[i]["tipo"].ToString();
            


            informacion.Rows.Add(fila);
        }

        return datos;
    }


    protected void BT_eliminar_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        DataListItem item = (DataListItem)btn.NamingContainer;
        Label lblid = (Label)item.FindControl("LB_id");
        string ID = lblid.Text;
        int h = int.Parse(ID);


        int b = int.Parse(Request.Params["userid"]);



        L_Usercs dac = new L_Usercs();
        U_user data = new U_user();

        data.Id = h;
        dac.eliminarUsermoderador(data);

        Response.Redirect("Moderador_listado_user.aspx?userid=" + b);
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        int b = int.Parse(Request.Params["userid"]);
        Response.Redirect("Moderador_listado_user.aspx?userid=" + b);
    }

   
}