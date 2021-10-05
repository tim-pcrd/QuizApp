using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Application.Features.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IReadOnlyList<CategorieVm>>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<CategorieVm>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categoriesFromDb = await _context.Categories.ToListAsync();

            return _mapper.Map<IReadOnlyList<CategorieVm>>(categoriesFromDb);
        }

    }
}
