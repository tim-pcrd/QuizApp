using QuizApp.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Interfaces.Identity
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<(bool Success, RegistrationResponse Response, IEnumerable<string> Errors)> RegisterAsync(RegistrationRequest request);
    }
}
