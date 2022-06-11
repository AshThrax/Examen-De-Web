using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain;
using Application.Common.Mapping;
using AutoMapper;
using Api.Application.film.query;
using Api.Domain.Entities;

namespace Application.Films.Query.GetFilm
{
    public class FilmDto : IMapFrom<Film>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly Date { get; set; }
        public string Genre { get; set; }

        public string Producer { get; set; }
        public string Description { get; set; }
        public IList<ActeurDto> Acteurs { get; set;}
        public FilmDto()
        {
            Acteurs = new List<ActeurDto>();
        }

        public void Mapping(Profile profile){
            profile.CreateMap<Film, FilmDto>();
        }
    }
}
