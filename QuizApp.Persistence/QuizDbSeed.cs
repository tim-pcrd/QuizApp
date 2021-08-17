using Microsoft.Extensions.Logging;
using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Persistence
{
    public class QuizDbSeed
    {
        public static async Task SeedAsync(QuizDbContext context)
        {
                if (!context.Quizzes.Any())
                {


                var quizzes = new List<Quiz>
                    {

                        new Quiz
                        {
                            Name = "Quiz 1",
                            NumberOfQuestions = 10,
                            CreatorName = "Tim",
                            Category = new Category
                            {
                                Name = "Algemeen"
                            },
                            Questions = new List<Question>
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
                            }
                        },
                         new Quiz
                        {
                            Name = "Quiz 2",
                            NumberOfQuestions = 10,
                            CreatorName = "Ruimtesonde",
                            Category = new Category
                            {
                                Name = "Sport"
                            },
                            Questions = new List<Question>
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
                                            Correct = false
                                        },
                                        new Answer
                                        {
                                            Text = "answer 2",
                                            Correct = true
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
                            }
                        },
                          new Quiz
                        {
                            Name = "Quiz 3",
                            NumberOfQuestions = 10,
                            CreatorName = "Tim",
                            Category = new Category
                            {
                                Name = "Geschiedenis"
                            },
                            Questions = new List<Question>
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
                            }
                        },
                    };
                context.Quizzes.AddRange(quizzes);
                await context.SaveChangesAsync();
                }
            
        }
    }
}
