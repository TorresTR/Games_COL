using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_Interaccion
    {
        private Boolean estado;
        private String mensaje;
        private Int32 iteraccion;
        private Int32 contador;
        private Int32 id;
        private Int32 puntos;

        public bool Estado { get => estado; set => estado = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
        public int Iteraccion { get => iteraccion; set => iteraccion = value; }
        public int Contador { get => contador; set => contador = value; }
        public int Id { get => id; set => id = value; }
        public int Puntos { get => puntos; set => puntos = value; }
    }

}
