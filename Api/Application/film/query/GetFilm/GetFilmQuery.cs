using Application.Common.Interfaces.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Films.Query.GetFilm
{
    public class GetFilmQuery : IRequest<IEnumerable<FilmDto>>
    {

    }
        public class GetFilmQueryHandler : IRequestHandler<GetFilmQuery, IEnumerable<FilmDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetFilmQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<FilmDto>> Handle(GetFilmQuery request, CancellationToken cancellationToken)
            {

                IEnumerable<FilmDto> lst = await _context.Film.ProjectTo<FilmDto>(_mapper.ConfigurationProvider).OrderBy(t => t.Title).ToListAsync(cancellationToken);
                return lst;
            }
        }
    
}
