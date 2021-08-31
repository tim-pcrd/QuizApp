﻿using AutoMapper;
using QuizApp.Application.Features.Questions.Commands.CreateQuestion;
using QuizApp.Application.Features.Questions.Commands.UpdateQuestion;
using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Profiles
{
    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {

            CreateMap<CreateQuestionCommand, Question>();
            CreateMap<CreateAnswerDto, Answer>();

            CreateMap<UpdateQuestionCommand, Question>();
            CreateMap<UpdateAnswerDto, Answer>();
        }
    }
}
