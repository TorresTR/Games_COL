using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_control
    {
        private int id;
        private string nombre;
        private int id_form;
        private int idioma;
        private string contenido;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Id_form { get => id_form; set => id_form = value; }
        public int Idioma { get => idioma; set => idioma = value; }
        public string Contenido { get => contenido; set => contenido = value; }
    }
}
