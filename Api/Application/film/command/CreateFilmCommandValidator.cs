using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces.Application.Common.Interfaces;

namespace Application.Films.Command
{
    public class CreateFilmCommandValidator :AbstractValidator<CreateFilmCommand>
    {
        private readonly IApplicationDbContext context;

        public CreateFilmCommandValidator(IApplicationDbContext context)
        {
            this.context = context;

            //titre
            RuleFor(V => V.Title)
                .NotEmpty().WithMessage("Title is Required ");
        }

        public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken) 
        {
            return await context.Film
                .AllAsync(x => x.Title != title);
        }
       
    }
}
