using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using QuizApp.Application.Exceptions;
using QuizApp.Application.Features.Quizzes.Commands.UpdateQuiz;
using QuizApp.Application.Interfaces.Application;
using QuizApp.Domain.Entities;
using QuizApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace QuizApp.Application.UnitTests.Quizzes.Commands
{
    public class UpdateQuizCommandTests : IClassFixture<ApplicationCommandFixture>
    {
        private Mock<IValidation<UpdateQuizCommand, UpdateQuizCommandValidator>> validationMock;
        private UpdateQuizCommandHandler sut;
        private QuizDbContext context;
        private IMapper mapper;

        public UpdateQuizCommandTests(ApplicationCommandFixture fixture)
        {
            context = fixture.Context;
            mapper = fixture.Mapper;
            validationMock = new Mock<IValidation<UpdateQuizCommand, UpdateQuizCommandValidator>>();

            sut = new UpdateQuizCommandHandler(context, mapper, validationMock.Object);
        }

        [Fact]
        public async Task UpdateQuizHandler_UpdatesQuiz()
        {
            var command = new UpdateQuizCommand
            {
                Id = 3,
                Name = "Quiz 3 updated",
                CategoryId = 99,
                NumberOfQuestions = 10,
            };

            await sut.Handle(command, CancellationToken.None);

            var quiz = await context.Quizzes.FirstOrDefaultAsync(x => x.Id == 3);

            Assert.Equal("Quiz 3 updated", quiz.Name);

            validationMock.Verify(x => x.Validate(command), Times.Once);
        }

        [Fact]
        public async Task UpdateQuizHandler_ThrowsNotFoundException_WhenQuizDoesntExist()
        {
            var command = new UpdateQuizCommand
            {
                Id = 9999,
                Name = "Quiz 3 updated",
                CategoryId = 99,
                NumberOfQuestions = 10,
            };

            Func<Task<MediatR.Unit>> result =() => sut.Handle(command, CancellationToken.None);

            var exception = await Assert.ThrowsAsync<NotFoundException>(result);

            Assert.Equal($"{nameof(Quiz)} (id: 9999) niet gevonden", exception.Message);

            validationMock.Verify(x => x.Validate(command), Times.Once);
        }
    }
}
