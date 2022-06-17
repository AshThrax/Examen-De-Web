using MediatR;
using Film_api.Model;
using Film_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Film_api.Service;

namespace Film_api.CQRS.FilmCqrs.Querry
{
    public class GetAllFilmQuery : IRequest<IEnumerable<Film>>
    {
       public class GetAllFilmQueryHandler : IRequestHandler<GetAllFilmQuery, IEnumerable<Film>>
        {
            private readonly IServiceFilm _filmService;
            public GetAllFilmQueryHandler(IServiceFilm filmService)
            {
                _filmService = filmService;
            }

            public async Task<IEnumerable<Film>> Handle(GetAllFilmQuery query, CancellationToken cancellationToken)
            {
                return await _filmService.GetallFilm();
            }
        }
    }
}
