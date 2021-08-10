using QuizApp.Application.Exceptions;
using QuizApp.Application.Features.Quizzes.Commands.CreateQuiz;
using QuizApp.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QuizApp.Application.UnitTests.Validations
{
    public class CreateQuizCommandValidation
    {
        [Fact]
        public void Should_ThrowNoException_WhenValid()
        {
            var createQuizCommand = new CreateQuizCommand
            {
                CategoryId = 1,
                Name = "test",
                NumberOfQuestions = 10
            };


            var exception = Record.Exception(() => new Validation<CreateQuizCommand>().Validate(new CreateQuizCommandValidator(), createQuizCommand));

            Assert.Null(exception);
        }

        [Theory]
        [InlineData("", "Naam is verplicht.")]
        [InlineData("ffjieijfiefjfjiejofizjefozjefoizjeofzeofjzeoifjozzefzfzfzefze", "Naam mag maximaal 30 tekens bevatten.")]
        public void Should_ThrowException_WhenNameIsInvalid(string name, string message)
        {

            var createQuizCommand = new CreateQuizCommand
            {
                CategoryId = 1,
                Name = name,
                NumberOfQuestions = 10
            };


            var exception = Record.Exception(() => new Validation<CreateQuizCommand>().Validate(new CreateQuizCommandValidator(), createQuizCommand));

            Assert.IsType<ValidationException>(exception);
            Assert.Equal("Name", ((ValidationException)exception).ValidationErrors.First().Key);
            Assert.Equal(message, ((ValidationException)exception).ValidationErrors.First().Value);

        }


        [Theory]
        [InlineData(9)]
        [InlineData(11)]
        [InlineData(21)]
        public void Should_ThrowException_WhenNumberOfQuestionsIsInvalid(int number)
        {
            var createQuizCommand = new CreateQuizCommand
            {
                CategoryId = 1,
                Name = "test",
                NumberOfQuestions = number
            };

            var exception = Record.Exception(() => new Validation<CreateQuizCommand>().Validate(new CreateQuizCommandValidator(), createQuizCommand));

            Assert.IsType<ValidationException>(exception);
            Assert.Equal("NumberOfQuestions", ((ValidationException)exception).ValidationErrors.First().Key);
            Assert.Equal("Aantal vragen moet 10 of 20 zijn.", ((ValidationException)exception).ValidationErrors.First().Value);

        }
    }
}
