using System;
using System.Security.Cryptography;
using System.Text;

namespace CrossCutting.Helpers
{
    public interface ICryptoStrategy
    {
        string Decrypt(string input);

        string Encrypt(string input);

        bool IsValid(string value, string valueEncrypt);
    }
}