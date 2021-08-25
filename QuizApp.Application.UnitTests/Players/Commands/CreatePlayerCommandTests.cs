using AutoMapper;
using FluentValidation.Results;
using Moq;
using QuizApp.Application.Features.Players.Commands;
using QuizApp.Application.Interfaces.Application;
using QuizApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using ex = QuizApp.Application.Exceptions;

namespace QuizApp.Application.UnitTests.Players.Commands
{
    [Collection("ApplicationCommandCollection")]
    public class CreatePlayerCommandTests
    {
        private readonly QuizDbContext _context;
        private readonly IMapper _mapper;
        private readonly Mock<IValidation<CreatePlayerCommand, CreatePlayerCommandValidator>> _validationMock;
        private readonly CreatePlayerCommand _command;

        public CreatePlayerCommandTests(ApplicationCommandFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _validationMock = new Mock<IValidation<CreatePlayerCommand, CreatePlayerCommandValidator>>();
            _command = new CreatePlayerCommand("Frank");
        }

        [Fact]
        public async Task CreatePlayerCommandHandler_ShouldReturnId()
        {
            var sut = new CreatePlayerCommandHandler(_context, _validationMock.Object, _mapper);

            var result = await sut.Handle(_command, CancellationToken.None);

            _validationMock.Verify(x => x.ValidateAsync(_command), Times.Once);
            Assert.True(result > 0);
        }

        [Fact]
        public async Task CreatePlayerCommandHandler_ThrowsValidationException_WhenModelIsInvalid()
        {
            _validationMock.Setup(x => x.ValidateAsync(It.IsAny<CreatePlayerCommand>()))
                .Throws(new ex.ValidationException(new ValidationResult()));

            var sut = new CreatePlayerCommandHandler(_context, _validationMock.Object, _mapper);

            await Assert.ThrowsAsync<ex.ValidationException>(async () => await sut.Handle(_command, CancellationToken.None));
        }

    }
}
