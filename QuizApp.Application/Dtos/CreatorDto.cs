using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Dtos
{
    public class CreatorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid AccountId { get; set; }
    }
}
