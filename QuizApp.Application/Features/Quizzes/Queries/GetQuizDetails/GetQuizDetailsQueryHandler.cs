using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Exceptions;
using QuizApp.Application.Interfaces.Persistence;
using QuizApp.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Quizzes.Queries.GetQuizDetails
{
    public class GetQuizDetailsQueryHandler : IRequestHandler<GetQuizDetailsQuery, GetQuizDetailsVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetQuizDetailsQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetQuizDetailsVm> Handle(GetQuizDetailsQuery request, CancellationToken cancellationToken)
        {
            var quiz = await _context.Quizzes
                .Include(x => x.Creator)
                .Include(x => x.Category)
                .Include(x => x.Questions).ThenInclude(x => x.Answers)
                .SingleOrDefaultAsync(x => x.Id == request.Id);

            if (quiz is null) throw new NotFoundException(nameof(Quiz), request.Id);

            return _mapper.Map<GetQuizDetailsVm>(quiz);
        }
    }
}
