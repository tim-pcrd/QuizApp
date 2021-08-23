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
    public class Validation<TModel, TValidator> : IValidation<TModel, TValidator>
        where TModel: class where TValidator: AbstractValidator<TModel>, new()
    {
        private readonly TValidator _validator;

        public Validation()
        {
            _validator = new TValidator();
        }

        public void Validate(TModel model)
        {
            var validationResult = _validator.Validate(model);
            if (!validationResult.IsValid) throw new ex.ValidationException(validationResult);
        }

        public async Task ValidateAsync(TModel model)
        {
            var validationResult = await _validator.ValidateAsync(model);
            if (!validationResult.IsValid) throw new ex.ValidationException(validationResult);
        }
    }
}
