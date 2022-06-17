using Film_api.CQRS.ActeurCqrs.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ActeurCqrs.Command
{
    public class CreateacteurValidator : AbstractValidator<CreateActeurCommand>
    {
        public CreateacteurValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c =>c.film).NotEmpty();
        }
    }
}
