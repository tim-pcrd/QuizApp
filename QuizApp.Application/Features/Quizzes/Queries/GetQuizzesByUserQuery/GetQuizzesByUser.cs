using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Helpers;
using QuizApp.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Quizzes.Queries.GetQuizzesByUserQuery
{
    public class GetQuizzesByUser
    {
        public class Query : IRequest<Pagination<QuizListByUserVm>>
        {
            public Query(int pageIndex, int pageSize, Guid accountId)
            {
                PageIndex = pageIndex;
                PageSize = pageSize;
                AccountId = accountId;
            }

            public int PageIndex { get; }
            public int PageSize { get; }

            public Guid AccountId { get; }
        }

        public class Handler : IRequestHandler<Query, Pagination<QuizListByUserVm>>
        {
            private readonly IMapper _mapper;
            private readonly IDbContext _context;

            public Handler(IMapper mapper, IDbContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Pagination<QuizListByUserVm>> Handle(Query request, CancellationToken cancellationToken)
            {
                var quizzes = await _context.Quizzes
                    .Where(x => x.Creator.AccountId == request.AccountId)
                    .Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .Include(x => x.Category)
                    .Include(x => x.Creator)
                    .ToListAsync();

                var count = await _context.Quizzes.Where(x => x.Creator.AccountId == request.AccountId).CountAsync();

                return new Pagination<QuizListByUserVm>(
                    request.PageIndex, request.PageSize, count, _mapper.Map<IReadOnlyList<QuizListByUserVm>>(quizzes));
            }
        }
    }
}
