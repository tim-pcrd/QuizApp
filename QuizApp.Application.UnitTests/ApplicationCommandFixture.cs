using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using QuizApp.Application.Interfaces;
using QuizApp.Application.Profiles;
using QuizApp.Domain.Entities;
using QuizApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QuizApp.Application.UnitTests
{
    public class ApplicationCommandFixture : IDisposable
    {
        public QuizDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public ApplicationCommandFixture()
        {
            var options = new DbContextOptionsBuilder<QuizDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var loggedInUserServiceMock = new Mock<ILoggedInUserService>();

            Context = new QuizDbContext(options, loggedInUserServiceMock.Object);

            Context.Database.EnsureCreated();
            if (!Context.Quizzes.Any())
            {
                var player1 = new Player
                {
                    Name = "Tim",
                    Id = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}")
                };

                var category = new Category
                {
                    Name = "Algemeen"
                };

                Context.Quizzes.Add(new Quiz
                {
                    Id = 1,
                    Name = "Quiz 1",
                    Creator = player1,
                    Category = category,
                    NumberOfQuestions = 10
                });

                Context.SaveChanges();
            }

            var configurationProvider = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }


        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }

    }

    [CollectionDefinition("ApplicationCommandCollection")]
    public class ApplicationCommandCollection: ICollectionFixture<ApplicationCommandFixture> { }


}
