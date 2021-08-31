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
        public IEnumerable<string> ValidationErrors { get; set; }

        public ValidationException(IEnumerable<string> validationErrors)
        {
            ValidationErrors = validationErrors;
        }
    }
}
