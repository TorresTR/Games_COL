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
    
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            this.autenticacion = new HashSet<autenticacion>();
            this.sesiones = new HashSet<sesiones>();
            this.noticias = new HashSet<noticias>();
            this.post = new HashSet<post>();
            this.pqr = new HashSet<pqr>();
            this.puntuacion = new HashSet<puntuacion>();
            this.reporte_comentarios = new HashSet<reporte_comentarios>();
            this.reporte_post = new HashSet<reporte_post>();
            this.solicitud = new HashSet<solicitud>();
            this.token_recuperacion_user = new HashSet<token_recuperacion_user>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string nick { get; set; }
        public string correo { get; set; }
        public string contra { get; set; }
        public Nullable<int> puntos { get; set; }
        public Nullable<int> id_rol { get; set; }
        public Nullable<int> id_rango { get; set; }
        public Nullable<int> estado { get; set; }
        public string session { get; set; }
        public Nullable<System.DateTime> ultima_modificacion { get; set; }
        public Nullable<int> interacciones { get; set; }
        public Nullable<System.DateTime> fecha_interaccion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<autenticacion> autenticacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sesiones> sesiones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<noticias> noticias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<post> post { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pqr> pqr { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<puntuacion> puntuacion { get; set; }
        public virtual rango rango { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reporte_comentarios> reporte_comentarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reporte_post> reporte_post { get; set; }
        public virtual rol rol { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<solicitud> solicitud { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<token_recuperacion_user> token_recuperacion_user { get; set; }
    }
}
