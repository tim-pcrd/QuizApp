using QuizApp.Application.Features.Quizzes.Queries.CheckNameExists;
using QuizApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace QuizApp.Application.UnitTests.Quizzes.Queries
{
    [Collection("ApplicationQueryCollection")]
    public class CheckNameExistsTests
    {
        private readonly QuizDbContext _context;

        public CheckNameExistsTests(ApplicationQueryFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task CheckNameExistsHandler_ShouldReturnTrue_WhenNameExists()
        {
            var sut = new CheckNameExistsQueryhandler(_context);

            var result = await sut.Handle(new CheckNameExistsQuery("Quiz 1"), CancellationToken.None);

            Assert.True(result);
        }

        [Fact]
        public async Task CheckNameExistsHandler_ShouldReturnFalse_WhenNameDoesntExists()
        {
            var sut = new CheckNameExistsQueryhandler(_context);

            var result = await sut.Handle(new CheckNameExistsQuery("Quiz 9999"), CancellationToken.None);

            Assert.False(result);
        }
    }
}
