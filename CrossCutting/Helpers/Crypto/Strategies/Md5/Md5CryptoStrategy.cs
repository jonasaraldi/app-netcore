using System;
using System.Security.Cryptography;
using System.Text;

namespace CrossCutting.Helpers.Crypto.Strategies.Md5
{
    public class Md5CryptoStrategy : IMd5CryptoStrategy
    {
        private readonly HashAlgorithm algorithm;

        public Md5CryptoStrategy()
        {
            algorithm = HashAlgorithm.Create("MD5");
        }

        public string Decrypt(string input)
        {
            var base64 = Convert.FromBase64String(input);
            var hashedBase64 = algorithm.ComputeHash(base64);
            return Encoding.UTF8.GetString(hashedBase64);
        }

        public string Encrypt(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public bool IsValid(string value, string valueEncrypt)
            => valueEncrypt.Equals(Encrypt(value));
    }
}