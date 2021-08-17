using QuizApp.Application.Dtos;
using QuizApp.Domain.Enums;
using System;

namespace QuizApp.Application.Features.Quizzes.Queries.GetQuizzesByUser
{

    public class GetQuizzesByUserVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfQuestions { get; set; }
        public string Category { get; set; }
        public QuizStatus Status { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public string CreatorName { get; set; }

    }
}
