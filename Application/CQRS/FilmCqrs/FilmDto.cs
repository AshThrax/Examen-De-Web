using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities;
using Film_api.CQRS.ActeurCqrs;

namespace Film_api.CQRS.FilmCqrs
{
    public class FilmDto:IMapFrom<Film>
    { 
        public FilmDto()
        {
            Acteurs = new List<ActeurDto>();
        }
        public int Id { get; set; }
        public string Titre { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public IList<ActeurDto> Acteurs { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Film, FilmDto>();
        }
       
    }
}
