using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_userCrearpost
    {

        private String titulo;
        private String Autor;
        private String Contenido;
        private DateTime fecha;
        private Int32 id;
        private Int64 puntos;
        private Int32 id_user;
        private Int32 id_etiqueta;
        private Int32 puntosA;
        private Int32 nump;
        private int interacciones;
        private String totpunt;
        private String link;
        private Int32 Comentarios;
        private string nick;
        

        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor1 { get => Autor; set => Autor = value; }
        public string Contenido1 { get => Contenido; set => Contenido = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Id { get => id; set => id = value; }
        public long Puntos { get => puntos; set => puntos = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public int Id_etiqueta { get => id_etiqueta; set => id_etiqueta = value; }
        public int PuntosA { get => puntosA; set => puntosA = value; }
        public int Nump { get => nump; set => nump = value; }
        public int Interacciones { get => interacciones; set => interacciones = value; }
        public string Totpunt { get => totpunt; set => totpunt = value; }
        public string Link { get => link; set => link = value; }
        public int Comentarios1 { get => Comentarios; set => Comentarios = value; }
        public string Nick { get => nick; set => nick = value; }
    }
}
