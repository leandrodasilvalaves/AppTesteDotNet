using AppTesteDotNet.Models.Entities;
using AppTesteDotNet.Models.Intefaces;
using System.Linq;

namespace AppTesteDotNet.Testes.Mock
{
    public static class CategoriaMock
    {
        public static Categoria CategoriaDemo()
        {
            return new Categoria() { Id = 1, Descricao = "Categoria Teste", Slug = "categoria-teste" };
        }

        public static void InserirCategoriasNoContextoSeVazio(IAppContext context)
        {
            if(context.Categorias.Count() == 0)
            {
                context.Categorias.Add(new Categoria { Id = 1, Descricao = "Categoria Teste1", Slug = "categoria-teste1" });
                context.Categorias.Add(new Categoria { Id = 2, Descricao = "Categoria Teste2", Slug = "categoria-teste2" });
                context.Categorias.Add(new Categoria { Id = 3, Descricao = "Categoria Teste3", Slug = "categoria-teste3" });
                context.Categorias.Add(new Categoria { Id = 4, Descricao = "Categoria Teste4", Slug = "categoria-teste4" });
            }
        }


    }
}
