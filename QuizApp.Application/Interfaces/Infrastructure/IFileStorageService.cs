using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Application.Interfaces.Infrastructure
{
    public interface IFileStorageService
    {
        Task<string> SaveFile(byte[] content, string extension, string containerName);
        Task DeleteFile(string fileRoute, string containerName);
        Task<string> EditFile(byte[] content, string extension, string containerName, string fileRoute);
    }
}
