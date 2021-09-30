using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using QuizApp.Application.Exceptions;
using QuizApp.Application.Features.Questions.Commands.UpdateQuestion;
using QuizApp.Application.Interfaces.Application;
using QuizApp.Domain.Entities;
using QuizApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace QuizApp.Application.UnitTests.Questions.Commands
{
    public class UpdateQuestionCommandTests : IClassFixture<ApplicationCommandFixture>
    {
        private QuizDbContext context;
        private IMapper mapper;
        private Mock<IValidation<UpdateQuestionCommand, UpdateQuestionCommandValidator>> validationMock;
        private UpdateQuestionCommandHandler sut;

        public UpdateQuestionCommandTests(ApplicationCommandFixture fixture)
        {
            context = fixture.Context;
            mapper = fixture.Mapper;
            validationMock = new Mock<IValidation<UpdateQuestionCommand, UpdateQuestionCommandValidator>>();

            sut = new UpdateQuestionCommandHandler(context, mapper, validationMock.Object);
        }

        [Fact]
        public async Task UpdateQuestionHandler_ThrowsNotFoundException_WhenQuestionDoesntExist()
        {

            var command = new UpdateQuestionCommand
            {
                Id = 9999
            };

            Func<Task<MediatR.Unit>> result = () => sut.Handle(command, CancellationToken.None);

            var exception = await Assert.ThrowsAsync<NotFoundException>(result);

            Assert.Equal($"{nameof(Question)} (9999) is not found", exception.Message);

            validationMock.Verify(x => x.Validate(command), Times.Once);
        }

        [Fact]
        public async Task UpdateQuestionHandler_ThrowsValidationException_WhenOneOfAnswersDontBelongToQuestion()
        {

            var command = new UpdateQuestionCommand
            {
                Id = 101,
                Text = "updated text",
                Answers = new List<UpdateAnswerDto>
                {
                    new UpdateAnswerDto
                    {
                        Id = 101,
                        Text = "answer 1 updated",
                        Correct = true
                    },
                    new UpdateAnswerDto
                    {
                        Id = 999,
                        Text = "answer 2",
                        Correct = false
                    },
                    new UpdateAnswerDto
                    {
                        Id = 103,
                        Text = "answer 3",
                        Correct = false
                    },
                    new UpdateAnswerDto
                    {
                        Id = 104,
                        Text = "answer 4 updated",
                        Correct = false
                    }
                }
            };

            Func<Task<MediatR.Unit>> result = () => sut.Handle(command, CancellationToken.None);

            var exception = await Assert.ThrowsAsync<ValidationException>(result);

            Assert.Equal("1 of meerdere anwoorden behoren niet tot deze vraag.", exception.ValidationErrors.First());

            validationMock.Verify(x => x.Validate(command), Times.Once);
        }

    }
}
