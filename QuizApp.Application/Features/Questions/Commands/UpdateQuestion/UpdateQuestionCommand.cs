using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Questions.Commands.UpdateQuestion
{
    public class UpdateQuestionCommand : IRequest
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string Text { get; set; }
        public ICollection<UpdateAnswerDto> Answers { get; set; } = new List<UpdateAnswerDto>();
    }

    public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
    {
        public UpdateQuestionCommandValidator()
        {
            RuleFor(x => x.QuizId)
               .GreaterThan(0);

            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Text)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Answers)
                .Must(x => x.Count == 4)
                    .WithMessage("Elke vraag moet precies 4 antwoorden hebben")
                .Must(x => x.Where(x => x.Correct).ToList().Count == 1)
                    .WithMessage("Elke vraag moet 1 juist antwoord en 3 foute antwoorden hebben")
                .ForEach(x => x.SetValidator(new UpdateAnswerDtoValidator()));

        }
    }

    public class UpdateAnswerDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Correct { get; set; }
    }

    public class UpdateAnswerDtoValidator : AbstractValidator<UpdateAnswerDto>
    {
        public UpdateAnswerDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Text)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
