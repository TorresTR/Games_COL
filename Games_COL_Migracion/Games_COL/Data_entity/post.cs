//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data_entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public post()
        {
            this.reporte_post = new HashSet<reporte_post>();
        }
    
        public int id_post { get; set; }
        public string titulo { get; set; }
        public string contenido { get; set; }
        public System.DateTime fecha { get; set; }
        public Nullable<int> puntos { get; set; }
        public Nullable<int> autor { get; set; }
        public Nullable<int> etiqueta { get; set; }
        public Nullable<int> estado_bloqueo { get; set; }
        public Nullable<int> user_bloqueador { get; set; }
        public Nullable<int> num_puntos { get; set; }
    
        public virtual estado_bloqueo estado_bloqueo1 { get; set; }
        public virtual etiquetas etiquetas { get; set; }
        public virtual usuario usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reporte_post> reporte_post { get; set; }
    }
}
