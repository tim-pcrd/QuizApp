using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Exceptions;
using QuizApp.Application.Interfaces.Persistence;
using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Players.Queries
{
    public class GetPlayerIdByUserNameQuery : IRequest<int>
    {
        public GetPlayerIdByUserNameQuery(string userName)
        {
            UserName = userName;
        }
        public string UserName { get; }
    }

    public class GetPlayerIdByUserNameQueryHandler : IRequestHandler<GetPlayerIdByUserNameQuery, int>
    {
        private readonly IDbContext _context;

        public GetPlayerIdByUserNameQueryHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(GetPlayerIdByUserNameQuery request, CancellationToken cancellationToken)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.UserName == request.UserName)
                ?? throw new NotFoundException(nameof(Player), request.UserName);

            return player.Id;
        }
    }
}
