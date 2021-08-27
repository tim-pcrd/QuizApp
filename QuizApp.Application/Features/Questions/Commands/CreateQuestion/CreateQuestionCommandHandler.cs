using AutoMapper;
using MediatR;
using QuizApp.Application.Interfaces.Application;
using QuizApp.Application.Interfaces.Persistence;
using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, int>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidation<CreateQuestionCommand, CreateQuestionCommandValidator> _validation;

        public CreateQuestionCommandHandler(IDbContext context, IMapper mapper, IValidation<CreateQuestionCommand, CreateQuestionCommandValidator> validation)
        {
            _context = context;
            _mapper = mapper;
            _validation = validation;
        }

        public async Task<int> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            _validation.Validate(request);

            var question = _mapper.Map<Question>(request);

            _context.Questions.Add(question);
            await _context.SaveChangesAsync(cancellationToken);

            return question.Id;

        }
    }

}
