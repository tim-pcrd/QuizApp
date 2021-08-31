using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Quizzes.Commands.UpdateQuiz
{
    public class UpdateQuizCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfQuestions { get; set; }
        public int CategoryId { get; set; }
    }

    public class UpdateQuizCommandValidator: AbstractValidator<UpdateQuizCommand>
    {
        public UpdateQuizCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.NumberOfQuestions)
                .Must(x => x == 10 || x == 20).WithMessage("{PropertyName} moet 10 of 20 zijn.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0);

            RuleFor(x => x.Id)
                .GreaterThan(0);
        }
    }
}
