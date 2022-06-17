using Film_api.Model;
using Film_api.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_api.CQRS.ActeurCqrs.Command
{
    public class CreateActeurCommand :IRequest<Acteur>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Roles { get; set; }

        public Film film { get; set; }

        public class CreateActeurCommandHandler : IRequestHandler<CreateActeurCommand, Acteur>
        {
            private readonly IServiceActeur _serviceActeur;
            public CreateActeurCommandHandler(IServiceActeur serviceActeur)
            { 
                _serviceActeur = serviceActeur;
            }

            public async Task<Acteur> Handle(CreateActeurCommand command, CancellationToken cancellationToken)
            {
                var entity = new Acteur 
                {
                   Id = command.Id,
                   Name = command.Name,
                   Roles = command.Roles,
                   film = command.film,
                };

                return await _serviceActeur.CreateActeur(entity);
            }
        }
    }
}
