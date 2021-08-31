using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Exceptions;
using QuizApp.Application.Interfaces.Application;
using QuizApp.Application.Interfaces.Persistence;
using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Questions.Commands.UpdateQuestion
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidation<UpdateQuestionCommand, UpdateQuestionCommandValidator> _validation;

        public UpdateQuestionCommandHandler(IDbContext context, IMapper mapper, IValidation<UpdateQuestionCommand, UpdateQuestionCommandValidator> validation)
        {
            _context = context;
            _mapper = mapper;
            _validation = validation;
        }
        public async Task<Unit> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _context.Questions.Include(x => x.Answers).FirstOrDefaultAsync(x => x.Id == request.Id)
                ?? throw new NotFoundException(nameof(Question), request.Id);

            _mapper.Map(request, question);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
