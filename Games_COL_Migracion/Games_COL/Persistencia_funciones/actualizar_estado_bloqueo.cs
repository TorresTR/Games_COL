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
    [Table("reporte_post", Schema = "usuario")]
    public class actualizar_estado_bloqueo
    {
        private Int32 id_reporte;
        private Int32 id_post_reportador;
        private Int32 contenido_reporte;
        private DateTime fecha_reporte;
        private Int32 user_reportador;
        private Int32 estado_resuelto;


      
        [Column("id_reporte")]
        public int Id_reporte { get => id_reporte; set => id_reporte = value; }
        [Key]
        [Column("id_post_reportador")]
        public int Id_post_reportador { get => id_post_reportador; set => id_post_reportador = value; }
        [Column("contenido_reporte")]
        public int Contenido_reporte { get => contenido_reporte; set => contenido_reporte = value; }
        [Column("fecha_reporte")]
        public DateTime Fecha_reporte { get => fecha_reporte; set => fecha_reporte = value; }
        [Column("user_reportador")]
        public int User_reportador { get => user_reportador; set => user_reportador = value; }
        [Column("estado_resuelto")]
        public int Estado_resuelto { get => estado_resuelto; set => estado_resuelto = value; }
    }
}
