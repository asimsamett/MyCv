﻿using FluentValidation;
using MediatR;

namespace MyCv.Application
{
    
    public class ValidatorDI<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        {
            private readonly IEnumerable<IValidator<TRequest>> _validators;

            public ValidatorDI(IEnumerable<IValidator<TRequest>> validators)
            {
                _validators = validators;
            }

            public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
            {
                var context = new ValidationContext<TRequest>(request);
                var failures = _validators
                    .Select(v => v.Validate(context))
                    .SelectMany(result => result.Errors)
                    .Where(f => f != null)
                    .ToList();

                if (failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }

                return await next();
            }
        }
    }

