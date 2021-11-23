using AutoMapper;
using QuizApp.Application.Dtos;
using QuizApp.Application.Features.Quizzes.Commands.CreateQuiz;
using QuizApp.Application.Features.Quizzes.Commands.UpdateQuiz;
using QuizApp.Application.Features.Quizzes.Queries.GetQuizDetails;
using QuizApp.Application.Features.Quizzes.Queries.GetQuizzesByUser;
using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Profiles
{
    public class QuizMappingProfile : Profile
    {
        public QuizMappingProfile()
        {
            CreateMap<Quiz, GetQuizzesByUserVm>()
             .ForMember(
                 dest => dest.Category,
                 opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Quiz, GetQuizDetailsVm>()
               .ForMember(
                  dest => dest.Category,
                  opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CreateQuizCommand, Quiz>();

            CreateMap<UpdateQuizCommand, Quiz>();

            CreateMap<Category, CategoryDto>();

            CreateMap<Question, QuestionDto>();



        }
    }
}
