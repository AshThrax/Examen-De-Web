using Film_api.CQRS.ActeurCqrs.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ActeurCqrs.Command
{
    public class UpdateActeurValidator : AbstractValidator<UpdateActeurCommand>
    {
        public UpdateActeurValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c =>c.Roles).NotEmpty();
           

        }
    }
}
