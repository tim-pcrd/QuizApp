using AutoMapper;
using MediatR;
using QuizApp.Application.Exceptions;
using QuizApp.Application.Features.Quizzes.Commands.CreateQuiz;
using QuizApp.Application.Interfaces.Application;
using QuizApp.Application.Interfaces.Persistence;
using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Quizzes.Commands.UpdateQuiz
{
    public class UpdateQuizCommandHandler : IRequestHandler<UpdateQuizCommand>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidation<UpdateQuizCommand, UpdateQuizCommandValidator> _validation;

        public UpdateQuizCommandHandler(IDbContext context, IMapper mapper, IValidation<UpdateQuizCommand, UpdateQuizCommandValidator> validation)
        {
            _context = context;
            _mapper = mapper;
            _validation = validation;
        }

        public async Task<Unit> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {
            _validation.Validate(request);

            var quiz = await _context.Quizzes.FindAsync(request.Id)
                ?? throw new NotFoundException(nameof(Quiz), request.Id);

            _mapper.Map(request, quiz);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
