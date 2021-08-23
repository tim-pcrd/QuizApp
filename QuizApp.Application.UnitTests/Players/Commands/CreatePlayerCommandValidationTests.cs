using FluentValidation.TestHelper;
using QuizApp.Application.Features.Players.Commands;
using QuizApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QuizApp.Application.UnitTests.Players.Commands
{
    [Collection("ApplicationCommandCollection")]
    public class CreatePlayerCommandValidationTests
    {
        private QuizDbContext _context;
        private readonly CreatePlayerCommandValidator _validator;

        public CreatePlayerCommandValidationTests(ApplicationCommandFixture fixture)
        {
            _context = fixture.Context;
            _validator = new CreatePlayerCommandValidator(_context);
        }

        [Fact]
        public void Should_HaveNoErrors_WhenModelIsValid()
        {
            var command = new CreatePlayerCommand("Eric");

            var result = _validator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Theory]
        [InlineData("")]
        [InlineData("fkeofkagslelfkdlemdld")]
        [InlineData("Tim")]
        public void Should_HaveError_WhenUserNameIsInvalid(string userName)
        {
            var command = new CreatePlayerCommand(userName);

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(x => x.UserName);
        }
    }
}
