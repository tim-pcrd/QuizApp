using FluentValidation.TestHelper;
using QuizApp.Application.Features.Quizzes.Commands.UpdateQuizStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QuizApp.Application.UnitTests.Quizzes.Commands
{
    public class UpdateQuizStatusCommandValidationTests
    {
        private readonly UpdateQuizStatusCommandValidator validator;

        public UpdateQuizStatusCommandValidationTests()
        {
            validator = new UpdateQuizStatusCommandValidator();
        }

        [Fact]
        public void Should_HaveNoErrors_WhenValidModel()
        {
            var command = new UpdateQuizStatusCommand(1, "Ready");

            var result = validator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }


        [Fact]
        public void Should_HaveError_WhenStatusIsInvalid()
        {
            var command = new UpdateQuizStatusCommand(1, "sdfsdfsdfsfd");

            var result = validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.QuizStatus);
        }

        [Fact]
        public void Should_HaveError_WhenQuizIdIsInvalid()
        {
            var command = new UpdateQuizStatusCommand(0, "Ready");

            var result = validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.QuizId);
        }


    }
}
