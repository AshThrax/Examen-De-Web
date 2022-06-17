using Film_api.CQRS.FilmCqrs.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.FilmCqrs.Command
{
    public class UpdateFilmValidator : AbstractValidator<UpdateFilmCommand>
    {
        public UpdateFilmValidator()
            {
                 RuleFor(c => c.Titre).NotEmpty();
            }
       
    }
}
