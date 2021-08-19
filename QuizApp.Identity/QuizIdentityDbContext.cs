using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Identity
{
    public class QuizIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public QuizIdentityDbContext(DbContextOptions<QuizIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().Property(x => x.UserName).HasMaxLength(20);       
        }
    }
}
