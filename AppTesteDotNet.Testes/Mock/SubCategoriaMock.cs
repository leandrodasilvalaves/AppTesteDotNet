using AppTesteDotNet.Models.Entities;
using AppTesteDotNet.Models.Intefaces;
using System.Linq;

namespace AppTesteDotNet.Testes.Mock
{
    public static class SubCategoriaMock
    {
        public static SubCategoria SubCategoriaDemo()
        {
            return new SubCategoria { Descricao = "SubCategoria Teste", Slug = "subcategoria-teste"};
        }

        public static void InserirSubCategoriasNoContextoSeVazio(IAppContext context)
        {
            if (context.SubCategorias.Count() == 0)
            {
                context.SubCategorias.Add(new SubCategoria { Id = 1, Descricao = "SubCategoria Teste1", Slug = "subcategoria-teste1" });
                context.SubCategorias.Add(new SubCategoria { Id = 2, Descricao = "SubCategoria Teste2", Slug = "subcategoria-teste2" });
                context.SubCategorias.Add(new SubCategoria { Id = 3, Descricao = "SubCategoria Teste3", Slug = "subcategoria-teste3" });
                context.SubCategorias.Add(new SubCategoria { Id = 4, Descricao = "SubCategoria Teste4", Slug = "subcategoria-teste4" });
            }
        }
    }
}
