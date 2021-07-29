using AutoMapper;
using MediatR;
using QuizApp.Application.Interfaces.Persistence;
using ex = QuizApp.Application.Exceptions;
using QuizApp.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using QuizApp.Application.Helpers;

namespace QuizApp.Application.Features.Quizzes.Commands.CreateQuiz
{
    public class CreateQuizHandler : IRequestHandler<CreateQuizCommand>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public CreateQuizHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            Validation<CreateQuizCommand>.Validate(new CreateQuizCommandValidator(), request);

            var quizToCreate = _mapper.Map<Quiz>(request);

            _context.Quizzes.Add(quizToCreate);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
