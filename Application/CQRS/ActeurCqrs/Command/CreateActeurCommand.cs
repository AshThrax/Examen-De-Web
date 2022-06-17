using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Film_api.CQRS.ActeurCqrs.Command
{
    public class CreateActeurCommand :IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Roles { get; set; }

        public Film film { get; set; }

        public class CreateActeurCommandHandler : IRequestHandler<CreateActeurCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateActeurCommandHandler(IApplicationDbContext context)
            { 
               _context = context;
            }

            public async Task<int> Handle(CreateActeurCommand command, CancellationToken cancellationToken)
            {
                var entity = new Acteur 
                {
                   Id = command.Id,
                   Name = command.Name,
                   Roles = command.Roles,
                   Film = command.film,
                };

                _context.Acteurs.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity.Id;
            }
        }
    }
}
