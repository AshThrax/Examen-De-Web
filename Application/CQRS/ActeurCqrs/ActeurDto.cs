using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities;

namespace Film_api.CQRS.ActeurCqrs
{
    public class ActeurDto : IMapFrom<Acteur>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Roles { get; set; }

        public int Filmid { get; set; }

       public void Mapping(Profile Profile) 
        {
            Profile.CreateMap<Acteur, ActeurDto>();
        }
        
    }
}
