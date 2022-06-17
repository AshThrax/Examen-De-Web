using Api.Domain.Entities;

namespace UI.Models
{
    public class ActeurViewModel
    {
        public int id { get; set; }
        public string? name { get; set; }
        
        public FilmViewModel? Film { get; set; }
        public int Filmid { get; set; }
    }
}
