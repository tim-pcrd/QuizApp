using QuizApp.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Questions.Queries.GetQuestionDetails
{
    public class QuestionDetailsVm
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
        public string ImageUrl { get; set; }
        public int QuizId { get; set; }
        public IEnumerable<AnswerDto> Answers { get; set; }
    }
}
