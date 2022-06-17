namespace UI.Models
{
    public class FilmViewModel
    {
        public int? Id { get; set; }

        public string? Titre{ get; set; }
        public DateTime? Date { get; set; }
        public string genre { get; set; }
        public string? Description { get; set; }

        public ICollection<ActeurViewModel>? Acteurs { get; set; }
    }
}
