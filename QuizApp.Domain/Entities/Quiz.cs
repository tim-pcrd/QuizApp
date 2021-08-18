using QuizApp.Domain.Common;
using QuizApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Entities
{
    public class Quiz : BaseEntity, IPlayerProp
    {
        public string Name { get; set; }
        public int NumberOfQuestions { get; set; }
        public int CreatorId { get; set; }
        public Player Creator { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTimeOffset CreationDate { get; private set; } = DateTimeOffset.Now;
        public DateTimeOffset? StartDate { get; set; }
        public QuizStatus Status { get; set; } = QuizStatus.Creating;
        public ICollection<Question> Questions { get; set; }
    }
}
