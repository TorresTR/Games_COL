using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    [Serializable]
    [Table("pqr", Schema = "usuario")]
    public class Entity_pqr
    {
        private int id_pqr;
        private int usuario;
        private int solicitud;
        private string contenido;
        private string asunto;
        private DateTime fecha;
        private string respuesta;
        private int id_contestador;
        private DateTime fecha_respuesta;
        private int estado_respuesta;

        [Key]
        [Column("id_pqr")]
        public int Id_pqr { get => id_pqr; set => id_pqr = value; }
        [Column("usuario")]
        public int Usuario { get => usuario; set => usuario = value; }
        [Column("solicitud")]
        public int Solicitud { get => solicitud; set => solicitud = value; }
        [Column("contenido")]
        public string Contenido { get => contenido; set => contenido = value; }
        [Column("asunto")]
        public string Asunto { get => asunto; set => asunto = value; }
        [Column("fecha")]
        public DateTime Fecha { get => fecha; set => fecha = value; }
        [Column("respuesta")]
        public string Respuesta { get => respuesta; set => respuesta = value; }
        [Column("id_contestador")]
        public int Id_contestador { get => id_contestador; set => id_contestador = value; }
        [Column("fecha_respuesta")]
        public DateTime Fecha_respuesta { get => fecha_respuesta; set => fecha_respuesta = value; }
        [Column("estado_respuesta")]
        public int Estado_respuesta { get => estado_respuesta; set => estado_respuesta = value; }
    }
}
