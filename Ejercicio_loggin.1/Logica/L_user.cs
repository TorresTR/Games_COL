using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Data;
using Utilitarios;


namespace Logica
{
    public class L_user
    {
        public U_user logear(string UserName,string Clave) {

            D_user data = new D_user();
            DataTable usuario = data.Login(UserName, Clave);
            U_user user = new U_user();


            if (usuario.Rows.Count > 0)
            {
                user.UserId = int.Parse(usuario.Rows[0]["id"].ToString());
                user.Rol = int.Parse(usuario.Rows[0]["rol_id"].ToString());
                switch (usuario.Rows[0]["rol_id"].ToString())
                {
                    case "1":
                        user.Url = "admon.aspx";
                        user.Mensaje = "Hola Admins";

                        break;
                    case "2":
                        user.Url = "Moderador.aspx";
                        user.Mensaje = "Hola Moderador";

                        break;
                    case "3":
                        user.Url = "user.aspx";
                        user.Mensaje = "Hola usuario";

                        break;


                }
            }
            else {
                user.Url = "loggin.aspx";
                user.Mensaje = "Usuario Y/O Clave Incorrecta";
            }
           

            return user; 
        }


        public DataTable listaUsuarios() {

            D_user data = new D_user();
            DataTable datos = new DataTable();

            datos = data.ObtenerUsuarios();
            return datos;
        }


        public DataTable EliminaUsuarios(int x)
        {
           
            D_user data = new D_user();
            DataTable datos = new DataTable();

            
            datos = data.EliminarUsuarios(x);


            return datos;
        }

        public DataTable EditarUsuarios(int x,string nom, string pas, string us)
        {

            D_user data = new D_user();
            DataTable datos = new DataTable();


            datos = data.EditarUsuarios(x,nom,pas,us);


            return datos;
        }

        public DataTable EditarUsuariosesp(int x)
        {

            D_user data = new D_user();
            DataTable datos = new DataTable();


            datos = data.ObtenerUs(x);


            return datos;
        }

        public DataTable AgregrarUsuario(string nombre, string usuario, string contra)
        {

            D_user data = new D_user();
            DataTable datos = new DataTable();


            datos = data.AgregarUsuarionuev(nombre,usuario,contra);


            return datos;
        }
    }
}
