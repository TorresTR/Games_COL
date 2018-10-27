<%@ Application Language="C#" %>


<script runat="server">
    int i;
    void Application_Start(object sender, EventArgs e)
    {
        // Código que se ejecuta al iniciarse la aplicación

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Código que se ejecuta al cerrarse la aplicación

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando se produce un error sin procesar

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Código que se ejecuta al iniciarse una nueva sesión

    }

    void Session_End(object sender, EventArgs e)
    {

        try
        {
            i = int.Parse(Session["id"].ToString());
            Logica.L_Usercs user = new Logica.L_Usercs();
            user.cerrarSesio(i);
        }
        catch
        {

        }

    }

</script>
