using System;
using Microsoft.AspNetCore.Identity;

namespace Domain.Services
{
    public class PasswordHasherService
    {
        public (string HashedPassword, string SecurityStamp) HashPasswordForSignup(string password)
        {
            // Generate a new security stamp
            string securityStamp = Guid.NewGuid().ToString();

            // Use ASP.NET Core Identity's PasswordHasher
            var passwordHasher = new PasswordHasher<object>();

            // Hash the password (security stamp is NOT used in the hash in ASP.NET Identity)
            string hashedPassword = passwordHasher.HashPassword(null, password);

            return (hashedPassword, securityStamp);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var passwordHasher = new PasswordHasher<object>();
            var result = passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);

            // Fixed: Use the correct enum from Microsoft.AspNetCore.Identity
            return result == Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success ||
                   result == Microsoft.AspNetCore.Identity.PasswordVerificationResult.SuccessRehashNeeded;
        }
    }
}
