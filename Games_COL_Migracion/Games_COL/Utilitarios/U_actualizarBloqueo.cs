using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_actualizarBloqueo
    {
        private Int32 id_post;
        private Int32 user_bloqueador;
        private Int32 estado_bloqueo;
        private Int32 respuesta;

        public int Id_post { get => id_post; set => id_post = value; }
        public int User_bloqueador { get => user_bloqueador; set => user_bloqueador = value; }
        public int Estado_bloqueo { get => estado_bloqueo; set => estado_bloqueo = value; }
        public int Respuesta { get => respuesta; set => respuesta = value; }
    }
}
