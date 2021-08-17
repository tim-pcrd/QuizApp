using AutoMapper;
using QuizApp.Application.Features.Quizzes.Queries.GetQuizzesByUser;
using QuizApp.Application.Profiles;
using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QuizApp.Application.UnitTests.AutoMapper
{
    public class AutoMapperTests
    {
        private IMapper _mapper;

        public AutoMapperTests()
        {
            var configurationProvider = new MapperConfiguration(config =>
            {
                config.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public void Quiz_ShouldReturn_QuizListDto()
        {
            var quiz = new Quiz
            {
                Id = 1,
                Name = "Quiz 1",
                NumberOfQuestions = 10,
                Category = new Category
                {
                    Id = 1,
                    Name = "Sport"
                },
                CreatorName = "Tim",
                StartDate = new DateTimeOffset(new DateTime(2021, 7, 31))
            };

            var quizListDto = _mapper.Map<GetQuizzesByUserVm>(quiz);

            Assert.Equal(quiz.Id, quizListDto.Id);
            Assert.Equal(quiz.Name, quizListDto.Name);
            Assert.Equal(quiz.NumberOfQuestions, quizListDto.NumberOfQuestions);
            Assert.Equal(quiz.Category.Name, quizListDto.Category);
            Assert.Equal(quiz.CreatorName, quizListDto.CreatorName);
        }
    }
}
