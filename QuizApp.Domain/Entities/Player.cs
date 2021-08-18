﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int? ImageId { get; set; }
        public Image Image { get; set; }
    }
}
