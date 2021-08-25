using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizApp.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Identity
{
    public class QuizIdentityDbSeed
    {
        public static async Task SeedAsync(QuizIdentityDbContext context, UserManager<ApplicationUser> userManager)
        {
            await context.Database.MigrateAsync();
            var user = new ApplicationUser
            {
                Email = "picardtim@gmail.com",
                UserName = "Tim",
                EmailConfirmed = true
            };

            var user2 = new ApplicationUser
            {
                Email = "ruimtesonde@gmail.com",
                UserName = "Ruimtesonde",
                EmailConfirmed = true
            };

            if((await userManager.FindByEmailAsync(user.Email)) is null)
            {
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }

            if ((await userManager.FindByEmailAsync(user2.Email)) is null)
            {
                await userManager.CreateAsync(user2, "Pa$$w0rd");
            }
        }
    }
}
