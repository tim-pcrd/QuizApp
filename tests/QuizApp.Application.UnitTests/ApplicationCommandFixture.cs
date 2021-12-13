using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using QuizApp.Application.Interfaces;
using QuizApp.Application.Profiles;
using QuizApp.Domain.Entities;
using QuizApp.Domain.Enums;
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
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).EnableSensitiveDataLogging()
                .Options;

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
                    CreatedBy = "Tim",
                    Category = category,
                    NumberOfQuestions = 10,
                    Status = QuizStatus.Creating,
                    Questions = new List<Question> { }
                });

               

                //For DeleteQuiz and UpdateQuiz test
                Context.Quizzes.Add(new Quiz
                {
                    Id = 3,
                    Name = "Quiz 3",
                    CreatedBy = "Tim",
                    Category = category,
                    NumberOfQuestions = 10,
                    Questions = new List<Question> { }
                });

              

                //For CreateQuestion test
                Context.Quizzes.Add(new Quiz
                {
                    Id = 4,
                    Name = "Quiz 4",
                    CreatedBy = "Tim",
                    Category = category,
                    NumberOfQuestions = 10,
                    Questions = GetQuestions()
                });

                //Update question command
                Context.Quizzes.Add(new Quiz
                {
                    Id = 5,
                    Name = "Quiz 4",
                    CreatedBy = "Tim",
                    Category = category,
                    NumberOfQuestions = 10,
                    Questions = new List<Question>
                    {
                         new Question
                                {
                                    Id = 101,
                                    Text = "Question 1",
                                    Answers = new List<Answer>
                                    {
                                        new Answer
                                        {
                                            Id = 101,
                                            Text = "answer 1",
                                            Correct = true
                                        },
                                        new Answer
                                        {
                                            Id = 102,
                                            Text = "answer 2",
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Id = 103,
                                            Text = "answer 3",
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Id = 104,
                                            Text = "answer 4",
                                            Correct = false
                                        }
                                    }
                                }
                    }
                });





                Context.SaveChanges();
                Context.ChangeTracker.Clear();
            }

            var configurationProvider = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
                config.AddProfile<QuizMappingProfile>();        
                config.AddProfile<QuestionMappingProfile>();
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
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = false
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
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = false
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
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = false
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
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = false
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
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = false
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
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = false
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
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = false
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
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = false
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
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = false
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
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 3",
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 4",
                                            Correct = false
                                        }
                                    }
                                },
                            };
            }

        }

    //[CollectionDefinition("ApplicationCommandCollection")]
    //public class ApplicationCommandCollection: ICollectionFixture<ApplicationCommandFixture> { }


}
