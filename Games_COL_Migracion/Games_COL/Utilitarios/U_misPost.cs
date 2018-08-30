using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
     public class U_misPost
    {

        private Int32 id_mipost;
        private String link;
        private String contenido;
        private String autor;
        private Boolean estadoCK;
        private Boolean estadoBT;
        private Int32 dato1;
        private Int32 dato2;


        public int Id_mipost { get => id_mipost; set => id_mipost = value; }
        public string Link { get => link; set => link = value; }
        public string Contenido { get => contenido; set => contenido = value; }
        public string Autor { get => autor; set => autor = value; }
        public bool EstadoCK { get => estadoCK; set => estadoCK = value; }
        public bool EstadoBT { get => estadoBT; set => estadoBT = value; }
        public int Dato1 { get => dato1; set => dato1 = value; }
        public int Dato2 { get => dato2; set => dato2 = value; }
    }
}
