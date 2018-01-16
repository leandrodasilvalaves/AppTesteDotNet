using AppTesteDotNet.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AppTesteDotNet.Models.EntityConfig
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            ToTable("categoria");

            HasKey(c => c.Id);
            Property(c => c.Id)
                .HasColumnName("id");

            Property(c => c.Descricao)
                .IsRequired()
                .HasColumnName("descricao");

            Property(c => c.Slug)
                .IsRequired()
                .HasColumnName("slug");
        }
    }
}