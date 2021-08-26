using QuizApp.Application.Exceptions;
using QuizApp.Application.Features.Quizzes.Commands.CreateQuiz;
using QuizApp.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentValidation.TestHelper;

namespace QuizApp.Application.UnitTests.Validations
{
    public class CreateQuizCommandValidationTests
    {
        private readonly CreateQuizCommandValidator validator;

        public CreateQuizCommandValidationTests()
        {
            validator = new CreateQuizCommandValidator();
        }

        [Fact]
        public void Should_HaveNoErrors_WhenValidModel()
        {
            var createQuizCommand = new CreateQuizCommand
            {
                CategoryId = 1,
                Name = "test",
                NumberOfQuestions = 10
            };

            var result = validator.TestValidate(createQuizCommand);
            result.ShouldNotHaveAnyValidationErrors();


            //var exception = Record.Exception(() => new Validation<CreateQuizCommand>().Validate(new CreateQuizCommandValidator(), createQuizCommand));

            //Assert.Null(exception);
        }

        [Theory]
        [InlineData("")]
        [InlineData("ffjieijfiefjfjiejofizjefozjefoizjeofzeofjzeoifjozzefzfzfzefze")]
        public void Should_HaveError_WhenNameIsInvalid(string name)
        {

            var createQuizCommand = new CreateQuizCommand
            {
                CategoryId = 1,
                Name = name,
                NumberOfQuestions = 10
            };

            var result = validator.TestValidate(createQuizCommand);
            result.ShouldHaveValidationErrorFor(x => x.Name);


            //var exception = Record.Exception(() => new Validation<CreateQuizCommand>().Validate(new CreateQuizCommandValidator(), createQuizCommand));

            //Assert.IsType<ValidationException>(exception);

        }


        [Theory]
        [InlineData(9)]
        [InlineData(11)]
        [InlineData(21)]
        public void Should_HaveError_WhenNumberOfQuestionsIsInvalid(int number)
        {
            var createQuizCommand = new CreateQuizCommand
            {
                CategoryId = 1,
                Name = "test",
                NumberOfQuestions = number
            };

            var result = validator.TestValidate(createQuizCommand);
            result.ShouldHaveValidationErrorFor(x => x.NumberOfQuestions);
        }
    }
}
