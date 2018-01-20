using AppTesteDotNet.TipoDeCampos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppTesteDotNet.Models.Entities
{
    public class Campo
    {
        public int Id { get; set; }
        public int Ordem { get; set; }
        public string Descricao { get; set; }
        public int Tipo { get; set; }

        public int SubCategoriaId { get; set; }
        public virtual SubCategoria SubCategoria { get; set; }

        [NotMapped]
        public string HTML { get; set; }

        public virtual ICollection<Lista> Lista { get; set; }
        
        public Campo()
        {
            Lista = new List<Lista>();
        }

        public string Renderizar(ITipoDeCampo tipoDeCampo)
        {
            HTML = tipoDeCampo.Renderizar();
            return HTML;
        }
        
    }
}