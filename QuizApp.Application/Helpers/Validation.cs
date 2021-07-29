using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ex = QuizApp.Application.Exceptions;

namespace QuizApp.Application.Helpers
{
    public class Validation<T> where T : class
    {
        public static void Validate(AbstractValidator<T> validator, T request)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid) throw new ex.ValidationException(validationResult);
        }
    }
}
