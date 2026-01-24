using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Domain.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password, string securityStamp);
        PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword, string securityStamp);
    }

    public enum PasswordVerificationResult
    {
        Success,
        Failed,
        SuccessRehashNeeded
    }

    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 128 / 8; // 16 bytes
        private const int SubkeyLength = 256 / 8; // 32 bytes
        private const int IterationCount = 10000;

        public string HashPassword(string password, string securityStamp)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (securityStamp == null) throw new ArgumentNullException(nameof(securityStamp));

            // Combine password with security stamp
            var combinedPassword = password + securityStamp;

            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] subkey = KeyDerivation.Pbkdf2(
                password: combinedPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: IterationCount,
                numBytesRequested: SubkeyLength
            );

            var outputBytes = new byte[1 + SaltSize + SubkeyLength];
            outputBytes[0] = 0x01; // Format marker
            Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, SubkeyLength);

            return Convert.ToBase64String(outputBytes);
        }

        public PasswordVerificationResult VerifyHashedPassword(
            string hashedPassword,
            string providedPassword,
            string securityStamp)
        {
            if (hashedPassword == null) throw new ArgumentNullException(nameof(hashedPassword));
            if (providedPassword == null) throw new ArgumentNullException(nameof(providedPassword));
            if (securityStamp == null) throw new ArgumentNullException(nameof(securityStamp));

            var decodedHashedPassword = Convert.FromBase64String(hashedPassword);

            // Check format marker
            if (decodedHashedPassword[0] != 0x01)
                return PasswordVerificationResult.Failed;

            // Extract salt and subkey
            var salt = new byte[SaltSize];
            Buffer.BlockCopy(decodedHashedPassword, 1, salt, 0, SaltSize);

            var storedSubkey = new byte[SubkeyLength];
            Buffer.BlockCopy(decodedHashedPassword, 1 + SaltSize, storedSubkey, 0, SubkeyLength);

            // Combine provided password with security stamp
            var combinedPassword = providedPassword + securityStamp;

            // Hash the provided password
            byte[] providedSubkey = KeyDerivation.Pbkdf2(
                password: combinedPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: IterationCount,
                numBytesRequested: SubkeyLength
            );

            // Compare
            if (CryptographicOperations.FixedTimeEquals(providedSubkey, storedSubkey))
            {
                return PasswordVerificationResult.Success;
            }

            return PasswordVerificationResult.Failed;
        }
    }
}
