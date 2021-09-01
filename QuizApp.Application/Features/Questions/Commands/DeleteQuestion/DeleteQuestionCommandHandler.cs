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

namespace QuizApp.Application.Features.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand>
    {
        private readonly IDbContext _context;

        public DeleteQuestionCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _context.Questions.FindAsync(request.QuestionId)
                ?? throw new NotFoundException(nameof(Question), request.QuestionId);

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
