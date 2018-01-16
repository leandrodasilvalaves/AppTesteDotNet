using AppTesteDotNet.Models.Entities;
using System.Linq;

namespace AppTesteDotNet.Testes.Models.Context
{
    public class TesteCategoriaDbSet : TestDbSet<Categoria>
    {
        public override Categoria Find(params object[] keyValues)
        {
            return this.SingleOrDefault(c => c.Id == (int)keyValues.Single());
        }
    }
}
