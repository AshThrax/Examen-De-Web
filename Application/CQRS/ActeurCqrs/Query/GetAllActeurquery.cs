﻿using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Film_api.CQRS.ActeurCqrs.Query
{
    public class GetAllActeurQuery:IRequest<IEnumerable<ActeurDto>>
    {
        public class GetAllActeurQueryHandler:IRequestHandler<GetAllActeurQuery,IEnumerable<ActeurDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public GetAllActeurQueryHandler(IApplicationDbContext context,IMapper mapper)
            {
               _context = context;
               _mapper = mapper;
            }

            public async Task<IEnumerable<ActeurDto>> Handle(GetAllActeurQuery query, CancellationToken cancellationToken)
            {
                List<ActeurDto> act =await _context.Acteurs
                                                    .ProjectTo<ActeurDto>(_mapper.ConfigurationProvider)
                                                    .ToListAsync();
                return act;
            }
        }
    }
}
