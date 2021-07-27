﻿using AutoMapper;
using QuizApp.Application.Dtos;
using QuizApp.Application.Features.Quizzes.Queries.GetQuizDetailsQuery;
using QuizApp.Application.Features.Quizzes.Queries.GetQuizzesByUserQuery;
using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Quiz, QuizListByUserVm>()
                .ForMember(
                    dest => dest.Category,
                    opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<Player, CreatorDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Answer, AnswerDto>();
            CreateMap<Question, QuestionDto>()
                .ForMember(
                    dest => dest.ImageUrl,
                    opt => opt.MapFrom(src => src.Image.Url));
            CreateMap<Quiz, QuizDetailsVm>();
        }
    }
}
