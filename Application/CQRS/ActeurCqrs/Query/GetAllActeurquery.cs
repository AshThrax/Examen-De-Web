using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Film_api.CQRS.ActeurCqrs.Query
{
    public class GetAllActeurQuery : IRequest<List<ActeurDto>>
    {
        public int FilmId { get; set; }
        public class GetAllActeurQueryHandler:IRequestHandler<GetAllActeurQuery,List<ActeurDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public GetAllActeurQueryHandler(IApplicationDbContext context,IMapper mapper)
            {
               _context = context;
               _mapper = mapper;
            }

            public async Task<List<ActeurDto>> Handle(GetAllActeurQuery query, CancellationToken cancellationToken)
            {
                List<ActeurDto> act =await _context.Acteurs
                                                    .ProjectTo<ActeurDto>(_mapper.ConfigurationProvider).Where(x =>x.Filmid==query.FilmId)
                                                    .ToListAsync();
                return act;
            }
        }
    }
}
