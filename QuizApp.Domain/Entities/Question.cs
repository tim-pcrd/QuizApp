using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Entities
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }
        public int? ImageId { get; set; }
        public Image Image { get; set; }
        public int QuizId { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
