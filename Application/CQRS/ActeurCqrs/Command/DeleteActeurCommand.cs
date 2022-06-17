using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Film_api.CQRS.ActeurCqrs.Command
{
    public  class DeleteActeurCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Roles { get; set; }

        public Film film { get; set; }
        public class DeleteActeurCommandHandler : IRequestHandler<DeleteActeurCommand>
        {
            private readonly IApplicationDbContext _context;
      

            public DeleteActeurCommandHandler(IApplicationDbContext context)
            {
              _context= context;
            }

            public async Task<Unit> Handle(DeleteActeurCommand Command, CancellationToken cancellationToken)
            { 
                var entity= await _context.Acteurs
                    .Where(x =>x.Id==Command.Id)
                    .SingleOrDefaultAsync(cancellationToken);
                if (entity == null) 
                { 
                    throw new NotFoundException(nameof(Acteur),Command.Id);
                }
                   

                _context.Acteurs.Remove(entity);
                 await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
