using FluentValidation;
using MediatR;

namespace QuizApp.Application.Features.Quizzes.Commands.CreateQuiz
{

    public class CreateQuizCommand : IRequest
    {
        public string Name { get; set; }
        public int NumberOfQuestions { get; set; }
        public int CategoryId { get; set; }
    }

    public class CreateQuizCommandValidator : AbstractValidator<CreateQuizCommand>
    {
        public CreateQuizCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Naam is verplicht.")
                .NotNull()
                .MaximumLength(30).WithMessage("Naam mag maximaal 30 tekens bevatten.");

            RuleFor(x => x.NumberOfQuestions)
                .Must(x => x == 10 || x == 20).WithMessage("Aantal vragen moet 10 of 20 zijn.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0);
        }
    }
}
