using System.Collections.Generic;

namespace AppTesteDotNet.Models.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<SubCategoria> SubCategorias { get; set; }

        public Categoria()
        {
            SubCategorias = new List<SubCategoria>();
        }
    }
}