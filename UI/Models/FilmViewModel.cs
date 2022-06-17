namespace UI.Models
{
    public class FilmViewModel
    {
        public int? Id { get; set; }

        public string? Title { get; set; }
        public DateTime? Date { get; set; }
        public string? Genre { get; set; }

        public string? Producer { get; set; }
        public string? Description { get; set; }

        public ICollection<ActeurViewModel>? Acteurs { get; set; }
    }
}
