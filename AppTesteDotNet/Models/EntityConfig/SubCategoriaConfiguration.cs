using AppTesteDotNet.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AppTesteDotNet.Models.EntityConfig
{
    public class SubCategoriaConfiguration : EntityTypeConfiguration<SubCategoria> 
    {
        public SubCategoriaConfiguration()
        {
            ToTable("subCategoria");

            HasKey(s => s.Id);
            Property(s => s.Id)
                .HasColumnName("id");

            Property(s => s.Descricao)
                .IsRequired()
                .HasColumnName("descricao");

            Property(s => s.Slug)
                .IsRequired()
                .HasColumnName("slug");

            Property(s => s.CategoriaId)
                .HasColumnName("categoriaId");

            HasRequired(s => s.Categoria)
                .WithMany(c => c.SubCategorias)
                .HasForeignKey(s => s.CategoriaId);

        }
    }
}