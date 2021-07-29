using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public Dictionary<string, string> ValidationErrors { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new Dictionary<string, string>();

            foreach(var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.PropertyName, validationError.ErrorMessage);
            }
        }
    }
}
