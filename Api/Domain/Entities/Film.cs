using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class Film
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? Title { get; set; }
        public DateTime? Date { get; set; }
        public string? Genre { get; set; }

        public string? Producer { get; set; }
        public string? Description { get; set; }

        public ICollection<Acteur>? Acteurs { get; set; }
        public Film()
        {
            Acteurs = new Collection<Acteur>();
        }




        /*
         public void AddActeur(string actor)
         { 
             var isAlready= Acteurs.Any(i =>i.Equals(actor));
             //si ma variable reponds a ma condition if je renvoie une exception perosnnalisée
             if (isAlready)
             { 
                 throw new ActorAlreadyExistException(this.Title,actor);
             }
             Acteurs.Add(actor);

         }
        */
    }
}
