using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_comentarios
    {

        private String Conetinido;
        private Int32 id_post;
        private Int32 id;
        private Int32 id_user;
        private int interaccion;
        private DateTime fecha;

        public string Conetinido1 { get => Conetinido; set => Conetinido = value; }
        public int Id_post { get => id_post; set => id_post = value; }
        public int Id { get => id; set => id = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public int Interaccion { get => interaccion; set => interaccion = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
