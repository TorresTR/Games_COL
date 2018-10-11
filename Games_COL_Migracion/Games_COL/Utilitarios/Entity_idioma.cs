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
    [Table("idiomas", Schema = "idioma")]
    public class Entity_idioma
    {
        private Int32 id;
        private String nombre;
        private String terminacion;
        private String estado;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("terminacion")]
        public string Terminacion { get => terminacion; set => terminacion = value; }
        [Column("estado")]
        public string Estado { get => estado; set => estado = value; }
    }
}
