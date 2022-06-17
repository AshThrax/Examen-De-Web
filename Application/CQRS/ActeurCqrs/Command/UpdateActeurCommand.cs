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
    public  class UpdateActeurCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Roles { get; set; }

        public Film film { get; set; }
        public class UpdateActeurCommandHandler : IRequestHandler<UpdateActeurCommand,int>
        {
            private readonly IServiceActeur _serviceActeur;
            public UpdateActeurCommandHandler(IServiceActeur serviceActeur)
            {
                _serviceActeur = serviceActeur;
            }

            public async Task<int> Handle(UpdateActeurCommand command, CancellationToken cancellationToken)
            {
                var entity = new Acteur 
                {
                    Id = command.Id,
                    Name = command.Name,
                    Roles = command.Roles,
                    film = command.film
                };
                return await _serviceActeur.UpdateActeur(entity);
            }
        }
    }
}
