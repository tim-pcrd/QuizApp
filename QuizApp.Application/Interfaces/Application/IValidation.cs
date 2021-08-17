using FluentValidation;
using System.Threading.Tasks;

namespace QuizApp.Application.Interfaces.Application
{
    public interface IValidation<T> where T : class
    {
        void Validate(AbstractValidator<T> validator, T request);

        Task ValidateAsync(AbstractValidator<T> validator, T request);
    }
}