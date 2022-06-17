using Application.Common.Interfaces;
using Film_api.Model;
using Film_api.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_api.CQRS.ActeurCqrs.Query
{
    public  class GetActeurByIdQuery: IRequest<Acteur>
    {
        public int Id { get; set; }
        public class GetActeurByIdQueryHandler : IRequestHandler<GetActeurByIdQuery, Acteur>
        {
            private readonly IApplicationDbContext context;
            public GetActeurByIdQueryHandler( IServiceActeur serviceActeur)
            { 
                _serviceActeur = serviceActeur;
                
            }

            public async Task<Acteur> Handle(GetActeurByIdQuery query,CancellationToken cancellationToken)
            {
                return await _serviceActeur.GetActeurById(query.Id);
            }
        }
    }
}
