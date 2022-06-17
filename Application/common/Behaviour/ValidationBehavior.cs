using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = Application.Common.Exceptions.ValidationException;

namespace Application.Common.Behaviours
{
    public  class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest,TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _Validator;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _Validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_Validator.Any())
            {
                var context = new ValidationContext<TRequest>(request) ;
                
                var validationResult= await Task.WhenAll(_Validator.Select(v => v.ValidateAsync(context, cancellationToken)));
                var Failures = validationResult.SelectMany(r =>r.Errors).Where(f =>f !=null).ToList();

                if (Failures.Count != 0)
                {
                    throw new ValidationException(Failures);
                }
            }
            return await next();
        }
    }
}
