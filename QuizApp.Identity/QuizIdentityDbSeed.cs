using Microsoft.AspNetCore.Identity;
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
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var user = new ApplicationUser
            {
                Email = "picardtim@gmail.com",
                UserName = "Tim"
                
            };
        }
    }
}
