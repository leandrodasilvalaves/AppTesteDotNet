using AppTesteDotNet.Models.Entities;
using System.Linq;

namespace AppTesteDotNet.Testes.Models.Context
{
    public class TesteSubCategoriaDbSet : TestDbSet<SubCategoria>
    {
        public override SubCategoria Find(params object[] keyValues)
        {
            return this.SingleOrDefault(c => c.Id == (int)keyValues.Single());
        }
    }
}
