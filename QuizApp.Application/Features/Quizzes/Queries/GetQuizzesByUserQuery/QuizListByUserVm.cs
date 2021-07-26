using QuizApp.Application.Dtos;
using System;

namespace QuizApp.Application.Features.Quizzes.Queries.GetQuizzesByUserQuery
{

    public class QuizListByUserVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfQuestions { get; set; }
        public string Category { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public CreatorDto Creator { get; set; }

    }
}
