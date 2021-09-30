using FluentValidation.TestHelper;
using QuizApp.Application.Features.Questions.Commands.CreateQuestion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QuizApp.Application.UnitTests.Questions
{
    public class CreateQuestionCommandValidationTests
    {
        private CreateQuestionCommandValidator validator;
        private CreateAnswerDtoValidator answerValidator;

        public CreateQuestionCommandValidationTests()
        {
            validator = new CreateQuestionCommandValidator();
            answerValidator = new CreateAnswerDtoValidator();
        }

        [Fact]
        public void Should_HaveNoErrors_WhenValidModel()
        {
            var command = new CreateQuestionCommand
            {
                Text = "dit is een vraag",
                QuizId = 1,
                Answers = new List<CreateAnswerDto>
                {
                    new CreateAnswerDto
                    {
                        Text = "dit is een antwoord",
                        Correct = true,
                        Order = 1
                    },
                     new CreateAnswerDto
                    {
                        Text = "dit is een antwoord",
                        Correct = false,
                        Order = 2
                    },
                      new CreateAnswerDto
                    {
                        Text = "dit is een antwoord",
                        Correct = false,
                        Order = 3
                    },
                       new CreateAnswerDto
                    {
                        Text = "dit is een antwoord",
                        Correct = false,
                        Order = 4
                    }
                }
            };

            var result = validator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Should_HaveError_WhenText_HasMoreThan500characters()
        {
            var command = new CreateQuestionCommand { Text = new string('x', 501) };
            var result = validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Text);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_HaveError_WhenText_IsEmpty(string text)
        {
            var command = new CreateQuestionCommand { Text = text };
            var result = validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Text);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_HaveError_WhenQuizId_IsLessThan1(int id)
        {
            var command = new CreateQuestionCommand { QuizId = id };
            var result = validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Text);
        }

        [Fact]
        public void Should_HaveError_WhenOneOfAnswersText_IsLongerThan50Characters()
        {
            var answer = new CreateAnswerDto { Text = new string('x', 51) };

            var result = answerValidator.TestValidate(answer);
            result.ShouldHaveValidationErrorFor(x => x.Text);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_HaveError_WhenOneOfAnswersText_IsEmpty(string text)
        {

            var answer = new CreateAnswerDto { Text = text };

            var result = answerValidator.TestValidate(answer);
            result.ShouldHaveValidationErrorFor(x => x.Text);
        }



        [Fact]
        public void Should_HaveError_WhenMultipleAnswers_AreTrue()
        {
            var command = new CreateQuestionCommand
            {
                Answers = new List<CreateAnswerDto>
                {
                    new CreateAnswerDto
                    {
                        Text = "dit is een antwoord",
                        Correct = true
                    },
                     new CreateAnswerDto
                    {
                        Text = "dit is een antwoord",
                        Correct = true
                    },
                      new CreateAnswerDto
                    {
                        Text = "dit is een antwoord",
                        Correct = false
                    },
                       new CreateAnswerDto
                    {
                        Text = "dit is een antwoord",
                        Correct = false
                    }
                }
            };

            var result = validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Answers)
                .WithErrorMessage("Elke vraag moet 1 juist antwoord en 3 foute antwoorden hebben");
        }

        [Fact]
        public void Should_HaveError_WhenAllAnswers_AreFalse()
        {
            var command = new CreateQuestionCommand
            {
                Answers = new List<CreateAnswerDto>
                {
                    new CreateAnswerDto
                    {
                        Text = "dit is een antwoord",
                        Correct = false
                    },
                     new CreateAnswerDto
                    {
                        Text = "dit is een antwoord",
                        Correct = false
                    },
                      new CreateAnswerDto
                    {
                        Text = "dit is een antwoord",
                        Correct = false
                    },
                       new CreateAnswerDto
                    {
                        Text = "dit is een antwoord",
                        Correct = false
                    }
                }
            };

            var result = validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Answers)
                 .WithErrorMessage("Elke vraag moet 1 juist antwoord en 3 foute antwoorden hebben");
        }

        [Theory]
        [InlineData(0,0,0,0)]
        [InlineData(1,2,3,5)]
        public void Should_HaveError_WhenAnswers_DontHaveOrder1To4(int a, int b, int c, int d)
        {
            var command = new CreateQuestionCommand
            {
                Text = "dit is een vraag",
                QuizId = 1,
                Answers = new List<CreateAnswerDto>
                {
                    new CreateAnswerDto
                    {
                        Text = "dit is een antwoord",
                        Correct = true,
                        Order = a
                    },
                     new CreateAnswerDto
                    {
                        Text = "dit is een antwoord",
                        Correct = false,
                        Order = b
                    },
                      new CreateAnswerDto
                    {
                        Text = "dit is een antwoord",
                        Correct = false,
                        Order = c
                    },
                       new CreateAnswerDto
                    {
                        Text = "dit is een antwoord",
                        Correct = false,
                        Order = d
                    }
                }
            };

            var result = validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Answers)
                .WithErrorMessage("Elke antwoord moet een uniek volgordenummer hebben tusen 1 en 4");
            
        }
    }

   

}
