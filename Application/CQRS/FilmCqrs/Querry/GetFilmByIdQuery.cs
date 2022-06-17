using Application.Common.Interfaces;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Film_api.CQRS.FilmCqrs;

namespace Application.FilmCqrs.Querry
{
    public class GetFilmByIdQuery :IRequest<FilmDto>
    {
        public int Id { get; set; }
        public class GetFilmByIdQueryHandler : IRequestHandler<GetFilmByIdQuery, FilmDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public GetFilmByIdQueryHandler(IApplicationDbContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<FilmDto> Handle(GetFilmByIdQuery query, CancellationToken cancellationToken)
            {
                FilmDto film= await _context.Films
                                    .ProjectTo<FilmDto>(_mapper.ConfigurationProvider)
                                    .Where(x =>x.Id ==query.Id)
                                    .FirstOrDefaultAsync(cancellationToken);
                return film;
               
            }
        }
    }
}
