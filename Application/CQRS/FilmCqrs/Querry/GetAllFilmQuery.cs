using MediatR;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Application.CQRS.FilmCqrs;
using AutoMapper.QueryableExtensions;
using Film_api.CQRS.FilmCqrs;

namespace Application.CQRS.FilmCqrs.Querry
{
    public class GetAllFilmQuery : IRequest<FilmVm>
    {
       public class GetAllFilmQueryHandler : IRequestHandler<GetAllFilmQuery, FilmVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public GetAllFilmQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<FilmVm> Handle(GetAllFilmQuery query, CancellationToken cancellationToken)
            {
                return new FilmVm
                {
                    Lists = await _context.Films
                    .ProjectTo<FilmDto>(_mapper.ConfigurationProvider)
                    .OrderBy(x => x.Titre)
                    .ToListAsync(cancellationToken)

                };
                   
            }
        }
    }
}
