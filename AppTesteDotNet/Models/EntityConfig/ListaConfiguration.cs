using AppTesteDotNet.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AppTesteDotNet.Models.EntityConfig
{
    public class ListaConfiguration : EntityTypeConfiguration<Lista>
    {
        public ListaConfiguration()
        {
            ToTable("lista");

            HasKey(l => l.Id);
            Property(l => l.Id)
                .HasColumnName("id");

            Property(l => l.Descricao)
                .IsRequired()
                .HasColumnName("descricao");

            Property(l => l.CampoId)
                .HasColumnName("campoId");

            HasRequired(l => l.Campo)
                .WithMany(c => c.Lista)
                .HasForeignKey(l => l.CampoId);
        }
    }
}