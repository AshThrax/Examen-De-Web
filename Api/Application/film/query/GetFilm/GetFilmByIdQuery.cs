using Application.Common.Interfaces;
using Application.Common.Interfaces.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Api.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Films.Query.GetFilm
{
    public class GetFilmbyIdQuery : IRequest<FilmDto>
    {
      public int Id { get; set; }
    }

    public class GetFilmQueryIdHandler : IRequestHandler<GetFilmbyIdQuery, FilmDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetFilmQueryIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FilmDto> Handle(GetFilmbyIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Film.ProjectTo<FilmDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
               
            return  entity;

        }
    }
}
