using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Domain;

namespace Totvs.ATS.Crosscuting.Shared
{
    public static class Utils
    {
        public static string EncodePassword(Candidate candidate)
        {
            var hashPassword = new PasswordHasher<Candidate>();
            return hashPassword.HashPassword(candidate, candidate.Password);
        }

        public static bool VerifyPassword(Candidate candidate, string password)
        {
            var hashPassword = new PasswordHasher<Candidate>();
            return PasswordVerificationResult.Success == hashPassword.VerifyHashedPassword(candidate, candidate.Password, password);
        }
    }
}
