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
    [Table("controles", Schema = "idioma")]
    public class Entity_controlesIdioma
    {
        private int? id;
        private String nombre;
        private int id_formulario;
        private int id_idioma;
        private String contenido;



        [Key]
        [Column("id")]
        public int? Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("id_formulario")]
        public int Id_formulario { get => id_formulario; set => id_formulario = value; }
        [Column("id_idioma")]
        public int Id_idioma { get => id_idioma; set => id_idioma = value; }
        [Column("contenido")]
        public string Contenido { get => contenido; set => contenido = value; }

        
    }


   
}
