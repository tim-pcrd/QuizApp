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
    public class ApplicationQueryFixture : IDisposable
    {
        public QuizDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public ApplicationQueryFixture()
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



                for (int i = 1; i <= 6; i++)
                {

                    Context.Quizzes.Add(new Quiz
                    {
                        Id = i,
                        Name = $"Quiz {i}",
                        CreatedBy = i % 2 == 0 ? "Tim" : "Ruimtesonde",
                        Category = category,
                        Questions = GetQuestions()
                    });
                }
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

        private List<Question> GetQuestions()
        {
            return new List<Question>
                            {
                                new Question
                                {
                                    Text = "Question 1",
                                    Answers = new List<Answer>
                                    {
                                        new Answer
                                        {
                                            Text = "answer 1",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 2",
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = true
                                        }
                                    }
                                },
                                new Question
                                {
                                    Text = "Question 2",
                                    Answers = new List<Answer>
                                    {
                                        new Answer
                                        {
                                            Text = "answer 1",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 2",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = true
                                        }
                                    }
                                },
                                new Question
                                {
                                    Text = "Question 3",
                                    Answers = new List<Answer>
                                    {
                                        new Answer
                                        {
                                            Text = "answer 1",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 2",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = true
                                        }
                                    }
                                },
                                   new Question
                                {
                                    Text = "Question 4",
                                    Answers = new List<Answer>
                                    {
                                        new Answer
                                        {
                                            Text = "answer 1",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 2",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = true
                                        }
                                    }
                                },
                                    new Question
                                {
                                    Text = "Question 5",
                                    Answers = new List<Answer>
                                    {
                                        new Answer
                                        {
                                            Text = "answer 1",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 2",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = true
                                        }
                                    }
                                },
                                     new Question
                                {
                                    Text = "Question 6",
                                    Answers = new List<Answer>
                                    {
                                        new Answer
                                        {
                                            Text = "answer 1",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 2",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = true
                                        }
                                    }
                                },
                                      new Question
                                {
                                    Text = "Question 7",
                                    Answers = new List<Answer>
                                    {
                                        new Answer
                                        {
                                            Text = "answer 1",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 2",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = true
                                        }
                                    }
                                },
                                       new Question
                                {
                                    Text = "Question 8",
                                    Answers = new List<Answer>
                                    {
                                        new Answer
                                        {
                                            Text = "answer 1",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 2",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = true
                                        }
                                    }
                                },
                                        new Question
                                {
                                    Text = "Question 9",
                                    Answers = new List<Answer>
                                    {
                                        new Answer
                                        {
                                            Text = "answer 1",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 2",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = true
                                        }
                                    }
                                },
                                         new Question
                                {
                                    Text = "Question 10",
                                    Answers = new List<Answer>
                                    {
                                        new Answer
                                        {
                                            Text = "answer 1",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 2",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = true
                                        }
                                    }
                                },
                            };
        }
    }

    [CollectionDefinition("ApplicationQueryCollection")]
    public class ApplicationQueryCollection: ICollectionFixture<ApplicationQueryFixture> { }


}
