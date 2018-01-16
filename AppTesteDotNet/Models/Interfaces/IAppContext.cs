using System.Data.Entity;
using AppTesteDotNet.Models.Entities;

namespace AppTesteDotNet.Models.Intefaces
{
    public interface IAppContext
    {
        DbSet<Categoria> Categorias { get; set; }
        DbSet<SubCategoria> SubCategorias { get; set; }
        int SaveChanges();
    }
}