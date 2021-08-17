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

                var category = new Category
                {
                    Name = "Algemeen"
                };

                Context.Quizzes.Add(new Quiz
                {
                    Id = 1,
                    Name = "Quiz 1",
                    CreatorName = "Tim",
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
