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
    public  class DeleteActeurCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Roles { get; set; }

        public Film film { get; set; }
        public class DeleteActeurCommandHandler : IRequestHandler<DeleteActeurCommand, int>
        {
            private readonly IApplicationDbContext context;
            private int defautl;

            public DeleteActeurCommandHandler(IServiceActeur serviceActeur)
            {
                _serviceActeur = serviceActeur;
            }

            public async Task<int> Handle(DeleteActeurCommand Command, CancellationToken cancellationToken)
            { 
                var entity=await _serviceActeur.GetActeurById(Command.Id);
                if (entity == null)
                    return default;

                return await _serviceActeur.DeleteActeur(entity);
            }
        }
    }
}
