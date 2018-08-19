using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_user
    {

        private String url;
        private Int32 userId;
        private Int32 rol;
        private String mensaje;
        private String Username;
        private String pass;

        public string Mensaje { get => mensaje; set => mensaje = value; }
        public int Rol { get => rol; set => rol = value; }
        public int UserId { get => userId; set => userId = value; }
        public string Url { get => url; set => url = value; }
        public string Pass { get => pass; set => pass = value; }
        public string Username1 { get => Username; set => Username = value; }
    }
}
