using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using QuizApp.Application.Features.Quizzes.Queries;
using QuizApp.Application.Features.Quizzes.Queries.GetQuizzesByUserQuery;
using QuizApp.Application.Helpers;
using QuizApp.Application.Interfaces.Persistence;
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

namespace QuizApp.Application.UnitTests.Quizzes.Queries
{
    public class GetMyQuizzesTests
    {

        public GetMyQuizzesTests()
        {

        }

        [Fact]
        public async Task GetMyQuizzesHandler_ShouldReturnPaginatedResult()
        {
            var dbContext = await GetDataBaseContext();

            var configurationProvider = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            var mapper = configurationProvider.CreateMapper();

            var sut = new GetQuizzesByUser.Handler(mapper, dbContext);

            var result = await sut.Handle(new GetQuizzesByUser.Query(1, 3, Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}")), CancellationToken.None);

            Assert.IsType<Pagination<QuizListByUserVm>>(result);
            Assert.Equal(1, result.PageIndex);
            Assert.Equal(3, result.PageSize);
            Assert.Equal(5, result.Count);
            Assert.Equal(3, result.Data.Count);
        }

        private async Task<QuizDbContext> GetDataBaseContext()
        {
            var options = new DbContextOptionsBuilder<QuizDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var dbContext = new QuizDbContext(options);
            dbContext.Database.EnsureCreated();
            if (await dbContext.Quizzes.CountAsync() <= 0)
            {
                var player1 = new Player
                {
                    Name = "Tim",
                    AccountId = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}")
                };

                var player2 = new Player
                {
                    Name = "Ruimtesonde",
                    AccountId = Guid.NewGuid()
                };

                var category = new Category
                {
                    Name = "Algemeen"
                };

                for (int i = 1; i <= 10; i++)
                {

                    dbContext.Quizzes.Add(new Quiz
                    {
                        Name = $"Quiz {i}",
                        Creator = i % 2 == 0 ? player1 : player2,
                        Category = category
                    });
                }
                await dbContext.SaveChangesAsync();
            }

            return dbContext;
        }
    }

   
}
