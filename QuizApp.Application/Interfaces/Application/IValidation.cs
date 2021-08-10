using FluentValidation;

namespace QuizApp.Application.Interfaces.Application
{
    public interface IValidation<T> where T : class
    {
        void Validate(AbstractValidator<T> validator, T request);
    }
}