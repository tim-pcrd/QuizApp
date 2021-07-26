﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public string Text { get; set; }
        public bool Correct { get; set; }
        public int QuestionId { get; set; }
    }
}
