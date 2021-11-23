using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Exceptions;
using QuizApp.Application.Interfaces.Application;
using QuizApp.Application.Interfaces.Infrastructure;
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
        private readonly IFileStorageService _storageService;

        public CreateQuestionCommandHandler(
            IDbContext context, 
            IMapper mapper, 
            IValidation<CreateQuestionCommand, CreateQuestionCommandValidator> validation, 
            IFileStorageService storageService)
        {
            _context = context;
            _mapper = mapper;
            _validation = validation;
            _storageService = storageService;
        }

        public async Task<int> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            
            _validation.Validate(request);

            var quiz = await _context.Quizzes.FindAsync(request.QuizId)
                ?? throw new ValidationException(new List<string> { "QuizId bestaat niet." });

            var numberOfQuestions = await _context.Questions.CountAsync(x => x.QuizId == request.QuizId);
            if (numberOfQuestions == quiz.NumberOfQuestions)
                throw new ValidationException(new List<string> { $"Quiz bevat al het maximaal ({quiz.NumberOfQuestions}) aantal vragen." });

            if (request.ImageFile is not null)
            {
                var image = Convert.FromBase64String(request.ImageFile.Image);
                request.ImageFile.Image = await _storageService.SaveFile(image, request.ImageFile.Extension, "questions");
            }

            var question = _mapper.Map<Question>(request);

            _context.Questions.Add(question);


            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch
            {
                if(request.ImageFile is not null)
                {
                    await _storageService.DeleteFile(request.ImageFile.Image, "questions");
                }

                throw;
            }

            
            return question.Id;
        }
    }

}
