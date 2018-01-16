namespace AppTesteDotNet.Models.Entities
{
    public class Lista
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public int CampoId { get; set; }
        public virtual Campo Campo { get; set; }
    }
}