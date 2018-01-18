using AppTesteDotNet.Models.Entities;
using AppTesteDotNet.Models.EntityConfig;
using AppTesteDotNet.Models.Intefaces;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AppTesteDotNet.Models.Context
{
    public class AppContext : DbContext, IAppContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<Campo> Campos { get; set; }

        public AppContext():base("AppTesteConexao")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            ConfigurarEntidades(modelBuilder);
        }

        private void ConfigurarEntidades(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            modelBuilder.Configurations.Add(new SubCategoriaConfiguration());
            modelBuilder.Configurations.Add(new CampoConfiguration());
            modelBuilder.Configurations.Add(new ListaConfiguration());
        }

        
    }
}