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
    [Table("etiquetas", Schema = "usuario")]
    public class Entity_etiqueta
    {
        private int id_etiqueta;
        private string nombre_etiqueta;

        [Key]
        [Column("id_etiqueta")]
        public int Id_etiqueta { get => id_etiqueta; set => id_etiqueta = value; }
        [Column("nombre_etiqueta")]
        public string Nombre_etiqueta { get => nombre_etiqueta; set => nombre_etiqueta = value; }
    }
}
