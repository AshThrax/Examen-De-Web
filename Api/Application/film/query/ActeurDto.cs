using Application.Common.Mapping;

namespace Api.Application.film.query
{
    public class ActeurDto :IMapFrom<ActeurDto>
    {
        public int id { get; set; }
        public string? name { get; set; }
      

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<ActeurDto, ActeurDto>();
        }
    }
}
