using Api.Domain.Entities;
using Application.Common.Interfaces.Application.Common.Interfaces;
using MediatR;

namespace Application.Films.Command
{
    public class UpdateFilmCommand : IRequest
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime? Date { get; set; }
        public string? Genre { get; set; }

        public string? Producer { get; set; }
        public string? Description { get; set; }

        public Acteur? Acteur { get; set; }

    }
    public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommand>
        {
            private readonly IApplicationDbContext _context;

            public UpdateFilmCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateFilmCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Film.FindAsync(new object[] { request.Id }, cancellationToken);

                entity.Title = request.Title;
                entity.Date = request.Date;
                entity.Genre = request.Genre;
                entity.Producer = request.Producer;
                entity.Description = request.Description;
                entity.Acteurs.Add(request.Acteur);

                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }

