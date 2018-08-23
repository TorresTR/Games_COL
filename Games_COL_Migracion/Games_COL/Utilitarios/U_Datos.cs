using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_Datos
    {
        private String nombre;
        private String nick;
        private String correo;
        private String pass;
        private String imagen;
        private int puntos;
        private int rol;
        private int rango;
        private int estado;
        private int id;
        private DateTime fecha;
        private int interaccion;
        private String Mensaje;
        private String link;
        private String confirma;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Nick { get => nick; set => nick = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Pass { get => pass; set => pass = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public int Puntos { get => puntos; set => puntos = value; }
        public int Rol { get => rol; set => rol = value; }
        public int Rango { get => rango; set => rango = value; }
        public int Estado { get => estado; set => estado = value; }
        public int Id { get => id; set => id = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Interaccion { get => interaccion; set => interaccion = value; }
        public string Mensaje1 { get => Mensaje; set => Mensaje = value; }
        public string Link { get => link; set => link = value; }
        public string Confirma { get => confirma; set => confirma = value; }
    }
}
