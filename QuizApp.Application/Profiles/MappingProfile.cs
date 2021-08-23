using AutoMapper;
using QuizApp.Application.Dtos;
using QuizApp.Application.Features.Players.Commands;
using QuizApp.Application.Features.Quizzes.Commands.CreateQuiz;
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
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Quiz, GetQuizzesByUserVm>()
                .ForMember(
                    dest => dest.Category,
                    opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(
                    dest => dest.CreatorName,
                    opt => opt.MapFrom(src => src.Creator.UserName));
            CreateMap<Category, CategoryDto>();
            CreateMap<Answer, AnswerDto>();
            CreateMap<Question, QuestionDto>()
                .ForMember(
                    dest => dest.ImageUrl,
                    opt => opt.MapFrom(src => src.Image.Url));
            CreateMap<Quiz, GetQuizDetailsVm>()
                 .ForMember(
                    dest => dest.Category,
                    opt => opt.MapFrom(src => src.Category.Name))
                 .ForMember(
                    dest => dest.CreatorName,
                    opt => opt.MapFrom(src => src.Creator.UserName));
            CreateMap<CreateQuizCommand, Quiz>();
            CreateMap<CreatePlayerCommand, Player>();

        }
    }
}
