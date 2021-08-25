using Microsoft.EntityFrameworkCore;
using QuizApp.Application.Interfaces;
using QuizApp.Application.Interfaces.Persistence;
using QuizApp.Domain.Common;
using QuizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuizApp.Persistence
{
    public class QuizDbContext : DbContext, IDbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public QuizDbContext(DbContextOptions<QuizDbContext> options, ILoggedInUserService loggedInUserService) : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuizDbContext).Assembly);
        }

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    foreach (var entry in ChangeTracker.Entries<Quiz>())
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Entity.CreatorId = await _loggedInUserService.GetPlayerId();
        //        }
        //    }


        //    return await base.SaveChangesAsync(cancellationToken);
        //}

    }
}
