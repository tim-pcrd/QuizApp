using MediatR;
using QuizApp.Application.Exceptions;
using QuizApp.Application.Interfaces.Persistence;
using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Quizzes.Commands.DeleteQuiz
{
    public class DeleteQuizCommandHandler : IRequestHandler<DeleteQuizCommand>
    {
        private readonly IDbContext _context;

        public DeleteQuizCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _context.Quizzes.FindAsync(request.QuizId)
                ?? throw new NotFoundException(nameof(Quiz), request.QuizId);

            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
