using MediatR;
using Domain.Entities;
using Application.Common.Interfaces;

namespace Film_api.CQRS.FilmCqrs.Command
{
    public class CreateFilmCommand : IRequest<int>
    {
        public string Titre { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public class CreateFilmCommandHandler : IRequestHandler< CreateFilmCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateFilmCommandHandler(IApplicationDbContext context)
            {
                _context = context
 ;            }
            public async Task<int> Handle(CreateFilmCommand command, CancellationToken cancellationToken)
            {
                var entity = new Film
                {
                    Titre = command.Titre,
                    Date = command.Date,
                    Description = command.Description,
                };

                _context.Films.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity.Id;

            }
        }
    }
}
