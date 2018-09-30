using System.Data.Entity;
using Utilitarios;

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


        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema(this.schema);

            base.OnModelCreating(builder);
        }
    }
}