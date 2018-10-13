using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia_funciones
{
    [Serializable]
    [Table("reporte_comentarios", Schema = "usuario")]
    public class Entity_reporte_comentarios
    {
        private Int32 id_reporte_coment;
        private Int32 id_com_reportado;
        private String contenido;
        private DateTime fecha;
        private Int32 id_user;

        [Key]
        [Column("id_reporte_coment")]
        public int Id_reporte_coment { get => id_reporte_coment; set => id_reporte_coment = value; }
        [Column("id_com_reportado")]
        public int Id_com_reportado { get => id_com_reportado; set => id_com_reportado = value; }
        [Column("contenido")]
        public string Contendio { get => contenido; set => contenido = value; }
        [Column("fecha")]
        public DateTime Fecha { get => fecha; set => fecha = value; }
        [Column("id_user")]
        public int Id_user { get => id_user; set => id_user = value; }
    }
}
