using AutoMapper;
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

namespace QuizApp.Application.Features.Quizzes.Queries.GetQuizDetailsQuery
{
    public class GetQuizDetails
    {
        public class Query: IRequest<QuizDetailsVm> 
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, QuizDetailsVm>
        {
            private readonly IDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QuizDetailsVm> Handle(Query request, CancellationToken cancellationToken)
            {
                var quiz = await _context.Quizzes
                    .Include(x => x.Creator)
                    .Include(x => x.Category)
                    .Include(x => x.Questions).ThenInclude(x => x.Answers)
                    .SingleOrDefaultAsync(x => x.Id == request.Id);

                if (quiz is null) throw new NotFoundException(nameof(Quiz), request.Id);

                return _mapper.Map<QuizDetailsVm>(quiz);
            }
        }

    }
}
