using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace chipchop.Core.Classes
{
    public class Security
    {
        public async Task<string> GetHash(string key)
        {
            MD5 code = MD5.Create();
            byte[] Input = ASCIIEncoding.Default.GetBytes(key);
            byte[] Output = code.ComputeHash(Input);
            
            var hashkey = Convert.ToBase64String(Output);
            return await Task.FromResult(hashkey);
        }

        //public static bool IsPasswordStrong(string password)
        //{
        //    return Regex.IsMatch(password, @"^(?=.{0,9})(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$");
        //}
    }
}
