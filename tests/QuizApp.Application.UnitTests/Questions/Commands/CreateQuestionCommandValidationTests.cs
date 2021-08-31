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

        public CreateQuestionCommandValidationTests()
        {
            validator = new CreateQuestionCommandValidator();
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
                    },
                       new CreateAnswerDto
                    {
                        Text = "dit is een antwoord",
                        Correct = false
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
            var command = new CreateQuestionCommand 
            { 
                Answers = new List<CreateAnswerDto> 
                {
                    new CreateAnswerDto{Text = new string('x',51)}
                } 
            };
            var result = validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.Text);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Should_HaveError_WhenOneOfAnswersText_IsEmpty(string text)
        {
            var command = new CreateQuestionCommand
            {
                Answers = new List<CreateAnswerDto>
                {
                    new CreateAnswerDto{Text = text}
                }
            };
            var result = validator.TestValidate(command);
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
            result.ShouldHaveValidationErrorFor(x => x.Answers);
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
            result.ShouldHaveValidationErrorFor(x => x.Answers);
        }
    }

   

}
