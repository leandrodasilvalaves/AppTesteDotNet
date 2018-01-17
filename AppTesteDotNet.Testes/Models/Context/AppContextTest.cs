using AppTesteDotNet.Models.Entities;
using AppTesteDotNet.Models.Intefaces;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace AppTesteDotNet.Testes.Models.Context
{
    public class AppContextTest : IAppContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }

        public AppContextTest()
        {
            Categorias = new TesteCategoriaDbSet();
            SubCategorias = new TesteSubCategoriaDbSet();
        }

        public void Dispose() { }

        public DbEntityEntry Entry(object entity)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
