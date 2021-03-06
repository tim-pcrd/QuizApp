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
        public string Status { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public string CreatedBy { get; set; }

    }
}
