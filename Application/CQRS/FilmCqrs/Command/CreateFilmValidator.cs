using Film_api.CQRS.FilmCqrs.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.FilmCqrs.Command
{
    public class CreateFilmValidator : AbstractValidator<CreateFilmCommand>
    {
        public CreateFilmValidator()
        {
            RuleFor(c => c.Titre).NotEmpty();
           
        }
    }
}
