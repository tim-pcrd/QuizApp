using QuizApp.Application.Exceptions;
using QuizApp.Application.Features.Quizzes.Commands.DeleteQuiz;
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
    public class DeleteQuizCommandTests : IClassFixture<ApplicationCommandFixture>
    {
        private readonly QuizDbContext context;
        private DeleteQuizCommandHandler sut;

        public DeleteQuizCommandTests(ApplicationCommandFixture fixture)
        {
            context = fixture.Context;
            sut = new DeleteQuizCommandHandler(context);
        }

        [Fact]
        public async Task DeleteQuizHandler_DeletesQuiz()
        {
            var command = new DeleteQuizCommand(3);

            await sut.Handle(command, CancellationToken.None);

            var quiz = await context.Quizzes.FindAsync(3);

            Assert.Null(quiz);
        }

        [Fact]
        public async Task DeleteQuizHandler_ThrowsNotFoundException_WhenInvalidId()
        {
            var command = new DeleteQuizCommand(999);

            Func<Task<MediatR.Unit>> result = () => sut.Handle(command, CancellationToken.None);

            await Assert.ThrowsAsync<NotFoundException>(result);
           
        }

    }
}
