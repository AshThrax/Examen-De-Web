using Api.Domain.Entities;

namespace UI.Models
{
    public class Acteur
    {
        public int id { get; set; }
        public string? name { get; set; }
        
        public Film? Film { get; set; }
        public int Filmid { get; set; }
    }
}
