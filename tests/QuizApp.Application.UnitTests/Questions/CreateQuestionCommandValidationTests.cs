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

        [Theory]
        [ClassData(typeof(QuestionTextGenerator))]
        public void Should_HaveError_WhenTextIsInvalid(string text)
        {
            var command = new CreateQuestionCommand
            {
                Text = text,
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
            result.ShouldHaveValidationErrorFor(x => x.Text);
        }


        [Theory]
        [InlineData("")]
        [InlineData("fjfjeizlksssdfzefzpoefzeokpzokfpzjbpobpozpzbpozpfozkefpozekfpozokefpozkefpzkpofezefzf")]
        public void Should_HaveError_WhenOneOfAnswersIsInvalid(string text)
        {
            var command = new CreateQuestionCommand
            {
                Text = "dit is een vraag",
                Answers = new List<CreateAnswerDto>
                {
                    new CreateAnswerDto
                    {
                        Text = text,
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
            result.ShouldHaveValidationErrorFor("Answers[0].Text");
        }
    }

   

    public class QuestionTextGenerator : IEnumerable<object[]>
    {

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {""},
            new object[] {new string('x',501)}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
