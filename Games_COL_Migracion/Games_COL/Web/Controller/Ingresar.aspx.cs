using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;
using Datos;
using System.Collections;
using ASPSnippets.FaceBookAPI;
using ASPSnippets.GoogleAPI;
using System.Web.Script.Serialization;
using Persistencia_funciones;

public partial class View_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Response.Cache.SetNoStore();
        Int32 idioma = 1;
        Int32 id_pagina = 58;
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


        LB_ingresar.Text = compIdioma["LB_ingresar"].ToString();
        L_UserName.Text = compIdioma["L_UserName"].ToString();
        L_contraseña.Text = compIdioma["L_contraseña"].ToString();
        HL_recuperar.Text = compIdioma["HL_recuperar"].ToString();
        BT_Ingresar.Text = compIdioma["BT_ingresar"].ToString();
        BT_registro.Text = compIdioma["BT_registro"].ToString();
        B_volver.Text = compIdioma["B_volver"].ToString();

        GoogleConnect.ClientId = "822784870812-7l78djulgtfh1sdvpl596buka23enf5o.apps.googleusercontent.com";
        GoogleConnect.ClientSecret = "TRJGkBAxBBXaxNIdCjik7868";
        GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];

        if (!string.IsNullOrEmpty(Request.QueryString["code"]))
        {
            try
            {
                string coded = Request.QueryString["code"];
                string json = GoogleConnect.Fetch("me", coded);
                GoogleProfile profile = new JavaScriptSerializer().Deserialize<GoogleProfile>(json);
                Lb_idG.Text = profile.Id;
                lblUserNameG.Text = profile.DisplayName;
                lblEmailG.Text = profile.Emails.Find(email => email.Type == "account").Value;
                ProfileImageG.ImageUrl = profile.Image.Url;

                string correo = lblEmailG.Text;

                U_logueo usuario = new U_logueo();
                U_Datos llamado = new U_Datos();
                U_user link = new U_user();
                L_Usercs user = new L_Usercs();

                string a = Session.SessionID;

                try
                {

                    DataTable datauser = Idio.consultaUsusariocorreo(correo);
                    llamado.Sesion = datauser.Rows[0]["id"].ToString();
                    usuario.Nick = datauser.Rows[0]["nick"].ToString();
                    int id = int.Parse(datauser.Rows[0]["id"].ToString());
                    usuario.Pass = datauser.Rows[0]["contra"].ToString();
                    Session["id"] = llamado.Sesion;
                    link = user.loggin(datauser, a, usuario.Nick, id);

                }
                catch (Exception)
                {
                    Session["user_name"] = profile.DisplayName;
                    Session["correo"] = correo;
                    Session["band"] = true;
                    Response.Redirect("registro.aspx");
                }
                Response.Redirect(link.Link_demas);

            }
            catch (Exception)
            {

            }
        }
        if (Request.QueryString["error"] == "access_denied")
        {
            Response.Write("<Script Language='JavaScript'>parent.alert('Access denied');</Script>");
        }


        FaceBookConnect.API_Key = "184076195845739";
        FaceBookConnect.API_Secret = "a0c8d4f1c27d4d3efdfb3b0ee894e12f";
        if (!IsPostBack)
        {
            if (Request.QueryString["error"] == "access_denied")
            {
                Response.Write("<Script Language='JavaScript'>parent.alert('User has denied access.');</Script>");
                return;
            }

           
            string code = Request.QueryString["code"];
            if (!string.IsNullOrEmpty(code))
            {
                ViewState["Code"] = code;

                try
                {
                    string data = FaceBookConnect.Fetch(code, "me?fields=id,name,email");
                    FaceBookUser faceBookUser = new JavaScriptSerializer().Deserialize<FaceBookUser>(data);
                    faceBookUser.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", faceBookUser.Id);
                    pnlFaceBookUser.Visible = true;
                    lblId.Text = faceBookUser.Id;
                    lblUserName.Text = faceBookUser.UserName;
                    lblName.Text = faceBookUser.Name;
                    lblEmail.Text = faceBookUser.Email;
                    ProfileImage.ImageUrl = faceBookUser.PictureUrl;
                    btnLogin.Enabled = false;
               
                

               
                    U_logueo usuario = new U_logueo();
                    U_Datos llamado = new U_Datos();
                    U_user link = new U_user();
                    L_Usercs user = new L_Usercs();

                    string a = Session.SessionID;

                    try
                    {
                        
                        DataTable datauser = Idio.consultaUsusariocorreo(faceBookUser.Email);
                        llamado.Sesion = datauser.Rows[0]["id"].ToString();
                        usuario.Nick = datauser.Rows[0]["nick"].ToString();
                        int id = int.Parse(datauser.Rows[0]["id"].ToString());
                        usuario.Pass = datauser.Rows[0]["contra"].ToString();
                        Session["id"] = llamado.Sesion;
                        link = user.loggin(datauser, a, usuario.Nick, id);
                        
                    }
                    catch (Exception)
                    {
                        Session["user_name"] = faceBookUser.Name;
                        Session["correo"] = faceBookUser.Email;
                        Session["band"] = true;
                        Response.Redirect("registro.aspx");
                    }
                    Response.Redirect(link.Link_demas);
                }
                catch (Exception)
                {

                }

            }




        }

    }




    protected void BT_Ingresar_Click(object sender, EventArgs e)
    {


        U_logueo usuario = new U_logueo();
        U_user link = new U_user();
        Dsql datos = new Dsql();
        L_Usercs user = new L_Usercs();
        U_Datos llamado = new U_Datos();

        usuario.Nick = TB_UserName.Text.ToString();
        usuario.Pass = TB_Contraseña.Text.ToString();
        string a = Session.SessionID;
        link.Link_demas = "";
        try
        {
            int id = user.consultaid(usuario.Nick);
            user.validar_Bloqueo(id);
            DataTable registros = user.valida(usuario);
            llamado.Sesion = registros.Rows[0]["id"].ToString();
            //string sesion = Session["id"].ToString();

            Session["id"] = llamado.Sesion;

            link = user.loggin(registros, a, usuario.Nick, id);

            L_error.Text = link.Mensaje_Alertaobservador1;
            Response.Write("<Script Language='JavaScript'>parent.alert('" + link.Mensaje_Alertaobservador1 + "');</Script>");
        }
        catch (Exception)
        {
            Response.Write("<Script Language='JavaScript'>parent.alert('Usuario y/o contraseña incorrecta');</Script>");
            Response.Redirect("Ingresar.aspx");
        }
            

            
            Response.Redirect(link.Link_demas);
       
        

    }


    protected void Login(object sender, EventArgs e)
    {
        FaceBookConnect.Authorize("user_photos,email", Request.Url.AbsoluteUri.Split('?')[0]);
      
    }


    protected void BT_registro_Click(object sender, EventArgs e)
    {
        Response.Redirect("registro.aspx");
    }

    protected void B_olvido_Click(object sender, EventArgs e)
    {
        Response.Redirect("Generar_token.aspx");
    }

    protected void B_volver_Click(object sender, EventArgs e)
    {
        U_userCrearpost retorno = new U_userCrearpost();
        L_Usercs data = new L_Usercs();

        retorno = data.retornoObservador();
        Response.Redirect(retorno.Link);

    }

    protected void BT_gmail_Click(object sender, EventArgs e)
    {
        GoogleConnect.Authorize("profile", "email");
    }
}
