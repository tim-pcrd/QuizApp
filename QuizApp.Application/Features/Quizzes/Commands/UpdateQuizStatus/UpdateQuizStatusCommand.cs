using FluentValidation;
using MediatR;
using QuizApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Quizzes.Commands.UpdateQuizStatus
{
    public class UpdateQuizStatusCommand : IRequest
    {
        public UpdateQuizStatusCommand(int quizId, string quizStatus)
        {
            QuizId = quizId;
            QuizStatus = quizStatus;
        }

        public int QuizId { get; }
        public string QuizStatus { get; }
    }

    public class UpdateQuizStatusCommandValidator : AbstractValidator<UpdateQuizStatusCommand>
    {
        public UpdateQuizStatusCommandValidator()
        {
            RuleFor(x => x.QuizStatus)
                .IsEnumName(typeof(QuizStatus));

            RuleFor(x => x.QuizId)
                .GreaterThan(0);
        }
    }
}
