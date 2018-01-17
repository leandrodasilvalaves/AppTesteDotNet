using Newtonsoft.Json;
using System.Collections.Generic;

namespace AppTesteDotNet.Models.Entities
{
    public class SubCategoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Slug { get; set; }

        public int CategoriaId { get; set; }
        [JsonIgnore]
        public virtual Categoria Categoria { get; set; }

        [JsonIgnore]
        public virtual ICollection<Campo> Campos { get; set; }

        public SubCategoria()
        {
            Campos = new List<Campo>();
        }
    }
}