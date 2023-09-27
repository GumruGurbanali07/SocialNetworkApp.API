using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Security.HashHelper
{
    public static class Hashing
    {
        //out- verdiyimiz parametri kenarda istifade ede  bilerik
        public static void HashPassword(string password, out byte[] passwordHash,out byte[] passwordSalt)
        {
            using HMACSHA512 hash = new();
            passwordHash = hash.ComputeHash(Encoding .UTF8.GetBytes(password));
            passwordSalt = hash.Key;
        }
        public static bool VerifyPassword(string password,  byte[] passwordHash,  byte[] passwordSalt)
        {
            using HMACSHA512 hash = new(passwordSalt);
            var hashing= hash.ComputeHash (Encoding .UTF8.GetBytes(password));
            for(int i=0; i<passwordHash.Length; i++)
            {
                if (hashing[i] != passwordHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
