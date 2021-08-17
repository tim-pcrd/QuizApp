using FluentValidation;
using MediatR;
using QuizApp.Application.Interfaces.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ex = QuizApp.Application.Exceptions;

namespace QuizApp.Application.Helpers
{
    public class Validation<T> : IValidation<T> where T : class
    {
        public void Validate(AbstractValidator<T> validator, T request)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid) throw new ex.ValidationException(validationResult);
        }

        public async Task ValidateAsync(AbstractValidator<T> validator, T request)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid) throw new ex.ValidationException(validationResult);
        }

    }
}
