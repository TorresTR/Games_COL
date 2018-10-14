using System.Data.Entity;
using Utilitarios;
using Persistencia_funciones;

namespace Data
{
    public class Mapeo : DbContext
    {
        static Mapeo()
        {
            Database.SetInitializer<Mapeo>(null);
        }
        private readonly string schema;

        public Mapeo(string schema)
            : base("name=Games_Col")
        {
            this.schema = schema;
        }
        
        public DbSet<Entity_post> post { get; set; }
        public DbSet<Entity_usuario> usuario { get; set; }
        public DbSet<Entity_comentarios> comentario { get; set; }
        public DbSet<Entity_pqr> pqr { get; set; }
        public DbSet<Entity_contacto> contacto { get; set; }
        public DbSet<Entity_reporte> Reporte { get; set; }
        public DbSet<Entity_reporteModer> ReporteModer { get; set; }
        public DbSet<Entity_etiqueta> etiqueta { get; set; }
        public DbSet<Entity_idioma> idioma { get; set; }
        public DbSet<Entity_controlesIdioma> controles { get; set; }
        public DbSet<Entiry_formularioIdioma> formu { get; set; }
        public DbSet<actualizar_estado_bloqueo> actua_est { get; set; }
        public DbSet<Entity_token_recuperacion_user> token_recupera { get; set; }
        public DbSet<Entity_solicitud> solicitud { get; set; }
        public DbSet<Entity_noticias> noticas { get; set; }
        public DbSet<Entity_puntuacion> puntos { get; set; }
        public DbSet<Entity_rango> rango { get; set; }
        public DbSet<Entity_reporte_comentarios> coment_repo { get; set; }
        //public DbSet<Noticia> noticia { get; set; } // agregar
        //public DbSet<Puntuacion> puntuacion { get; set; }//agregar
        //public DbSet<Rango> rango { get; set; }//agregar
        //public DbSet<Reporte_Post> report { get; set; }//agregar

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema(this.schema);

            base.OnModelCreating(builder);
        }
    }
}