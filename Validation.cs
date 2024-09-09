using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace qansapi
{

    public static class Validation
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;
        public static bool EmailValidation(string email)
        {
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isEmail;
        }

        public static bool PhoneNumberValidation(string phoneNumber)
        {
            bool isEmail = Regex.IsMatch(phoneNumber, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", RegexOptions.IgnoreCase);
            return isEmail;
        }

        public static string EncryptPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            // Create hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 5);
            var hash = pbkdf2.GetBytes(HashSize);

            // Combine salt and hash
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            // Convert to base64
            var base64Hash = Convert.ToBase64String(hashBytes);
            return base64Hash;
        }
    }
}
