using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CinemaFinal.Models
{
    public class Utils
    {
        public static string GenerateHash(string password)
        {
            var sha = SHA1.Create();
            byte[] buffer = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha.ComputeHash(buffer);
            string hash64 = Convert.ToBase64String(hash);
            return hash64;
        }
    }
}