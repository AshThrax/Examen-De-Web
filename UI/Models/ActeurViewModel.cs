namespace UI.Models
{
    public class ActeurViewModel
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string Roles { get; set; }
        public FilmViewModel? Film { get; set; }
        public int Filmid { get; set; }
    }
}
