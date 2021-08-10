using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Common
{
    public interface IPlayerProps
    {
        public Guid CreatorId { get; set; }
        public Player Creator { get; set; }
    }
}
