using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using QuizApp.Application.Exceptions;
using QuizApp.Application.Features.Questions.Commands.CreateQuestion;
using QuizApp.Application.Interfaces.Application;
using QuizApp.Application.Interfaces.Infrastructure;
using QuizApp.Application.Profiles;
using QuizApp.Domain.Entities;
using QuizApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace QuizApp.Application.UnitTests.Questions.Commands
{
    public class CreateQuestionCommandTests : IClassFixture<ApplicationCommandFixture>
    {
        private readonly QuizDbContext context;
        private readonly IMapper mapper;
        private readonly Mock<IValidation<CreateQuestionCommand, CreateQuestionCommandValidator>> validationMock;
        private readonly Mock<IFileStorageService> fileStorageServiceMock;

        public CreateQuestionCommandTests(ApplicationCommandFixture fixture)
        {
            context = fixture.Context;
            mapper = fixture.Mapper;

            validationMock = new Mock<IValidation<CreateQuestionCommand, CreateQuestionCommandValidator>>();
            fileStorageServiceMock = new Mock<IFileStorageService>();

        }

        [Fact]
        public async Task CreateQuestionHandler_ReturnsId()
        {
            var command = new CreateQuestionCommand
            {
                QuizId = 1,
                Text = "Dit is een vraag",
            };

            var sut = new CreateQuestionCommandHandler(context, mapper, validationMock.Object, fileStorageServiceMock.Object);

            var result = await sut.Handle(command, CancellationToken.None);

            Assert.True(result > 0);

        }

        [Fact]
        public async Task CreateQuestionHandler_ThrowsValidationException_WhenQuizDoesntExists()
        {
            var command = new CreateQuestionCommand
            {
                QuizId = 999,
                Text = "Dit is een vraag",
            };

            var sut = new CreateQuestionCommandHandler(context, mapper, validationMock.Object, fileStorageServiceMock.Object);

            Func<Task<int>> result = () => sut.Handle(command, CancellationToken.None);

            var exception = await Assert.ThrowsAsync<ValidationException>(result);
            Assert.Equal("QuizId bestaat niet.", exception.ValidationErrors.First());
            validationMock.Verify(x => x.Validate(command), Times.Once);
        }

        [Fact]
        public async Task CreateQuestionHandler_ThrowsValidationException_WhenQuizHasMaximumAmountOfQuestions()
        {
            var command = new CreateQuestionCommand
            {
                QuizId = 4,
                Text = "Dit is een vraag",
            };

            var sut = new CreateQuestionCommandHandler(context, mapper, validationMock.Object,fileStorageServiceMock.Object);

            Func<Task<int>> result = () => sut.Handle(command, CancellationToken.None);

            var exception = await Assert.ThrowsAsync<ValidationException>(result);
            Assert.Equal($"Quiz bevat al het maximaal (10) aantal vragen.", exception.ValidationErrors.First());
            validationMock.Verify(x => x.Validate(command), Times.Once);
        }
    }
}
