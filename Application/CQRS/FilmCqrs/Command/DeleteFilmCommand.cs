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
   public class DeleteFilmCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string Titre { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public Film film { get; set; }

        public class DeleteFilmCommandHandler : IRequestHandler<DeleteFilmCommand, int>
        {
            private readonly IServiceFilm _serviceFilm;
            public DeleteFilmCommandHandler(IServiceFilm serviceFilm)
            { 
              _serviceFilm = serviceFilm;
            }

            public async Task<int> Handle(DeleteFilmCommand Command, CancellationToken cancellationToken)
            {
                var entity = await _serviceFilm.GetFilmByid(Command.Id);
                if (entity == null)
                    return default;

                return await _serviceFilm.Deletefilm(entity);
            }
        }
    }
}
