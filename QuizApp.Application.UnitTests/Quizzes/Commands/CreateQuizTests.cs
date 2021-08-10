using AutoMapper;
using Moq;
using QuizApp.Application.Features.Quizzes.Commands.CreateQuiz;
using QuizApp.Application.Interfaces.Application;
using ex = QuizApp.Application.Exceptions;
using QuizApp.Persistence;
using System.Threading.Tasks;
using Xunit;
using FluentValidation.Results;

namespace QuizApp.Application.UnitTests.Quizzes.Commands
{
    [Collection("ApplicationCommandCollection")]
    public class CreateQuizTests
    {
        private readonly QuizDbContext _context;
        private IMapper _mapper;
        private readonly Mock<IValidation<CreateQuizCommand>> _validationMock;
        private readonly CreateQuizCommand _createQuizCommand;

        public CreateQuizTests(ApplicationCommandFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
            _validationMock = new Mock<IValidation<CreateQuizCommand>>();
            _createQuizCommand = new CreateQuizCommand { CategoryId = 1, Name = "Test Quiz", NumberOfQuestions = 10 };
        }


        [Fact]
        public async Task CreateQuizHandler_ShouldReturn_Id()
        {
            var sut = new CreateQuizCommandHandler(_context, _mapper, _validationMock.Object);

            var result = await sut.Handle(_createQuizCommand, System.Threading.CancellationToken.None);

            Assert.True(result > 0);
        }

        [Fact]
        public async Task CreateQuizHandler_ThrowsValidationException_WhenInvalid()
        {
            _validationMock.Setup(x => x.Validate(It.IsAny<CreateQuizCommandValidator>(), _createQuizCommand))
                .Throws(new ex.ValidationException(new ValidationResult()));

            var sut = new CreateQuizCommandHandler(_context, _mapper, _validationMock.Object);

            await Assert.ThrowsAsync<ex.ValidationException>(async() => await sut.Handle(_createQuizCommand, System.Threading.CancellationToken.None));
        }
    }
}
