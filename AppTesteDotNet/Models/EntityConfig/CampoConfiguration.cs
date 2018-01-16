using AppTesteDotNet.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AppTesteDotNet.Models.EntityConfig
{
    public class CampoConfiguration : EntityTypeConfiguration<Campo>
    {
        public CampoConfiguration()
        {
            ToTable("campo");

            HasKey(c => c.Id);
            Property(c => c.Id)
                .HasColumnName("id");

            Property(c => c.Ordem)
                .IsRequired()
                .HasColumnName("ordem");

            Property(c => c.Descricao)
                .IsRequired()
                .HasColumnName("descricao");

            Property(c => c.Tipo)
                .IsRequired()
                .HasColumnName("tipo");

            Property(c => c.SubCategoriaId)
                .HasColumnName("subCategoriaId");

            HasRequired(c => c.SubCategoria)
                .WithMany(s => s.Campos)
                .HasForeignKey(c => c.SubCategoriaId);
        }
    }
}