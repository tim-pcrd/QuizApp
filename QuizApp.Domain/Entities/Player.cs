using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public Guid AccountId { get; set; }
    }
}
