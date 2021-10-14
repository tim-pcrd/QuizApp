using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Quizzes.Queries.CheckNameExists
{
    public class CheckNameExistsQueryhandler : IRequestHandler<CheckNameExistsQuery, bool>
    {
        private readonly IDbContext _context;

        public CheckNameExistsQueryhandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CheckNameExistsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Quizzes.AnyAsync(x => x.Name.ToLower() == request.Name.ToLower());
        }
    }
}
