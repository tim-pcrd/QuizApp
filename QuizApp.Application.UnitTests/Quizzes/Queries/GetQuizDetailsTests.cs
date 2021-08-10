using AutoMapper;
using QuizApp.Application.Exceptions;
using QuizApp.Application.Features.Quizzes.Queries.GetQuizDetails;
using QuizApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace QuizApp.Application.UnitTests.Quizzes.Queries
{
    [Collection("ApplicationQueryCollection")]
    public class GetQuizDetailsTests
    {
        private readonly QuizDbContext _context;
        private readonly IMapper _mapper;

        public GetQuizDetailsTests(ApplicationQueryFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetQuizDetailsHandler_ThrowsNotFoundException_IfQuizIsNull()
        {
            var sut = new GetQuizDetailsQueryHandler(_context, _mapper);

            await Assert.ThrowsAsync<NotFoundException>(async() => await sut.Handle(new GetQuizDetailsQuery { Id = 9999 }, CancellationToken.None));
        }

        [Fact]
        public async Task GetQuizDetailsHandler_ShouldReturn_QuizDetailsVm()
        {
            var sut = new GetQuizDetailsQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetQuizDetailsQuery { Id = 1 }, CancellationToken.None);

            Assert.IsType<GetQuizDetailsVm>(result);
            Assert.Equal(1, result.Id);
        }


    }
}
