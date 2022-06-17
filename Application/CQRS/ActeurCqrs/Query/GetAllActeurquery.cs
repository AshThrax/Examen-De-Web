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
    public class GetAllActeurQuery:IRequest<IEnumerable<Acteur>>
    {
        public class GetAllActeurQueryHandler:IRequestHandler<GetAllActeurQuery,IEnumerable<Acteur>>
        {
            private readonly IServiceActeur _serviceActeur;
            public GetAllActeurQueryHandler(IServiceActeur serviceActeur)
            {
                _serviceActeur = serviceActeur;

            }

            public async Task<IEnumerable<Acteur>> Handle(GetAllActeurQuery query, CancellationToken cancellationToken)
            {
                return await _serviceActeur.GetAllActeur();
            }
        }
    }
}
