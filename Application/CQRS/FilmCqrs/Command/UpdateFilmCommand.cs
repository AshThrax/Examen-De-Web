using Film_api.Model;
using Film_api.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_api.CQRS.FilmCqrs.Command
{
    public class UpdateFilmCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Titre { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public class UpdateFilmCommandHandler :IRequestHandler<UpdateFilmCommand, int>
        {
            private readonly IServiceFilm _serviceFilm;
            public UpdateFilmCommandHandler(IServiceFilm serviceFilm)
            {
                _serviceFilm = serviceFilm;
            }

            public async Task<int> Handle(UpdateFilmCommand Command, CancellationToken Cancellation)
            { 
                var entity = new Film
                {
                    Id = Command.Id,
                    Titre = Command.Titre,
                    Date = Command.Date,
                    Description = Command.Description
                };


                return await _serviceFilm.UpdateFilm(entity);
            }
        }
    }
}
