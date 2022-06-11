using Application.Common.Interfaces.Application.Common.Interfaces;
using Api.Domain.Entities;
using MediatR;

namespace Application.Films.Command
{
    public class CreateFilmCommand : IRequest<int>
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Genre { get; set; }
        public string Producteur { get; set; }

        public string Description { get; set; }

    }
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateFilmCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
            {
                var entity = new Film();

                entity.Title = request.Title;
                entity.Date = request.Date;
                entity.Genre = request.Genre;
                entity.Producer = request.Producteur;
                entity.Description = request.Description;


                _context.Film.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return (int) entity.Id;
            }
        }
    
}
