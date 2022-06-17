using Film_api.Model;
using Film_api.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_api.CQRS.FilmCqrs.Querry
{
    public class GetFilmByIdQuery :IRequest<Film>
    {
        public int Id { get; set; }
        public class GetFilmByIdQueryHandler : IRequestHandler<GetFilmByIdQuery, Film>
        {
            private readonly IServiceFilm _filmService;
            public GetFilmByIdQueryHandler(IServiceFilm filmService)
            {
                _filmService = filmService;
            }

            public async Task<Film> Handle(GetFilmByIdQuery query, CancellationToken cancellationToken)
            {
                return await _filmService.GetFilmByid(query.Id);
            }
        }
    }
}
