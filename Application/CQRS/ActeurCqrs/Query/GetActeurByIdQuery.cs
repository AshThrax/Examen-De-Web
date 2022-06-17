using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Film_api.CQRS.ActeurCqrs.Query
{
    public  class GetActeurByIdQuery: IRequest<Acteur>
    {
        public int Id { get; set; }
        public class GetActeurByIdQueryHandler : IRequestHandler<GetActeurByIdQuery, Acteur>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper ;
            public GetActeurByIdQueryHandler(IApplicationDbContext context,IMapper mapper)
            { 
                _context = context;
                _mapper = mapper;
                
            }

            public async Task<Acteur> Handle(GetActeurByIdQuery query,CancellationToken cancellationToken)
            {
                return await _context.Acteurs.FirstOrDefaultAsync(x => x.Id == query.Id);
            }
        }
        }
    }
}
