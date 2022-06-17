using AutoMapper;
using Film_api.Mapping;
using Film_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_api.CQRS.ActeurCqrs
{
    public class ActeurDto :IMapFrom<Acteur>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Roles { get; set; }

       public void Mapping(Profile Profile) 
        {
            Profile.CreateMap<Acteur, ActeurDto>();
        }
        
    }
}
