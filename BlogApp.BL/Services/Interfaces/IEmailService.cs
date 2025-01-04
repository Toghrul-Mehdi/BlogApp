using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Interfaces
{
    public interface IEmailService
    {
        Task<string> GenerateEmailVerificationToken(string email);
        Task<string> SendVerificationEmail(string email);
        Task VerifyEmail(string token);
    }
}
