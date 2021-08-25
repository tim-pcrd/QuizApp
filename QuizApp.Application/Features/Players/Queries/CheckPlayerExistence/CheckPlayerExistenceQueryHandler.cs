using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Players.Queries.CheckPlayerExistence
{
    public class CheckPlayerExistenceQueryHandler : IRequestHandler<CheckPlayerExistenceQuery, bool>
    {
        private readonly IDbContext _context;

        public CheckPlayerExistenceQueryHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CheckPlayerExistenceQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Players.FirstOrDefaultAsync(x => x.UserName == request.UserName);

            return !(user is null);
        }
    }
}
