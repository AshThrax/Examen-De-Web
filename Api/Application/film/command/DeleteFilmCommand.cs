using Api.Domain.Entities;
using Application.Common.Exceptions;
using Application.Common.Interfaces.Application.Common.Interfaces;
using MediatR;

namespace Application.Films.Command
{
    public class DeleteFilmCommand : IRequest
    {
        public int Id { get; set; }

    }
    public class DeleteFilmCommandHandler : IRequestHandler<DeleteFilmCommand>
    {
            private readonly IApplicationDbContext _context;

            public DeleteFilmCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
            {

                var entity = await _context.Film.FindAsync(request.Id);
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Film), request.Id);
                }

                _context.Film.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        
    }
}
