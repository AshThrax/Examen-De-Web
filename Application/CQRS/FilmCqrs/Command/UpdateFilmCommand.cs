using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Film_api.CQRS.FilmCqrs.Command
{
    public class UpdateFilmCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Titre { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public class UpdateFilmCommandHandler :IRequestHandler<UpdateFilmCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateFilmCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateFilmCommand Command, CancellationToken cancellationToken)
            { 
                var entity = new Film
                {
                    Id = Command.Id,
                    Titre = Command.Titre,
                    Date = Command.Date,
                    Description = Command.Description
                };


                _context.Films.Update(entity);
                return await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
