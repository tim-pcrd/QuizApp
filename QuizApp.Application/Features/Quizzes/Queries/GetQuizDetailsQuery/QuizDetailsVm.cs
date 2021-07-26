using QuizApp.Application.Dtos;
using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Quizzes.Queries.GetQuizDetailsQuery
{
    public class QuizDetailsVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfQuestions { get; set; }
        public string Category { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public CreatorDto Creator { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}
