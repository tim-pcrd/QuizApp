using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public Dictionary<string, ICollection<string>> ValidationErrors { get; set; }

        public ValidationException(ValidationResult validationResult) 
            : base($"Validation errors for {string.Join(",",validationResult.Errors.Select(x => x.PropertyName))}")
        {
            ValidationErrors = new Dictionary<string, ICollection<string>>();

            foreach(var validationError in validationResult.Errors)
            {
                if (ValidationErrors.ContainsKey(validationError.PropertyName))
                {
                    ValidationErrors[validationError.PropertyName].Add(validationError.ErrorMessage);
                }
                else
                {
                    ValidationErrors.Add(validationError.PropertyName, new Collection<string> { validationError.ErrorMessage });
                }
                
            }
        }
    }
}
