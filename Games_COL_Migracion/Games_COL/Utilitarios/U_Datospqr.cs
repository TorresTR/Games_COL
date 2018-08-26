using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class U_Datospqr
    {

        private String asunto;
        private String contenido;
        private DateTime fecha;
        private Int32 id_user;
        private Int32 id_pqrestado;
        private String respuesta;
        private Int32 id_respondedor;
        private DateTime fecha_respuesta;
        private Int32 id_pqr;
        private Int32 estado_respuesta;

        public string Asunto { get => asunto; set => asunto = value; }
        public string Contenido { get => contenido; set => contenido = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public int Id_pqrestado { get => id_pqrestado; set => id_pqrestado = value; }
        public string Respuesta { get => respuesta; set => respuesta = value; }
        public int Id_respondedor { get => id_respondedor; set => id_respondedor = value; }
        public DateTime Fecha_respuesta { get => fecha_respuesta; set => fecha_respuesta = value; }
        public int Id_pqr { get => id_pqr; set => id_pqr = value; }
        public int Estado_respuesta { get => estado_respuesta; set => estado_respuesta = value; }
    }
}
