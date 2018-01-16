using System.Collections.Generic;

namespace AppTesteDotNet.Models.Entities
{
    public class Campo
    {
        public int Id { get; set; }
        public int Ordem { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }

        public int SubCategoriaId { get; set; }
        public virtual SubCategoria SubCategoria { get; set; }

        public virtual ICollection<Lista> Lista { get; set; }

        public Campo()
        {
            Lista = new List<Lista>();
        }
    }
}