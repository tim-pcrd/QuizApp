﻿using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommand : IRequest<int>
    {
        public int QuizId { get; set; }
        public string Text { get; set; }
        public ICollection<CreateAnswerDto> Answers { get; set; } = new List<CreateAnswerDto>();

    }

    public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
    {
        public CreateQuestionCommandValidator()
        {

            RuleFor(x => x.QuizId)
               .GreaterThan(0);

            RuleFor(x => x.Text)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Answers)
                .Must(x => x.Count == 4)
                    .WithMessage("Elke vraag moet precies 4 antwoorden hebben")
                .Must(x => x.Where(x => x.Correct).ToList().Count == 1)
                    .WithMessage("Elke vraag moet 1 juist antwoord en 3 foute antwoorden hebben")
                .ForEach(x => x.SetValidator(new CreateAnswerDtoValidator()));

        }
    }

    public class CreateAnswerDto
    {
        public string Text { get; set; }
        public bool Correct { get; set; }
    }

    public class CreateAnswerDtoValidator: AbstractValidator<CreateAnswerDto>
    {
        public CreateAnswerDtoValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}