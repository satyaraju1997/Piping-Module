using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace Piping.Common
{
    public static class Utility
    {
        public static byte[] ConvertImageToByteArray(string filePath)
        {
            byte[] data;

            Image img = Image.FromFile(filePath);
            using (MemoryStream mStream = new MemoryStream())
            {
                img.Save(mStream, img.RawFormat);
                data = mStream.ToArray();
            }

            return data;
        }

        public static void SendEmail(string smtpClientaddress, string fromEmail, string toEmail, string ccEmail, string subject, string content)
        {

            MailMessage objMailMessage = new MailMessage();
            SmtpClient objSmtpClient = new SmtpClient();
            try
            {

                objMailMessage.From = new MailAddress(fromEmail);

                string[] toAddresses = !string.IsNullOrEmpty(toEmail) ? toEmail.Split(';') : new string[] { };
                if (toAddresses.Length > 0)
                {
                    foreach (string address in toAddresses)
                    {
                        if (address != string.Empty)
                            objMailMessage.To.Add(address);
                    }
                }

                ccEmail = ccEmail.TrimEnd(';');
                string[] addresses = !string.IsNullOrEmpty(ccEmail) ? ccEmail.Split(';') : new string[] { };
                if (addresses.Length > 0)
                {
                    foreach (string address in addresses)
                    {
                        if (address != string.Empty)
                            objMailMessage.CC.Add(address);
                    }
                }

                objMailMessage.Subject = subject;
                objMailMessage.IsBodyHtml = true;
                objMailMessage.Body = content;

                objSmtpClient = new SmtpClient(smtpClientaddress);
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                objSmtpClient.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                //Log.LogError(ex, Log.Severity.Error, "");                
            }
            finally
            {
                objMailMessage = null;
                objSmtpClient = null;
            }
        }

        public static string GetSalt()
        {
            byte[] bytes = new byte[128 / 8];
            using (var keyGenerator = RandomNumberGenerator.Create())
            {
                keyGenerator.GetBytes(bytes);
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        private static string GetHash(string text)
        {
            // SHA512 is disposable by inheritance.  
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                // Get the hashed string.  
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public static string CreateRandomPassword()
        {
            int length = 8;
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }

        /// <summary>
        /// Generates a Random Password
        /// respecting the given strength requirements.
        /// </summary>
        /// <param name="opts">A valid PasswordOptions object
        /// containing the password strength requirements.</param>
        /// <returns>A random password</returns>
        public static string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
        "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
        "abcdefghijkmnopqrstuvwxyz",    // lowercase
        "0123456789",                   // digits
        "!@$?_-"                        // non-alphanumeric
            };
            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }
    }
}
