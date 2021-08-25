using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Helpers;
using QuizApp.Application.Interfaces;
using QuizApp.Application.Interfaces.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Quizzes.Queries.GetQuizzesByUser
{

    public class GetQuizzesByUserQueryHandler : IRequestHandler<GetQuizzesByUserQuery, Pagination<GetQuizzesByUserVm>>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _context;

        public GetQuizzesByUserQueryHandler(IMapper mapper, IDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Pagination<GetQuizzesByUserVm>> Handle(GetQuizzesByUserQuery request, CancellationToken cancellationToken)
        {
            var quizzes = await _context.Quizzes
                .Where(x => x.CreatedBy == request.UserName)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Include(x => x.Category)
                .ToListAsync();

            var count = await _context.Quizzes.Where(x => x.CreatedBy == request.UserName).CountAsync();

            return new Pagination<GetQuizzesByUserVm>(
                request.PageIndex, request.PageSize, count, _mapper.Map<IReadOnlyList<GetQuizzesByUserVm>>(quizzes));
        }
    }

}
