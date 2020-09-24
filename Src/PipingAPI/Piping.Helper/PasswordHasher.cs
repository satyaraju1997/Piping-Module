using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Piping.Helper
{
   public class PasswordHasher 
    {
        private const int SaltSize = 16; // 128 bit 
        private const int KeySize = 32; // 256 bit
        private const int Iterations = 10000; 
        public PasswordHasher()
        {
           // Options = options.Value;
        }

        private HashingOptions Options { get; }

        public string Hash(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(
              password,
              SaltSize,
              Iterations)
                //,HashAlgorithmName.SHA512)
                )
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{Iterations}.{salt}.{key}";
            }
        }

        public bool Check(string hash, string password)
        {
            char[] param = {'.'};
            var parts = hash.Split(param, 3);

            if (parts.Length != 3)
            {
                throw new FormatException("Unexpected hash format. " +
                  "Should be formatted as `{iterations}.{salt}.{hash}`");
            }

            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            var needsUpgrade = iterations != Iterations;

            using (var algorithm = new Rfc2898DeriveBytes(
              password,
              salt,
              iterations)
              //  ,HashAlgorithmName.SHA512)
              )
            {
                var keyToCheck = algorithm.GetBytes(KeySize);

                var verified = keyToCheck.SequenceEqual(key);

                return verified;
            }
        }
    }

    public sealed class HashingOptions
    {
        public int Iterations { get; set; } = 10000;
    }
}
