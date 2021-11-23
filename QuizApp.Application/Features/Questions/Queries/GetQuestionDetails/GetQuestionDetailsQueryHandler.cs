using AutoMapper;
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

namespace QuizApp.Application.Features.Questions.Queries.GetQuestionDetails
{
    public class GetQuestionDetailsQueryHandler : IRequestHandler<GetQuestionDetailsQuery, QuestionDetailsVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetQuestionDetailsQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QuestionDetailsVm> Handle(GetQuestionDetailsQuery request, CancellationToken cancellationToken)
        {
            var question = await _context.Questions.FindAsync(request.QuestionId);

            if (question is null) throw new NotFoundException(nameof(Question), request.QuestionId);

            return _mapper.Map<QuestionDetailsVm>(question);
        }
    }
}
