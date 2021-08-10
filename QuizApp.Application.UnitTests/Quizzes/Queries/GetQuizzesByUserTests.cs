using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using QuizApp.Application.Features.Quizzes.Queries.GetQuizzesByUser;
using QuizApp.Application.Helpers;
using QuizApp.Application.Interfaces.Persistence;
using QuizApp.Application.Profiles;
using QuizApp.Domain.Entities;
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
    public class GetQuizzesByUserTests
    {
        private readonly QuizDbContext _context;
        private readonly IMapper _mapper;

        public GetQuizzesByUserTests(ApplicationQueryFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetQuizzesByUserHandler_ShouldReturn_PaginatedResult()
        {
            var sut = new GetQuizzesByUserQueryHandler(_mapper, _context);

            var result = await sut.Handle(new GetQuizzesByUserQuery(1, 2, Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}")), CancellationToken.None);

            Assert.IsType<Pagination<GetQuizzesByUserVm>>(result);
            Assert.Equal(1, result.PageIndex);
            Assert.Equal(2, result.PageSize);
            Assert.Equal(3, result.Count);
            Assert.Equal(2, result.Data.Count);
        }
    }

   
}
