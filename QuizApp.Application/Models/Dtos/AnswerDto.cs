using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Dtos
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Correct { get; set; }
        public int QuestionId { get; set; }
    }
}
