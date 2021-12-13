using MediatR;
using QuizApp.Application.Exceptions;
using QuizApp.Application.Interfaces.Application;
using QuizApp.Application.Interfaces.Persistence;
using QuizApp.Domain.Entities;
using QuizApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Quizzes.Commands.UpdateQuizStatus
{
    public class UpdateQuizStatusCommandHandler : IRequestHandler<UpdateQuizStatusCommand>
    {
        private readonly IDbContext _context;
        private readonly IValidation<UpdateQuizStatusCommand, UpdateQuizStatusCommandValidator> _validation;

        public UpdateQuizStatusCommandHandler(IDbContext context, IValidation<UpdateQuizStatusCommand, UpdateQuizStatusCommandValidator> validation)
        {
            _context = context;
            _validation = validation;
        }

        public async Task<Unit> Handle(UpdateQuizStatusCommand request, CancellationToken cancellationToken)
        {
            _validation.Validate(request);

            var quiz = await _context.Quizzes.FindAsync(request.QuizId)
                ?? throw new NotFoundException(nameof(Quiz), request.QuizId);

            quiz.Status = Enum.Parse<QuizStatus>(request.QuizStatus);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
