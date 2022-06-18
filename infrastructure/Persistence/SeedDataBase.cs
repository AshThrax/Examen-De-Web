using Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Persistence
{
    public  class SeedDataBase
    {
        private readonly ApplicationDbContext context;


            public SeedDataBase(ApplicationDbContext context)
            { 
                context = context ?? throw new ArgumentNullException(nameof(context));
            }

        public void Seed() {

            if (context.Films.Any()) 
            { 
                var movie = new List<Domain.Entities.Film>
                { 
                    new Domain.Entities.Film
                    {
                    Id=1,
                    Titre="the Man",
                    Description="L'histoire d'un homme qui réussi a surpasser ses peurs",
                    Date=DateTime.Now,
                    Genre="Drame"

                },
                 new Domain.Entities.Film
                 {
                     Id = 1,
                     Titre = "the M",
                     Description = "tout commence le jours ou david trouvas un medaillons sacré qui le transporta vers un monde effroyable, pourra t'il y echapper",
                     Date = DateTime.Now,
                     Genre = "Horreur"
                 },
                  new Domain.Entities.Film
                  {
                      Id = 1,
                      Titre = "Die hard 12",
                      Description = "John Mclane reprends du service ,et dois sauver le president ainsi que l'amérique",
                      Date = DateTime.Now,
                      Genre = "Drame"
                  },
                   new Domain.Entities.Film
                   {
                       Id = 1,
                       Titre = "Rambo 8",
                       Description = "le gouvernement cherche le lieutenant john rambo pour une dernière mission a Wuhan y suvrira t'il?",
                       Date = DateTime.Now,
                       Genre = "Drame"
                   } 
                };

                context.Films.AddRange(movie);
                context.SaveChanges();
            }
           
        }
    }
}
