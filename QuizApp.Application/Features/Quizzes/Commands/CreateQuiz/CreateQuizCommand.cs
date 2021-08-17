using FluentValidation;
using MediatR;
using System;

namespace QuizApp.Application.Features.Quizzes.Commands.CreateQuiz
{

    public class CreateQuizCommand : IRequest<int>
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
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.NumberOfQuestions)
                .Must(x => x == 10 || x == 20).WithMessage("{PropertyName} moet 10 of 20 zijn.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0);
        }
    }
}
