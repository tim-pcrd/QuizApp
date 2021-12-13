using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using QuizApp.Application.Exceptions;
using QuizApp.Application.Features.Quizzes.Commands.UpdateQuizStatus;
using QuizApp.Application.Interfaces.Application;
using QuizApp.Domain.Entities;
using QuizApp.Domain.Enums;
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
    public class UpdateQuizStatusCommandTests : IClassFixture<ApplicationCommandFixture>
    {
        private readonly QuizDbContext context;
        private readonly Mock<IValidation<UpdateQuizStatusCommand, UpdateQuizStatusCommandValidator>> validationMock;
        private readonly UpdateQuizStatusCommandHandler sut;

        public UpdateQuizStatusCommandTests(ApplicationCommandFixture fixture)
        {
            context = fixture.Context;
            validationMock = new Mock<IValidation<UpdateQuizStatusCommand, UpdateQuizStatusCommandValidator>>();

            sut = new UpdateQuizStatusCommandHandler(context, validationMock.Object);

            context.ChangeTracker.Clear();
        }

        [Fact]
        public async Task UpdateQuizStatusHandler_UpdatesQuiz()
        {
            var command = new UpdateQuizStatusCommand(1,"Ready");

            await sut.Handle(command, CancellationToken.None);

            var quiz = await context.Quizzes.FindAsync(1);

            Assert.Equal(Enum.Parse<QuizStatus>(command.QuizStatus), quiz.Status);

            validationMock.Verify(x => x.Validate(command), Times.Once);
        }

        [Fact]
        public async Task UpdateQuizHandler_ThrowsNotFoundException_WhenQuizDoesntExist()
        {
            var command = new UpdateQuizStatusCommand(1111, "Ready");

            Func<Task<MediatR.Unit>> result = () => sut.Handle(command, CancellationToken.None);
            var exception = await Assert.ThrowsAsync<NotFoundException>(result);

            Assert.Equal($"{nameof(Quiz)} (id: 1111) niet gevonden", exception.Message);

            validationMock.Verify(x => x.Validate(command), Times.Once);
        }
    }
}
