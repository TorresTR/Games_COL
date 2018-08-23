using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_Sugerencia
    {
        private String correo;
        private String sugerencia;
        private String link;
        private String mensaje;

        public string Correo { get => correo; set => correo = value; }
        public string Sugerencia { get => sugerencia; set => sugerencia = value; }
        public string Link { get => link; set => link = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
    }
}
