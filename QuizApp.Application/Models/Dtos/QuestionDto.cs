using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public int Order { get; set; }
        public int QuizId { get; set; }
        public ICollection<AnswerDto> Answers { get; set; }
    }
}
