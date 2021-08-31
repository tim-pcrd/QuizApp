using FluentValidation;
using System.Threading.Tasks;

namespace QuizApp.Application.Interfaces.Application
{
    public interface IValidation<TModel, TValidator> where TModel : class where TValidator: AbstractValidator<TModel>
    {
        void Validate(TModel model);
    }
}