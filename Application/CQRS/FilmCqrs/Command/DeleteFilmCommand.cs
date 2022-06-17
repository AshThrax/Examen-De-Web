using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Film_api.CQRS.FilmCqrs.Command
{
    public class DeleteFilmCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string Titre { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public Film film { get; set; }

        public class DeleteFilmCommandHandler : IRequestHandler<DeleteFilmCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteFilmCommandHandler(IApplicationDbContext context)
            { 
                _context = context;
            }

            public async Task<int> Handle(DeleteFilmCommand Command, CancellationToken cancellationToken)
            {
                var entity = await _context.Films.Where(x => x.Id==Command.Id).First();
                if (entity == null)
                    return default;

                _context.Films.Remove(entity);
                return await _context.SaveChangesAsync();
            }
        }
    }
}
