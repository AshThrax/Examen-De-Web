using Film_api.Service;
using Film_api.Model;
using MediatR;

namespace Film_api.CQRS.FilmCqrs.Command
{
    public class CreateFilmCommand : IRequest<Film>
    {
        public string Titre { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public class CreateFilmCommandHandler : IRequestHandler< CreateFilmCommand, Film>
        {
            private readonly IServiceFilm _filmservice;
            public CreateFilmCommandHandler (IServiceFilm filmservice)
            {
                _filmservice = filmservice;
            }
            public async Task<Film> Handle(CreateFilmCommand command, CancellationToken cancellationToken)
            {
                var entity = new Film
                {
                    Titre = command.Titre,
                    Date = command.Date,
                    Description = command.Description,
                };

                return await _filmservice.Createfilm(entity);

            }
        }
    }
}
