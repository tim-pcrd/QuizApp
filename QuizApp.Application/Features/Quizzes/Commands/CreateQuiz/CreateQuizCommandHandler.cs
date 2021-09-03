using AutoMapper;
using MediatR;
using QuizApp.Application.Interfaces.Persistence;
using ex = QuizApp.Application.Exceptions;
using QuizApp.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using QuizApp.Application.Helpers;
using QuizApp.Application.Interfaces.Application;
using System;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Exceptions;
using System.Collections.Generic;

namespace QuizApp.Application.Features.Quizzes.Commands.CreateQuiz
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, int>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidation<CreateQuizCommand, CreateQuizCommandValidator> _validation;

        public CreateQuizCommandHandler(IDbContext context, IMapper mapper, IValidation<CreateQuizCommand, CreateQuizCommandValidator> validation)
        {
            _context = context;
            _mapper = mapper;
            _validation = validation;
        }

       
        public async Task<int> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            _validation.Validate(request);

            var nameExists = await _context.Quizzes.AnyAsync(x => x.Name == request.Name);
            if (nameExists) throw new ValidationException(new List<string> { "Naam bestaat al" });

            var quizToCreate = _mapper.Map<Quiz>(request);

            _context.Quizzes.Add(quizToCreate);
            await _context.SaveChangesAsync(cancellationToken);

            return quizToCreate.Id;
        }
    }
}
