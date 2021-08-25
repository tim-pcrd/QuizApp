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

namespace QuizApp.Application.Features.Players.Commands.DeletePlayer
{
    public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand>
    {
        private readonly IDbContext _context;

        public DeletePlayerCommandHandler(IDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = await _context.Players.FindAsync(request.PlayerId)
                ?? throw new NotFoundException(nameof(Player), request.PlayerId);

            _context.Players.Remove(player);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
