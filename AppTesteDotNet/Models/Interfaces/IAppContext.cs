using System.Data.Entity;
using AppTesteDotNet.Models.Entities;
using System.Data.Entity.Infrastructure;

namespace AppTesteDotNet.Models.Intefaces
{
    public interface IAppContext
    {
        DbSet<Categoria> Categorias { get; set; }
        DbSet<SubCategoria> SubCategorias { get; set; }
        DbSet<Campo> Campos { get; set; }
        DbSet<Lista> Listas { get; set; }

        void Dispose();        
        DbEntityEntry Entry(object entity);
        int SaveChanges();
        
    }
}